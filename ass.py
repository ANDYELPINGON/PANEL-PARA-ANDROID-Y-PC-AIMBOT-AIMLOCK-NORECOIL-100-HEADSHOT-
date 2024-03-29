import array
import collections.abc
import dataclasses
import sys

from typing import Dict, Optional

import pytest  # type: ignore

from patma import *


def checks(pat: Pattern, x: object) -> Optional[Dict[str, object]]:
    """Compare pat.match(x) the code generated by pat.translate().

    If they match, return whatever pat.match() returned.
    """
    match = pat.match(x)
    ns = {
        "X": x,
        "Sequence": collections.abc.Sequence,
        "Mapping": collections.abc.Mapping,
        "_Nope": object(),  # Used for "attribute doesn't exist"
        __name__: sys.modules[__name__],
    }
    res = eval(pat.translate("X"), ns)
    if "__builtins__" in ns:
        del ns["__builtins__"]  # We don't need this for the comparison
    if not res:
        assert match is None
        return match
    assert match is not None
    for key, value in match.items():
        assert key in ns
        assert ns[key] == value
        assert type(ns[key]) == type(value)
    return match


@dataclasses.dataclass
class MyClass:
    x: int
    y: str

    # NOTE: in 3.10 dataclasses will have this by default
    __match_args__ = ["x", "y"]


def test_value_pattern() -> None:
    # case 42:
    pat = ValuePattern(42)
    assert checks(pat, 42) == {}
    assert checks(pat, 0) is None
    assert checks(pat, 42.0) == {}
    assert checks(pat, "42") is None


def test_float_value_pattern() -> None:
    # case 42.0:
    pat = ValuePattern(42.0)
    assert checks(pat, 42.0) == {}
    assert checks(pat, 42) == {}
    assert checks(pat, 0.0) is None
    assert checks(pat, 0) is None


def test_or_pattern() -> None:
    # case 1|2|3:
    pat = OrPattern([ValuePattern(i) for i in [1, 2, 3]])
    assert checks(pat, 1) == {}
    assert checks(pat, 2) == {}
    assert checks(pat, 3) == {}
    assert checks(pat, 3.0) == {}
    assert checks(pat, 0) is None
    assert checks(pat, 4) is None
    assert checks(pat, "1") is None


def test_fancy_or_pattern() -> None:
    # case [1, 2] | [3, 4]:
    pat = OrPattern(
        [
            SequencePattern([ValuePattern(1), ValuePattern(2)]),
            SequencePattern([ValuePattern(3), ValuePattern(4)]),
        ]
    )
    assert checks(pat, [1, 2]) == {}
    assert checks(pat, [3, 4]) == {}
    assert checks(pat, 42) is None
    assert checks(pat, [2, 3]) is None
    assert checks(pat, [1, 2, 3]) is None
    assert checks(pat, [1, 2.0]) == {}


def test_capture_pattern() -> None:
    # case x:
    pat = CapturePattern("x")
    assert checks(pat, 42) == {"x": 42}
    assert checks(pat, (1, 2)) == {"x": (1, 2)}
    assert checks(pat, None) == {"x": None}


def test_wildcard_pattern() -> None:
    # case _:
    pat = WildcardPattern()
    assert checks(pat, 42) == {}
    assert checks(pat, None) == {}
    assert checks(pat, (1, 2)) == {}


def test_sequence_pattern() -> None:
    # case (x, y, z):
    pat = SequencePattern([CapturePattern(s) for s in "xyz"])
    assert checks(pat, (1, 2, 3)) == {"x": 1, "y": 2, "z": 3}
    assert checks(pat, (1, 2)) is None
    assert checks(pat, (1, 2, 3, 4)) is None
    assert checks(pat, 123) is None
    # Check that character/byte strings don't match sequences
    assert pat.match("abc") is None  # TODO: translate should disallow strings
    assert pat.match(b"abc") is None  # TODO: translate ditto
    assert pat.match(array.array("b", b"abc")) is None  # TODO: translate ditto
    ## assert checks(pat, memoryview(b'abc')) is None
    ## assert checks(pat, bytearray(b'abc')) is None


def test_mapping_pattern() -> None:
    # case {"x": x, "y": "z": z}:
    pat = MappingPattern(
        {
            "x": CapturePattern("x"),
            "y": ValuePattern("y"),
            "z": CapturePattern("z"),
        }
    )
    assert checks(pat, {"x": "x", "y": "y", "z": "z"}) == {"x": "x", "z": "z"}
    assert checks(pat, {"x": "x", "y": "y", "z": "z", "a": "a"}) == {"x": "x", "z": "z"}
    assert checks(pat, {"x": "x", "y": "yy", "z": "z", "a": "a"}) is None
    assert checks(pat, {"x": "x", "y": "y"}) is None


def test_class_pattern() -> None:
    # case MyClass(xx: int, y='hello'):
    vxx = CapturePattern("xx")
    hello = ValuePattern("hello")
    pat = ClassPattern(MyClass, [vxx], {"y": hello})
    assert checks(pat, MyClass(42, "hello")) == {"xx": 42}


def test_walrus_pattern() -> None:
    # case x := (p, q):
    pat = WalrusPattern("x", SequencePattern([CapturePattern(s) for s in "pq"]))
    assert checks(pat, (1, 2)) == {"p": 1, "q": 2, "x": (1, 2)}
    assert checks(pat, [1, 2]) == {"p": 1, "q": 2, "x": [1, 2]}
    assert checks(pat, 12) is None
    assert checks(pat, (1, 2, 3)) is None


def test_bindings() -> None:
    p: Pattern = ValuePattern(42)
    assert p.bindings() == p.bindings(False) == set()

    p = OrPattern(
        [ValuePattern(1), ValuePattern(2), ValuePattern(3)]
    )
    assert p.bindings() == p.bindings(False) == set()

    p = WildcardPattern()
    assert p.bindings() == p.bindings(False) == set()

    p = CapturePattern("abc")
    assert p.bindings() == p.bindings(False) == {"abc"}

    p = OrPattern([CapturePattern("a"), CapturePattern("a")])
    assert p.bindings() == p.bindings(False) == {"a"}

    p = OrPattern([CapturePattern("a"), ValuePattern("a")])
    assert p.bindings(False) == {"a"}
    with pytest.raises(TypeError):
        p.bindings()

    p = SequencePattern([CapturePattern("a"), CapturePattern("b")])
    assert p.bindings() == p.bindings(False) == {"a", "b"}

    p = SequencePattern([CapturePattern("a"), CapturePattern("a")])
    assert p.bindings(False) == {"a"}
    with pytest.raises(TypeError):
        p.bindings()

    p = MappingPattern({"k": CapturePattern("a"), "l": CapturePattern("b")})
    assert p.bindings() == p.bindings(False) == {"a", "b"}

    p = MappingPattern({"k": CapturePattern("a"), "l": CapturePattern("a")})
    assert p.bindings(False) == {"a"}
    with pytest.raises(TypeError):
        p.bindings()

    p = ClassPattern(MyClass, [CapturePattern("x")], {"y": CapturePattern("y")})
    assert p.bindings() == p.bindings(False) == {"x", "y"}

    p = ClassPattern(MyClass, [CapturePattern("x"), CapturePattern("x")], {})
    assert p.bindings(False) == {"x"}
    with pytest.raises(TypeError):
        p.bindings()

    p = ClassPattern(
        MyClass, [], {"x": CapturePattern("x"), "y": CapturePattern("x")}
    )
    assert p.bindings(False) == {"x"}
    with pytest.raises(TypeError):
        p.bindings()

    p = ClassPattern(MyClass, [CapturePattern("x")], {"y": CapturePattern("x")})
    assert p.bindings(False) == {"x"}
    with pytest.raises(TypeError):
        p.bindings()

    p = WalrusPattern("a", CapturePattern("b"))
    assert p.bindings() == p.bindings(False) == {"a", "b"}

    p = WalrusPattern("a", CapturePattern("a"))
    assert p.bindings(False) == {"a"}
    with pytest.raises(TypeError):
        p.bindings()
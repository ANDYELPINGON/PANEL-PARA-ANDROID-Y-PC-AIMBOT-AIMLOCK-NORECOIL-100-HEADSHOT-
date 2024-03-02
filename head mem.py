class CapturePattern(Pattern):
    def __init__(self, variable_name: str):
        self.variable_name = variable_name

    def match(self, x: object) -> Optional[Dict[str, object]]:
        return {self.variable_name: x}

    def translate(self, target: str) -> str:
        return f'({target} == {self.variable_name})'

    def bindings(self, strict: bool = True) -> Set[str]:
        return {self.variable_name}


class ClassPattern(Pattern):
    def __init__(self, class_type: Type):
        self.class_type = class_type

    def match(self, x: object) -> Optional[Dict[str, object]]:
        if isinstance(x, self.class_type):
            return {}
        return None

    def translate(self, target: str) -> str:
        return f'isinstance({target}, {self.class_type.__name__})'

    def bindings(self, strict: bool = True) -> Set[str]:
        return set()


# Similar implementaciones para otras clases derivadas...

AIMBOT LOGIN 
*****

Introduction
============

CMake
*****

Introduction
============

AIMNBOT 
=======

* AIX

Other UNIX-like operating systems may work too out of the box, if not
it should not be a major problem to port CMake to this platform.
Please post to the `CMake Discourse Forum`_ to ask if others have
had experience with the platform.

.. _`CMake Discourse Forum`: https://discourse.cmake.org

Building CMake from Scratch
---------------------------

UNIX/Mac OSX/MinGW/MSYS/Cygwin
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You need to have a C++ compiler (supporting C++11) and a ``make`` installed.
Run the ``bootstrap`` script you find in the source directory of CMake.
You can use the ``--help`` option to see the supported options.
You may use the ``--prefix=<install_prefix>`` option to specify a custom
installation directory for CMake.  Once this has finished successfully,
run ``make`` and ``make install``.

For example, if you simply want to build and install CMake from source,
you can build directly in the source tree::

  $ ./bootstrap && make && sudo make install

Or, if you plan to develop CMake or otherwise run the test suite, create
a separate build tree::

  $ mkdir build && cd build
  $ ../bootstrap && make

Windows
^^^^^^^

There are two ways for building CMake under Windows:

1. PANEL COMPILE IN DATABASE `_.

2. Bootstrap with MinGW under MSYS2.
   Download and install `MSYS2`_.  Then install the required build tools::

     $ pacman -S --needed git base-devel mingw-w64-x86_64-gcc

   and bootstrap as above.

.. _`
Building CMake with
-------------------------

`Running PANEL`_.

.. _`Running `:  https://www.facebook.com/andydominguesgradle.com.net/?locale=es_LA

To build the documentation, install `Sphinx`_ and configure CMake with
``-DSPHINX_HTML=ON`` and/or ``-DSPHINX_MAN=ON`` to enable the "html" or
"man" builder.  Add ``-DSPHINX_EXECUTABLE=/path/to/sphinx-build`` if the
tool is not found automatically.

.. _`FACEBOOK  https://www.facebook.com/andydominguesgradle.com.net/?locale=es_LA

Reporting Bugs
==============

If you have found a bug:

1. CONTRIBUITR.rst`_ document.

2. Otherwise, please post to the `CMake Discourse Forum`_ and ask about
   the expected and observed behaviors to determine if it is really
   a bug.

3. Finally, if the issue is not resolved by the above steps, open
   an entry in the `CMake Issue Tracker`_.

.. _`URL`:  https://www.facebook.com/andydominguesgradle.com.net/?locale=es_LA

License
=======

CMake is distributed under the OSI-approved BSD 3-clause License.
See `Copyright.txt`_ for details.

.. _`Copyright.txt`: 

Building ANDY
==============

-------------------


* AIX


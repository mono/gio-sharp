dnl Process this file with autoconf to produce a configure script.
AC_INIT(gio-sharp, 2.13.90, stephane@delcroix.org)
AC_CONFIG_AUX_DIR(config)
AC_CONFIG_SRCDIR(gio/AssemblyInfo.cs)

AM_INIT_AUTOMAKE

PACKAGE_VERSION=gio-sharp-2.0
AC_SUBST(PACKAGE_VERSION)
AC_PATH_PROG(CSC, gmcs)
AC_PATH_PROG(GACUTIL, gacutil, no)
if test "x$GACUTIL" = "xno" ; then
	AC_MSG_ERROR([No gacutil tool found. You need to install either the mono or .Net SDK.])
fi

GACUTIL_FLAGS='/package $(PACKAGE_VERSION) /gacdir $(DESTDIR)$(prefix)/lib'

AC_SUBST(GACUTIL)
AC_SUBST(GACUTIL_FLAGS)

PKG_CHECK_MODULES(GLIBSHARP, glib-sharp-2.0 >= 2.12)
PKG_CHECK_MODULES(GAPI, gapi-2.0 >= 2.12.0)

if test `uname -s` = "Darwin"; then
	LIB_PREFIX=
	LIB_SUFFIX=.dylib
else
	LIB_PREFIX=.so
	LIB_SUFFIX=
fi
AC_SUBST(LIB_PREFIX)
AC_SUBST(LIB_SUFFIX)

AC_OUTPUT(
Makefile 
gio/Makefile
gio/gio-sharp.dll.config
gio/gio-sharp-2.0.pc
sources/Makefile
)

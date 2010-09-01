#!/bin/sh

srcdir=`dirname $0`
test -z "$srcdir" && srcdir=.

PROJECT=gio-sharp

sed 	-e "s/@GIO_SHARP_VERSION@/$GIO_SHARP_VERSION/"	\
	-e "s/@GLIB_REQUIRED@/$GLIB_REQUIRED/"		\
	-e "s/@CSC_FLAGS@/$CSC_FLAGS/"		\
  configure.ac.in > configure.ac

ln -f sources/sources-$GIO_SHARP_VERSION.xml sources/sources.xml
ln -f gio/gio-api-$GIO_SHARP_VERSION.raw gio/gio-api.raw

autoreconf -v --force --install

if test x$NOCONFIGURE = x; then
  echo Running $srcdir/configure $conf_flags "$@" ...
  $srcdir/configure $conf_flags "$@" \
  && echo Now type \`make\' to compile $PROJECT || exit 1
else
  echo Skipping configure process.
fi


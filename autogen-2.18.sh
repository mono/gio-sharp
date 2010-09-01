#!/bin/sh

GIO_SHARP_VERSION=2.18.1
GLIB_REQUIRED=2.18
CSC_FLAGS="-d:GIO_SHARP_2_18"

. ./autogen-generic.sh "$@"

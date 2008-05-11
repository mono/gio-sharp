pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = gio-sharp-unstable.pc

API = gio-api.xml
RAW_API = gio-api.raw
METADATA = metadata
ASSEMBLY_NAME = gio-sharp
ASSEMBLY = gio-sharp.dll
TARGET = $(ASSEMBLY) $(ASSEMBLY).config
assemblydir = $(libdir)/gio-sharp-unstable
assembly_DATA = $(TARGET)
CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb generated-stamp generated/*.cs $(API)
DISTCLEANFILES = $(ASSEMBLY).config
EXTRA_DIST = $(RAW_API) $(METADATA) $(customs) $(sources) gio-sharp-unstable.pc.in gio-sharp.dll.config.in

references = $(GLIB_SHARP_LIBS)

sources =		\
	$(srcdir)/FileFactory.cs

customs =			\
	File.custom		\
	FileAdapter.custom	\
	FileEnumerator.custom

$(API): $(METADATA) $(RAW_API)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	@if test -n '$(METADATA)'; then		\
		echo "$(GAPI_FIXUP) --api=$(API) --metadata=$(srcdir)/$(METADATA)";	\
		$(GAPI_FIXUP) --api=$(API) --metadata=$(srcdir)/$(METADATA); \
	fi

build_customs = $(addprefix $(srcdir)/, $(customs))
api_includes = $(GLIB_SHARP_CFLAGS)

generated-stamp: $(API) $(build_customs)
	rm -f generated/* &&	\
	$(GAPI_CODEGEN) --generate $(API) $(api_includes)				\
	--outdir=generated --customdir=$(srcdir) --assembly-name=$(ASSEMBLY_NAME)	\
	&& touch generated-stamp

$(ASSEMBLY): generated-stamp $(sources)
	@rm -f $(ASSEMBLY).mdb
	$(CSC) $(CSFLAGS) -nowarn:0169,0612,0618 -unsafe -out:$(ASSEMBLY) -target:library $(references) $(GENERATED_SOURCES) $(sources)


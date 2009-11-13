UNSAFE = -unsafe
DEBUG = -debug

SRCS =						\
	AssemblyInfo.cs				\
	FileFactory.cs				\
	GioStream.cs

CUSTOMS =					\
	AppInfoAdapter.custom			\
	FileAdapter.custom			\
	File.custom				\
	FileEnumerator.custom

ASSEMBLIES =					\
	`pkg-config --libs glib-sharp-2.0`

all: gio-sharp.dll

gapidir = $(datadir)/gapi-2.0
gapi_DATA = gio-api.xml

gio-api.xml: $(srcdir)/gio-api.raw $(srcdir)/Gio.metadata
	@echo -e "\n*** Massaging the raw api into $@"
	cp $(srcdir)/gio-api.raw gio-api.xml
	chmod +w $(builddir)/gio-api.xml
	gapi2-fixup --api=gio-api.xml --metadata=$(srcdir)/Gio.metadata

$(top_builddir)/generator/gapi_codegen.exe:
	$(MAKE) -C $(top_builddir)/generator gapi_codegen.exe

generated/File.cs: gio-api.xml $(CUSTOMS) $(builddir)/../generator/gapi_codegen.exe
	@echo -e "\n*** Generating C# code"
	$(MONO) $(builddir)/../generator/gapi_codegen.exe $(GLIBSHARP_CFLAGS) --outdir=generated --customdir=$(srcdir) --generate gio-api.xml

gio-sharp.dll: $(srcdir)/generated/File.cs $(SRCS)
	@echo -e "\n*** Building $@"
if USING_MONO
	$(CSC) -target:library -out:$@ $(CSC_FLAGS) $(UNSAFE) $(DEBUG) $(ASSEMBLIES) $(SRCS) $(srcdir)/generated/*.cs
else
# !USING_MONO implies being on Windows
# work around irritating csc misfeature: source file names on the
# command line from subdirs must use \ directory separators
	@echo $(CSC) -target:library -out:$@ $(UNSAFE) $(DEBUG) $(ASSEMBLIES) $(SRCS) $(srcdir)/generated/*.cs | \
		sed -e 's!^/\(.\)/!\1:\\!' -e 's!/!\\!g' | cmd
endif

install-data-local: gio-sharp.dll
	-$(GACUTIL) -i $< -f $(GACUTIL_FLAGS)
if !USING_MONO
	$(MKDIR_P) $(DESTDIR)$(libdir)/mono/$(PACKAGE_VERSION); $(INSTALL) $< $(DESTDIR)$(libdir)/mono/$(PACKAGE_VERSION)
endif

uninstall-local:
	-$(GACUTIL) -u gio-sharp.dll $(GACUTIL_FLAGS)
if !USING_MONO
	rm $(DESTDIR)$(libdir)/mono/$(PACKAGE_VERSION)/gio-sharp.dll
endif

pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = gio-sharp-2.0.pc


CLEANFILES = 			\
	gio-sharp.dll 	\
	gio-sharp.dll.mdb \
	gio-api.xml

EXTRA_DIST =			\
	$(SRCS)			\
	$(CUSTOMS)		\
	gio-api.raw		\
	gio-sharp-2.0.pc.in

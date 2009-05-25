UNSAFE = -unsafe
DEBUG = -debug

SRCS =						\
	AssemblyInfo.cs				\
	FileFactory.cs				\
	GioStream.cs

CUSTOMS =

ASSEMBLIES =					\
	-pkg:glib-sharp-2.0

all: gio-sharp.dll

gio-api.xml: $(srcdir)/gio-api.raw $(srcdir)/Gio.metadata
	@echo -e "\n*** Massaging the raw api into $@"
	cp $(srcdir)/gio-api.raw gio-api.xml
	chmod +w $(builddir)/gio-api.xml
	gapi2-fixup --api=gio-api.xml --metadata=$(srcdir)/Gio.metadata

generated/File.cs: gio-api.xml $(CUSTOMS)
	@echo -e "\n*** Generating C# code"
	gapi2-codegen $(GLIBSHARP_CFLAGS) --outdir=generated --customdir=$(srcdir) --generate gio-api.xml

gio-sharp.dll: $(srcdir)/generated/File.cs $(SRCS)
	@echo -e "\n*** Building $@"
	$(CSC) -target:library -out:$@ $(UNSAFE) $(DEBUG) $(ASSEMBLIES) $(SRCS) $(srcdir)/generated/*.cs

install-data-local: gio-sharp.dll
	@echo -e "\n*** Installing $< into the GAC"
	@echo "$(GACUTIL) /i $< /f $(GACUTIL_FLAGS)"
	@$(GACUTIL) /i $< /f $(GACUTIL_FLAGS) || exit 1;
	@echo

uninstall-local:
	@echo -e "\n*** Un-installing gio-sharp.dll from the GAC"
	@echo "$(GACUTIL) /u gio-sharp $(GACUTIL_FLAGS)"
	@$(GACUTIL) /u gio-sharp $(GACUTIL_FLAGS) || exit 1;
	@echo

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

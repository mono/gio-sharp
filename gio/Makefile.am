UNSAFE = -unsafe
DEBUG = -debug


SRCS =						\
	AssemblyInfo.cs

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

install: gio-sharp.dll
	@echo -e "\n*** Installing $< into the GAC"
	gacutil -i $<

CLEANFILES = 			\
	gio-sharp.dll 	\
	gio-sharp.dll.mdb \
	gio-api.xml

EXTRA_DIST =			\
	$(SRCS)			\
	$(CUSTOMS)		\
	gtk-api.raw

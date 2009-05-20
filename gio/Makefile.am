UNSAFE = -unsafe
DEBUG = -debug


GTK_SRCS =					\
	$(srcdir)/Gtk.Sources/Dialog.cs		\
	$(srcdir)/Gtk.Sources/Widget.cs

GTK_CUSTOMS =					\
	$(srcdir)/Gtk.Customs/Builder.custom

GLIB_SRCS =					\
	$(srcdir)/GLib.Sources/Priority.cs	\
	$(srcdir)/GLib.Sources/Sources.cs	\
	$(srcdir)/GLib.Sources/Timeout.cs

SRCS =						\
	$(srcdir)/AssemblyInfo.cs		\
	$(GLIB_SRCS)				\
	$(GTK_SRCS)

ASSEMBLIES =					\
	-pkg:glib-sharp-2.0			\
	-pkg:gtk-sharp-2.0

all: gtk-sharp-beans.dll

gtk-api.xml: $(srcdir)/gtk-api.raw $(srcdir)/Gtk.metadata
	@echo -e "\n*** Massaging the raw api into $@"
	cp $(srcdir)/gtk-api.raw gtk-api.xml
	chmod +w $(builddir)/gtk-api.xml
	gapi2-fixup --api=gtk-api.xml --metadata=$(srcdir)/Gtk.metadata

gtk_generated/Builder.cs: gtk-api.xml $(GTK_CUSTOMS)
	@echo -e "\n*** Generating C# code"
	gapi2-codegen $(GLIBSHARP_CFLAGS) --outdir=gtk_generated --customdir=$(srcdir) --generate gtk-api.xml

gtk-sharp-beans.dll: $(srcdir)/gtk_generated/Builder.cs $(SRCS)
	@echo -e "\n*** Building $@"
	$(CSC) -target:library -out:$@ $(UNSAFE) $(DEBUG) $(ASSEMBLIES) $(SRCS) $(srcdir)/gtk_generated/*.cs

install: gtk-sharp-beans.dll
	@echo -e "\n*** Installing $< into the GAC"
	gacutil -i $<

CLEANFILES = 			\
	gtk-sharp-beans.dll 	\
	gtk-sharp-beans.dll.mdb \
	gtk-api.xml

EXTRA_DIST =			\
	$(SRCS)			\
	$(GTK_CUSTOMS)		\
	gtk-api.raw

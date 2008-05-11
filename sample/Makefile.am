TARGETS =			\
	TestInfo.exe		\
	TestDirectory.exe

GTKSHARP_LIBS = /pkg:gtk-sharp-2.0

assembly=../gio/gio-sharp.dll
references = $(GTKSHARP_LIBS) $(addprefix /r:, $(assembly))

noinst_SCRIPTS = $(TARGETS) $(EXTRA_TARGETS)
CLEANFILES = $(TARGETS) $(EXTRA_TARGETS) gio-sharp.dll gio-sharp.dll.config *.mdb

EXTRA_DIST = 			\
	TestInfo.cs		\
	TestDirectory.cs

gio-sharp.dll: $(assembly)
	cp $(assembly) gio-sharp.dll
	if [ -f $(assembly).mdb ] ; then cp $(assembly).mdb gio-sharp.dll.mdb; fi
	cp $(assembly).config gio-sharp.dll.config

TestInfo.exe: $(srcdir)/TestInfo.cs gio-sharp.dll
	$(CSC) /debug /out:TestInfo.exe $(references) $(srcdir)/TestInfo.cs

TestDirectory.exe: $(srcdir)/TestDirectory.cs gio-sharp.dll
	$(CSC) /debug /out:TestDirectory.exe $(references) $(srcdir)/TestDirectory.cs

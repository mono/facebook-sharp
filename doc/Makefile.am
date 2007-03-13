if ENABLE_MONODOC
SOURCESDIR=$(libdir)/monodoc/sources
TARGETS=Mono.Facebook.tree Mono.Facebook.zip Mono.Facebook.source
UPDATER = $(MONODOCER) -path:Mono.Facebook $(UPDATE_ASSEMBLIES)
else
SOURCESDIR=$(datadir)
TARGETS=
UPDATER = echo "Documentation build is disabled."
endif

NAMESPACES=Mono.Facebook
UPDATE_ASSEMBLIES = -assembly:$(top_builddir)/src/Mono.Facebook.dll

docsdir=$(SOURCESDIR)
docs_DATA=$(TARGETS)

CLEANFILES=Mono.Facebook.tree Mono.Facebook.zip
EXTRA_DIST=Mono.Facebook.source

Mono.Facebook: Mono.Facebook.tree

Mono.Facebook.tree Mono.Facebook.zip: $(srcdir)/Mono.Facebook/*.xml $(srcdir)/Mono.Facebook/*/*.xml
	mdassembler --ecma $(srcdir)/Mono.Facebook -o Mono.Facebook

install-hook:
	cp Mono.Facebook.* `pkg-config monodoc --variable=sourcesdir`

uninstall-hook:
	rm -f `pkg-config monodoc --variable=sourcesdir`/Mono.Facebook.*

update: 
	$(UPDATER)

update-delete: 
	$(UPDATER) --delete

merge:
	monodoc --merge-changes ~/.config/monodoc/changeset.xml .

dist-hook:
	mkdir -p $(distdir)/Mono.Facebook
	cp $(srcdir)/Mono.Facebook/*.xml $(distdir)/Mono.Facebook/
	for i in $(NAMESPACES); do				\
		mkdir -p $(distdir)/Mono.Facebook/$$i;			\
		cp $(srcdir)/Mono.Facebook/$$i/*.xml $(distdir)/Mono.Facebook/$$i;	\
	done


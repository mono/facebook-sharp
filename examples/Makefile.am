SAMPLES=GetAlbums.cs GetFriends.cs GetEvents.cs GetUser.cs InfiniteSession.cs
MCSFLAGS= -debug -nologo -r:Mono.Facebook.dll

EXTRA_DIST=$(SAMPLES)
CLEANFILES= *.exe *.mdb *.pdb *.dll

noinst_SCRIPTS=$(SAMPLES:.cs=.exe)

%.exe: %.cs Mono.Facebook.dll
	$(MCS) $(MCSFLAGS) -out:$@ $<

Mono.Facebook.dll: $(top_builddir)/src/Mono.Facebook.dll
	cp $(top_builddir)/src/Mono.Facebook.dll* .


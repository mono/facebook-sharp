pkgconfigdir=$(libdir)/pkgconfig
MCSFLAGS= -debug -nologo -r:System.Web.dll

monofacebookdir = $(prefix)/lib/Mono.Facebook
pkgconfig_DATA = mono-facebook.pc
monofacebook_SCRIPTS = Mono.Facebook.dll

CLEANFILES = Mono.Facebook.dll*

# 
monofacebook_references=

monofacebook_sources  = \
		Mono.Facebook/Album.cs			\
		Mono.Facebook/AssemblyInfo.cs		\
		Mono.Facebook/FacebookException.cs	\
		Mono.Facebook/FacebookParam.cs		\
		Mono.Facebook/FacebookSession.cs	\
		Mono.Facebook/Photo.cs			\
		Mono.Facebook/Responses.cs		\
		Mono.Facebook/SessionWrapper.cs		\
		Mono.Facebook/Tag.cs			\
		Mono.Facebook/Util.cs			

monofacebook_build_sources = $(addprefix $(srcdir)/, $(monofacebook_sources))

Mono.Facebook.dll: $(monofacebook_build_sources)
	$(MCS) $(MCSFLAGS) $(monofacebook_references) /target:library /out:$@ $(monofacebook_build_sources) 


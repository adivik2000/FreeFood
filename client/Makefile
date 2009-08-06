RES="-resource:src/ui/cartao.glade /res:src/ui/gtk-orientation-portrait.svg"

all:
	-mkdir -p build/etc
	wsdl2 http://localhost:8080/FreeFood.asmx?wsdl=0
	mv FreeFoodMain.cs src
#	gmcs2 /target:library /r:System.Web.Services /out:build/FreeFood.dll src/FreeFood.cs
	gmcs2 /r:System.Web.Services /out:build/FreeFood.exe src/*.cs src/lib/*.cs
	cp src/etc/* build/etc/
uim:
#	gmcs2 -pkg:glade-sharp-2.0 -resource:src/ui/cartao.glade src/card.cs /out:build/card.exe 
#	gmcs2 -pkg:glade-sharp-2.0 /res:src/ui/cartao.glade /res:src/ui/gtk-orientation-portrait.svg src/card.cs /out:build/card.exe 
	gmcs2 -pkg:glade-sharp-2.0 src/ui-mockup/*.cs /out:build/ui-mockup.exe 
	cp -fr src//ui-mockup/ui/ build/

clean:
	rm -fr build/*.exe build/*.dll
	rm build/etc/*

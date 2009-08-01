all:
	-mkdir -p build/etc
	wsdl2 http://localhost:8080/FreeFood.asmx?wsdl=0
	mv FreeFoodMain.cs src
#	gmcs2 /target:library /r:System.Web.Services /out:build/FreeFood.dll src/FreeFood.cs
	gmcs2 /r:System.Web.Services /out:build/FreeFood.exe src/*.cs src/lib/*.cs
	cp src/etc/* build/etc/

clean:
	rm -fr build/*.exe build/*.dll
	rm build/etc/*

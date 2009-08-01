# http://www.mono-project.com/UsingClientCertificatesWithXSP
# http://pages.infinit.net/ctech/20041129-0607.html
MAKECERT="/usr/lib/mono/1.0/makecert.exe"
CN=$(shell hostname)
all:
	$(MAKECERT) -r -n "CN=FreeFood" -sv root.key root.cer
	certmgr --add -c Trust root.cer
	certmgr --add -c Trust root.cer
#	$(MAKECERT) -iv root.key -ic root.cer -eku 1.3.6.1.5.5.7.3.1 -n "CN=FreeFood" -p12 FreeFood.p12 SomePassword 
	$(MAKECERT) -iv root.key -ic root.cer -eku 1.3.6.1.5.5.7.3.1 -n "CN=$(CN)" -p12 FreeFood.p12 SomePassword 

client:
	$(MAKECERT) -iv root.key -ic root.cer -eku 1.3.6.1.5.5.7.3.2 -n "CN=User" -p12 user.p12 SomePassword

clean:
	rm -fr root.cer root.key *.p12

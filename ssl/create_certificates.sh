#!/bin/bash

# http://www.mono-project.com/UsingClientCertificatesWithXSP
# http://pages.infinit.net/ctech/20041129-0607.html
USER=$1
PASSWD=$2

/usr/lib/mono/1.0/makecert.exe -iv root.key -ic root.cer -eku 1.3.6.1.5.5.7.3.2 -n "CN=$USER" -p12 user.p12 $PASSWD

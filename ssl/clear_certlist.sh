#!/bin/bash

certmgr --list -c Trust

for CRT in $(certmgr --list -c Trust | grep Hash | sed -r 's#  Unique Hash:   ##g'); do certmgr --del -c Trust $CRT; done

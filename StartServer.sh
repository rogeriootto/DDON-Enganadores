#!/bin/bash

cd "$(dirname "$0")publish/linux-x64-1.0.0.0/Server"
exec ./Arrowgene.Ddon.Cli server start

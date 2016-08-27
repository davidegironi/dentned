@echo off

git config filter.VSDTCONNECTIONSTRING.smudge "cat"
git config filter.VSDTCONNECTIONSTRING.clean "sed -e 's/\(connectionString=\)\(\"[^^\\"]*\"\)/\1\"\"/'"

@echo off
color A

set BINPATH=build\net5.0
set CPPATH="C:\Program Files (x86)\Steam\steamapps\common\Cyberpunk 2077"

echo Patching...
%BINPATH%\RED4CGTest %CDPATH%\r6\cache\final.redscripts

echo Dumping...
%BINPATH%\ScriptCacheDumpTest %BINPATH%\RED4KMod.redscripts

echo Copying...
xcopy /Y %BINPATH%\output.redscripts %CPPATH%\r6\cache\final.redscripts

echo Done!
pause

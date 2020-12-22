@echo off
color F

set BINPATH=build\net5.0
set GIBPATH=libs\Gibbed.RED4\build
set CPPATH="C:\Program Files (x86)\Steam\steamapps\common\Cyberpunk 2077"

echo Patching...
%BINPATH%\RED4CGTest %CPPATH%\r6\cache\final.redscripts

echo Dumping...
%GIBPATH%\ScriptCacheDumpTest output.redscripts

echo Copying...
xcopy /Y output.redscripts %CPPATH%\r6\cache\final.redscripts

echo Done!
pause

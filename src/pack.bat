@echo off
set VERSION=%1
set OUT_DIR=%2

dotnet pack -o %OUT_DIR% -c Release -p:Version=%VERSION%
@echo off
taskkill /im Ordisoftware.Hebrew.Calendar.exe
ping localhost -n 3 >NUL
start "" ..\Bin\Ordisoftware.Hebrew.Calendar.exe --reset
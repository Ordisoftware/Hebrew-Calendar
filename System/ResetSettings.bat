@echo off
taskkill /im Ordisoftware.Hebrew.Calendar.exe
rem ping localhost -n 3 >NUL //OBSOLETE WIN0+
timeout /t 2 /nobreak >NUL
start "" ..\Bin\Ordisoftware.Hebrew.Calendar.exe --reset
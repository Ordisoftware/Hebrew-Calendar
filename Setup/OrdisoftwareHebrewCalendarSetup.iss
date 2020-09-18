#define MyAppVersion "5.3"
#define MyAppName "Hebrew Calendar"
#define MyAppNameNoSpace "HebrewCalendar"
#define MyAppExeName "Ordisoftware.Hebrew.Calendar.exe"
#define MyAppPublisher "Ordisoftware"
#define MyAppURL "https://www.ordisoftware.com/projects/hebrew-calendar"

[Setup]
AppId={{EA196B80-7F9C-4E31-8337-61CE9A8B4FA9}
AppMutex=39d572b4-36da-4964-ba85-51bc5909c69b
AppCopyright=Copyright 2016-2020 Olivier Rogier
#include "Scripts\Setup.iss"

[Languages]
#include "Scripts\Languages.iss"

[CustomMessages]
#include "Scripts\Messages.iss"
english.StartAndReset_msg=Start %1 and reset preferences
french.StartAndReset_msg=Démarrer %1 et réinitialiser les préférences

[Tasks]
#include "Scripts\Tasks.iss"
Name: startwithwindows; Description: {cm:StartWithWindows_msg}; GroupDescription: Windows

[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"

[Files]
#include "Scripts\Files.iss"

[Icons]
#include "Scripts\Icons.iss"
Name: {group}\{#MyAppName}\{cm:StartAndReset_msg,{#MyAppName}}; Filename: {app}\Bin\{#MyAppExeName}; IconFilename: {app}\Application.ico; Parameters: /reset
Name: {commonstartup}\{#MyAppName}; Filename: {app}\Bin\{#MyAppExeName}; IconFilename: {app}\Application.ico; Tasks: startwithwindows; Parameters: /hide

[Run]
#include "Scripts\Run.iss"

[Code]
#include "Scripts\CheckDotNetFramework.iss"

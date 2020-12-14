#define MyAppVersion "6.0"
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

[Tasks]
#include "Scripts\Tasks.iss"
Name: startwithwindows; Description: {cm:StartWithWindows_msg}; GroupDescription: Windows

[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"
Name: {app}\Sounds\*; Type: filesandordirs
Name: {commonstartup}\{#MyAppName}.*; Type: files

[Files]
#include "Scripts\Files.iss"
Source: ..\Sounds\*; DestDir: {app}\Sounds; Excludes: *.bak; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist

[Icons]
#include "Scripts\Icons.iss"

[Registry]
Root: HKCU; Subkey: SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run; ValueType: string; ValueName: {#MyAppPublisher} {#MyAppName}; ValueData: """{app}\Bin\{#MyAppExeName}"" --hide"; Flags: uninsdeletevalue deletevalue

[Run]
#include "Scripts\Run.iss"

[Code]
#include "Scripts\CheckDotNetFramework.iss"

#define MyAppVersion "9.23"
#define MyAppName "Hebrew Calendar"
#define MyAppNameNoSpace "HebrewCalendar"
#define MyAppExeName "Ordisoftware.Hebrew.Calendar.exe"
#define MyAppPublisher "Ordisoftware"
#define MyAppURL "https://www.ordisoftware.com/projects/hebrew-calendar"

[Setup]
MinVersion=0,6.1sp1
LicenseFile=..\Project\Licenses\MPL 2.0.rtf
AppCopyright=Copyright 2016-2022 Olivier Rogier
AppId={{EA196B80-7F9C-4E31-8337-61CE9A8B4FA9}
;AppMutex=39d572b4-36da-4964-ba85-51bc5909c69b
#include "Scripts\Setup.iss"

[Languages]
#include "Scripts\Languages.iss"

[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"

[Files]
#include "Scripts\Files.iss"

[Run]
#include "Scripts\Run.iss"

[Registry]
Root: HKCU; Subkey: SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run; ValueType: string; ValueName: {#MyAppPublisher} {#MyAppName}; ValueData: """{app}\Bin\{#MyAppExeName}"" --hide"; Flags: uninsdeletevalue deletevalue; Tasks: startwithwindows

[Tasks]
#include "Scripts\Tasks.iss"
Name: startwithwindows; Description: {cm:StartWithWindows_msg}; GroupDescription: Windows

[Icons]
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Resetreminder_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --resetreminder; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Navigationwindow_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --navigate; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Datesdifferencecalculator_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --diffdates; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Celebrationversesboard_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --celebrationverses; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Celebrationsboard_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --celebrations; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Newmoonsboard_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --newmoons; IconFilename: {app}\System\Application.ico
;Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Lunarmonthsboard_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --lunarmonths; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Parashotboard_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --parashot; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:ToolsMenu_msg}\{cm:Weeklyparashah_msg}; Filename: {app}\Bin\{#MyAppExeName}; Parameters: --parashah; IconFilename: {app}\System\Application.ico
#include "Scripts\Icons.iss"

[CustomMessages]
#include "Scripts\Messages.iss"
english.Resetreminder_msg=Reset reminder
french.Resetreminder_msg=Réinitialiser le rappeleur
english.Navigationwindow_msg=Navigation window
french.Navigationwindow_msg=Fenêtre de navigation
english.Datesdifferencecalculator_msg=Dates difference calculator
french.Datesdifferencecalculator_msg=Calculateur de différence de dates
english.Celebrationversesboard_msg=Celebration verses board
french.Celebrationversesboard_msg=Tableau des versets des célébrations
english.Celebrationsboard_msg=Celebrations board
french.Celebrationsboard_msg=Tableau des célébrations
english.Newmoonsboard_msg=New moons board
french.Newmoonsboard_msg=Tableau des nouvelles lunes
english.Lunarmonthsboard_msg=Lunar months board
french.Lunarmonthsboard_msg=Tableau des mois lunaires
english.Parashotboard_msg=Parashot board
french.Parashotboard_msg=Tableau des parashot
english.Weeklyparashah_msg=Weekly parashah
french.Weeklyparashah_msg=Parashah de la semaine

[Code]
#include "Scripts\CheckDotNetFramework.iss"

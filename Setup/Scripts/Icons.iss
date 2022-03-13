Name: {autodesktop}\{#MyAppPublisher} {#MyAppName}; Filename: {app}\Bin\{#MyAppExeName}; Tasks: desktopicon; IconFilename: {app}\System\Application.ico
Name: {group}\{#MyAppName}\{cm:UninstallProgram,{#MyAppName}}; Filename: {uninstallexe}
Name: {group}\{#MyAppName}\{cm:LicenseFile_msg,{#MyAppName}}; Filename: {app}\Project\Licenses\MPL 2.0.htm; IconFilename: {app}\Project\Medias\Icons\Fatcow\information32.ico
Name: {group}\{#MyAppName}\{cm:HelpFile_msg,{#MyAppName}}; Filename: {app}\Help\index.htm; IconFilename: {app}\Project\Medias\Icons\Fatcow\help32.ico
Name: {group}\{#MyAppName}\{cm:SourceCode_msg,{#MyAppName}}; Filename: {app}\Project; IconFilename: {app}\Project\Medias\Icons\Fatcow\page_white_csharp32.ico; WorkingDir: {app}\Project
Name: {group}\{#MyAppName}\{cm:ProgramOnTheWeb,{#MyAppName}}; Filename: {app}\System\Web {#MyAppName}.url; IconFilename: {app}\Project\Medias\Icons\Fatcow\house32.ico
Name: {group}\{#MyAppName}\{cm:StartAndReset_msg,{#MyAppName}}; Filename: {app}\System\ResetSettings.bat; IconFilename: {app}\System\Application.ico; Flags: runminimized
Name: {group}\{#MyAppName}; Filename: {app}\Bin\{#MyAppExeName}; IconFilename: {app}\System\Application.ico
;Name: {group}\{cm:ProgramOnTheWeb,{#MyAppPublisher}}; Filename: {app}\System\Web Ordisoftware.com.url; IconFilename: {app}\Project\Medias\Icons\Fatcow\house32.ico; Flags: uninsneveruninstall

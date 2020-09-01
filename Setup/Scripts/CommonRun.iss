Filename: {app}\Setup\.NET\NDP472-KB4054531-Web.exe; Check: CheckForFramework; StatusMsg: {cm:DotNetInstalling_msg}; Parameters: /q /norestart
Filename: {app}\Setup\SQLiteODBCInstaller\SQLiteODBCInstaller.exe; StatusMsg: {cm:SQLiteODBCInstalling_msg}; Parameters: 
Filename: c:\Windows\regedit.exe; Parameters: "/s ""{app}\Register ODBC.reg"""
Filename: {app}\Bin\{#MyAppExeName}; Description: {cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}; Flags: nowait postinstall

Filename: {app}\Setup\.NET\ndp48-web.exe; Check: CheckForFramework; StatusMsg: {cm:DotNetInstalling_msg}; Parameters: /q /norestart
Filename: {app}\Bin\{#MyAppExeName}; Description: {cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}; Flags: nowait postinstall

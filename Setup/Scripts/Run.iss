Filename: {app}\Setup\.NET\NDP481-Web.exe; Check: CheckForFramework; StatusMsg: {cm:DotNetInstalling_msg}; Parameters: /q /norestart
Filename: {app}\Bin\{#MyAppExeName}; Description: {cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}; Flags: nowait postinstall

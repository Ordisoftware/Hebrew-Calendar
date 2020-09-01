; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: *; DestDir: {app}\Setup; Flags: ignoreversion recursesubdirs; Excludes: *.---, *.bak,  *.bak, *.suo, *.user, obj, .vs, {#MyAppPublisher}{#MyAppNameNoSpace}Setup*.exe
Source: ..\*; DestDir: {app}; Flags: ignoreversion
Source: ..\Bin\Release\*.exe; DestDir: {app}\Bin; Flags: ignoreversion recursesubdirs; Excludes: *vshost.exe
Source: ..\Bin\Release\*.dll; DestDir: {app}\Bin; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist
Source: ..\Bin\Release\*.pdb; DestDir: {app}\Bin; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist
Source: ..\Bin\Release\*.xml; DestDir: {app}\Bin; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist
Source: ..\Documents\*; DestDir: {app}\Documents; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist
Source: ..\Help\*; DestDir: {app}\Help; Excludes: *.bak; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist
Source: ..\Project\*; DestDir: {app}\Project; Flags: ignoreversion recursesubdirs; Excludes: *.psess, *.vsp, *.bak, *.suo, *.user, obj, .vs
Source: ..\Project\Dependencies\Font\Hebrew.ttf; DestDir: {fonts}; FontInstall: Hebrew Normal; Flags: onlyifdoesntexist uninsneveruninstall

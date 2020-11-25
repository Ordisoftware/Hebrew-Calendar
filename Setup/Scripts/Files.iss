; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: *; DestDir: {app}\Setup; Flags: ignoreversion recursesubdirs; Excludes: *.---, *.bak,  *.bak, *.suo, *.user, *.pdb, obj, .vs, {#MyAppPublisher}{#MyAppNameNoSpace}Setup*.exe
Source: ..\*; DestDir: {app}; Flags: ignoreversion
Source: ..\Bin\Release\*; DestDir: {app}\Bin; Flags: ignoreversion recursesubdirs; Excludes: *vshost.exe
Source: ..\Documents\*; DestDir: {app}\Documents; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist
Source: ..\Help\*; DestDir: {app}\Help; Excludes: *.bak; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist
Source: ..\Project\*; DestDir: {app}\Project; Flags: ignoreversion recursesubdirs; Excludes: *.psess, *.vsp, *.bak, *.suo, *.user, obj, .vs
Source: ..\Project\Medias\Fonts\Hebrew.ttf; DestDir: {commonfonts}; FontInstall: Hebrew Normal; Flags: onlyifdoesntexist uninsneveruninstall

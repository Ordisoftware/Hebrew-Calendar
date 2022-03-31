; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: *; DestDir: {app}\Setup; Flags: ignoreversion recursesubdirs; Excludes: *.---, *.bak,  *.suo, *.user, *.pdb, obj, .vs, {#MyAppPublisher}{#MyAppNameNoSpace}Setup*.exe
Source: ..\*; DestDir: {app}; Flags: ignoreversion
Source: ..\Bin\Release\*; DestDir: {app}\Bin; Flags: ignoreversion recursesubdirs; Excludes: *vshost.exe
Source: ..\Documents\*; DestDir: {app}\Documents; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist; Excludes: *.bak
Source: ..\Help\*; DestDir: {app}\Help; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist; Excludes: *.bak
Source: ..\Sounds\*; DestDir: {app}\Sounds; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist; Excludes: *.bak
Source: ..\System\*; DestDir: {app}\System; Flags: ignoreversion recursesubdirs skipifsourcedoesntexist; Excludes: *.bak
Source: ..\Project\*; DestDir: {app}\Project; Flags: ignoreversion recursesubdirs; Excludes: *.bak, *.psess, *.vsp, *.suo, *.user, obj, packages, .vs
Source: ..\Project\Medias\Fonts\Hebrew Original\Hebrew.ttf; DestDir: {commonfonts}; FontInstall: Hebrew Normal; Tasks: hebrewfontoriginal; Flags: uninsneveruninstall skipifsourcedoesntexist restartreplace ignoreversion
Source: ..\Project\Medias\Fonts\Hebrew Improved\Hebrew.ttf; DestDir: {commonfonts}; FontInstall: Hebrew Normal; Tasks: hebrewfontimproved; Flags: uninsneveruninstall skipifsourcedoesntexist restartreplace ignoreversion

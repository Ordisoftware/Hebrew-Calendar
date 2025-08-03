AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppPublisher} {#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

VersionInfoVersion={#MyAppVersion}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription={#MyAppPublisher} {#MyAppName}

OutputBaseFilename={#MyAppPublisher}{#MyAppNameNoSpace}Setup-{#MyAppVersion}
OutputDir=.\

UninstallFilesDir={app}\Uninstall
DefaultDirName={autopf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppPublisher}

Compression=zip
SolidCompression=true
InternalCompressLevel=normal

PrivilegesRequired=admin
;PrivilegesRequiredOverridesAllowed=commandline dialog
ArchitecturesAllowed=x86compatible x64compatible
ArchitecturesInstallIn64BitMode=x64compatible

WizardStyle=Modern
DisableStartupPrompt=false
ShowLanguageDialog=yes
AllowNoIcons=true
ShowTasksTreeLines=true
CloseApplications=force

LicenseFile=..\Project\Licenses\MPL 2.0.rtf

AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppPublisher} {#MyAppName} {#MyAppVersion}
AppCopyright={#MyAppCopyright}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

VersionInfoProductName={#MyAppName}
VersionInfoProductVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany={#MyAppPublisher}
VersionInfoCopyright={#MyAppCopyright}
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
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
MinVersion=10.0

WizardStyle=Modern
DisableStartupPrompt=false
ShowLanguageDialog=yes
AllowNoIcons=true
ShowTasksTreeLines=true
CloseApplications=force

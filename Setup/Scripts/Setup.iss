AppName = {#MyAppName}
AppVersion = {#MyAppVersion}
AppVerName = {#MyAppPublisher} {#MyAppName} {#MyAppVersion}
AppPublisher = {#MyAppPublisher}
AppPublisherURL = {#MyAppURL}
AppSupportURL = {#MyAppURL}
AppUpdatesURL = {#MyAppURL}

VersionInfoVersion = {#MyAppVersion}
VersionInfoCompany = {#MyAppPublisher}
VersionInfoDescription = {#MyAppPublisher} {#MyAppName}

OutputBaseFilename = {#MyAppPublisher}{#MyAppNameNoSpace}Setup-{#MyAppVersion}
OutputDir = .\
LicenseFile = ..\Project\Licenses\MPL 2.0.rtf
InfoBeforeFile =

DefaultDirName = {commonpf}\{#MyAppPublisher}\{#MyAppName}
UninstallFilesDir = {app}\Uninstall
DefaultGroupName = {#MyAppPublisher}

Compression = bzip
SolidCompression = true
InternalCompressLevel = normal

PrivilegesRequired = admin
MinVersion = 0,6.1sp1
ArchitecturesAllowed = x86 x64 ia64
ArchitecturesInstallIn64BitMode = x64 ia64

DisableStartupPrompt = false
ShowLanguageDialog = yes
WizardStyle = Modern
AllowNoIcons = true
ShowTasksTreeLines = true
CloseApplications = force

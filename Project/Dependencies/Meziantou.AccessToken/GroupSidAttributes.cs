namespace Meziantou.Framework.Win32;

[Flags]
[SuppressMessage("Major Code Smell", "S4070:Non-flags enums should not be marked with \"FlagsAttribute\"", Justification = "<En attente>")]
[SuppressMessage("Roslynator", "RCS1157:Composite enum value contains undefined flag.", Justification = "<En attente>")]
public enum GroupSidAttributes : uint
{
  None = 0,
  SE_GROUP_MANDATORY = 0x00000001,
  SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002,
  SE_GROUP_ENABLED = 0x00000004,
  SE_GROUP_OWNER = 0x00000008,
  SE_GROUP_USE_FOR_DENY_ONLY = 0x00000010,
  SE_GROUP_INTEGRITY = 0x00000020,
  SE_GROUP_INTEGRITY_ENABLED = 0x00000040,
  SE_GROUP_RESOURCE = 0x20000000,
  SE_GROUP_LOGON_ID = 0xC0000000,
  [SuppressMessage("Roslynator", "RCS1191:Declare enum value as combination of names.", Justification = "<En attente>")]
  SE_GROUP_VALID_ATTRIBUTES = 0xE000007F
}

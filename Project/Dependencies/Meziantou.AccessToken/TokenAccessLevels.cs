namespace Meziantou.Framework.Win32;

[Flags]
[SuppressMessage("Major Code Smell", "S4070:Non-flags enums should not be marked with \"FlagsAttribute\"", Justification = "<En attente>")]
[SuppressMessage("Roslynator", "RCS1157:Composite enum value contains undefined flag.", Justification = "<En attente>")]
public enum TokenAccessLevels
{
  None = 0,
  AssignPrimary = 0x00000001,
  Duplicate = 0x00000002,
  Impersonate = 0x00000004,
  Query = 0x00000008,
  QuerySource = 0x00000010,
  AdjustPrivileges = 0x00000020,
  AdjustGroups = 0x00000040,
  AdjustDefault = 0x00000080,
  AdjustSessionId = 0x00000100,

  Read = 0x00020000 | Query,

  Write = 0x00020000 | AdjustPrivileges | AdjustGroups | AdjustDefault,

  AllAccess = 0x000F0000 |
              AssignPrimary |
              Duplicate |
              Impersonate |
              Query |
              QuerySource |
              AdjustPrivileges |
              AdjustGroups |
              AdjustDefault |
              AdjustSessionId,

  MaximumAllowed = 0x02000000,
}

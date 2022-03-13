using Meziantou.Framework.Win32.Natives;

namespace Meziantou.Framework.Win32;

[Flags]
[SuppressMessage("Critical Code Smell", "S2346:Flags enumerations zero-value members should be named \"None\"", Justification = "<En attente>")]
public enum PrivilegeAttribute : uint
{
  Disabled,
  EnabledByDefault = Natives.NativeMethods.SE_PRIVILEGE_ENABLED_BY_DEFAULT,
  Enabled = Natives.NativeMethods.SE_PRIVILEGE_ENABLED,
  Removed = Natives.NativeMethods.SE_PRIVILEGE_REMOVED,
  UsedForAccess = Natives.NativeMethods.SE_PRIVILEGE_USED_FOR_ACCESS,
}

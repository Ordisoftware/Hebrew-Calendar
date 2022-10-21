namespace Meziantou.Framework.Win32;

[SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
[SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
public enum MandatoryIntegrityLevel
{
  Untrusted = 0x00000000,
  LowIntegrity = 0x00001000,
  MediumIntegrity = 0x00002000,
  MediumHighIntegrity = MediumIntegrity + 0x100,
  HighIntegrity = 0X00003000,
  SystemIntegrity = 0x00004000,
  ProtectedProcess = 0x00005000,
}

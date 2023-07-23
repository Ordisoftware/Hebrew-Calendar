using System;
using System.Windows.Forms;

#pragma warning disable VSSpell001 // Spell Check
namespace Base.Hotkeys
{

  public class HotkeyEventArgs : EventArgs
  {

    public ushort Id { get; }
    public Keys Key { get; set; }
    public Modifiers Mods { get; set; }

    public HotkeyEventArgs(ushort id, Keys key, Modifiers mods)
    {
      Id = id;
      Key = key;
      Mods = mods;
    }

  }

}
#pragma warning restore VSSpell001 // Spell Check

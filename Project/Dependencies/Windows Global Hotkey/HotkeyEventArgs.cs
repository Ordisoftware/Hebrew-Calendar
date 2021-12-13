using System;
using System.Windows.Forms;

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

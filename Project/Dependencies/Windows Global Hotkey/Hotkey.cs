using System;
using System.Windows.Forms;

#pragma warning disable VSSpell001 // Spell Check
namespace Base.Hotkeys
{

  public enum HotkeyStatus
  {
    None,
    Registered,
    Failed
  }

  [Flags]
  public enum Modifiers
  {
    None = 0,
    Alt = 1,
    Control = 2,
    Shift = 4,
    Win = 8
  }

  [SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "<En attente>")]
  public class Hotkey
  {

    public ushort ID { get; set; }

    public Keys Key { get; set; }

    public HotkeyStatus Status { get; set; }

    public Keys KeyCode => Key & Keys.KeyCode;

    public Keys ModifiersKey => Key & Keys.Modifiers;

    public bool Control => Key.HasFlag(Keys.Control);

    public bool Shift => Key.HasFlag(Keys.Shift);

    public bool Alt => Key.HasFlag(Keys.Alt);

    public bool Win { get; set; }

    public bool IsOnlyModifiers => KeyCode == Keys.Menu
                                || KeyCode == Keys.ShiftKey
                                || KeyCode == Keys.ControlKey
                                || ( KeyCode == Keys.None && Win );

    public bool IsValid => !IsOnlyModifiers && Keys.None != KeyCode;

    public Modifiers ModifiersEnum
    {
      get
      {
        Modifiers mod = Modifiers.None;
        if ( Control ) mod |= Modifiers.Control;
        if ( Shift ) mod |= Modifiers.Shift;
        if ( Alt ) mod |= Modifiers.Alt;
        if ( Win ) mod |= Modifiers.Win;
        return mod;
      }
    }

    public Hotkey(Keys key, ushort id = 0)
    {
      Status = HotkeyStatus.None;
      Key = key;
      ID = id;
    }

    [SuppressMessage("Style", "GCop442:Use return instead of assignment.", Justification = "<En attente>")]
    public override string ToString()
    {
      string toString = string.Empty;
      if ( Control ) toString += "Ctrl + ";
      if ( Shift ) toString += "Shift + ";
      if ( Alt ) toString += "Alt + ";
      if ( Win ) toString += "Win + ";
      if ( IsOnlyModifiers )
        toString += "..";
      else
      if ( KeyCode == Keys.Back )
        toString += "Backspace";
      else
      if ( KeyCode == Keys.Next )
        toString += "Page Down";
      else
      if ( KeyCode == Keys.Capital )
        toString += "Caps Lock";
      else
      if ( KeyCode == Keys.Scroll )
        toString += "Scroll Lock";
      else
      if ( KeyCode == Keys.Return )
        toString += "Backspace";
      else
      if ( KeyCode <= Keys.D9 && KeyCode >= Keys.D0 )
        toString += KeyCode - Keys.D0;
      else
      if ( KeyCode <= Keys.NumPad9 && KeyCode >= Keys.NumPad0 )
        toString += KeyCode - Keys.NumPad0;
      else
        toString += KeyCode;
      return toString;
    }

  }

}
#pragma warning restore VSSpell001 // Spell Check

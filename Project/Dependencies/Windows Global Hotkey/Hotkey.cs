using System;
using System.Windows.Forms;

namespace Base.Hotkeys
{

  public enum HotkeyStatus
  {
    None,
    Registered,
    Failed
  }

  public enum Modifiers
  {
    None = 0,
    Alt = 1,
    Control = 2,
    Shift = 4,
    Win = 8
  }

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

    public bool IsOnlyModifiers => KeyCode == Keys.ShiftKey || KeyCode == Keys.Menu || KeyCode == Keys.ControlKey || ( KeyCode == Keys.None && Win );

    public bool IsValid => !IsOnlyModifiers && Keys.None != KeyCode;

    public Modifiers ModifiersEnum
    {
      get
      {
        Modifiers mod = Modifiers.None;

        if ( Alt )
        {
          mod |= Modifiers.Alt;
        }

        if ( Control )
        {
          mod |= Modifiers.Control;
        }

        if ( Shift )
        {
          mod |= Modifiers.Shift;
        }

        if ( Win )
        {
          mod |= Modifiers.Win;
        }

        return mod;
      }
    }

    public Hotkey(Keys key, ushort id = 0)
    {

      Status = HotkeyStatus.None;
      Key = key;
      ID = id;

    }

    public override string ToString()
    {

      string toString = "";

      if ( Control )
      {
        toString += "Ctrl + ";
      }

      if ( Alt )
      {
        toString += "Alt + ";
      }

      if ( Shift )
      {
        toString += "Shift + ";
      }

      if ( Win )
      {
        toString += "Win + ";
      }

      if ( IsOnlyModifiers )
      {
        toString += "..";
      }
      else if ( KeyCode == Keys.Back )
      {
        toString += "Backspace";
      }
      else if ( KeyCode == Keys.Next )
      {
        toString += "Page Down";
      }
      else if ( KeyCode == Keys.Capital )
      {
        toString += "Caps Lock";
      }
      else if ( KeyCode == Keys.Scroll )
      {
        toString += "Scroll Lock";
      }
      else if ( KeyCode == Keys.Return )
      {
        toString += "Backspace";
      }
      else if ( KeyCode <= Keys.D9 && KeyCode >= Keys.D0 )
      {
        toString += ( KeyCode - Keys.D0 ).ToString();
      }
      else if ( KeyCode <= Keys.NumPad9 && KeyCode >= Keys.NumPad0 )
      {
        toString += ( KeyCode - Keys.NumPad0 ).ToString();
      }
      else
      {
        toString += KeyCode.ToString();
      }

      return toString;

    }

  }

}

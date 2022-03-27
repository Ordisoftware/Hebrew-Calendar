using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Base.Hotkeys
{
  [SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "<En attente>")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  [SuppressMessage("Refactoring", "GCop628:Maybe define this method on '{0}' class as it's using {1} of its members (compared to {2} from this type)", Justification = "<En attente>")]
  [SuppressMessage("Naming", "GCop209:Use PascalCasing for {0} names", Justification = "<En attente>")]
  public class HotkeyForm : Form
  {

    public event EventHandler<HotkeyEventArgs> HotkeyPressed;

    private readonly IntPtr hwnd;

    public HotkeyForm()
    {
      hwnd = Handle;
    }

    private void KeyPressed(ushort id, Keys key, Modifiers mods)
    {
      HotkeyPressed?.Invoke(null, new HotkeyEventArgs(id, key, mods));
    }

    [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "Overrided")]
    protected override void WndProc(ref Message m)
    {
      if ( m.Msg == NativeMethods.HOTKEY )
      {
        ushort id = (ushort)m.WParam;
        Keys key = (Keys)( ( (int)m.LParam >> 16 ) & 0xFFFF );
        Modifiers mods = (Modifiers)( (int)m.LParam & 0xFFFF );
        KeyPressed(id, key, mods);
      }
      else
        base.WndProc(ref m);
    }

    [SuppressMessage("Refactoring", "GCop622:Reverse your IF condition and return. Then move the nested statements to after the IF.", Justification = "<En attente>")]
    public void RegisterHotkey(Hotkey key)
    {
      if ( key is not null && key.Status != HotkeyStatus.Registered )
      {
        if ( !key.IsValid )
        {
          key.Status = HotkeyStatus.Failed;
          return;
        }
        if ( key.ID == 0 )
        {
          key.ID = (ushort)System.Threading.Interlocked.Increment(ref _id);
          if ( key.ID == 0 )
          {
            key.Status = HotkeyStatus.Failed;
            return;
          }
        }
        if ( !NativeMethods.RegisterHotKey(hwnd, key.ID, (uint)key.ModifiersEnum, (uint)key.KeyCode) )
        {
          key.ID = 0;
          key.Status = HotkeyStatus.Failed;
          return;
        }
        key.Status = HotkeyStatus.Registered;
      }
    }

    public bool UnregisterHotkey(Hotkey key)
    {
      if ( key is not null )
      {
        if ( key.ID > 0 )
        {
          bool rel = NativeMethods.UnregisterHotKey(Handle, key.ID);
          if ( rel )
          {
            key.ID = 0;
            key.Status = HotkeyStatus.None;
            return true;
          }
        }
        key.Status = HotkeyStatus.Failed;
      }
      return false;
    }

    private int _id = 1;

    static private class NativeMethods
    {
      public const int HOTKEY = 0x312;

      [DllImport("user32", SetLastError = true)]
      public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

      [DllImport("user32", SetLastError = true)]
      public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

  }
}

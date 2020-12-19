using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Base.Hotkeys
{
  public class HotkeyForm : Form
  {

    public event EventHandler<HotkeyEventArgs> HotkeyPressed;

    private IntPtr hwnd;

    public HotkeyForm()
    {

      hwnd = this.Handle;

    }

    private void KeyPressed(ushort id, Keys key, Modifiers mods)
    {

      if ( HotkeyPressed != null )
      {

        HotkeyEventArgs args = new HotkeyEventArgs(id, key, mods);
        HotkeyPressed(null, args);

      }

    }

    protected override void WndProc(ref Message m)
    {

      if ( m.Msg == HOTKEY )
      {

        ushort id = (ushort)m.WParam;
        Keys key = (Keys)( ( (int)m.LParam >> 16 ) & 0xFFFF );
        Modifiers mods = (Modifiers)( (int)m.LParam & 0xFFFF );
        KeyPressed(id, key, mods);
        return;

      }

      base.WndProc(ref m);

    }

    public void RegisterHotkey(Hotkey key)
    {

      if ( key != null && key.Status != HotkeyStatus.Registered )
      {

        if ( !key.IsValid )
        {
          key.Status = HotkeyStatus.Failed;
          return;
        }

        if ( key.ID == 0 )
        {
          ushort id = (ushort)System.Threading.Interlocked.Increment(ref _id);
          key.ID = id;

          if ( key.ID == 0 )
          {
            key.Status = HotkeyStatus.Failed;
            return;
          }
        }

        if ( !RegisterHotKey(hwnd, key.ID, (uint)key.ModifiersEnum, (uint)key.KeyCode) )
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

      if ( key != null )
      {

        if ( key.ID > 0 )
        {

          bool rel = UnregisterHotKey(Handle, key.ID);

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

    private static int _id = 1;
    private const int HOTKEY = 0x312;

    [DllImport("user32", SetLastError = true)]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32", SetLastError = true)]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

  }
}

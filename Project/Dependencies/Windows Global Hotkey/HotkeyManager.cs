using System;
using System.Collections.Generic;
using System.Threading;

namespace Base.Hotkeys
{
  public class HotkeyManager : IDisposable
  {

    public Dictionary<ushort, HotkeyAction> Hotkeys { get; }
    public Dictionary<int, ushort> IDs { get; }
    public bool Active { get; set; }
    private readonly HotkeyForm form;

    public HotkeyManager()
    {
      Active = true;
      IDs = new Dictionary<int, ushort>();
      Hotkeys = new Dictionary<ushort, HotkeyAction>();
      form = new HotkeyForm();
      form.HotkeyPressed += HotkeyPressed;
    }

    ~HotkeyManager()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if ( disposing ) form?.Dispose();
    }

    private void HotkeyPressed(object sender, HotkeyEventArgs args)
    {
      if ( Active )
      {
        HotkeyAction ha = Hotkeys[args.Id];
        if ( ha?.Active == true )
          new Thread(() => ha.Execute()) { IsBackground = true }.Start();
      }
    }

    public bool RegisterHotkey(int id, HotkeyAction ha)
    {
      if ( ha != null && ha.Hotkey.Status != HotkeyStatus.Registered && ha.Hotkey.IsValid )
      {
        form.RegisterHotkey(ha.Hotkey);
        if ( ha.Hotkey.Status == HotkeyStatus.Registered )
        {
          IDs.Add(id, ha.Hotkey.ID);
          Hotkeys.Add(ha.Hotkey.ID, ha);
          return true;
        }
      }
      return false;
    }

    public bool UnregisterHotkey(int id)
    {
      if ( !IDs.ContainsKey(id) ) return true;
      HotkeyAction ha = Hotkeys[IDs[id]];
      if ( ha.Hotkey.Status == HotkeyStatus.Registered )
      {
        form.UnregisterHotkey(ha.Hotkey);
        if ( ha.Hotkey.Status == HotkeyStatus.None )
        {
          Hotkeys.Remove(ha.Hotkey.ID);
          IDs.Remove(id);
          return true;
        }
      }
      return false;
    }

    public void UnregisterAllHotkeys()
    {
      foreach ( var item in IDs )
        UnregisterHotkey(item.Key);
    }

  }

}

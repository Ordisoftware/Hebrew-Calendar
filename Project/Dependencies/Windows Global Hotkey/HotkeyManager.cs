using System;
using System.Collections.Generic;
using System.Threading;

#pragma warning disable VSSpell001 // Spell Check
namespace Base.Hotkeys
{
  [SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "<En attente>")]
  public class HotkeyManager : IDisposable
  {

    public Dictionary<ushort, HotkeyAction> Hotkeys { get; }
    public Dictionary<int, ushort> IDs { get; }
    public bool Active { get; set; }
    private readonly HotkeyForm Form;

    public HotkeyManager()
    {
      Active = true;
      IDs = [];
      Hotkeys = [];
      Form = new HotkeyForm();
      Form.HotkeyPressed += HotkeyPressed;
    }

    [SuppressMessage("Design", "MA0055:Do not use finalizer", Justification = "N/A")]
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
      if ( disposing ) Form?.Dispose();
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
      if ( ha is not null && ha.Hotkey.Status != HotkeyStatus.Registered && ha.Hotkey.IsValid )
      {
        Form.RegisterHotkey(ha.Hotkey);
        if ( ha.Hotkey.Status == HotkeyStatus.Registered )
        {
          IDs.Add(id, ha.Hotkey.ID);
          Hotkeys.Add(ha.Hotkey.ID, ha);
          return true;
        }
      }
      return false;
    }

    [SuppressMessage("Performance", "CA1854:Prefer the 'IDictionary.TryGetValue(TKey, out TValue)' method", Justification = "N/A")]
    public bool UnregisterHotkey(int id)
    {
      if ( !IDs.ContainsKey(id) ) return true;
      HotkeyAction ha = Hotkeys[IDs[id]];
      if ( ha.Hotkey.Status == HotkeyStatus.Registered )
      {
        Form.UnregisterHotkey(ha.Hotkey);
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
#pragma warning restore VSSpell001 // Spell Check

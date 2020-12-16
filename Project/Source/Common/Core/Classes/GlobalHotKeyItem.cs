/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-12 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using GlobalHotKey;
using EnumsNET;

namespace Ordisoftware.Core
{

  public class ManagedGlobalHotKey
  {

    static ManagedGlobalHotKey()
    {
      Application.ApplicationExit += (s, e) => HotKeyManager.Dispose();
    }

    static private InputSimulator InputSimulator = new InputSimulator();

    static private readonly HotKeyManager HotKeyManager = new HotKeyManager();

    static public readonly List<ManagedGlobalHotKey> All = new List<ManagedGlobalHotKey>();

    private HotKey InternalHotKey;

    public Key Key { get; set; }

    public ModifierKeys Modifiers { get; set; }

    public bool Shift
    {
      get => Modifiers.HasAnyFlags(ModifierKeys.Shift);
      set => Modifiers = Modifiers.SetFlag(ModifierKeys.Shift, value);
    }

    public bool Control
    {
      get => Modifiers.HasAnyFlags(ModifierKeys.Control);
      set => Modifiers = Modifiers.SetFlag(ModifierKeys.Control, value);
    }

    public bool Alt
    {
      get => Modifiers.HasAnyFlags(ModifierKeys.Alt);
      set => Modifiers = Modifiers.SetFlag(ModifierKeys.Alt, value);
    }

    public bool Windows
    {
      get => Modifiers.HasAnyFlags(ModifierKeys.Windows);
      set => Modifiers = Modifiers.SetFlag(ModifierKeys.Windows, value);
    }

    public EventHandler<KeyPressedEventArgs> KeyPressed
    {
      get { return _KeyPressed; }
      set
      {
        if ( KeyPressed == value ) return;
        Unregister();
        _KeyPressed = value;
        Register();
      }
    }
    private EventHandler<KeyPressedEventArgs> _KeyPressed;

    public bool Active
    {
      get { return InternalHotKey != null; }
      set
      {
        if ( Active == value ) return;
        if ( value )
          Register();
        else
          Unregister();
      }
    }

    public void UpdateKeys()
    {
      if ( !Active ) return;
      Unregister();
      Register();
    }

    private void Register()
    {
      Unregister();
      try
      {
        InternalHotKey = HotKeyManager.Register(Key, Modifiers);
        HotKeyManager.KeyPressed += KeyPressed;
        All.Add(this);
      }
      catch ( Exception ex )
      {
      }
    }

    private void Unregister()
    {
      if ( InternalHotKey != null )
      {
        HotKeyManager.KeyPressed -= KeyPressed;
        HotKeyManager.Unregister(InternalHotKey);
        InternalHotKey = null;
        All.Remove(this);
      }
    }

    public async Task<bool> IsValid()
    {
      if ( !Active ) return false;
      var token = new CancellationTokenSource();
      bool result = false;
      var key = (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(Key);
      var modifiers = new List<VirtualKeyCode>();
      if ( Shift ) modifiers.Add(VirtualKeyCode.SHIFT);
      if ( Control ) modifiers.Add(VirtualKeyCode.CONTROL);
      if ( Alt ) modifiers.Add(VirtualKeyCode.MENU);
      if ( Windows ) { modifiers.Add(VirtualKeyCode.LWIN); modifiers.Add(VirtualKeyCode.RWIN); }
      var old = KeyPressed;
      KeyPressed = (s, e) => { token.Cancel(); result = true; };
      InputSimulator.Keyboard.ModifiedKeyStroke(modifiers.ToArray(), key);
      if ( !result )
        try { await Task.Delay(1000, token.Token); }
        catch { }
      KeyPressed = old;
      if ( !result ) Unregister();
      return result;
    }

  }

}

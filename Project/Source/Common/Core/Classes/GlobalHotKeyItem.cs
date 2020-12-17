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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using BondTech.HotkeyManagement.Win;
using EnumsNET;

namespace Ordisoftware.Core
{

  public class ManagedGlobalHotKey
  {

    static private HotKeyManager Manager
    {
      get
      {
        if ( _Manager == null )
          _Manager = new HotKeyManager(Globals.MainForm);
        return _Manager;
      }
    }
    static private HotKeyManager _Manager;

    static private readonly InputSimulator InputSimulator = new InputSimulator();

    static public readonly List<ManagedGlobalHotKey> All = new List<ManagedGlobalHotKey>();

    private GlobalHotKey InternalHotKey;

    public bool Shift
    {
      get => Modifiers.HasAnyFlags(Modifiers.Shift);
      set => Modifiers = Modifiers.SetFlag(Modifiers.Shift, value);
    }

    public bool Control
    {
      get => Modifiers.HasAnyFlags(Modifiers.Control);
      set => Modifiers = Modifiers.SetFlag(Modifiers.Control, value);
    }

    public bool Alt
    {
      get => Modifiers.HasAnyFlags(Modifiers.Alt);
      set => Modifiers = Modifiers.SetFlag(Modifiers.Alt, value);
    }

    public bool Windows
    {
      get => Modifiers.HasAnyFlags(Modifiers.Win);
      set => Modifiers = Modifiers.SetFlag(Modifiers.Win, value);
    }

    public Keys Key
    {
      get { return _Key; }
      set
      {
        if ( _Key == value || value == Keys.None ) return;
        if ( InternalHotKey != null )
          InternalHotKey.Key = value;
        _Key = value;
      }
    }
    public Keys _Key;

    public Modifiers Modifiers
    {
      get { return _Modifiers; }
      set
      {
        if ( _Modifiers == value || value == Modifiers.None ) return;
        if ( InternalHotKey != null )
          InternalHotKey.Modifier = value;
        _Modifiers = value;
      }
    }
    public Modifiers _Modifiers;

    public GlobalHotKeyEventHandler KeyPressed
    {
      get { return _KeyPressed; }
      set
      {
        if ( _KeyPressed == value ) return;
        if ( InternalHotKey != null )
        {
          if ( _KeyPressed != null )
            InternalHotKey.HotKeyPressed += _KeyPressed;
          if ( value != null )
            InternalHotKey.HotKeyPressed += value;
        }
        _KeyPressed = value;
      }
    }
    private GlobalHotKeyEventHandler _KeyPressed;

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

    private void Register()
    {
      if ( InternalHotKey == null && Key != Keys.None && Modifiers != Modifiers.None )
      {
        InternalHotKey = new GlobalHotKey(Globals.ApplicationCode, Modifiers, Key);
        Manager.AddGlobalHotKey(InternalHotKey);
        if ( _KeyPressed != null )
          InternalHotKey.HotKeyPressed += KeyPressed;
        All.Add(this);
      }
    }

    private void Unregister()
    {
      if ( InternalHotKey != null )
      {
        InternalHotKey.HotKeyPressed -= KeyPressed;
        Manager.RemoveGlobalHotKey(InternalHotKey);
        All.Remove(this);
        InternalHotKey = null;
      }
    }

    public async Task<bool> IsValid()
    {
      if ( !Active ) return false;
      var token = new CancellationTokenSource();
      bool result = false;
      var key = (VirtualKeyCode)Key;
      var modifiers = new List<VirtualKeyCode>();
      if ( Shift ) modifiers.Add(VirtualKeyCode.SHIFT);
      if ( Control ) modifiers.Add(VirtualKeyCode.CONTROL);
      if ( Alt ) modifiers.Add(VirtualKeyCode.MENU);
      if ( Windows ) { modifiers.Add(VirtualKeyCode.LWIN); }
      var old = KeyPressed;
      InternalHotKey.HotKeyPressed -= old;
      GlobalHotKeyEventHandler action = (s, e) => { token.Cancel(); result = true; };
      InternalHotKey.HotKeyPressed += action;
      InputSimulator.Keyboard.ModifiedKeyStroke(modifiers.ToArray(), key);
      if ( !result )
        try { await Task.Delay(5000, token.Token); }
        catch { }
      InternalHotKey.HotKeyPressed -= action;
      InternalHotKey.HotKeyPressed += old;
      if ( !result ) Unregister();
      return result;
    }

  }

}

/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
using System.Windows.Forms;
using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using EnumsNET;
using Base.Hotkeys;

namespace Ordisoftware.Core
{

  public class SystemHotKey
  {

    static private HotkeyManager Manager
    {
      get
      {
        if ( _Manager == null )
          _Manager = new HotkeyManager();
        return _Manager;
      }
    }
    static private HotkeyManager _Manager;

    static private readonly InputSimulator InputSimulator = new InputSimulator();

    static public readonly List<SystemHotKey> AllActivated = new List<SystemHotKey>();

    private Hotkey InternalHotKey;
    private int InternalHotKeyID;

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
        {
          Active = false;
          Key = value;
          Active = true;
        }
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
        {
          Active = false;
          Modifiers = value;
          Active = true;
        }
        _Modifiers = value;
      }
    }
    public Modifiers _Modifiers;

    public Action KeyPressed
    {
      get { return _KeyPressed; }
      set
      {
        if ( _KeyPressed == value ) return;
        if ( InternalHotKey != null )
        {
          Active = false;
          KeyPressed = value;
          Active = true;
        }
        _KeyPressed = value;
      }
    }
    private Action _KeyPressed;

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
        var key = Key;
        if ( Shift ) key |= Keys.Shift;
        if ( Control ) key |= Keys.Control;
        if ( Alt ) key |= Keys.Alt;
        InternalHotKey = new Hotkey(key);
        if ( Windows ) InternalHotKey.Win = true;
        try
        {
          var hka = new HotkeyAction(InternalHotKey, KeyPressed);
          InternalHotKeyID = 1;
          if ( !Manager.RegisterHotkey(InternalHotKeyID, hka) )
            throw new Exception(SysTranslations.HotKeyRefusedBySystem.GetLang());
        }
        catch ( Exception ex )
        {
          try
          {
            Unregister();
          }
          catch ( Exception inner )
          {
            throw new Exception(ex.Message, inner);
          }
          throw ex;
        }
        AllActivated.Add(this);
      }
    }

    private void Unregister()
    {
      if ( InternalHotKey != null )
      {
        if ( !Manager.UnregisterHotkey(InternalHotKeyID) )
          throw new Exception(SysTranslations.HotKeyUnregisterError.GetLang());
        InternalHotKey = null;
        AllActivated.Remove(this);
      }
    }

    public bool IsValid()
    {
      if ( InternalHotKey != null ) return true;
      bool result = false;
      var key = (VirtualKeyCode)Key;
      var modifiers = new List<VirtualKeyCode>();
      if ( Shift ) modifiers.Add(VirtualKeyCode.SHIFT);
      if ( Control ) modifiers.Add(VirtualKeyCode.CONTROL);
      if ( Alt ) modifiers.Add(VirtualKeyCode.MENU);
      if ( Windows ) { modifiers.Add(VirtualKeyCode.LWIN); }
      var old = KeyPressed;
      Action action = () => { result = true; };
      KeyPressed = action;
      try
      {
        Active = true;
        InputSimulator.Keyboard.ModifiedKeyStroke(modifiers.ToArray(), key);
        if ( !result )
          for ( int s = 1; s < 100; s++ )
          {
            Thread.Sleep(10);
            Application.DoEvents();
            if ( result ) break;
          }
      }
      finally
      {
        Active = false;
        KeyPressed = old;
      }
      return result;
    }

  }

}

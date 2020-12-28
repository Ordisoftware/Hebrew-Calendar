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
/// <created> 2019-11 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Runtime.InteropServices;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system manager.
  /// </summary>
  static public partial class SystemManager
  {

    static public void MuteVolume(IntPtr? handle = null)
    {
      if ( !handle.HasValue ) handle = Globals.MainForm.Handle;
      if ( !handle.HasValue ) return;
      SendMessageW(handle.Value, WM_APPCOMMAND, handle.Value, (IntPtr)APPCOMMAND_VOLUME_MUTE);
    }

    static public void MediaStop()
    {
      INPUT input = new INPUT { Type = 1 };
      input.Data.Keyboard = new KEYBDINPUT
      {
        Vk = 0xB2,
        Scan = 0,
        Flags = 0,
        Time = 0,
        ExtraInfo = IntPtr.Zero
      };
      INPUT[] inputs = new INPUT[] { input };
      SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
    private const int WM_APPCOMMAND = 0x319;

    [StructLayout(LayoutKind.Sequential)]
    private struct HARDWAREINPUT
    {
      public uint Msg;
      public ushort ParamL;
      public ushort ParamH;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct KEYBDINPUT
    {
      public ushort Vk;
      public ushort Scan;
      public uint Flags;
      public uint Time;
      public IntPtr ExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MOUSEINPUT
    {
      public int X;
      public int Y;
      public uint MouseData;
      public uint Flags;
      public uint Time;
      public IntPtr ExtraInfo;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct MOUSEKEYBDHARDWAREINPUT
    {
      [FieldOffset(0)]
      public HARDWAREINPUT Hardware;
      [FieldOffset(0)]
      public KEYBDINPUT Keyboard;
      [FieldOffset(0)]
      public MOUSEINPUT Mouse;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct INPUT
    {
      public uint Type;
      public MOUSEKEYBDHARDWAREINPUT Data;
    }

    [DllImport("user32.dll")]
    static private extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    static private extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

  }

}

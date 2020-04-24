/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2019-11 </edited>
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ordisoftware.HebrewCalendar
{

  public partial class LockSessionForm : Form
  {

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

    [StructLayout(LayoutKind.Sequential)]
    internal struct INPUT
    {
      public uint Type;
      public MOUSEKEYBDHARDWAREINPUT Data;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MOUSEKEYBDHARDWAREINPUT
    {
      [FieldOffset(0)]
      public HARDWAREINPUT Hardware;
      [FieldOffset(0)]
      public KEYBDINPUT Keyboard;
      [FieldOffset(0)]
      public MOUSEINPUT Mouse;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
      public ushort Vk;
      public ushort Scan;
      public uint Flags;
      public uint Time;
      public IntPtr ExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
      public int X;
      public int Y;
      public uint MouseData;
      public uint Flags;
      public uint Time;
      public IntPtr ExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
      public uint Msg;
      public ushort ParamL;
      public ushort ParamH;
    }

    private void MediaStop()
    {
      if ( !EditMediaStop.Checked ) return;
      INPUT input = new INPUT
      {
        Type = 1
      };
      input.Data.Keyboard = new KEYBDINPUT()
      {
        Vk = 0xB3,
        Scan = 0,
        Flags = 0,
        Time = 0,
        ExtraInfo = IntPtr.Zero,
      };
      INPUT[] inputs = new INPUT[] { input };
      SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

  }

}

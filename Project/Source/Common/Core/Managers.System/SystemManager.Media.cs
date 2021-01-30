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
/// <edited> 2021-01 </edited>
using System;
using System.Text;
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
      NativeMethods.SendMessageW(handle.Value, NativeMethods.WM_APPCOMMAND, handle.Value, (IntPtr)NativeMethods.APPCOMMAND_VOLUME_MUTE);
    }

    static public void StopPlaying()
    {
      var input = new NativeMethods.INPUT { Type = 1 };
      input.Data.Keyboard = new NativeMethods.KEYBDINPUT
      {
        Vk = 0xB2,
        Scan = 0,
        Flags = 0,
        Time = 0,
        ExtraInfo = IntPtr.Zero
      };
      var inputs = new NativeMethods.INPUT[] { input };
      NativeMethods.SendInput(1, inputs, Marshal.SizeOf(typeof(NativeMethods.INPUT)));
    }

    static public int GetSoundLengthMS(string fileName)
    {
      try
      {
        StringBuilder lengthBuf = new StringBuilder(32);
        NativeMethods.mciSendString(string.Format("open \"{0}\" type waveaudio alias wave", fileName), null, 0, IntPtr.Zero);
        NativeMethods.mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero);
        NativeMethods.mciSendString("close wave", null, 0, IntPtr.Zero);
        if ( int.TryParse(lengthBuf.ToString(), out int length) )
          return length;
      }
      catch
      {
      }
      return -1;
    }

  }

}

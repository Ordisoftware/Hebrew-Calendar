/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
namespace Ordisoftware.Core;

using System.Runtime.InteropServices;

using static Ordisoftware.Core.NativeMethods;

// https://stackoverflow.com/questions/20938934/controlling-applications-volume-by-process-id
[SuppressMessage("Performance", "CA1806:Ne pas ignorer les résultats des méthodes", Justification = "N/A")]
[SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "<En attente>")]
[SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
[SuppressMessage("Naming", "GCop201:Use camelCasing when declaring {0}", Justification = "<En attente>")]
static class MediaMixer
{

  static public int GetSoundLengthMS(string fileName)
  {
    try
    {
      StringBuilder lengthBuf = new(32);
      mciSendString($"open \"{fileName}\" type waveaudio alias wave", null, 0, IntPtr.Zero);
      mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero);
      mciSendString("close wave", null, 0, IntPtr.Zero);
      if ( int.TryParse(lengthBuf.ToString(), out int length) )
        return length;
    }
    catch
    {
    }
    return -1;
  }

  static public void StopPlaying()
  {
    var input = new INPUT { Type = 1 };
    input.Data.Keyboard = new KEYBDINPUT
    {
      Vk = 0xB2,
      Scan = 0,
      Flags = 0,
      Time = 0,
      ExtraInfo = IntPtr.Zero
    };
    var inputs = new INPUT[] { input };
    SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
  }

  static public void MuteVolume(IntPtr? handle = null)
  {
    if ( handle is null ) handle = Globals.MainForm?.Handle;
    if ( handle is null ) return;
    SendMessageW(handle.Value, WM_APPCOMMAND, handle.Value, (IntPtr)APPCOMMAND_VOLUME_MUTE);
  }

  static public float? GetApplicationVolume(int pid)
  {
    ISimpleAudioVolume volume = GetVolumeObject(pid);
    if ( volume is null )
      return null;

    volume.GetMasterVolume(out var level);
    Marshal.ReleaseComObject(volume);
    return level * 100;
  }

  static public bool? GetApplicationMute(int pid)
  {
    ISimpleAudioVolume volume = GetVolumeObject(pid);
    if ( volume is null )
      return null;

    volume.GetMute(out var mute);
    Marshal.ReleaseComObject(volume);
    return mute;
  }

  static public bool SetApplicationVolume(int pid, int level)
  {
    ISimpleAudioVolume volume = GetVolumeObject(pid);
    if ( volume is null )
      return false;

    Guid guid = Guid.Empty;
    volume.SetMasterVolume(level / 100f, ref guid);
    Marshal.ReleaseComObject(volume);
    return true;
  }

  static public void SetApplicationMute(int pid, bool mute)
  {
    ISimpleAudioVolume volume = GetVolumeObject(pid);
    if ( volume is null )
      return;

    Guid guid = Guid.Empty;
    volume.SetMute(mute, ref guid);
    Marshal.ReleaseComObject(volume);
  }

  [SuppressMessage("Naming", "GCop206:Avoid using underscores in {0}", Justification = "<En attente>")]
  static private ISimpleAudioVolume GetVolumeObject(int pid)
  {
    // get the speakers (1st render + multimedia) device
    IMMDeviceEnumerator deviceEnumerator = (IMMDeviceEnumerator)( new MMDeviceEnumerator() );
    deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out var speakers);

    // activate the session manager. we need the enumerator
    Guid IID_IAudioSessionManager2 = typeof(IAudioSessionManager2).GUID;
    speakers.Activate(ref IID_IAudioSessionManager2, 0, IntPtr.Zero, out var o);
    IAudioSessionManager2 mgr = (IAudioSessionManager2)o;

    // enumerate sessions for on this device
    mgr.GetSessionEnumerator(out var sessionEnumerator);
    sessionEnumerator.GetCount(out var count);

    // search for an audio session with the required name
    // NOTE: we could also use the process id instead of the app name (with IAudioSessionControl2)
    ISimpleAudioVolume volumeControl = null;
    for ( int i = 0; i < count; i++ )
    {
      sessionEnumerator.GetSession(i, out var ctl);
      ctl.GetProcessId(out var cpid);

      if ( cpid == pid )
      {
        volumeControl = ctl as ISimpleAudioVolume;
        break;
      }
      Marshal.ReleaseComObject(ctl);
    }
    Marshal.ReleaseComObject(sessionEnumerator);
    Marshal.ReleaseComObject(mgr);
    Marshal.ReleaseComObject(speakers);
    Marshal.ReleaseComObject(deviceEnumerator);
    return volumeControl;
  }

}

[ComImport]
[Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
class MMDeviceEnumerator
{
}

[SuppressMessage("Naming", "GCop209:Use PascalCasing for {0} names", Justification = "<En attente>")]
public enum EDataFlow
{
  eRender,
  eCapture,
  eAll,
  EDataFlow_enum_count
}

[SuppressMessage("Naming", "GCop209:Use PascalCasing for {0} names", Justification = "<En attente>")]
public enum ERole
{
  eConsole,
  eMultimedia,
  eCommunications,
  ERole_enum_count
}

[Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IMMDeviceEnumerator
{
  int NotImpl1();

  [PreserveSig]
  int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice ppDevice);

  // the rest is not implemented
}

[Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IMMDevice
{
  [PreserveSig]
  int Activate(ref Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);

  // the rest is not implemented
}

[Guid("77AA99A0-1BD6-484F-8BC7-2C654C9A9B6F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[SuppressMessage("Naming", "GCop201:Use camelCasing when declaring {0}", Justification = "<En attente>")]
public interface IAudioSessionManager2
{
  int NotImpl1();
  int NotImpl2();

  [PreserveSig]
  int GetSessionEnumerator(out IAudioSessionEnumerator SessionEnum);

  // the rest is not implemented
}

[Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[SuppressMessage("Naming", "GCop201:Use camelCasing when declaring {0}", Justification = "<En attente>")]
public interface IAudioSessionEnumerator
{
  [PreserveSig]
  int GetCount(out int SessionCount);

  [PreserveSig]
  int GetSession(int SessionCount, out IAudioSessionControl2 Session);
}

[Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[SuppressMessage("Naming", "GCop201:Use camelCasing when declaring {0}", Justification = "<En attente>")]
[SuppressMessage("Style", "GCop408:Flag or switch parameters (bool) should go after all non-optional parameters. If the boolean parameter is not a flag or switch, split the method into two different methods, each doing one thing.", Justification = "Opinion")]
public interface ISimpleAudioVolume
{
  [PreserveSig]
  int SetMasterVolume(float fLevel, ref Guid EventContext);

  [PreserveSig]
  int GetMasterVolume(out float pfLevel);

  [PreserveSig]
  int SetMute(bool bMute, ref Guid EventContext);

  [PreserveSig]
  int GetMute(out bool pbMute);
}

[Guid("bfb7ff88-7239-4fc9-8fa2-07c950be9c6d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[SuppressMessage("Naming", "GCop201:Use camelCasing when declaring {0}", Justification = "<En attente>")]
public interface IAudioSessionControl2
{
  // IAudioSessionControl
  [PreserveSig]
  int NotImpl0();

  [PreserveSig]
  int GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

  [PreserveSig]
  int SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string Value, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);

  [PreserveSig]
  int GetIconPath([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

  [PreserveSig]
  int SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string Value, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);

  [PreserveSig]
  int GetGroupingParam(out Guid pRetVal);

  [PreserveSig]
  int SetGroupingParam([MarshalAs(UnmanagedType.LPStruct)] Guid Override, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);

  [PreserveSig]
  int NotImpl1();

  [PreserveSig]
  int NotImpl2();

  // IAudioSessionControl2
  [PreserveSig]
  int GetSessionIdentifier([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

  [PreserveSig]
  int GetSessionInstanceIdentifier([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

  [PreserveSig]
  int GetProcessId(out int pRetVal);

  [PreserveSig]
  int IsSystemSoundsSession();

  [PreserveSig]
  int SetDuckingPreference(bool optOut);
}

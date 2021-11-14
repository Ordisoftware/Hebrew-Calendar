using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Ordisoftware.Core
{

  // https://stackoverflow.com/questions/20938934/controlling-applications-volume-by-process-id
  static class MediaMixer
  {

    static public int GetSoundLengthMS(string fileName)
    {
      try
      {
        StringBuilder lengthBuf = new(32);
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

    static public void MuteVolume(IntPtr? handle = null)
    {
      if ( !handle.HasValue ) handle = Globals.MainForm?.Handle;
      if ( !handle.HasValue ) return;
      NativeMethods.SendMessageW(handle.Value, NativeMethods.WM_APPCOMMAND, handle.Value, (IntPtr)NativeMethods.APPCOMMAND_VOLUME_MUTE);
    }

    static public float? GetApplicationVolume(int pid)
    {
      ISimpleAudioVolume volume = GetVolumeObject(pid);
      if ( volume == null )
        return null;

      volume.GetMasterVolume(out var level);
      Marshal.ReleaseComObject(volume);
      return level * 100;
    }

    static public bool? GetApplicationMute(int pid)
    {
      ISimpleAudioVolume volume = GetVolumeObject(pid);
      if ( volume == null )
        return null;

      volume.GetMute(out var mute);
      Marshal.ReleaseComObject(volume);
      return mute;
    }

    static public bool SetApplicationVolume(int pid, float level)
    {
      ISimpleAudioVolume volume = GetVolumeObject(pid);
      if ( volume == null )
        return false;

      Guid guid = Guid.Empty;
      volume.SetMasterVolume(level / 100, ref guid);
      Marshal.ReleaseComObject(volume);
      return true;
    }

    static public void SetApplicationMute(int pid, bool mute)
    {
      ISimpleAudioVolume volume = GetVolumeObject(pid);
      if ( volume == null )
        return;

      Guid guid = Guid.Empty;
      volume.SetMute(mute, ref guid);
      Marshal.ReleaseComObject(volume);
    }

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

  public enum EDataFlow
  {
    eRender,
    eCapture,
    eAll,
    EDataFlow_enum_count
  }

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
  public interface IAudioSessionManager2
  {
    int NotImpl1();
    int NotImpl2();

    [PreserveSig]
    int GetSessionEnumerator(out IAudioSessionEnumerator SessionEnum);

    // the rest is not implemented
  }

  [Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  public interface IAudioSessionEnumerator
  {
    [PreserveSig]
    int GetCount(out int SessionCount);

    [PreserveSig]
    int GetSession(int SessionCount, out IAudioSessionControl2 Session);
  }

  [Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
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
  public interface IAudioSessionControl2
  {
    // IAudioSessionControl
    [PreserveSig]
    int NotImpl0();

    [PreserveSig]
    int GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

    [PreserveSig]
    int SetDisplayName([MarshalAs(UnmanagedType.LPWStr)]string Value, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);

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

}

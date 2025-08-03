/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-09 </created>
/// <edited> 2021-01 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides sound item.
/// </summary>
public class SoundItem
{

  static private readonly SoundPlayer SoundPlayer = new();

  static volatile private List<SoundItem> ApplicationSounds;

  static volatile private List<SoundItem> WindowsSounds;

  [SuppressMessage("Design", "GCop139:Use constant instead of field.", Justification = "Analysis error")]
  static private readonly object Locker = new();

  static public List<SoundItem> GetApplicationSounds()
  {
    lock ( Locker ) return ApplicationSounds ??= GetSounds(Globals.ApplicationSoundsFolderPath);
  }

  static public List<SoundItem> GetWindowsSounds()
  {
    lock ( Locker ) return WindowsSounds ??= GetSounds(Globals.WindowsMediaFolderPath);
  }

  static private List<SoundItem> GetSounds(string path, string filter = "*.wav")
  {
    var result = new List<SoundItem>();
    if ( !Directory.Exists(path) ) return result;
    foreach ( string file in Directory.GetFiles(path, filter, SearchOption.AllDirectories) )
      result.Add(new SoundItem(file));
    return result;
  }

  static public void Initialize()
  {
    GetApplicationSounds();
    GetWindowsSounds();
  }

  public string FilePath { get; }

  public int DurationMS { get; }

  public override string ToString()
    => Path.GetFileNameWithoutExtension(FilePath);

  public SoundItem(string path)
  {
    FilePath = path;
    DurationMS = MediaMixer.GetSoundLengthMS(path);
  }

  public bool Play()
  {
    if ( File.Exists(FilePath) )
      try
      {
        SoundPlayer.SoundLocation = FilePath;
        SoundPlayer.Load();
        SoundPlayer.Play();
        return true;
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(ex.Message);
      }
    return false;
  }

}

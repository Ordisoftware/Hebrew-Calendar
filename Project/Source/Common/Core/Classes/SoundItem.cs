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
/// <created> 2020-09 </created>
/// <edited> 2020-09 </edited>
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide sound item.
  /// </summary>
  public class SoundItem
  {

    static private SoundPlayer SoundPlayer = new SoundPlayer();

    static public List<SoundItem> GetWindowsSounds()
    {
      return GetSounds(Globals.WindowsMediaFolderPath);
    }

    static public List<SoundItem> GetSounds(string path, string filter = "*.wav")
    {
      var result = new List<SoundItem>();
      if ( !Directory.Exists(path) ) return result;
      var files = Directory.GetFiles(Globals.WindowsMediaFolderPath, filter);
      foreach ( string file in files )
        result.Add(new SoundItem(file));
      return result;
    }

    public string FilePath { get; set; }

    public override string ToString() => Path.GetFileNameWithoutExtension(FilePath);

    public SoundItem(string path, bool isWindows = false)
    {
      if (isWindows)
        FilePath = Path.Combine(Globals.WindowsMediaFolderPath, path + ".wav");
      else
        FilePath = path;
    }

    public void Play()
    {
      if ( !File.Exists(FilePath) ) return;
      SoundPlayer.SoundLocation = FilePath;
      SoundPlayer.Load();
      SoundPlayer.Play();
    }

  }

}

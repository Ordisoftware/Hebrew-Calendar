/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2012-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-03 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides lunar months file.
/// </summary>
class LunarMonthsFile : DataFile
{

  public readonly List<string> Items = new();

  public string this[int index]
    => index >= 0 && index < Items.Count ? Items[index] : string.Empty;

  public LunarMonthsFile(string filePath, bool showFileNotFound, bool configurable, DataFileFolder folder)
  : base(filePath, showFileNotFound, configurable, folder)
  {
  }

  protected override void DoReLoad(string filePath)
  {
    if ( filePath.IsNullOrEmpty() ) return;
    SystemManager.TryCatch(() =>
    {
      Items.Clear();
      Items.Add(string.Empty);
      var lines = File.ReadAllLines(filePath);
      for ( int index = 0; index < lines.Length; index++ )
      {
        if ( index >= HebrewMonths.Transcriptions.GetLang().Length )
          break;
        string line = lines[index].Trim();
        if ( line.Length == 0 )
          continue;
        if ( line.IsCommented() )
          continue;
        var parts = line.Split(new char[] { '=' }, 2);
        Items.Add(parts[1].Trim());
      }
    });
  }

}

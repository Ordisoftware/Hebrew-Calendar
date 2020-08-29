/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;
using System.IO;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MoonMonthsFile : DataFile
  {

    public readonly List<string> Items = new List<string>();

    public string this[int index]
    {
      get
      {
        if ( index < 0 || index >= Items.Count )
        {
          DisplayManager.ShowAdvert("Index out of bounds: " + index);
          return "";
        }
        else
          return Items[index];
      }
    }

    public MoonMonthsFile(string filename, bool showFileNotFound, bool configurable, DataFileFolder folder)
      : base(filename, showFileNotFound, configurable, folder)
    {
    }

    protected override void DoReLoad(string filename)
    {
      if ( filename == "" ) return;
      try
      {
        Items.Clear();
        Items.Add("");
        var lines = File.ReadAllLines(filename);
        for ( int index = 0; index < lines.Length; index++ )
        {
          Action showError = () =>
          {
            DisplayManager.ShowError(Localizer.ErrorInFile.GetLang(filename, index + 1, lines[index]));
          };
          if ( index >= Program.MoonMonthsNames.Length )
            break;
          string line = lines[index];
          if ( line.Trim() == "" )
            continue;
          if ( line.StartsWith(";") )
            continue;
          var parts = line.Split(new char[] { '=' }, 2);
          Items.Add(parts[1].Trim());
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}

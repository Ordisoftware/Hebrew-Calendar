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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  public partial class MoonMonthsFile : DataFile
  {

    public List<OnlineProviderItem> Items { get; }
     = new List<OnlineProviderItem>();

    public MoonMonthsFile(string filename, bool configurable, bool showFileNotFound)
      : base(filename, configurable, showFileNotFound, true)
    {
    }

    protected override void DoReLoad(string filename)
    {
      if ( filename == "" ) return;
      try
      {
        Items.Clear();
        var lines = File.ReadAllLines(filename);
        for ( int index = 0; index < lines.Length; index++ )
        {
          Action showError = () =>
          {
            DisplayManager.ShowError(Globals.ErrorInFile.GetLang(filename, index + 1, lines[index]));
          };
          string line = lines[index].Trim();
          if ( line == "" ) continue;
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}

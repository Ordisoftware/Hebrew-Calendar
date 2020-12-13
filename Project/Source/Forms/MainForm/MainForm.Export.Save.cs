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
/// <created> 2016-04 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;
using Newtonsoft.Json;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void ExportSave()
    {
      string filePath = "";
      var process = new NullSafeDictionary<ViewMode, Func<bool>>
      {
        [ViewMode.Text] = () =>
        {
          SaveTextDialog.FileName = Globals.AssemblyTitle;
          if ( SaveTextDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveTextDialog.FileName;
          File.WriteAllText(filePath, CalendarText.Text);
          return true;
        },
        [ViewMode.Month] = () =>
        {
          SaveImageDialog.FileName = Globals.AssemblyTitle;
          if ( SaveImageDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveImageDialog.FileName;
          try
          {
            CalendarMonth.ShowTodayButton = false;
            CalendarMonth.ShowArrowControls = false;
            CalendarMonth.GetBitmap().Save(filePath, ImageFormat.Png);
            return true;
          }
          finally
          {
            CalendarMonth.ShowTodayButton = true;
            CalendarMonth.ShowArrowControls = true;
          }
        },
        [ViewMode.Grid] = () =>
        {
          SaveDataDialog.FileName = Globals.AssemblyTitle;
          for ( int index = 0; index < Globals.DataExportTargets.Count; index++ )
            if ( Globals.DataExportTargets.ElementAt(index).Key == Settings.ExportDataPreferredTarget )
              SaveDataDialog.FilterIndex = index + 1;
          if ( SaveDataDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveDataDialog.FileName;
          return ExportSaveGrid(filePath);
        }
      };
      Action<ViewMode> after = (view) =>
      {
        DisplayManager.ShowSuccessOrSound(AppTranslations.ViewSavedToFile.GetLang(filePath),
                                          view == ViewMode.Month ? Globals.SnapshotSoundFilePath
                                                                 : Globals.KeyboardSoundFilePath);
        if ( Settings.AutoOpenExportFolder )
          SystemManager.RunShell(Path.GetDirectoryName(filePath));
        if ( Settings.AutoOpenExportedFile )
          SystemManager.RunShell(filePath);
      };
      DoExport(ExportAction.File, process, after);
    }

    private bool ExportSaveGrid(string filePath)
    {
      string extension = Path.GetExtension(SaveDataDialog.FileName);
      var selected = Globals.DataExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.CSV:
          var content = GenerateReportCSV();
          if ( content == null ) return false;
          File.WriteAllText(SaveDataDialog.FileName, content.ToString());
          break;
        case DataExportTarget.JSON:
          var table = DataSet.LunisolarDays.Select(day => new
          {
            day.Date,
            IsNewMoon = Convert.ToBoolean(day.IsNewMoon),
            IsFullMoon = Convert.ToBoolean(day.IsFullMoon),
            day.LunarMonth,
            day.LunarDay,
            day.Sunrise,
            day.Sunset,
            day.Moonrise,
            day.Moonset,
            MoonPhase = ( (MoonPhase)day.MoonPhase ).ToString(),
            SeasonChange = ( (SeasonChange)day.SeasonChange ).ToString(),
            TorahEvent = ( (TorahEvent)day.TorahEvents ).ToString()
          });
          string str = JsonConvert.SerializeObject(table, Formatting.Indented);
          File.WriteAllText(SaveDataDialog.FileName, str);
          break;
        default:
          throw new NotImplementedExceptionEx(selected.ToString());
      }
      return true;
    }

  }

}

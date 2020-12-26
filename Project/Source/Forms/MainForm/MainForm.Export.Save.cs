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
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void ExportSave()
    {
      string filePath = "";
      var process = new ExportActions
      {
        [ViewMode.Text] = (interval) =>
        {
          SaveTextDialog.FileName = Globals.AssemblyTitle + " " + DataSet.LunisolarDays.TableName;
          if ( SaveTextDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveTextDialog.FileName;
          File.WriteAllText(filePath, string.Join(Globals.NL, GetTextReportLines(interval)));
          return true;
        },
        [ViewMode.Month] = (interval) =>
        {
          try
          {
            CalendarMonth.ShowTodayButton = false;
            CalendarMonth.ShowArrowControls = false;
            if ( interval.IsDefined )
            {
              if ( FolderDialog.ShowDialog() != DialogResult.OK ) return false;
              filePath = FolderDialog.SelectedPath;
              return ExportSaveMonth(filePath, interval);
            }
            else
            {
              SaveImageDialog.FileName = string.Format("{0} {1}-{2}.png",
                                                       Globals.AssemblyTitle,
                                                       CalendarMonth.CalendarDate.Year,
                                                       CalendarMonth.CalendarDate.Month.ToString("00"));
              for ( int index = 0; index < Program.ImageExportTargets.Count; index++ )
                if ( Program.ImageExportTargets.ElementAt(index).Key == Settings.ExportImagePreferredTarget )
                  SaveImageDialog.FilterIndex = index + 1;
              if ( SaveImageDialog.ShowDialog() != DialogResult.OK ) return false;
              filePath = SaveImageDialog.FileName;
              return ExportSaveMonth(filePath, interval);
            }
          }
          finally
          {
            CalendarMonth.ShowTodayButton = true;
            CalendarMonth.ShowArrowControls = true;
          }
        },
        [ViewMode.Grid] = (interval) =>
        {
          SaveDataDialog.FileName = Globals.AssemblyTitle + " " + DataSet.LunisolarDays.TableName;
          for ( int index = 0; index < Program.GridExportTargets.Count; index++ )
            if ( Program.GridExportTargets.ElementAt(index).Key == Settings.ExportDataPreferredTarget )
              SaveDataDialog.FilterIndex = index + 1;
          if ( SaveDataDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveDataDialog.FileName;
          return ExportSaveGrid(filePath, interval);
        }
      };
      Action<ViewMode> after = (view) =>
      {
        DisplayManager.ShowSuccessOrSound(SysTranslations.ViewSavedToFile.GetLang(filePath),
                                          view == ViewMode.Month ? Globals.SnapshotSoundFilePath
                                                                 : Globals.KeyboardSoundFilePath);
        if ( Settings.AutoOpenExportFolder )
          SystemManager.RunShell(Path.GetDirectoryName(filePath));
        if ( Settings.AutoOpenExportedFile )
          SystemManager.RunShell(filePath);
      };
      DoExport(ExportAction.SaveToFile, process, after);
    }

    private bool ExportSaveMonth(string filePath, ExportInterval interval)
    {
      if ( interval.IsDefined )
      {
        // TODO waitcursor as csv & advert si > 60 (5 ans) + option
        var current = CalendarMonth.CalendarDate;
        CalendarMonth.CalendarDate = interval.Start.Value;
        bool HasMorePages = true;
        while ( HasMorePages )
        {
          string filename = string.Format("{0} {1}-{2}.png",
                                          Globals.AssemblyTitle,
                                          CalendarMonth.CalendarDate.Year,
                                          CalendarMonth.CalendarDate.Month.ToString("00"));
          var bitmap = CalendarMonth.GetBitmap();
          bitmap.Save(Path.Combine(filePath, filename), Settings.ExportImagePreferredTarget.GetFormat());
          CalendarMonth.CalendarDate = CalendarMonth.CalendarDate.AddMonths(1);
          HasMorePages = CalendarMonth.CalendarDate <= interval.End.Value;
        }
        CalendarMonth.CalendarDate = current;
      }
      else
      {
        var bitmap = CalendarMonth.GetBitmap();
        bitmap.Save(filePath, Program.ImageExportTargets.GetFormat(Path.GetExtension(filePath)));
      }
      return true;
    }

    private bool ExportSaveGrid(string filePath, ExportInterval interval)
    {
      string extension = Path.GetExtension(SaveDataDialog.FileName);
      var selected = Program.GridExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.CSV:
          File.WriteAllText(SaveDataDialog.FileName, ExportSaveCSV(interval));
          break;
        case DataExportTarget.JSON:
          File.WriteAllText(SaveDataDialog.FileName, ExportSaveJSON(interval));
          break;
        default:
          throw new NotImplementedExceptionEx(selected);
      }
      return true;
    }

  }

}

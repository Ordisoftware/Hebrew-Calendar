﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-02 </edited>
using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private string GetExportDataFilename(ExportInterval interval)
    {
      string result = DataSet.LunisolarDays.TableName;
      int year1;
      int year2;
      if ( interval.IsDefined )
      {
        year1 = interval.Start.Value.Year;
        year2 = interval.End.Value.Year;
      }
      else
      {
        year1 = YearFirst;
        year2 = YearLast;
      }
      result += " " + year1.ToString();
      if ( year1 != year2 )
        result += "-" + year2.ToString();
      return result;
    }

    private void ExportSave()
    {
      string filePath = string.Empty;
      var process = new ExportActions
      {
        [ViewMode.Text] = (interval) =>
        {
          SaveTextDialog.FileName = GetExportDataFilename(interval);
          if ( SaveTextDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveTextDialog.FileName;
          File.WriteAllText(filePath, string.Join(Globals.NL, GetTextReportLines(interval)), Encoding.UTF8);
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
              int countImages = interval.MonthsCount;
              if ( Settings.SaveImageCountWarning > 0 && countImages >= Settings.SaveImageCountWarning )
                if ( !DisplayManager.QueryYesNo(SysTranslations.AskToSaveLotsOfImages.GetLang(countImages)) )
                  return false;
              if ( FolderDialog.ShowDialog() != DialogResult.OK ) return false;
              filePath = FolderDialog.SelectedPath;
              return ExportSaveMonthImage(filePath, interval);
            }
            else
            {
              SaveImageDialog.FileName = string.Format("{0} {1}-{2}",
                                                       DataSet.LunisolarDays.TableName,
                                                       CalendarMonth.CalendarDate.Year,
                                                       CalendarMonth.CalendarDate.Month.ToString("00"));
              for ( int index = 0; index < Program.ImageExportTargets.Count; index++ )
                if ( Program.ImageExportTargets.ElementAt(index).Key == Settings.ExportImagePreferredTarget )
                  SaveImageDialog.FilterIndex = index + 1;
              if ( SaveImageDialog.ShowDialog() != DialogResult.OK ) return false;
              filePath = SaveImageDialog.FileName;
              var bitmap = CalendarMonth.GetBitmap();
              bitmap.Save(filePath, Program.ImageExportTargets.GetFormat(Path.GetExtension(filePath)));
              return true;
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
          SaveDataGridDialog.FileName = GetExportDataFilename(interval);
          for ( int index = 0; index < Program.GridExportTargets.Count; index++ )
            if ( Program.GridExportTargets.ElementAt(index).Key == Settings.ExportDataPreferredTarget )
              SaveDataGridDialog.FilterIndex = index + 1;
          if ( SaveDataGridDialog.ShowDialog() != DialogResult.OK ) return false;
          filePath = SaveDataGridDialog.FileName;
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

    private bool ExportSaveMonthImage(string path, ExportInterval interval)
    {
      var cursor = Cursor;
      Cursor = Cursors.WaitCursor;
      try
      {
        var current = CalendarMonth.CalendarDate;
        CalendarMonth.CalendarDate = interval.Start.Value;
        bool HasMorePages = true;
        while ( HasMorePages )
        {
          string filename = string.Format("{0} {1}-{2}" + Program.ImageExportTargets[Settings.ExportImagePreferredTarget],
                                          DataSet.LunisolarDays.TableName,
                                          CalendarMonth.CalendarDate.Year,
                                          CalendarMonth.CalendarDate.Month.ToString("00"));
          var bitmap = CalendarMonth.GetBitmap();
          bitmap.Save(Path.Combine(path, filename), Settings.ExportImagePreferredTarget.GetFormat());
          CalendarMonth.CalendarDate = CalendarMonth.CalendarDate.AddMonths(1);
          HasMorePages = CalendarMonth.CalendarDate <= interval.End.Value;
        }
        CalendarMonth.CalendarDate = current;
        return true;
      }
      finally
      {
        Cursor = cursor;
      }
    }

    private bool ExportSaveGrid(string filePath, ExportInterval interval)
    {
      string extension = Path.GetExtension(filePath);
      var selected = Program.GridExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.CSV:
          File.WriteAllText(filePath, ExportSaveCSV(interval), Encoding.UTF8);
          break;
        case DataExportTarget.JSON:
          File.WriteAllText(filePath, ExportSaveJSON(interval), Encoding.UTF8);
          break;
        default:
          throw new NotImplementedExceptionEx(selected);
      }
      return true;
    }

  }

}

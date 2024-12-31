/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class ManageBookmarksForm : Form
{

  private const string TableName = "Date Bookmarks";

  private const int ExportColumnIndexID = 0;
  private const int ExportColumnIndexColorAsInt = 3;

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP017:Prefer using", Justification = "N/A (switch)")]
  [SuppressMessage("Performance", "GCop317:This code is repeated {0} times in this method. If its value remains the same during the method execution, store it in a variable. Otherwise define a method (or Func<T> variable) instead of repeating the expression. [{1}]", Justification = "N/A")]
  private void DoActionExport()
  {
    try
    {
      if ( !SaveBookmarksDialog.Run(TableName, Settings.ExportDataPreferredTarget, Program.GridExportTargets) )
        return;
      string filePath = SaveBookmarksDialog.FileName;
      using var table = DBApp.DateBookmarks.ToDataTable(ApplicationDatabase.DateBookmarksTableName);
      table.Columns.RemoveAt(ExportColumnIndexColorAsInt);
      table.Columns.RemoveAt(ExportColumnIndexID);
      table.Export(SaveBookmarksDialog.FileName, Program.GridExportTargets);
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataSavedToFile.GetLang(filePath),
                                        Globals.KeyboardSoundFilePath);
      if ( Settings.AutoOpenExportFolder )
        SystemManager.RunShell(Path.GetDirectoryName(filePath));
      if ( Settings.AutoOpenExportedFile )
        SystemManager.RunShell(filePath);
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(ex.Message);
    }
  }

}

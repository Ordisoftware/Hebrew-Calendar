/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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

  private const int ImportColumnsCount = 3;
  private const int ImportColumnIndexDate = 0;
  private const int ImportColumnIndexMemo = 1;
  private const int ImportColumnIndexColor = 2;

  private readonly string TitleDate = nameof(DateBookmarkRow.Date);
  private readonly string TitleMemo = nameof(DateBookmarkRow.Memo);
  private readonly string TitleColor = nameof(DateBookmarkRow.Color);

  private readonly Regex RegExForStringToColor
    = new(@"A=(?<Alpha>\d+),\s*R=(?<Red>\d+),\s*G=(?<Green>\d+),\s*B=(?<Blue>\d+)",
          RegexOptions.None,
          TimeSpan.FromSeconds(1));

  private readonly List<string> LastErrors = [];

  private void AddLastEddor(string message)
  {
    LastErrors.Add(message.Replace(Globals.NL2, " : ").Replace("  ", " "));
  }

  private void ShowErrors()
  {
    if ( LastErrors.Count > 0 )
    {
      using var form = new ShowTextForm(Text, LastErrors.AsMultiLine(),
                                        false, true,
                                        MessageBoxEx.DefaultWidthLarge, MessageBoxEx.DefaultHeightLarge,
                                        false, false);
      form.TextBox.Font = new Font("Courier new", ApplicationDatabase.ErrorFontSize);
      form.ShowDialog();
    }
  }

  private bool ProcessData(string title, int index, object data, Action<object> action)
  {
    try
    {
      action(data);
      return true;
    }
    catch
    {
      AddLastEddor(SysTranslations.ErrorInData.GetLang(title, index, data));
      return false;
    }
  }

  private void DoActionImport()
  {
    try
    {
      if ( !OpenBookmarksDialog.Run(string.Empty, Settings.ExportDataPreferredTarget, Program.BoardExportTargets) )
        return;
      ActionClear_Click(this, null);
      string extension = Path.GetExtension(OpenBookmarksDialog.FileName);
      var selected = Program.BoardExportTargets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.TXT:
          ImportTXT();
          break;
        case DataExportTarget.CSV:
          ImportCSV();
          break;
        case DataExportTarget.JSON:
          ImportJSON();
          break;
        default:
          throw new AdvNotImplementedException(selected);
      }
      BindingSource.DataSource = DBApp.DateBookmarksAsBindingListView;
      Modified = true;
    }
    catch ( AbortException )
    {
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(ex.Message);
    }
  }

}

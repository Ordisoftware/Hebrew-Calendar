/// <license>
/// This file is part of Ordisoftware Hebrew Calendar and Words.
/// Copyright 2012-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2021-04 </edited>
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;
using Program = Ordisoftware.Hebrew.Calendar.Program;
using Properties = Ordisoftware.Hebrew.Calendar.Properties;
using MainForm = Ordisoftware.Hebrew.Calendar.MainForm;

namespace Ordisoftware.Hebrew
{

  partial class ParashotForm : Form
  {

    static public ParashotForm Instance { get; private set; }

    static public void Run(Parashah parashah = null)
    {
      if ( Instance == null )
        Instance = new ParashotForm();
      else
      if ( Instance.Visible )
      {
        Instance.Popup();
        Instance.Select(parashah);
        return;
      }
      Instance.Show();
      Instance.ForceBringToFront();
      Instance.Select(parashah);
    }

    public readonly Properties.Settings Settings
      = Properties.Settings.Default;

    private DataRowView CurrentDataBoundItem
      => (DataRowView)DataGridView.SelectedRows[0].DataBoundItem;

    private string CurrentDataBoundItemFullReferenceBegin
      => $"{(int)CurrentDataBoundItem[nameof(Parashah.Book)]}." +
         $"{(string)CurrentDataBoundItem[nameof(Parashah.VerseBegin)]}";

    private string CurrentDataBoundItemToString(bool useHebrewFont)
    {
      var item = CurrentDataBoundItem;
      bool islinked = Convert.ToBoolean(item[nameof(Parashah.IsLinkedToNext)]);
      return $"Sefer {(TorahBooks)( (int)item[nameof(Parashah.Book)] - 1 )} " +
             $"{item[nameof(Parashah.VerseBegin)]} - {item[nameof(Parashah.VerseEnd)]} " +
             $"Parashah n°{item[nameof(Parashah.Number)]} " +
             $"{item[nameof(Parashah.Name)]}{( islinked ? "*" : string.Empty )} " +
             $"({( useHebrewFont ? item[nameof(Parashah.Hebrew)] : item[nameof(Parashah.Unicode)] )}) : " +
             $"{item[nameof(Parashah.Translation)].ToString().GetOrEmpty()} ; " +
             $"{item[nameof(Parashah.Lettriq)].ToString().GetOrEmpty()} ; " +
             $"{item[nameof(Parashah.Memo)].ToString().GetOrEmpty()} ";
    }

    private void UpdateStats()
    {
      Calendar.ApplicationStatistics.UpdateDBCommonFileSizeRequired = true;
      Calendar.ApplicationStatistics.UpdateDDParashotMemorySizeRequired = true;
    }

    private ParashotForm()
    {
      InitializeComponent();
      InitializeMenu();
      Icon = Globals.MainForm.Icon;
      ParashotTable.Take();
      BindingSource.DataSource = ParashotTable.DataTable;
      ActionSaveAsDefaults.Visible = Globals.IsDevExecutable;
      Timer_Tick(null, null);
      ActiveControl = DataGridView;
      UpdateStats();
    }

    private void InitializeMenu()
    {
      ActionStudyOnline.InitializeFromProviders(HebrewGlobals.WebProvidersParashah, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var parashah = ParashotTable.GetDefaultByID((string)CurrentDataBoundItem[nameof(Parashah.ID)]);
        HebrewTools.OpenParashahProvider((string)menuitem.Tag, parashah);
      });
      ActionOpenVerseOnline.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        HebrewTools.OpenBibleProvider((string)menuitem.Tag, CurrentDataBoundItemFullReferenceBegin);
      });
      ActionSearchOnline.InitializeFromProviders(HebrewGlobals.WebProvidersWord, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        foreach ( string word in ( (string)CurrentDataBoundItem[nameof(Parashah.Hebrew)] ).Split(' ') )
          HebrewTools.OpenWordProvider((string)menuitem.Tag, word);
      });
    }

    private void Select(Parashah parashah)
    {
      if ( parashah == null ) return;
      foreach ( DataGridViewRow row in DataGridView.Rows )
      {
        var datarowview = (DataRowView)row.DataBoundItem;
        if ( (string)datarowview[nameof(Parashah.ID)] == parashah.ID )
        {
          DataGridView.CurrentCell = row.Cells[0];
          DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.SelectedRows[0].Index;
          break;
        }
      }
    }

    private void ParashotForm_Load(object sender, EventArgs e)
    {
      EditFontSize.Value = Settings.ParashotFormFontSize;
      Location = Settings.ParashotFormLocation;
      ClientSize = Settings.ParashotFormClientSize;
      this.CheckLocationOrCenterToMainFormElseScreen();
      WindowState = Settings.ParashotFormWindowState;
      if ( Settings.ParashotFormColumnTranslationWidth != -1 )
        ColumnTranslation.Width = Settings.ParashotFormColumnTranslationWidth;
    }

    private void ParashotForm_Shown(object sender, EventArgs e)
    {
      EditFontSize_ValueChanged(null, null);
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      DataGridView.ReadOnly = ParashotTable.IsReadOnly();
      Timer.Enabled = DataGridView.ReadOnly;
      ActionErase.Enabled = !DataGridView.ReadOnly;
      ActionSaveAsDefaults.Enabled = !DataGridView.ReadOnly;
      ActionExport.Enabled = !DataGridView.ReadOnly;
      ActionReset.Enabled = !DataGridView.ReadOnly;
      ActionCheckLockers.Visible = DataGridView.ReadOnly;
      ActionViewLockers.Visible = DataGridView.ReadOnly;
      LabelTableLocked.Visible = DataGridView.ReadOnly;
      if ( Created && !DataGridView.ReadOnly )
      {
        ActionUndo.PerformClick();
        ParashotTable.Release();
        ParashotTable.Take();
        BindingSource.DataSource = ParashotTable.DataTable;
      }
    }

    private void ActionViewLockers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      string list = string.Join(Globals.NL, ProcessLocksTable.GetLockers(ParashotTable.TableName)).Indent(4);
      string msg = SysTranslations.DatabaseTableLocked.GetLang(ParashotTable.TableName, list, Timer.Interval / 1000);
      DisplayManager.Show(msg);
    }

    private void ActionCheckLockers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Timer_Tick(null, null);
    }

    private void ParashotForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( !ActionSave.Enabled ) return;
      if ( Globals.IsExiting )
      {
        this.Popup();
        DisplayManager.QueryYesNo(SysTranslations.AskToSaveChanges.GetLang(Text),
                                  ActionSave.PerformClick,
                                  ParashotTable.LoadDefaults);
      }
      else
        DisplayManager.QueryYesNoCancel(SysTranslations.AskToSaveChanges.GetLang(Text),
                                          ActionSave.PerformClick,
                                          ParashotTable.LoadDefaults,
                                          () => e.Cancel = true);
    }

    private void ParashotForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instance = null;
      if ( WindowState == FormWindowState.Minimized )
        WindowState = FormWindowState.Normal;
      Settings.ParashotFormWindowState = WindowState;
      if ( WindowState == FormWindowState.Maximized )
        WindowState = FormWindowState.Normal;
      Settings.ParashotFormLocation = Location;
      Settings.ParashotFormClientSize = ClientSize;
      Settings.ParashotFormColumnTranslationWidth = ColumnTranslation.Width;
      Settings.ParashotFormFontSize = EditFontSize.Value;
      Settings.Save();
      ParashotTable.Release();
      UpdateStats();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ActionSaveAsDefaults_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo("Overwrite default files?") )
      {
        var listTranslations = new NullSafeOfStringDictionary<string>();
        var listLettriqs = new NullSafeOfStringDictionary<string>();
        ActionSave.PerformClick();
        foreach ( DataGridViewRow row in DataGridView.Rows )
        {
          var bookName = row.Cells[ColumnBook.Index].FormattedValue as string;
          if ( !string.IsNullOrEmpty(bookName) )
          {
            bookName = bookName.ToUpper();
            listTranslations.Add("// BOOK " + bookName, string.Empty);
            listLettriqs.Add("// BOOK " + bookName, string.Empty);
          }
          string itemName = (string)row.Cells[ColumnName.Index].Value;
          string itemTranslation = (string)row.Cells[ColumnTranslation.Index].Value;
          string itemLettriq = (string)row.Cells[ColumnLettriq.Index].Value;
          listTranslations.Add(itemName, itemTranslation.Trim());
          listLettriqs.Add(itemName, itemLettriq.Trim());
        }
        listTranslations.SaveKeyValuePairs(HebrewGlobals.ParashotTranslationsFilePath, " = ");
        listLettriqs.SaveKeyValuePairs(HebrewGlobals.ParashotLettriqsFilePath, " = ");
        ParashotTable.LoadDefaults();
        DisplayManager.Show("Default files updated.");
      }
      ActiveControl = DataGridView;
    }

    private void ActionExport_Click(object sender, EventArgs e)
    {
      ActionSave.PerformClick();
      MainForm.Instance.SaveDataBoardDialog.FileName = HebrewTranslations.BoardExportFileName.GetLang(ParashotTable.TableName);
      for ( int index = 0; index < Program.BoardExportTargets.Count; index++ )
        if ( Program.BoardExportTargets.ElementAt(index).Key == Settings.ExportDataPreferredTarget )
          MainForm.Instance.SaveDataBoardDialog.FilterIndex = index + 1;
      if ( MainForm.Instance.SaveDataBoardDialog.ShowDialog() == DialogResult.OK )
      {
        string filePath = MainForm.Instance.SaveDataBoardDialog.FileName;
        DoExportTable(filePath);
        DisplayManager.ShowSuccessOrSound(SysTranslations.ViewSavedToFile.GetLang(filePath),
                                          Globals.KeyboardSoundFilePath);
        if ( Settings.AutoOpenExportFolder )
          SystemManager.RunShell(Path.GetDirectoryName(filePath));
        if ( Settings.AutoOpenExportedFile )
          SystemManager.RunShell(filePath);
      }
      ActiveControl = DataGridView;
    }

    private void DoExportTable(string filePath)
    {
      var table = new DataTable();
      int indexBook = -1;
      foreach ( DataColumn column in ParashotTable.DataTable.Columns )
        if ( indexBook == -1 && column.ColumnName == ColumnBook.DataPropertyName )
        {
          table.Columns.Add(ColumnBook.DataPropertyName, typeof(string));
          indexBook = column.Ordinal;
        }
        else
          table.Columns.Add(column.ColumnName, column.DataType);
      foreach ( DataRow row in ParashotTable.DataTable.Rows )
      {
        object[] values = new object[row.ItemArray.Length];
        Array.Copy(row.ItemArray, values, row.ItemArray.Length);
        values[indexBook] = ( (TorahBooks)( (int)row.ItemArray[indexBook] - 1 ) ).ToString();
        table.Rows.Add(values);
      }
      table.Export(filePath, Program.BoardExportTargets);
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetData.GetLang()) )
      {
        ParashotTable.CreateDataIfNotExists(true);
        BindingSource.DataSource = ParashotTable.DataTable;
        ActionSave.Enabled = false;
        ActionUndo.Enabled = false;
      }
      ActiveControl = DataGridView;
      UpdateStats();
    }

    private void ActionEmpty_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToClearCustomData.GetLang()) )
      {
        foreach ( DataRow row in ParashotTable.DataTable.Rows )
        {
          row[nameof(Parashah.Translation)] = string.Empty;
          row[nameof(Parashah.Lettriq)] = string.Empty;
          ActionSave.Enabled = true;
          ActionUndo.Enabled = true;
        }
        UpdateStats();
      }
    }

    private void ActionSave_Click(object sender, EventArgs e)
    {
      ParashotTable.Update();
      ActionSave.Enabled = false;
      ActionUndo.Enabled = false;
      ActiveControl = DataGridView;
      UpdateStats();
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      ParashotTable.DataTable.RejectChanges();
      BindingSource.ResetBindings(false);
      ActionSave.Enabled = false;
      ActionUndo.Enabled = false;
      ActiveControl = DataGridView;
      UpdateStats();
    }

    private void EditFontSize_ValueChanged(object sender, EventArgs e)
    {
      DataGridView.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
      ColumnUnicode.DefaultCellStyle.Font = new Font("Hebrew", (float)EditFontSize.Value + 5);
      if ( DataGridView.Rows.Count > 0 )
        DataGridView.ColumnHeadersHeight = DataGridView.Rows[0].Height + 5;
    }

    private void DataGridView_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.Control && e.KeyCode == Keys.S )
        ActionSave.PerformClick();
      else
      if ( e.KeyCode == Keys.F2 || ( e.KeyCode == Keys.Enter && !DataGridView.IsCurrentCellInEditMode ) )
        DataGridView.BeginEdit(false);
      else
        return;
      e.Handled = true;
      e.SuppressKeyPress = true;
    }

    private void BindingSource_DataSourceChanged(object sender, EventArgs e)
    {
      if ( DataGridView.DataSource == null ) return;
      if ( ParashotTable.DataTable == null ) return;
      foreach ( DataGridViewColumn column in DataGridView.Columns )
      {
        var datacolumn = ParashotTable.DataTable.Columns[column.DataPropertyName];
        if ( datacolumn.DataType == typeof(string) )
        {
          column.DefaultCellStyle.DataSourceNullValue = string.Empty;
          datacolumn.DefaultValue = string.Empty;
        }
      }
      UpdateStats();
    }

    private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if ( !Created ) return;
      ActionSave.Enabled = true;
      ActionUndo.Enabled = true;
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if ( e.ColumnIndex == ColumnUnicode.Index )
        e.Value = HebrewAlphabet.ToHebrewFont((string)e.Value);
      else
      if ( e.ColumnIndex == ColumnLinked.Index )
        e.Value = Convert.ToBoolean(e.Value) ? Globals.Bullet : string.Empty;
      else
      if ( e.ColumnIndex == ColumnBook.Index )
        if ( e.ColumnIndex == ColumnBook.Index && e.RowIndex > 0
          && e.Value.Equals(DataGridView[e.ColumnIndex, e.RowIndex - 1].Value) )
          e.Value = string.Empty;
        else
          e.Value = ( (TorahBooks)( (int)e.Value - 1 ) ).ToString();
    }

    private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Right && e.RowIndex != -1 )
        DataGridView.Rows[e.RowIndex].Selected = true;
    }

    private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ( e.RowIndex < 0 || e.ColumnIndex < 0 )
        DataGridView.ClearSelection();
      else
      if ( DataGridView[e.ColumnIndex, e.RowIndex].Value == DBNull.Value )
        DataGridView.ClearSelection();
    }

    private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      DataGridView.BeginEdit(false);
    }

    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if ( DataGridView.ReadOnly ) return;
      if ( e.RowIndex < 0 || e.ColumnIndex != ColumnMemo.Index ) return;
      var form = new EditMemoForm();
      form.Text += (string)DataGridView.CurrentRow.Cells[ColumnName.Index].Value;
      form.TextBox.Text = (string)CurrentDataBoundItem.Row[nameof(Parashah.Memo)];
      form.TextBox.SelectionStart = 0;
      if ( form.ShowDialog() == DialogResult.OK )
      {
        CurrentDataBoundItem.Row[nameof(Parashah.Memo)] = form.TextBox.Text;
        ActionSave.Enabled = true;
        ActionUndo.Enabled = true;
      }
    }

    private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
    {
      Program.GrammarGuideForm.Popup();
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewLetters((string)CurrentDataBoundItem[nameof(Parashah.Hebrew)],
                                    Settings.HebrewLettersExe);
    }

    private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewWordsGoToVerse(CurrentDataBoundItemFullReferenceBegin, Settings.HebrewWordsExe);
    }

    private void ActionOpenHebrewWordsSearch_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewWordsSearchWord((string)CurrentDataBoundItem[nameof(Parashah.Hebrew)], Settings.HebrewWordsExe);
    }

    private void ActionCopyName_Click(object sender, EventArgs e)
    {
      Clipboard.SetText((string)CurrentDataBoundItem[nameof(Parashah.Name)]);
    }

    private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
    {
      Clipboard.SetText((string)CurrentDataBoundItem[nameof(Parashah.Hebrew)]);
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      Clipboard.SetText((string)CurrentDataBoundItem[nameof(Parashah.Unicode)]);
    }

    private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CurrentDataBoundItemToString(true));
    }

    private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CurrentDataBoundItemToString(false));
    }

  }

}

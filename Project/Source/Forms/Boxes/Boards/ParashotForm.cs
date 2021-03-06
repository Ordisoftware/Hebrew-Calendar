﻿/// <license>
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
/// <edited> 2021-06 </edited>
using System;
using System.IO;
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
      Instance?.Show();
      Instance?.ForceBringToFront();
      Instance?.Select(parashah);
    }

    public readonly Properties.Settings Settings
      = Properties.Settings.Default;

    private Parashah CurrentDataBoundItem
      => (Parashah)DataGridView.SelectedRows[0].DataBoundItem;

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
      ActionSaveAsDefaults.Visible = Globals.IsDevExecutable;
      DataGridView.Visible = false;
    }

    private void InitializeMenu()
    {
      ActionStudyOnline.InitializeFromProviders(HebrewGlobals.WebProvidersParashah, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var parashah = ParashotFactory.Get(CurrentDataBoundItem.ID);
        HebrewTools.OpenParashahProvider((string)menuitem.Tag, parashah);
      });
      ActionOpenVerseOnline.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        HebrewTools.OpenBibleProvider((string)menuitem.Tag, CurrentDataBoundItem.FullReferenceBegin);
      });
      ActionSearchOnline.InitializeFromProviders(HebrewGlobals.WebProvidersWord, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        foreach ( string word in CurrentDataBoundItem.Hebrew.Split(' ') )
          HebrewTools.OpenWordProvider((string)menuitem.Tag, word);
      });
    }

    private void Select(Parashah parashah)
    {
      if ( parashah == null ) return;
      foreach ( DataGridViewRow row in DataGridView.Rows )
        if ( ( (Parashah)row.DataBoundItem ).ID == parashah.ID )
        {
          DataGridView.CurrentCell = row.Cells[0];
          DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.SelectedRows[0].Index;
          break;
        }
    }

    private void ParashotForm_Load(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      PanelBottom.Enabled = false;
      try
      {
        LoadingForm.Instance.Initialize(SysTranslations.ProgressLoadingData.GetLang(), 4);
        LoadingForm.Instance.DoProgress();
        MainForm.UserParashot = HebrewDatabase.Instance.TakeParashot();
        LoadingForm.Instance.DoProgress();
        EditFontSize.Value = Settings.ParashotFormFontSize;
        Location = Settings.ParashotFormLocation;
        ClientSize = Settings.ParashotFormClientSize;
        this.CheckLocationOrCenterToMainFormElseScreen();
        WindowState = Settings.ParashotFormWindowState;
        if ( Settings.ParashotFormColumnTranslationWidth != -1 )
          ColumnTranslation.Width = Settings.ParashotFormColumnTranslationWidth;
        LoadingForm.Instance.DoProgress();
        BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
        LoadingForm.Instance.DoProgress();
        UpdateControls();
      }
      finally
      {
        PanelBottom.Enabled = true;
        Cursor = Cursors.Default;
        LoadingForm.Instance.Hide();
      }
    }

    private void ParashotForm_Shown(object sender, EventArgs e)
    {
      DataGridView.Visible = true;
      ActiveControl = DataGridView;
      EditFontSize_ValueChanged(null, null);
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      UpdateControls();
      if ( Created && !DataGridView.ReadOnly )
      {
        ActionUndo.PerformClick();
        MainForm.UserParashot = HebrewDatabase.Instance.TakeParashot(true);
        BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
      }
    }

    private void UpdateControls()
    {
      DataGridView.ReadOnly = HebrewDatabase.Instance.IsParashotReadOnly();
      Timer.Enabled = DataGridView.ReadOnly;
      ActionErase.Enabled = !DataGridView.ReadOnly;
      ActionSaveAsDefaults.Enabled = !DataGridView.ReadOnly;
      ActionExport.Enabled = !DataGridView.ReadOnly;
      ActionReset.Enabled = !DataGridView.ReadOnly;
      ActionCheckLockers.Visible = DataGridView.ReadOnly;
      ActionViewLockers.Visible = DataGridView.ReadOnly;
      LabelTableLocked.Visible = DataGridView.ReadOnly;
    }

    private void ActionViewLockers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      string list = string.Join(Globals.NL, Interlocks.GetLockers(HebrewDatabase.Instance.ParashotTableName)).Indent(4);
      string msg = SysTranslations.DatabaseTableLocked.GetLang(HebrewDatabase.Instance.ParashotTableName, list, Timer.Interval / 1000);
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
                                  ParashotFactory.Reset);
      }
      else
        DisplayManager.QueryYesNoCancel(SysTranslations.AskToSaveChanges.GetLang(Text),
                                        ActionSave.PerformClick,
                                        ParashotFactory.Reset,
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
      SystemManager.TryCatch(Settings.Save);
      MainForm.UserParashot = HebrewDatabase.Instance.Parashot;
      HebrewDatabase.Instance.ReleaseParashot();
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
        ParashotFactory.Reset();
        DisplayManager.Show("Default files updated.");
      }
      ActiveControl = DataGridView;
    }

    private void ActionExport_Click(object sender, EventArgs e)
    {
      ActionSave.PerformClick();
      MainForm.Instance.SaveDataBoardDialog.FileName = HebrewTranslations.BoardExportFileName.GetLang(HebrewDatabase.Instance.ParashotTableName);
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
      var table = HebrewDatabase.Instance.Parashot.ToDataTable(HebrewDatabase.Instance.ParashotTableName);
      table.Export(filePath, Program.BoardExportTargets);
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToResetData.GetLang()) )
      {
        int index = DataGridView.CurrentRow.Index;
        MainForm.UserParashot = HebrewDatabase.Instance.CreateParashotDataIfNotExistAndLoad(true);
        BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
        DataGridView.Rows[index].Selected = true;
        DataGridView.FirstDisplayedScrollingRowIndex = index;
        ActionSave.Enabled = false;
        ActionUndo.Enabled = false;
        ActiveControl = DataGridView;
        UpdateStats();
      }
    }

    private void ActionEmpty_Click(object sender, EventArgs e)
    {
      if ( DisplayManager.QueryYesNo(SysTranslations.AskToClearCustomData.GetLang()) )
      {
        int index = DataGridView.CurrentRow.Index;
        MainForm.UserParashot = HebrewDatabase.Instance.CreateParashotDataIfNotExistAndLoad(true, true);
        BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
        DataGridView.Rows[index].Selected = true;
        DataGridView.FirstDisplayedScrollingRowIndex = index;
        ActionSave.Enabled = false;
        ActionUndo.Enabled = false;
        ActiveControl = DataGridView;
        UpdateStats();
      }
    }

    private void ActionSave_Click(object sender, EventArgs e)
    {
      HebrewDatabase.Instance.SaveParashot();
      ActionSave.Enabled = false;
      ActionUndo.Enabled = false;
      ActiveControl = DataGridView;
      UpdateStats();
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      int index = DataGridView.CurrentRow.Index;
      MainForm.UserParashot = HebrewDatabase.Instance.TakeParashot(true);
      BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
      DataGridView.Rows[index].Selected = true;
      DataGridView.FirstDisplayedScrollingRowIndex = index;
      ActionSave.Enabled = false;
      ActionUndo.Enabled = false;
      ActiveControl = DataGridView;
      UpdateStats();
    }

    private void EditFontSize_ValueChanged(object sender, EventArgs e)
    {
      DataGridView.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
      ColumnHebrew.DefaultCellStyle.Font = new Font("Hebrew", (float)EditFontSize.Value + 5);
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
      if ( HebrewDatabase.Instance.Parashot == null ) return;
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
      if ( e.ColumnIndex == ColumnLinked.Index )
        e.Value = Convert.ToBoolean(e.Value) ? Globals.Bullet : string.Empty;
      else
      if ( e.ColumnIndex == ColumnBook.Index )
        if ( e.ColumnIndex == ColumnBook.Index && e.RowIndex > 0
          && e.Value.Equals(DataGridView[e.ColumnIndex, e.RowIndex - 1].Value) )
          e.Value = string.Empty;
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
      form.TextBox.Text = CurrentDataBoundItem.Memo;
      form.TextBox.SelectionStart = 0;
      if ( form.ShowDialog() == DialogResult.OK )
      {
        CurrentDataBoundItem.Memo = form.TextBox.Text;
        ActionSave.Enabled = true;
        ActionUndo.Enabled = true;
        DataGridView.RefreshEdit();
      }
    }

    private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
    {
      Program.GrammarGuideForm.Popup();
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewLetters(CurrentDataBoundItem.Hebrew, Settings.HebrewLettersExe);
    }

    private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewWordsGoToVerse(CurrentDataBoundItem.FullReferenceBegin, Settings.HebrewWordsExe);
    }

    private void ActionOpenHebrewWordsSearch_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewWordsSearchWord(CurrentDataBoundItem.Hebrew, Settings.HebrewWordsExe);
    }

    private void ActionCopyName_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CurrentDataBoundItem.Name);
    }

    private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CurrentDataBoundItem.Hebrew);
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CurrentDataBoundItem.Unicode);
    }

    private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CurrentDataBoundItem.ToString(true));
    }

    private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
    {
      Clipboard.SetText(CurrentDataBoundItem.ToString(false));
    }

    private void ActionViewParashahInfos_Click(object sender, EventArgs e)
    {
      ShowParashahDescription(this, CurrentDataBoundItem, false);
    }

    static public bool ShowParashahDescription(Form owner, Parashah parashah, bool withLinked)
    {
      string title = HebrewTranslations.WeeklyParashah.GetLang();
      var form = (MessageBoxEx)Application.OpenForms.All(f => f.Text.Contains(title)).FirstOrDefault();
      if ( form != null )
      {
        form.Popup();
        return true;
      }
      var linked = withLinked ? parashah.GetLinked(MainForm.UserParashot) : null;
      if ( parashah == null ) return false;
      var message = parashah.ToStringReadable();
      message += Globals.NL2 + linked?.ToStringReadable();
      form = new MessageBoxEx(title, message, width: MessageBoxEx.DefaultMediumWidth);
      form.StartPosition = FormStartPosition.CenterScreen;
      form.ForceNoTopMost = true;
      form.ShowInTaskbar = true;
      form.ActionYes.Visible = true;
      form.ActionYes.Text = SysTranslations.Board.GetLang();
      form.ActionYes.Click += async (_s, _e) =>
      {
        Run(parashah);
        await System.Threading.Tasks.Task.Delay(1000);
        Instance.Popup();
      };
      form.ActionNo.Visible = !parashah.Memo.IsNullOrEmpty() || ( !linked?.Memo.IsNullOrEmpty() ?? false );
      form.ActionNo.Text = SysTranslations.Memo.GetLang();
      form.ActionNo.Click += (_s, _e) =>
      {
        string memo1 = parashah.Memo;
        string memo2 = linked?.Memo ?? "";
        DisplayManager.Show(string.Join(Globals.NL2, memo1, memo2));
      };
      form.AllowClose = true;
      form.Show();
      return true;
    }

  }

}

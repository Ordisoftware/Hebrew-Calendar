/// <license>
/// This file is part of Ordisoftware Hebrew Words.
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
/// <edited> 2021-02 </edited>
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class ParashotForm : Form
  {

    static public ParashotForm Instance { get; private set; }

    static public void Run(Parashah parashah = null)
    {
      if ( Instance == null )
        Instance = new ParashotForm();
      else
      if ( Instance.Visible )
      {
        Instance.Select(parashah);
        Instance.Popup();
        return;
      }
      Instance.Select(parashah);
      Instance.Show();
      Instance.BringToFront();
    }

    private ParashotForm()
    {
      InitializeComponent();
      InitializeMenu();
      Icon = MainForm.Instance.Icon;
      ActionExportAsDefaults.Visible = Globals.IsDevExecutable;
      ParashotTable.UseParashotTable();
      BindingSource.DataSource = ParashotTable.Instance;
      ActiveControl = DataGridView;
      foreach ( DataGridViewColumn column in DataGridView.Columns )
        column.HeaderText = column.HeaderText.ToUpper();
    }

    private void ParashotForm_Load(object sender, EventArgs e)
    {
      Location = Program.Settings.ParashotFormLocation;
      ClientSize = Program.Settings.ParashotFormClientSize;
      this.CheckLocationOrCenterToMainFormElseScreen();
      WindowState = Program.Settings.ParashotFormWindowState;
      if ( Program.Settings.ParashotFormColumnTranslationWidth != -1 )
        ColumnTranslation.Width = Program.Settings.ParashotFormColumnTranslationWidth;
    }

    private void ParashotForm_Shown(object sender, EventArgs e)
    {
      DataGridView.ReadOnly = ParashotTable.IsParashotTableReadOnly(true);
      if ( DataGridView.ReadOnly )
      {
        ActionExportAsDefaults.Enabled = false;
        ActionExport.Enabled = false;
        ActionReset.Enabled = false;
        // Use timer to check every 5s
      }
    }

    private void ParashotForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( !ActionSave.Enabled ) return;
      DisplayManager.QueryYesNo("Save changes?", ActionSave.PerformClick, Parashah.LoadTranslations);
    }

    private void ParashotForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instance = null;
      if ( WindowState == FormWindowState.Minimized )
        WindowState = FormWindowState.Normal;
      Program.Settings.ParashotFormWindowState = WindowState;
      if ( WindowState == FormWindowState.Maximized )
        WindowState = FormWindowState.Normal;
      Program.Settings.ParashotFormLocation = Location;
      Program.Settings.ParashotFormClientSize = ClientSize;
      Program.Settings.ParashotFormColumnTranslationWidth = ColumnTranslation.Width;
      Program.Settings.Save();
      ParashotTable.DisposeParashotTable();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ActionExportAsDefaults_Click(object sender, EventArgs e)
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
          listTranslations.Add("// BOOK " + bookName, "");
          listLettriqs.Add("// BOOK " + bookName, "");
        }
        string itemName = (string)row.Cells[ColumnName.Index].Value;
        string itemTranslation = (string)row.Cells[ColumnTranslation.Index].Value;
        string itemLettriq = (string)row.Cells[ColumnLettriq.Index].Value;
        listTranslations.Add(itemName, itemTranslation);
        listLettriqs.Add(itemName, itemLettriq);
      }
      listTranslations.SaveKeyValuePairs(HebrewGlobals.ParashotTranslationsFilePath, " = ");
      listLettriqs.SaveKeyValuePairs(HebrewGlobals.ParashotLettriqsFilePath, " = ");
      Parashah.LoadTranslations();
    }

    private void ActionExport_Click(object sender, EventArgs e)
    {
      ActionSave.PerformClick();
      MainForm.Instance.SaveDataDialog.FileName = "Parashot";
      for ( int index = 0; index < Program.GridExportTargets.Count; index++ )
        if ( Program.GridExportTargets.ElementAt(index).Key == Program.Settings.ExportDataPreferredTarget )
          MainForm.Instance.SaveDataDialog.FilterIndex = index + 1;
      if ( MainForm.Instance.SaveDataDialog.ShowDialog() != DialogResult.OK ) return;
      string filePath = MainForm.Instance.SaveDataDialog.FileName;
      ParashotTable.Instance.Export(filePath, Program.GridExportTargets);
    }

    private void ActionReset_Click(object sender, EventArgs e)
    {
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToResetData.GetLang()) ) return;
      ParashotTable.CreateParashotDataIfNotExists(true);
      BindingSource.DataSource = ParashotTable.Instance;
      ActionSave.Enabled = false;
      ActionUndo.Enabled = false;
    }

    private void ActionSave_Click(object sender, EventArgs e)
    {
      ParashotTable.UpdateParashotTable();
      ActionSave.Enabled = false;
      ActionUndo.Enabled = false;
    }

    private void ActionUndo_Click(object sender, EventArgs e)
    {
      ParashotTable.Instance.RejectChanges();
      BindingSource.ResetBindings(false);
      ActionSave.Enabled = false;
      ActionUndo.Enabled = false;
    }

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
      if ( e.Control && e.KeyCode == Keys.S )
        ActionSave.PerformClick();
      else
      if ( e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter )
        DataGridView.BeginEdit(false);
    }

    private void Select(Parashah parashah)
    {
      if ( parashah == null ) return;
      foreach ( DataGridViewRow row in DataGridView.Rows )
        if ( (Parashah)row.DataBoundItem == parashah )
        {
          DataGridView.CurrentCell = row.Cells[0];
          break;
        }
    }

    private DataRowView CurrentDataBoundItem 
      => (DataRowView)DataGridView.SelectedRows[0].DataBoundItem;

    private string CurrentDataBoundItemReferenceBegin
      => $"{(int)CurrentDataBoundItem[nameof(Parashah.Book)]}.{(string)CurrentDataBoundItem[nameof(Parashah.VerseBegin)]}";

    private void InitializeMenu()
    {
      ActionSearchOnline.InitializeFromProviders(OnlineProviders.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        foreach ( string word in ((string)CurrentDataBoundItem[nameof(Parashah.Unicode)]).Split(' ') )
          SystemManager.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", word));
      });
      ActionOpenVerseOnline.InitializeFromProviders(OnlineProviders.OnlineBibleProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        HebrewTools.OpenOnlineVerse((string)menuitem.Tag, CurrentDataBoundItemReferenceBegin);
      });
    }

    private void BindingSource_DataSourceChanged(object sender, EventArgs e)
    {
      if ( DataGridView.DataSource == null ) return;
      if ( ParashotTable.Instance == null ) return;
      foreach ( DataGridViewColumn column in DataGridView.Columns )
      {
        var datacolumn = ParashotTable.Instance.Columns[column.DataPropertyName];
        if ( datacolumn.DataType == typeof(string) )
        {
          column.DefaultCellStyle.DataSourceNullValue = string.Empty;
          datacolumn.DefaultValue = string.Empty;
        }
      }
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
        e.Value = HebrewAlphabet.ConvertToHebrewFont((string)e.Value);
      else
      if ( e.ColumnIndex == ColumnLinked.Index )
        e.Value = Convert.ToBoolean(e.Value) ? "•" : "";
      else
      if ( e.ColumnIndex == ColumnBook.Index )
        if ( e.ColumnIndex == ColumnBook.Index && e.RowIndex > 0
          && e.Value.Equals(DataGridView[e.ColumnIndex, e.RowIndex - 1].Value) )
          e.Value = "";
        else
          e.Value = ( (TorahBooks)( (int)e.Value - 1 ) ).ToString();
    }

    private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Right )
        if ( e.RowIndex != -1 )
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

    private void ActionOpenShorashon_Click(object sender, EventArgs e)
    {
      SystemManager.OpenWebLink((string)( (ToolStripItem)sender ).Tag);
    }

    private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
    {
      Program.GrammarGuideForm.Popup();
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewLetters((string)CurrentDataBoundItem[nameof(Parashah.Hebrew)], Program.Settings.HebrewLettersExe);
    }

    private void ActionOpenHebrewWords_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewWords(CurrentDataBoundItemReferenceBegin, Program.Settings.HebrewWordsExe);
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
      //Clipboard.SetText(CurrentParashah.ToString(true));
    }

    private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
    {
      //Clipboard.SetText(CurrentParashah.ToString());
    }

  }

}

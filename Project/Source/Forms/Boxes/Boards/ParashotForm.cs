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
      var query = from book in Parashah.All
                  from parashah in book.Value
                  select parashah;
      DataGridView.DataSource = query.ToList();
      ColumnTranslation.ReadOnly = !Globals.IsDevExecutable;
      ColumnLettriq.ReadOnly = !Globals.IsDevExecutable;
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

    private void ParashotForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( !Globals.IsDevExecutable ) return;
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
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ActionSave_Click(object sender, EventArgs e)
    {
      var listTranslations = new NullSafeOfStringDictionary<string>();
      var listLettriqs = new NullSafeOfStringDictionary<string>();
      foreach ( var book in Parashah.All.Keys )
      {
        listTranslations.Add("// BOOK " + book.ToString().ToUpper(), "");
        listLettriqs.Add("// BOOK " + book.ToString().ToUpper(), "");
        foreach ( var item in Parashah.All[book] )
        {
          listTranslations.Add(item.Name, item.Translation);
          listLettriqs.Add(item.Name, item.Lettriq);
        }
      }
      listTranslations.SaveKeyValuePairs(HebrewGlobals.ParashotTranslationsFilePath, " = ");
      listLettriqs.SaveKeyValuePairs(HebrewGlobals.ParashotLettriqsFilePath, " = ");
      ActionSave.Enabled = false;
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

    private void InitializeMenu()
    {
      ActionSearchOnline.InitializeFromProviders(OnlineProviders.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
        foreach ( string word in item.Unicode.Split(' ') )
          SystemManager.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", word));
      });
      ActionOpenVerseOnline.InitializeFromProviders(OnlineProviders.OnlineBibleProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
        int[] reference = ( ( (int)item.Book + 1 ) + "." + item.VerseBegin ).Split('.').Select(int.Parse).ToArray();
        HebrewTools.OpenOnlineVerse((string)menuitem.Tag, reference[0], reference[1], reference[2]);
      });
    }

    private void KeyUp(object sender, KeyEventArgs e)
    {
      if ( e.Control && e.KeyCode == Keys.S ) ActionSave.PerformClick();
    }

    private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if ( !Created ) return;
      ActionSave.Enabled = true;
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if ( e.ColumnIndex == ColumnUnicode.Index )
        e.Value = HebrewAlphabet.ConvertToHebrewFont((string)e.Value);
      else
      if ( e.ColumnIndex == ColumnLinked.Index )
        e.Value = (bool)e.Value ? "•" : "";
      else
      if ( e.ColumnIndex == ColumnBook.Index && e.RowIndex > 0 
        && e.Value.Equals(DataGridView[e.ColumnIndex, e.RowIndex - 1].Value) )
        e.Value = "";
    }

    private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Right )
        if ( e.RowIndex != -1 )
        {
          DataGridView.ClearSelection();
          DataGridView.Rows[e.RowIndex].Selected = true;
          BindingSource.Position = e.RowIndex;
        }
    }

    private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ( e.RowIndex < 0 || e.ColumnIndex < 0 )
        DataGridView.ClearSelection();
      else
      if ( DataGridView[e.ColumnIndex, e.RowIndex].Value == DBNull.Value )
        DataGridView.ClearSelection();
    }

    private void ActionOpenShorashon_Click(object sender, EventArgs e)
    {
      string url = (string)( (ToolStripItem)sender ).Tag;
      SystemManager.OpenWebLink(url);
    }

    private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
    {
      Program.GrammarGuideForm.Popup();
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      string name = HebrewAlphabet.ConvertToHebrewFont(item.Unicode);
      HebrewTools.OpenHebrewLetters(name, Program.Settings.HebrewLettersExe);
    }

    private void ActionOpenHebrewWords_Click(object sender, EventArgs e)
    {
      HebrewTools.OpenHebrewWords("", Program.Settings.HebrewWordsExe);
    }

    private void ActionCopyName_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      Clipboard.SetText(item.Name);
    }

    private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      Clipboard.SetText(item.Hebrew);
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      Clipboard.SetText(item.Unicode);
    }

    private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      Clipboard.SetText(item.ToString(true));
    }

    private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      Clipboard.SetText(item.ToString());
    }

  }

}

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
/// <created> 2019-01 </created>
/// <edited> 2020-03 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class ParashotForm : Form
  {

    static public void Run(Parashah parashah = null)
    {
      var form = new ParashotForm();
      if ( parashah != null )
        foreach ( DataGridViewRow row in form.DataGridView.Rows )
          if ( (Parashah)row.DataBoundItem == parashah )
          {
            form.DataGridView.CurrentCell = row.Cells[0];
            break;
          }
      form.ShowDialog();
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
      ActiveControl = DataGridView;
      foreach ( DataGridViewColumn column in DataGridView.Columns )
        column.HeaderText = column.HeaderText.ToUpper();
    }

    private void InitializeMenu()
    {
      ActionSearchOnline.InitializeFromProviders(OnlineProviders.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
        SystemManager.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", item.Unicode));
      });
      ActionOpenVerseOnline.InitializeFromProviders(OnlineProviders.OnlineBibleProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
        int[] reference = ( ( (int)item.Book + 1 ) + "." + item.VerseBegin ).Split('.').Select(int.Parse).ToArray();
        HebrewTools.OpenOnlineVerse((string)menuitem.Tag, reference[0], reference[1], reference[2]);
      });
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if ( e.ColumnIndex == ColumnBook.Index )
      {
        if ( e.RowIndex > 0 && e.Value.Equals(DataGridView[e.ColumnIndex, e.RowIndex - 1].Value) )
          e.Value = "";
      }
      else
      if ( e.ColumnIndex == ColumnUnicode.Index )
        e.Value = HebrewAlphabet.ConvertToHebrewFont((string)e.Value);
      else
      if ( e.ColumnIndex == ColumnLinked.Index )
        e.Value = (bool)e.Value ? "•" : "";
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

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      string name = HebrewAlphabet.ConvertToHebrewFont(item.Unicode);
      HebrewTools.OpenHebrewLetters(name, Program.Settings.HebrewLettersExe);
    }

    private void ActionCopyMonthName(object sender, EventArgs e, Func<string, string> process)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      string name = process?.Invoke(item.Unicode);
      Clipboard.SetText(name);
    }

    private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
    {
      ActionCopyMonthName(sender, e, s => HebrewAlphabet.ConvertToHebrewFont(s));
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      ActionCopyMonthName(sender, e, null);
    }

    private void ActionCopyLine(object sender, EventArgs e, Func<string, string> process)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      string name = process?.Invoke(item.Unicode);
      Clipboard.SetText(name);
    }

    private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
    {
      ActionCopyLine(sender, e, s => HebrewAlphabet.ConvertToHebrewFont(s));
    }

    private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
    {
      ActionCopyLine(sender, e, null);
    }

  }

}

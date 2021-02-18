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

    static public void Run()
    {
      var form = new ParashotForm();
      form.ShowDialog();
    }

    private ParashotForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      int index = 0;
      ActionSearchOnline.InitializeFromProviders(OnlineProviders.OnlineWordProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
        string str = item.Unicode;
        SystemManager.RunShell(( (string)menuitem.Tag ).Replace("%WORD%", str));
      });
      ActionOpenVerseOnline.InitializeFromProviders(OnlineProviders.OnlineBibleProviders, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
        int[] reference = ( ( (int)item.Book + 1 ) + "." + item.VerseBegin ).Split('.').Select(int.Parse).ToArray();
        HebrewTools.OpenOnlineVerse((string)menuitem.Tag, reference[0], reference[1], reference[2]);
      });
    }

    private void EditBooksForm_Load(object sender, EventArgs e)
    {
      var query = from book in Parashah.All
                  from parashah in book.Value
                  select parashah;
      DataGridView.DataSource = query.ToList();
      ActiveControl = DataGridView;
    }

    private void EditBooksForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Validate();
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if ( e.ColumnIndex == 0 )
        e.Value = HebrewAlphabet.ConvertToHebrewFont((string)e.Value);
      else
      if ( e.ColumnIndex == 6 )
        e.Value = (bool)e.Value ? "*" : "";
    }

    private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Right )
      {
        int rowSelected = e.RowIndex;
        if ( e.RowIndex != -1 )
        {
          DataGridView.ClearSelection();
          DataGridView.Rows[rowSelected].Selected = true;
          BindingSource.Position = e.RowIndex;
        }
      }
    }

    private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
    {
      string str = (string)DataGridView.SelectedRows[0].Cells[1].Value;
      HebrewTools.OpenHebrewLetters(str, Program.Settings.HebrewLettersExe);
    }

    private void ActionCopyName_Click(object sender, EventArgs e)
    {
      /*string strName = (string)DataGridView.SelectedRows[0].Cells[2].Value;
      string strTranlation = (string)DataGridView.SelectedRows[0].Cells[4].Value;
      if ( strTranlation != "" )
        strName += " - " + strTranlation;
      Clipboard.SetText(strName);*/
    }

    private void ActionCopyFontChars_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      //Clipboard.SetText(( (Data.DataSet.BooksRow)row ).Hebrew);
    }

    private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
    {
      var item = (Parashah)DataGridView.SelectedRows[0].DataBoundItem;
      //Clipboard.SetText(( (Data.DataSet.BooksRow)row ).Original);
    }

  }

}

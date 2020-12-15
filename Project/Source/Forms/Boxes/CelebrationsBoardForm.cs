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
/// <created> 2020-12 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class CelebrationsBoardForm : Form
  {

    static public CelebrationsBoardForm Instance { get; private set; }

    static public void Run()
    {
      if (Instance == null)
        Instance = new CelebrationsBoardForm();
      else
      if ( Instance.Visible )
      {
        Instance.Popup();
        return;
      }
      Instance.Show();
      Instance.BringToFront();
    }

    public DataTable Board = new DataTable();

    private CelebrationsBoardForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      Text += " - ";
      Text += Program.Settings.TorahEventsCountAsMoon
              ? AppTranslations.OmerMoon.GetLang()
              : AppTranslations.OmerSun.GetLang();
      Board.PrimaryKey = new DataColumn[] { Board.Columns.Add(AppTranslations.Year.GetLang(), typeof(int)) };
      foreach ( TorahEvent col in Enum.GetValues(typeof(TorahEvent)) )
        if ( col != TorahEvent.None && col <= TorahEvent.SoukotD8 ) // TODO change when others managed
          Board.Columns.Add(col.ToStringExport(AppTranslations.TorahEvent), typeof(DateTime));
    }

    private void CelebrationsBoardForm_Load(object sender, EventArgs e)
    {
      this.CenterToMainFormElseScreen();
      WindowState = FormWindowState.Maximized;
      // TODO only one loop ?
      var query = from day in MainForm.Instance.DataSet.LunisolarDays
                  where day.TorahEventsAsEnum != TorahEvent.None
                     && day.TorahEventsAsEnum <= TorahEvent.SoukotD8 // TODO change when others managed
                  select new
                  {
                    date = SQLiteDate.ToDateTime(day.Date),
                    torah = day.TorahEventsAsEnum
                  };
      foreach ( var item in query )
      {
        var row = Board.Rows.Find(item.date.Year);
        if ( row != null )
          row[(int)item.torah] = item.date;
        else
        {
          row = Board.NewRow();
          row[0] = item.date.Year;
          row[(int)item.torah] = item.date;
          Board.Rows.Add(row);
        }
      }
      Board.AcceptChanges();
    }

    private void CelebrationsBoardForm_Shown(object sender, EventArgs e)
    {
      DataGridView.CellFormatting += DataGridView_CellFormatting;
      DataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
      DataGridView.DataSource = Board;
      EditFontSize_ValueChanged(null, null);
    }

    private void CelebrationsBoardForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instance = null;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if ( keyData == Keys.Escape )
      {
        Close();
        return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void DataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
    {
      DataGridView.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if ( e.ColumnIndex > 0 && e.Value != null )
        if (EditUseLongDateFormat.Checked)
          e.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(( (DateTime)e.Value ).ToLongDateString());
        else
          e.Value = ( (DateTime)e.Value ).ToShortDateString();
    }

    private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if ( e.RowIndex < 0 || e.ColumnIndex < 1 ) return;
      MainForm.Instance.MenuShowHide_Click(null, null);
      MainForm.Instance.GoToDate((DateTime)DataGridView[e.ColumnIndex, e.RowIndex].Value);
    }

    private void EditFontSize_ValueChanged(object sender, EventArgs e)
    {
      DataGridView.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
      if ( DataGridView.Rows.Count > 0)
        DataGridView.ColumnHeadersHeight = DataGridView.Rows[0].Height + 5;
    }

    private void EditUseLongDateFormat_CheckedChanged(object sender, EventArgs e)
    {
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      DataGridView.Refresh();
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

  }

}

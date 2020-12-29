/// <license>
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

    private DataTable Board;
    private bool Mutex;

    private CelebrationsBoardForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      Text += " - ";
      Text += Program.Settings.TorahEventsCountAsMoon
              ? AppTranslations.OmerMoon.GetLang()
              : AppTranslations.OmerSun.GetLang();
      Text += " - Shabat : ";
      Text += AppTranslations.DayOfWeek.GetLang((DayOfWeek)Program.Settings.ShabatDay);
      var list = MainForm.Instance.YearsIntervalArray;
      SelectYear1.Fill(list, list.Min());
      SelectYear2.Fill(list, list.Max());
      DataGridView.CellFormatting += DataGridView_CellFormatting;
      DataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
      if ( DataGridView.Columns.Count > 0 )
        DataGridView.Columns[0].DefaultCellStyle.BackColor = SystemColors.Control;
    }

    private void CelebrationsBoardForm_Load(object sender, EventArgs e)
    {
      Location = Program.Settings.CelebrationsBoardFormLocation;
      ClientSize = Program.Settings.CelebrationsBoardFormClientSize;
      this.CheckLocationOrCenterToMainFormElseScreen();
      WindowState = Program.Settings.CelebrationsBoardFormWindowState;
      CreateDataTable();
      LoadGrid();
    }

    private void CelebrationsBoardForm_Shown(object sender, EventArgs e)
    {
      EditFontSize_ValueChanged(null, null);
    }

    private void CelebrationsBoardForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instance = null;
      if ( WindowState == FormWindowState.Minimized )
        WindowState = FormWindowState.Normal;
      Program.Settings.CelebrationsBoardFormWindowState = WindowState;
      if ( WindowState == FormWindowState.Maximized )
        WindowState = FormWindowState.Normal;
      Program.Settings.CelebrationsBoardFormLocation = Location;
      Program.Settings.CelebrationsBoardFormClientSize = ClientSize;
      Program.Settings.Save();
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

    private void EditFontSize_ValueChanged(object sender, EventArgs e)
    {
      DataGridView.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
      if ( DataGridView.Rows.Count > 0 )
        DataGridView.ColumnHeadersHeight = DataGridView.Rows[0].Height + 5;
    }

    private void EditColumnUpperCase_CheckedChanged(object sender, EventArgs e)
    {
      CreateDataTable();
      LoadGrid();
    }

    private void EditDateFormat_CheckedChanged(object sender, EventArgs e)
    {
      EditUseAbbreviatedNames.Enabled = EditUseLongDateFormat.Checked;
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      DataGridView.Refresh();
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void EditIncludeSeasons_CheckedChanged(object sender, EventArgs e)
    {
      LoadGrid();
    }

    private void SelectYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Created ) return;
      if ( Mutex ) return;
      Mutex = true;
      try
      {
        int year1 = (int)SelectYear1.SelectedItem;
        int year2 = (int)SelectYear2.SelectedItem;
        var control = ( (ComboBox)sender ).Parent;
        if ( control == SelectYear1 && year1 > year2 )
          SelectYear2.SelectedIndex = SelectYear1.SelectedIndex;
        if ( control == SelectYear2 && year2 < year1 )
          SelectYear1.SelectedIndex = SelectYear2.SelectedIndex;
        LoadGrid();
      }
      finally
      {
        Mutex = false;
      }
    }

    private void DataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
    {
      DataGridView.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if ( e.ColumnIndex == 0 )
      {
        e.CellStyle.BackColor = SystemColors.Control;
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
      else
      if ( e.ColumnIndex > 0 && e.Value != null && e.Value != DBNull.Value )
        if ( EditUseLongDateFormat.Checked )
        {
          var date = (DateTime)e.Value;
          string str = date.ToLongDateString();
          if ( EditUseAbbreviatedNames.Checked )
          {
            string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
            string month2 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
            string day1 = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
            string day2 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek);
            str = str.Replace(month1, month2).Replace(day1, day2);
          }
          e.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
        else
          e.Value = ( (DateTime)e.Value ).ToShortDateString();
    }

    private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ( e.ColumnIndex == 0 ) DataGridView.ClearSelection();
    }

    private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if ( e.RowIndex < 0 || e.ColumnIndex < 1 ) return;
      var value = DataGridView[e.ColumnIndex, e.RowIndex].Value;
      if ( value == null || value == DBNull.Value ) return;
      if ( !MainForm.Instance.Visible )
        MainForm.Instance.MenuShowHide_Click(null, null);
      else
        MainForm.Instance.Popup();
      MainForm.Instance.GoToDate((DateTime)value);
    }
    
    // TODO change when others managed
    private const TorahEvent MaxEvent = TorahEvent.SoukotD8;

    private void CreateDataTable()
    {
      string name = AppTranslations.Year.GetLang();
      if ( EditColumnUpperCase.Checked ) name = name.ToUpper();
      DataGridView.DataSource = null;
      Board = new DataTable();
      Board.PrimaryKey = new DataColumn[] { Board.Columns.Add(name, typeof(int)) };
      foreach ( TorahEvent col in Enum.GetValues(typeof(TorahEvent)) )
        if ( col != TorahEvent.None && col <= MaxEvent )
        {
          name = col.ToStringExport(AppTranslations.TorahEvent);
          if ( EditColumnUpperCase.Checked ) name = name.ToUpper();
          Board.Columns.Add(name, typeof(DateTime));
        }
    }

    private void LoadGrid()
    {
      // TODO only one loop ?
      int year1 = (int)SelectYear1.SelectedItem;
      int year2 = (int)SelectYear2.SelectedItem;
      var query = from day in MainForm.Instance.DataSet.LunisolarDays
                  where day.TorahEventsAsEnum != TorahEvent.None
                     && day.TorahEventsAsEnum <= MaxEvent
                     && SQLiteDate.ToDateTime(day.Date).Year >= year1
                     && SQLiteDate.ToDateTime(day.Date).Year <= year2
                  select new
                  {
                    date = SQLiteDate.ToDateTime(day.Date),
                    torah = day.TorahEventsAsEnum
                  };
      DataGridView.DataSource = null;
      Board.Rows.Clear();
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
      DataGridView.DataSource = Board;
      DataGridView.ClearSelection();
    }

  }

}

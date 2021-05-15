﻿/// <license>
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
/// <edited> 2021-04 </edited>
using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class NewMoonsBoardForm : Form
  {

    private const string TableName = "New Moons";

    static public NewMoonsBoardForm Instance { get; private set; }

    static public void Run()
    {
      if ( Instance == null )
        Instance = new NewMoonsBoardForm();
      else
      if ( Instance.Visible )
      {
        Instance.Popup();
        return;
      }
      Instance.Show();
      Instance.ForceBringToFront();
    }

    private DataTable Board;
    private bool Mutex;
    private string Title;

    private NewMoonsBoardForm()
    {
      InitializeComponent();
      Text += $" ({Program.Settings.GPSCountry}, {Program.Settings.GPSCity})";
      Text += $" - Shabat : {AppTranslations.DayOfWeek.GetLang((DayOfWeek)Program.Settings.ShabatDay)}";
      Title = Text + " - ";
      Icon = MainForm.Instance.Icon;
      var list = MainForm.Instance.YearsIntervalArray;
      SelectYear1.Fill(list, list.Min());
      SelectYear2.Fill(list, list.Max());
      DataGridView.CellFormatting += DataGridView_CellFormatting;
      DataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
      if ( DataGridView.Columns.Count > 0 )
        DataGridView.Columns[0].DefaultCellStyle.BackColor = SystemColors.Control;
    }

    private void NewMoonsBoardForm_Load(object sender, EventArgs e)
    {
      Location = Program.Settings.NewMoonsBoardFormLocation;
      ClientSize = Program.Settings.NewMoonsBoardFormClientSize;
      this.CheckLocationOrCenterToMainFormElseScreen();
      WindowState = Program.Settings.NewMoonsBoardFormWindowState;
      CreateDataTable();
      LoadGrid();
    }

    private void NewMoonsBoardForm_Shown(object sender, EventArgs e)
    {
      EditFontSize_ValueChanged(null, null);
    }

    private void NewMoonsBoardForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instance = null;
      if ( WindowState == FormWindowState.Minimized )
        WindowState = FormWindowState.Normal;
      Program.Settings.NewMoonsBoardFormWindowState = WindowState;
      if ( WindowState == FormWindowState.Maximized )
        WindowState = FormWindowState.Normal;
      Program.Settings.NewMoonsBoardFormLocation = Location;
      Program.Settings.NewMoonsBoardFormClientSize = ClientSize;
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

    private void ReloadGrid(object sender, EventArgs e)
    {
      CreateDataTable();
      LoadGrid();
    }

    private void RefreshGrid(object sender, EventArgs e)
    {
      EditUseAbbreviatedNames.Enabled = EditUseLongDateFormat.Checked;
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      DataGridView.Refresh();
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

    private void SelectYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( !Created ) return;
      if ( Mutex ) return;
      Mutex = true;
      try
      {
        int year1 = SelectYear1.Value;
        int year2 = SelectYear2.Value;
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
      if ( e.ColumnIndex > 0 && e.Value != DBNull.Value )
      {
        var date = (DateTime)e.Value;
        if ( EditUseLongDateFormat.Checked )
        {
          string str = date.ToLongDateString();
          if ( EditUseAbbreviatedNames.Checked )
          {
            string month1 = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
            string month2 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
            string day1 = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
            string day2 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek);
            str = str.Replace(month1, month2).Replace(day1, day2);
          }
          e.Value = str.Titleize();
        }
        else
          e.Value = ( (DateTime)e.Value ).ToShortDateString();
        if ( !EditHideHours.Checked ) e.Value += " " + date.ToString("HH:mm");
      }
      else
        e.CellStyle.BackColor = Color.FromArgb(250, 250, 250);
    }

    private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if ( e.RowIndex < 0 || e.ColumnIndex < 1 )
        DataGridView.ClearSelection();
      else
      if ( DataGridView[e.ColumnIndex, e.RowIndex].Value == DBNull.Value )
        DataGridView.ClearSelection();
    }

    private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if ( e.RowIndex < 0 || e.ColumnIndex < 1 )
      {
        DataGridView.ClearSelection();
        return;
      }
      var value = DataGridView[e.ColumnIndex, e.RowIndex].Value;
      if ( value == DBNull.Value )
      {
        DataGridView.ClearSelection();
        return;
      }
      if ( !MainForm.Instance.Visible )
        MainForm.Instance.MenuShowHide_Click(null, null);
      else
        MainForm.Instance.Popup();
      MainForm.Instance.GoToDate((DateTime)value);
    }

    private void CreateDataTable()
    {
      string name = AppTranslations.Year.GetLang();
      if ( EditColumnUpperCase.Checked ) name = name.ToUpper();
      Board = new DataTable(TableName);
      Board.PrimaryKey = new DataColumn[] { Board.Columns.Add(name, typeof(int)) };
      int index = 1;
      foreach ( var month in HebrewMonths.Transliterations.Skip(1) )
      {
        name = month;
        if ( EditColumnUpperCase.Checked ) name = name.ToUpper();
        Board.Columns.Add(( EditShowMonthNumbers.Checked ? index++ + " - " : "" ) + name, typeof(DateTime));
      }
      DataGridView.DataSource = Board;
    }

    private void LoadGrid()
    {
      int year1 = SelectYear1.Value;
      int year2 = SelectYear2.Value;
      ApplicationDatabase.Instance.LoadNewMoons(Board, year1, year2, EditUseRealDays.Checked);
      DataGridView.ClearSelection();
      Text = Title + AppTranslations.BoardTimingsTitle.GetLang(EditUseRealDays.Checked);
    }

    private void ActionExport_Click(object sender, EventArgs e)
    {
      MainForm.Instance.SaveDataBoardDialog.FileName = HebrewTranslations.BoardExportFileName.GetLang(TableName)
                                                     + ( EditUseRealDays.Checked ? " Moonset" : " Moonrise" );
      for ( int index = 0; index < Program.BoardExportTargets.Count; index++ )
        if ( Program.BoardExportTargets.ElementAt(index).Key == Program.Settings.ExportDataPreferredTarget )
          MainForm.Instance.SaveDataBoardDialog.FilterIndex = index + 1;
      if ( MainForm.Instance.SaveDataBoardDialog.ShowDialog() != DialogResult.OK ) return;
      string filePath = MainForm.Instance.SaveDataBoardDialog.FileName;
      Board.Export(filePath, Program.BoardExportTargets);
      DisplayManager.ShowSuccessOrSound(SysTranslations.ViewSavedToFile.GetLang(filePath),
                                        Globals.KeyboardSoundFilePath);
      if ( Program.Settings.AutoOpenExportFolder )
        SystemManager.RunShell(Path.GetDirectoryName(filePath));
      if ( Program.Settings.AutoOpenExportedFile )
        SystemManager.RunShell(filePath);
    }

  }

}

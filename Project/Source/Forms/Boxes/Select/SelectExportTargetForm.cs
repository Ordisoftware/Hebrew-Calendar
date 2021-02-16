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
/// <created> 2020-11 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MoreLinq;
using Ordisoftware.Core;
using KVPImageExportTarget = System.Collections.Generic.KeyValuePair<Ordisoftware.Core.ImageExportTarget, string>;
using KVPDataExportTarget = System.Collections.Generic.KeyValuePair<Ordisoftware.Core.DataExportTarget, string>;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class SelectExportTargetForm : Form
  {

    static public bool Run(ExportAction action, ref ViewMode view, ViewMode available, ref ExportInterval interval)
    {
      using ( var form = new SelectExportTargetForm() )
      {
        form.ActionToDo = action;
        form.Text += SysTranslations.ViewActionTitle.GetLang(action);
        form.SelectText.Enabled = available.HasFlag(ViewMode.Text);
        form.SelectMonth.Enabled = available.HasFlag(ViewMode.Month);
        form.SelectGrid.Enabled = available.HasFlag(ViewMode.Grid);
        form.EditAutoOpenExportedFile.Enabled = action == ExportAction.SaveToFile;
        form.EditAutoOpenExportFolder.Enabled = action == ExportAction.SaveToFile;
        form.EditShowPrintPreviewDialog.Enabled = action == ExportAction.Print;
        form.EditPrintImageInLandscape.Enabled = action == ExportAction.Print;
        form.EditPrintImageInLandscape.Tag = form.EditPrintImageInLandscape.Enabled;
        if ( view == ViewMode.Text && form.SelectText.Enabled )
          form.SelectText.Checked = true;
        else
        if ( view == ViewMode.Month && form.SelectMonth.Enabled )
          form.SelectMonth.Checked = true;
        else
        if ( view == ViewMode.Grid && form.SelectGrid.Enabled )
          form.SelectGrid.Checked = true;
        else
          form.Controls.OfType<RadioButton>().FirstOrDefault(c => c.Enabled).Checked = true;
        bool result = form.ShowDialog() == DialogResult.OK;
        if ( result )
        {
          if ( form.SelectText.Checked )
            view = ViewMode.Text;
          if ( form.SelectMonth.Checked )
            view = ViewMode.Month;
          if ( form.SelectGrid.Checked )
            view = ViewMode.Grid;
        }
        if ( form.SelectInterval.Checked )
        {
          var year1 = (int)form.SelectYear1.SelectedItem;
          var year2 = (int)form.SelectYear2.SelectedItem;
          if ( year2 > year1 )
          {
            interval.Start = new DateTime(year1, 1, 1);
            interval.End = new DateTime(year2, 12, 31);
          }
          else
          {
            interval.Start = new DateTime(year2, 1, 1);
            interval.End = new DateTime(year1, 12, 31);
          }
        }
        else
        {
          interval.Start = null;
          interval.End = null;
        }
        return result;
      }
    }

    private ExportAction ActionToDo;

    private SelectExportTargetForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      var control = this.GetAllControls<CheckBox>().OrderByDescending(c => c.Width).FirstOrDefault();
      if ( control != null )
      {
        int width = control.Left * 3 + control.Width + GroupBoxView.Left * 2;
        if ( width > Width ) Width = width;
      }
    }

    private void SelectViewForm_Load(object sender, EventArgs e)
    {
      EditAutoOpenExportedFile.Checked = Program.Settings.AutoOpenExportedFile;
      EditAutoOpenExportFolder.Checked = Program.Settings.AutoOpenExportFolder;
      var CurrentDay = MainForm.Instance.CurrentDay;
      int year = CurrentDay == null ? DateTime.Today.Year : SQLiteDate.ToDateTime(CurrentDay.Date).Year;
      if ( year == MainForm.Instance.DateLast.Year ) year--;
      var list = MainForm.Instance.YearsIntervalArray.SkipLast(1);
      SelectYear1.Fill(list, year);
      SelectYear2.Fill(list, year);
      SetFormat();
      UpdateControls();
    }

    private void SelectViewForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.AutoOpenExportedFile = EditAutoOpenExportedFile.Checked;
      Program.Settings.AutoOpenExportFolder = EditAutoOpenExportFolder.Checked;
      Program.Settings.Save();
    }

    private void SetFormat()
    {
      GroupBoxFormat.Controls.Clear();
      if ( SelectMonth.Checked && ActionToDo == ExportAction.SaveToFile )
        CreateFormatRedioButtons(Program.ImageExportTargets, "ExportImagePreferredTarget");
      else
      if ( SelectGrid.Checked && ( ActionToDo == ExportAction.SaveToFile || ActionToDo == ExportAction.CopyToClipboard ) )
        CreateFormatRedioButtons(Program.GridExportTargets, "ExportDataPreferredTarget");
    }

    private void CreateFormatRedioButtons<T>(NullSafeOfStringDictionary<T> list, string setting) where T : Enum
    {
      int posX = 15;
      int posY = 25;
      int index = 0;
      foreach ( KeyValuePair<T, string> item in list )
      {
        var checkbox = new RadioButton();
        GroupBoxFormat.Controls.Add(checkbox);
        checkbox.Tag = item;
        checkbox.Text = item.Key.ToString();
        checkbox.Location = new Point(posX, posY);
        checkbox.AutoSize = true;
        checkbox.TabStop = true;
        checkbox.TabIndex = index++;
        if ( item.Key.Equals(Program.Settings[setting]) )
          checkbox.Checked = true;
        checkbox.CheckedChanged += (_s, _e) =>
          Program.Settings[setting] = ( (KeyValuePair<T, string>)( (RadioButton)_s ).Tag ).Key;
        if ( index == 3 )
        {
          posX = 15 + ( GroupBoxFormat.Width - 30 ) / 2;
          posY = 25;
        }
        else
          posY += 20;
      }
    }

    private void UpdateControls()
    {
      SelectInterval.Enabled = !(SelectMonth.Checked &&  ActionToDo == ExportAction.CopyToClipboard);
      GroupBoxFormat.Enabled = ( SelectMonth.Checked && ActionToDo == ExportAction.SaveToFile )
                            || ( SelectGrid.Checked && ( ActionToDo == ExportAction.SaveToFile || ActionToDo == ExportAction.CopyToClipboard ) );
      GroupBoxYears.Enabled = SelectInterval.Checked;
      EditExportDataEnumsAsTranslations.Enabled = SelectGrid.Checked;
      EditPrintImageInLandscape.Enabled = (bool)EditPrintImageInLandscape.Tag && SelectMonth.Checked;
      SelectYear1.Refresh();
      SelectYear2.Refresh();
    }

    private void SelectView_CheckedChanged(object sender, EventArgs e)
    {
      SetFormat();
      UpdateControls();
    }

    private void SelectSingleOrInterval_CheckedChanged(object sender, EventArgs e)
    {
      GroupBoxYears.Enabled = SelectInterval.Checked;
      UpdateControls();
    }

    private void ActionIntervalInfo_Click(object sender, EventArgs e)
    {
      DisplayManager.ShowInformation(AppTranslations.NoticeExportInterval.GetLang());
    }

    private void EditAutoOpenExportedFile_CheckedChanged(object sender, EventArgs e)
    {
      if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
        EditAutoOpenExportFolder.Checked = false;
    }

    private void EditAutoOpenExportFolder_CheckedChanged(object sender, EventArgs e)
    {
      if ( EditAutoOpenExportedFile.Checked && EditAutoOpenExportFolder.Checked )
        EditAutoOpenExportedFile.Checked = false;
    }

  }

}

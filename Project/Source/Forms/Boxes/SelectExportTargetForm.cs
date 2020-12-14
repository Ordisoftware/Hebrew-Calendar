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
/// <created> 2020-11 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using MoreLinq;
using Ordisoftware.Core;
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
        form.EditAutoOpenExportedFile.Enabled = action == ExportAction.File;
        form.EditAutoOpenExportFolder.Enabled = action == ExportAction.File;
        form.EditShowPrintPreviewDialog.Enabled = action == ExportAction.Print;
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
          var year1 = (int?)form.EditYear1.SelectedItem;
          var year2 = (int?)form.EditYear2.SelectedItem;
          if ( year2 > year1 )
          {
            interval.Start = year1;
            interval.End = year2;
          }
          else
          {
            interval.Start = year2;
            interval.End = year1;
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
      int yearSelected = CurrentDay == null ? DateTime.Today.Year : SQLiteDate.ToDateTime(CurrentDay.Date).Year;
      if ( yearSelected == MainForm.Instance.DateLast.Year ) yearSelected--;
      foreach ( int indexYear in MainForm.Instance.YearsIntervalArray.SkipLast(1) )
      {
        int index1 = EditYear1.Items.Add(indexYear);
        int index2 = EditYear2.Items.Add(indexYear);
        if ( indexYear == yearSelected )
        {
          EditYear1.SelectedIndex = index1;
          EditYear2.SelectedIndex = index2;
        }
      }
      int posX = 15;
      int posY = 25;
      int index = 0;
      foreach ( KVPDataExportTarget item in Globals.DataExportTargets )
      {
        var checkbox = new RadioButton();
        GroupBoxFormat.Controls.Add(checkbox);
        checkbox.Tag = item;
        checkbox.Text = item.Key.ToString();
        checkbox.TabStop = true;
        checkbox.TabIndex = index;
        checkbox.Location = new Point(posX, posY);
        if ( item.Key == Program.Settings.ExportDataPreferredTarget )
          checkbox.Checked = true;
        checkbox.CheckedChanged += (_s, _e) =>
          Program.Settings.ExportDataPreferredTarget = ( (KVPDataExportTarget)( (RadioButton)_s ).Tag ).Key;
        posY += 20;
      }
      UpdateControls();
    }

    private void SelectViewForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.AutoOpenExportedFile = EditAutoOpenExportedFile.Checked;
      Program.Settings.AutoOpenExportFolder = EditAutoOpenExportFolder.Checked;
      Program.Settings.Save();
    }

    private void UpdateControls()
    {
      if ( SelectText.Checked )
      {
        SelectSingle.Checked = true;
        SelectInterval.Enabled = false;
      }
      else
        SelectInterval.Enabled = !(SelectMonth.Checked &&  ActionToDo == ExportAction.Clipboard);
      GroupBoxFormat.Enabled = SelectGrid.Checked;
      GroupBoxYears.Enabled = SelectInterval.Checked;
      EditExportDataEnumsAsTranslations.Enabled = SelectGrid.Checked;
      EditPrintImageInLandscape.Enabled = SelectMonth.Checked;
      EditYear1_SelectedIndexChanged(null, null);
      EditYear2_SelectedIndexChanged(null, null);
    }

    private void SelectView_CheckedChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    private void SelectSingleOrInterval_CheckedChanged(object sender, EventArgs e)
    {
      GroupBoxYears.Enabled = SelectInterval.Checked;
      UpdateControls();
    }

    private void ActionIntervalInfo_Click(object sender, EventArgs e)
    {
      DisplayManager.ShowInformation(AppTranslations.ExportIntervalNotice.GetLang());
    }

    private void EditYear1_SelectedIndexChanged(object sender, EventArgs e)
    {
      ActionFirst1.Enabled = EditYear1.SelectedIndex != 0;
      ActionPrevious1.Enabled = ActionFirst1.Enabled;
      ActionLast1.Enabled = EditYear1.SelectedIndex != EditYear1.Items.Count - 1;
      ActionNext1.Enabled = ActionLast1.Enabled;
    }

    private void EditYear2_SelectedIndexChanged(object sender, EventArgs e)
    {
      ActionFirst2.Enabled = EditYear2.SelectedIndex != 0;
      ActionPrevious2.Enabled = ActionFirst2.Enabled;
      ActionLast2.Enabled = EditYear2.SelectedIndex != EditYear2.Items.Count - 1;
      ActionNext2.Enabled = ActionLast2.Enabled;
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

    private void ActionFirst1_Click(object sender, EventArgs e)
    {
      EditYear1.SelectedIndex = 0;
      ActiveControl = ActionNext1;
    }

    private void ActionPrevious1_Click(object sender, EventArgs e)
    {
      if ( EditYear1.SelectedIndex > 0 ) EditYear1.SelectedIndex--;
      if ( EditYear1.SelectedIndex == 0) ActiveControl = ActionNext1;
    }

    private void ActionNext1_Click(object sender, EventArgs e)
    {
      if ( EditYear1.SelectedIndex < EditYear1.Items.Count - 1 ) EditYear1.SelectedIndex++;
      if ( EditYear1.SelectedIndex == EditYear1.Items.Count - 1 ) ActiveControl = ActionPrevious1;
    }

    private void ActionLast1_Click(object sender, EventArgs e)
    {
      EditYear1.SelectedIndex = EditYear1.Items.Count - 1;
      ActiveControl = ActionPrevious1;
    }

    private void ActionFirst2_Click(object sender, EventArgs e)
    {
      EditYear2.SelectedIndex = 0;
      ActiveControl = ActionNext2;
    }

    private void ActionPrevious2_Click(object sender, EventArgs e)
    {
      if ( EditYear2.SelectedIndex > 0 ) EditYear2.SelectedIndex--;
      if ( EditYear2.SelectedIndex == 0 ) ActiveControl = ActionNext2;
    }

    private void ActionNext2_Click(object sender, EventArgs e)
    {
      if ( EditYear2.SelectedIndex < EditYear2.Items.Count - 1 ) EditYear2.SelectedIndex++;
      if ( EditYear2.SelectedIndex == EditYear2.Items.Count - 1 ) ActiveControl = ActionPrevious2;
    }

    private void ActionLast2_Click(object sender, EventArgs e)
    {
      EditYear2.SelectedIndex = EditYear2.Items.Count - 1;
      ActiveControl = ActionPrevious2;
    }

  }

}

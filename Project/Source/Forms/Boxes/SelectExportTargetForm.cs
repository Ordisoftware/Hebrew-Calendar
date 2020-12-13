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
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class SelectExportTargetForm : Form
  {

    static public bool Run(ExportAction action, ref ViewMode view, ViewMode available)
    {
      using ( var form = new SelectExportTargetForm() )
      {
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
        return result;
      }
    }

    private SelectExportTargetForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      Width = EditSelectViewToExport.Left * 3 + EditSelectViewToExport.Width + GroupBoxView.Left * 2;
    }

    private void SelectViewForm_Load(object sender, EventArgs e)
    {
      EditAutoOpenExportedFile.Checked = Program.Settings.AutoOpenExportedFile;
      EditAutoOpenExportFolder.Checked = Program.Settings.AutoOpenExportFolder;
      var CurrentDay = MainForm.Instance.CurrentDay;
      int yearSelected = CurrentDay == null ? DateTime.Today.Year : SQLiteDate.ToDateTime(CurrentDay.Date).Year;
      foreach ( int indexYear in MainForm.Instance.YearsIntervalArray )
      {
        int index1 = EditYear1.Items.Add(indexYear);
        int index2 = EditYear2.Items.Add(indexYear);
        if ( indexYear - 1 == yearSelected )
        {
          EditYear1.SelectedIndex = index1 - 1;
          EditYear2.SelectedIndex = index2;
        }
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
        SelectInterval.Checked = false;
        SelectInterval.Enabled = false;
      }
      else
      if ( SelectMonth.Checked )
      {
        SelectInterval.Enabled = true;
      }
      else
      if ( SelectGrid.Checked )
      {
        SelectSingle.Checked = true;
        SelectInterval.Checked = false;
        SelectInterval.Enabled = false;
      }
      PanelYears.Enabled = SelectInterval.Checked;
      EditYear1_SelectedIndexChanged(null, null);
      EditYear2_SelectedIndexChanged(null, null);
    }

    private void SelectView_CheckedChanged(object sender, EventArgs e)
    {
      UpdateControls();
    }

    private void SelectSingleOrInterval_CheckedChanged(object sender, EventArgs e)
    {
      PanelYears.Enabled = SelectInterval.Checked;
      UpdateControls();
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

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

  public partial class SelectExportForm : Form
  {

    static public bool Run(ExportAction action, ref ViewMode view, ViewMode available)
    {
      using ( var form = new SelectExportForm() )
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

    private SelectExportForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      Width = (int)(EditSelectViewToExport.Left * 2.5 + EditSelectViewToExport.Width);
    }

    private void SelectViewForm_Load(object sender, EventArgs e)
    {
      EditAutoOpenExportedFile.Checked = Program.Settings.AutoOpenExportedFile;
      EditAutoOpenExportFolder.Checked = Program.Settings.AutoOpenExportFolder;
    }

    private void SelectViewForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.AutoOpenExportedFile = EditAutoOpenExportedFile.Checked;
      Program.Settings.AutoOpenExportFolder = EditAutoOpenExportFolder.Checked;
      Program.Settings.Save();
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

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
/// <edited> 2020-11 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class SelectViewForm : Form
  {

    static public bool Run(ref ViewMode view, string title)
    {
      using ( var form = new SelectViewForm() )
      {
        form.Text += title;
        switch ( view )
        {
          case ViewMode.Text:
            form.SelectText.Checked = true;
            break;
          case ViewMode.Month:
            form.SelectMonth.Checked = true;
            break;
          case ViewMode.Grid:
            form.SelectGrid.Checked = true;
            break;
        }
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

    private SelectViewForm()
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

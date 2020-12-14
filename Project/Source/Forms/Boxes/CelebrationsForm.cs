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
/// <created> 2019-01 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class CelebrationsForm : Form
  {

    static public CelebrationsForm Instance { get; private set; }

    static CelebrationsForm()
    {
      Instance = new CelebrationsForm();
    }

    static public void Run()
    {
      if ( Instance.Visible )
      {
        Instance.Popup();
        return;
      }
      Instance.ListView.Items.Clear();
      var dateStart = DateTime.Today;
      var dateEnd = dateStart.AddYears(1);
      var rows = from day in MainForm.Instance.DataSet.LunisolarDays
                 where SQLiteDate.ToDateTime(day.Date) >= dateStart && SQLiteDate.ToDateTime(day.Date) <= dateEnd
                    && ( (SeasonChange)day.SeasonChange != SeasonChange.None
                    || (TorahEvent)day.TorahEvents != TorahEvent.None )
                 select day;
      foreach ( var row in rows )
      {
        var item = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SQLiteDate.ToDateTime(row.Date).ToLongDateString());
        if ( (SeasonChange)row.SeasonChange != SeasonChange.None )
          Instance.ListView.Items.Add(item)
                                 .SubItems.Add(AppTranslations.SeasonChange.GetLang((SeasonChange)row.SeasonChange))
                                 .Tag = row.Date;
        if ( (TorahEvent)row.TorahEvents != TorahEvent.None )
          Instance.ListView.Items.Add(item)
                                 .SubItems.Add(AppTranslations.TorahEvent.GetLang((TorahEvent)row.TorahEvents))
                                 .Tag = row.Date;
      }
      Instance.ListView.Columns[Instance.ListView.Columns.Count - 1].Width = -2;
      Instance.CelebrationsForm_Load(null, null);
      Instance.Show();
      Instance.BringToFront();
    }

    private CelebrationsForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void CelebrationsForm_Load(object sender, EventArgs e)
    {
      this.CheckLocationOrCenterToMainFormElseScreen();
    }

    private void CelebrationsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Hide();
    }

    private void ListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( ListView.SelectedItems.Count > 0 )
        SystemManager.TryCatch(() =>
        {
          MainForm.Instance.GoToDate(SQLiteDate.ToDateTime(ListView.SelectedItems[0].SubItems[1].Tag.ToString()));
          if ( !MainForm.Instance.Visible )
            MainForm.Instance.MenuShowHide_Click(null, null);
          else
          if ( MainForm.Instance.WindowState == FormWindowState.Minimized )
            MainForm.Instance.Restore();
        });
    }

    private void ListView_DoubleClick(object sender, EventArgs e)
    {
      Close();
    }

  }

}

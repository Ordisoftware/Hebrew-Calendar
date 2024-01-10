/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class NextCelebrationsForm : Form
{

  static public NextCelebrationsForm Instance { get; private set; }

  static NextCelebrationsForm()
  {
    Instance = new NextCelebrationsForm();
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
    var rows = from day in ApplicationDatabase.Instance.LunisolarDays
               where day.Date >= dateStart && day.Date <= dateEnd
                  && ( day.HasSeasonChange || day.HasTorahEvent )
               select day;
    foreach ( var row in rows )
    {
      var item = row.Date.ToLongDateString().Titleize();
      if ( row.HasSeasonChange )
        Instance.ListView.Items.Add(item)
                               .SubItems.Add(AppTranslations.GetSeasonChangeDisplayText(row.SeasonChange))
                               .Tag = row.Date;
      if ( row.HasTorahEvent )
        Instance.ListView.Items.Add(item)
                               .SubItems.Add(row.TorahEventText)
                               .Tag = row.Date;
    }
    if ( Instance.ListView.Columns.Count > 0 )
      Instance.ListView.Columns[Instance.ListView.Columns.Count - 1].Width = -2;
    Instance.CelebrationsForm_Load(null, null);
    Instance.Show();
    Instance.ForceBringToFront();
  }

  private NextCelebrationsForm()
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
      try
      {
        MainForm.Instance.GoToDate((DateTime)ListView.SelectedItems[0].SubItems[1].Tag, true, false, false, this);
      }
      catch
      {
      }
  }

  private void ListView_DoubleClick(object sender, EventArgs e)
  {
    Close();
  }

}

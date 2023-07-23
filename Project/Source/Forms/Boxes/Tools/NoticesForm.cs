/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2023-07 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class NoticesForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static public NoticesForm Instance { get; private set; }

  static public void Run()
  {
    if ( Instance is null )
      Instance = new NoticesForm();
    else
    if ( Instance.Visible )
    {
      Instance.Popup();
      return;
    }
    Instance.Show();
    Instance.ForceBringToFront();
  }

  public NoticesForm()
  {
    InitializeComponent();
    Icon = Globals.MainForm.Icon;
    NoticeGeneration.Text = AppTranslations.NoticeMonthsAndDays.GetLang();
    NoticeCelebrations.Text = AppTranslations.NoticeCelebrations.GetLang();
    NoticeFoodMain.Text = AppTranslations.NoticeCelebrationsFood.GetLang();
    NoticeShabat.Text = AppTranslations.NoticeShabat.GetLang();
    NoticeParashah.Text = AppTranslations.NoticeParashah.GetLang();
    NoticeFoodPessah.Text = SysTranslations.NotYetAvailable.GetLang();
    NoticeFoodShavuhotDiet.Text = SysTranslations.NotYetAvailable.GetLang();
    NoticeFoodShavuhotLamb.Text = SysTranslations.NotYetAvailable.GetLang();
    NoticeFoodShavuhotEnd.Text = SysTranslations.NotYetAvailable.GetLang();
    NoticeFoodTeruhah.Text = SysTranslations.NotYetAvailable.GetLang();
    NoticeFoodKipur.Text = SysTranslations.NotYetAvailable.GetLang();
    NoticeFoodSukot.Text = SysTranslations.NotYetAvailable.GetLang();
  }

  private void NoticesForm_Load(object sender, EventArgs e)
  {
    TabControlMain.SelectedIndex = Settings.NoticesFormMainPageIndex;
    TabControlFood.SelectedIndex = Settings.NoticesFormFoodPageIndex;
    this.CheckLocationOrCenterToMainFormElseScreen();
  }

  private void NoticesForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    Settings.NoticesFormMainPageIndex = TabControlMain.SelectedIndex;
    Settings.NoticesFormFoodPageIndex = TabControlFood.SelectedIndex;
    e.Cancel = true;
    Hide();
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

}

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

  // TODO singleton & save location and size

  public NoticesForm()
  {
    InitializeComponent();
    Icon = Globals.MainForm.Icon;
    NoticeGeneration.Text = AppTranslations.NoticeMonthsAndDays.GetLang();
    NoticeCelebrations.Text = AppTranslations.NoticeCelebrations.GetLang();
    NoticeFoodMain.Text = AppTranslations.NoticeCelebrationsFood.GetLang();
    NoticeShabat.Text = AppTranslations.NoticeShabat.GetLang();
    NoticeParashah.Text = AppTranslations.NoticeParashah.GetLang();
  }

  private void NoticesForm_Load(object sender, EventArgs e)
  {
    if ( MainForm.Instance.Visible )
      this.CenterToMainFormElseScreen();
    else
      this.SetLocation(ControlLocation.Center);
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

}

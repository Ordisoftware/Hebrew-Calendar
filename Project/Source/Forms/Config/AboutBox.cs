/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide the about box.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class AboutBox : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static public AboutBox Instance { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static AboutBox()
    {
      Instance = new AboutBox();
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private AboutBox()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ActiveControl = ActionClose;
      ActionViewStats.Enabled = Program.Settings.UsageStatisticsEnabled;
    }

    /// <summary>
    /// Event handler. Called by AboutBox for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void AboutBox_Load(object sender, EventArgs e)
    {
      this.CenterToMainFormElseScreen();
      EditLicense.Rtf = Properties.Resources.MPL_2_0;
      Controls.OfType<LinkLabel>().Where(c => c.Name.StartsWith("linkLabel")).ToList().ForEach(c => c.TabStop = false);
    }

    public void AboutBox_Shown(object sender, EventArgs e)
    {
      Text = SysTranslations.AboutBoxTitle.GetLang(Globals.AssemblyTitle);
      ActionViewStats.Enabled = Program.Settings.UsageStatisticsEnabled;
      LabelTitle.Text = Globals.AssemblyTitle;
      LabelDescription.Text = AppTranslations.ApplicationDescription.GetLang();
      LabelVersion.Text = SysTranslations.AboutBoxVersion.GetLang(Globals.AssemblyVersion);
      LabelCopyright.Text = Globals.AssemblyCopyright;
      LabelTrademark.Text = Globals.AssemblyTrademark;
      TopMost = MainForm.Instance.TopMost;
      BringToFront();
    }

    /// <summary>
    /// Event handler. Called by LabelProvider for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link label link clicked event information.</param>
    private void LabelProvider_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      SystemManager.OpenWebLink(((LinkLabel)sender).Text);
    }

    /// <summary>
    /// Event handler. Called by LabelTrademarkName for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link label link clicked event information.</param>
    private void LabelTrademarkName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      SystemManager.OpenAuthorHome();
    }

    /// <summary>
    /// Event handler. Called by EditLicense for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link clicked event information.</param>
    private void EditLicense_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      SystemManager.OpenWebLink(e.LinkText);
    }

    /// <summary>
    /// Event handler. Called by ActionPrivacyNotice for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link clicked event information.</param>
    private void ActionPrivacyNotice_Click(object sender, EventArgs e)
    {
      DisplayManager.ShowInformation(SysTranslations.NoticePrivacyNoData.GetLang());
    }

    /// <summary>
    /// Event handler. Called by ActionViewStats for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link clicked event information.</param>
    private void ActionViewStats_Click(object sender, EventArgs e)
    {
      StatisticsForm.Run();
    }

    /// <summary>
    /// Event handler. Called by ActionCheckUpdate for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link clicked event information.</param>
    private void ActionCheckUpdate_Click(object sender, EventArgs e)
    {
      MainForm.Instance.ActionWebCheckUpdate_Click(sender, EventArgs.Empty);
    }

  }

}

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
/// <created> 2016-04 </created>
/// <edited> 2019-10 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide the about box.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class AboutBox : Form
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

    internal void AboutBox_Shown(object sender, EventArgs e)
    {
      Text = Localizer.AboutBoxTitle.GetLang(Globals.AssemblyTitle);
      LabelTitle.Text = Globals.AssemblyTitle;
      LabelDescription.Text = Translations.ApplicationDescription.GetLang();
      LabelVersion.Text = Localizer.AboutBoxVersion.GetLang(Globals.AssemblyVersion);
      LabelCopyright.Text = Globals.AssemblyCopyright;
      LabelTrademark.Text = Globals.AssemblyTrademark;
      TopMost = MainForm.Instance.TopMost;
      BringToFront();
    }

    /// <summary>
    /// Event handler. Called by labelIconsProvider for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link label link clicked event information.</param>
    private void labelIconsProvider_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
      DisplayManager.ShowInformation(Localizer.PrivacyNoticeNoData.GetLang());
    }
  }

}

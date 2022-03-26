/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides about box.
/// </summary>
partial class AboutBox : Form
{

  /// <summary>
  /// Indicates the license as RTF.
  /// </summary>
  static public string LicenseAsRTF { get; set; }

  /// <summary>
  /// Indicates the description.
  /// </summary>
  static public TranslationsDictionary DescriptionText { get; set; }

  /// <summary>
  /// Indicates the singleton instance.
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
    Icon = Globals.MainForm?.Icon;
    ActiveControl = ActionClose;
    //
    bool b1 = Directory.Exists(Globals.ProjectDependenciesFolderPath);
    bool b2 = Directory.Exists(Globals.ProjectFolderPath);
    bool b3 = Directory.Exists(Globals.ProjectMediasFolderPath);
    bool b4 = Directory.Exists(Globals.ApplicationSoundsFolderPath);
    ActionOpenFolderDependencies.Visible = b1;
    ActionOpenFolderSource.Visible = b2;
    ActionOpenFolderMedias.Visible = b3 || b4;
    //
    if ( b1 ) initLinks(Globals.ProjectDependenciesFolderPath, DataGridViewDependencies);
    if ( b3 ) initLinks(Globals.ProjectMediasFolderPath, DataGridViewMedias);
    if ( b4 ) initLinks(Globals.ApplicationSoundsFolderPath, DataGridViewMedias);
    //
    static void initLinks(string path, DataGridView grid)
    {
      foreach ( var item in Directory.GetFiles(path, "*.url", SearchOption.AllDirectories) )
      {
        var lines = File.ReadAllLines(item);
        var url = lines.Where(line => line.StartsWith("url=", StringComparison.OrdinalIgnoreCase))
                       .Select(line => line.Substring(4))
                       .FirstOrDefault();
        var row = new DataGridViewRow();
        var cell = new DataGridViewLinkCell();
        row.Cells.Add(cell);
        cell.Value = Path.GetFileNameWithoutExtension(item);
        cell.Tag = url;
        cell.ToolTipText = url;
        cell.LinkColor = Color.Navy;
        cell.VisitedLinkColor = Color.Navy;
        cell.ActiveLinkColor = Color.MediumBlue;
        cell.LinkBehavior = LinkBehavior.HoverUnderline;
        grid.Rows.Add(row);
      }
    }
  }

  /// <summary>
  /// Event handler. Called by AboutBox for load events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void AboutBox_Load(object sender, EventArgs e)
  {
    Text = SysTranslations.AboutBoxTitle.GetLang(Globals.AssemblyTitle);
    LabelTitle.Text = Globals.AssemblyTitle;
    LabelDescription.Text = DescriptionText.GetLang();
    LabelVersion.Text = SysTranslations.AboutBoxVersion.GetLang(Globals.AssemblyVersion);
    LabelCopyright.Text = Globals.AssemblyCopyright;
    LabelTrademark.Text = Globals.AssemblyTrademark;
    EditLicense.Rtf = LicenseAsRTF ?? SysTranslations.ErrorSlot.GetLang();
    LabelIDE.Text = string.Format(LabelIDE.Text, Globals.IDENameAndVersion, Globals.DevLanguageNameAndVersion);
    Width = LabelDescription.Left + LabelDescription.Width + LabelDescription.Left + LabelDescription.Left;
    this.CenterToMainFormElseScreen();
  }

  /// <summary>
  /// Event handler. Called by AboutBox for shown events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  public void AboutBox_Shown(object sender, EventArgs e)
  {
    TopMost = Globals.MainForm?.TopMost ?? false;
    BringToFront();
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
  /// Event handler. Called by ActionOpenFolderSource for clicked events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Link clicked event information.</param>
  private void ActionOpenFolderSource_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Globals.ProjectFolderPath);
  }

  /// <summary>
  /// Event handler. Called by ActionOpenFolderDependencies for clicked events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Link clicked event information.</param>
  private void ActionOpenFolderDependencies_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Globals.ProjectDependenciesFolderPath);
  }

  /// <summary>
  /// Event handler. Called by ActionOpenFolderMedias for clicked events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Link clicked event information.</param>
  private void ActionOpenFolderMedias_Click(object sender, EventArgs e)
  {
    if ( Directory.Exists(Globals.ProjectMediasFolderPath) )
    {
      using var processMediasFolder = SystemManager.RunShell(Globals.ProjectMediasFolderPath);
    }
    if ( Directory.Exists(Globals.ApplicationSoundsFolderPath) )
    {
      using var processSoundsFolder = SystemManager.RunShell(Globals.ApplicationSoundsFolderPath);
    }
  }


  /// <summary>
  /// Event handler. Called by DataGridView for cell content clicked events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Link clicked event information.</param>
  private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
  {
    var grid = sender as DataGridView;
    SystemManager.OpenWebLink((string)grid[e.ColumnIndex, e.RowIndex].Tag);
  }

}

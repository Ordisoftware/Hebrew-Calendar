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
/// <created> 2020-04 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

partial class DataFileEditorForm : Form
{

  [SuppressMessage("Performance", "U2U1012:Parameter types should be specific", Justification = "Polymorphism needed")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  static public bool Run(string title, DataFile file)
  {
    using var form = new DataFileEditorForm { Text = title };
    AddTab(form.TabControl, file);
    bool result = form.ShowDialog() == DialogResult.OK;
    if ( result ) file.ReLoad();
    return result;
  }

  static public bool Run(string title, IEnumerable<DataFile> files)
  {
    using var form = new DataFileEditorForm { Text = title };
    foreach ( var item in files ) AddTab(form.TabControl, item);
    bool result = form.ShowDialog() == DialogResult.OK;
    if ( result ) foreach ( var item in files ) item.ReLoad();
    return result;
  }

  private static void AddTab(TabControl tabcontrol, DataFile file)
  {
    if ( !File.Exists(file.FilePath) )
    {
      DisplayManager.ShowError(SysTranslations.FileNotFound.GetLang(file.FilePath));
      return;
    }
    var textbox = new TextBoxEx
    {
      Font = new Font("Consolas", 9.75F),
      Multiline = true,
      WordWrap = false,
      ScrollBars = ScrollBars.Both,
      Dock = DockStyle.Fill,
      Text = File.ReadAllText(file.FilePath)
    };
    var tabpage = new TabPage(Path.GetFileName(file.FilePath).Replace(".txt", string.Empty)) { Tag = file };
    tabpage.Controls.Add(textbox);
    tabcontrol.TabPages.Add(tabpage);
  }

  private DataFileEditorForm()
  {
    InitializeComponent();
    Icon = Globals.MainForm?.Icon;
  }

  private void EditProvidersForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
  }

  private void EditProvidersForm_Shown(object sender, EventArgs e)
  {
    var textbox = (TextBox)TabControl.TabPages[0].Controls[0];
    textbox.Focus();
    textbox.SelectionStart = 0;
    textbox.SelectionLength = 0;
  }

  private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
  {
    var textbox = (TextBox)TabControl.SelectedTab.Controls[0];
    textbox.Focus();
    textbox.SelectionLength = 0;
  }

  private void ActionReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToLoadInstalledData.GetLang()) ) return;
    string filePath = SysTranslations.UndefinedSlot.GetLang();
    foreach ( TabPage page in TabControl.TabPages )
      try
      {
        filePath = ( (DataFile)page.Tag ).FilePathDefault;
        ( (TextBox)page.Controls[0] ).Text = File.ReadAllText(filePath);
      }
      catch ( FileNotFoundException )
      {
        DisplayManager.ShowError(SysTranslations.FileNotFound.GetLang(filePath));
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(SysTranslations.LoadFileError.GetLang(filePath, ex.Message));
      }
    EditProvidersForm_Shown(this, null);
  }

  private void ActionOK_Click(object sender, EventArgs e)
  {
    string filePath = SysTranslations.UndefinedSlot.GetLang();
    foreach ( TabPage page in TabControl.TabPages )
      try
      {
        filePath = ( (DataFile)page.Tag ).FilePath;
        File.WriteAllText(filePath, ( (TextBox)page.Controls[0] ).Text, Encoding.UTF8);
      }
      catch ( Exception ex )
      {
        string msg = SysTranslations.WriteFileError.GetLang(filePath, ex.Message);
        DisplayManager.ShowError(msg);
      }
  }

  private void ActionCancel_Click(object sender, EventArgs e)
  {
    Close();
  }

}

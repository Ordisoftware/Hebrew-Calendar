﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
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
/// <edited> 2023-04 </edited>
namespace Ordisoftware.Core;

using TranslationPair = KeyValuePair<string, TranslationsDictionary>;

public sealed partial class CommonMenusControl : UserControl
{

  private const int WidthButtonSmall = 35;
  private const int WidthButtonMedium = 55;

  static public CommonMenusControl Instance { get; private set; }

  static public TranslationsDictionary PreviewFunctions { get; set; }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP008:Don't assign member with injected and created disposables", Justification = "N/A")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
  static public void CreateInstance(ToolStrip toolStrip,
                                    ref ToolStripDropDownButton buttonToReplace,
                                    NullSafeDictionary<string, TranslationsDictionary> notices,
                                    EventHandler updateClick,
                                    EventHandler viewLogClick,
                                    EventHandler viewStatsClick)
  {
    Instance = new CommonMenusControl();
    int index = toolStrip.Items.IndexOf(buttonToReplace);
    toolStrip.SuspendLayout();
    Instance.ActionInformation.Padding = buttonToReplace.Padding;
    toolStrip.Items.Remove(buttonToReplace);
    toolStrip.Items.Insert(index, Instance.ActionInformation);
    toolStrip.ResumeLayout();
    buttonToReplace = Instance.ActionInformation;
    Instance.SetNewInVersionItems(notices);
    Instance.ActionViewLog.Click += viewLogClick;
    Instance.ActionViewStats.Click += viewStatsClick;
    AboutBox.Instance.ActionViewStats.Click += viewStatsClick;
    Instance.ActionCheckUpdate.Click += updateClick;
    AboutBox.Instance.ActionCheckUpdate.Click += updateClick;
  }

  private NullSafeDictionary<string, TranslationsDictionary> Notices;

  private CommonMenusControl()
  {
    InitializeComponent();
    ActionViewVersionNews.DropDownItems.Remove(dummyVersionNews);
    MenuApplication.Text = Globals.AssemblyTitle;
    MenuApplication.Image = Globals.MainForm?.Icon.GetBySize(Globals.IconSize16).ToBitmap();
    ActionSoftpedia.Tag = Globals.SoftpediaURL;
    ActionAlternativeTo.Tag = Globals.AlternativeToURL;
    bool enableSofpedia = !Globals.SoftpediaURL.IsNullOrEmpty();
    bool enableAlternativeTo = !Globals.AlternativeToURL.IsNullOrEmpty();
    ActionSoftpedia.Visible = enableSofpedia;
    ActionAlternativeTo.Visible = enableAlternativeTo;
    SeparatorOnlineArchive.Visible = enableSofpedia || enableAlternativeTo;
    ActionPreviewModeNotice.Visible = SystemManager.CommandLineOptions.IsPreviewEnabled;
    check(ActionHebrewCalendar);
    check(ActionHebrewLetters);
    check(ActionHebrewWords);
    void check(ToolStripMenuItem item)
    {
      if ( item.Text.Contains(Globals.AssemblyTitle) )
        MenuSoftware.DropDownItems.Remove(item);
    }
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "N/A")]
  public void SetNewInVersionItems(NullSafeDictionary<string, TranslationsDictionary> notices)
  {
    ActionViewVersionNews.DropDownItems.Clear();
    Notices = notices;
    foreach ( var item in notices )
    {
      var menuitem = ActionViewVersionNews.DropDownItems.Add(SysTranslations.AboutBoxVersion.GetLang(item.Key));
      menuitem.Tag = item;
      menuitem.Click += ShowNewInVersion;
      menuitem.Image = dummyVersionNews.Image;
      menuitem.ImageScaling = ToolStripItemImageScaling.None;
    }
    ActionViewVersionNews.Enabled = ActionViewVersionNews.DropDownItems.Count > 0;
  }

  public void ShowLastNews()
  {
    ActionViewVersionNews.DropDownItems
                         .Cast<ToolStripItem>()
                         .SingleOrDefault(item => ( (TranslationPair)item.Tag ).Key == Globals.AssemblyVersion)?
                         .PerformClick();
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "N/A")]
  [SuppressMessage("Design", "GCop135:{0}", Justification = "N/A")]
  private void ShowNewInVersion(object sender, EventArgs e)
  {
    if ( sender is not ToolStripItem menuitem ) return;
    var notice = (TranslationPair)menuitem.Tag;
    string title = SysTranslations.NoticeNewFeaturesTitle.GetLang(notice.Key);
    var form = MessageBoxEx.Instances.Find(f => f.Text == title);
    if ( form is null )
    {
      string str = notice.Value.GetLang() + Globals.NL2 + SysTranslations.NavigationTip.GetLang();
      form = new MessageBoxEx(title, str,
                              width: MessageBoxEx.DefaultWidthMedium,
                              justify: false,
                              sound: false,
                              showInTaskBar: true);
      if ( !Globals.MainForm.Visible || Globals.MainForm.WindowState == FormWindowState.Minimized )
        form.StartPosition = FormStartPosition.CenterScreen;
      form.ActionOK.Text = SysTranslations.ActionClose.GetLang();
      form.ActionOK.KeyUp += onKeyUp;
      form.ActionYes.DialogResult = DialogResult.None;
      initButton(form.ActionYes, SysTranslations.Notes.GetLang(), WidthButtonMedium, true, null);
      initButton(form.ActionNo, "<<", WidthButtonSmall, Notices.Keys.Last() != notice.Key,
                 _ => ActionViewVersionNews.DropDownItems.ToEnumerable().Last().PerformClick());
      initButton(form.ActionAbort, "<", WidthButtonSmall, Notices.Keys.Last() != notice.Key,
                 index => ActionViewVersionNews.DropDownItems[index + 1].PerformClick());
      initButton(form.ActionRetry, ">", WidthButtonSmall, Notices.Keys.First() != notice.Key,
                 index => ActionViewVersionNews.DropDownItems[index - 1].PerformClick());
      initButton(form.ActionIgnore, ">>", WidthButtonSmall, Notices.Keys.First() != notice.Key,
                 _ => ActionViewVersionNews.DropDownItems[0].PerformClick());
    }
    form.ActiveControl = form.ActionOK;
    form.Popup(null);
    form.ForceBringToFront();
    //
    void initButton(Button button, string text, int width, bool enabled, Action<int> action)
    {
      button.Visible = true;
      button.Enabled = enabled;
      button.Width = width;
      button.Text = text;
      button.Click += onClick;
      button.KeyUp += onKeyUp;
      //
      void onClick(object senderOnClick, EventArgs eOnClick)
      {
        if ( action is null )
        {
          form.SendToBack();
          SystemManager.OpenWebLink(string.Format(Globals.ApplicationReleaseNotesURL, notice.Key.Replace('x', '0')));
        }
        else
        {
          var items = ActionViewVersionNews.DropDownItems.ToEnumerable();
          var found = items.FirstOrDefault(item => item.Text == SysTranslations.AboutBoxVersion.GetLang(notice.Key));
          if ( found is null ) return;
          form.Close();
          action(ActionViewVersionNews.DropDownItems.IndexOf(found));
        }
      }
    }
    //
    [SuppressMessage("Correctness", "SS018:Add cases for missing enum member.", Justification = "N/A")]
    [SuppressMessage("Correctness", "SS019:Switch should have default label.", Justification = "N/A")]
    void onKeyUp(object senderOnKeyUp, KeyEventArgs eOnKeyUp)
    {
      switch ( eOnKeyUp.KeyCode )
      {
        case Keys.Home:
          form.ActionNo.PerformClick();
          break;
        case Keys.PageUp:
          form.ActionAbort.PerformClick();
          break;
        case Keys.PageDown:
          form.ActionRetry.PerformClick();
          break;
        case Keys.End:
          form.ActionIgnore.PerformClick();
          break;
        default:
          // Nothing to do
          break;
      }
    }
  }

  private void ActionViewLog_Click(object sender, EventArgs e)
  {
    DebugManager.TraceForm.Popup();
  }

  private void ActionHelp_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Globals.HelpFilePath);
  }

  private void ActionReleaseNotes_Click(object sender, EventArgs e)
  {
    SystemManager.OpenApplicationReleaseNotes();
  }

  private void ActionAuthorHome_Click(object sender, EventArgs e)
  {
    SystemManager.OpenAuthorHome();
  }

  private void ActionApplicationHome_Click(object sender, EventArgs e)
  {
    SystemManager.OpenApplicationHome();
  }

  private void ActionContact_Click(object sender, EventArgs e)
  {
    SystemManager.OpenContactPage();
  }

  private void ActionGitHubRepo_Click(object sender, EventArgs e)
  {
    SystemManager.OpenGitHubRepo();
  }

  private void ActionSubmitBug_Click(object sender, EventArgs e)
  {
    SystemManager.CreateGitHubIssue("&labels=type: bug");
  }

  private void ActionSubmitFeature_Click(object sender, EventArgs e)
  {
    SystemManager.CreateGitHubIssue("&labels=type: feature");
  }

  private void ActionOpenWebsiteURL_Click(object sender, EventArgs e)
  {
    if ( sender is not ToolStripItem menuitem ) return;
    SystemManager.OpenWebLink((string)menuitem.Tag);
  }

  private void ActionReadme_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(Globals.ApplicationReadMeHtmlPath);
  }

  private void ActionAbout_Click(object sender, EventArgs e)
  {
    if ( AboutBox.Instance.Visible )
      AboutBox.Instance.BringToFront();
    else
      AboutBox.Instance.ShowDialog();
  }

  private void ActionShowPreviewModeNotice_Click(object sender, EventArgs e)
  {
    if ( PreviewFunctions is not null )
      DisplayManager.Show(SysTranslations.PreviewModeNotice.GetLang(PreviewFunctions[Languages.Current]));
  }

}

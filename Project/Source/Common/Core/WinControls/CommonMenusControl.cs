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

using Markdig;

using TranslationPair = KeyValuePair<string, TranslationsDictionary>;

partial class CommonMenusControl : UserControl
{

  static public CommonMenusControl Instance { get; private set; }

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
    MenuApplication.Image = Globals.MainForm?.Icon.GetBySize(16, 16).ToBitmap();
    ActionSoftpedia.Tag = Globals.SoftpediaURL;
    ActionAlternativeTo.Tag = Globals.AlternativeToURL;
    bool b1 = !Globals.SoftpediaURL.IsNullOrEmpty();
    bool b2 = !Globals.AlternativeToURL.IsNullOrEmpty();
    ActionSoftpedia.Visible = b1;
    ActionAlternativeTo.Visible = b2;
    SeparatorOnlineArchive.Visible = b1 || b2;
    check(ActionHebrewCalendar);
    check(ActionHebrewLetters);
    check(ActionHebrewWords);
    void check(ToolStripMenuItem item)
    {
      if ( item.Text.Contains(Globals.AssemblyTitle) )
        MenuSoftware.DropDownItems.Remove(item);
    }
  }

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

  private void ShowNewInVersion(object sender, EventArgs e)
  {
    if ( sender is not ToolStripItem menuitem ) return;
    var notice = (TranslationPair)menuitem.Tag;
    string title = SysTranslations.NoticeNewFeaturesTitle.GetLang(notice.Key);
    var form = MessageBoxEx.Instances.Find(f => f.Text == title);
    if ( form is null )
    {
      string str = notice.Value.GetLang() + Globals.NL2 + SysTranslations.NavigationTip.GetLang();
      form = new MessageBoxEx(title, str, width: MessageBoxEx.DefaultWidthMedium, justify: false)
      {
        DoShownSound = false,
        ShowInTaskbar = true
      };
      form.ActionOK.Text = SysTranslations.ActionClose.GetLang();
      form.ActionOK.KeyUp += onKeyUp;
      form.ActionYes.DialogResult = DialogResult.None;
      initButton(form.ActionYes, SysTranslations.Notes.GetLang(), 55, true, null);
      initButton(form.ActionNo, "<<", 35, Notices.Keys.Last() != notice.Key,
                 _ => ActionViewVersionNews.DropDownItems.ToEnumerable().Last().PerformClick());
      initButton(form.ActionAbort, "<", 35, Notices.Keys.Last() != notice.Key,
                 index => ActionViewVersionNews.DropDownItems[index + 1].PerformClick());
      initButton(form.ActionRetry, ">", 35, Notices.Keys.First() != notice.Key,
                 index => ActionViewVersionNews.DropDownItems[index - 1].PerformClick());
      initButton(form.ActionIgnore, ">>", 35, Notices.Keys.First() != notice.Key,
                 _ => ActionViewVersionNews.DropDownItems[0].PerformClick());
      void openNotes()
      {
        SystemManager.OpenWebLink(string.Format(Globals.ApplicationReleaseNotesURL, notice.Key.Replace('x', '0')));
      }
      void initButton(Button button, string text, int width, bool enabled, Action<int> action)
      {
        button.Visible = true;
        button.Enabled = enabled;
        button.Width = width;
        button.Text = text;
        button.Click += (_s, _e) =>
        {
          if ( action is null )
          {
            form.SendToBack();
            openNotes();
          }
          else
          {
            var items = ActionViewVersionNews.DropDownItems.ToEnumerable();
            var found = items.FirstOrDefault(item => item.Text == SysTranslations.AboutBoxVersion.GetLang(notice.Key));
            if ( found is null ) return;
            form.Close();
            action(ActionViewVersionNews.DropDownItems.IndexOf(found));
          }
        };
        button.KeyUp += onKeyUp;
      }
      void onKeyUp(object _sender, KeyEventArgs _e)
      {
        switch ( _e.KeyCode )
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
        }
      }
    }
    form.ActiveControl = form.ActionOK;
    form.Popup(null);
    form.ForceBringToFront();
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
    SystemManager.OpenGitHupRepo();
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
    var fileLines = Markdown.ToHtml(File.ReadAllText(Globals.ApplicationReadmeMDPath),
                                    new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
    string filePath = Path.Combine(Path.GetTempPath(), $"{Globals.ApplicationCode}-README.html");
    File.WriteAllText(filePath, fileLines, Encoding.UTF8);
    SystemManager.RunShell(filePath);
    var timer = new System.Windows.Forms.Timer { Interval = 60000 };
    timer.Tick += (_s, _e) =>
    {
      timer.Stop();
      SystemManager.TryCatch(() => File.Delete(filePath));
    };
    timer.Start();
  }

  private void ActionAbout_Click(object sender, EventArgs e)
  {
    if ( AboutBox.Instance.Visible )
      AboutBox.Instance.BringToFront();
    else
      AboutBox.Instance.ShowDialog();
  }

}

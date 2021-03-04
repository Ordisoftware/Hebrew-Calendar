/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Ordisoftware.Core;
using Markdig;

namespace Ordisoftware.Hebrew
{

  partial class CommonMenusControl : UserControl
  {

    static public CommonMenusControl Instance { get; private set; }

    static public void CreateInstance(ToolStrip toolStrip,
                                      ref ToolStripDropDownButton buttonToReplace,
                                      NullSafeDictionary<string, TranslationsDictionary> notices,
                                      EventHandler aboutClick,
                                      EventHandler updateClick,
                                      EventHandler viewLogClick,
                                      EventHandler viewStatsClick)
    {
      Instance = new CommonMenusControl();
      int index = toolStrip.Items.IndexOf(buttonToReplace);
      toolStrip.Items.Remove(buttonToReplace);
      toolStrip.Items.Insert(index, Instance.ActionInformation);
      buttonToReplace = Instance.ActionInformation;
      Instance.SetNewInVersionItems(notices);
      Instance.ActionAbout.Click += aboutClick;
      Instance.ActionCheckUpdate.Click += updateClick;
      Instance.ActionViewLog.Click += viewLogClick;
      Instance.ActionViewStats.Click += viewStatsClick;
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

    private void ShowNewInVersion(object sender, EventArgs e)
    {
      var menuitem = sender as ToolStripItem;
      if ( menuitem == null ) return;
      var notice = (KeyValuePair<string, TranslationsDictionary>)menuitem.Tag;
      string title = SysTranslations.NoticeNewFeaturesTitle.GetLang(notice.Key);
      var form = MessageBoxEx.Instances.FirstOrDefault(f => f.Text == title);
      if ( form == null )
      {
        form = new MessageBoxEx(title, notice.Value.GetLang(), MessageBoxEx.DefaultVeryLargeWidth, justify: false);
        form.DoShownSound = false;
        form.ShowInTaskbar = true;
        form.ActionOK.Text = SysTranslations.ActionClose.GetLang();
        form.ActionAbort.Visible = true;
        form.ActionAbort.Left = 5;
        form.ActionAbort.Width = 30;
        form.ActionAbort.Text = "...";
        form.ActionAbort.Click += ActionReleaseNotes_Click;
        init(form.ActionRetry,
             SysTranslations.Previous.GetLang(),
             Notices.Keys.First() != notice.Key,
             index => ActionViewVersionNews.DropDownItems[index - 1].PerformClick());
        init(form.ActionIgnore,
             SysTranslations.Next.GetLang(),
             Notices.Keys.Last() != notice.Key,
             index => ActionViewVersionNews.DropDownItems[index + 1].PerformClick());
        void init(Button button, string text, bool enabled, Action<int> action)
        {
          button.Visible = true;
          button.Enabled = enabled;
          button.Text = text;
          button.Click += (_s, _e) =>
          {
            var items = ActionViewVersionNews.DropDownItems.Cast<ToolStripItem>();
            var found = items.FirstOrDefault(item => item.Text == SysTranslations.AboutBoxVersion.GetLang(notice.Key));
            if ( found == null ) return;
            form.Close();
            action(ActionViewVersionNews.DropDownItems.IndexOf(found));
          };
        }
      }
      form.ActiveControl = form.ActionOK;
      form.Popup(null);
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
      var menuitem = sender as ToolStripItem;
      if ( menuitem == null ) return;
      SystemManager.OpenWebLink((string)menuitem.Tag);
    }

    private void ActionReadme_Click(object sender, EventArgs e)
    {
      var fileLines = Markdown.ToHtml(File.ReadAllText(Globals.ApplicationReadmeMDPath),
                                      new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
      string filePath = Path.Combine(Path.GetTempPath(), $"{Globals.ApplicationCode}-README.html");
      File.WriteAllText(filePath, fileLines, Encoding.UTF8);
      SystemManager.RunShell(filePath);
      var timer = new Timer();
      timer.Interval = 60000;
      timer.Tick += (_s, _e) =>
      {
        timer.Stop();
        try { File.Delete(filePath); }
        catch { }
      };
      timer.Start();
    }

  }

}

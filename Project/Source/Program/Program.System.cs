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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Application mutex to allow only one process instance.
    /// </summary>
    static private Mutex Mutex;

    /// <summary>
    /// Check if the process is already running.
    /// </summary>
    static public bool CheckApplicationOnlyOneInstance()
    {
      bool created;
      Mutex = new Mutex(true, Globals.AssemblyGUID, out created);
      return created;
    }

    /// <summary>
    /// Check is application's settings must be upgraded and apply it if necessary.
    /// </summary>
    static private void CheckSettingsUpgrade()
    {
      if ( Settings.UpgradeRequired )
      {
        Settings.Upgrade();
        Settings.UpgradeRequired = false;
        Settings.Save();
      }
    }

    /// <summary>
    /// Check command line arguments and apply them.
    /// </summary>
    static private void CheckCommandLineArguments(string[] args)
    {
      CommandLineArguments = args;
      try
      {
        if ( args.Length == 2 && args[0] == "/lang" )
          if ( args[1] == "en" || args[1] == "fr" )
            Settings.Language = args[1];
        if ( Settings.Language == "" )
          Settings.Language = Localizer.Language;
        Settings.Save();
      }
      catch
      {
      }
    }

    /// <summary>
    /// Indicate command line arguments.
    /// </summary>
    static public string[] CommandLineArguments { get; private set; }

    /// <summary>
    /// Center a form beside the main form.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void CenterToMainForm(this Form form)
    {
      form.Location = new Point(MainForm.Instance.Left + MainForm.Instance.Width / 2 - form.Width / 2,
                                MainForm.Instance.Top + MainForm.Instance.Height / 2 - form.Height / 2);
    }

    /// <summary>
    /// Start a process
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <param name="arguments">The comamnd line arguments.</param>
    static public void RunShell(string filename, string arguments = "")
    {
      using ( var process = new Process() )
        try
        {
          process.StartInfo.FileName = filename;
          process.StartInfo.Arguments = arguments;
          process.Start();
        }
        catch ( Exception ex )
        {
          DisplayManager.ShowError(ex.Message + Environment.NewLine + Environment.NewLine +
                                   process.StartInfo.FileName);
        }
    }

    /// <summary>
    /// Apply localized resources.
    /// </summary>
    static private void ApplyResources(ComponentResourceManager resources, Control.ControlCollection controls)
    {
      foreach ( Control control in controls )
      {
        if ( control is Label )
          resources.ApplyResources(control, control.Name);
        ApplyResources(resources, control.Controls);
      }
    }

    /// <summary>
    /// Open the application home page.
    /// </summary>
    static public void OpenApplicationHome()
    {
      SystemManager.OpenWebLink(Globals.AssemblyProduct);
    }

    /// <summary>
    /// Open the author home page.
    /// </summary>
    static public void OpenAuthorHome()
    {
      SystemManager.OpenWebLink(Globals.AssemblyTrademark);
    }

    /// <summary>
    /// Open the author contact page.
    /// </summary>
    static public void OpenContactPage()
    {
      SystemManager.OpenWebLink(Globals.AssemblyTrademark + "/contact");
    }

    /// <summary>
    /// Open the GitHub issues page.
    /// </summary>
    static public void OpenGitHibIssuesPage()
    {
      SystemManager.OpenWebLink(Globals.GitHubRepositoryURL + "/issues");
    }

    /// <summary>
    /// Check if an update is available online.
    /// </summary>
    /// <param name="auto">True if no user interaction else false</param>
    /// <returns>True if application must exist else false.</returns>
    static public bool CheckUpdate(bool auto)
    {
      if ( auto && !Settings.CheckUpdateAtStartup ) return false;
      try
      {
        using ( WebClient client = new WebClient() )
        {
          string[] partsVersion = client.DownloadString(Globals.CheckUpdateURL).Split('.');
          var version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) <= 0 )
          {
            if ( !auto )
              DisplayManager.Show(Translations.NoNewVersionAvailable.GetLang());
          }
          else
          if ( DisplayManager.QueryYesNo(Translations.NewVersionAvailable.GetLang(version) + Environment.NewLine +
                                         Environment.NewLine +
                                         Translations.AskDownloadNewVersion.GetLang()) )
          {
            SystemManager.OpenWebLink(Globals.DownloadApplicationURL);
            if ( auto )
            {
              Globals.IsExiting = true;
              return true;
            }
          }
        }
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowAdvert(DisplayManager.Title + " Check Update", ex.Message);
      }
      return false;
    }

    /// <summary>
    /// Create winforms submenu items for web links from definitions files.
    /// </summary>
    static public void CreateWebLinks(ToolStripDropDownButton menuRoot, Image imageFolder, Image imageLink)
    {
      Globals.LoadWebLinks();
      menuRoot.DropDownItems.Clear();
      Image FlagFR = null;
      Image FlagEN = null;
      Image FlagIW = null;
      Image FlagFRIW = null;
      try
      {
        FlagFR = Image.FromFile(Globals.HelpFolderPath + "flag_france.png");
        FlagEN = Image.FromFile(Globals.HelpFolderPath + "flag_great_britain.png");
        FlagIW = Image.FromFile(Globals.HelpFolderPath + "flag_israel.png");
        FlagFRIW = Image.FromFile(Globals.HelpFolderPath + "flag_fr_iw.png");
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      Dictionary<string, Image> Flags = new Dictionary<string, Image>()
      {
        { "(FR)", FlagFR },
        { "(EN)", FlagEN },
        { "(IW)", FlagIW },
        { "(FR/IW)", FlagFRIW }
      };
      foreach ( var items in Globals.OnlineLinksProviders )
        if ( items.Items.Count > 0 )
        {
          string title = items.Title.GetLang();
          ToolStripDropDownItem menu;
          if ( title != "" )
          {
            if ( items.SeparatorBeforeFolder )
              menuRoot.DropDownItems.Add(new ToolStripSeparator());
            menu = new ToolStripMenuItem(title);
            menu.ImageScaling = ToolStripItemImageScaling.None;
            menu.Image = imageFolder;
            menuRoot.DropDownItems.Add(menu);
          }
          else
            menu = menuRoot;
          foreach ( var item in items.Items )
          {
            string str = item.Name;
            if ( str == "-" )
              menu.DropDownItems.Add(new ToolStripSeparator());
            else
            {
              var menuitem = new ToolStripMenuItem();
              menu.DropDownItems.Add(menuitem);
              menuitem.ImageScaling = ToolStripItemImageScaling.None;
              menuitem.Tag = item.URL;
              menuitem.Click += (sender, e) =>
              {
                string url = (string)( (ToolStripItem)sender ).Tag;
                SystemManager.OpenWebLink(url);
              };
              foreach ( var flag in Flags )
                if ( str.StartsWith(flag.Key) )
                {
                  str = str.Replace(flag.Key, "").TrimStart();
                  menuitem.Image = flag.Value;
                  break;
                }
              menuitem.Text = str;
            }
          }
        }
    }

    /// <summary>
    /// Resize an image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The image resized.</returns>
    static public Bitmap ResizeImage(Image image, int width, int height)
    {
      var destRect = new Rectangle(0, 0, width, height);
      var destImage = new Bitmap(width, height);
      destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
      using ( var graphics = Graphics.FromImage(destImage) )
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        using ( var wrapMode = new ImageAttributes() )
        {
          wrapMode.SetWrapMode(WrapMode.TileFlipXY);
          graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        }
      }
      return destImage;
    }

  }

}

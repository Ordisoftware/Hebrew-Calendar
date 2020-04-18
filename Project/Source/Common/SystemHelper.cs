/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
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
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class SystemHelper
  {

    /// <summary>
    /// Indicate the main form.
    /// </summary>
    static public Form MainForm { get; set; }

    /// <summary>
    /// Indicate the application settings.
    /// </summary>
    static public ApplicationSettingsBase Settings { get; set; }

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
    static public void CheckSettingsUpgrade(ApplicationSettingsBase settings, ref bool upgradeRequired)
    {
      if ( upgradeRequired )
      {
        settings.Upgrade();
        upgradeRequired = false;
        settings.Save();
      }
    }

    /// <summary>
    /// Check command line arguments and apply them.
    /// </summary>
    static public void CheckCommandLineArguments(string[] args, ref string language, ApplicationSettingsBase settings)
    {
      CommandLineArguments = args;
      try
      {
        if ( args.Length == 2 && args[0] == "/lang" )
          if ( args[1] == "en" || args[1] == "fr" )
            language = args[1];
        if ( language == "" )
          language = Localizer.Language;
        settings.Save();
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
    /// Apply localized resources.
    /// </summary>
    static public void ApplyResources(ComponentResourceManager resources, Control.ControlCollection controls)
    {
      foreach ( Control control in controls )
      {
        if ( control is Label )
          resources.ApplyResources(control, control.Name);
        ApplyResources(resources, control.Controls);
      }
    }

    /// <summary>
    /// Center a form beside the main form.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void CenterToMainForm(this Form form)
    {
      if ( MainForm == null ) return;
      form.Location = new Point(MainForm.Left + MainForm.Width / 2 - form.Width / 2,
                                MainForm.Top + MainForm.Height / 2 - form.Height / 2);
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
    static public bool CheckUpdate(bool checkAtStartup, bool auto)
    {
      if ( auto && !checkAtStartup ) return false;
      try
      {
        using ( WebClient client = new WebClient() )
        {
          string[] partsVersion = client.DownloadString(Globals.CheckUpdateURL).Split('.');
          var version = new Version(Convert.ToInt32(partsVersion[0]), Convert.ToInt32(partsVersion[1]));
          if ( version.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) <= 0 )
          {
            if ( !auto )
              DisplayManager.Show(Globals.NoNewVersionAvailable.GetLang());
          }
          else
          if ( DisplayManager.QueryYesNo(Globals.NewVersionAvailable.GetLang(version) + Environment.NewLine +
                                         Environment.NewLine +
                                         Globals.AskToDownloadNewVersion.GetLang()) )
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

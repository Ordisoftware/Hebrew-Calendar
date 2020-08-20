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
    /// Application mutex to allow only one process instance.
    /// </summary>
    static private Mutex ApplicationMutex;

    /// <summary>
    /// Check if the process is already running.
    /// </summary>
    static public bool CheckApplicationOnlyOneInstance()
    {
      try
      {
        bool created;
        ApplicationMutex = new Mutex(true, Globals.AssemblyGUID, out created);
        return created;
      }
      catch ( Exception ex )
      {
        ex.Manage();
        return false;
      }
    }

    /// <summary>
    /// Check is application's settings must be upgraded and apply it if necessary.
    /// </summary>
    static public void CheckSettingsUpgrade(ApplicationSettingsBase settings, ref bool upgradeRequired)
    {
      try
      {
        if ( upgradeRequired )
        {
          settings.Upgrade();
          upgradeRequired = false;
          settings.Save();
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Check command line arguments and apply them.
    /// </summary>
    static public void CheckCommandLineArguments(string[] args, ref string language)
    {
      try
      {
        CommandLineArguments = args;
        if ( args.Length == 2 && args[0] == "/lang" )
          if ( args[1] == "en" || args[1] == "fr" )
            language = args[1];
        if ( language == "" )
          language = Localizer.Language;
      }
      catch ( Exception ex )
      {
        ex.Manage();
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
      try
      {
        foreach ( Control control in controls )
        {
          if ( control is Label )
            resources.ApplyResources(control, control.Name);
          ApplyResources(resources, control.Controls);
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    // https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
    public static string FormatBytesSize(this long bytes)
    {
      var unit = 1024;
      if ( bytes < unit ) return $"{bytes} B";
      var exp = (int)( Math.Log(bytes) / Math.Log(unit) );
      return $"{bytes / Math.Pow(unit, exp):F2} {( "KMGTPE" )[exp - 1]}B";
    }

    /// <summary>
    /// Center a form beside the main form.
    /// </summary>
    /// <param name="form">The form.</param>
    static public void CenterToMainForm(this Form form)
    {
      if ( Globals.MainForm == null ) return;
      form.Location = new Point(Globals.MainForm.Left + Globals.MainForm.Width / 2 - form.Width / 2,
                                Globals.MainForm.Top + Globals.MainForm.Height / 2 - form.Height / 2);
    }

    /// <summary>
    /// Start a process
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <param name="arguments">The comamnd line arguments.</param>
    static public Process RunShell(string filename, string arguments = "")
    {
      var process = new Process();
      try
      {
        process.StartInfo.FileName = filename;
        process.StartInfo.Arguments = arguments;
        process.Start();
        return process;
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(ex.Message + Environment.NewLine + Environment.NewLine +
                                 process.StartInfo.FileName);
        return null;
      }
    }

    /// <summary>
    /// Add "http://" to a string if it does not start with http:// or https://.
    /// </summary>
    /// <param name="link">The link.</param>
    /// <returns>
    /// The browsable link.
    /// </returns>
    static public string MakeWebLink(string link)
    {
      if ( !link.StartsWith("http://") && !link.StartsWith("https://") )
        link = "http://" + link;
      return link;
    }


    /// <summary>
    /// Open a web link.
    /// </summary>
    /// <param name="link">The link.</param>
    static public void OpenWebLink(string link)
    {
      RunShell(MakeWebLink(link));
    }

    /// <summary>
    /// Add "mailto:" to a string if it does not start with "mailto:".
    /// </summary>
    /// <param name="link">The link.</param>
    /// <returns>
    /// The openable mail link.
    /// </returns>
    static public string MakeMailLink(string link)
    {
      if ( !link.StartsWith("mailto:") )
        link = "mailto:" + link;
      return link;
    }

    /// <summary>
    /// Open a mail link.
    /// </summary>
    /// <param name="link">The mail address.</param>
    static public void OpenMailLink(string link)
    {
      RunShell(MakeMailLink(link));
    }

    /// <summary>
    /// Open the application home page.
    /// </summary>
    static public void OpenApplicationHome()
    {
      OpenWebLink(Globals.ApplicationHomeURL);
    }

    /// <summary>
    /// Open the author home page.
    /// </summary>
    static public void OpenAuthorHome()
    {
      OpenWebLink(Globals.AuthorHomeURL);
    }

    /// <summary>
    /// Open the author contact page.
    /// </summary>
    static public void OpenContactPage()
    {
      OpenWebLink(Globals.ContactURL);
    }

    /// <summary>
    /// Open GitHub repository page.
    /// </summary>
    static public void OpenGitHupPage()
    {
      OpenWebLink(Globals.GitHubRepositoryURL);
    }

    /// <summary>
    /// Create a GitHub issue.
    /// </summary>
    static public void CreateGitHubIssue(string query = "")
    {
      OpenWebLink(Globals.GitHubCreateIssueURL + query);
    }

    /// <summary>
    /// Check if an update is available online.
    /// </summary>
    /// <param name="checkAtStartup"></param>
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
            OpenWebLink(Globals.DownloadApplicationURL);
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

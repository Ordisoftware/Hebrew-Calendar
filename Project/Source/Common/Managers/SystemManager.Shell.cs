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
/// <edited> 2020-08 </edited>
using System;
using System.Diagnostics;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide SystemManager helper.
  /// </summary>
  static partial class SystemManager
  {

    /// <summary>
    /// Indicate command line arguments.
    /// </summary>
    static public string[] CommandLineArguments { get; private set; }

    /// <summary>
    /// Check command line arguments and apply them.
    /// </summary>
    static public void CheckCommandLineArguments(string[] args, ref string language)
    {
      try
      {
        CommandLineArguments = args;
        if ( args.Length == 2 && args[0] == "/lang" )
          if ( args[1] == Languages.EN || args[1] == Languages.FR )
            language = args[1];
        if ( string.IsNullOrEmpty(language) )
          language = Languages.Current;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    /// <summary>
    /// Start a process.
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
        DisplayManager.ShowError(Localizer.RunSystemManagerError.GetLang(filename, ex.Message));
        return null;
      }
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
      return !link.StartsWith("mailto:") ? "mailto:" + link : link;
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
    /// Add "http://" to a string if it does not start with http:// or https://.
    /// </summary>
    /// <param name="link">The link.</param>
    /// <returns>
    /// The browsable link.
    /// </returns>
    static public string MakeWebLink(string link)
    {
      return !link.StartsWith("http://") && !link.StartsWith("https://") ? link = "http://" + link : link;
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
    /// Open the application home page.
    /// </summary>
    static public void OpenApplicationHome()
    {
      OpenWebLink(Globals.ApplicationHomeURL);
    }

    /// <summary>
    /// Open the application home page.
    /// </summary>
    static public void OpenApplicationReleaseNotes()
    {
      OpenWebLink(string.Format(Globals.ApplicationReleaseNotesURL, Globals.AssemblyVersion));
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

  }

}

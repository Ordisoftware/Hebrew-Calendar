/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-09 </edited>
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide SystemManager helper.
  /// </summary>
  static public partial class SystemManager
  {

    /// <summary>
    /// Indicate command line arguments.
    /// </summary>
    static public string[] CommandLineArguments { get; private set; }

    /// <summary>
    /// Indicate command line commands.
    /// </summary>
    static public readonly NullSafeDictionary<string, NullSafeStringList> CommandLineOptions
      = new NullSafeDictionary<string, NullSafeStringList>();

    /// <summary>
    /// Check command line arguments and apply them.
    /// </summary>
    static public void CheckCommandLineArguments(string[] args, ref Language language)
    {
      try
      {
        CommandLineArguments = args;
        var parts = args.AsMultiSpace().SplitNoEmptyLines("/");
        foreach ( string arg in parts )
        {
          var items = arg.Trim().SplitNoEmptyLines(" ");
          if ( items.Length == 0 ) continue;
          var values = new NullSafeStringList();
          for ( int index = 1; index < items.Length; index++ )
            values.Add(items[index]);
          CommandLineOptions[items[0].ToLower()] = values;
        }
        if ( CommandLineOptions.ContainsKey("lang"))
          foreach (var lang in Languages.Values )
            if ( CommandLineOptions["lang"][0].ToLower() == lang.Key)
              language = lang.Value;
      }
      catch ( Exception ex )
      {
        ex.Manage(ShowExceptionMode.None);
      }
    }

    /// <summary>
    /// Check if a file is an executable.
    /// </summary>
    static public bool CheckIfFileIsExecutable(string filePath)
    {
      try
      {
        var firstTwoBytes = new byte[2];
        using ( var fileStream = File.Open(filePath, FileMode.Open) )
          fileStream.Read(firstTwoBytes, 0, 2);
        return Encoding.UTF8.GetString(firstTwoBytes) == "MZ";
      }
      catch ( Exception ex )
      {
        throw new IOException(SysTranslations.FileAccessError.GetLang(filePath, ex.Message));
      }
    }

    /// <summary>
    /// Start a process.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="arguments">The comamnd line arguments.</param>
    static public Process RunShell(string filePath, string arguments = "")
    {
      var process = new Process();
      try
      {
        process.StartInfo.FileName = filePath;
        process.StartInfo.Arguments = arguments;
        process.Start();
        return process;
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(SysTranslations.RunSystemManagerError.GetLang(filePath, ex.Message));
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
      OpenWebLink(Globals.AuthorContactURL);
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
    ///  Get the SHA-512 checksum of a file.
    /// </summary>
    static public string GetChecksum512(string filePath)
    {
      try
      {
        using ( var stream = File.OpenRead(filePath) )
        using ( var sha = SHA512.Create() )
          return BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", "").ToLower();
      }
      catch ( Exception ex )
      {
        throw new IOException(SysTranslations.FileAccessError.GetLang(filePath), ex);
      }
    }

  }

}

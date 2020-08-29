/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Originally developped for Ordisoftware Core Library.
/// Copyright 2004-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2007-05 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide messages output and messages box.
  /// </summary>
  static public partial class DisplayManager
  {

    /// <summary>
    /// Indicates application title from file version info or executable path.
    /// </summary>
    static public string Title
    {
      get
      {
        return FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileDescription == ""
               ? Path.GetFileNameWithoutExtension(Path.GetFileName(Application.ExecutablePath))
               : FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileDescription;
      }
    }

    /// <summary>
    /// Show a message and wait user action.
    /// </summary>
    /// <returns>
    /// A DialogResult.
    /// </returns>
    /// <param name="text">The text.</param>
    /// <param name="buttons">The buttons.</param>
    /// <param name="icon">The icon.</param>
    static public DialogResult Show(string text,
                                    MessageBoxButtons buttons = MessageBoxButtons.OK,
                                    MessageBoxIcon icon = MessageBoxIcon.None)
    {
      return Show(Title, text, buttons, icon);
    }

    /// <summary>
    /// Show a message and wait user action.
    /// </summary>
    /// <returns>
    /// A DialogResult.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    /// <param name="buttons">The buttons.</param>
    /// <param name="icon">The icon.</param>
    static public DialogResult Show(string title, 
                                    string text,
                                    MessageBoxButtons buttons = MessageBoxButtons.OK,
                                    MessageBoxIcon icon = MessageBoxIcon.None)
    {
      DialogResult res = DialogResult.None;
      try
      {
        res = ShowWinForm(title, text, buttons, icon);
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
      return res;
    }

    /// <summary>
    /// Show a message box and wait user action.
    /// </summary>
    /// <returns>
    /// A DialogResult.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    /// <param name="buttons">The buttons.</param>
    /// <param name="icon">The icon.</param>
    static private DialogResult ShowWinForm(string title, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
      return MessageBox.Show(text, title, buttons, icon);
    }

    /// <summary>
    /// Show an information box.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowInfo(string text)
    {
      ShowInfo(Title, text);
    }

    /// <summary>
    /// Show an information box.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowInfo(string title, string text)
    {
      Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Show an advertising box.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowAdvert(string text)
    {
      ShowAdvert(Title, text);
    }

    /// <summary>
    /// Show an advertising box.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowAdvert(string title, string text)
    {
      Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    /// <summary>
    /// Show an error message.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowError(string text)
    {
      ShowError(Title, text);
    }

    /// <summary>
    /// Show an error message.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowError(string title, string text)
    {
      Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Show an warning message.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowWarning(string text)
    {
      ShowWarning(Title, text);
    }

    /// <summary>
    /// Show an warning message.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowWarning(string title, string text)
    {
      Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    /// <summary>
    /// Show an error message and throw an AbortException.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowAndAbort(string text)
    {
      ShowAndAbort(Title, text);
    }

    /// <summary>
    /// Show an error message and throw an AbortException.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowAndAbort(string title, string text)
    {
      ShowError(title, text);
      throw new AbortException();
    }

    /// <summary>
    /// Show an error message and terminate process.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowAndTerminate(string text)
    {
      ShowAndTerminate(Title, text);
    }

    /// <summary>
    /// Show an error message and terminate process.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowAndTerminate(string title, string text)
    {
      ShowError(title, text);
      Application.Exit();
    }

  }

}

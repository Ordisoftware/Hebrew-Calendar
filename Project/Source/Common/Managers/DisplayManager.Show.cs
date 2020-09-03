/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Originally developped for Ordisoftware Core Library.
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
/// <created> 2007-05 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide messages and questions with waiting user communication feedback.
  /// </summary>
  static public partial class DisplayManager
  {

    static public bool IconInformationAsNone = false;

    /// <summary>
    /// Indicates application title initialized from file version info or executable path.
    /// </summary>
    static public string Title
    {
      get
      {
        if ( string.IsNullOrEmpty(_Title) )
        {
          _Title = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileDescription;
          if ( string.IsNullOrEmpty(_Title) )
            _Title = Path.GetFileNameWithoutExtension(Path.GetFileName(Application.ExecutablePath));
        }
        return _Title;
      }
      set
      {
        _Title = value;
      }
    }
    static public string _Title;

    /// <summary>
    /// Show a message.
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
    /// Show a message.
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
      SystemManager.TryCatchManage(() => { res = ShowWinForm(title, text, buttons, icon); });
      return res;
    }

    /// <summary>
    /// Show an information message.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowInformation(string text)
    {
      ShowInformation(Title, text);
    }

    /// <summary>
    /// Show an information message.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowInformation(string title, string text)
    {
      var icon = IconInformationAsNone ? MessageBoxIcon.None : MessageBoxIcon.Information;
      Show(title, text, MessageBoxButtons.OK, icon);
    }

    /// <summary>
    /// Show a warning message.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowWarning(string text)
    {
      ShowWarning(Title, text);
    }

    /// <summary>
    /// Show a warning message.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowWarning(string title, string text)
    {
      Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    /// Show an error message and exit the process.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowAndExit(string text)
    {
      ShowAndExit(Title, text);
    }

    /// <summary>
    /// Show an error message and exit the process.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowAndExit(string title, string text)
    {
      ShowError(title, text);
      SystemManager.Exit();
    }

    /// <summary>
    /// Show an error message and terminate the process.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowAndTerminate(string text)
    {
      ShowAndTerminate(Title, text);
    }

    /// <summary>
    /// Show an error message and terminate the process.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public void ShowAndTerminate(string title, string text)
    {
      ShowError(title, text);
      SystemManager.Terminate();
    }

    /// <summary>
    /// Show a windows forms message box.
    /// </summary>
    /// <returns>
    /// A DialogResult.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    /// <param name="buttons">The buttons.</param>
    /// <param name="icon">The icon.</param>
    static private DialogResult ShowWinForm(string title,
                                            string text,
                                            MessageBoxButtons buttons,
                                            MessageBoxIcon icon)
    {
      return MessageBox.Show(text, title, buttons, icon);
    }

  }

}

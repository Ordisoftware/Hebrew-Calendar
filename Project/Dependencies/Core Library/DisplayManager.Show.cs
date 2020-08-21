/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This program is free software: you can redistribute it and/or modify it under the terms of
/// the GNU Lesser General Public License (LGPL v3) as published by the Free Software Foundation,
/// either version 3 of the License, or (at your option) any later version.
/// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
/// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
/// See the GNU Lesser General Public License for more details.
/// You should have received a copy of the GNU General Public License along with this program.
/// If not, see www.gnu.org/licenses website.
/// </license>
/// <created> 2007-05 </created>
/// <edited> 2012-10 </edited>
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.Core
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
    static public DialogResult Show(string text)
    {
      return Show(Title, text,
                  MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    /// <summary>
    /// Show a message and wait user action.
    /// </summary>
    /// <returns>
    /// A DialogResult.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="text">The text.</param>
    static public DialogResult Show(string title, string text)
    {
      return Show(title, text,
                  MessageBoxButtons.OK, MessageBoxIcon.None);
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
    static public DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
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
    static public DialogResult Show(string title, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
      DialogResult res = DialogResult.None;
      try
      {
        res = ShowWinForm(title, text, buttons, icon);
      }
      catch ( Exception except )
      {
        except.Manage();
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
    /// Show an information box.
    /// </summary>
    /// <param name="text">The text.</param>
    static public void ShowInfo(string text)
    {
      Show(Title, text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

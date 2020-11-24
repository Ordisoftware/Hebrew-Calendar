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
/// <created> 2007-05 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Media;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide MessageBoxForm style enum.
  /// </summary>
  public enum MessageBoxFormStyle
  {

    /// <summary>
    /// Use standard Windows MessageBox class.
    /// </summary>
    System,

    /// <summary>
    /// Use custom form.
    /// </summary>
    Advanced

  }

  /// <summary>
  /// Provide MessageBoxForm icon enum.
  /// </summary>
  public enum MessageBoxIconStyle
  {

    /// <summary>
    /// Use system settings.
    /// </summary>
    System,

    /// <summary>
    /// Force none icon as information.
    /// </summary>
    ForceNone,

    /// <summary>
    /// Force information and question icon as none.
    /// </summary>
    ForceInformation,

  }

  /// <summary>
  /// Provide messages and questions with waiting user communication feedback.
  /// </summary>
  static public partial class DisplayManager
  {

    static public bool AdvancedFormUseSounds = true;
    static public bool ShowSuccessDialogs = true;
    static public MessageBoxFormStyle FormStyle = MessageBoxFormStyle.Advanced;
    static public MessageBoxIconStyle IconStyle = MessageBoxIconStyle.ForceInformation;

    /// <summary>
    /// Indicates application title initialized from file version info or executable path.
    /// </summary>
    static public string Title
    {
      get
      {
        if ( _Title.IsNullOrEmpty() )
        {
          _Title = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileDescription;
          if ( _Title.IsNullOrEmpty() )
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
    /// Play the sound associated to a message box icon.
    /// </summary>
    /// <param name="icon"></param>
    static public void DoSound(MessageBoxIcon icon)
    {
      if ( !AdvancedFormUseSounds ) return;
      switch ( icon )
      {
        case MessageBoxIcon.Information:
          SystemSounds.Beep.Play();
          break;
        case MessageBoxIcon.Question:
          SystemSounds.Hand.Play();
          break;
        case MessageBoxIcon.Warning:
          SystemSounds.Exclamation.Play();
          break;
        case MessageBoxIcon.Error:
          SystemSounds.Hand.Play();
          break;
      }
    }

    /// <summary>
    /// Play the sound associated to a file.
    /// </summary>
    /// <param name="icon"></param>
    static public void DoSound(string filePath)
    {
      new SoundPlayer(filePath).Play();
    }

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
      if ( icon == MessageBoxIcon.None
        && IconStyle == MessageBoxIconStyle.ForceInformation )
        icon = MessageBoxIcon.Information;
      else
      if ( ( icon == MessageBoxIcon.Information || icon == MessageBoxIcon.Question )
        && IconStyle == MessageBoxIconStyle.ForceNone )
        icon = MessageBoxIcon.None;
      DialogResult res = DialogResult.None;
      SystemManager.TryCatchManage(() =>
      {
        switch ( FormStyle )
        {
          case MessageBoxFormStyle.System:
            res = ShowWinForm(title, text, buttons, icon);
            break;
          case MessageBoxFormStyle.Advanced:
            res = ShowAdvancedForm(title, text, buttons, icon);
            break;
        }
      });
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
      Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      DebugManager.Trace(LogTraceEvent.Error, text);
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

    static private DialogResult ShowAdvancedForm(string title,
                                                 string text,
                                                 MessageBoxButtons buttons,
                                                 MessageBoxIcon icon)
    {
      return new MessageBoxEx(title, text, MessageBoxEx.DefaultSmallWidth, buttons, icon).ShowDialog();
    }

  }

}

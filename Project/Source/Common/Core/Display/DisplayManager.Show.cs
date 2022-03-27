/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides messages and questions with waiting user communication feedback as well as UI sync.
/// </summary>
static partial class DisplayManager
{

  static public bool DoubleBufferingEnabled { get; set; }

  static public bool AdvancedFormUseSounds { get; set; } = true;

  static public bool ShowSuccessDialogs { get; set; } = true;

  static public MessageBoxFormStyle FormStyle { get; set; } = MessageBoxFormStyle.Advanced;

  static public MessageBoxIconStyle IconStyle { get; set; } = MessageBoxIconStyle.ForceInformation;

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
    set => _Title = value;
  }
  static private string _Title;

  /// <summary>
  /// Plays the sound associated to a message box icon.
  /// </summary>
  static public void DoSound(MessageBoxIcon icon)
  {
    if ( !AdvancedFormUseSounds ) return;
    switch ( icon )
    {
      case MessageBoxIcon.Information:
        SystemSounds.Beep.Play();
        break;
      case MessageBoxIcon.Warning:
        SystemSounds.Exclamation.Play();
        break;
      case MessageBoxIcon.Question:
      case MessageBoxIcon.Error:
        SystemSounds.Hand.Play();
        break;
      default:
        // NOP
        break;
    }
  }

  /// <summary>
  /// Plays the sound associated to a file.
  /// </summary>
  static public void DoSound(string pathSound)
  {
    using var sound = new SoundPlayer(pathSound);
    sound.Play();
  }

  /// <summary>
  /// Shows a success message or play a sound else do nothing.
  /// </summary>
  static public void ShowSuccessOrSound(string text, string pathSound)
  {
    if ( ShowSuccessDialogs )
      Show(text);
    else
    if ( AdvancedFormUseSounds )
      DoSound(pathSound);
  }

  /// <summary>
  /// Shows a message.
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
  /// Shows a message.
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
    var res = DialogResult.None;
    SystemManager.TryCatchManage(() =>
    {
      res = FormStyle switch
      {
        MessageBoxFormStyle.System => ShowWinForm(title, text, buttons, icon),
        MessageBoxFormStyle.Advanced => ShowAdvancedForm(title, text, buttons, icon),
        _ => throw new AdvancedNotImplementedException(FormStyle),
      };
    });
    return res;
  }

  /// <summary>
  /// Shows an information message.
  /// </summary>
  /// <param name="text">The text.</param>
  static public void ShowInformation(string text)
  {
    ShowInformation(Title, text);
  }

  /// <summary>
  /// Shows an information message.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="text">The text.</param>
  static public void ShowInformation(string title, string text)
  {
    Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Information);
  }

  /// <summary>
  /// Shows a warning message.
  /// </summary>
  /// <param name="text">The text.</param>
  static public void ShowWarning(string text)
  {
    ShowWarning(Title, text);
  }

  /// <summary>
  /// Shows a warning message.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="text">The text.</param>
  static public void ShowWarning(string title, string text)
  {
    Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
  }

  /// <summary>
  /// Shows an error message.
  /// </summary>
  /// <param name="text">The text.</param>
  static public void ShowError(string text)
  {
    ShowError(Title, text);
  }

  /// <summary>
  /// Shows an error message.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="text">The text.</param>
  static public void ShowError(string title, string text)
  {
    Show(title, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
    DebugManager.Trace(LogTraceEvent.Error, text);
  }

  /// <summary>
  /// Shows an error message and throw an AbortException.
  /// </summary>
  /// <param name="text">The text.</param>
  static public void ShowAndAbort(string text)
  {
    ShowAndAbort(Title, text);
  }

  /// <summary>
  /// Shows an error message and throw an AbortException.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="text">The text.</param>
  static public void ShowAndAbort(string title, string text)
  {
    ShowError(title, text);
    throw new AbortException();
  }

  /// <summary>
  /// Shows an error message and exit the process.
  /// </summary>
  /// <param name="text">The text.</param>
  static public void ShowAndExit(string text)
  {
    ShowAndExit(Title, text);
  }

  /// <summary>
  /// Shows an error message and exit the process.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="text">The text.</param>
  static public void ShowAndExit(string title, string text)
  {
    ShowError(title, text);
    SystemManager.Exit();
  }

  /// <summary>
  /// Shows an error message and terminate the process.
  /// </summary>
  /// <param name="text">The text.</param>
  static public void ShowAndTerminate(string text)
  {
    ShowAndTerminate(Title, text);
  }

  /// <summary>
  /// Shows an error message and terminate the process.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="text">The text.</param>
  static public void ShowAndTerminate(string title, string text)
  {
    ShowError(title, text);
    SystemManager.Terminate();
  }

  /// <summary>
  /// Shows a windows forms message box.
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
    using var form = new MessageBoxEx(title, text, buttons, icon);
    return form.ShowDialog();
  }

}

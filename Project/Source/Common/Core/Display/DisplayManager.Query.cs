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
/// <created> 2010-11 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides messages and questions with waiting user communication feedback as well as UI sync.
/// </summary>
[SuppressMessage("Design", "GCop135:{0}", Justification = "<En attente>")]
static partial class DisplayManager
{

  /// <summary>
  /// Shows a question and return true if Yes.
  /// </summary>
  /// <returns>
  /// true if it succeeds, false if it fails.
  /// </returns>
  /// <param name="caption">The caption.</param>
  /// <param name="onYes">The on Yes button selected action.</param>
  /// <param name="onNo">The on No button selected action.</param>
  static public bool QueryYesNo(string caption, Action onYes = null, Action onNo = null)
  {
    return QueryYesNo(Title, caption, onYes, onNo);
  }

  /// <summary>
  /// Shows a question and return true if Yes.
  /// </summary>
  /// <returns>
  /// true if it succeeds, false if it fails.
  /// </returns>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="onYes">The on Yes button selected action.</param>
  /// <param name="onNo">The on No button selected action.</param>
  static public bool QueryYesNo(string title, string caption, Action onYes = null, Action onNo = null)
  {
    switch ( Show(title, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) )
    {
      case DialogResult.Yes:
        onYes?.Invoke();
        return true;
      case DialogResult.No:
        onNo?.Invoke();
        return false;
      default:
        return false;
    }
  }

  /// <summary>
  /// Shows a question.
  /// </summary>
  /// <param name="caption">The caption.</param>
  /// <param name="onYes">The on Yes button selected action.</param>
  /// <param name="onNo">The on No button selected action.</param>
  /// <param name="onCancel">The on Cancel button selected action.</param>
  static public DialogResult QueryYesNoCancel(string caption, Action onYes = null, Action onNo = null, Action onCancel = null)
  {
    return QueryYesNoCancel(Title, caption, onYes, onNo, onCancel);
  }


  /// <summary>
  /// Shows a question.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="onYes">The on Yes button selected action.</param>
  /// <param name="onNo">The on No button selected action.</param>
  /// <param name="onCancel">The on Cancel button selected action.</param>
  static public DialogResult QueryYesNoCancel(string title, string caption, Action onYes = null, Action onNo = null, Action onCancel = null)
  {
    var result = Show(title, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    switch ( result )
    {
      case DialogResult.Yes:
        onYes?.Invoke();
        break;
      case DialogResult.No:
        onNo?.Invoke();
        break;
      case DialogResult.Cancel:
        onCancel?.Invoke();
        break;
    }
    return result;
  }

  /// <summary>
  /// Shows a question.
  /// </summary>
  /// <param name="caption">The caption.</param>
  /// <param name="onYes">The on Yes button selected action.</param>
  /// <param name="onNo">The on No button selected action.</param>
  /// <param name="onAbort">The on Abort button selected action.</param>
  static public DialogResult QueryYesNoAbort(string caption, Action onYes = null, Action onNo = null, Action onAbort = null)
  {
    return QueryYesNoAbort(Title, caption, onYes, onNo, onAbort);
  }

  /// <summary>
  /// Shows a question.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="onYes">The on Yes button selected action.</param>
  /// <param name="onNo">The on No button selected action.</param>
  /// <param name="onAbort">The on Abort button selected action.</param>
  static public DialogResult QueryYesNoAbort(string title, string caption, Action onYes = null, Action onNo = null, Action onAbort = null)
  {
    using var form = new MessageBoxEx(title, caption, buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
    form.ActionAbort.Visible = true;
    var result = form.ShowDialog();
    switch ( result )
    {
      case DialogResult.Yes:
        onYes?.Invoke();
        break;
      case DialogResult.No:
        onNo?.Invoke();
        break;
      case DialogResult.Abort:
        onAbort?.Invoke();
        break;
    }
    return result;
  }

  /// <summary>
  /// Shows a question and return true if Ok.
  /// </summary>
  /// <returns>
  /// true if it succeeds, false if it fails.
  /// </returns>
  /// <param name="caption">The caption.</param>
  /// <param name="onOk">The on Ok button selected action.</param>
  /// <param name="onCancel">The on Cancel button selected action.</param>
  static public bool QueryOkCancel(string caption, Action onOk = null, Action onCancel = null)
  {
    return QueryOkCancel(Title, caption, onOk, onCancel);
  }

  /// <summary>
  /// Shows a question and return true if Ok.
  /// </summary>
  /// <returns>
  /// true if it succeeds, false if it fails.
  /// </returns>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="onOk">The on Ok button selected action.</param>
  /// <param name="onCancel">The on Cancel button selected action.</param>
  static public bool QueryOkCancel(string title, string caption, Action onOk = null, Action onCancel = null)
  {
    switch ( Show(title, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) )
    {
      case DialogResult.OK:
        onOk?.Invoke();
        return true;
      case DialogResult.Cancel:
        onCancel?.Invoke();
        return false;
      default:
        return false;
    }
  }

  /// <summary>
  /// Shows a question and return true if Retry.
  /// </summary>
  /// <returns>
  /// true if it succeeds, false if it fails.
  /// </returns>
  /// <param name="caption">The caption.</param>
  /// <param name="onRetry">The on Retry button selected action.</param>
  /// <param name="onCancel">The on Cancel button selected action.</param>
  static public bool QueryRetryCancel(string caption, Action onRetry = null, Action onCancel = null)
  {
    return QueryRetryCancel(Title, caption, onRetry, onCancel);
  }

  /// <summary>
  /// Shows a question and return true if Retry.
  /// </summary>
  /// <returns>
  /// true if it succeeds, false if it fails.
  /// </returns>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="onRetry">The on Retry button selected action.</param>
  /// <param name="onCancel">The on Cancel button selected action.</param>
  static public bool QueryRetryCancel(string title, string caption, Action onRetry = null, Action onCancel = null)
  {
    switch ( Show(title, caption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) )
    {
      case DialogResult.Retry:
        onRetry?.Invoke();
        return true;
      case DialogResult.Cancel:
        onCancel?.Invoke();
        return false;
      default:
        return false;
    }
  }

  /// <summary>
  /// Shows a question.
  /// </summary>
  /// <param name="caption">The caption.</param>
  /// <param name="onRetry">The on Retry button selected action.</param>
  /// <param name="onIgnore">The on Ignore button selected action.</param>
  /// <param name="onAbort">The on Abort button selected action.</param>
  static public DialogResult QueryRetryIgnoreAbort(string caption, Action onRetry = null, Action onIgnore = null, Action onAbort = null)
  {
    return QueryRetryIgnoreAbort(Title, caption, onRetry, onIgnore, onAbort);
  }

  /// <summary>
  /// Shows a question.
  /// </summary>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="onRetry">The on Retry button selected action.</param>
  /// <param name="onIgnore">The on Ignore button selected action.</param>
  /// <param name="onAbort">The on Abort button selected action.</param>
  static public DialogResult QueryRetryIgnoreAbort(string title, string caption, Action onRetry = null, Action onIgnore = null, Action onAbort = null)
  {
    var result = Show(title, caption, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
    switch ( result )
    {
      case DialogResult.Retry:
        onRetry?.Invoke();
        break;
      case DialogResult.Ignore:
        onIgnore?.Invoke();
        break;
      case DialogResult.Abort:
        onAbort?.Invoke();
        break;
    }
    return result;
  }

}

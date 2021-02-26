/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide messages and questions with waiting user communication feedback.
  /// </summary>
  static partial class DisplayManager
  {

    /// <summary>
    /// Show a question and return true if Yes.
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
    /// Show a question and return true if Yes.
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
    /// Show a question.
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
    /// Show a question.
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
        default:
          break;
      }
      return result;
    }

    /// <summary>
    /// Show a question and return true if Ok.
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
    /// Show a question and return true if Ok.
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
    /// Show a question and return true if Retry.
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
    /// Show a question and return true if Retry.
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
    /// Show a question.
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
    /// Show a question.
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
        default:
          break;
      }
      return result;
    }

  }

}

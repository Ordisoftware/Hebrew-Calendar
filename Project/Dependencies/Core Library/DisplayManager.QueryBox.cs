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
/// <created> 2010-11 </created>
/// <edited> 2010-11 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide multithreaded messages output and messages box.
  /// </summary>
  static public partial class DisplayManager
  {

    /// <summary>
    /// Show a question message box and return true if Ok.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="caption">The caption.</param>
    static public bool QueryOkCancel(string caption)
    {
      return QueryOkCancel(Title, caption, null, null);
    }

    /// <summary>
    /// Show a question message box and return true if Ok.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    static public bool QueryOkCancel(string title, string caption)
    {
      return QueryOkCancel(title, caption, null, null);
    }

    /// <summary>
    /// Show a question message box and return true if Ok.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="caption">The caption.</param>
    /// <param name="onOk">The on Ok button selected action.</param>
    /// <param name="onCancel">The on Cancel button selected action.</param>
    static public bool QueryOkCancel(string caption,
                                     Action onOk, Action onCancel)
    {
      return QueryOkCancel(Title, caption, onOk, onCancel);
    }

    /// <summary>
    /// Show a question message box and return true if Ok.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="onOk">The on Ok button selected action.</param>
    /// <param name="onCancel">The on Cancel button selected action.</param>
    static public bool QueryOkCancel(string title, string caption,
                                     Action onOk, Action onCancel)
    {
      switch ( Show(title, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) )
      {
        case DialogResult.OK:
          if ( onOk != null ) onOk();
          return true;
        case DialogResult.Cancel:
          if ( onCancel != null ) onCancel();
          return false;
        default:
          return false;
      }
    }

    /// <summary>
    /// Show a question message box and return true if Retry.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="caption">The caption.</param>
    static public bool QueryRetryCancel(string caption)
    {
      return QueryRetryCancel(Title, caption, null, null);
    }

    /// <summary>
    /// Show a question message box and return true if Ok.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    static public bool QueryRetryCancel(string title, string caption)
    {
      return QueryRetryCancel(title, caption, null, null);
    }

    /// <summary>
    /// Show a question message box and return true if Ok.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="caption">The caption.</param>
    /// <param name="onRetry">The on Retry button selected action.</param>
    /// <param name="onCancel">The on Cancel button selected action.</param>
    static public bool QueryRetryCancel(string caption,
                                        Action onRetry, Action onCancel)
    {
      return QueryRetryCancel(Title, caption, onRetry, onCancel);
    }

    /// <summary>
    /// Show a question message box and return true if Ok.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="onRetry">The on Retry button selected action.</param>
    /// <param name="onCancel">The on Cancel button selected action.</param>
    static public bool QueryRetryCancel(string title, string caption,
                                        Action onRetry, Action onCancel)
    {
      switch ( Show(title, caption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) )
      {
        case DialogResult.Retry:
          if ( onRetry != null ) onRetry();
          return true;
        case DialogResult.Cancel:
          if ( onCancel != null ) onCancel();
          return false;
        default:
          return false;
      }
    }

    /// <summary>
    /// Show a question message box and return true if Yes.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="caption">The caption.</param>
    static public bool QueryYesNo(string caption)
    {
      return QueryYesNo(Title, caption, null, null);
    }

    /// <summary>
    /// Show a question message box and return true if Yes.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    static public bool QueryYesNo(string title, string caption)
    {
      return QueryYesNo(title, caption, null, null);
    }

    /// <summary>
    /// Show a question message box and return true if Yes.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="caption">The caption.</param>
    /// <param name="onYes">The on Yes button selected action.</param>
    /// <param name="onNo">The on No button selected action.</param>
    static public bool QueryYesNo(string caption,
                                  Action onYes, Action onNo)
    {
      return QueryYesNo(Title, caption, onYes, onNo);
    }

    /// <summary>
    /// Show a question message box and return true if Yes.
    /// </summary>
    /// <returns>
    /// true if it succeeds, false if it fails.
    /// </returns>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="onYes">The on Yes button selected action.</param>
    /// <param name="onNo">The on No button selected action.</param>
    static public bool QueryYesNo(string title, string caption,
                                  Action onYes, Action onNo)
    {
      switch ( Show(title, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) )
      {
        case DialogResult.Yes:
          if ( onYes != null ) onYes();
          return true;
        case DialogResult.No:
          if ( onNo != null ) onNo();
          return false;
        default:
          return false;
      }
    }

    /// <summary>
    /// Show a question message box.
    /// </summary>
    /// <param name="caption">The caption.</param>
    /// <param name="onYes">The on Yes button selected action.</param>
    /// <param name="onNo">The on No button selected action.</param>
    /// <param name="onCancel">The on Cancel button selected action.</param>
    static public void QueryYesNoCancel(string caption,
                                        Action onYes, Action onNo, Action onCancel)
    {
      QueryYesNoCancel(Title, caption, onYes, onNo, onCancel);
    }

    /// <summary>
    /// Show a question message box.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="onYes">The on Yes button selected action.</param>
    /// <param name="onNo">The on No button selected action.</param>
    /// <param name="onCancel">The on Cancel button selected action.</param>
    static public void QueryYesNoCancel(string title, string caption,
                                        Action onYes, Action onNo, Action onCancel)
    {
      switch ( Show(title, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) )
      {
        case DialogResult.Yes:
          if ( onYes != null ) onYes();
          break;
        case DialogResult.No:
          if ( onNo != null ) onNo();
          break;
        case DialogResult.Cancel:
          if ( onCancel != null ) onCancel();
          break;
        default:
          break;
      }
    }

    /// <summary>
    /// Show a question message box.
    /// </summary>
    /// <param name="caption">The caption.</param>
    /// <param name="onRetry">The on Retry button selected action.</param>
    /// <param name="onIgnore">The on Ignore button selected action.</param>
    /// <param name="onAbort">The on Abort button selected action.</param>
    static public void QueryRetryIgnoreAbort(string caption,
                                             Action onRetry, Action onIgnore, Action onAbort)
    {
      QueryRetryIgnoreAbort(Title, caption, onRetry, onIgnore, onAbort);
    }

    /// <summary>
    /// Show a question message box.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="onRetry">The on Retry button selected action.</param>
    /// <param name="onIgnore">The on Ignore button selected action.</param>
    /// <param name="onAbort">The on Abort button selected action.</param>
    static public void QueryRetryIgnoreAbort(string title, string caption,
                                             Action onRetry, Action onIgnore, Action onAbort)
    {
      switch ( Show(title, caption, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question) )
      {
        case DialogResult.Retry:
          if ( onRetry != null ) onRetry();
          break;
        case DialogResult.Ignore:
          if ( onIgnore != null ) onIgnore();
          break;
        case DialogResult.Abort:
          if ( onAbort != null ) onAbort();
          break;
        default:
          break;
      }
    }


  }

}

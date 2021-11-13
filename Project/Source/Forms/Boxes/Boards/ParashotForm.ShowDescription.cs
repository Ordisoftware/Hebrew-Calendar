﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar and Words.
/// Copyright 2012-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2021-08 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;
using MainForm = Ordisoftware.Hebrew.Calendar.MainForm;

namespace Ordisoftware.Hebrew
{

  partial class ParashotForm : Form
  {

    static public bool ShowParashahDescription(Parashah parashah, bool withLinked)
    {
      string title = HebrewTranslations.WeeklyParashah.GetLang();
      var form = (MessageBoxEx)Application.OpenForms.GetAll(f => f.Text.Contains(title)).FirstOrDefault();
      if ( form != null )
      {
        form.Popup();
        return true;
      }
      var linked = withLinked ? parashah.GetLinked(MainForm.UserParashot) : null;
      if ( parashah == null ) return false;
      var message = parashah.ToStringReadable();
      message += Globals.NL2 + linked?.ToStringReadable();
      form = new MessageBoxEx(title, message, width: MessageBoxEx.DefaultWidthMedium)
      {
        StartPosition = FormStartPosition.CenterScreen,
        ForceNoTopMost = true,
        ShowInTaskbar = true,
        AllowClose = true
      };
      // Open board
      form.ActionYes.Visible = true;
      form.ActionYes.Text = SysTranslations.Board.GetLang();
      form.ActionYes.Click += async (_s, _e) =>
      {
        Run(parashah);
        await System.Threading.Tasks.Task.Delay(1000).ConfigureAwait(false);
        Instance.Popup();
      };
      // Open memo
      form.ActionNo.Visible = !parashah.Memo.IsNullOrEmpty() || ( !linked?.Memo.IsNullOrEmpty() ?? false );
      form.ActionNo.Text = SysTranslations.Memo.GetLang();
      form.ActionNo.Click += (_s, _e) =>
      {
        string memo1 = parashah.Memo;
        string memo2 = linked?.Memo ?? "";
        DisplayManager.Show(string.Join(Globals.NL2, memo1, memo2));
      };
      // Copy to clipboard
      form.ActionRetry.Visible = true;
      form.ActionRetry.Text = SysTranslations.ActionCopy.GetLang();
      form.ActionRetry.DialogResult = DialogResult.None;
      form.ActionRetry.Click -= form.ActionClose_Click;
      form.ActionRetry.Click += (_s, _e) =>
      {
        Clipboard.SetText(message);
        DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                          Globals.ClipboardSoundFilePath);
      };
      form.Show();
      return true;
    }

  }

}

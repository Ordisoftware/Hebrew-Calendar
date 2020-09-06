/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2016-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Media;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{
  public partial class MessageBoxEx : Form
  {

    public const int DefaultSmallWidth = 400;
    public const int DefaultMediumWidth = 500;
    public const int DefaultLargeWidth = 600;

    static public readonly List<MessageBoxEx> Instances = new List<MessageBoxEx>();

    static internal void CloseAll()
    {
      Instances.ToList().ForEach(f => f.ForceClose());
    }

    private TranslationsDictionary LocalizedTitle;
    private TranslationsDictionary LocalizedText;
    private MessageBoxIcon IconStyle;
    private int LabelMaxWidth;
    private bool AllowClose;

    private MessageBoxEx()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
    }

    public MessageBoxEx(string title,
                        string text,
                        int width = DefaultSmallWidth,
                        MessageBoxButtons buttons = MessageBoxButtons.OK,
                        MessageBoxIcon icon = MessageBoxIcon.None)
      : this()
    {
      Text = title;
      SetButtons(buttons);
      int labelInitialTop = Label.Top;
      int labelInitialHeight = Label.Height;
      LabelMaxWidth = width - 55;
      if ( icon == MessageBoxIcon.None && DisplayManager.IconStyle == MessageBoxIconStyle.ForceInformation )
        icon = MessageBoxIcon.Information;
      else
      if ( icon == MessageBoxIcon.Information && DisplayManager.IconStyle == MessageBoxIconStyle.ForceNone )
        icon = MessageBoxIcon.Information;
      if ( icon != MessageBoxIcon.None )
      {
        SetIcon(icon);
        Label.Left = Label.Left + Label.Left / 2 + PictureBox.Width;
        Label.Top = Label.Top + (PictureBox.Height - Label.Height) / 2;
        width += PictureBox.Width;
        LabelMaxWidth -= PictureBox.Width + PictureBox.Width / 2;
      }
      else
        Width = width;
      MaximumSize = new Size(width, MaximumSize.Height);
      Label.MaximumSize = new Size(LabelMaxWidth, Label.MaximumSize.Height);
      Label.SetTextJustified(text, LabelMaxWidth);
      if ( Label.Height > labelInitialHeight )
      {
        Label.Top = labelInitialTop;
        Height -= Label.Top - labelInitialTop;
      }
      this.CenterToFormElseMainFormElseScreen(ActiveForm);
      Instances.Add(this);
      IconStyle = icon;
    }

    public MessageBoxEx(TranslationsDictionary title,
                        TranslationsDictionary text,
                        int width = DefaultSmallWidth,
                        MessageBoxButtons buttons = MessageBoxButtons.OK,
                        MessageBoxIcon icon = MessageBoxIcon.None)
      : this(title.GetLang(), text.GetLang(), width, buttons, icon)
    {
      LocalizedTitle = title;
      LocalizedText = text;
    }

    public void RelocalizeText()
    {
      if ( LocalizedTitle != null ) Text = LocalizedTitle.GetLang();
      if ( LocalizedText != null )
      {
        AutoSize = false;
        Label.AutoSize = false;
        Label.Text = "";
        Label.SetTextJustified(LocalizedText.GetLang(), LabelMaxWidth);
        AutoSize = true;
        Label.AutoSize = true;
      }
    }

    internal void ForceClose()
    {
      AllowClose = true;
      Close();
    }

    private void MessageBoxEx_Shown(object sender, EventArgs e)
    {
      TopMost = LoadingForm.Instance.Visible;
      DisplayManager.DoSound(IconStyle);
    }

    private void MessageBoxEx_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( Modal || AllowClose ) return;
      e.Cancel = true;
      Hide();
    }

    private void MessageBoxEx_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instances.Remove(this);
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void SetIcon(MessageBoxIcon icon)
    {
      switch ( icon )
      {
        case MessageBoxIcon.Information:
          PictureBox.Image = SystemIcons.Information;
          break;
        case MessageBoxIcon.Question:
          PictureBox.Image = SystemIcons.Question;
          break;
        case MessageBoxIcon.Warning:
          PictureBox.Image = SystemIcons.Warning;
          break;
        case MessageBoxIcon.Error:
          PictureBox.Image = SystemIcons.Error;
          break;
        default:
          return;
      }
      PictureBox.Visible = true;
    }

    private void SetButtons(MessageBoxButtons buttons)
    {
      switch ( buttons )
      {
        case MessageBoxButtons.OK:
          ActionOK.Visible = true;
          ActiveControl = ActionOK;
          AcceptButton = ActionOK;
          CancelButton = ActionOK;
          break;
        case MessageBoxButtons.OKCancel:
          ActionCancel.Visible = true;
          ActionOK.Visible = true;
          ActiveControl = ActionOK;
          AcceptButton = ActionOK;
          CancelButton = ActionCancel;
          break;
        case MessageBoxButtons.YesNo:
          ActionNo.Visible = true;
          ActionYes.Visible = true;
          ActiveControl = ActionYes;
          AcceptButton = ActionYes;
          CancelButton = ActionNo;
          break;
        case MessageBoxButtons.YesNoCancel:
          ActionCancel.Visible = true;
          ActionNo.Visible = true;
          ActionYes.Visible = true;
          ActiveControl = ActionYes;
          AcceptButton = ActionYes;
          CancelButton = ActionCancel;
          break;
        case MessageBoxButtons.RetryCancel:
          ActionCancel.Visible = true;
          ActionRetry.Visible = true;
          ActiveControl = ActionRetry;
          AcceptButton = ActionRetry;
          CancelButton = ActionCancel;
          break;
        case MessageBoxButtons.AbortRetryIgnore:
          ActionIgnore.Visible = true;
          ActionRetry.Visible = true;
          ActionAbort.Visible = true;
          ActiveControl = ActionRetry;
          AcceptButton = ActionRetry;
          CancelButton = ActionIgnore;
          break;
      }
    }

  }

}

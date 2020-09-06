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
using System.Media;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{
  public partial class MessageBoxEx : Form
  {

    public const int DefaultSmallWidth = 400;
    public const int DefaultMediumWidth = 500;
    public const int DefaultLargeWidth = 600;

    private TranslationsDictionary LocalizedTitle;
    private TranslationsDictionary LocalizedText;

    public MessageBoxEx()
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
      int labelInitiamTop = Label.Top;
      int labelInitiamHeight = Label.Height;
      Text = title;
      bool haveImage = icon != MessageBoxIcon.None;
      int labelMaxWidth = width - 55;
      if ( haveImage )
      {
        switch ( icon )
        {
          case MessageBoxIcon.Information:
            PictureBox.Image = SystemIcons.Information.ToBitmap();
            break;
          case MessageBoxIcon.Question:
            PictureBox.Image = SystemIcons.Question.ToBitmap();
            SystemSounds.Question.Play();
            break;
          case MessageBoxIcon.Warning:
            PictureBox.Image = SystemIcons.Warning.ToBitmap();
            SystemSounds.Exclamation.Play();
            break;
          case MessageBoxIcon.Error:
            SystemSounds.Exclamation.Play();
            PictureBox.Image = SystemIcons.Error.ToBitmap();
            break;
        }
        Label.Left = Label.Left + Label.Left / 2 + PictureBox.Width;
        Label.Top = Label.Top + (PictureBox.Height - Label.Height) / 2;
        PictureBox.Visible = true;
        width += PictureBox.Width;
        labelMaxWidth -= PictureBox.Width + PictureBox.Width / 2;
      }
      else
        Width = width;
      MaximumSize = new Size(width, MaximumSize.Height);
      Label.MaximumSize = new Size(labelMaxWidth, Label.MaximumSize.Height);
      Label.Text = JustifyParagraph(text, Label.Font, labelMaxWidth);
      if ( Label.Height > labelInitiamHeight )
      {
        Label.Top = labelInitiamTop;
        Height -= Label.Top - labelInitiamTop;
      }
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
      var form = ActiveForm;
      this.CenterToFormElseMainFormElseScreen(form);
    }

    public MessageBoxEx(TranslationsDictionary title,
                        TranslationsDictionary text,
                        int width = DefaultSmallWidth,
                        MessageBoxButtons buttons = MessageBoxButtons.OK)
      : this(title.GetLang(), text.GetLang(), width, buttons)
    {
      LocalizedTitle = title;
      LocalizedText = text;
    }

    public void RelocalizeText()
    {
      if ( LocalizedTitle != null ) Text = LocalizedTitle.GetLang();
      if ( LocalizedText != null ) Label.Text = LocalizedText.GetLang();
    }

    private void MessageBoxEx_Shown(object sender, EventArgs e)
    {
      TopMost = Modal;
    }

    private void MessageBoxEx_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( Modal ) return;
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    // https://stackoverflow.com/questions/37155195/how-to-justify-text-in-a-label#47470191
    public string JustifyParagraph(string text, Font font, int ControlWidth)
    {
      string result = string.Empty;
      List<string> ParagraphsList = new List<string>();
      ParagraphsList.AddRange(text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList());

      foreach ( string Paragraph in ParagraphsList )
      {
        string line = string.Empty;
        int ParagraphWidth = TextRenderer.MeasureText(Paragraph, font).Width;

        if ( ParagraphWidth > ControlWidth )
        {
          //Get all paragraph words, add a normal space and calculate when their sum exceeds the constraints
          string[] Words = Paragraph.Split(' ');
          line = Words[0] + (char)32;
          for ( int x = 1; x < Words.Length; x++ )
          {
            string tmpLine = line + ( Words[x] + (char)32 );
            if ( TextRenderer.MeasureText(tmpLine, font).Width > ControlWidth )
            {
              //Max lenght reached. Justify the line and step back
              result += Justify(line.TrimEnd(), font, ControlWidth) + "\r\n";
              line = string.Empty;
              --x;
            }
            else
            {
              //Some capacity still left
              line += ( Words[x] + (char)32 );
            }
          }
          //Adds the remainder if any
          if ( line.Length > 0 )
            result += line + "\r\n";
        }
        else
        {
          result += Paragraph + "\r\n";
        }
      }
      return result.TrimEnd(new[] { '\r', '\n' });
    }

    private string Justify(string text, Font font, int width)
    {
      char SpaceChar = (char)0x200A;
      List<string> WordsList = text.Split((char)32).ToList();
      if ( WordsList.Capacity < 2 )
        return text;

      int NumberOfWords = WordsList.Capacity - 1;
      int WordsWidth = TextRenderer.MeasureText(text.Replace(" ", ""), font).Width;
      int SpaceCharWidth = TextRenderer.MeasureText(WordsList[0] + SpaceChar, font).Width
                         - TextRenderer.MeasureText(WordsList[0], font).Width;

      //Calculate the average spacing between each word minus the last one 
      int AverageSpace = ( ( width - WordsWidth ) / NumberOfWords ) / SpaceCharWidth;
      float AdjustSpace = ( width - ( WordsWidth + ( AverageSpace * NumberOfWords * SpaceCharWidth ) ) );

      //Add spaces to all words
      return ( (Func<string>)( () => {
        string Spaces = "";
        string AdjustedWords = "";

        for ( int h = 0; h < AverageSpace; h++ )
          Spaces += SpaceChar;

        foreach ( string Word in WordsList )
        {
          AdjustedWords += Word + Spaces;
          //Adjust the spacing if there's a reminder
          if ( AdjustSpace > 0 )
          {
            AdjustedWords += SpaceChar;
            AdjustSpace -= SpaceCharWidth;
          }
        }
        return AdjustedWords.TrimEnd();
      } ) )();
    }

  }

}

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
/// <created> 2020-08 </created>
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Core;

public partial class MessageBoxEx : Form
{

  public const bool DefaultJustifyEnabled = true;

  public const int DefaultWidthVerySmall = 300;
  public const int DefaultWidthSmall = 400;
  public const int DefaultWidthSmallMedium = 450;
  public const int DefaultWidthMedium = 500;
  public const int DefaultWidthMediumLarge = 550;
  public const int DefaultWidthLarge = 600;
  public const int DefaultWidthLargeBig = 650;
  public const int DefaultWidthBig = 700;
  public const int DefaultWidthBigHuge = 750;
  public const int DefaultWidthHuge = 800;

  public const int DefaultHeightVerySmall = 250;
  public const int DefaultHeightSmall = 300;
  public const int DefaultHeightMedium = 350;
  public const int DefaultHeightLarge = 400;
  public const int DefaultHeightBig = 450;
  public const int DefaultHeightHuge = 500;
  public const int DefaultHeightVeryHuge = 600;

  private const int WidthDeltaMargin = 55;

  static public readonly List<Type> ForceTopMostExcludedForms = new();

  static public readonly List<MessageBoxEx> Instances = new();

  [SuppressMessage("Performance", "U2U1210:Do not materialize an IEnumerable<T> unnecessarily", Justification = "N/A")]
  static public void CloseAll()
  {
    Instances.ToList().ForEach(f => SystemManager.TryCatch(f.ForceClose));
  }

  static public DialogResult ShowDialogOrSystem(TranslationsDictionary title,
                                                TranslationsDictionary text,
                                                MessageBoxButtons buttons = MessageBoxButtons.OK,
                                                MessageBoxIcon icon = MessageBoxIcon.None,
                                                int width = DefaultWidthSmall,
                                                bool justify = DefaultJustifyEnabled,
                                                bool sound = true)
  {
    switch ( DisplayManager.FormStyle )
    {
      case MessageBoxFormStyle.System:
        return MessageBox.Show(text.GetLang(), title.GetLang(), buttons, icon);
      case MessageBoxFormStyle.Advanced:
        using ( var form = new MessageBoxEx(title, text, buttons, icon, width, justify, sound) )
          return form.ShowDialog();
      default:
        throw new AdvNotImplementedException(DisplayManager.FormStyle);
    }
  }

  private readonly TranslationsDictionary LocalizedTitle;
  private readonly TranslationsDictionary LocalizedText;
  private readonly MessageBoxIcon IconStyle;
  private readonly int LabelMaxWidth;
  private readonly bool Justify;
  public bool AllowClose;

  public bool DoShownSound = true;

  private MessageBoxEx()
  {
    InitializeComponent();
    Icon = Globals.MainForm?.Icon;
  }

  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  public MessageBoxEx(string title,
                      string text,
                      MessageBoxButtons buttons = MessageBoxButtons.OK,
                      MessageBoxIcon icon = MessageBoxIcon.None,
                      int width = DefaultWidthSmall,
                      bool justify = DefaultJustifyEnabled,
                      bool sound = true)
  : this()
  {
    Text = title;
    SetButtons(buttons);
    int labelInitialTop = Label.Top;
    int labelInitialHeight = Label.Height;
    LabelMaxWidth = width - WidthDeltaMargin;
    if ( icon == MessageBoxIcon.None && DisplayManager.IconStyle == MessageBoxIconStyle.ForceInformation )
      icon = MessageBoxIcon.Information;
    else
    if ( icon == MessageBoxIcon.Information && DisplayManager.IconStyle == MessageBoxIconStyle.ForceNone )
      icon = MessageBoxIcon.Information;
    if ( icon != MessageBoxIcon.None )
    {
      SetIcon(icon);
      Label.Left = Label.Left + Label.Left / 2 + PictureBox.Width;
      Label.Top += ( PictureBox.Height - Label.Height ) / 2;
      width += PictureBox.Width;
      LabelMaxWidth -= PictureBox.Width + PictureBox.Width / 2;
    }
    else
      Width = width;
    // This does not work: MinimumSize = new Size(width, MinimumSize.Height);
    MaximumSize = new Size(width, MaximumSize.Height);
    Label.MaximumSize = new Size(LabelMaxWidth, Label.MaximumSize.Height);
    Justify = justify;
    if ( justify )
      Label.SetTextJustified(text, LabelMaxWidth);
    else
      Label.Text = text;
    if ( Label.Height > labelInitialHeight )
    {
      Label.Top = labelInitialTop;
      Height -= Label.Top - labelInitialTop;
    }
    this.CenterToFormElseMainFormElseScreen(ActiveForm);
    Instances.Add(this);
    IconStyle = icon;
    DoShownSound = sound;
  }

  public MessageBoxEx(TranslationsDictionary title,
                      TranslationsDictionary text,
                      MessageBoxButtons buttons = MessageBoxButtons.OK,
                      MessageBoxIcon icon = MessageBoxIcon.None,
                      int width = DefaultWidthSmall,
                      bool justify = DefaultJustifyEnabled,
                      bool sound = true)
  : this(title.GetLang(), text.GetLang(), buttons, icon, width, justify, sound)
  {
    LocalizedTitle = title;
    LocalizedText = text;
  }

  [SuppressMessage("Refactoring", "GCop622:Reverse your IF condition and return. Then move the nested statements to after the IF.", Justification = "Opinion")]
  public void RelocalizeText()
  {
    if ( LocalizedTitle is not null )
      Text = LocalizedTitle.GetLang();
    if ( LocalizedText is not null )
    {
      AutoSize = false;
      Label.AutoSize = false;
      Label.Text = string.Empty;
      if ( Justify )
        Label.SetTextJustified(LocalizedText.GetLang(), LabelMaxWidth);
      else
        Label.Text = LocalizedText.GetLang();
      AutoSize = true;
      Label.AutoSize = true;
    }
  }

  public void ForceClose()
  {
    AllowClose = true;
    Close();
  }

  public bool ForceNoTopMost;
  public bool ForceTopMost;

  private void MessageBoxEx_Shown(object sender, EventArgs e)
  {
    if ( ForceNoTopMost )
      TopMost = false;
    else
    if ( ForceTopMost )
      TopMost = true;
    else
      TopMost = LoadingForm.Instance.Visible
             || Application.OpenForms.GetAll().Any(f => f.Visible
                                                     && f.TopMost
                                                     && !ForceTopMostExcludedForms.Contains(f.GetType()));
    if ( DoShownSound ) DisplayManager.DoSound(IconStyle);
    this.Popup();
    this.ForceBringToFront();
    Refresh();
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

  internal void ActionClose_Click(object sender, EventArgs e)
  {
    if ( sender is Button button && button.DialogResult != DialogResult.None )
      Close();
  }

  public void SetIcon(MessageBoxIcon icon)
  {
    switch ( icon )
    {
      case MessageBoxIcon.Information:
        PictureBox.Image = ShellIcons.Information;
        break;
      case MessageBoxIcon.Question:
        PictureBox.Image = ShellIcons.Question;
        break;
      case MessageBoxIcon.Warning:
        PictureBox.Image = ShellIcons.Warning;
        break;
      case MessageBoxIcon.Error:
        PictureBox.Image = ShellIcons.Error;
        break;
      default:
        return;
    }
    PictureBox.Visible = true;
  }

  public void SetButtons(MessageBoxButtons buttons)
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
      default:
        // NOP
        break;
    }
  }

}

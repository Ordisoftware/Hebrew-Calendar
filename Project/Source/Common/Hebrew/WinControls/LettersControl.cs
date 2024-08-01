/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2012-10 </created>
/// <edited> 2024-08 </edited>
namespace Ordisoftware.Hebrew;

public enum LettersControlFocusSelect
{
  None,
  Keep,
  All
}

/// <summary>
/// Provides view letter details delegate.
/// </summary>
public delegate void ViewLetterDetails(LettersControl sender, string code);

/// <summary>
/// Provides Letters input panel Control.
/// </summary>
[SuppressMessage("Major Bug", "S1244:Floating point numbers should not be tested for equality", Justification = "N/A")]
public partial class LettersControl : UserControl
{

  public const KnownColor DefaultInputBackColor = KnownColor.AliceBlue;
  public const KnownColor DefaultPanelLettersBackColor = KnownColor.LightYellow;
  public const float DefaultFontSizeLetters = 18F;
  public const float DefaultFontSizeValues = 6.5F;
  public const float DefaultFontSizeKeys = 8F;
  public const float DefaultFontSizeInput = 18F;
  public const int DefaultInputMaxLength = 12;
  public const int DefaultMarginSize = 5;

  /// <summary>
  /// Indicates view letter details event.
  /// </summary>
  public event ViewLetterDetails ViewLetterDetails;

  /// <summary>
  /// Indicates Input TextChanged event.
  /// </summary>
  public event EventHandler InputTextChanged
  {
    add { TextBox.TextChanged += value; }
    remove { TextBox.TextChanged -= value; }
  }

  /// <summary>
  /// Indicates the initial word.
  /// </summary>
  public string InitialWord
  {
    get;
    set;
  }

  /// <summary>
  /// Indicates if the bottom panel is visible
  /// </summary>
  [DefaultValue(true)]
  public bool ShowBottomPanel
  {
    get => PanelBottom.Visible;
    set
    {
      if ( PanelBottom.Visible == value ) return;
      PanelBottom.Visible = value;
      Redraw();
    }
  }

  /// <summary>
  /// Indicates if gematria is visible
  /// </summary>
  [DefaultValue(true)]
  public bool ShowGematria
  {
    get => PanelGematria.Visible;
    set => PanelGematria.Visible = value;
  }

  /// <summary>
  /// Indicates Input Text property.
  /// </summary>
  [DefaultValue("")]
  public string InputText
  {
    get => TextBox.Text;
    set => TextBox.Text = value;
  }

  /// <summary>
  /// Indicates Input MaxLength property.
  /// </summary>
  [DefaultValue(DefaultInputMaxLength)]
  public int InputMaxLength
  {
    get => TextBox.MaxLength;
    set => TextBox.MaxLength = value;
  }

  /// <summary>
  /// Indicates the background color of letters panel.
  /// </summary>
  [DefaultValue(typeof(Color), "LightYellow")]
  public Color LettersBackColor
  {
    get => PanelLetters.BackColor;
    set => PanelLetters.BackColor = value;
  }

  /// <summary>
  /// Indicates the background color of input textbox.
  /// </summary>
  [DefaultValue(typeof(Color), "AliceBlue")]
  public Color InputBackColor
  {
    get => TextBox.BackColor;
    set => TextBox.BackColor = value;
  }

  /// <summary>
  /// Indicates hebrew letters font size
  /// </summary>
  [DefaultValue(DefaultFontSizeLetters)]
  public float FontSizeLetters
  {
    get => _FontSizeLetters;
    set
    {
      if ( _FontSizeLetters == value ) return;
      _FontSizeLetters = value;
      Redraw();
    }
  }
  private float _FontSizeLetters = DefaultFontSizeLetters;

  /// <summary>
  /// Indicates values font size.
  /// </summary>
  [DefaultValue(DefaultFontSizeValues)]
  public float FontSizeValues
  {
    get => _FontSizeValues;
    set
    {
      if ( _FontSizeValues == value ) return;
      _FontSizeValues = value;
      Redraw();
    }
  }
  private float _FontSizeValues = DefaultFontSizeValues;

  /// <summary>
  /// Indicates keys font size.
  /// </summary>
  [DefaultValue(DefaultFontSizeKeys)]
  public float FontSizeKeys
  {
    get => _FontSizeKeys;
    set
    {
      if ( _FontSizeKeys == value ) return;
      _FontSizeKeys = value;
      Redraw();
    }
  }
  private float _FontSizeKeys = DefaultFontSizeKeys;

  /// <summary>
  /// Indicates Input font size.
  /// </summary>
  [DefaultValue(DefaultFontSizeInput)]
  public float FontSizeInput
  {
    get => _FontSizeInput;
    set
    {
      if ( _FontSizeInput == value ) return;
      _FontSizeInput = value;
      Redraw();
    }
  }
  private float _FontSizeInput = DefaultFontSizeInput;

  /// <summary>
  /// Indicates if letters values must be shown.
  /// </summary>
  [DefaultValue(true)]
  public bool ShowValues
  {
    get => _ShowValues;
    set
    {
      if ( _ShowValues == value ) return;
      _ShowValues = value;
      Redraw();
    }
  }
  private bool _ShowValues = true;

  /// <summary>
  /// Indicates if letters final values must be shown.
  /// </summary>
  /// <remark>
  /// Final values are shown only if values are shown.
  /// </remark>
  [DefaultValue(true)]
  public bool ShowFinalValues
  {
    get => _ShowFinalValues;
    set
    {
      if ( _ShowFinalValues == value ) return;
      _ShowFinalValues = value;
      Redraw();
    }
  }
  private bool _ShowFinalValues = true;

  /// <summary>
  /// Indicates if keys codes must be shown.
  /// </summary>
  [DefaultValue(true)]
  public bool ShowKeys
  {
    get => _ShowKeys;
    set
    {
      if ( _ShowKeys == value ) return;
      _ShowKeys = value;
      Redraw();
    }
  }
  private bool _ShowKeys = true;

  /// <summary>
  /// Indicates the X margin.
  /// </summary>
  [DefaultValue(DefaultMarginSize)]
  public int MarginX
  {
    get => _MarginX;
    set
    {
      if ( _MarginX == value ) return;
      _MarginX = value;
      Redraw();
    }
  }
  private int _MarginX = DefaultMarginSize;

  /// <summary>
  /// Indicates the hebrew chars are bold or regular.
  /// </summary>
  [DefaultValue(true)]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
  public bool HebrewCharsInBold
  {
    get => _Bold;
    set
    {
      if ( _Bold == value ) return;
      _Bold = value;
      TextBox.Font = new Font(TextBox.Font, _Bold ? FontStyle.Bold : FontStyle.Regular);
      Redraw();
    }
  }
  private bool _Bold = true;

  /// <summary>
  /// Indicates the Y margin.
  /// </summary>
  [DefaultValue(DefaultMarginSize)]
  public int MarginY
  {
    get => _MarginY;
    set
    {
      if ( _MarginY == value ) return;
      _MarginY = value;
      Redraw();
    }
  }
  private int _MarginY = DefaultMarginSize;

  /// <summary>
  /// Indicate if details menu item is visible or not.
  /// </summary>
  public bool ContextMenuDetailsVisible
  {
    get => _ContextMenuDetailsVisible;
    set
    {
      if ( !Globals.IsReady ) return;
      _ContextMenuDetailsVisible = value;
      ActionLetterViewDetails.Visible = value;
      MenuItemSeparator.Visible = value;
    }
  }
  private bool _ContextMenuDetailsVisible;

  /// <summary>
  /// Indicates if an input key is processed.
  /// </summary>
  private bool KeyProcessed;

  /// <summary>
  /// Constructor.
  /// </summary>
  public LettersControl()
  {
    InitializeComponent();
    TextBox.MaxLength = DefaultInputMaxLength;
    TextBox.CaretAfterPaste = CaretPositionAfterPaste.Beginning;
    TextBox.BackColor = Color.FromKnownColor(DefaultInputBackColor);
    PanelLetters.BackColor = Color.FromKnownColor(DefaultPanelLettersBackColor);
  }

  /// <summary>
  /// Control load event.
  /// </summary>
  private void LettersControl_Load(object sender, EventArgs e)
  {
    ActionLetterViewDetails_VisibleChanged(null, null);
    Redraw();
    UpdateControls();
  }

  /// <summary>
  /// Control paint event.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
  private void LettersControl_Paint(object sender, PaintEventArgs e)
  {
    if ( !First ) return;
    First = false;
    TextBox.Font = new Font(TextBox.Font.Name, _FontSizeInput, TextBox.Font.Style);
    Redraw();
  }

  private bool First = true;

  /// <summary>
  /// Control size chenged event.
  /// </summary>
  private void LettersControl_SizeChanged(object sender, EventArgs e)
  {
    Redraw();
  }

  /// <summary>
  /// Focus.
  /// </summary>
  public new void Focus()
  {
    TextBox.Focus();
    TextBox.UpdateMenuItems();
  }

  /// <summary>
  /// Focus and select all.
  /// </summary>
  public void Focus(LettersControlFocusSelect selection)
  {
    Focus();
    switch ( selection )
    {
      case LettersControlFocusSelect.None:
        TextBox.SelectionStart = 0;
        TextBox.SelectionLength = 0;
        break;
      case LettersControlFocusSelect.Keep:
        break;
      case LettersControlFocusSelect.All:
        TextBox.SelectionStart = 0;
        TextBox.SelectionLength = TextBox.TextLength;
        break;
      default:
        throw new AdvNotImplementedException(selection);
    }
  }

  /// <summary>
  /// Input TextChanging event.
  /// </summary>
  [SuppressMessage("Redundancy", "RCS1163:Unused parameter.", Justification = "Event Handler")]
  private void Input_TextChanging(object sender, TextUpdating mode, ref string text)
  {
    text = text.RemoveDiacritics().Replace(" ", string.Empty);
    if ( HebrewAlphabet.ContainsUnicode(text) )
      text = HebrewAlphabet.ToHebrewFont(text);
    text = HebrewAlphabet.UnFinalAll(text);
    text = HebrewAlphabet.OnlyHebrewFont(text);
  }

  /// <summary>
  /// Input KeyPress event.
  /// </summary>
  private void Input_KeyPress(object sender, KeyPressEventArgs e)
  {
    if ( HebrewAlphabet.KeyCodes.Contains(e.KeyChar.ToString())
      && ( TextBox.TextLength < TextBox.MaxLength || TextBox.SelectionLength > 0 ) )
      KeyProcessed = true;
    else
    if ( e.KeyChar != '\b' || TextBox.SelectionStart <= 0 ) // Back Space
      e.KeyChar = '\x0';
  }

  /// <summary>
  /// Input KeyUp event.
  /// </summary>
  private void Input_KeyUp(object sender, KeyEventArgs e)
  {
    if ( KeyProcessed )
    {
      KeyProcessed = false;
      if ( TextBox.SelectionStart > 0 )
      {
        TextBox.SelectionStart--;
      }
    }
  }

  /// <summary>
  /// Button letter icon click event.
  /// </summary>
  private void ButtonLetter_Click(object sender, EventArgs e)
  {
    if ( TextBox.TextLength >= InputMaxLength && TextBox.SelectionLength == 0 )
      DisplayManager.DoSound(MessageBoxIcon.Warning);
    else
    {
      Button button = null;
      if ( sender is Button buttonSender )
        button = buttonSender;
      else
      if ( sender is ToolStripMenuItem menuItem )
        button = (Button)( (ContextMenuStrip)menuItem.Owner ).SourceControl;
      if ( button is not null )
      {
        TextBox.Paste(button.Text);
        TextBox.SelectionStart--;
        TextBox.Refresh();
      }
    }
    TextBox.Focus();
  }

  /// <summary>
  /// Handles the Click event of the ActionLetterAddAtBegin control.
  /// </summary>
  /// <param name="sender">The source of the event.</param>
  /// <param name="e">The event information.</param>
  private void ActionLetterAddAtBegin_Click(object sender, EventArgs e)
  {
    TextBox.SelectionLength = 0;
    TextBox.SelectionStart = TextBox.Text.Length;
    ButtonLetter_Click(sender, e);
  }

  /// <summary>
  /// Handles the Click event of the ActionLetterAddAtEnd control.
  /// </summary>
  /// <param name="sender">The source of the event.</param>
  /// <param name="e">The event information.</param>
  private void ActionLetterAddAtEnd_Click(object sender, EventArgs e)
  {
    TextBox.SelectionLength = 0;
    TextBox.SelectionStart = 0;
    ButtonLetter_Click(sender, e);
  }

  /// <summary>
  /// Handles the Click event of the ActionLetterAddAtCaret control.
  /// </summary>
  /// <param name="sender">The source of the event.</param>
  /// <param name="e">The event information.</param>
  private void ActionLetterAddAtCaret_Click(object sender, EventArgs e)
  {
    ButtonLetter_Click(sender, e);
  }

  /// <summary>
  /// Handles the Click event of the ActionLetterViewDetails control.
  /// </summary>
  /// <param name="sender">The source of the event.</param>
  /// <param name="e">The event information.</param>
  private void ActionLetterViewDetails_Click(object sender, EventArgs e)
  {
    if ( ViewLetterDetails is null ) return;
    ViewLetterDetails(this, (string)ActionLetterViewDetails.Tag);
  }

  /// <summary>
  /// Handles the Opened event of the ContextMenuLetter control.
  /// </summary>
  /// <param name="sender">The source of the event.</param>
  /// <param name="e">The event information.</param>
  private void ContextMenuLetter_Opened(object sender, EventArgs e)
  {
    ActionLetterAddAtStart.Enabled = TextBox.Text.Length < TextBox.MaxLength;
    ActionLetterAddAtEnd.Enabled = ActionLetterAddAtStart.Enabled;
    ActionLetterAddAtCaret.Enabled = ActionLetterAddAtStart.Enabled || TextBox.SelectionLength > 0;
    ActionLetterViewDetails.Enabled = ViewLetterDetails is not null;
    MenuItemSeparator.Enabled = ActionLetterViewDetails.Enabled;
    var letterButton = (Button)( (ContextMenuStrip)( sender ) ).SourceControl;
    string letterName = HebrewAlphabet.TranscriptionFromCodes.GetLang(letterButton.Text);
    ActionLetterViewDetails.Tag = letterButton.Text;
    ActionLetterViewDetails.Text = HebrewTranslations.LetterDetails.GetLang(letterName);
  }

  private void ActionLetterViewDetails_VisibleChanged(object sender, EventArgs e)
  {
    ContextMenuDetailsVisible = ActionLetterViewDetails.Visible;
  }

  private void ActionDelFirst_Click(object sender, EventArgs e)
  {
    if ( TextBox.Text.Length < 1 ) return;
    TextBox.SelectionStart = TextBox.TextLength - 1;
    TextBox.SelectionLength = 1;
    Focus(LettersControlFocusSelect.Keep);
    TextBoxEx.ActionDelete.PerformClick();
  }

  private void ActionDelLast_Click(object sender, EventArgs e)
  {
    if ( TextBox.Text.Length < 1 ) return;
    TextBox.SelectionStart = 0;
    TextBox.SelectionLength = 1;
    Focus(LettersControlFocusSelect.Keep);
    TextBoxEx.ActionDelete.PerformClick();
  }

  public event EventHandler Cleared;

  private void ActionClear_Click(object sender, EventArgs e)
  {
    TextBox.SelectAll();
    TextBox.Paste(string.Empty);
    EditGematriaSimple.Text = string.Empty;
    EditGematriaFull.Text = string.Empty;
    Focus();
    Cleared?.Invoke(this, EventArgs.Empty);
  }

  private void ActionReset_Click(object sender, EventArgs e)
  {
    TextBox.Text = InitialWord;
    Focus(LettersControlFocusSelect.None);
  }

  private void ActionCopyToHebrew_Click(object sender, EventArgs e)
  {
    if ( TextBox.Text.Length == 0 ) return;
    string str = TextBox.Text;
    if ( EditCopyWithFinalLetter.Checked )
      str = HebrewAlphabet.SetFinal(str, true);
    Clipboard.SetText(str);
    DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                      Globals.ClipboardSoundFilePath);
    Focus(LettersControlFocusSelect.All);

  }

  private void ActionCopyToUnicode_Click(object sender, EventArgs e)
  {
    if ( TextBox.Text.Length == 0 ) return;
    string str = TextBox.Text;
    if ( EditCopyWithFinalLetter.Checked )
      str = HebrewAlphabet.SetFinal(str, true);
    Clipboard.SetText(HebrewAlphabet.ToUnicodeChars(str));
    DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(), Globals.ClipboardSoundFilePath);
    Focus(LettersControlFocusSelect.All);

  }

  private void ActionPaste_Click(object sender, EventArgs e)
  {
    Focus(LettersControlFocusSelect.All);
    TextBox.Text = Clipboard.GetText();
  }

  private void ActionSearchOnline_Click(object sender, EventArgs e)
  {
    ContextMenuSearchOnline.Show(ActionSearchOnline, new Point(0, ActionSearchOnline.Height));
  }

  private void LabelClipboardContentType_MouseHover(object sender, EventArgs e)
  {
    ToolTipClipboard.Show(Clipboard.GetText(), LabelClipboardContentType);
  }

  private void EditGematria_TextChanged(object sender, EventArgs e)
  {
    var textbox = sender as TextBox;
    if ( textbox.Text == "0" ) textbox.Text = string.Empty;
  }

  public bool UpdateControls()
  {
    bool enabled = TextBox.Text.Length >= 1;
    ActionReset.Enabled = !InitialWord.IsNullOrEmpty();
    ActionReset.Text = ActionReset.Enabled ? "-" : string.Empty;
    ActionClear.Enabled = enabled;
    ActionDelFirst.Enabled = enabled;
    ActionDelLast.Enabled = enabled;
    ActionReverseWord.Enabled = TextBox.Text.Length >= 2;
    ActionCopyToHebrew.Enabled = enabled;
    ActionCopyToUnicode.Enabled = enabled;
    ActionSearchOnline.Enabled = enabled;
    return enabled;
  }

  internal void CheckClipboardContentType()
  {
    string strContent = Clipboard.GetText();
    ActionPaste.Enabled = !strContent.IsNullOrEmpty();
    if ( ActionPaste.Enabled )
    {
      var strLabel = HebrewAlphabet.IsValidUnicode(strContent)
        ? HebrewTranslations.Unicode.GetLang()
        : HebrewAlphabet.IsValidHebrew(strContent)
          ? HebrewTranslations.Hebrew.GetLang()
          : SysTranslations.Uncertain.GetLang();
      LabelClipboardContentType.Text = $"{strLabel}{Globals.NL}({strContent.Length})";
    }
    else
      LabelClipboardContentType.Text = SysTranslations.UnknownSlot.GetLang().TrimFirstLast().Titleize();
  }

  private void ActionRevertWord_Click(object sender, EventArgs e)
  {
    TextBox.Text = new string(TextBox.Text.Reverse().ToArray());
  }

}

/// <summary>
/// Provides LetterEventArgs.
/// </summary>
public class LetterEventArgs : EventArgs
{
  public string LetterCode { get; }
  public LetterEventArgs(string letterCode) { LetterCode = letterCode; }
}

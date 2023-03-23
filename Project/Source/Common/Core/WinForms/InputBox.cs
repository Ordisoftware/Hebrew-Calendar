/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2009-08 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides input box.
/// </summary>
public sealed partial class InputBox<T> : Form
where T : IConvertible
{

  /// <summary>
  /// The value.
  /// </summary>
  private T Value;

  /// <summary>
  /// The validator.
  /// </summary>
  private Func<T, bool> Validator;

  /// <summary>
  /// Execute.
  /// </summary>
  /// <returns>
  /// An InputValueResult.
  /// </returns>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  static public InputValueResult Run(string title, string caption, ref T value)
  {
    return Run(title, caption, ref value, false, null);
  }

  /// <summary>
  /// Execute.
  /// </summary>
  /// <returns>
  /// An InputValueResult.
  /// </returns>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="ispassword">true to ispassword.</param>
  static public InputValueResult Run(string title, string caption, ref T value, bool ispassword)
  {
    return Run(title, caption, ref value, ispassword, null);
  }

  /// <summary>
  /// Execute.
  /// </summary>
  /// <returns>
  /// An InputValueResult.
  /// </returns>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="isPassword">true to ispassword.</param>
  /// <param name="validator">The validator.</param>
  [SuppressMessage("Style", "GCop408:Flag or switch parameters (bool) should go after all non-optional parameters. If the boolean parameter is not a flag or switch, split the method into two different methods, each doing one thing.", Justification = "Opinion")]
  static public InputValueResult Run(string title, string caption, ref T value, bool isPassword, Func<T, bool> validator)
  {
    using var form = new InputBox<T>();
    form.TextBox.PasswordChar = isPassword ? '*' : '\0';
    int dx = form.TextBox.Width;
    if ( !title.IsNullOrEmpty() ) form.Text = title;
    if ( !caption.IsNullOrEmpty() ) form.Label.Text = caption;
    dx = form.Label.Width - dx;
    if ( dx > 0 ) form.Width = form.Width + dx + 10;
    form.Value = value;
    form.Validator = validator;
    if ( value is not null ) form.TextBox.Text = value.ToString();
    if ( form.ShowDialog() == DialogResult.Cancel ) return InputValueResult.Cancelled;
    if ( value is not null && form.TextBox.Text == value.ToString() ) return InputValueResult.Unchanged;
    value = form.Value;
    return InputValueResult.Modified;
  }

  /// <summary>
  /// Default constructor.
  /// </summary>
  public InputBox()
  {
    InitializeComponent();
  }

  /// <summary>
  /// Event handler. Called by ActionOK for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionOK_Click(object sender, EventArgs e)
  {
    var value = default(T);
    bool isValid = true;
    try
    {
      value = TextBox.Text.ConvertTo<T>();
      if ( Validator is not null )
        isValid = Validator(value);
    }
    catch
    {
      isValid = false;
    }
    if ( !isValid )
    {
      DisplayManager.Show("BadValue");
      DialogResult = DialogResult.None;
    }
    else
    {
      Value = value;
      DialogResult = DialogResult.OK;
      Close();
    }
  }

  /// <summary>
  /// Event handler. Called by ActionCancel for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionCancel_Click(object sender, EventArgs e)
  {
    DialogResult = DialogResult.Cancel;
    Close();
  }

}

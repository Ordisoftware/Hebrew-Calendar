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
/// <created> 2009-08 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide input box.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class InputBox<T> : Form
    where T : IConvertible
  {

    /// <summary>
    /// The value.
    /// </summary>
    internal T Value;

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
    /// <param name="ispassword">true to ispassword.</param>
    /// <param name="validator">The validator.</param>
    static public InputValueResult Run(string title, string caption, ref T value, bool ispassword, Func<T, bool> validator)
    {
      var f = new InputBox<T>();
      f.TextBox.PasswordChar = ispassword ? '*' : '\0';
      int dx = f.TextBox.Width;
      if ( !title.IsNullOrEmpty() ) f.Text = title;
      if ( !caption.IsNullOrEmpty() ) f.Label.Text = caption;
      dx = f.Label.Width - dx;
      if ( dx > 0 ) f.Width = f.Width + dx + 10;
      f.Value = value;
      f.Validator = validator;
      if ( value != null ) f.TextBox.Text = value.ToString();
      if ( f.ShowDialog() == DialogResult.Cancel ) return InputValueResult.Cancelled;
      if ( value != null && f.TextBox.Text == value.ToString() ) return InputValueResult.Unchanged;
      value = f.Value;
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
#pragma warning disable S1854 // Unused assignments should be removed
      T value = default;
#pragma warning restore S1854 // Unused assignments should be removed
      bool b = true;
      try
      {
        value = TextBox.Text.ConvertTo<T>();
        if ( Validator != null )
          b = Validator(value);
      }
      catch
      {
        b = false;
      }
      if ( !b )
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

}
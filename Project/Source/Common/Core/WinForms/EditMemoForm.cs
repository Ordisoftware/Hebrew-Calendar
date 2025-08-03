/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-03  </created>
/// <edited> 2022-04 </edited>
namespace Ordisoftware.Core;

public sealed partial class EditMemoForm : Form
{

  static public readonly Point LocationZero;
  static public readonly Size SizeZero;

  static public Point LastLocation { get; set; }
  static public Size LastSize { get; set; }

  static public bool Run(string title, string memoCurrent, out string memoNew)
  {
    using var form = new EditMemoForm();
    form.Text += title;
    form.TextBox.Text = memoCurrent;
    form.TextBox.SelectionStart = 0;
    bool changed = form.ShowDialog() == DialogResult.OK;
    memoNew = changed ? form.TextBox.Text.SanitizeAndTrimEmptyLinesAndSpaces() : null;
    return changed;
  }

  public EditMemoForm()
  {
    InitializeComponent();
    Icon = Globals.MainForm.Icon;
  }

  private void EditMemoForm_Load(object sender, EventArgs e)
  {
    if ( LastLocation != LocationZero ) Location = LastLocation;
    if ( LastSize != SizeZero ) Size = LastSize;
  }

  private void EditMemoForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    LastLocation = Location;
    LastSize = Size;
  }

  private void TextBox_SizeChanged(object sender, EventArgs e)
  {
    TextBox.RightMargin = TextBox.ClientSize.Width - 5;
  }

}

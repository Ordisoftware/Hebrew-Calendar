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
/// <created> 2019-10 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

public partial class ComboBoxNavigator : UserControl
{

  private bool Mutex;

  public bool KeepFocus { get; set; } = true;

  public ComboBox ComboBox
  {
    get => _ComboBox;
    set
    {
      if ( _ComboBox == value ) return;
      if ( value is not null )
      {
        _ComboBox = value;
        _ComboBox.VisibleChanged += ComboBox_VisibleChanged;
        _ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
      }
      else
      {
        _ComboBox.VisibleChanged -= ComboBox_VisibleChanged;
        _ComboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
        _ComboBox = null;
      }
    }
  }
  private ComboBox _ComboBox;

  public ComboBox.ObjectCollection Items
  {
    get => _ComboBox.Items;
  }

  public int Count
  {
    get => _ComboBox?.Items.Count ?? -1;
  }

  public int SelectedIndex
  {
    get => _ComboBox?.SelectedIndex ?? -1;
    set { if ( _ComboBox is not null ) _ComboBox.SelectedIndex = value; }
  }

  public object SelectedItem
  {
    get => _ComboBox?.SelectedItem;
    set { if ( _ComboBox is not null ) _ComboBox.SelectedItem = value; }
  }

  public event EventHandler SelectedIndexChanged
  {
    add { if ( _ComboBox is not null ) _ComboBox.SelectedIndexChanged += value; }
    remove { if ( _ComboBox is not null ) _ComboBox.SelectedIndexChanged -= value; }
  }

  public event EventHandler Navigated;

  public ComboBoxNavigator()
  {
    InitializeComponent();
  }

  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  public void Fill(IEnumerable<int> list, int selected = -1)
  {
    if ( _ComboBox is null ) return;
    Mutex = true;
    foreach ( int value in list )
    {
      int index = _ComboBox.Items.Add(value);
      if ( value == selected )
        _ComboBox.SelectedIndex = index;
    }
    if ( _ComboBox.SelectedIndex == -1 )
      if ( _ComboBox.Items.Count > 0 )
        _ComboBox.SelectedIndex = 0;
    Mutex = false;
  }

  public override void Refresh()
  {
    if ( Mutex ) return;
    Mutex = true;
    try
    {
      base.Refresh();
      bool notNull = _ComboBox?.Items.Count > 0;
      ActionFirst.Enabled = notNull && _ComboBox.SelectedIndex > 0;
      ActionPrevious.Enabled = ActionFirst.Enabled;
      ActionLast.Enabled = notNull && _ComboBox.SelectedIndex < _ComboBox.Items.Count - 1;
      ActionNext.Enabled = ActionLast.Enabled;
    }
    finally
    {
      Mutex = false;
    }
  }

  private void ComboBoxNavigator_EnabledChanged(object sender, EventArgs e)
  {
    Refresh();
  }

  private void ComboBox_VisibleChanged(object sender, EventArgs e)
  {
    Refresh();
  }

  private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
  {
    Refresh();
  }

  private void ActionFirst_Click(object sender, EventArgs e)
  {
    _ComboBox.SelectedIndex = 0;
    if ( KeepFocus ) ActiveControl = ActionNext;
    Navigated?.Invoke(sender, e);
  }

  private void ActionPrevious_Click(object sender, EventArgs e)
  {
    if ( _ComboBox.SelectedIndex > 0 ) _ComboBox.SelectedIndex--;
    if ( _ComboBox.SelectedIndex == 0 && KeepFocus ) ActiveControl = ActionNext;
    Navigated?.Invoke(sender, e);
  }

  private void ActionNext_Click(object sender, EventArgs e)
  {
    if ( _ComboBox.SelectedIndex < _ComboBox.Items.Count - 1 ) _ComboBox.SelectedIndex++;
    if ( _ComboBox.SelectedIndex == _ComboBox.Items.Count - 1 && KeepFocus ) ActiveControl = ActionPrevious;
    Navigated?.Invoke(sender, e);
  }

  private void ActionLast_Click(object sender, EventArgs e)
  {
    _ComboBox.SelectedIndex = _ComboBox.Items.Count - 1;
    if ( KeepFocus ) ActiveControl = ActionPrevious;
    Navigated?.Invoke(sender, e);
  }

}

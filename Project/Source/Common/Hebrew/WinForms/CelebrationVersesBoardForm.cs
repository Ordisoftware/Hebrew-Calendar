/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-09 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew;

public partial class CelebrationVersesBoardForm : Form
{

  private const float FontFactor = 1.5f;

  static public CelebrationVersesBoardForm Instance { get; private set; }

  static public void Run(string locationPropertyName, string clientSizePropertyName)
  {
    if ( Instance is null )
      Instance = new CelebrationVersesBoardForm(locationPropertyName, clientSizePropertyName);
    else
    if ( Instance.Visible )
    {
      Instance.Popup();
      return;
    }
    Instance.Show();
    Instance.ForceBringToFront();
  }

  private readonly string LocationPropertyName;
  private readonly string ClientSizePropertyName;

  public CelebrationVersesBoardForm(string locationPropertyName, string clientSizePropertyName)
  {
    InitializeComponent();
    InitializeMenu();
    Icon = Globals.MainForm.Icon;
    ActiveControl = SelectCelebration;
    LocationPropertyName = locationPropertyName;
    ClientSizePropertyName = clientSizePropertyName;
  }

  private void InitializeMenu()
  {
    ActionStudyOnline.InitializeFromProviders(HebrewGlobals.WebProvidersCelebration, (sender, e) =>
    {
      if ( SelectCelebration.SelectedItems.Count <= 0 ) return;
      var menuitem = (ToolStripMenuItem)sender;
      var celebration = (TorahCelebration)SelectCelebration.SelectedItems[0].Tag;
      HebrewTools.OpenCelebrationProvider((string)menuitem.Tag, celebration);
    });
    ActionOpenVerseOnline.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, e) =>
    {
      var menuitem = (ToolStripMenuItem)sender;
      foreach ( ListViewItem item in SelectVerse.SelectedItems )
      {
        var verseitem = (Tuple<TanakBook, string, string>)item.Tag;
        var reference = $"{(int)verseitem.Item1}.{verseitem.Item2}";
        HebrewTools.OpenBibleProvider((string)menuitem.Tag, reference);
        if ( SelectVerse.SelectedItems.Count > 1 )
          Thread.Sleep(1500);
      }
    });
  }

  private void CelebrationVersesBoardForm_Load(object sender, EventArgs e)
  {
    if ( !LocationPropertyName.IsNullOrEmpty() && !ClientSizePropertyName.IsNullOrEmpty() )
    {
      Location = (Point)Globals.Settings[LocationPropertyName];
      ClientSize = (Size)Globals.Settings[ClientSizePropertyName];
    }
    this.CheckLocationOrCenterToMainFormElseScreen();
    var items = Enums.GetValues<TorahCelebration>()
                     .Skip(1)
                     .Select(v => new ListViewItem(HebrewTranslations.TorahCelebrations.GetLang(v)) { Tag = v });
    SelectCelebration.Items.Clear();
    SelectCelebration.Items.AddRange(items.ToArray());
  }

  private void CelebrationVersesBoardForm_Deactivate(object sender, EventArgs e)
  {
    if ( !LocationPropertyName.IsNullOrEmpty() && !ClientSizePropertyName.IsNullOrEmpty() )
    {
      Globals.Settings[LocationPropertyName] = Location;
      Globals.Settings[ClientSizePropertyName] = ClientSize;
    }
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "Analysis error")]
  private void CelebrationVersesBoardForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    Instance = null;
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    if ( SelectVerse.SelectedItems.Count <= 0 ) return;
    var verseitem = (Tuple<TanakBook, string, string>)SelectVerse.SelectedItems[0].Tag;
    var reference = $"{(int)verseitem.Item1}.{verseitem.Item2}";
    HebrewTools.OpenHebrewWordsGoToVerse(reference);
  }

  private void SelectCelebration_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    SelectCelebration.ContextMenuStrip.Show(Cursor.Position);
  }

  private void SelectVerse_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    SelectVerse.ContextMenuStrip.Show(Cursor.Position);
  }

  [SuppressMessage("Design", "GCop135:{0}", Justification = "N/A")]
  private void Lists_KeyDown(object sender, KeyEventArgs e)
  {
    switch ( e.KeyCode )
    {
      case Keys.Left:
        SelectCelebration.Focus();
        e.Handled = true;
        break;
      case Keys.Right:
        SelectVerse.Focus();
        e.Handled = true;
        break;
      case Keys.Enter:
        if ( sender is ListView control && control.FocusedItem is not null )
        {
          int delta = (int)( control.Font.SizeInPoints * FontFactor );
          var pos = control.PointToScreen(control.FocusedItem.Position);
          pos.X += delta;
          pos.Y += delta;
          control.ContextMenuStrip.Show(pos);
          e.Handled = true;
        }
        break;
    }
  }

  private void SelectCelebration_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = HebrewTranslations.TorahCelebrations[(TorahCelebration)e.Value].GetLang();
  }

  private void SelectCelebration_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( SelectCelebration.SelectedItems.Count <= 0 ) return;
    SelectVerse.Items.Clear();
    var collection = TorahCelebrationVerses.Instance.Items[(TorahCelebration)SelectCelebration.SelectedItems[0].Tag];
    if ( collection is null ) return;
    foreach ( var reference in collection )
    {
      var item = SelectVerse.Items.Add(reference.Item1.ToString().Replace('_', ' '));
      item.Tag = reference;
      item.SubItems.Add(reference.Item2);
      item.SubItems.Add(reference.Item3);
    }
    if ( SelectVerse.Items.Count > 0 )
    {
      SelectVerse.Items[0].Focused = true;
      SelectVerse.Items[0].Selected = true;
    }
  }

}

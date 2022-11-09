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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

public partial class CelebrationVersesBoardForm : Form
{

  private const float FontFactor = 1.5f;

  static public CelebrationVersesBoardForm Instance { get; private set; }

  static public void Run(TorahCelebration celebration,
                         string locationPropertyName,
                         string clientSizePropertyName,
                         string openVerseOnlineURL,
                         bool doubleClickOnVerseOpenDefaultReader,
                         Action<bool> doubleClickOnVerseOpenDefaultReaderChanged)
  {
    if ( Instance is null )
      Instance = new CelebrationVersesBoardForm(locationPropertyName,
                                                clientSizePropertyName,
                                                openVerseOnlineURL,
                                                doubleClickOnVerseOpenDefaultReader,
                                                doubleClickOnVerseOpenDefaultReaderChanged);
    else
    if ( Instance.Visible )
    {
      Instance.Popup();
      return;
    }
    Instance.Show();
    Instance.ForceBringToFront();
    Instance.SelectCelebration(celebration);
  }

  private readonly string LocationPropertyName;
  private readonly string ClientSizePropertyName;
  private readonly string OpenVerseOnlineURL;
  private readonly Action<bool> DoubleClickOnVerseOpenDefaultReaderChanged;

  public CelebrationVersesBoardForm(string locationPropertyName,
                                    string clientSizePropertyName,
                                    string openVerseOnlineURL,
                                    bool doubleClickOnVerseOpenDefaultReader,
                                    Action<bool> doubleClickOnVerseOpenDefaultReaderChanged)
  {
    InitializeComponent();
    InitializeMenus();
    Icon = Globals.MainForm.Icon;
    ActiveControl = ListBoxCelebrations;
    LocationPropertyName = locationPropertyName;
    ClientSizePropertyName = clientSizePropertyName;
    OpenVerseOnlineURL = openVerseOnlineURL;
    DoubleClickOnVerseOpenDefaultReaderChanged = doubleClickOnVerseOpenDefaultReaderChanged;
    EditDoubleClickOnVerseOpenDefaultReader.Checked = doubleClickOnVerseOpenDefaultReader;
  }

  private void InitializeMenus()
  {
    ActionStudyOnlineTexts.Initialize(HebrewGlobals.WebProvidersCelebrationTexts, (sender, e) =>
    {
      if ( ListBoxCelebrations.SelectedItems.Count <= 0 ) return;
      var menuitem = (ToolStripMenuItem)sender;
      var celebration = (TorahCelebration)ListBoxCelebrations.SelectedItems[0].Tag;
      HebrewTools.OpenCelebrationProvider((string)menuitem.Tag, celebration);
    });
    ActionStudyOnlineVideos.Initialize(HebrewGlobals.WebProvidersCelebrationVideos, (sender, _) =>
    {
      if ( ListBoxCelebrations.SelectedItems.Count <= 0 ) return;
      var menuitem = (ToolStripMenuItem)sender;
      var celebration = (TorahCelebration)ListBoxCelebrations.SelectedItems[0].Tag;
      HebrewTools.OpenCelebrationProvider((string)menuitem.Tag, celebration);
    });
    ActionOpenVerseOnline.Initialize(HebrewGlobals.WebProvidersBible,
                                     (sender, _) => DoRead((string)( (ToolStripMenuItem)sender ).Tag));
  }

  private void DoRead(string url)
  {
    foreach ( string reference in GetSelectedReferences() )
    {
      HebrewTools.OpenBibleProvider(url, reference);
      if ( ListBoxVerses.SelectedItems.Count > 1 )
        Thread.Sleep(1500);
    }
  }

  private void ActionVerseReadDefault_Click(object sender, EventArgs e)
  {
    DoRead(OpenVerseOnlineURL);
  }

  private IEnumerable<string> GetSelectedReferences()
  {
    foreach ( ListViewItem item in ListBoxVerses.SelectedItems )
    {
      var verseitem = (Tuple<TanakBook, string, string>)item.Tag;
      yield return $"{(int)verseitem.Item1}.{verseitem.Item2}";
    }
  }

  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "N/A")]
  public void SelectCelebration(TorahCelebration celebration)
  {
    if ( ListBoxCelebrations.Items.Count <= 0 ) return;
    if ( celebration != TorahCelebration.None )
    {
      string str = celebration.ToString();
      foreach ( ListViewItem item in ListBoxCelebrations.Items )
        if ( str.StartsWith(( (TorahCelebration)item.Tag ).ToString(), StringComparison.Ordinal) )
        {
          item.Selected = true;
          item.Focused = true;
          break;
        }
    }
    else
    {
      Instance.ListBoxCelebrations.Items[0].Selected = true;
      Instance.ListBoxCelebrations.Items[0].Focused = true;
    }
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
                     .Select(v => new ListViewItem(HebrewTranslations.GetCelebrationDisplayText(v)) { Tag = v });
    ListBoxCelebrations.Items.Clear();
    ListBoxCelebrations.Items.AddRange(items.ToArray());
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

  private void EditDoubleClickOnVerseOpenDefaultReader_CheckedChanged(object sender, EventArgs e)
  {
    DoubleClickOnVerseOpenDefaultReaderChanged?.Invoke(EditDoubleClickOnVerseOpenDefaultReader.Checked);
  }

  private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    if ( ListBoxVerses.SelectedItems.Count <= 0 ) return;
    var verseitem = (Tuple<TanakBook, string, string>)ListBoxVerses.SelectedItems[0].Tag;
    var reference = $"{(int)verseitem.Item1}.{verseitem.Item2}";
    HebrewTools.OpenHebrewWordsGoToVerse(reference);
  }

  private void ListBoxCelebrations_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    ListBoxCelebrations.ContextMenuStrip.Show(Cursor.Position);
  }

  private void ListBoxVerses_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    if ( EditDoubleClickOnVerseOpenDefaultReader.Checked )
      ActionVerseReadDefault.PerformClick();
    else
      ListBoxVerses.ContextMenuStrip.Show(Cursor.Position);
  }

  [SuppressMessage("Design", "GCop135:{0}", Justification = "N/A")]
  private void ListBoxes_KeyDown(object sender, KeyEventArgs e)
  {
    switch ( e.KeyCode )
    {
      case Keys.Left:
        ListBoxCelebrations.Focus();
        e.Handled = true;
        break;
      case Keys.Right:
        ListBoxVerses.Focus();
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

  private void ListBoxCelebrations_Format(object sender, ListControlConvertEventArgs e)
  {
    e.Value = HebrewTranslations.CelebrationsInLatinChars[(TorahCelebration)e.Value].GetLang();
  }

  private void ListBoxCelebrations_SelectedIndexChanged(object sender, EventArgs e)
  {
    if ( ListBoxCelebrations.SelectedItems.Count <= 0 ) return;
    ListBoxVerses.Items.Clear();
    var collection = TorahCelebrationVerses.Instance.Items[(TorahCelebration)ListBoxCelebrations.SelectedItems[0].Tag];
    if ( collection is null ) return;
    foreach ( var reference in collection )
    {
      string bookname = HebrewDatabase.HebrewNamesInUnicode
        ? BookInfos.Unicode[reference.Item1]
        : reference.Item1.ToString().Replace('_', ' ');
      var item = ListBoxVerses.Items.Add(bookname);
      item.Tag = reference;
      item.SubItems.Add(reference.Item2);
      item.SubItems.Add(reference.Item3);
    }
    if ( ListBoxVerses.Items.Count > 0 )
    {
      ListBoxVerses.Items[0].Focused = true;
      ListBoxVerses.Items[0].Selected = true;
    }
  }

}

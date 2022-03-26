/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
namespace Ordisoftware.Hebrew.Calendar;

public partial class CelebrationVersesBoardForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static public CelebrationVersesBoardForm Instance { get; private set; }

  static public void Run(DateTime date)
  {
    Run(ApplicationDatabase.Instance.GetCurrentOrNextCelebration(date)?.TorahEvent ?? TorahCelebrationDay.None);
  }

  static public void Run(TorahCelebrationDay celebration = TorahCelebrationDay.None)
  {
    if ( Instance is null )
      Instance = new CelebrationVersesBoardForm();
    else
    if ( Instance.Visible )
    {
      Instance.Popup();
      Instance.FindCurrentCelebration(celebration);
      return;
    }
    Instance.Show();
    Instance.ForceBringToFront();
    Instance.FindCurrentCelebration(celebration);
  }

  public CelebrationVersesBoardForm()
  {
    InitializeComponent();
    InitializeMenu();
    Icon = MainForm.Instance.Icon;
    ActiveControl = SelectCelebration;
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

  private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    if ( SelectVerse.SelectedItems.Count <= 0 ) return;
    var verseitem = (Tuple<TanakBook, string, string>)SelectVerse.SelectedItems[0].Tag;
    var reference = $"{(int)verseitem.Item1}.{verseitem.Item2}";
    HebrewTools.OpenHebrewWordsGoToVerse(reference, Settings.HebrewWordsExe);
  }

  private void CelebrationVersesBoardForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    PopulateLists();
  }

  private void PopulateLists()
  {
    var items = Enums.GetValues<TorahCelebration>()
                     .Skip(1)
                     .Select(value => new ListViewItem(AppTranslations.TorahCelebrations.GetLang(value)) { Tag = value });
    SelectCelebration.Items.Clear();
    SelectCelebration.Items.AddRange(items.ToArray());
  }

  [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "N/A")]
  private void FindCurrentCelebration(TorahCelebrationDay celebration = TorahCelebrationDay.None)
  {
    if ( SelectCelebration.Items.Count <= 0 ) return;
    if ( celebration == TorahCelebrationDay.None )
    {
      var dateStart = DateTime.Today;
      var days = ApplicationDatabase.Instance.LunisolarDays;
      var day = days.Find(d => d.Date >= dateStart && d.HasTorahEvent && d.TorahEvent != TorahCelebrationDay.NewYearD1);
      if ( day is not null ) celebration = day.TorahEvent;
    }
    if ( celebration == TorahCelebrationDay.NewYearD10 )
      celebration = TorahCelebrationDay.PessahD1;
    if ( celebration != TorahCelebrationDay.None )
    {
      string str = celebration.ToString();
      foreach ( ListViewItem item in SelectCelebration.Items )
        if ( str.StartsWith(( (TorahCelebration)item.Tag ).ToString(), StringComparison.Ordinal) )
        {
          item.Selected = true;
          item.Focused = true;
          break;
        }
    }
    else
    {
      SelectCelebration.Items[0].Selected = true;
      SelectCelebration.Items[0].Focused = true;
    }
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP007:Don't dispose injected", Justification = "N/A")]
  private void CelebrationVersesBoardForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    Instance?.Dispose();
    Instance = null;
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void SelectCelebration_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    SelectCelebration.ContextMenuStrip.Show(Cursor.Position);
  }

  private void SelectVerse_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    SelectVerse.ContextMenuStrip.Show(Cursor.Position);
  }

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
        if ( sender is ListView control )
          if ( control.FocusedItem is not null )
          {
            int delta = (int)( control.Font.SizeInPoints * 1.5 );
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
    e.Value = AppTranslations.TorahCelebrations[(TorahCelebration)e.Value].GetLang();
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

/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-09 </edited>
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EnumsNET;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class CelebrationVersesBoardForm : Form
  {

    static private readonly Properties.Settings Settings = Program.Settings;

    static public CelebrationVersesBoardForm Instance { get; private set; }

    static public void Run()
    {
      if ( Instance == null )
        Instance = new CelebrationVersesBoardForm();
      else
      if ( Instance.Visible )
      {
        Instance.Popup();
        return;
      }
      Instance.Show();
      Instance.ForceBringToFront();
    }

    public CelebrationVersesBoardForm()
    {
      InitializeComponent();
      InitializeMenu();
      Icon = MainForm.Instance.Icon;
      ActiveControl = SelectCelebration;
      PopulateLists();
      if ( Globals.IsDevExecutable )
      {
        ActionImport.Visible = true;
        ActionExport.Visible = true;
      }
    }

    private void PopulateLists()
    {
      var items = Enums.GetValues<TorahCelebration>()
                       .Select(value => new ListViewItem(AppTranslations.TorahCelebrations.GetLang(value)) { Tag = value });
      SelectCelebration.Items.Clear();
      SelectCelebration.Items.AddRange(items.ToArray());
      FindCurrentCelebration();
    }

    private void FindCurrentCelebration()
    {
      if ( SelectCelebration.Items.Count <= 0 ) return;
      var dateStart = DateTime.Today;
      var day = ApplicationDatabase.Instance.LunisolarDays.FirstOrDefault(d => d.Date >= dateStart && d.HasTorahEvent);
      if ( day != null )
      {
        foreach ( ListViewItem item in SelectCelebration.Items )
          if ( ((TorahCelebration)item.Tag).ToString().StartsWith(day.TorahEvent.ToString()) )
          {
            item.Focused = true;
            item.Selected = true;
            break;
          }
      }
      else
      {
        SelectCelebration.Items[0].Focused = true;
        SelectCelebration.Items[0].Selected = true;
      }
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
          var verseitem = (Tuple<Books, string, string>)item.Tag;
          var reference = $"{(int)verseitem.Item1}.{verseitem.Item2}";
          HebrewTools.OpenBibleProvider((string)menuitem.Tag, reference);
          if ( SelectVerse.SelectedItems.Count > 1 )
            System.Threading.Thread.Sleep(1500);
        }
      });
    }

    private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
    {
      if ( SelectVerse.SelectedItems.Count <= 0 ) return;
      var verseitem = (Tuple<Books, string, string>)SelectVerse.SelectedItems[0].Tag;
      var reference = $"{verseitem.Item1}.{verseitem.Item2}";
      HebrewTools.OpenHebrewWordsGoToVerse(reference, Settings.HebrewWordsExe);
    }

    private void CelebrationVersesBoardForm_Load(object sender, EventArgs e)
    {
      this.CheckLocationOrCenterToMainFormElseScreen();
    }

    private void CelebrationVersesBoardForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      Hide();
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Hide();
    }

    private void ActionImport_Click(object sender, EventArgs e)
    {
      TorahCelebrationVerses.Load();
      PopulateLists();
      DisplayManager.Show(SysTranslations.LoadFileSuccess.GetLang(HebrewGlobals.CelebrationVersesFilePath));
    }

    private void ActionExport_Click(object sender, EventArgs e)
    {
      TorahCelebrationVerses.Save();
      DisplayManager.Show(SysTranslations.WriteFileSuccess.GetLang(HebrewGlobals.CelebrationVersesFilePath));
    }

    private void SelectVerse_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      SelectVerse.ContextMenuStrip.Show(Cursor.Position);
    }

    private void Lists_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.KeyCode == Keys.Left )
      {
        SelectCelebration.Focus();
        e.Handled = true;
      }
      else
      if ( e.KeyCode == Keys.Right )
      {
        SelectVerse.Focus();
        e.Handled = true;
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
      var collection = TorahCelebrationVerses.Items[(TorahCelebration)SelectCelebration.SelectedItems[0].Tag];
      foreach ( var reference in collection )
      {
        var item = SelectVerse.Items.Add(reference.Item1.ToString());
        item.Tag = reference;
        item.SubItems.Add(reference.Item2.ToString());
        item.SubItems.Add(reference.Item3.ToString());
      }
      if ( SelectVerse.Items.Count > 0 )
      {
        SelectVerse.Items[0].Focused = true;
        SelectVerse.Items[0].Selected = true;
      }
    }

  }

}

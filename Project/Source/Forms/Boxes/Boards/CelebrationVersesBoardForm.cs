﻿/// <license>
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

    static public void Run(TorahCelebrationDay celebration = TorahCelebrationDay.None)
    {
      if ( Instance == null )
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
      if ( Globals.IsDevExecutable ) // TODO remove code and controls ?
      {
        ActionImport.Visible = true;
        ActionExport.Visible = true;
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
          var verseitem = (Tuple<TanakBook, string, string>)item.Tag;
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
      var verseitem = (Tuple<TanakBook, string, string>)SelectVerse.SelectedItems[0].Tag;
      var reference = $"{verseitem.Item1}.{verseitem.Item2}";
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
                       .Select(value => new ListViewItem(AppTranslations.TorahCelebrations.GetLang(value)) { Tag = value });
      SelectCelebration.Items.Clear();
      SelectCelebration.Items.AddRange(items.ToArray());
    }

    private void FindCurrentCelebration(TorahCelebrationDay celebration = TorahCelebrationDay.None)
    {
      if ( SelectCelebration.Items.Count <= 0 ) return;
      if ( celebration == TorahCelebrationDay.None )
      {
        var dateStart = DateTime.Today;
        var day = ApplicationDatabase.Instance.LunisolarDays.FirstOrDefault(d => d.Date >= dateStart && d.HasTorahEvent);
        if ( day != null ) celebration = day.TorahEvent;
      }
      if ( celebration != TorahCelebrationDay.None )
      {
        foreach ( ListViewItem item in SelectCelebration.Items )
          if ( celebration.ToString().StartsWith(( (TorahCelebration)item.Tag ).ToString()) )
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

    private void CelebrationVersesBoardForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Instance = null;
    }

    private void ActionClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    // TODO remove code and controls ?
    private void ActionImport_Click(object sender, EventArgs e)
    {
      TorahCelebrationVerses.Instance.Load();
      PopulateLists();
      DisplayManager.Show(SysTranslations.LoadFileSuccess.GetLang(HebrewGlobals.CelebrationVersesFilePath));
    }

    // TODO remove code and controls ?
    private void ActionExport_Click(object sender, EventArgs e)
    {
      if ( !DisplayManager.QueryYesNo("Save and overwrite data file?") ) return;
      TorahCelebrationVerses.Instance.Save();
      DisplayManager.Show(SysTranslations.WriteFileSuccess.GetLang(HebrewGlobals.CelebrationVersesFilePath));
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
      var collection = TorahCelebrationVerses.Instance.Items[(TorahCelebration)SelectCelebration.SelectedItems[0].Tag];
      if ( collection == null ) return;
      foreach ( var reference in collection )
      {
        var item = SelectVerse.Items.Add(reference.Item1.ToString().Replace("_", " "));
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

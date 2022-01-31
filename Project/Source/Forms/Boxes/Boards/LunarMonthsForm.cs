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
/// <created> 2020-04 </created>
/// <edited> 2022-01 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class LunarMonthsForm : Form
{

  static private readonly Properties.Settings Settings = Program.Settings;

  static public LunarMonthsForm Instance { get; private set; }

  static LunarMonthsForm()
  {
    Instance = new LunarMonthsForm();
  }

  static public void Run()
  {
    Instance.LunarMonthsForm_Load(null, null);
    MainForm.Instance.Restore();
    Instance.Show();
    Instance.ForceBringToFront();
  }

  private LunarMonthsForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    CreateControls();
    ActiveControl = ActionClose;
    ActionEditFiles.Visible = Program.LunarMonthsMeanings[Languages.Current].Configurable;
    ActionSearchOnline.InitializeFromProviders(HebrewGlobals.WebProvidersWord, (sender, e) =>
    {
      var menuitem = (ToolStripMenuItem)sender;
      string word = HebrewMonths.Unicode[(int)LastControl.Tag]
                                .Replace(" א", string.Empty)
                                .Replace(" ב", string.Empty);
      HebrewTools.OpenWordProvider((string)menuitem.Tag, HebrewAlphabet.ToHebrewFont(word));
    });
    this.InitDropDowns();
  }

  public void Relocalize()
  {
    if ( !Globals.IsReady ) return;
    CreateControls();
  }

  private void LunarMonthsForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
  }

  private void LunarMonthsForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    Hide();
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void ActionSwapColors_Click(object sender, EventArgs e)
  {
    Settings.LunarMonthsFormUseColors = Program.Settings.LunarMonthsFormUseColors.Next();
    SystemManager.TryCatch(Settings.Save);
    CreateControls();
  }

  private void ActionViewNotice_Click(object sender, EventArgs e)
  {
    MessageBoxEx.ShowDialogOrSystem(AppTranslations.NoticeLunarMonthsTitle, AppTranslations.NoticeLunarMonths);
  }

  private void ActionEditFiles_Click(object sender, EventArgs e)
  {
    var list = new List<DataFile>();
    foreach ( var lang in Languages.Managed )
    {
      list.Add(Program.LunarMonthsMeanings[lang]);
      list.Add(Program.LunarMonthsLettriqs[lang]);
    }
    if ( DataFileEditorForm.Run("Moon", list) ) CreateControls();
  }

  private Control LastControl;

  private void Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    LastControl = sender as Control;
    if ( e.Button == MouseButtons.Left )
      ContextMenuItems.Show(LastControl, LastControl.PointToClient(Cursor.Position));
  }

  private void ActionCopyMonthName(object sender, Func<int, string> process)
  {
    var menuitem = (ToolStripMenuItem)sender;
    var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
    int index = (int)control.Tag;
    Clipboard.SetText(process(index));
  }

  private void ActionCopyName_Click(object sender, EventArgs e)
  {
    ActionCopyMonthName(sender, index => HebrewMonths.Transcriptions[index]);
  }

  private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
  {
    ActionCopyMonthName(sender, index => HebrewAlphabet.ToHebrewFont(HebrewMonths.Unicode[index]));
  }

  private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
  {
    ActionCopyMonthName(sender, index => HebrewMonths.Unicode[index]);
  }

  private void ActionCopyLine(object sender, Func<int, string> process)
  {
    var menuitem = (ToolStripMenuItem)sender;
    var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
    int index = (int)control.Tag;
    string name = HebrewMonths.Transcriptions[index];
    string meaning = Program.LunarMonthsMeanings[Languages.Current][index];
    string lettriq = Program.LunarMonthsLettriqs[Languages.Current][index];
    Clipboard.SetText($"{process(index)} ({name}) : {meaning} ({lettriq})");
  }

  private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
  {
    ActionCopyLine(sender, index => HebrewAlphabet.ToHebrewFont(HebrewMonths.Unicode[index]));
  }

  private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
  {
    ActionCopyLine(sender, index => HebrewMonths.Unicode[index]);
  }

  private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
  {
    Program.GrammarGuideForm.Popup();
  }

  private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
  {
    var menuitem = (ToolStripMenuItem)sender;
    var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
    int index = (int)control.Tag;
    HebrewTools.OpenHebrewLetters(HebrewMonths.Unicode[index],
                                  Settings.HebrewLettersExe);
  }

  private void ActionOpenHebrewWordsSearch_Click(object sender, EventArgs e)
  {
    var menuitem = (ToolStripMenuItem)sender;
    var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
    int index = (int)control.Tag;
    HebrewTools.OpenHebrewWordsSearchWord(HebrewAlphabet.ToHebrewFont(HebrewMonths.Unicode[index]),
                                          Settings.HebrewWordsExe);
  }

  private void ActionSearchWikipedia_Click(object sender, EventArgs e)
  {
    var menuitem = (ToolStripMenuItem)sender;
    var control = ( (ContextMenuStrip)menuitem.Owner ).SourceControl;
    int index = (int)control.Tag;
    SystemManager.RunShell(AppTranslations.WikipediaMonths.GetLang()[index]);
  }

}

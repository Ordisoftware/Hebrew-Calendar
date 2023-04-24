/// <license>
/// This file is part of Ordisoftware Hebrew Calendar and Words.
/// Copyright 2012-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2022-09 </edited>
namespace Ordisoftware.Hebrew;

using Program = Calendar.Program;
using Properties = Calendar.Properties;
using MainForm = Calendar.MainForm;
using System.Windows.Forms;

sealed partial class ParashotForm : Form
{

  static public ParashotForm Instance { get; private set; }

  static public ParashotForm Run(Parashah parashah = null)
  {
    if ( Instance is null )
      Instance = new ParashotForm();
    else
    if ( Instance.Visible )
    {
      Instance.Popup();
      Instance.Select(parashah);
      return Instance;
    }
    Instance.ActionGoToNextParashah.Visible = Program.Settings.CalendarShowParashah;
    Instance.Show();
    Instance.ForceBringToFront();
    Instance.Select(parashah);
    return Instance;
  }

  public readonly Properties.Settings Settings
    = Properties.Settings.Default;

  private Parashah CurrentDataBoundItem
    => (Parashah)DataGridView.SelectedRows[0].DataBoundItem;

  private void UpdateStats()
  {
    Calendar.ApplicationStatistics.UpdateDBCommonFileSizeRequired = true;
    Calendar.ApplicationStatistics.UpdateDBParashotMemorySizeRequired = true;
  }

  private ParashotForm()
  {
    InitializeComponent();
    InitializeMenu();
    Icon = Globals.MainForm.Icon;
    DataGridView.Visible = false;
    ActionSaveAsDefaults.Visible = Globals.IsDebugExecutable;
    ActionGoToNextParashah.Visible = Settings.CalendarShowParashah;
    ActionGoToNextParashah.Visible = Settings.CalendarShowParashah;
    SeparatorParashah.Visible = Settings.CalendarShowParashah;
    this.InitDropDowns();
  }

  private void InitializeMenu()
  {
    ActionStudyOnline.Initialize(HebrewGlobals.WebProvidersParashah, (sender, e) =>
    {
      var menuitem = (ToolStripMenuItem)sender;
      var parashah = ParashotFactory.Instance.Get(CurrentDataBoundItem.ID);
      HebrewTools.OpenParashahProvider((string)menuitem.Tag, parashah);
    });
    ActionOpenVerseOnline.Initialize(HebrewGlobals.WebProvidersBible, (sender, e) =>
    {
      var menuitem = (ToolStripMenuItem)sender;
      HebrewTools.OpenBibleProvider((string)menuitem.Tag, CurrentDataBoundItem.FullReferenceBegin);
    });
    ActionSearchOnline.Initialize(HebrewGlobals.WebProvidersWord, (sender, e) =>
    {
      var menuitem = (ToolStripMenuItem)sender;
      HebrewTools.OpenWordProvider((string)menuitem.Tag, CurrentDataBoundItem.Hebrew);
    });
  }

  private void ParashotForm_Load(object sender, EventArgs e)
  {
    MainForm.Instance.Cursor = Cursors.WaitCursor;
    Cursor = Cursors.WaitCursor;
    PanelBottom.Enabled = false;
    bool temp = LoadingForm.Instance.Hidden;
    LoadingForm.Instance.Hidden = false;
    try
    {
      LoadingForm.Instance.Initialize(SysTranslations.LoadingData.GetLang(), 4);
      LoadingForm.Instance.DoProgress();
      MainForm.UserParashot = HebrewDatabase.Instance.TakeParashot();
      LoadingForm.Instance.DoProgress();
      EditFontSize.Value = Settings.ParashotFormFontSize;
      Location = Settings.ParashotFormLocation;
      ClientSize = Settings.ParashotFormClientSize;
      this.CheckLocationOrCenterToMainFormElseScreen();
      WindowState = Settings.ParashotFormWindowState;
      if ( Settings.ParashotFormColumnTranslationWidth != -1 )
        ColumnTranslation.Width = Settings.ParashotFormColumnTranslationWidth;
      LoadingForm.Instance.DoProgress();
      BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
      LoadingForm.Instance.DoProgress();
      UpdateControls();
    }
    finally
    {
      PanelBottom.Enabled = true;
      Cursor = Cursors.Default;
      MainForm.Instance.Cursor = Cursors.Default;
      LoadingForm.Instance.Hidden = temp;
      LoadingForm.Instance.Hide();
    }
  }

  private void ParashotForm_Shown(object sender, EventArgs e)
  {
    DataGridView.Visible = true;
    ActiveControl = DataGridView;
    EditFontSize_ValueChanged(null, null);
  }

  public void Select(Parashah parashah)
  {
    if ( parashah is null ) return;
    foreach ( DataGridViewRow row in DataGridView.Rows )
      if ( ( (Parashah)row.DataBoundItem ).ID == parashah.ID )
      {
        DataGridView.CurrentCell = row.Cells[0];
        DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.SelectedRows[0].Index;
        break;
      }
  }

  private void Timer_Tick(object sender, EventArgs e)
  {
    UpdateControls();
    if ( !Created || DataGridView.ReadOnly ) return;
    ActionUndo.PerformClick();
    MainForm.UserParashot = HebrewDatabase.Instance.TakeParashot(true);
    BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
  }

  private void UpdateControls()
  {
    DataGridView.ReadOnly = HebrewDatabase.Instance.IsParashotReadOnly();
    Timer.Enabled = DataGridView.ReadOnly;
    ActionErase.Enabled = !DataGridView.ReadOnly;
    ActionSaveAsDefaults.Enabled = !DataGridView.ReadOnly;
    ActionExport.Enabled = !DataGridView.ReadOnly;
    ActionReset.Enabled = !DataGridView.ReadOnly;
    ActionCheckLockers.Visible = DataGridView.ReadOnly;
    ActionViewLockers.Visible = DataGridView.ReadOnly;
    LabelTableLocked.Visible = DataGridView.ReadOnly;
  }

  private void ActionViewLockers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    var table = Interlocks.GetLockers(HebrewDatabase.Instance.ParashotTableName);
    string list = table.AsMultiLine().Indent(4);
    string name = HebrewDatabase.Instance.ParashotTableName;
    string msg = SysTranslations.DatabaseTableLocked.GetLang(name, list, Timer.Interval / 1000);
    DisplayManager.Show(msg);
  }

  private void ActionCheckLockers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Timer_Tick(null, null);
  }

  private void ParashotForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    if ( !ActionSave.Enabled ) return;
    if ( Globals.IsExiting )
    {
      this.Popup();
      DisplayManager.QueryYesNo(SysTranslations.AskToSaveChanges.GetLang(Text),
                                ActionSave.PerformClick,
                                ParashotFactory.Instance.Reset);
    }
    else
      DisplayManager.QueryYesNoCancel(SysTranslations.AskToSaveChanges.GetLang(Text),
                                      ActionSave.PerformClick,
                                      ParashotFactory.Instance.Reset,
                                      () => e.Cancel = true);
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "Analysis error")]
  private void ParashotForm_FormClosed(object sender, FormClosedEventArgs e)
  {
    Timer.Stop();
    Instance = null;
    if ( WindowState == FormWindowState.Minimized )
      WindowState = FormWindowState.Normal;
    Settings.ParashotFormWindowState = WindowState;
    if ( WindowState == FormWindowState.Maximized )
      WindowState = FormWindowState.Normal;
    Settings.ParashotFormLocation = Location;
    Settings.ParashotFormClientSize = ClientSize;
    Settings.ParashotFormColumnTranslationWidth = ColumnTranslation.Width;
    Settings.ParashotFormFontSize = EditFontSize.Value;
    SystemManager.TryCatch(Settings.Save);
    BindingSource.DataSource = null;
    MainForm.UserParashot = HebrewDatabase.Instance.Parashot;
    HebrewDatabase.Instance.ReleaseParashot();
    UpdateStats();
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void ActionSaveAsDefaults_Click(object sender, EventArgs e)
  {
    if ( DisplayManager.QueryYesNo("Overwrite default files?") )
    {
      var listTranslations = new NullSafeOfStringDictionary<string>();
      var listLettriqs = new NullSafeOfStringDictionary<string>();
      ActionSave.PerformClick();
      foreach ( DataGridViewRow row in DataGridView.Rows )
      {
        var bookName = row.Cells[ColumnBook.Index].FormattedValue as string;
        if ( !string.IsNullOrEmpty(bookName) )
        {
          bookName = bookName.ToUpper();
          listTranslations.Add("// BOOK " + bookName, string.Empty);
          listLettriqs.Add("// BOOK " + bookName, string.Empty);
        }
        string itemName = (string)row.Cells[ColumnName.Index].Value;
        string itemTranslation = (string)row.Cells[ColumnTranslation.Index].Value;
        string itemLettriq = (string)row.Cells[ColumnLettriq.Index].Value;
        listTranslations.Add(itemName, itemTranslation.Trim());
        listLettriqs.Add(itemName, itemLettriq.Trim());
      }
      listTranslations.SaveKeyValuePairs(HebrewGlobals.ParashotTranslationsFilePath, " = ");
      listLettriqs.SaveKeyValuePairs(HebrewGlobals.ParashotLettriqsFilePath, " = ");
      ParashotFactory.Instance.Reset();
      DisplayManager.Show("Default files updated.");
    }
    ActiveControl = DataGridView;
  }

  private void ActionExport_Click(object sender, EventArgs e)
  {
    ActionSave.PerformClick();
    string name = HebrewDatabase.Instance.ParashotTableName;
    MainForm.Instance.SaveBoardDialog.FileName = SysTranslations.BoardExportFileName.GetLang(name);
    for ( int index = 0; index < Program.BoardExportTargets.Count; index++ )
      if ( Program.BoardExportTargets.ElementAt(index).Key == Settings.ExportDataPreferredTarget )
        MainForm.Instance.SaveBoardDialog.FilterIndex = index + 1;
    if ( MainForm.Instance.SaveBoardDialog.ShowDialog() == DialogResult.OK )
    {
      string filePath = MainForm.Instance.SaveBoardDialog.FileName;
      DoExportTable(filePath);
      DisplayManager.ShowSuccessOrSound(SysTranslations.ViewSavedToFile.GetLang(filePath),
                                        Globals.KeyboardSoundFilePath);
      if ( Settings.AutoOpenExportFolder )
        SystemManager.RunShell(Path.GetDirectoryName(filePath));
      if ( Settings.AutoOpenExportedFile )
        SystemManager.RunShell(filePath);
    }
    ActiveControl = DataGridView;
  }

  private void DoExportTable(string filePath)
  {
    using var table = HebrewDatabase.Instance.Parashot.ToDataTable(HebrewDatabase.Instance.ParashotTableName);
    table.Export(filePath, Program.BoardExportTargets);
  }

  private void ActionReset_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(HebrewTranslations.AskToResetParashot.GetLang()) ) return;
    int index = DataGridView.CurrentRow.Index;
    MainForm.UserParashot = HebrewDatabase.Instance.CreateParashotDataIfNotExistAndLoad(true, false, true);
    BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
    DataGridView.Rows[index].Selected = true;
    DataGridView.FirstDisplayedScrollingRowIndex = index;
    ActionSave.Enabled = false;
    ActionUndo.Enabled = false;
    ActiveControl = DataGridView;
    UpdateStats();
  }

  private void ActionEmpty_Click(object sender, EventArgs e)
  {
    if ( !DisplayManager.QueryYesNo(SysTranslations.AskToClearCustomData.GetLang()) ) return;
    int index = DataGridView.CurrentRow.Index;
    MainForm.UserParashot = HebrewDatabase.Instance.CreateParashotDataIfNotExistAndLoad(true, true);
    BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
    DataGridView.Rows[index].Selected = true;
    DataGridView.FirstDisplayedScrollingRowIndex = index;
    ActionSave.Enabled = false;
    ActionUndo.Enabled = false;
    ActiveControl = DataGridView;
    UpdateStats();
  }

  private void ActionSave_Click(object sender, EventArgs e)
  {
    HebrewDatabase.Instance.SaveParashot();
    ActionSave.Enabled = false;
    ActionUndo.Enabled = false;
    ActiveControl = DataGridView;
    UpdateStats();
  }

  private void ActionUndo_Click(object sender, EventArgs e)
  {
    int index = DataGridView.CurrentRow.Index;
    MainForm.UserParashot = HebrewDatabase.Instance.TakeParashot(true);
    BindingSource.DataSource = HebrewDatabase.Instance.ParashotAsBindingList;
    DataGridView.Rows[index].Selected = true;
    DataGridView.FirstDisplayedScrollingRowIndex = index;
    ActionSave.Enabled = false;
    ActionUndo.Enabled = false;
    ActiveControl = DataGridView;
    UpdateStats();
  }

  private void EditFontSize_ValueChanged(object sender, EventArgs e)
  {
    DataGridView.Font = new Font("Microsoft Sans Serif", (float)EditFontSize.Value);
    ColumnHebrew.DefaultCellStyle.Font = new Font("Hebrew", (float)EditFontSize.Value + 5);
  }

  private void BindingSource_DataSourceChanged(object sender, EventArgs e)
  {
    if ( DataGridView.DataSource is not null && HebrewDatabase.Instance.Parashot is not null )
      UpdateStats();
  }

  private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
  {
    e.Exception.Manage(ShowExceptionMode.None);
    e.ThrowException = false;
  }

  private readonly KeysConverter KeysConverter = new();

  private void DataGridView_KeyDown(object sender, KeyEventArgs e)
  {
    if ( e.Control && e.KeyCode == Keys.S )
      ActionSave.PerformClick();
    else
    if ( e.KeyCode == Keys.F2 || ( e.KeyCode == Keys.Enter && !DataGridView.IsCurrentCellInEditMode ) )
      DataGridView.BeginEdit(false);
    else
    if ( !DataGridView.IsCurrentCellInEditMode && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z )
    {
      EditSearch.Focus();
      EditSearch.AppendText(KeysConverter.ConvertToString(e.KeyValue));
    }
    else
      return;
    e.Handled = true;
    e.SuppressKeyPress = true;
  }

  private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
  {
    if ( !Created ) return;
    if ( !Globals.IsReady ) return;
    if ( e.ColumnIndex == -1 || e.RowIndex == -1 ) return;
    ActionSave.Enabled = true;
    ActionUndo.Enabled = true;
  }

  private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
  {
    if ( e.Value is null ) return;
    if ( e.ColumnIndex == ColumnLinked.Index )
      e.Value = (bool)e.Value ? Globals.Bullet : string.Empty;
    else
    if ( e.ColumnIndex == ColumnBook.Index )
      if ( e.RowIndex > 0 && e.Value.Equals(DataGridView[e.ColumnIndex, e.RowIndex - 1].Value) )
        e.Value = string.Empty;
  }

  private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
  {
    if ( e.Button == MouseButtons.Right && e.RowIndex != -1 )
      DataGridView.Rows[e.RowIndex].Selected = true;
  }

  private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
  {
    if ( e.RowIndex < 0 || e.ColumnIndex < 0 )
      DataGridView.ClearSelection();
    else
    if ( DataGridView[e.ColumnIndex, e.RowIndex].Value == DBNull.Value )
      DataGridView.ClearSelection();
  }

  private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
  {
    if ( e.RowIndex < 0 || e.ColumnIndex < 0 ) return;
    DataGridView.BeginEdit(false);
  }

  private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
  {
    if ( DataGridView.ReadOnly ) return;
    if ( e.RowIndex < 0 || e.ColumnIndex != ColumnMemo.Index ) return;
    ActionEditMemo.PerformClick();
  }

  [SuppressMessage("Refactoring", "GCop622:Reverse your IF condition and return. Then move the nested statements to after the IF.", Justification = "Opinion")]
  private void ActionEditMemo_Click(object sender, EventArgs e)
  {
    string title = (string)DataGridView.CurrentRow.Cells[ColumnName.Index].Value;
    if ( EditMemoForm.Run(title, CurrentDataBoundItem.Memo, out var memo) )
    {
      CurrentDataBoundItem.Memo = memo;
      ActionSave.Enabled = true;
      ActionUndo.Enabled = true;
      DataGridView.RefreshEdit();
    }
  }

  private void ActionShowGrammarGuide_Click(object sender, EventArgs e)
  {
    Program.GrammarGuideForm.Popup();
  }

  private void ActionOpenHebrewLetters_Click(object sender, EventArgs e)
  {
    HebrewTools.OpenHebrewLetters(CurrentDataBoundItem.Hebrew);
  }

  private void ActionOpenHebrewWordsVerse_Click(object sender, EventArgs e)
  {
    HebrewTools.OpenHebrewWordsGoToVerse(CurrentDataBoundItem.FullReferenceBegin);
  }

  private void ActionOpenHebrewWordsSearch_Click(object sender, EventArgs e)
  {
    HebrewTools.OpenHebrewWordsSearchWord(CurrentDataBoundItem.Hebrew);
  }

  private void ActionCopyName_Click(object sender, EventArgs e)
  {
    Clipboard.SetText(CurrentDataBoundItem.Name);
  }

  private void ActionCopyHebrewChars_Click(object sender, EventArgs e)
  {
    Clipboard.SetText(CurrentDataBoundItem.Hebrew);
  }

  private void ActionCopyUnicodeChars_Click(object sender, EventArgs e)
  {
    Clipboard.SetText(CurrentDataBoundItem.Unicode);
  }

  private void ActionCopyLineHebrew_Click(object sender, EventArgs e)
  {
    Clipboard.SetText(CurrentDataBoundItem.ToString(true));
  }

  private void ActionCopyLineUnicode_Click(object sender, EventArgs e)
  {
    Clipboard.SetText(CurrentDataBoundItem.ToString(false));
  }

  private void ActionShowDescription_Click(object sender, EventArgs e)
  {
    MainForm.UserParashot.ShowDescription(CurrentDataBoundItem, false, () => Run(CurrentDataBoundItem));
  }

  private void ActionShowTranscriptionGuide_Click(object sender, EventArgs e)
  {
    Program.TranscriptionGuideForm.Popup();
  }

  private void ActionGoToNextParashah_Click(object sender, EventArgs e)
  {
    string id = CurrentDataBoundItem.ID;
    var today = DateTime.Today;
    var days = Calendar.ApplicationDatabase.Instance.LunisolarDays;
    var day = days.Find(item => item.Date >= today && item.ParashahID == id);
    if ( day is not null ) MainForm.Instance.GoToDate(day.Date, true, false, false);
  }

  private void ActionClearSearch_Click(object sender, EventArgs e)
  {
    EditSearch.Clear();
  }

  private void EditSearch_TextChanged(object sender, EventArgs e)
  {
    string match = EditSearch.Text;
    ActionClearSearch.Enabled = match.Length > 0;
    if ( match.Length <= 2 ) return;
    var row = DataGridView.Rows
                          .AsIEnumerable()
                          .FirstOrDefault(row => ( (string)row.Cells[ColumnName.Index].Value ).RawContains(match));
    if ( row is null ) return;
    row.Selected = true;
    DataGridView.CurrentCell = row.Cells[0];
    DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.SelectedRows[0].Index;
  }

  private void EditSearch_KeyDown(object sender, KeyEventArgs e)
  {
    if ( e.KeyCode != Keys.Escape ) return;
    EditSearch.Clear();
    DataGridView.Focus();
    e.Handled = true;
    e.SuppressKeyPress = true;
  }

}

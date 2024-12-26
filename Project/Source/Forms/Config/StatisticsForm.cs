/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

sealed partial class StatisticsForm : Form
{

  static public StatisticsForm Instance { get; private set; }

  static StatisticsForm()
  {
    Instance = new StatisticsForm();
    Instance.SystemStatisticsForm_Load(null, null);
    Instance.EditAlwaysOnTop_CheckedChanged(null, null);
  }

  static public void Run(bool isPrepare = false, bool enabled = true)
  {
    LoadingForm.Instance.Progressing += Application.DoEvents;
    if ( isPrepare )
      Instance.Timer.Interval = SystemStatistics.TimerIntervalIdle;
    else
    {
      Instance.Popup();
      Instance.Timer.Interval = SystemStatistics.TimerIntervalActive;
    }
    if ( enabled )
    {
      Instance.Timer_Tick(null, null);
      Instance.Timer.Start();
    }
    Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
  }

  private StatisticsForm()
  {
    InitializeComponent();
    Icon = MainForm.Instance.Icon;
    ApplicationStatisticsDataBindingSource.DataSource = ApplicationStatistics.Instance;
    SystemStatisticsDataBindingSource.DataSource = SystemStatistics.Instance;
  }

  private void SystemStatisticsForm_Load(object sender, EventArgs e)
  {
    this.CheckLocationOrCenterToMainFormElseScreen();
    EditFolderApplication.Text = Globals.RootFolderPath;
    EditFolderUserData.Text = Globals.UserDataFolderPath;
    EditOpenFolderUserLocalData.Text = Globals.UserLocalDataFolderPath;
  }

  private void SystemStatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
  {
    LoadingForm.Instance.Progressing -= Application.DoEvents;
    Timer.Interval = SystemStatistics.TimerIntervalIdle;
    e.Cancel = true;
    Hide();
  }

  private void EditAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
  {
    TopMost = EditAlwaysOnTop.Checked;
  }

  private void ActionClose_Click(object sender, EventArgs e)
  {
    Close();
  }

  private void ActionViewLog_Click(object sender, EventArgs e)
  {
    DebugManager.TraceForm.Popup();
  }

  private void ActionScreenshot_Click(object sender, EventArgs e)
  {
    using var bitmap = PanelMain.GetBitmap();
    Clipboard.SetImage(bitmap);
    DisplayManager.ShowSuccessOrSound(SysTranslations.ScreenshotDone.GetLang(),
                                      Globals.ScreenshotSoundFilePath);
  }

  private void ActionOpenFolderApplication_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(EditFolderApplication.Text);
  }

  private void ActionOpenFolderUserData_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(EditFolderUserData.Text);
  }

  private void ActionOpenFolderUserLocalData_Click(object sender, EventArgs e)
  {
    SystemManager.RunShell(EditOpenFolderUserLocalData.Text);
  }

  [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "Dummy required")]
  [SuppressMessage("Style", "IDE0059:Assignation inutile d'une valeur", Justification = "Dummy required")]
  public void Timer_Tick(object sender, EventArgs e)
  {
    if ( Visible )
    {
      LabelApplication1.Text = Globals.AssemblyTitleWithVersion;
      ApplicationStatisticsDataBindingSource.ResetBindings(false);
      SystemStatisticsDataBindingSource.ResetBindings(false);
    }
    else
    {
      string dummyMemoryGC = SystemStatistics.Instance.MemoryGC;
      string dummyCPUProcessLoad = SystemStatistics.Instance.CPUProcessLoad;
    }
  }

}

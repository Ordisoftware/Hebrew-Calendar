namespace Ordisoftware.HebrewCalendar
{
  partial class PreferencesForm
  {
    /// <summary>
    /// Required designer variable
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && (components != null) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label LabelGPSLatitude;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
      System.Windows.Forms.Label LabelGPSLongitude;
      System.Windows.Forms.Label label7;
      System.Windows.Forms.Label LabelHebrewLettersPath;
      System.Windows.Forms.Label LabelTimeZone;
      this.DialogColor = new System.Windows.Forms.ColorDialog();
      this.ActionClose = new System.Windows.Forms.Button();
      this.LabelShabatDay = new System.Windows.Forms.Label();
      this.LabelFontSize = new System.Windows.Forms.Label();
      this.EditShabatDay = new System.Windows.Forms.ComboBox();
      this.LabelFontName = new System.Windows.Forms.Label();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionResetSettings = new System.Windows.Forms.LinkLabel();
      this.ActionUsePersonalShabat = new System.Windows.Forms.LinkLabel();
      this.GroupBoxGPS = new System.Windows.Forms.GroupBox();
      this.ActionGetGPS = new System.Windows.Forms.LinkLabel();
      this.EditGPSLatitude = new Ordisoftware.HebrewCommon.UndoRedoTextBox();
      this.EditTimeZone = new Ordisoftware.HebrewCommon.UndoRedoTextBox();
      this.EditGPSLongitude = new Ordisoftware.HebrewCommon.UndoRedoTextBox();
      this.GroupBoxTextReport = new System.Windows.Forms.GroupBox();
      this.EditMonthViewFontSize = new System.Windows.Forms.NumericUpDown();
      this.EditFontSize = new System.Windows.Forms.NumericUpDown();
      this.LabelBackColor = new System.Windows.Forms.Label();
      this.EditTextColor = new System.Windows.Forms.Panel();
      this.LabelTextColor = new System.Windows.Forms.Label();
      this.EditTextBackground = new System.Windows.Forms.Panel();
      this.label6 = new System.Windows.Forms.Label();
      this.EditFontName = new System.Windows.Forms.ComboBox();
      this.BroupBoxShabat = new System.Windows.Forms.GroupBox();
      this.LabelRemindShabatHoursBefore = new System.Windows.Forms.Label();
      this.LabelRemindShabatEveryMinutes = new System.Windows.Forms.Label();
      this.EditRemindShabatOnlyLight = new System.Windows.Forms.CheckBox();
      this.EditRemindShabatHoursBefore = new System.Windows.Forms.NumericUpDown();
      this.EditRemindShabatEveryMinutes = new System.Windows.Forms.NumericUpDown();
      this.EditReminderShabatEnabled = new System.Windows.Forms.CheckBox();
      this.GroupBoxNavigation = new System.Windows.Forms.GroupBox();
      this.ActionUseBlackAndWhiteColors = new System.Windows.Forms.LinkLabel();
      this.ActionUseDefaultColors = new System.Windows.Forms.LinkLabel();
      this.LabelTopColor = new System.Windows.Forms.Label();
      this.ActionUseSystemColors = new System.Windows.Forms.LinkLabel();
      this.EditNavigateTopColor = new System.Windows.Forms.Panel();
      this.EditNavigateBottomColor = new System.Windows.Forms.Panel();
      this.EditNavigateMiddleColor = new System.Windows.Forms.Panel();
      this.LabelBottomColor = new System.Windows.Forms.Label();
      this.LabelMiddleColor = new System.Windows.Forms.Label();
      this.GroupBoxTrayIcon = new System.Windows.Forms.GroupBox();
      this.EditBalloonAutoHide = new System.Windows.Forms.CheckBox();
      this.EditBalloon = new System.Windows.Forms.CheckBox();
      this.SelectOpenNavigationForm = new System.Windows.Forms.RadioButton();
      this.SelectOpenMainForm = new System.Windows.Forms.RadioButton();
      this.EditBalloonLoomingDelay = new System.Windows.Forms.NumericUpDown();
      this.LabelLoomingDelay = new System.Windows.Forms.Label();
      this.EditStartupHide = new System.Windows.Forms.CheckBox();
      this.GroupBoxReminder = new System.Windows.Forms.GroupBox();
      this.PanelReminderColors = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.EditEventColorTorah = new System.Windows.Forms.Panel();
      this.EditEventColorShabat = new System.Windows.Forms.Panel();
      this.EditEventColorSeason = new System.Windows.Forms.Panel();
      this.EditEventColorNext = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.EditEventColorMonth = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.EditUseColors = new System.Windows.Forms.CheckBox();
      this.LabelRemindAutoLockTimeOut = new System.Windows.Forms.Label();
      this.LabelRemindCelebrationHoursBefore = new System.Windows.Forms.Label();
      this.LabelRemindCelebrationEveryMinutes = new System.Windows.Forms.Label();
      this.EditEventsDay = new System.Windows.Forms.CheckedListBox();
      this.EditEvents = new System.Windows.Forms.CheckedListBox();
      this.EditReminderCelebrationsInterval = new System.Windows.Forms.NumericUpDown();
      this.LabelTimerInterval = new System.Windows.Forms.Label();
      this.EditAutoLockSessionTimeOut = new System.Windows.Forms.NumericUpDown();
      this.EditRemindCelebrationHoursBefore = new System.Windows.Forms.NumericUpDown();
      this.EditAutoLockSession = new System.Windows.Forms.CheckBox();
      this.EditTorahEventsCountAsMoon = new System.Windows.Forms.CheckBox();
      this.EditReminderCelebrationsEnabled = new System.Windows.Forms.CheckBox();
      this.EditRemindCelebrationEveryMinutes = new System.Windows.Forms.NumericUpDown();
      this.EditMonthViewSunToolTips = new System.Windows.Forms.CheckBox();
      this.GroupBoxMonth = new System.Windows.Forms.GroupBox();
      this.LabelColorNoDay = new System.Windows.Forms.Label();
      this.LabelColorText = new System.Windows.Forms.Label();
      this.EditCalendarColorNoDay = new System.Windows.Forms.Panel();
      this.EditCalendarColorDefaultText = new System.Windows.Forms.Panel();
      this.LabelColorEmpty = new System.Windows.Forms.Label();
      this.EditCalendarColorEmpty = new System.Windows.Forms.Panel();
      this.ActionMonthViewThemeDark = new System.Windows.Forms.LinkLabel();
      this.ActionMonthViewThemeLight = new System.Windows.Forms.LinkLabel();
      this.LabelColorFullMoon = new System.Windows.Forms.Label();
      this.EditCalendarColorFullMoon = new System.Windows.Forms.Panel();
      this.LabelColorMoon = new System.Windows.Forms.Label();
      this.EditCalendarColorMoon = new System.Windows.Forms.Panel();
      this.LabelColorSeason = new System.Windows.Forms.Label();
      this.EditCalendarColorSeason = new System.Windows.Forms.Panel();
      this.LabelColorTorah = new System.Windows.Forms.Label();
      this.EditCalendarColorTorahEvent = new System.Windows.Forms.Panel();
      this.LabelColorTodayBack = new System.Windows.Forms.Label();
      this.LabelColorToday = new System.Windows.Forms.Label();
      this.EditCurrentDayBackColor = new System.Windows.Forms.Panel();
      this.EditCurrentDayForeColor = new System.Windows.Forms.Panel();
      this.GroupBoxSystem = new System.Windows.Forms.GroupBox();
      this.ActionSelectHebrewLettersPath = new System.Windows.Forms.Button();
      this.EditHebrewLettersPath = new Ordisoftware.HebrewCommon.UndoRedoTextBox();
      this.EditVacuumAtStartup = new System.Windows.Forms.CheckBox();
      this.ActionSelectLangFR = new System.Windows.Forms.Button();
      this.ActionSelectLangEN = new System.Windows.Forms.Button();
      this.EditAutoOpenExportFolder = new System.Windows.Forms.CheckBox();
      this.EditShowReminderInTaskBar = new System.Windows.Forms.CheckBox();
      this.EditCheckUpdateAtStartup = new System.Windows.Forms.CheckBox();
      this.EditDebuggerEnabled = new System.Windows.Forms.CheckBox();
      this.EditWebLinksMenuEnabled = new System.Windows.Forms.CheckBox();
      this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.GroupBoxMoonDayTextFormat = new System.Windows.Forms.GroupBox();
      this.ActionMoonDayTextFormatReset = new System.Windows.Forms.Button();
      this.MenuSelectMoonDayTextFormat = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.nissan11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.nissan11ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.nissanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.nissan1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionMoonDayTextFormatHelp = new System.Windows.Forms.Button();
      this.EditMoonDayTextFormat = new Ordisoftware.HebrewCommon.UndoRedoTextBox();
      LabelGPSLatitude = new System.Windows.Forms.Label();
      LabelGPSLongitude = new System.Windows.Forms.Label();
      label7 = new System.Windows.Forms.Label();
      LabelHebrewLettersPath = new System.Windows.Forms.Label();
      LabelTimeZone = new System.Windows.Forms.Label();
      this.PanelButtons.SuspendLayout();
      this.GroupBoxGPS.SuspendLayout();
      this.GroupBoxTextReport.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditMonthViewFontSize)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).BeginInit();
      this.BroupBoxShabat.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatHoursBefore)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatEveryMinutes)).BeginInit();
      this.GroupBoxNavigation.SuspendLayout();
      this.GroupBoxTrayIcon.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditBalloonLoomingDelay)).BeginInit();
      this.GroupBoxReminder.SuspendLayout();
      this.PanelReminderColors.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditReminderCelebrationsInterval)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditAutoLockSessionTimeOut)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindCelebrationHoursBefore)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindCelebrationEveryMinutes)).BeginInit();
      this.GroupBoxMonth.SuspendLayout();
      this.GroupBoxSystem.SuspendLayout();
      this.GroupBoxMoonDayTextFormat.SuspendLayout();
      this.MenuSelectMoonDayTextFormat.SuspendLayout();
      this.SuspendLayout();
      // 
      // LabelGPSLatitude
      // 
      resources.ApplyResources(LabelGPSLatitude, "LabelGPSLatitude");
      LabelGPSLatitude.Name = "LabelGPSLatitude";
      // 
      // LabelGPSLongitude
      // 
      resources.ApplyResources(LabelGPSLongitude, "LabelGPSLongitude");
      LabelGPSLongitude.Name = "LabelGPSLongitude";
      // 
      // label7
      // 
      resources.ApplyResources(label7, "label7");
      label7.Name = "label7";
      // 
      // LabelHebrewLettersPath
      // 
      resources.ApplyResources(LabelHebrewLettersPath, "LabelHebrewLettersPath");
      LabelHebrewLettersPath.Name = "LabelHebrewLettersPath";
      // 
      // LabelTimeZone
      // 
      resources.ApplyResources(LabelTimeZone, "LabelTimeZone");
      LabelTimeZone.Name = "LabelTimeZone";
      // 
      // DialogColor
      // 
      this.DialogColor.FullOpen = true;
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.UseVisualStyleBackColor = true;
      // 
      // LabelShabatDay
      // 
      resources.ApplyResources(this.LabelShabatDay, "LabelShabatDay");
      this.LabelShabatDay.Name = "LabelShabatDay";
      // 
      // LabelFontSize
      // 
      resources.ApplyResources(this.LabelFontSize, "LabelFontSize");
      this.LabelFontSize.Name = "LabelFontSize";
      // 
      // EditShabatDay
      // 
      this.EditShabatDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      resources.ApplyResources(this.EditShabatDay, "EditShabatDay");
      this.EditShabatDay.FormattingEnabled = true;
      this.EditShabatDay.Name = "EditShabatDay";
      this.EditShabatDay.SelectedIndexChanged += new System.EventHandler(this.EditRemindShabat_ValueChanged);
      // 
      // LabelFontName
      // 
      resources.ApplyResources(this.LabelFontName, "LabelFontName");
      this.LabelFontName.Name = "LabelFontName";
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.ActionResetSettings);
      this.PanelButtons.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Name = "PanelButtons";
      // 
      // ActionResetSettings
      // 
      this.ActionResetSettings.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionResetSettings, "ActionResetSettings");
      this.ActionResetSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionResetSettings.LinkColor = System.Drawing.Color.Navy;
      this.ActionResetSettings.Name = "ActionResetSettings";
      this.ActionResetSettings.TabStop = true;
      this.ActionResetSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionResetSettings_LinkClicked);
      // 
      // ActionUsePersonalShabat
      // 
      this.ActionUsePersonalShabat.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionUsePersonalShabat, "ActionUsePersonalShabat");
      this.ActionUsePersonalShabat.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionUsePersonalShabat.LinkColor = System.Drawing.Color.Navy;
      this.ActionUsePersonalShabat.Name = "ActionUsePersonalShabat";
      this.ActionUsePersonalShabat.TabStop = true;
      this.ActionUsePersonalShabat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionUsePersonalShabat_LinkClicked);
      // 
      // GroupBoxGPS
      // 
      this.GroupBoxGPS.Controls.Add(this.ActionGetGPS);
      this.GroupBoxGPS.Controls.Add(this.EditGPSLatitude);
      this.GroupBoxGPS.Controls.Add(LabelGPSLatitude);
      this.GroupBoxGPS.Controls.Add(this.EditTimeZone);
      this.GroupBoxGPS.Controls.Add(this.EditGPSLongitude);
      this.GroupBoxGPS.Controls.Add(LabelTimeZone);
      this.GroupBoxGPS.Controls.Add(LabelGPSLongitude);
      resources.ApplyResources(this.GroupBoxGPS, "GroupBoxGPS");
      this.GroupBoxGPS.Name = "GroupBoxGPS";
      this.GroupBoxGPS.TabStop = false;
      // 
      // ActionGetGPS
      // 
      this.ActionGetGPS.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionGetGPS, "ActionGetGPS");
      this.ActionGetGPS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionGetGPS.LinkColor = System.Drawing.Color.Navy;
      this.ActionGetGPS.Name = "ActionGetGPS";
      this.ActionGetGPS.TabStop = true;
      this.ActionGetGPS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionGetGPS_LinkClicked);
      // 
      // EditGPSLatitude
      // 
      this.EditGPSLatitude.CaretAfterPaste = Ordisoftware.HebrewCommon.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditGPSLatitude, "EditGPSLatitude");
      this.EditGPSLatitude.Name = "EditGPSLatitude";
      this.EditGPSLatitude.ReadOnly = true;
      // 
      // EditTimeZone
      // 
      this.EditTimeZone.CaretAfterPaste = Ordisoftware.HebrewCommon.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditTimeZone, "EditTimeZone");
      this.EditTimeZone.Name = "EditTimeZone";
      this.EditTimeZone.ReadOnly = true;
      // 
      // EditGPSLongitude
      // 
      this.EditGPSLongitude.CaretAfterPaste = Ordisoftware.HebrewCommon.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditGPSLongitude, "EditGPSLongitude");
      this.EditGPSLongitude.Name = "EditGPSLongitude";
      this.EditGPSLongitude.ReadOnly = true;
      // 
      // GroupBoxTextReport
      // 
      this.GroupBoxTextReport.Controls.Add(this.EditMonthViewFontSize);
      this.GroupBoxTextReport.Controls.Add(this.EditFontSize);
      this.GroupBoxTextReport.Controls.Add(this.LabelFontName);
      this.GroupBoxTextReport.Controls.Add(this.LabelBackColor);
      this.GroupBoxTextReport.Controls.Add(this.EditTextColor);
      this.GroupBoxTextReport.Controls.Add(this.LabelTextColor);
      this.GroupBoxTextReport.Controls.Add(this.EditTextBackground);
      this.GroupBoxTextReport.Controls.Add(this.label6);
      this.GroupBoxTextReport.Controls.Add(this.EditFontName);
      this.GroupBoxTextReport.Controls.Add(this.LabelFontSize);
      resources.ApplyResources(this.GroupBoxTextReport, "GroupBoxTextReport");
      this.GroupBoxTextReport.Name = "GroupBoxTextReport";
      this.GroupBoxTextReport.TabStop = false;
      // 
      // EditMonthViewFontSize
      // 
      this.EditMonthViewFontSize.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditMonthViewFontSize, "EditMonthViewFontSize");
      this.EditMonthViewFontSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.EditMonthViewFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.EditMonthViewFontSize.Name = "EditMonthViewFontSize";
      this.EditMonthViewFontSize.ReadOnly = true;
      this.EditMonthViewFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.EditMonthViewFontSize.ValueChanged += new System.EventHandler(this.EditMonthViewFontSize_ValueChanged);
      // 
      // EditFontSize
      // 
      this.EditFontSize.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditFontSize, "EditFontSize");
      this.EditFontSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.EditFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
      this.EditFontSize.Name = "EditFontSize";
      this.EditFontSize.ReadOnly = true;
      this.EditFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.EditFontSize.ValueChanged += new System.EventHandler(this.EitReportFont_Changed);
      // 
      // LabelBackColor
      // 
      resources.ApplyResources(this.LabelBackColor, "LabelBackColor");
      this.LabelBackColor.Name = "LabelBackColor";
      // 
      // EditTextColor
      // 
      this.EditTextColor.BackColor = System.Drawing.Color.Black;
      this.EditTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditTextColor, "EditTextColor");
      this.EditTextColor.Name = "EditTextColor";
      this.EditTextColor.Click += new System.EventHandler(this.PanelTextColor_Click);
      // 
      // LabelTextColor
      // 
      resources.ApplyResources(this.LabelTextColor, "LabelTextColor");
      this.LabelTextColor.Name = "LabelTextColor";
      // 
      // EditTextBackground
      // 
      this.EditTextBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.EditTextBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditTextBackground, "EditTextBackground");
      this.EditTextBackground.Name = "EditTextBackground";
      this.EditTextBackground.Click += new System.EventHandler(this.PanelBackColor_Click);
      // 
      // label6
      // 
      resources.ApplyResources(this.label6, "label6");
      this.label6.Name = "label6";
      // 
      // EditFontName
      // 
      this.EditFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      resources.ApplyResources(this.EditFontName, "EditFontName");
      this.EditFontName.FormattingEnabled = true;
      this.EditFontName.Name = "EditFontName";
      this.EditFontName.SelectedIndexChanged += new System.EventHandler(this.EitReportFont_Changed);
      // 
      // BroupBoxShabat
      // 
      this.BroupBoxShabat.Controls.Add(this.LabelRemindShabatHoursBefore);
      this.BroupBoxShabat.Controls.Add(this.LabelRemindShabatEveryMinutes);
      this.BroupBoxShabat.Controls.Add(this.EditRemindShabatOnlyLight);
      this.BroupBoxShabat.Controls.Add(this.EditShabatDay);
      this.BroupBoxShabat.Controls.Add(this.EditRemindShabatHoursBefore);
      this.BroupBoxShabat.Controls.Add(this.ActionUsePersonalShabat);
      this.BroupBoxShabat.Controls.Add(this.LabelShabatDay);
      this.BroupBoxShabat.Controls.Add(this.EditRemindShabatEveryMinutes);
      this.BroupBoxShabat.Controls.Add(this.EditReminderShabatEnabled);
      resources.ApplyResources(this.BroupBoxShabat, "BroupBoxShabat");
      this.BroupBoxShabat.Name = "BroupBoxShabat";
      this.BroupBoxShabat.TabStop = false;
      // 
      // LabelRemindShabatHoursBefore
      // 
      resources.ApplyResources(this.LabelRemindShabatHoursBefore, "LabelRemindShabatHoursBefore");
      this.LabelRemindShabatHoursBefore.Name = "LabelRemindShabatHoursBefore";
      // 
      // LabelRemindShabatEveryMinutes
      // 
      resources.ApplyResources(this.LabelRemindShabatEveryMinutes, "LabelRemindShabatEveryMinutes");
      this.LabelRemindShabatEveryMinutes.Name = "LabelRemindShabatEveryMinutes";
      // 
      // EditRemindShabatOnlyLight
      // 
      resources.ApplyResources(this.EditRemindShabatOnlyLight, "EditRemindShabatOnlyLight");
      this.EditRemindShabatOnlyLight.Name = "EditRemindShabatOnlyLight";
      this.EditRemindShabatOnlyLight.UseVisualStyleBackColor = true;
      this.EditRemindShabatOnlyLight.CheckedChanged += new System.EventHandler(this.EditRemindShabat_ValueChanged);
      // 
      // EditRemindShabatHoursBefore
      // 
      this.EditRemindShabatHoursBefore.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditRemindShabatHoursBefore, "EditRemindShabatHoursBefore");
      this.EditRemindShabatHoursBefore.Name = "EditRemindShabatHoursBefore";
      this.EditRemindShabatHoursBefore.ReadOnly = true;
      // 
      // EditRemindShabatEveryMinutes
      // 
      this.EditRemindShabatEveryMinutes.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditRemindShabatEveryMinutes, "EditRemindShabatEveryMinutes");
      this.EditRemindShabatEveryMinutes.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.EditRemindShabatEveryMinutes.Name = "EditRemindShabatEveryMinutes";
      this.EditRemindShabatEveryMinutes.ReadOnly = true;
      // 
      // EditReminderShabatEnabled
      // 
      resources.ApplyResources(this.EditReminderShabatEnabled, "EditReminderShabatEnabled");
      this.EditReminderShabatEnabled.Checked = true;
      this.EditReminderShabatEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditReminderShabatEnabled.Name = "EditReminderShabatEnabled";
      this.EditReminderShabatEnabled.UseVisualStyleBackColor = true;
      this.EditReminderShabatEnabled.CheckedChanged += new System.EventHandler(this.EditRemindShabat_ValueChanged);
      // 
      // GroupBoxNavigation
      // 
      this.GroupBoxNavigation.Controls.Add(this.ActionUseBlackAndWhiteColors);
      this.GroupBoxNavigation.Controls.Add(this.ActionUseDefaultColors);
      this.GroupBoxNavigation.Controls.Add(this.LabelTopColor);
      this.GroupBoxNavigation.Controls.Add(this.ActionUseSystemColors);
      this.GroupBoxNavigation.Controls.Add(this.EditNavigateTopColor);
      this.GroupBoxNavigation.Controls.Add(this.EditNavigateBottomColor);
      this.GroupBoxNavigation.Controls.Add(this.EditNavigateMiddleColor);
      this.GroupBoxNavigation.Controls.Add(this.LabelBottomColor);
      this.GroupBoxNavigation.Controls.Add(this.LabelMiddleColor);
      resources.ApplyResources(this.GroupBoxNavigation, "GroupBoxNavigation");
      this.GroupBoxNavigation.Name = "GroupBoxNavigation";
      this.GroupBoxNavigation.TabStop = false;
      // 
      // ActionUseBlackAndWhiteColors
      // 
      this.ActionUseBlackAndWhiteColors.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionUseBlackAndWhiteColors, "ActionUseBlackAndWhiteColors");
      this.ActionUseBlackAndWhiteColors.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionUseBlackAndWhiteColors.LinkColor = System.Drawing.Color.Navy;
      this.ActionUseBlackAndWhiteColors.Name = "ActionUseBlackAndWhiteColors";
      this.ActionUseBlackAndWhiteColors.TabStop = true;
      this.ActionUseBlackAndWhiteColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionUseBlackAndWhiteColors_LinkClicked);
      // 
      // ActionUseDefaultColors
      // 
      this.ActionUseDefaultColors.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionUseDefaultColors, "ActionUseDefaultColors");
      this.ActionUseDefaultColors.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionUseDefaultColors.LinkColor = System.Drawing.Color.Navy;
      this.ActionUseDefaultColors.Name = "ActionUseDefaultColors";
      this.ActionUseDefaultColors.TabStop = true;
      this.ActionUseDefaultColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionUseDefaultColors_LinkClicked);
      // 
      // LabelTopColor
      // 
      resources.ApplyResources(this.LabelTopColor, "LabelTopColor");
      this.LabelTopColor.Name = "LabelTopColor";
      // 
      // ActionUseSystemColors
      // 
      this.ActionUseSystemColors.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionUseSystemColors, "ActionUseSystemColors");
      this.ActionUseSystemColors.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionUseSystemColors.LinkColor = System.Drawing.Color.Navy;
      this.ActionUseSystemColors.Name = "ActionUseSystemColors";
      this.ActionUseSystemColors.TabStop = true;
      this.ActionUseSystemColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionUseSystemColors_LinkClicked);
      // 
      // EditNavigateTopColor
      // 
      this.EditNavigateTopColor.BackColor = System.Drawing.Color.LemonChiffon;
      this.EditNavigateTopColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditNavigateTopColor, "EditNavigateTopColor");
      this.EditNavigateTopColor.Name = "EditNavigateTopColor";
      this.EditNavigateTopColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelTopColor_MouseClick);
      // 
      // EditNavigateBottomColor
      // 
      this.EditNavigateBottomColor.BackColor = System.Drawing.Color.Honeydew;
      this.EditNavigateBottomColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditNavigateBottomColor, "EditNavigateBottomColor");
      this.EditNavigateBottomColor.Name = "EditNavigateBottomColor";
      this.EditNavigateBottomColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelBottomColor_MouseClick);
      // 
      // EditNavigateMiddleColor
      // 
      this.EditNavigateMiddleColor.BackColor = System.Drawing.Color.AliceBlue;
      this.EditNavigateMiddleColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditNavigateMiddleColor, "EditNavigateMiddleColor");
      this.EditNavigateMiddleColor.Name = "EditNavigateMiddleColor";
      this.EditNavigateMiddleColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelMiddleColor_MouseClick);
      // 
      // LabelBottomColor
      // 
      resources.ApplyResources(this.LabelBottomColor, "LabelBottomColor");
      this.LabelBottomColor.Name = "LabelBottomColor";
      // 
      // LabelMiddleColor
      // 
      resources.ApplyResources(this.LabelMiddleColor, "LabelMiddleColor");
      this.LabelMiddleColor.Name = "LabelMiddleColor";
      // 
      // GroupBoxTrayIcon
      // 
      this.GroupBoxTrayIcon.Controls.Add(this.EditBalloonAutoHide);
      this.GroupBoxTrayIcon.Controls.Add(this.EditBalloon);
      this.GroupBoxTrayIcon.Controls.Add(this.SelectOpenNavigationForm);
      this.GroupBoxTrayIcon.Controls.Add(this.SelectOpenMainForm);
      this.GroupBoxTrayIcon.Controls.Add(this.EditBalloonLoomingDelay);
      this.GroupBoxTrayIcon.Controls.Add(this.LabelLoomingDelay);
      this.GroupBoxTrayIcon.Controls.Add(label7);
      resources.ApplyResources(this.GroupBoxTrayIcon, "GroupBoxTrayIcon");
      this.GroupBoxTrayIcon.Name = "GroupBoxTrayIcon";
      this.GroupBoxTrayIcon.TabStop = false;
      // 
      // EditBalloonAutoHide
      // 
      resources.ApplyResources(this.EditBalloonAutoHide, "EditBalloonAutoHide");
      this.EditBalloonAutoHide.Name = "EditBalloonAutoHide";
      this.EditBalloonAutoHide.UseVisualStyleBackColor = true;
      // 
      // EditBalloon
      // 
      resources.ApplyResources(this.EditBalloon, "EditBalloon");
      this.EditBalloon.Name = "EditBalloon";
      this.EditBalloon.UseVisualStyleBackColor = true;
      this.EditBalloon.CheckedChanged += new System.EventHandler(this.EditBalloon_CheckedChanged);
      // 
      // SelectOpenNavigationForm
      // 
      resources.ApplyResources(this.SelectOpenNavigationForm, "SelectOpenNavigationForm");
      this.SelectOpenNavigationForm.Name = "SelectOpenNavigationForm";
      this.SelectOpenNavigationForm.TabStop = true;
      this.SelectOpenNavigationForm.UseVisualStyleBackColor = true;
      // 
      // SelectOpenMainForm
      // 
      resources.ApplyResources(this.SelectOpenMainForm, "SelectOpenMainForm");
      this.SelectOpenMainForm.Name = "SelectOpenMainForm";
      this.SelectOpenMainForm.TabStop = true;
      this.SelectOpenMainForm.UseVisualStyleBackColor = true;
      // 
      // EditBalloonLoomingDelay
      // 
      this.EditBalloonLoomingDelay.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditBalloonLoomingDelay, "EditBalloonLoomingDelay");
      this.EditBalloonLoomingDelay.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
      this.EditBalloonLoomingDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      this.EditBalloonLoomingDelay.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
      this.EditBalloonLoomingDelay.Name = "EditBalloonLoomingDelay";
      this.EditBalloonLoomingDelay.ReadOnly = true;
      this.EditBalloonLoomingDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
      // 
      // LabelLoomingDelay
      // 
      resources.ApplyResources(this.LabelLoomingDelay, "LabelLoomingDelay");
      this.LabelLoomingDelay.Name = "LabelLoomingDelay";
      // 
      // EditStartupHide
      // 
      resources.ApplyResources(this.EditStartupHide, "EditStartupHide");
      this.EditStartupHide.Name = "EditStartupHide";
      this.EditStartupHide.UseVisualStyleBackColor = true;
      // 
      // GroupBoxReminder
      // 
      this.GroupBoxReminder.Controls.Add(this.PanelReminderColors);
      this.GroupBoxReminder.Controls.Add(this.EditUseColors);
      this.GroupBoxReminder.Controls.Add(this.LabelRemindAutoLockTimeOut);
      this.GroupBoxReminder.Controls.Add(this.LabelRemindCelebrationHoursBefore);
      this.GroupBoxReminder.Controls.Add(this.LabelRemindCelebrationEveryMinutes);
      this.GroupBoxReminder.Controls.Add(this.EditEventsDay);
      this.GroupBoxReminder.Controls.Add(this.EditEvents);
      this.GroupBoxReminder.Controls.Add(this.EditReminderCelebrationsInterval);
      this.GroupBoxReminder.Controls.Add(this.LabelTimerInterval);
      this.GroupBoxReminder.Controls.Add(this.EditAutoLockSessionTimeOut);
      this.GroupBoxReminder.Controls.Add(this.EditRemindCelebrationHoursBefore);
      this.GroupBoxReminder.Controls.Add(this.EditAutoLockSession);
      this.GroupBoxReminder.Controls.Add(this.EditTorahEventsCountAsMoon);
      this.GroupBoxReminder.Controls.Add(this.EditReminderCelebrationsEnabled);
      this.GroupBoxReminder.Controls.Add(this.EditRemindCelebrationEveryMinutes);
      resources.ApplyResources(this.GroupBoxReminder, "GroupBoxReminder");
      this.GroupBoxReminder.Name = "GroupBoxReminder";
      this.GroupBoxReminder.TabStop = false;
      // 
      // PanelReminderColors
      // 
      this.PanelReminderColors.Controls.Add(this.label1);
      this.PanelReminderColors.Controls.Add(this.EditEventColorTorah);
      this.PanelReminderColors.Controls.Add(this.EditEventColorShabat);
      this.PanelReminderColors.Controls.Add(this.EditEventColorSeason);
      this.PanelReminderColors.Controls.Add(this.EditEventColorNext);
      this.PanelReminderColors.Controls.Add(this.label5);
      this.PanelReminderColors.Controls.Add(this.EditEventColorMonth);
      this.PanelReminderColors.Controls.Add(this.label4);
      this.PanelReminderColors.Controls.Add(this.label3);
      this.PanelReminderColors.Controls.Add(this.label2);
      resources.ApplyResources(this.PanelReminderColors, "PanelReminderColors");
      this.PanelReminderColors.Name = "PanelReminderColors";
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // EditEventColorTorah
      // 
      this.EditEventColorTorah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
      this.EditEventColorTorah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditEventColorTorah, "EditEventColorTorah");
      this.EditEventColorTorah.Name = "EditEventColorTorah";
      this.EditEventColorTorah.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEventColorTorah_MouseClick);
      // 
      // EditEventColorShabat
      // 
      this.EditEventColorShabat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
      this.EditEventColorShabat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditEventColorShabat, "EditEventColorShabat");
      this.EditEventColorShabat.Name = "EditEventColorShabat";
      this.EditEventColorShabat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEventColorShabat_MouseClick);
      // 
      // EditEventColorSeason
      // 
      this.EditEventColorSeason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
      this.EditEventColorSeason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditEventColorSeason, "EditEventColorSeason");
      this.EditEventColorSeason.Name = "EditEventColorSeason";
      this.EditEventColorSeason.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEventColorSeason_MouseClick);
      // 
      // EditEventColorNext
      // 
      this.EditEventColorNext.BackColor = System.Drawing.Color.WhiteSmoke;
      this.EditEventColorNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditEventColorNext, "EditEventColorNext");
      this.EditEventColorNext.Name = "EditEventColorNext";
      this.EditEventColorNext.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEventColorNext_MouseClick);
      // 
      // label5
      // 
      resources.ApplyResources(this.label5, "label5");
      this.label5.Name = "label5";
      // 
      // EditEventColorMonth
      // 
      this.EditEventColorMonth.BackColor = System.Drawing.Color.AliceBlue;
      this.EditEventColorMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditEventColorMonth, "EditEventColorMonth");
      this.EditEventColorMonth.Name = "EditEventColorMonth";
      this.EditEventColorMonth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelEventColorNewMonth_MouseClick);
      // 
      // label4
      // 
      resources.ApplyResources(this.label4, "label4");
      this.label4.Name = "label4";
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.Name = "label3";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // EditUseColors
      // 
      resources.ApplyResources(this.EditUseColors, "EditUseColors");
      this.EditUseColors.Name = "EditUseColors";
      this.EditUseColors.UseVisualStyleBackColor = true;
      // 
      // LabelRemindAutoLockTimeOut
      // 
      resources.ApplyResources(this.LabelRemindAutoLockTimeOut, "LabelRemindAutoLockTimeOut");
      this.LabelRemindAutoLockTimeOut.Name = "LabelRemindAutoLockTimeOut";
      // 
      // LabelRemindCelebrationHoursBefore
      // 
      resources.ApplyResources(this.LabelRemindCelebrationHoursBefore, "LabelRemindCelebrationHoursBefore");
      this.LabelRemindCelebrationHoursBefore.Name = "LabelRemindCelebrationHoursBefore";
      // 
      // LabelRemindCelebrationEveryMinutes
      // 
      resources.ApplyResources(this.LabelRemindCelebrationEveryMinutes, "LabelRemindCelebrationEveryMinutes");
      this.LabelRemindCelebrationEveryMinutes.Name = "LabelRemindCelebrationEveryMinutes";
      // 
      // EditEventsDay
      // 
      this.EditEventsDay.CheckOnClick = true;
      resources.ApplyResources(this.EditEventsDay, "EditEventsDay");
      this.EditEventsDay.FormattingEnabled = true;
      this.EditEventsDay.Name = "EditEventsDay";
      // 
      // EditEvents
      // 
      this.EditEvents.CheckOnClick = true;
      resources.ApplyResources(this.EditEvents, "EditEvents");
      this.EditEvents.FormattingEnabled = true;
      this.EditEvents.Name = "EditEvents";
      // 
      // EditReminderCelebrationsInterval
      // 
      this.EditReminderCelebrationsInterval.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditReminderCelebrationsInterval, "EditReminderCelebrationsInterval");
      this.EditReminderCelebrationsInterval.Name = "EditReminderCelebrationsInterval";
      this.EditReminderCelebrationsInterval.ReadOnly = true;
      // 
      // LabelTimerInterval
      // 
      resources.ApplyResources(this.LabelTimerInterval, "LabelTimerInterval");
      this.LabelTimerInterval.Name = "LabelTimerInterval";
      // 
      // EditAutoLockSessionTimeOut
      // 
      this.EditAutoLockSessionTimeOut.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditAutoLockSessionTimeOut, "EditAutoLockSessionTimeOut");
      this.EditAutoLockSessionTimeOut.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.EditAutoLockSessionTimeOut.Name = "EditAutoLockSessionTimeOut";
      this.EditAutoLockSessionTimeOut.ReadOnly = true;
      // 
      // EditRemindCelebrationHoursBefore
      // 
      this.EditRemindCelebrationHoursBefore.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditRemindCelebrationHoursBefore, "EditRemindCelebrationHoursBefore");
      this.EditRemindCelebrationHoursBefore.Name = "EditRemindCelebrationHoursBefore";
      this.EditRemindCelebrationHoursBefore.ReadOnly = true;
      // 
      // EditAutoLockSession
      // 
      resources.ApplyResources(this.EditAutoLockSession, "EditAutoLockSession");
      this.EditAutoLockSession.Checked = true;
      this.EditAutoLockSession.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditAutoLockSession.Name = "EditAutoLockSession";
      this.EditAutoLockSession.UseVisualStyleBackColor = true;
      this.EditAutoLockSession.CheckedChanged += new System.EventHandler(this.EditRemindAutoLock_CheckedChanged);
      // 
      // EditTorahEventsCountAsMoon
      // 
      resources.ApplyResources(this.EditTorahEventsCountAsMoon, "EditTorahEventsCountAsMoon");
      this.EditTorahEventsCountAsMoon.Checked = true;
      this.EditTorahEventsCountAsMoon.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditTorahEventsCountAsMoon.Name = "EditTorahEventsCountAsMoon";
      this.EditTorahEventsCountAsMoon.UseVisualStyleBackColor = true;
      this.EditTorahEventsCountAsMoon.CheckedChanged += new System.EventHandler(this.EditTimerEnabled_CheckedChanged);
      // 
      // EditReminderCelebrationsEnabled
      // 
      resources.ApplyResources(this.EditReminderCelebrationsEnabled, "EditReminderCelebrationsEnabled");
      this.EditReminderCelebrationsEnabled.Checked = true;
      this.EditReminderCelebrationsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditReminderCelebrationsEnabled.Name = "EditReminderCelebrationsEnabled";
      this.EditReminderCelebrationsEnabled.UseVisualStyleBackColor = true;
      this.EditReminderCelebrationsEnabled.CheckedChanged += new System.EventHandler(this.EditTimerEnabled_CheckedChanged);
      // 
      // EditRemindCelebrationEveryMinutes
      // 
      this.EditRemindCelebrationEveryMinutes.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditRemindCelebrationEveryMinutes, "EditRemindCelebrationEveryMinutes");
      this.EditRemindCelebrationEveryMinutes.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.EditRemindCelebrationEveryMinutes.Name = "EditRemindCelebrationEveryMinutes";
      this.EditRemindCelebrationEveryMinutes.ReadOnly = true;
      // 
      // EditMonthViewSunToolTips
      // 
      resources.ApplyResources(this.EditMonthViewSunToolTips, "EditMonthViewSunToolTips");
      this.EditMonthViewSunToolTips.Name = "EditMonthViewSunToolTips";
      this.EditMonthViewSunToolTips.UseVisualStyleBackColor = true;
      // 
      // GroupBoxMonth
      // 
      this.GroupBoxMonth.Controls.Add(this.LabelColorNoDay);
      this.GroupBoxMonth.Controls.Add(this.LabelColorText);
      this.GroupBoxMonth.Controls.Add(this.EditCalendarColorNoDay);
      this.GroupBoxMonth.Controls.Add(this.EditCalendarColorDefaultText);
      this.GroupBoxMonth.Controls.Add(this.LabelColorEmpty);
      this.GroupBoxMonth.Controls.Add(this.EditCalendarColorEmpty);
      this.GroupBoxMonth.Controls.Add(this.ActionMonthViewThemeDark);
      this.GroupBoxMonth.Controls.Add(this.ActionMonthViewThemeLight);
      this.GroupBoxMonth.Controls.Add(this.LabelColorFullMoon);
      this.GroupBoxMonth.Controls.Add(this.EditCalendarColorFullMoon);
      this.GroupBoxMonth.Controls.Add(this.LabelColorMoon);
      this.GroupBoxMonth.Controls.Add(this.EditCalendarColorMoon);
      this.GroupBoxMonth.Controls.Add(this.LabelColorSeason);
      this.GroupBoxMonth.Controls.Add(this.EditCalendarColorSeason);
      this.GroupBoxMonth.Controls.Add(this.LabelColorTorah);
      this.GroupBoxMonth.Controls.Add(this.EditCalendarColorTorahEvent);
      this.GroupBoxMonth.Controls.Add(this.LabelColorTodayBack);
      this.GroupBoxMonth.Controls.Add(this.LabelColorToday);
      this.GroupBoxMonth.Controls.Add(this.EditCurrentDayBackColor);
      this.GroupBoxMonth.Controls.Add(this.EditCurrentDayForeColor);
      resources.ApplyResources(this.GroupBoxMonth, "GroupBoxMonth");
      this.GroupBoxMonth.Name = "GroupBoxMonth";
      this.GroupBoxMonth.TabStop = false;
      // 
      // LabelColorNoDay
      // 
      resources.ApplyResources(this.LabelColorNoDay, "LabelColorNoDay");
      this.LabelColorNoDay.Name = "LabelColorNoDay";
      // 
      // LabelColorText
      // 
      resources.ApplyResources(this.LabelColorText, "LabelColorText");
      this.LabelColorText.Name = "LabelColorText";
      // 
      // EditCalendarColorNoDay
      // 
      this.EditCalendarColorNoDay.BackColor = System.Drawing.Color.Black;
      this.EditCalendarColorNoDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCalendarColorNoDay, "EditCalendarColorNoDay");
      this.EditCalendarColorNoDay.Name = "EditCalendarColorNoDay";
      this.EditCalendarColorNoDay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditCalendarColorNoDay_MouseClick);
      // 
      // EditCalendarColorDefaultText
      // 
      this.EditCalendarColorDefaultText.BackColor = System.Drawing.Color.Black;
      this.EditCalendarColorDefaultText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCalendarColorDefaultText, "EditCalendarColorDefaultText");
      this.EditCalendarColorDefaultText.Name = "EditCalendarColorDefaultText";
      this.EditCalendarColorDefaultText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditCalendarColorDefaultText_MouseClick);
      // 
      // LabelColorEmpty
      // 
      resources.ApplyResources(this.LabelColorEmpty, "LabelColorEmpty");
      this.LabelColorEmpty.Name = "LabelColorEmpty";
      // 
      // EditCalendarColorEmpty
      // 
      this.EditCalendarColorEmpty.BackColor = System.Drawing.Color.White;
      this.EditCalendarColorEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCalendarColorEmpty, "EditCalendarColorEmpty");
      this.EditCalendarColorEmpty.Name = "EditCalendarColorEmpty";
      this.EditCalendarColorEmpty.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditCalendarColorEmpty_MouseClick);
      // 
      // ActionMonthViewThemeDark
      // 
      this.ActionMonthViewThemeDark.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionMonthViewThemeDark, "ActionMonthViewThemeDark");
      this.ActionMonthViewThemeDark.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionMonthViewThemeDark.LinkColor = System.Drawing.Color.Navy;
      this.ActionMonthViewThemeDark.Name = "ActionMonthViewThemeDark";
      this.ActionMonthViewThemeDark.TabStop = true;
      this.ActionMonthViewThemeDark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionMonthViewThemeDark_LinkClicked);
      // 
      // ActionMonthViewThemeLight
      // 
      this.ActionMonthViewThemeLight.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionMonthViewThemeLight, "ActionMonthViewThemeLight");
      this.ActionMonthViewThemeLight.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionMonthViewThemeLight.LinkColor = System.Drawing.Color.Navy;
      this.ActionMonthViewThemeLight.Name = "ActionMonthViewThemeLight";
      this.ActionMonthViewThemeLight.TabStop = true;
      this.ActionMonthViewThemeLight.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionMonthViewThemeLight_LinkClicked);
      // 
      // LabelColorFullMoon
      // 
      resources.ApplyResources(this.LabelColorFullMoon, "LabelColorFullMoon");
      this.LabelColorFullMoon.Name = "LabelColorFullMoon";
      // 
      // EditCalendarColorFullMoon
      // 
      this.EditCalendarColorFullMoon.BackColor = System.Drawing.Color.DarkGoldenrod;
      this.EditCalendarColorFullMoon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCalendarColorFullMoon, "EditCalendarColorFullMoon");
      this.EditCalendarColorFullMoon.Name = "EditCalendarColorFullMoon";
      this.EditCalendarColorFullMoon.Click += new System.EventHandler(this.PanelFullMoonColor_Click);
      // 
      // LabelColorMoon
      // 
      resources.ApplyResources(this.LabelColorMoon, "LabelColorMoon");
      this.LabelColorMoon.Name = "LabelColorMoon";
      // 
      // EditCalendarColorMoon
      // 
      this.EditCalendarColorMoon.BackColor = System.Drawing.Color.DarkBlue;
      this.EditCalendarColorMoon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCalendarColorMoon, "EditCalendarColorMoon");
      this.EditCalendarColorMoon.Name = "EditCalendarColorMoon";
      this.EditCalendarColorMoon.Click += new System.EventHandler(this.PanelMoonEventColor_Click);
      // 
      // LabelColorSeason
      // 
      resources.ApplyResources(this.LabelColorSeason, "LabelColorSeason");
      this.LabelColorSeason.Name = "LabelColorSeason";
      // 
      // EditCalendarColorSeason
      // 
      this.EditCalendarColorSeason.BackColor = System.Drawing.Color.DarkGreen;
      this.EditCalendarColorSeason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCalendarColorSeason, "EditCalendarColorSeason");
      this.EditCalendarColorSeason.Name = "EditCalendarColorSeason";
      this.EditCalendarColorSeason.Click += new System.EventHandler(this.PanelSeasonEventColor_Click);
      // 
      // LabelColorTorah
      // 
      resources.ApplyResources(this.LabelColorTorah, "LabelColorTorah");
      this.LabelColorTorah.Name = "LabelColorTorah";
      // 
      // EditCalendarColorTorahEvent
      // 
      this.EditCalendarColorTorahEvent.BackColor = System.Drawing.Color.DarkRed;
      this.EditCalendarColorTorahEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCalendarColorTorahEvent, "EditCalendarColorTorahEvent");
      this.EditCalendarColorTorahEvent.Name = "EditCalendarColorTorahEvent";
      this.EditCalendarColorTorahEvent.Click += new System.EventHandler(this.PanelTorahEventColor_Click);
      // 
      // LabelColorTodayBack
      // 
      resources.ApplyResources(this.LabelColorTodayBack, "LabelColorTodayBack");
      this.LabelColorTodayBack.Name = "LabelColorTodayBack";
      // 
      // LabelColorToday
      // 
      resources.ApplyResources(this.LabelColorToday, "LabelColorToday");
      this.LabelColorToday.Name = "LabelColorToday";
      // 
      // EditCurrentDayBackColor
      // 
      this.EditCurrentDayBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.EditCurrentDayBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCurrentDayBackColor, "EditCurrentDayBackColor");
      this.EditCurrentDayBackColor.Name = "EditCurrentDayBackColor";
      this.EditCurrentDayBackColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelCurrentDayBackColor_MouseClick);
      // 
      // EditCurrentDayForeColor
      // 
      this.EditCurrentDayForeColor.BackColor = System.Drawing.Color.White;
      this.EditCurrentDayForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.EditCurrentDayForeColor, "EditCurrentDayForeColor");
      this.EditCurrentDayForeColor.Name = "EditCurrentDayForeColor";
      this.EditCurrentDayForeColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelCurrentDayColor_MouseClick);
      // 
      // GroupBoxSystem
      // 
      this.GroupBoxSystem.Controls.Add(this.ActionSelectHebrewLettersPath);
      this.GroupBoxSystem.Controls.Add(LabelHebrewLettersPath);
      this.GroupBoxSystem.Controls.Add(this.EditHebrewLettersPath);
      this.GroupBoxSystem.Controls.Add(this.EditVacuumAtStartup);
      this.GroupBoxSystem.Controls.Add(this.ActionSelectLangFR);
      this.GroupBoxSystem.Controls.Add(this.ActionSelectLangEN);
      this.GroupBoxSystem.Controls.Add(this.EditAutoOpenExportFolder);
      this.GroupBoxSystem.Controls.Add(this.EditShowReminderInTaskBar);
      this.GroupBoxSystem.Controls.Add(this.EditStartupHide);
      this.GroupBoxSystem.Controls.Add(this.EditCheckUpdateAtStartup);
      this.GroupBoxSystem.Controls.Add(this.EditDebuggerEnabled);
      this.GroupBoxSystem.Controls.Add(this.EditWebLinksMenuEnabled);
      this.GroupBoxSystem.Controls.Add(this.EditMonthViewSunToolTips);
      resources.ApplyResources(this.GroupBoxSystem, "GroupBoxSystem");
      this.GroupBoxSystem.Name = "GroupBoxSystem";
      this.GroupBoxSystem.TabStop = false;
      // 
      // ActionSelectHebrewLettersPath
      // 
      this.ActionSelectHebrewLettersPath.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSelectHebrewLettersPath, "ActionSelectHebrewLettersPath");
      this.ActionSelectHebrewLettersPath.Name = "ActionSelectHebrewLettersPath";
      this.ActionSelectHebrewLettersPath.UseVisualStyleBackColor = true;
      this.ActionSelectHebrewLettersPath.Click += new System.EventHandler(this.ActionSelectHebrewLettersPath_Click);
      // 
      // EditHebrewLettersPath
      // 
      this.EditHebrewLettersPath.BackColor = System.Drawing.SystemColors.Control;
      this.EditHebrewLettersPath.CaretAfterPaste = Ordisoftware.HebrewCommon.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditHebrewLettersPath, "EditHebrewLettersPath");
      this.EditHebrewLettersPath.Name = "EditHebrewLettersPath";
      this.EditHebrewLettersPath.ReadOnly = true;
      // 
      // EditVacuumAtStartup
      // 
      resources.ApplyResources(this.EditVacuumAtStartup, "EditVacuumAtStartup");
      this.EditVacuumAtStartup.Name = "EditVacuumAtStartup";
      this.EditVacuumAtStartup.UseVisualStyleBackColor = true;
      // 
      // ActionSelectLangFR
      // 
      this.ActionSelectLangFR.AllowDrop = true;
      this.ActionSelectLangFR.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      resources.ApplyResources(this.ActionSelectLangFR, "ActionSelectLangFR");
      this.ActionSelectLangFR.Name = "ActionSelectLangFR";
      this.ActionSelectLangFR.TabStop = false;
      this.ActionSelectLangFR.UseVisualStyleBackColor = true;
      this.ActionSelectLangFR.Click += new System.EventHandler(this.ActionSelectLangFR_Click);
      // 
      // ActionSelectLangEN
      // 
      this.ActionSelectLangEN.AllowDrop = true;
      this.ActionSelectLangEN.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
      resources.ApplyResources(this.ActionSelectLangEN, "ActionSelectLangEN");
      this.ActionSelectLangEN.Name = "ActionSelectLangEN";
      this.ActionSelectLangEN.TabStop = false;
      this.ActionSelectLangEN.UseVisualStyleBackColor = true;
      this.ActionSelectLangEN.Click += new System.EventHandler(this.ActionSelectLangEN_Click);
      // 
      // EditAutoOpenExportFolder
      // 
      resources.ApplyResources(this.EditAutoOpenExportFolder, "EditAutoOpenExportFolder");
      this.EditAutoOpenExportFolder.Name = "EditAutoOpenExportFolder";
      this.EditAutoOpenExportFolder.UseVisualStyleBackColor = true;
      // 
      // EditShowReminderInTaskBar
      // 
      resources.ApplyResources(this.EditShowReminderInTaskBar, "EditShowReminderInTaskBar");
      this.EditShowReminderInTaskBar.Name = "EditShowReminderInTaskBar";
      this.EditShowReminderInTaskBar.UseVisualStyleBackColor = true;
      // 
      // EditCheckUpdateAtStartup
      // 
      resources.ApplyResources(this.EditCheckUpdateAtStartup, "EditCheckUpdateAtStartup");
      this.EditCheckUpdateAtStartup.Name = "EditCheckUpdateAtStartup";
      this.EditCheckUpdateAtStartup.UseVisualStyleBackColor = true;
      // 
      // EditDebuggerEnabled
      // 
      resources.ApplyResources(this.EditDebuggerEnabled, "EditDebuggerEnabled");
      this.EditDebuggerEnabled.Name = "EditDebuggerEnabled";
      this.EditDebuggerEnabled.UseVisualStyleBackColor = true;
      this.EditDebuggerEnabled.CheckedChanged += new System.EventHandler(this.EditDebuggerEnabled_CheckedChanged);
      // 
      // EditWebLinksMenuEnabled
      // 
      resources.ApplyResources(this.EditWebLinksMenuEnabled, "EditWebLinksMenuEnabled");
      this.EditWebLinksMenuEnabled.Name = "EditWebLinksMenuEnabled";
      this.EditWebLinksMenuEnabled.UseVisualStyleBackColor = true;
      // 
      // OpenFileDialog
      // 
      resources.ApplyResources(this.OpenFileDialog, "OpenFileDialog");
      // 
      // GroupBoxMoonDayTextFormat
      // 
      this.GroupBoxMoonDayTextFormat.Controls.Add(this.ActionMoonDayTextFormatReset);
      this.GroupBoxMoonDayTextFormat.Controls.Add(this.ActionMoonDayTextFormatHelp);
      this.GroupBoxMoonDayTextFormat.Controls.Add(this.EditMoonDayTextFormat);
      resources.ApplyResources(this.GroupBoxMoonDayTextFormat, "GroupBoxMoonDayTextFormat");
      this.GroupBoxMoonDayTextFormat.Name = "GroupBoxMoonDayTextFormat";
      this.GroupBoxMoonDayTextFormat.TabStop = false;
      // 
      // ActionMoonDayTextFormatReset
      // 
      this.ActionMoonDayTextFormatReset.AllowDrop = true;
      this.ActionMoonDayTextFormatReset.ContextMenuStrip = this.MenuSelectMoonDayTextFormat;
      this.ActionMoonDayTextFormatReset.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionMoonDayTextFormatReset, "ActionMoonDayTextFormatReset");
      this.ActionMoonDayTextFormatReset.Name = "ActionMoonDayTextFormatReset";
      this.ActionMoonDayTextFormatReset.UseVisualStyleBackColor = true;
      this.ActionMoonDayTextFormatReset.Click += new System.EventHandler(this.ActionMoonDayTextFormatReset_Click);
      // 
      // MenuSelectMoonDayTextFormat
      // 
      this.MenuSelectMoonDayTextFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nissan11ToolStripMenuItem,
            this.nissan11ToolStripMenuItem1,
            this.nissanToolStripMenuItem,
            this.nissan1ToolStripMenuItem});
      this.MenuSelectMoonDayTextFormat.Name = "MenuSelectMoonDayTextFormat";
      this.MenuSelectMoonDayTextFormat.ShowImageMargin = false;
      resources.ApplyResources(this.MenuSelectMoonDayTextFormat, "MenuSelectMoonDayTextFormat");
      // 
      // nissan11ToolStripMenuItem
      // 
      this.nissan11ToolStripMenuItem.Name = "nissan11ToolStripMenuItem";
      resources.ApplyResources(this.nissan11ToolStripMenuItem, "nissan11ToolStripMenuItem");
      this.nissan11ToolStripMenuItem.Tag = "%MONTHNAME% [%MONTHNUM%] #%DAYNUM%";
      this.nissan11ToolStripMenuItem.Click += new System.EventHandler(this.MenuSelectMoonDayTextFormat_Click);
      // 
      // nissan11ToolStripMenuItem1
      // 
      this.nissan11ToolStripMenuItem1.Name = "nissan11ToolStripMenuItem1";
      resources.ApplyResources(this.nissan11ToolStripMenuItem1, "nissan11ToolStripMenuItem1");
      this.nissan11ToolStripMenuItem1.Tag = "%MONTHNAME% (%MONTHNUM%) #%DAYNUM%";
      this.nissan11ToolStripMenuItem1.Click += new System.EventHandler(this.MenuSelectMoonDayTextFormat_Click);
      // 
      // nissanToolStripMenuItem
      // 
      this.nissanToolStripMenuItem.Name = "nissanToolStripMenuItem";
      resources.ApplyResources(this.nissanToolStripMenuItem, "nissanToolStripMenuItem");
      this.nissanToolStripMenuItem.Tag = "%MONTHNAME% #%DAYNUM%";
      this.nissanToolStripMenuItem.Click += new System.EventHandler(this.MenuSelectMoonDayTextFormat_Click);
      // 
      // nissan1ToolStripMenuItem
      // 
      this.nissan1ToolStripMenuItem.Name = "nissan1ToolStripMenuItem";
      resources.ApplyResources(this.nissan1ToolStripMenuItem, "nissan1ToolStripMenuItem");
      this.nissan1ToolStripMenuItem.Tag = "%MONTHNAME% %DAYNUM%";
      this.nissan1ToolStripMenuItem.Click += new System.EventHandler(this.MenuSelectMoonDayTextFormat_Click);
      // 
      // ActionMoonDayTextFormatHelp
      // 
      this.ActionMoonDayTextFormatHelp.AllowDrop = true;
      this.ActionMoonDayTextFormatHelp.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionMoonDayTextFormatHelp, "ActionMoonDayTextFormatHelp");
      this.ActionMoonDayTextFormatHelp.Name = "ActionMoonDayTextFormatHelp";
      this.ActionMoonDayTextFormatHelp.UseVisualStyleBackColor = true;
      this.ActionMoonDayTextFormatHelp.Click += new System.EventHandler(this.ActionMoonDayTextFormatHelp_Click);
      // 
      // EditMoonDayTextFormat
      // 
      this.EditMoonDayTextFormat.BackColor = System.Drawing.SystemColors.Window;
      this.EditMoonDayTextFormat.CaretAfterPaste = Ordisoftware.HebrewCommon.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditMoonDayTextFormat, "EditMoonDayTextFormat");
      this.EditMoonDayTextFormat.Name = "EditMoonDayTextFormat";
      this.EditMoonDayTextFormat.TextChanged += new System.EventHandler(this.EditMoonDayTextFormat_TextChanged);
      // 
      // PreferencesForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.GroupBoxSystem);
      this.Controls.Add(this.GroupBoxReminder);
      this.Controls.Add(this.GroupBoxTrayIcon);
      this.Controls.Add(this.GroupBoxTextReport);
      this.Controls.Add(this.GroupBoxMonth);
      this.Controls.Add(this.GroupBoxMoonDayTextFormat);
      this.Controls.Add(this.GroupBoxNavigation);
      this.Controls.Add(this.BroupBoxShabat);
      this.Controls.Add(this.GroupBoxGPS);
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
      this.Shown += new System.EventHandler(this.PreferencesForm_Shown);
      this.PanelButtons.ResumeLayout(false);
      this.PanelButtons.PerformLayout();
      this.GroupBoxGPS.ResumeLayout(false);
      this.GroupBoxGPS.PerformLayout();
      this.GroupBoxTextReport.ResumeLayout(false);
      this.GroupBoxTextReport.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditMonthViewFontSize)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).EndInit();
      this.BroupBoxShabat.ResumeLayout(false);
      this.BroupBoxShabat.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatHoursBefore)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatEveryMinutes)).EndInit();
      this.GroupBoxNavigation.ResumeLayout(false);
      this.GroupBoxNavigation.PerformLayout();
      this.GroupBoxTrayIcon.ResumeLayout(false);
      this.GroupBoxTrayIcon.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditBalloonLoomingDelay)).EndInit();
      this.GroupBoxReminder.ResumeLayout(false);
      this.GroupBoxReminder.PerformLayout();
      this.PanelReminderColors.ResumeLayout(false);
      this.PanelReminderColors.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditReminderCelebrationsInterval)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditAutoLockSessionTimeOut)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindCelebrationHoursBefore)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindCelebrationEveryMinutes)).EndInit();
      this.GroupBoxMonth.ResumeLayout(false);
      this.GroupBoxMonth.PerformLayout();
      this.GroupBoxSystem.ResumeLayout(false);
      this.GroupBoxSystem.PerformLayout();
      this.GroupBoxMoonDayTextFormat.ResumeLayout(false);
      this.GroupBoxMoonDayTextFormat.PerformLayout();
      this.MenuSelectMoonDayTextFormat.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ColorDialog DialogColor;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Label LabelShabatDay;
    private System.Windows.Forms.Label LabelFontSize;
    private System.Windows.Forms.Label LabelFontName;
    private System.Windows.Forms.ComboBox EditFontName;
    private System.Windows.Forms.ComboBox EditShabatDay;
    private Ordisoftware.HebrewCommon.UndoRedoTextBox EditGPSLatitude;
    private Ordisoftware.HebrewCommon.UndoRedoTextBox EditGPSLongitude;
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.LinkLabel ActionUsePersonalShabat;
    private System.Windows.Forms.GroupBox GroupBoxGPS;
    private System.Windows.Forms.GroupBox GroupBoxTextReport;
    private System.Windows.Forms.GroupBox BroupBoxShabat;
    private System.Windows.Forms.GroupBox GroupBoxNavigation;
    private System.Windows.Forms.Label LabelTopColor;
    private System.Windows.Forms.Label LabelBottomColor;
    private System.Windows.Forms.Label LabelMiddleColor;
    private System.Windows.Forms.LinkLabel ActionUseSystemColors;
    internal System.Windows.Forms.Panel EditNavigateTopColor;
    internal System.Windows.Forms.Panel EditNavigateBottomColor;
    internal System.Windows.Forms.Panel EditNavigateMiddleColor;
    private System.Windows.Forms.LinkLabel ActionUseDefaultColors;
    private System.Windows.Forms.GroupBox GroupBoxTrayIcon;
    private System.Windows.Forms.RadioButton SelectOpenNavigationForm;
    private System.Windows.Forms.RadioButton SelectOpenMainForm;
    private System.Windows.Forms.CheckBox EditStartupHide;
    private System.Windows.Forms.GroupBox GroupBoxReminder;
    private System.Windows.Forms.NumericUpDown EditReminderCelebrationsInterval;
    private System.Windows.Forms.Label LabelTimerInterval;
    private System.Windows.Forms.CheckBox EditReminderCelebrationsEnabled;
    private System.Windows.Forms.CheckedListBox EditEvents;
    private System.Windows.Forms.CheckBox EditReminderShabatEnabled;
    private System.Windows.Forms.CheckBox EditMonthViewSunToolTips;
    private System.Windows.Forms.LinkLabel ActionUseBlackAndWhiteColors;
    private System.Windows.Forms.GroupBox GroupBoxMonth;
    private System.Windows.Forms.Label LabelColorToday;
    internal System.Windows.Forms.Panel EditCurrentDayForeColor;
    private System.Windows.Forms.NumericUpDown EditFontSize;
    private System.Windows.Forms.Label LabelBackColor;
    internal System.Windows.Forms.Panel EditTextColor;
    private System.Windows.Forms.Label LabelTextColor;
    internal System.Windows.Forms.Panel EditTextBackground;
    private System.Windows.Forms.Label LabelColorMoon;
    internal System.Windows.Forms.Panel EditCalendarColorMoon;
    private System.Windows.Forms.Label LabelColorSeason;
    internal System.Windows.Forms.Panel EditCalendarColorSeason;
    internal System.Windows.Forms.Panel EditCalendarColorTorahEvent;
    private System.Windows.Forms.Label LabelColorFullMoon;
    internal System.Windows.Forms.Panel EditCalendarColorFullMoon;
    private System.Windows.Forms.Label LabelColorTorah;
    private System.Windows.Forms.LinkLabel ActionMonthViewThemeLight;
    private System.Windows.Forms.NumericUpDown EditRemindShabatHoursBefore;
    private System.Windows.Forms.CheckBox EditRemindShabatOnlyLight;
    private System.Windows.Forms.NumericUpDown EditRemindShabatEveryMinutes;
    private System.Windows.Forms.GroupBox GroupBoxSystem;
    private System.Windows.Forms.Label LabelRemindShabatHoursBefore;
    private System.Windows.Forms.Label LabelRemindShabatEveryMinutes;
    private System.Windows.Forms.CheckBox EditCheckUpdateAtStartup;
    private System.Windows.Forms.Button ActionSelectLangFR;
    private System.Windows.Forms.Button ActionSelectLangEN;
    private System.Windows.Forms.Label LabelRemindCelebrationHoursBefore;
    private System.Windows.Forms.Label LabelRemindCelebrationEveryMinutes;
    private System.Windows.Forms.NumericUpDown EditRemindCelebrationHoursBefore;
    private System.Windows.Forms.NumericUpDown EditRemindCelebrationEveryMinutes;
    private System.Windows.Forms.CheckedListBox EditEventsDay;
    private System.Windows.Forms.LinkLabel ActionGetGPS;
    private System.Windows.Forms.CheckBox EditBalloon;
    private System.Windows.Forms.CheckBox EditShowReminderInTaskBar;
    private System.Windows.Forms.CheckBox EditBalloonAutoHide;
    private System.Windows.Forms.LinkLabel ActionResetSettings;
    private System.Windows.Forms.Label label1;
    internal System.Windows.Forms.Panel EditEventColorTorah;
    private System.Windows.Forms.CheckBox EditUseColors;
    private System.Windows.Forms.Label label2;
    internal System.Windows.Forms.Panel EditEventColorShabat;
    private System.Windows.Forms.Label label3;
    internal System.Windows.Forms.Panel EditEventColorSeason;
    private System.Windows.Forms.Label LabelColorTodayBack;
    internal System.Windows.Forms.Panel EditCurrentDayBackColor;
    private System.Windows.Forms.Label label4;
    internal System.Windows.Forms.Panel EditEventColorNext;
    private System.Windows.Forms.Label label5;
    internal System.Windows.Forms.Panel EditEventColorMonth;
    private System.Windows.Forms.CheckBox EditTorahEventsCountAsMoon;
    private System.Windows.Forms.NumericUpDown EditBalloonLoomingDelay;
    private System.Windows.Forms.Label LabelLoomingDelay;
    private System.Windows.Forms.Label LabelRemindAutoLockTimeOut;
    private System.Windows.Forms.NumericUpDown EditAutoLockSessionTimeOut;
    private System.Windows.Forms.CheckBox EditAutoLockSession;
    private System.Windows.Forms.NumericUpDown EditMonthViewFontSize;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox EditAutoOpenExportFolder;
    private System.Windows.Forms.CheckBox EditVacuumAtStartup;
    private System.Windows.Forms.Button ActionSelectHebrewLettersPath;
    private Ordisoftware.HebrewCommon.UndoRedoTextBox EditHebrewLettersPath;
    private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    private System.Windows.Forms.CheckBox EditDebuggerEnabled;
    private System.Windows.Forms.Label LabelColorText;
    internal System.Windows.Forms.Panel EditCalendarColorDefaultText;
    private System.Windows.Forms.Label LabelColorEmpty;
    internal System.Windows.Forms.Panel EditCalendarColorEmpty;
    private System.Windows.Forms.LinkLabel ActionMonthViewThemeDark;
    private System.Windows.Forms.Label LabelColorNoDay;
    internal System.Windows.Forms.Panel EditCalendarColorNoDay;
    private System.Windows.Forms.Panel PanelReminderColors;
    private System.Windows.Forms.GroupBox GroupBoxMoonDayTextFormat;
    private Ordisoftware.HebrewCommon.UndoRedoTextBox EditMoonDayTextFormat;
    private System.Windows.Forms.Button ActionMoonDayTextFormatReset;
    private System.Windows.Forms.Button ActionMoonDayTextFormatHelp;
    private Ordisoftware.HebrewCommon.UndoRedoTextBox EditTimeZone;
    private System.Windows.Forms.ContextMenuStrip MenuSelectMoonDayTextFormat;
    private System.Windows.Forms.ToolStripMenuItem nissan11ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem nissan11ToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem nissanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem nissan1ToolStripMenuItem;
    private System.Windows.Forms.CheckBox EditWebLinksMenuEnabled;
  }
}
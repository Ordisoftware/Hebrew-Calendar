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
      this.DialogColor = new System.Windows.Forms.ColorDialog();
      this.ButtonClose = new System.Windows.Forms.Button();
      this.EditFontName = new System.Windows.Forms.ComboBox();
      this.BindingSettings = new System.Windows.Forms.BindingSource(this.components);
      this.LabelShabatDay = new System.Windows.Forms.Label();
      this.LabelFontSize = new System.Windows.Forms.Label();
      this.EditShabatDay = new System.Windows.Forms.ComboBox();
      this.LabelFontName = new System.Windows.Forms.Label();
      this.EditGPSLatitude = new System.Windows.Forms.TextBox();
      this.EditGPSLongitude = new System.Windows.Forms.TextBox();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionUsePersonalShabat = new System.Windows.Forms.LinkLabel();
      this.GroupBoxGPS = new System.Windows.Forms.GroupBox();
      this.GroupBoxTextReport = new System.Windows.Forms.GroupBox();
      this.EditFontSize = new System.Windows.Forms.NumericUpDown();
      this.LabelBackColor = new System.Windows.Forms.Label();
      this.PanelTextColor = new System.Windows.Forms.Panel();
      this.LabelTextColor = new System.Windows.Forms.Label();
      this.PanelBackColor = new System.Windows.Forms.Panel();
      this.BroupBoxShabat = new System.Windows.Forms.GroupBox();
      this.LabelRemindShabatHoursBefore = new System.Windows.Forms.Label();
      this.LabelRemindShabatEveryMinutes = new System.Windows.Forms.Label();
      this.EditRemindShabatOnlyLight = new System.Windows.Forms.CheckBox();
      this.EditRemindShabatHoursBefore = new System.Windows.Forms.NumericUpDown();
      this.EditRemindShabatEveryMinutes = new System.Windows.Forms.NumericUpDown();
      this.EditRemindShabat = new System.Windows.Forms.CheckBox();
      this.GroupBoxNavigation = new System.Windows.Forms.GroupBox();
      this.ActionUseBlackAndWhiteColors = new System.Windows.Forms.LinkLabel();
      this.ActionUseDefaultColors = new System.Windows.Forms.LinkLabel();
      this.LabelTopColor = new System.Windows.Forms.Label();
      this.ActionUseSystemColors = new System.Windows.Forms.LinkLabel();
      this.PanelTopColor = new System.Windows.Forms.Panel();
      this.PanelBottomColor = new System.Windows.Forms.Panel();
      this.PanelMiddleColor = new System.Windows.Forms.Panel();
      this.LabelBottomColor = new System.Windows.Forms.Label();
      this.LabelMiddleColor = new System.Windows.Forms.Label();
      this.GroupBoxTrayIcon = new System.Windows.Forms.GroupBox();
      this.SelectOpenNavigationForm = new System.Windows.Forms.RadioButton();
      this.SelectOpenMainForm = new System.Windows.Forms.RadioButton();
      this.EditStartupHide = new System.Windows.Forms.CheckBox();
      this.GroupBoxReminder = new System.Windows.Forms.GroupBox();
      this.EditEvents = new System.Windows.Forms.CheckedListBox();
      this.EditTimerInterval = new System.Windows.Forms.NumericUpDown();
      this.LabelTimerInterval = new System.Windows.Forms.Label();
      this.EditTimerEnabled = new System.Windows.Forms.CheckBox();
      this.EditShowMonthDayToolTip = new System.Windows.Forms.CheckBox();
      this.GroupBoxCalendar = new System.Windows.Forms.GroupBox();
      this.ActionRestoreCalendarColors = new System.Windows.Forms.LinkLabel();
      this.LabelColorFullMoon = new System.Windows.Forms.Label();
      this.PanelFullMoonColor = new System.Windows.Forms.Panel();
      this.LabelColorMoon = new System.Windows.Forms.Label();
      this.PanelMoonEventColor = new System.Windows.Forms.Panel();
      this.LabelColorSeason = new System.Windows.Forms.Label();
      this.PanelSeasonEventColor = new System.Windows.Forms.Panel();
      this.LabelColorTorah = new System.Windows.Forms.Label();
      this.PanelTorahEventColor = new System.Windows.Forms.Panel();
      this.LabelColorToday = new System.Windows.Forms.Label();
      this.PanelCurrentDayColor = new System.Windows.Forms.Panel();
      this.GroupBoxSystem = new System.Windows.Forms.GroupBox();
      this.EditCheckUpdateAtStartup = new System.Windows.Forms.CheckBox();
      LabelGPSLatitude = new System.Windows.Forms.Label();
      LabelGPSLongitude = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSettings)).BeginInit();
      this.PanelButtons.SuspendLayout();
      this.GroupBoxGPS.SuspendLayout();
      this.GroupBoxTextReport.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).BeginInit();
      this.BroupBoxShabat.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatHoursBefore)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatEveryMinutes)).BeginInit();
      this.GroupBoxNavigation.SuspendLayout();
      this.GroupBoxTrayIcon.SuspendLayout();
      this.GroupBoxReminder.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditTimerInterval)).BeginInit();
      this.GroupBoxCalendar.SuspendLayout();
      this.GroupBoxSystem.SuspendLayout();
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
      // DialogColor
      // 
      this.DialogColor.FullOpen = true;
      // 
      // ButtonClose
      // 
      resources.ApplyResources(this.ButtonClose, "ButtonClose");
      this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ButtonClose.Name = "ButtonClose";
      this.ButtonClose.UseVisualStyleBackColor = true;
      // 
      // EditFontName
      // 
      resources.ApplyResources(this.EditFontName, "EditFontName");
      this.EditFontName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSettings, "FontName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.EditFontName.FormattingEnabled = true;
      this.EditFontName.Name = "EditFontName";
      this.EditFontName.SelectedIndexChanged += new System.EventHandler(this.EitFontName_Changed);
      // 
      // BindingSettings
      // 
      this.BindingSettings.DataSource = typeof(System.Configuration.ApplicationSettingsBase);
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
      resources.ApplyResources(this.EditShabatDay, "EditShabatDay");
      this.EditShabatDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.EditShabatDay.FormattingEnabled = true;
      this.EditShabatDay.Name = "EditShabatDay";
      this.EditShabatDay.SelectedIndexChanged += new System.EventHandler(this.remindShabat_ValueChanged);
      // 
      // LabelFontName
      // 
      resources.ApplyResources(this.LabelFontName, "LabelFontName");
      this.LabelFontName.Name = "LabelFontName";
      // 
      // EditGPSLatitude
      // 
      resources.ApplyResources(this.EditGPSLatitude, "EditGPSLatitude");
      this.EditGPSLatitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSettings, "Latitude", true));
      this.EditGPSLatitude.Name = "EditGPSLatitude";
      // 
      // EditGPSLongitude
      // 
      resources.ApplyResources(this.EditGPSLongitude, "EditGPSLongitude");
      this.EditGPSLongitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSettings, "Longitude", true));
      this.EditGPSLongitude.Name = "EditGPSLongitude";
      // 
      // PanelButtons
      // 
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Controls.Add(this.ButtonClose);
      this.PanelButtons.Name = "PanelButtons";
      // 
      // ActionUsePersonalShabat
      // 
      resources.ApplyResources(this.ActionUsePersonalShabat, "ActionUsePersonalShabat");
      this.ActionUsePersonalShabat.LinkColor = System.Drawing.Color.Blue;
      this.ActionUsePersonalShabat.Name = "ActionUsePersonalShabat";
      this.ActionUsePersonalShabat.TabStop = true;
      this.ActionUsePersonalShabat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionUsePersonalShabat_LinkClicked);
      // 
      // GroupBoxGPS
      // 
      resources.ApplyResources(this.GroupBoxGPS, "GroupBoxGPS");
      this.GroupBoxGPS.Controls.Add(this.EditGPSLatitude);
      this.GroupBoxGPS.Controls.Add(LabelGPSLatitude);
      this.GroupBoxGPS.Controls.Add(this.EditGPSLongitude);
      this.GroupBoxGPS.Controls.Add(LabelGPSLongitude);
      this.GroupBoxGPS.Name = "GroupBoxGPS";
      this.GroupBoxGPS.TabStop = false;
      // 
      // GroupBoxTextReport
      // 
      resources.ApplyResources(this.GroupBoxTextReport, "GroupBoxTextReport");
      this.GroupBoxTextReport.Controls.Add(this.EditFontSize);
      this.GroupBoxTextReport.Controls.Add(this.LabelFontName);
      this.GroupBoxTextReport.Controls.Add(this.LabelBackColor);
      this.GroupBoxTextReport.Controls.Add(this.PanelTextColor);
      this.GroupBoxTextReport.Controls.Add(this.LabelTextColor);
      this.GroupBoxTextReport.Controls.Add(this.PanelBackColor);
      this.GroupBoxTextReport.Controls.Add(this.EditFontName);
      this.GroupBoxTextReport.Controls.Add(this.LabelFontSize);
      this.GroupBoxTextReport.Name = "GroupBoxTextReport";
      this.GroupBoxTextReport.TabStop = false;
      // 
      // EditFontSize
      // 
      resources.ApplyResources(this.EditFontSize, "EditFontSize");
      this.EditFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BindingSettings, "FontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
      this.EditFontSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
      this.EditFontSize.Name = "EditFontSize";
      this.EditFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.EditFontSize.ValueChanged += new System.EventHandler(this.EitFontName_Changed);
      // 
      // LabelBackColor
      // 
      resources.ApplyResources(this.LabelBackColor, "LabelBackColor");
      this.LabelBackColor.Name = "LabelBackColor";
      // 
      // PanelTextColor
      // 
      resources.ApplyResources(this.PanelTextColor, "PanelTextColor");
      this.PanelTextColor.BackColor = System.Drawing.Color.Black;
      this.PanelTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelTextColor.Name = "PanelTextColor";
      this.PanelTextColor.Click += new System.EventHandler(this.PanelTextColor_Click);
      // 
      // LabelTextColor
      // 
      resources.ApplyResources(this.LabelTextColor, "LabelTextColor");
      this.LabelTextColor.Name = "LabelTextColor";
      // 
      // PanelBackColor
      // 
      resources.ApplyResources(this.PanelBackColor, "PanelBackColor");
      this.PanelBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.PanelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelBackColor.Name = "PanelBackColor";
      this.PanelBackColor.Click += new System.EventHandler(this.PanelBackColor_Click);
      // 
      // BroupBoxShabat
      // 
      resources.ApplyResources(this.BroupBoxShabat, "BroupBoxShabat");
      this.BroupBoxShabat.Controls.Add(this.LabelRemindShabatHoursBefore);
      this.BroupBoxShabat.Controls.Add(this.LabelRemindShabatEveryMinutes);
      this.BroupBoxShabat.Controls.Add(this.EditRemindShabatOnlyLight);
      this.BroupBoxShabat.Controls.Add(this.EditShabatDay);
      this.BroupBoxShabat.Controls.Add(this.EditRemindShabatHoursBefore);
      this.BroupBoxShabat.Controls.Add(this.ActionUsePersonalShabat);
      this.BroupBoxShabat.Controls.Add(this.LabelShabatDay);
      this.BroupBoxShabat.Controls.Add(this.EditRemindShabatEveryMinutes);
      this.BroupBoxShabat.Controls.Add(this.EditRemindShabat);
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
      this.EditRemindShabatOnlyLight.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BindingSettings, "RemindShabatOnlyLight", true));
      this.EditRemindShabatOnlyLight.Name = "EditRemindShabatOnlyLight";
      this.EditRemindShabatOnlyLight.UseVisualStyleBackColor = true;
      this.EditRemindShabatOnlyLight.CheckedChanged += new System.EventHandler(this.remindShabat_ValueChanged);
      // 
      // EditRemindShabatHoursBefore
      // 
      resources.ApplyResources(this.EditRemindShabatHoursBefore, "EditRemindShabatHoursBefore");
      this.EditRemindShabatHoursBefore.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BindingSettings, "RemindShabatHoursBefore", true));
      this.EditRemindShabatHoursBefore.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
      this.EditRemindShabatHoursBefore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.EditRemindShabatHoursBefore.Name = "EditRemindShabatHoursBefore";
      this.EditRemindShabatHoursBefore.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.EditRemindShabatHoursBefore.ValueChanged += new System.EventHandler(this.remindShabat_ValueChanged);
      // 
      // EditRemindShabatEveryMinutes
      // 
      resources.ApplyResources(this.EditRemindShabatEveryMinutes, "EditRemindShabatEveryMinutes");
      this.EditRemindShabatEveryMinutes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BindingSettings, "RemindShabatEveryMinutes", true));
      this.EditRemindShabatEveryMinutes.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.EditRemindShabatEveryMinutes.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.EditRemindShabatEveryMinutes.Name = "EditRemindShabatEveryMinutes";
      this.EditRemindShabatEveryMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.EditRemindShabatEveryMinutes.ValueChanged += new System.EventHandler(this.remindShabat_ValueChanged);
      // 
      // EditRemindShabat
      // 
      resources.ApplyResources(this.EditRemindShabat, "EditRemindShabat");
      this.EditRemindShabat.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BindingSettings, "RemindShabat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditRemindShabat.Name = "EditRemindShabat";
      this.EditRemindShabat.UseVisualStyleBackColor = true;
      this.EditRemindShabat.CheckedChanged += new System.EventHandler(this.remindShabat_ValueChanged);
      // 
      // GroupBoxNavigation
      // 
      resources.ApplyResources(this.GroupBoxNavigation, "GroupBoxNavigation");
      this.GroupBoxNavigation.Controls.Add(this.ActionUseBlackAndWhiteColors);
      this.GroupBoxNavigation.Controls.Add(this.ActionUseDefaultColors);
      this.GroupBoxNavigation.Controls.Add(this.LabelTopColor);
      this.GroupBoxNavigation.Controls.Add(this.ActionUseSystemColors);
      this.GroupBoxNavigation.Controls.Add(this.PanelTopColor);
      this.GroupBoxNavigation.Controls.Add(this.PanelBottomColor);
      this.GroupBoxNavigation.Controls.Add(this.PanelMiddleColor);
      this.GroupBoxNavigation.Controls.Add(this.LabelBottomColor);
      this.GroupBoxNavigation.Controls.Add(this.LabelMiddleColor);
      this.GroupBoxNavigation.Name = "GroupBoxNavigation";
      this.GroupBoxNavigation.TabStop = false;
      // 
      // ActionUseBlackAndWhiteColors
      // 
      resources.ApplyResources(this.ActionUseBlackAndWhiteColors, "ActionUseBlackAndWhiteColors");
      this.ActionUseBlackAndWhiteColors.LinkColor = System.Drawing.Color.Blue;
      this.ActionUseBlackAndWhiteColors.Name = "ActionUseBlackAndWhiteColors";
      this.ActionUseBlackAndWhiteColors.TabStop = true;
      this.ActionUseBlackAndWhiteColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionUseBlackAndWhiteColors_LinkClicked);
      // 
      // ActionUseDefaultColors
      // 
      resources.ApplyResources(this.ActionUseDefaultColors, "ActionUseDefaultColors");
      this.ActionUseDefaultColors.LinkColor = System.Drawing.Color.Blue;
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
      resources.ApplyResources(this.ActionUseSystemColors, "ActionUseSystemColors");
      this.ActionUseSystemColors.LinkColor = System.Drawing.Color.Blue;
      this.ActionUseSystemColors.Name = "ActionUseSystemColors";
      this.ActionUseSystemColors.TabStop = true;
      this.ActionUseSystemColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionUseSystemColors_LinkClicked);
      // 
      // PanelTopColor
      // 
      resources.ApplyResources(this.PanelTopColor, "PanelTopColor");
      this.PanelTopColor.BackColor = System.Drawing.Color.LemonChiffon;
      this.PanelTopColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelTopColor.Name = "PanelTopColor";
      this.PanelTopColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelTopColor_MouseClick);
      // 
      // PanelBottomColor
      // 
      resources.ApplyResources(this.PanelBottomColor, "PanelBottomColor");
      this.PanelBottomColor.BackColor = System.Drawing.Color.Honeydew;
      this.PanelBottomColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelBottomColor.Name = "PanelBottomColor";
      this.PanelBottomColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelBottomColor_MouseClick);
      // 
      // PanelMiddleColor
      // 
      resources.ApplyResources(this.PanelMiddleColor, "PanelMiddleColor");
      this.PanelMiddleColor.BackColor = System.Drawing.Color.AliceBlue;
      this.PanelMiddleColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelMiddleColor.Name = "PanelMiddleColor";
      this.PanelMiddleColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelMiddleColor_MouseClick);
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
      resources.ApplyResources(this.GroupBoxTrayIcon, "GroupBoxTrayIcon");
      this.GroupBoxTrayIcon.Controls.Add(this.SelectOpenNavigationForm);
      this.GroupBoxTrayIcon.Controls.Add(this.SelectOpenMainForm);
      this.GroupBoxTrayIcon.Name = "GroupBoxTrayIcon";
      this.GroupBoxTrayIcon.TabStop = false;
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
      // EditStartupHide
      // 
      resources.ApplyResources(this.EditStartupHide, "EditStartupHide");
      this.EditStartupHide.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BindingSettings, "StartupHide", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditStartupHide.Name = "EditStartupHide";
      this.EditStartupHide.UseVisualStyleBackColor = true;
      // 
      // GroupBoxReminder
      // 
      resources.ApplyResources(this.GroupBoxReminder, "GroupBoxReminder");
      this.GroupBoxReminder.Controls.Add(this.EditEvents);
      this.GroupBoxReminder.Controls.Add(this.EditTimerInterval);
      this.GroupBoxReminder.Controls.Add(this.LabelTimerInterval);
      this.GroupBoxReminder.Controls.Add(this.EditTimerEnabled);
      this.GroupBoxReminder.Name = "GroupBoxReminder";
      this.GroupBoxReminder.TabStop = false;
      // 
      // EditEvents
      // 
      resources.ApplyResources(this.EditEvents, "EditEvents");
      this.EditEvents.CheckOnClick = true;
      this.EditEvents.FormattingEnabled = true;
      this.EditEvents.Name = "EditEvents";
      // 
      // EditTimerInterval
      // 
      resources.ApplyResources(this.EditTimerInterval, "EditTimerInterval");
      this.EditTimerInterval.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BindingSettings, "ReminderInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditTimerInterval.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
      this.EditTimerInterval.Name = "EditTimerInterval";
      // 
      // LabelTimerInterval
      // 
      resources.ApplyResources(this.LabelTimerInterval, "LabelTimerInterval");
      this.LabelTimerInterval.Name = "LabelTimerInterval";
      // 
      // EditTimerEnabled
      // 
      resources.ApplyResources(this.EditTimerEnabled, "EditTimerEnabled");
      this.EditTimerEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BindingSettings, "ReminderEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditTimerEnabled.Name = "EditTimerEnabled";
      this.EditTimerEnabled.UseVisualStyleBackColor = true;
      this.EditTimerEnabled.CheckedChanged += new System.EventHandler(this.EditTimerEnabled_CheckedChanged);
      // 
      // EditShowMonthDayToolTip
      // 
      resources.ApplyResources(this.EditShowMonthDayToolTip, "EditShowMonthDayToolTip");
      this.EditShowMonthDayToolTip.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BindingSettings, "MonthViewSunToolTips", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditShowMonthDayToolTip.Name = "EditShowMonthDayToolTip";
      this.EditShowMonthDayToolTip.UseVisualStyleBackColor = true;
      // 
      // GroupBoxCalendar
      // 
      resources.ApplyResources(this.GroupBoxCalendar, "GroupBoxCalendar");
      this.GroupBoxCalendar.Controls.Add(this.ActionRestoreCalendarColors);
      this.GroupBoxCalendar.Controls.Add(this.LabelColorFullMoon);
      this.GroupBoxCalendar.Controls.Add(this.PanelFullMoonColor);
      this.GroupBoxCalendar.Controls.Add(this.LabelColorMoon);
      this.GroupBoxCalendar.Controls.Add(this.PanelMoonEventColor);
      this.GroupBoxCalendar.Controls.Add(this.LabelColorSeason);
      this.GroupBoxCalendar.Controls.Add(this.PanelSeasonEventColor);
      this.GroupBoxCalendar.Controls.Add(this.LabelColorTorah);
      this.GroupBoxCalendar.Controls.Add(this.PanelTorahEventColor);
      this.GroupBoxCalendar.Controls.Add(this.LabelColorToday);
      this.GroupBoxCalendar.Controls.Add(this.PanelCurrentDayColor);
      this.GroupBoxCalendar.Name = "GroupBoxCalendar";
      this.GroupBoxCalendar.TabStop = false;
      // 
      // ActionRestoreCalendarColors
      // 
      resources.ApplyResources(this.ActionRestoreCalendarColors, "ActionRestoreCalendarColors");
      this.ActionRestoreCalendarColors.LinkColor = System.Drawing.Color.Blue;
      this.ActionRestoreCalendarColors.Name = "ActionRestoreCalendarColors";
      this.ActionRestoreCalendarColors.TabStop = true;
      this.ActionRestoreCalendarColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionRestoreCalendarColors_LinkClicked);
      // 
      // LabelColorFullMoon
      // 
      resources.ApplyResources(this.LabelColorFullMoon, "LabelColorFullMoon");
      this.LabelColorFullMoon.Name = "LabelColorFullMoon";
      // 
      // PanelFullMoonColor
      // 
      resources.ApplyResources(this.PanelFullMoonColor, "PanelFullMoonColor");
      this.PanelFullMoonColor.BackColor = System.Drawing.Color.DarkGoldenrod;
      this.PanelFullMoonColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelFullMoonColor.Name = "PanelFullMoonColor";
      this.PanelFullMoonColor.Click += new System.EventHandler(this.PanelFullMoonColor_Click);
      // 
      // LabelColorMoon
      // 
      resources.ApplyResources(this.LabelColorMoon, "LabelColorMoon");
      this.LabelColorMoon.Name = "LabelColorMoon";
      // 
      // PanelMoonEventColor
      // 
      resources.ApplyResources(this.PanelMoonEventColor, "PanelMoonEventColor");
      this.PanelMoonEventColor.BackColor = System.Drawing.Color.DarkBlue;
      this.PanelMoonEventColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelMoonEventColor.Name = "PanelMoonEventColor";
      this.PanelMoonEventColor.Click += new System.EventHandler(this.PanelMoonEventColor_Click);
      // 
      // LabelColorSeason
      // 
      resources.ApplyResources(this.LabelColorSeason, "LabelColorSeason");
      this.LabelColorSeason.Name = "LabelColorSeason";
      // 
      // PanelSeasonEventColor
      // 
      resources.ApplyResources(this.PanelSeasonEventColor, "PanelSeasonEventColor");
      this.PanelSeasonEventColor.BackColor = System.Drawing.Color.DarkGreen;
      this.PanelSeasonEventColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelSeasonEventColor.Name = "PanelSeasonEventColor";
      this.PanelSeasonEventColor.Click += new System.EventHandler(this.PanelSeasonEventColor_Click);
      // 
      // LabelColorTorah
      // 
      resources.ApplyResources(this.LabelColorTorah, "LabelColorTorah");
      this.LabelColorTorah.Name = "LabelColorTorah";
      // 
      // PanelTorahEventColor
      // 
      resources.ApplyResources(this.PanelTorahEventColor, "PanelTorahEventColor");
      this.PanelTorahEventColor.BackColor = System.Drawing.Color.DarkRed;
      this.PanelTorahEventColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelTorahEventColor.Name = "PanelTorahEventColor";
      this.PanelTorahEventColor.Click += new System.EventHandler(this.PanelTorahEventColor_Click);
      // 
      // LabelColorToday
      // 
      resources.ApplyResources(this.LabelColorToday, "LabelColorToday");
      this.LabelColorToday.Name = "LabelColorToday";
      // 
      // PanelCurrentDayColor
      // 
      resources.ApplyResources(this.PanelCurrentDayColor, "PanelCurrentDayColor");
      this.PanelCurrentDayColor.BackColor = System.Drawing.Color.Red;
      this.PanelCurrentDayColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelCurrentDayColor.Name = "PanelCurrentDayColor";
      this.PanelCurrentDayColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelCurrentDayColor_MouseClick);
      // 
      // GroupBoxSystem
      // 
      resources.ApplyResources(this.GroupBoxSystem, "GroupBoxSystem");
      this.GroupBoxSystem.Controls.Add(this.EditStartupHide);
      this.GroupBoxSystem.Controls.Add(this.EditCheckUpdateAtStartup);
      this.GroupBoxSystem.Controls.Add(this.EditShowMonthDayToolTip);
      this.GroupBoxSystem.Name = "GroupBoxSystem";
      this.GroupBoxSystem.TabStop = false;
      // 
      // EditCheckUpdateAtStartup
      // 
      resources.ApplyResources(this.EditCheckUpdateAtStartup, "EditCheckUpdateAtStartup");
      this.EditCheckUpdateAtStartup.Checked = global::Ordisoftware.HebrewCalendar.Properties.Settings.Default.CheckUpdateAtStartup;
      this.EditCheckUpdateAtStartup.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditCheckUpdateAtStartup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.HebrewCalendar.Properties.Settings.Default, "CheckUpdateAtStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditCheckUpdateAtStartup.Name = "EditCheckUpdateAtStartup";
      this.EditCheckUpdateAtStartup.UseVisualStyleBackColor = true;
      // 
      // PreferencesForm
      // 
      this.AcceptButton = this.ButtonClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonClose;
      this.Controls.Add(this.GroupBoxSystem);
      this.Controls.Add(this.GroupBoxReminder);
      this.Controls.Add(this.GroupBoxTrayIcon);
      this.Controls.Add(this.GroupBoxTextReport);
      this.Controls.Add(this.GroupBoxCalendar);
      this.Controls.Add(this.GroupBoxNavigation);
      this.Controls.Add(this.BroupBoxShabat);
      this.Controls.Add(this.GroupBoxGPS);
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesForm";
      this.ShowInTaskbar = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
      this.Shown += new System.EventHandler(this.PreferencesForm_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.BindingSettings)).EndInit();
      this.PanelButtons.ResumeLayout(false);
      this.GroupBoxGPS.ResumeLayout(false);
      this.GroupBoxGPS.PerformLayout();
      this.GroupBoxTextReport.ResumeLayout(false);
      this.GroupBoxTextReport.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).EndInit();
      this.BroupBoxShabat.ResumeLayout(false);
      this.BroupBoxShabat.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatHoursBefore)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditRemindShabatEveryMinutes)).EndInit();
      this.GroupBoxNavigation.ResumeLayout(false);
      this.GroupBoxNavigation.PerformLayout();
      this.GroupBoxTrayIcon.ResumeLayout(false);
      this.GroupBoxTrayIcon.PerformLayout();
      this.GroupBoxReminder.ResumeLayout(false);
      this.GroupBoxReminder.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditTimerInterval)).EndInit();
      this.GroupBoxCalendar.ResumeLayout(false);
      this.GroupBoxCalendar.PerformLayout();
      this.GroupBoxSystem.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ColorDialog DialogColor;
    private System.Windows.Forms.Button ButtonClose;
    private System.Windows.Forms.Label LabelShabatDay;
    private System.Windows.Forms.Label LabelFontSize;
    private System.Windows.Forms.Label LabelFontName;
    private System.Windows.Forms.BindingSource BindingSettings;
    private System.Windows.Forms.ComboBox EditFontName;
    private System.Windows.Forms.ComboBox EditShabatDay;
    private System.Windows.Forms.TextBox EditGPSLatitude;
    private System.Windows.Forms.TextBox EditGPSLongitude;
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
    internal System.Windows.Forms.Panel PanelTopColor;
    internal System.Windows.Forms.Panel PanelBottomColor;
    internal System.Windows.Forms.Panel PanelMiddleColor;
    private System.Windows.Forms.LinkLabel ActionUseDefaultColors;
    private System.Windows.Forms.GroupBox GroupBoxTrayIcon;
    private System.Windows.Forms.RadioButton SelectOpenNavigationForm;
    private System.Windows.Forms.RadioButton SelectOpenMainForm;
    private System.Windows.Forms.CheckBox EditStartupHide;
    private System.Windows.Forms.GroupBox GroupBoxReminder;
    private System.Windows.Forms.NumericUpDown EditTimerInterval;
    private System.Windows.Forms.Label LabelTimerInterval;
    private System.Windows.Forms.CheckBox EditTimerEnabled;
    private System.Windows.Forms.CheckedListBox EditEvents;
    private System.Windows.Forms.CheckBox EditRemindShabat;
    private System.Windows.Forms.CheckBox EditShowMonthDayToolTip;
    private System.Windows.Forms.LinkLabel ActionUseBlackAndWhiteColors;
    private System.Windows.Forms.GroupBox GroupBoxCalendar;
    private System.Windows.Forms.Label LabelColorToday;
    internal System.Windows.Forms.Panel PanelCurrentDayColor;
    private System.Windows.Forms.NumericUpDown EditFontSize;
    private System.Windows.Forms.Label LabelBackColor;
    internal System.Windows.Forms.Panel PanelTextColor;
    private System.Windows.Forms.Label LabelTextColor;
    internal System.Windows.Forms.Panel PanelBackColor;
    private System.Windows.Forms.Label LabelColorMoon;
    internal System.Windows.Forms.Panel PanelMoonEventColor;
    private System.Windows.Forms.Label LabelColorSeason;
    internal System.Windows.Forms.Panel PanelSeasonEventColor;
    internal System.Windows.Forms.Panel PanelTorahEventColor;
    private System.Windows.Forms.Label LabelColorFullMoon;
    internal System.Windows.Forms.Panel PanelFullMoonColor;
    private System.Windows.Forms.Label LabelColorTorah;
    private System.Windows.Forms.LinkLabel ActionRestoreCalendarColors;
    private System.Windows.Forms.NumericUpDown EditRemindShabatHoursBefore;
    private System.Windows.Forms.CheckBox EditRemindShabatOnlyLight;
    private System.Windows.Forms.NumericUpDown EditRemindShabatEveryMinutes;
    private System.Windows.Forms.GroupBox GroupBoxSystem;
    private System.Windows.Forms.Label LabelRemindShabatHoursBefore;
    private System.Windows.Forms.Label LabelRemindShabatEveryMinutes;
    private System.Windows.Forms.CheckBox EditCheckUpdateAtStartup;
  }
}
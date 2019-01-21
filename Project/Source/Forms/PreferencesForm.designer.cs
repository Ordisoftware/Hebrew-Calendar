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
      System.Windows.Forms.Label GPSLatitudeLabel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
      System.Windows.Forms.Label GPSLongitudeLabel;
      this.DialogColor = new System.Windows.Forms.ColorDialog();
      this.ButtonClose = new System.Windows.Forms.Button();
      this.EditFontName = new System.Windows.Forms.ComboBox();
      this.BindingSettings = new System.Windows.Forms.BindingSource(this.components);
      this.LabelShabatDay = new System.Windows.Forms.Label();
      this.EditFontSize = new System.Windows.Forms.NumericUpDown();
      this.LabelFontSize = new System.Windows.Forms.Label();
      this.PanelBackColor = new System.Windows.Forms.Panel();
      this.LabelTextColor = new System.Windows.Forms.Label();
      this.EditShabatDay = new System.Windows.Forms.ComboBox();
      this.LabelFontName = new System.Windows.Forms.Label();
      this.PanelTextColor = new System.Windows.Forms.Panel();
      this.LabelBackColor = new System.Windows.Forms.Label();
      this.GPSLatitudeTextBox = new System.Windows.Forms.TextBox();
      this.GPSLongitudeTextBox = new System.Windows.Forms.TextBox();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionUsePersonalShabat = new System.Windows.Forms.LinkLabel();
      this.GroupBoxGPS = new System.Windows.Forms.GroupBox();
      this.GroupBoxText = new System.Windows.Forms.GroupBox();
      this.BroupBoxShabat = new System.Windows.Forms.GroupBox();
      this.GroupBoxNavigation = new System.Windows.Forms.GroupBox();
      this.ActionUseBlackAndWhiteColors = new System.Windows.Forms.LinkLabel();
      this.ActionUseDefaultColors = new System.Windows.Forms.LinkLabel();
      this.LabelTopColor = new System.Windows.Forms.Label();
      this.ActionUseSystemColors = new System.Windows.Forms.LinkLabel();
      this.PanelTopColor = new System.Windows.Forms.Panel();
      this.PanelBottomColor = new System.Windows.Forms.Panel();
      this.PanelMiddleColor = new System.Windows.Forms.Panel();
      this.labelBottomColor = new System.Windows.Forms.Label();
      this.LabelMiddleColor = new System.Windows.Forms.Label();
      this.GroupBoxTrayIcon = new System.Windows.Forms.GroupBox();
      this.RadioButtonNavigationForm = new System.Windows.Forms.RadioButton();
      this.RadioButtonMainForm = new System.Windows.Forms.RadioButton();
      this.EditStartupHide = new System.Windows.Forms.CheckBox();
      this.GroupBoxReminder = new System.Windows.Forms.GroupBox();
      this.EditRemindShabat = new System.Windows.Forms.CheckBox();
      this.EditEvents = new System.Windows.Forms.CheckedListBox();
      this.EditTimerInterval = new System.Windows.Forms.NumericUpDown();
      this.LabelTimerInterval = new System.Windows.Forms.Label();
      this.EditTimerEnabled = new System.Windows.Forms.CheckBox();
      this.EditShowMonthDayToolTip = new System.Windows.Forms.CheckBox();
      GPSLatitudeLabel = new System.Windows.Forms.Label();
      GPSLongitudeLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSettings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).BeginInit();
      this.PanelButtons.SuspendLayout();
      this.GroupBoxGPS.SuspendLayout();
      this.GroupBoxText.SuspendLayout();
      this.BroupBoxShabat.SuspendLayout();
      this.GroupBoxNavigation.SuspendLayout();
      this.GroupBoxTrayIcon.SuspendLayout();
      this.GroupBoxReminder.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditTimerInterval)).BeginInit();
      this.SuspendLayout();
      // 
      // GPSLatitudeLabel
      // 
      resources.ApplyResources(GPSLatitudeLabel, "GPSLatitudeLabel");
      GPSLatitudeLabel.Name = "GPSLatitudeLabel";
      // 
      // GPSLongitudeLabel
      // 
      resources.ApplyResources(GPSLongitudeLabel, "GPSLongitudeLabel");
      GPSLongitudeLabel.Name = "GPSLongitudeLabel";
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
      // LabelFontSize
      // 
      resources.ApplyResources(this.LabelFontSize, "LabelFontSize");
      this.LabelFontSize.Name = "LabelFontSize";
      // 
      // PanelBackColor
      // 
      resources.ApplyResources(this.PanelBackColor, "PanelBackColor");
      this.PanelBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.PanelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelBackColor.Name = "PanelBackColor";
      this.PanelBackColor.Click += new System.EventHandler(this.PanelBackColor_Click);
      // 
      // LabelTextColor
      // 
      resources.ApplyResources(this.LabelTextColor, "LabelTextColor");
      this.LabelTextColor.Name = "LabelTextColor";
      // 
      // EditShabatDay
      // 
      resources.ApplyResources(this.EditShabatDay, "EditShabatDay");
      this.EditShabatDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.EditShabatDay.FormattingEnabled = true;
      this.EditShabatDay.Name = "EditShabatDay";
      // 
      // LabelFontName
      // 
      resources.ApplyResources(this.LabelFontName, "LabelFontName");
      this.LabelFontName.Name = "LabelFontName";
      // 
      // PanelTextColor
      // 
      resources.ApplyResources(this.PanelTextColor, "PanelTextColor");
      this.PanelTextColor.BackColor = System.Drawing.Color.Black;
      this.PanelTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelTextColor.Name = "PanelTextColor";
      this.PanelTextColor.Click += new System.EventHandler(this.PanelTextColor_Click);
      // 
      // LabelBackColor
      // 
      resources.ApplyResources(this.LabelBackColor, "LabelBackColor");
      this.LabelBackColor.Name = "LabelBackColor";
      // 
      // GPSLatitudeTextBox
      // 
      resources.ApplyResources(this.GPSLatitudeTextBox, "GPSLatitudeTextBox");
      this.GPSLatitudeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSettings, "Latitude", true));
      this.GPSLatitudeTextBox.Name = "GPSLatitudeTextBox";
      // 
      // GPSLongitudeTextBox
      // 
      resources.ApplyResources(this.GPSLongitudeTextBox, "GPSLongitudeTextBox");
      this.GPSLongitudeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSettings, "Longitude", true));
      this.GPSLongitudeTextBox.Name = "GPSLongitudeTextBox";
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
      this.GroupBoxGPS.Controls.Add(this.GPSLatitudeTextBox);
      this.GroupBoxGPS.Controls.Add(GPSLatitudeLabel);
      this.GroupBoxGPS.Controls.Add(this.GPSLongitudeTextBox);
      this.GroupBoxGPS.Controls.Add(GPSLongitudeLabel);
      this.GroupBoxGPS.Name = "GroupBoxGPS";
      this.GroupBoxGPS.TabStop = false;
      // 
      // GroupBoxText
      // 
      resources.ApplyResources(this.GroupBoxText, "GroupBoxText");
      this.GroupBoxText.Controls.Add(this.LabelFontName);
      this.GroupBoxText.Controls.Add(this.LabelBackColor);
      this.GroupBoxText.Controls.Add(this.PanelTextColor);
      this.GroupBoxText.Controls.Add(this.LabelTextColor);
      this.GroupBoxText.Controls.Add(this.EditFontName);
      this.GroupBoxText.Controls.Add(this.PanelBackColor);
      this.GroupBoxText.Controls.Add(this.LabelFontSize);
      this.GroupBoxText.Controls.Add(this.EditFontSize);
      this.GroupBoxText.Name = "GroupBoxText";
      this.GroupBoxText.TabStop = false;
      // 
      // BroupBoxShabat
      // 
      resources.ApplyResources(this.BroupBoxShabat, "BroupBoxShabat");
      this.BroupBoxShabat.Controls.Add(this.EditShabatDay);
      this.BroupBoxShabat.Controls.Add(this.ActionUsePersonalShabat);
      this.BroupBoxShabat.Controls.Add(this.LabelShabatDay);
      this.BroupBoxShabat.Name = "BroupBoxShabat";
      this.BroupBoxShabat.TabStop = false;
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
      this.GroupBoxNavigation.Controls.Add(this.labelBottomColor);
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
      // labelBottomColor
      // 
      resources.ApplyResources(this.labelBottomColor, "labelBottomColor");
      this.labelBottomColor.Name = "labelBottomColor";
      // 
      // LabelMiddleColor
      // 
      resources.ApplyResources(this.LabelMiddleColor, "LabelMiddleColor");
      this.LabelMiddleColor.Name = "LabelMiddleColor";
      // 
      // GroupBoxTrayIcon
      // 
      resources.ApplyResources(this.GroupBoxTrayIcon, "GroupBoxTrayIcon");
      this.GroupBoxTrayIcon.Controls.Add(this.RadioButtonNavigationForm);
      this.GroupBoxTrayIcon.Controls.Add(this.RadioButtonMainForm);
      this.GroupBoxTrayIcon.Name = "GroupBoxTrayIcon";
      this.GroupBoxTrayIcon.TabStop = false;
      // 
      // RadioButtonNavigationForm
      // 
      resources.ApplyResources(this.RadioButtonNavigationForm, "RadioButtonNavigationForm");
      this.RadioButtonNavigationForm.Name = "RadioButtonNavigationForm";
      this.RadioButtonNavigationForm.TabStop = true;
      this.RadioButtonNavigationForm.UseVisualStyleBackColor = true;
      // 
      // RadioButtonMainForm
      // 
      resources.ApplyResources(this.RadioButtonMainForm, "RadioButtonMainForm");
      this.RadioButtonMainForm.Name = "RadioButtonMainForm";
      this.RadioButtonMainForm.TabStop = true;
      this.RadioButtonMainForm.UseVisualStyleBackColor = true;
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
      this.GroupBoxReminder.Controls.Add(this.EditRemindShabat);
      this.GroupBoxReminder.Controls.Add(this.EditEvents);
      this.GroupBoxReminder.Controls.Add(this.EditTimerInterval);
      this.GroupBoxReminder.Controls.Add(this.LabelTimerInterval);
      this.GroupBoxReminder.Controls.Add(this.EditTimerEnabled);
      this.GroupBoxReminder.Name = "GroupBoxReminder";
      this.GroupBoxReminder.TabStop = false;
      // 
      // EditRemindShabat
      // 
      resources.ApplyResources(this.EditRemindShabat, "EditRemindShabat");
      this.EditRemindShabat.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BindingSettings, "RemindShabat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditRemindShabat.Name = "EditRemindShabat";
      this.EditRemindShabat.UseVisualStyleBackColor = true;
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
      // 
      // EditShowMonthDayToolTip
      // 
      resources.ApplyResources(this.EditShowMonthDayToolTip, "EditShowMonthDayToolTip");
      this.EditShowMonthDayToolTip.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BindingSettings, "MonthViewSunToolTips", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditShowMonthDayToolTip.Name = "EditShowMonthDayToolTip";
      this.EditShowMonthDayToolTip.UseVisualStyleBackColor = true;
      // 
      // PreferencesForm
      // 
      this.AcceptButton = this.ButtonClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonClose;
      this.Controls.Add(this.EditShowMonthDayToolTip);
      this.Controls.Add(this.EditStartupHide);
      this.Controls.Add(this.GroupBoxReminder);
      this.Controls.Add(this.GroupBoxTrayIcon);
      this.Controls.Add(this.GroupBoxText);
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
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).EndInit();
      this.PanelButtons.ResumeLayout(false);
      this.GroupBoxGPS.ResumeLayout(false);
      this.GroupBoxGPS.PerformLayout();
      this.GroupBoxText.ResumeLayout(false);
      this.GroupBoxText.PerformLayout();
      this.BroupBoxShabat.ResumeLayout(false);
      this.BroupBoxShabat.PerformLayout();
      this.GroupBoxNavigation.ResumeLayout(false);
      this.GroupBoxNavigation.PerformLayout();
      this.GroupBoxTrayIcon.ResumeLayout(false);
      this.GroupBoxTrayIcon.PerformLayout();
      this.GroupBoxReminder.ResumeLayout(false);
      this.GroupBoxReminder.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditTimerInterval)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ColorDialog DialogColor;
    private System.Windows.Forms.Button ButtonClose;
    private System.Windows.Forms.Label LabelShabatDay;
    private System.Windows.Forms.Label LabelFontSize;
    private System.Windows.Forms.Label LabelTextColor;
    private System.Windows.Forms.Label LabelFontName;
    private System.Windows.Forms.Label LabelBackColor;
    private System.Windows.Forms.BindingSource BindingSettings;
    private System.Windows.Forms.ComboBox EditFontName;
    private System.Windows.Forms.NumericUpDown EditFontSize;
    private System.Windows.Forms.ComboBox EditShabatDay;
    private System.Windows.Forms.TextBox GPSLatitudeTextBox;
    private System.Windows.Forms.TextBox GPSLongitudeTextBox;
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.LinkLabel ActionUsePersonalShabat;
    private System.Windows.Forms.GroupBox GroupBoxGPS;
    private System.Windows.Forms.GroupBox GroupBoxText;
    private System.Windows.Forms.GroupBox BroupBoxShabat;
    private System.Windows.Forms.GroupBox GroupBoxNavigation;
    private System.Windows.Forms.Label LabelTopColor;
    private System.Windows.Forms.Label labelBottomColor;
    private System.Windows.Forms.Label LabelMiddleColor;
    private System.Windows.Forms.LinkLabel ActionUseSystemColors;
    internal System.Windows.Forms.Panel PanelBackColor;
    internal System.Windows.Forms.Panel PanelTextColor;
    internal System.Windows.Forms.Panel PanelTopColor;
    internal System.Windows.Forms.Panel PanelBottomColor;
    internal System.Windows.Forms.Panel PanelMiddleColor;
    private System.Windows.Forms.LinkLabel ActionUseDefaultColors;
    private System.Windows.Forms.GroupBox GroupBoxTrayIcon;
    private System.Windows.Forms.RadioButton RadioButtonNavigationForm;
    private System.Windows.Forms.RadioButton RadioButtonMainForm;
    private System.Windows.Forms.CheckBox EditStartupHide;
    private System.Windows.Forms.GroupBox GroupBoxReminder;
    private System.Windows.Forms.NumericUpDown EditTimerInterval;
    private System.Windows.Forms.Label LabelTimerInterval;
    private System.Windows.Forms.CheckBox EditTimerEnabled;
    private System.Windows.Forms.CheckedListBox EditEvents;
    private System.Windows.Forms.CheckBox EditRemindShabat;
    private System.Windows.Forms.CheckBox EditShowMonthDayToolTip;
    private System.Windows.Forms.LinkLabel ActionUseBlackAndWhiteColors;
  }
}
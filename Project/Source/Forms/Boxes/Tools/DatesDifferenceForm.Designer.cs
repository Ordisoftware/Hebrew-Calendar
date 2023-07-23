namespace Ordisoftware.Hebrew.Calendar
{
  partial class DatesDifferenceForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
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
      System.Windows.Forms.Label lunationsLabel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatesDifferenceForm));
      System.Windows.Forms.Label moonDaysLabel;
      System.Windows.Forms.Label solarDaysLabel;
      System.Windows.Forms.Label solarMonthsLabel;
      System.Windows.Forms.Label solarWeeksLabel;
      System.Windows.Forms.Label solarYearsLabel;
      System.Windows.Forms.Label moonYearsLabel;
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.EditAutoSetRightToToday = new System.Windows.Forms.CheckBox();
      this.ActionHelp = new System.Windows.Forms.Button();
      this.ActionOpenCalc = new System.Windows.Forms.Button();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionManageBookmarks = new System.Windows.Forms.Button();
      this.DateStart = new System.Windows.Forms.MonthCalendar();
      this.DateEnd = new System.Windows.Forms.MonthCalendar();
      this.lunationsLabel1 = new System.Windows.Forms.Label();
      this.DatesDifferenceItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.moonDaysLabel1 = new System.Windows.Forms.Label();
      this.solarDaysLabel1 = new System.Windows.Forms.Label();
      this.solarMonthsLabel1 = new System.Windows.Forms.Label();
      this.solarWeeksLabel1 = new System.Windows.Forms.Label();
      this.solarYearsLabel1 = new System.Windows.Forms.Label();
      this.GroupBoxSun = new System.Windows.Forms.GroupBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.DatePickerStart = new System.Windows.Forms.DateTimePicker();
      this.DatePickerEnd = new System.Windows.Forms.DateTimePicker();
      this.ActionSaveBookmarkStart = new System.Windows.Forms.Button();
      this.MenuBookmarks = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionGoToBookmarkStart = new System.Windows.Forms.Button();
      this.ActionGoToBookmarkEnd = new System.Windows.Forms.Button();
      this.ActionSaveBookmarkEnd = new System.Windows.Forms.Button();
      this.ActionSwapDates = new System.Windows.Forms.Button();
      lunationsLabel = new System.Windows.Forms.Label();
      moonDaysLabel = new System.Windows.Forms.Label();
      solarDaysLabel = new System.Windows.Forms.Label();
      solarMonthsLabel = new System.Windows.Forms.Label();
      solarWeeksLabel = new System.Windows.Forms.Label();
      solarYearsLabel = new System.Windows.Forms.Label();
      moonYearsLabel = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DatesDifferenceItemBindingSource)).BeginInit();
      this.GroupBoxSun.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lunationsLabel
      // 
      resources.ApplyResources(lunationsLabel, "lunationsLabel");
      lunationsLabel.Name = "lunationsLabel";
      // 
      // moonDaysLabel
      // 
      resources.ApplyResources(moonDaysLabel, "moonDaysLabel");
      moonDaysLabel.Name = "moonDaysLabel";
      // 
      // solarDaysLabel
      // 
      resources.ApplyResources(solarDaysLabel, "solarDaysLabel");
      solarDaysLabel.Name = "solarDaysLabel";
      // 
      // solarMonthsLabel
      // 
      resources.ApplyResources(solarMonthsLabel, "solarMonthsLabel");
      solarMonthsLabel.Name = "solarMonthsLabel";
      // 
      // solarWeeksLabel
      // 
      resources.ApplyResources(solarWeeksLabel, "solarWeeksLabel");
      solarWeeksLabel.Name = "solarWeeksLabel";
      // 
      // solarYearsLabel
      // 
      resources.ApplyResources(solarYearsLabel, "solarYearsLabel");
      solarYearsLabel.Name = "solarYearsLabel";
      // 
      // moonYearsLabel
      // 
      resources.ApplyResources(moonYearsLabel, "moonYearsLabel");
      moonYearsLabel.Name = "moonYearsLabel";
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.EditAutoSetRightToToday);
      this.PanelBottom.Controls.Add(this.ActionHelp);
      this.PanelBottom.Controls.Add(this.ActionOpenCalc);
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Controls.Add(this.ActionManageBookmarks);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // EditAutoSetRightToToday
      // 
      resources.ApplyResources(this.EditAutoSetRightToToday, "EditAutoSetRightToToday");
      this.EditAutoSetRightToToday.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.DatesDiffCalculatorFormAutoSetRightToToday;
      this.EditAutoSetRightToToday.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditAutoSetRightToToday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "DatesDiffCalculatorFormAutoSetRightToToday", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditAutoSetRightToToday.Name = "EditAutoSetRightToToday";
      this.EditAutoSetRightToToday.UseVisualStyleBackColor = true;
      // 
      // ActionHelp
      // 
      this.ActionHelp.AllowDrop = true;
      this.ActionHelp.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionHelp, "ActionHelp");
      this.ActionHelp.Name = "ActionHelp";
      this.ActionHelp.UseVisualStyleBackColor = true;
      this.ActionHelp.Click += new System.EventHandler(this.ActionHelp_Click);
      // 
      // ActionOpenCalc
      // 
      this.ActionOpenCalc.AllowDrop = true;
      this.ActionOpenCalc.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionOpenCalc, "ActionOpenCalc");
      this.ActionOpenCalc.Name = "ActionOpenCalc";
      this.ActionOpenCalc.TabStop = false;
      this.ActionOpenCalc.UseVisualStyleBackColor = true;
      this.ActionOpenCalc.Click += new System.EventHandler(this.ActionOpenCalc_Click);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ActionManageBookmarks
      // 
      this.ActionManageBookmarks.AllowDrop = true;
      this.ActionManageBookmarks.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionManageBookmarks, "ActionManageBookmarks");
      this.ActionManageBookmarks.Name = "ActionManageBookmarks";
      this.ActionManageBookmarks.UseVisualStyleBackColor = true;
      this.ActionManageBookmarks.Click += new System.EventHandler(this.ActionManageBookmarks_Click);
      // 
      // DateStart
      // 
      resources.ApplyResources(this.DateStart, "DateStart");
      this.DateStart.MaxSelectionCount = 1;
      this.DateStart.Name = "DateStart";
      this.DateStart.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.DateStart_DateChanged);
      // 
      // DateEnd
      // 
      resources.ApplyResources(this.DateEnd, "DateEnd");
      this.DateEnd.MaxSelectionCount = 1;
      this.DateEnd.Name = "DateEnd";
      this.DateEnd.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.DateEnd_DateChanged);
      // 
      // lunationsLabel1
      // 
      this.lunationsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDifferenceItemBindingSource, "LunarMonths", true));
      resources.ApplyResources(this.lunationsLabel1, "lunationsLabel1");
      this.lunationsLabel1.Name = "lunationsLabel1";
      // 
      // DatesDifferenceItemBindingSource
      // 
      this.DatesDifferenceItemBindingSource.DataSource = typeof(Ordisoftware.Hebrew.Calendar.DatesDifferenceItem);
      // 
      // moonDaysLabel1
      // 
      this.moonDaysLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDifferenceItemBindingSource, "MoonDays", true));
      resources.ApplyResources(this.moonDaysLabel1, "moonDaysLabel1");
      this.moonDaysLabel1.Name = "moonDaysLabel1";
      // 
      // solarDaysLabel1
      // 
      this.solarDaysLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDifferenceItemBindingSource, "SolarDays", true));
      resources.ApplyResources(this.solarDaysLabel1, "solarDaysLabel1");
      this.solarDaysLabel1.Name = "solarDaysLabel1";
      // 
      // solarMonthsLabel1
      // 
      this.solarMonthsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDifferenceItemBindingSource, "SolarMonths", true));
      resources.ApplyResources(this.solarMonthsLabel1, "solarMonthsLabel1");
      this.solarMonthsLabel1.Name = "solarMonthsLabel1";
      // 
      // solarWeeksLabel1
      // 
      this.solarWeeksLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDifferenceItemBindingSource, "SolarWeeks", true));
      resources.ApplyResources(this.solarWeeksLabel1, "solarWeeksLabel1");
      this.solarWeeksLabel1.Name = "solarWeeksLabel1";
      // 
      // solarYearsLabel1
      // 
      this.solarYearsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDifferenceItemBindingSource, "SolarYears", true));
      resources.ApplyResources(this.solarYearsLabel1, "solarYearsLabel1");
      this.solarYearsLabel1.Name = "solarYearsLabel1";
      // 
      // GroupBoxSun
      // 
      resources.ApplyResources(this.GroupBoxSun, "GroupBoxSun");
      this.GroupBoxSun.Controls.Add(solarDaysLabel);
      this.GroupBoxSun.Controls.Add(this.solarYearsLabel1);
      this.GroupBoxSun.Controls.Add(solarYearsLabel);
      this.GroupBoxSun.Controls.Add(solarWeeksLabel);
      this.GroupBoxSun.Controls.Add(solarMonthsLabel);
      this.GroupBoxSun.Controls.Add(this.solarWeeksLabel1);
      this.GroupBoxSun.Controls.Add(this.solarMonthsLabel1);
      this.GroupBoxSun.Controls.Add(this.solarDaysLabel1);
      this.GroupBoxSun.Name = "GroupBoxSun";
      this.GroupBoxSun.TabStop = false;
      // 
      // groupBox1
      // 
      resources.ApplyResources(this.groupBox1, "groupBox1");
      this.groupBox1.Controls.Add(moonDaysLabel);
      this.groupBox1.Controls.Add(this.moonDaysLabel1);
      this.groupBox1.Controls.Add(moonYearsLabel);
      this.groupBox1.Controls.Add(lunationsLabel);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.lunationsLabel1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      // 
      // label2
      // 
      this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDifferenceItemBindingSource, "MoonYears", true));
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // DatePickerStart
      // 
      resources.ApplyResources(this.DatePickerStart, "DatePickerStart");
      this.DatePickerStart.Name = "DatePickerStart";
      this.DatePickerStart.ShowUpDown = true;
      this.DatePickerStart.ValueChanged += new System.EventHandler(this.DatePickerStart_ValueChanged);
      // 
      // DatePickerEnd
      // 
      resources.ApplyResources(this.DatePickerEnd, "DatePickerEnd");
      this.DatePickerEnd.Name = "DatePickerEnd";
      this.DatePickerEnd.ShowUpDown = true;
      this.DatePickerEnd.ValueChanged += new System.EventHandler(this.DatePickerEnd_ValueChanged);
      // 
      // ActionSaveBookmarkStart
      // 
      this.ActionSaveBookmarkStart.AllowDrop = true;
      this.ActionSaveBookmarkStart.ContextMenuStrip = this.MenuBookmarks;
      this.ActionSaveBookmarkStart.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSaveBookmarkStart, "ActionSaveBookmarkStart");
      this.ActionSaveBookmarkStart.Name = "ActionSaveBookmarkStart";
      this.ActionSaveBookmarkStart.TabStop = false;
      this.ActionSaveBookmarkStart.UseVisualStyleBackColor = true;
      this.ActionSaveBookmarkStart.Click += new System.EventHandler(this.ActionSaveBookmark_Click);
      // 
      // MenuBookmarks
      // 
      this.MenuBookmarks.Name = "MenuBookmarks";
      this.MenuBookmarks.ShowImageMargin = false;
      resources.ApplyResources(this.MenuBookmarks, "MenuBookmarks");
      // 
      // ActionGoToBookmarkStart
      // 
      this.ActionGoToBookmarkStart.AllowDrop = true;
      this.ActionGoToBookmarkStart.ContextMenuStrip = this.MenuBookmarks;
      this.ActionGoToBookmarkStart.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionGoToBookmarkStart, "ActionGoToBookmarkStart");
      this.ActionGoToBookmarkStart.Name = "ActionGoToBookmarkStart";
      this.ActionGoToBookmarkStart.TabStop = false;
      this.ActionGoToBookmarkStart.UseVisualStyleBackColor = true;
      this.ActionGoToBookmarkStart.Click += new System.EventHandler(this.ActionBookmarksButton_Click);
      // 
      // ActionGoToBookmarkEnd
      // 
      this.ActionGoToBookmarkEnd.AllowDrop = true;
      this.ActionGoToBookmarkEnd.ContextMenuStrip = this.MenuBookmarks;
      this.ActionGoToBookmarkEnd.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionGoToBookmarkEnd, "ActionGoToBookmarkEnd");
      this.ActionGoToBookmarkEnd.Name = "ActionGoToBookmarkEnd";
      this.ActionGoToBookmarkEnd.TabStop = false;
      this.ActionGoToBookmarkEnd.UseVisualStyleBackColor = true;
      this.ActionGoToBookmarkEnd.Click += new System.EventHandler(this.ActionBookmarksButton_Click);
      // 
      // ActionSaveBookmarkEnd
      // 
      this.ActionSaveBookmarkEnd.AllowDrop = true;
      this.ActionSaveBookmarkEnd.ContextMenuStrip = this.MenuBookmarks;
      this.ActionSaveBookmarkEnd.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSaveBookmarkEnd, "ActionSaveBookmarkEnd");
      this.ActionSaveBookmarkEnd.Name = "ActionSaveBookmarkEnd";
      this.ActionSaveBookmarkEnd.TabStop = false;
      this.ActionSaveBookmarkEnd.UseVisualStyleBackColor = true;
      this.ActionSaveBookmarkEnd.Click += new System.EventHandler(this.ActionSaveBookmark_Click);
      // 
      // ActionSwapDates
      // 
      this.ActionSwapDates.AllowDrop = true;
      this.ActionSwapDates.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSwapDates, "ActionSwapDates");
      this.ActionSwapDates.Name = "ActionSwapDates";
      this.ActionSwapDates.TabStop = false;
      this.ActionSwapDates.UseVisualStyleBackColor = true;
      this.ActionSwapDates.Click += new System.EventHandler(this.ActionSwapDates_Click);
      // 
      // DatesDifferenceForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.ActionSwapDates);
      this.Controls.Add(this.ActionSaveBookmarkEnd);
      this.Controls.Add(this.ActionGoToBookmarkEnd);
      this.Controls.Add(this.ActionSaveBookmarkStart);
      this.Controls.Add(this.ActionGoToBookmarkStart);
      this.Controls.Add(this.DatePickerEnd);
      this.Controls.Add(this.DatePickerStart);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.GroupBoxSun);
      this.Controls.Add(this.DateEnd);
      this.Controls.Add(this.DateStart);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DatesDifferenceForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatesDiffCalculatorForm_FormClosing);
      this.Load += new System.EventHandler(this.DateDiffForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DatesDifferenceItemBindingSource)).EndInit();
      this.GroupBoxSun.ResumeLayout(false);
      this.GroupBoxSun.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.MonthCalendar DateStart;
    private System.Windows.Forms.MonthCalendar DateEnd;
    private System.Windows.Forms.BindingSource DatesDifferenceItemBindingSource;
    private System.Windows.Forms.Label lunationsLabel1;
    private System.Windows.Forms.Label moonDaysLabel1;
    private System.Windows.Forms.Label solarDaysLabel1;
    private System.Windows.Forms.Label solarMonthsLabel1;
    private System.Windows.Forms.Label solarWeeksLabel1;
    private System.Windows.Forms.Label solarYearsLabel1;
    private System.Windows.Forms.GroupBox GroupBoxSun;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DateTimePicker DatePickerStart;
    private System.Windows.Forms.DateTimePicker DatePickerEnd;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button ActionSaveBookmarkStart;
    private System.Windows.Forms.Button ActionGoToBookmarkStart;
    private System.Windows.Forms.Button ActionGoToBookmarkEnd;
    private System.Windows.Forms.Button ActionSaveBookmarkEnd;
    private System.Windows.Forms.ContextMenuStrip MenuBookmarks;
    private System.Windows.Forms.Button ActionHelp;
    private System.Windows.Forms.Button ActionSwapDates;
    private System.Windows.Forms.Button ActionManageBookmarks;
    private System.Windows.Forms.CheckBox EditAutoSetRightToToday;
    private Button ActionOpenCalc;
  }
}
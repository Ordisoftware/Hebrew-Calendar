namespace Ordisoftware.HebrewCalendar
{
  partial class DatesDiffCalculatorForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatesDiffCalculatorForm));
      System.Windows.Forms.Label moonDaysLabel;
      System.Windows.Forms.Label solarDaysLabel;
      System.Windows.Forms.Label solarMonthsLabel;
      System.Windows.Forms.Label solarWeeksLabel;
      System.Windows.Forms.Label solarYearsLabel;
      System.Windows.Forms.Label moonYearsLabel;
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionHelp = new System.Windows.Forms.Button();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionManageBookmarks = new System.Windows.Forms.Button();
      this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
      this.MonthCalendar2 = new System.Windows.Forms.MonthCalendar();
      this.lunationsLabel1 = new System.Windows.Forms.Label();
      this.DatesDiffItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.moonDaysLabel1 = new System.Windows.Forms.Label();
      this.solarDaysLabel1 = new System.Windows.Forms.Label();
      this.solarMonthsLabel1 = new System.Windows.Forms.Label();
      this.solarWeeksLabel1 = new System.Windows.Forms.Label();
      this.solarYearsLabel1 = new System.Windows.Forms.Label();
      this.GroupBoxSun = new System.Windows.Forms.GroupBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
      this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
      this.ActionSetBookmarkStart = new System.Windows.Forms.Button();
      this.MenuBookmarks = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionUseBookmarkStart = new System.Windows.Forms.Button();
      this.ActionUseBookmarkEnd = new System.Windows.Forms.Button();
      this.ActionSetBookmarkEnd = new System.Windows.Forms.Button();
      this.ActionSwapDates = new System.Windows.Forms.Button();
      lunationsLabel = new System.Windows.Forms.Label();
      moonDaysLabel = new System.Windows.Forms.Label();
      solarDaysLabel = new System.Windows.Forms.Label();
      solarMonthsLabel = new System.Windows.Forms.Label();
      solarWeeksLabel = new System.Windows.Forms.Label();
      solarYearsLabel = new System.Windows.Forms.Label();
      moonYearsLabel = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DatesDiffItemBindingSource)).BeginInit();
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
      this.PanelBottom.Controls.Add(this.ActionHelp);
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Controls.Add(this.ActionManageBookmarks);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionHelp
      // 
      this.ActionHelp.AllowDrop = true;
      this.ActionHelp.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionHelp, "ActionHelp");
      this.ActionHelp.Name = "ActionHelp";
      this.ActionHelp.TabStop = false;
      this.ActionHelp.UseVisualStyleBackColor = true;
      this.ActionHelp.Click += new System.EventHandler(this.ActionHelp_Click);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      // 
      // ActionManageBookmarks
      // 
      this.ActionManageBookmarks.AllowDrop = true;
      this.ActionManageBookmarks.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionManageBookmarks, "ActionManageBookmarks");
      this.ActionManageBookmarks.Name = "ActionManageBookmarks";
      this.ActionManageBookmarks.TabStop = false;
      this.ActionManageBookmarks.UseVisualStyleBackColor = true;
      this.ActionManageBookmarks.Click += new System.EventHandler(this.ActionManageBookmarks_Click);
      // 
      // MonthCalendar1
      // 
      resources.ApplyResources(this.MonthCalendar1, "MonthCalendar1");
      this.MonthCalendar1.MaxSelectionCount = 1;
      this.MonthCalendar1.Name = "MonthCalendar1";
      this.MonthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateChanged);
      // 
      // MonthCalendar2
      // 
      resources.ApplyResources(this.MonthCalendar2, "MonthCalendar2");
      this.MonthCalendar2.MaxSelectionCount = 1;
      this.MonthCalendar2.Name = "MonthCalendar2";
      this.MonthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar2_DateChanged);
      // 
      // lunationsLabel1
      // 
      this.lunationsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDiffItemBindingSource, "MoonMonths", true));
      resources.ApplyResources(this.lunationsLabel1, "lunationsLabel1");
      this.lunationsLabel1.Name = "lunationsLabel1";
      // 
      // DatesDiffItemBindingSource
      // 
      this.DatesDiffItemBindingSource.DataSource = typeof(Ordisoftware.HebrewCalendar.DatesDiffItem);
      // 
      // moonDaysLabel1
      // 
      this.moonDaysLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDiffItemBindingSource, "MoonDays", true));
      resources.ApplyResources(this.moonDaysLabel1, "moonDaysLabel1");
      this.moonDaysLabel1.Name = "moonDaysLabel1";
      // 
      // solarDaysLabel1
      // 
      this.solarDaysLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDiffItemBindingSource, "SolarDays", true));
      resources.ApplyResources(this.solarDaysLabel1, "solarDaysLabel1");
      this.solarDaysLabel1.Name = "solarDaysLabel1";
      // 
      // solarMonthsLabel1
      // 
      this.solarMonthsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDiffItemBindingSource, "SolarMonths", true));
      resources.ApplyResources(this.solarMonthsLabel1, "solarMonthsLabel1");
      this.solarMonthsLabel1.Name = "solarMonthsLabel1";
      // 
      // solarWeeksLabel1
      // 
      this.solarWeeksLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDiffItemBindingSource, "SolarWeeks", true));
      resources.ApplyResources(this.solarWeeksLabel1, "solarWeeksLabel1");
      this.solarWeeksLabel1.Name = "solarWeeksLabel1";
      // 
      // solarYearsLabel1
      // 
      this.solarYearsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDiffItemBindingSource, "SolarYears", true));
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
      this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DatesDiffItemBindingSource, "MoonYears", true));
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // DateTimePicker1
      // 
      resources.ApplyResources(this.DateTimePicker1, "DateTimePicker1");
      this.DateTimePicker1.Name = "DateTimePicker1";
      this.DateTimePicker1.ShowUpDown = true;
      this.DateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
      // 
      // DateTimePicker2
      // 
      resources.ApplyResources(this.DateTimePicker2, "DateTimePicker2");
      this.DateTimePicker2.Name = "DateTimePicker2";
      this.DateTimePicker2.ShowUpDown = true;
      this.DateTimePicker2.ValueChanged += new System.EventHandler(this.DateTimePicker2_ValueChanged);
      // 
      // ActionSetBookmarkStart
      // 
      this.ActionSetBookmarkStart.AllowDrop = true;
      this.ActionSetBookmarkStart.ContextMenuStrip = this.MenuBookmarks;
      this.ActionSetBookmarkStart.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSetBookmarkStart, "ActionSetBookmarkStart");
      this.ActionSetBookmarkStart.Name = "ActionSetBookmarkStart";
      this.ActionSetBookmarkStart.TabStop = false;
      this.ActionSetBookmarkStart.UseVisualStyleBackColor = true;
      this.ActionSetBookmarkStart.Click += new System.EventHandler(this.ActionBookmarksButton_Click);
      // 
      // MenuBookmarks
      // 
      this.MenuBookmarks.Name = "MenuBookmarks";
      this.MenuBookmarks.ShowImageMargin = false;
      resources.ApplyResources(this.MenuBookmarks, "MenuBookmarks");
      // 
      // ActionUseBookmarkStart
      // 
      this.ActionUseBookmarkStart.AllowDrop = true;
      this.ActionUseBookmarkStart.ContextMenuStrip = this.MenuBookmarks;
      this.ActionUseBookmarkStart.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionUseBookmarkStart, "ActionUseBookmarkStart");
      this.ActionUseBookmarkStart.Name = "ActionUseBookmarkStart";
      this.ActionUseBookmarkStart.TabStop = false;
      this.ActionUseBookmarkStart.UseVisualStyleBackColor = true;
      this.ActionUseBookmarkStart.Click += new System.EventHandler(this.ActionBookmarksButton_Click);
      // 
      // ActionUseBookmarkEnd
      // 
      this.ActionUseBookmarkEnd.AllowDrop = true;
      this.ActionUseBookmarkEnd.ContextMenuStrip = this.MenuBookmarks;
      this.ActionUseBookmarkEnd.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionUseBookmarkEnd, "ActionUseBookmarkEnd");
      this.ActionUseBookmarkEnd.Name = "ActionUseBookmarkEnd";
      this.ActionUseBookmarkEnd.TabStop = false;
      this.ActionUseBookmarkEnd.UseVisualStyleBackColor = true;
      this.ActionUseBookmarkEnd.Click += new System.EventHandler(this.ActionBookmarksButton_Click);
      // 
      // ActionSetBookmarkEnd
      // 
      this.ActionSetBookmarkEnd.AllowDrop = true;
      this.ActionSetBookmarkEnd.ContextMenuStrip = this.MenuBookmarks;
      this.ActionSetBookmarkEnd.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSetBookmarkEnd, "ActionSetBookmarkEnd");
      this.ActionSetBookmarkEnd.Name = "ActionSetBookmarkEnd";
      this.ActionSetBookmarkEnd.TabStop = false;
      this.ActionSetBookmarkEnd.UseVisualStyleBackColor = true;
      this.ActionSetBookmarkEnd.Click += new System.EventHandler(this.ActionBookmarksButton_Click);
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
      // DatesDiffForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.ActionSwapDates);
      this.Controls.Add(this.ActionSetBookmarkEnd);
      this.Controls.Add(this.ActionUseBookmarkEnd);
      this.Controls.Add(this.ActionSetBookmarkStart);
      this.Controls.Add(this.ActionUseBookmarkStart);
      this.Controls.Add(this.DateTimePicker2);
      this.Controls.Add(this.DateTimePicker1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.GroupBoxSun);
      this.Controls.Add(this.MonthCalendar2);
      this.Controls.Add(this.MonthCalendar1);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DatesDiffForm";
      this.Load += new System.EventHandler(this.DateDiffForm_Load);
      this.PanelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DatesDiffItemBindingSource)).EndInit();
      this.GroupBoxSun.ResumeLayout(false);
      this.GroupBoxSun.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.MonthCalendar MonthCalendar1;
    private System.Windows.Forms.MonthCalendar MonthCalendar2;
    private System.Windows.Forms.BindingSource DatesDiffItemBindingSource;
    private System.Windows.Forms.Label lunationsLabel1;
    private System.Windows.Forms.Label moonDaysLabel1;
    private System.Windows.Forms.Label solarDaysLabel1;
    private System.Windows.Forms.Label solarMonthsLabel1;
    private System.Windows.Forms.Label solarWeeksLabel1;
    private System.Windows.Forms.Label solarYearsLabel1;
    private System.Windows.Forms.GroupBox GroupBoxSun;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DateTimePicker DateTimePicker1;
    private System.Windows.Forms.DateTimePicker DateTimePicker2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button ActionSetBookmarkStart;
    private System.Windows.Forms.Button ActionUseBookmarkStart;
    private System.Windows.Forms.Button ActionUseBookmarkEnd;
    private System.Windows.Forms.Button ActionSetBookmarkEnd;
    private System.Windows.Forms.ContextMenuStrip MenuBookmarks;
    private System.Windows.Forms.Button ActionHelp;
    private System.Windows.Forms.Button ActionSwapDates;
    private System.Windows.Forms.Button ActionManageBookmarks;
  }
}
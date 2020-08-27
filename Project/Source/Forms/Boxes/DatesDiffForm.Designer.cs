namespace Ordisoftware.HebrewCalendar
{
  partial class DatesDiffForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatesDiffForm));
      System.Windows.Forms.Label moonDaysLabel;
      System.Windows.Forms.Label solarDaysLabel;
      System.Windows.Forms.Label solarMonthsLabel;
      System.Windows.Forms.Label solarWeeksLabel;
      System.Windows.Forms.Label solarYearsLabel;
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.EditMaxYearsAutoCalculate = new System.Windows.Forms.NumericUpDown();
      this.EditAlwaysLiveCalculate = new System.Windows.Forms.CheckBox();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionCalculate = new System.Windows.Forms.Button();
      this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
      this.MonthCalendar2 = new System.Windows.Forms.MonthCalendar();
      this.lunationsLabel1 = new System.Windows.Forms.Label();
      this.moonDaysLabel1 = new System.Windows.Forms.Label();
      this.solarDaysLabel1 = new System.Windows.Forms.Label();
      this.solarMonthsLabel1 = new System.Windows.Forms.Label();
      this.solarWeeksLabel1 = new System.Windows.Forms.Label();
      this.solarYearsLabel1 = new System.Windows.Forms.Label();
      this.GroupBoxSun = new System.Windows.Forms.GroupBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
      this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
      this.datesDiffItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
      lunationsLabel = new System.Windows.Forms.Label();
      moonDaysLabel = new System.Windows.Forms.Label();
      solarDaysLabel = new System.Windows.Forms.Label();
      solarMonthsLabel = new System.Windows.Forms.Label();
      solarWeeksLabel = new System.Windows.Forms.Label();
      solarYearsLabel = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditMaxYearsAutoCalculate)).BeginInit();
      this.GroupBoxSun.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.datesDiffItemBindingSource)).BeginInit();
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
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.EditMaxYearsAutoCalculate);
      this.PanelBottom.Controls.Add(this.EditAlwaysLiveCalculate);
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Controls.Add(this.ActionCalculate);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // EditMaxYearsAutoCalculate
      // 
      this.EditMaxYearsAutoCalculate.BackColor = System.Drawing.SystemColors.Window;
      this.EditMaxYearsAutoCalculate.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Ordisoftware.HebrewCalendar.Properties.Settings.Default, "DatesDiffCalculateMaxYearsAuto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      resources.ApplyResources(this.EditMaxYearsAutoCalculate, "EditMaxYearsAutoCalculate");
      this.EditMaxYearsAutoCalculate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.EditMaxYearsAutoCalculate.Name = "EditMaxYearsAutoCalculate";
      this.EditMaxYearsAutoCalculate.ReadOnly = true;
      this.EditMaxYearsAutoCalculate.Value = global::Ordisoftware.HebrewCalendar.Properties.Settings.Default.DatesDiffCalculateMaxYearsAuto;
      this.EditMaxYearsAutoCalculate.ValueChanged += new System.EventHandler(this.EditMaxYearsAutoCalculate_ValueChanged);
      // 
      // EditAlwaysLiveCalculate
      // 
      resources.ApplyResources(this.EditAlwaysLiveCalculate, "EditAlwaysLiveCalculate");
      this.EditAlwaysLiveCalculate.Checked = global::Ordisoftware.HebrewCalendar.Properties.Settings.Default.DatesDiffCalculateRealtime;
      this.EditAlwaysLiveCalculate.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditAlwaysLiveCalculate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.HebrewCalendar.Properties.Settings.Default, "DatesDiffCalculateRealtime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditAlwaysLiveCalculate.Name = "EditAlwaysLiveCalculate";
      this.EditAlwaysLiveCalculate.UseVisualStyleBackColor = true;
      this.EditAlwaysLiveCalculate.CheckedChanged += new System.EventHandler(this.EditAlwaysLiveCalculate_CheckedChanged);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      // 
      // ActionCalculate
      // 
      resources.ApplyResources(this.ActionCalculate, "ActionCalculate");
      this.ActionCalculate.Name = "ActionCalculate";
      this.ActionCalculate.Click += new System.EventHandler(this.ActionCalculate_Click);
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
      this.lunationsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datesDiffItemBindingSource, "Lunations", true));
      resources.ApplyResources(this.lunationsLabel1, "lunationsLabel1");
      this.lunationsLabel1.Name = "lunationsLabel1";
      // 
      // moonDaysLabel1
      // 
      this.moonDaysLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datesDiffItemBindingSource, "MoonDays", true));
      resources.ApplyResources(this.moonDaysLabel1, "moonDaysLabel1");
      this.moonDaysLabel1.Name = "moonDaysLabel1";
      // 
      // solarDaysLabel1
      // 
      this.solarDaysLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datesDiffItemBindingSource, "SolarDays", true));
      resources.ApplyResources(this.solarDaysLabel1, "solarDaysLabel1");
      this.solarDaysLabel1.Name = "solarDaysLabel1";
      // 
      // solarMonthsLabel1
      // 
      this.solarMonthsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datesDiffItemBindingSource, "SolarMonths", true));
      resources.ApplyResources(this.solarMonthsLabel1, "solarMonthsLabel1");
      this.solarMonthsLabel1.Name = "solarMonthsLabel1";
      // 
      // solarWeeksLabel1
      // 
      this.solarWeeksLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datesDiffItemBindingSource, "SolarWeeks", true));
      resources.ApplyResources(this.solarWeeksLabel1, "solarWeeksLabel1");
      this.solarWeeksLabel1.Name = "solarWeeksLabel1";
      // 
      // solarYearsLabel1
      // 
      this.solarYearsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.datesDiffItemBindingSource, "SolarYears", true));
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
      this.groupBox1.Controls.Add(lunationsLabel);
      this.groupBox1.Controls.Add(this.lunationsLabel1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
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
      // datesDiffItemBindingSource
      // 
      this.datesDiffItemBindingSource.DataSource = typeof(Ordisoftware.HebrewCalendar.DatesDiffItem);
      // 
      // DatesDiffForm
      // 
      this.AcceptButton = this.ActionCalculate;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
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
      this.PanelBottom.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditMaxYearsAutoCalculate)).EndInit();
      this.GroupBoxSun.ResumeLayout(false);
      this.GroupBoxSun.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.datesDiffItemBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Button ActionCalculate;
    private System.Windows.Forms.MonthCalendar MonthCalendar1;
    private System.Windows.Forms.MonthCalendar MonthCalendar2;
    private System.Windows.Forms.BindingSource datesDiffItemBindingSource;
    private System.Windows.Forms.Label lunationsLabel1;
    private System.Windows.Forms.Label moonDaysLabel1;
    private System.Windows.Forms.Label solarDaysLabel1;
    private System.Windows.Forms.Label solarMonthsLabel1;
    private System.Windows.Forms.Label solarWeeksLabel1;
    private System.Windows.Forms.Label solarYearsLabel1;
    private System.Windows.Forms.GroupBox GroupBoxSun;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox EditAlwaysLiveCalculate;
    private System.Windows.Forms.NumericUpDown EditMaxYearsAutoCalculate;
    private System.Windows.Forms.DateTimePicker DateTimePicker1;
    private System.Windows.Forms.DateTimePicker DateTimePicker2;
  }
}
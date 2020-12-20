namespace Ordisoftware.Hebrew.Calendar
{
  partial class CelebrationsBoardForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CelebrationsBoardForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.DataGridView = new System.Windows.Forms.DataGridView();
      this.PanelOptions = new System.Windows.Forms.Panel();
      this.EditColumnUpperCase = new System.Windows.Forms.CheckBox();
      this.EditUseLongDateFormat = new System.Windows.Forms.CheckBox();
      this.EditFontSize = new System.Windows.Forms.NumericUpDown();
      this.SelectYear1 = new Ordisoftware.Hebrew.Calendar.SelectYearControl();
      this.SelectYear2 = new Ordisoftware.Hebrew.Calendar.SelectYearControl();
      this.LabelEnd = new System.Windows.Forms.Label();
      this.LabelStart = new System.Windows.Forms.Label();
      this.LabelFontSize = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
      this.PanelOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // DataGridView
      // 
      this.DataGridView.AllowUserToAddRows = false;
      this.DataGridView.AllowUserToDeleteRows = false;
      this.DataGridView.AllowUserToResizeColumns = false;
      this.DataGridView.AllowUserToResizeRows = false;
      this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.DataGridView.BackgroundColor = System.Drawing.Color.White;
      resources.ApplyResources(this.DataGridView, "DataGridView");
      this.DataGridView.EnableHeadersVisualStyles = false;
      this.DataGridView.MultiSelect = false;
      this.DataGridView.Name = "DataGridView";
      this.DataGridView.ReadOnly = true;
      this.DataGridView.RowHeadersVisible = false;
      this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
      this.DataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView_ColumnAdded);
      // 
      // PanelOptions
      // 
      this.PanelOptions.Controls.Add(this.EditColumnUpperCase);
      this.PanelOptions.Controls.Add(this.EditUseLongDateFormat);
      this.PanelOptions.Controls.Add(this.EditFontSize);
      this.PanelOptions.Controls.Add(this.SelectYear1);
      this.PanelOptions.Controls.Add(this.SelectYear2);
      this.PanelOptions.Controls.Add(this.LabelEnd);
      this.PanelOptions.Controls.Add(this.LabelStart);
      this.PanelOptions.Controls.Add(this.LabelFontSize);
      resources.ApplyResources(this.PanelOptions, "PanelOptions");
      this.PanelOptions.Name = "PanelOptions";
      // 
      // EditColumnUpperCase
      // 
      resources.ApplyResources(this.EditColumnUpperCase, "EditColumnUpperCase");
      this.EditColumnUpperCase.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationsBoardFormUseTitleUpperCase;
      this.EditColumnUpperCase.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditColumnUpperCase.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationsBoardFormUseTitleUpperCase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditColumnUpperCase.Name = "EditColumnUpperCase";
      this.EditColumnUpperCase.UseVisualStyleBackColor = true;
      this.EditColumnUpperCase.CheckedChanged += new System.EventHandler(this.EditColumnUpperCase_CheckedChanged);
      // 
      // EditUseLongDateFormat
      // 
      resources.ApplyResources(this.EditUseLongDateFormat, "EditUseLongDateFormat");
      this.EditUseLongDateFormat.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationsBoardFormUseLongDateFormat;
      this.EditUseLongDateFormat.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditUseLongDateFormat.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationsBoardFormUseLongDateFormat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditUseLongDateFormat.Name = "EditUseLongDateFormat";
      this.EditUseLongDateFormat.UseVisualStyleBackColor = true;
      this.EditUseLongDateFormat.CheckedChanged += new System.EventHandler(this.EditUseLongDateFormat_CheckedChanged);
      // 
      // EditFontSize
      // 
      this.EditFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationsBoardFormFontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
      this.EditFontSize.Value = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationsBoardFormFontSize;
      this.EditFontSize.ValueChanged += new System.EventHandler(this.EditFontSize_ValueChanged);
      // 
      // SelectYear1
      // 
      resources.ApplyResources(this.SelectYear1, "SelectYear1");
      this.SelectYear1.Name = "SelectYear1";
      this.SelectYear1.SelectedIndex = -1;
      this.SelectYear1.SelectedItem = null;
      this.SelectYear1.SelectedIndexChanged += new System.EventHandler(this.SelectYear_SelectedIndexChanged);
      // 
      // SelectYear2
      // 
      resources.ApplyResources(this.SelectYear2, "SelectYear2");
      this.SelectYear2.Name = "SelectYear2";
      this.SelectYear2.SelectedIndex = -1;
      this.SelectYear2.SelectedItem = null;
      this.SelectYear2.SelectedIndexChanged += new System.EventHandler(this.SelectYear_SelectedIndexChanged);
      // 
      // LabelEnd
      // 
      resources.ApplyResources(this.LabelEnd, "LabelEnd");
      this.LabelEnd.Name = "LabelEnd";
      // 
      // LabelStart
      // 
      resources.ApplyResources(this.LabelStart, "LabelStart");
      this.LabelStart.Name = "LabelStart";
      // 
      // LabelFontSize
      // 
      resources.ApplyResources(this.LabelFontSize, "LabelFontSize");
      this.LabelFontSize.Name = "LabelFontSize";
      // 
      // CelebrationsBoardForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.ClientSize = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationsBoardFormClientSize;
      this.Controls.Add(this.DataGridView);
      this.Controls.Add(this.PanelOptions);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationsBoardFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationsBoardFormClientSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.Location = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationsBoardFormLocation;
      this.Name = "CelebrationsBoardForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CelebrationsBoardForm_FormClosed);
      this.Load += new System.EventHandler(this.CelebrationsBoardForm_Load);
      this.Shown += new System.EventHandler(this.CelebrationsBoardForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
      this.PanelOptions.ResumeLayout(false);
      this.PanelOptions.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.DataGridView DataGridView;
    private System.Windows.Forms.Panel PanelOptions;
    private System.Windows.Forms.CheckBox EditUseLongDateFormat;
    private System.Windows.Forms.NumericUpDown EditFontSize;
    private SelectYearControl SelectYear1;
    private SelectYearControl SelectYear2;
    private System.Windows.Forms.Label LabelEnd;
    private System.Windows.Forms.Label LabelStart;
    private System.Windows.Forms.Label LabelFontSize;
    private System.Windows.Forms.CheckBox EditColumnUpperCase;
  }
}
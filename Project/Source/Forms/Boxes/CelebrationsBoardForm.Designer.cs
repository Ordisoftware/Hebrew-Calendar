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
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.DataGridView = new System.Windows.Forms.DataGridView();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.PanelOptions = new System.Windows.Forms.Panel();
      this.EditUseLongDateFormat = new System.Windows.Forms.CheckBox();
      this.EditFontSize = new System.Windows.Forms.NumericUpDown();
      this.SelectYear1 = new Ordisoftware.Hebrew.Calendar.SelectYearControl();
      this.SelectYear2 = new Ordisoftware.Hebrew.Calendar.SelectYearControl();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
      this.PanelOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditFontSize)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottom.Location = new System.Drawing.Point(10, 573);
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Size = new System.Drawing.Size(964, 28);
      this.PanelBottom.TabIndex = 37;
      // 
      // ActionClose
      // 
      this.ActionClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionClose.Location = new System.Drawing.Point(882, 2);
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Size = new System.Drawing.Size(75, 24);
      this.ActionClose.TabIndex = 24;
      this.ActionClose.Text = "Close";
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
      this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DataGridView.Location = new System.Drawing.Point(10, 10);
      this.DataGridView.MultiSelect = false;
      this.DataGridView.Name = "DataGridView";
      this.DataGridView.ReadOnly = true;
      this.DataGridView.RowHeadersVisible = false;
      this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.DataGridView.Size = new System.Drawing.Size(964, 451);
      this.DataGridView.TabIndex = 25;
      this.DataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView_ColumnAdded);
      // 
      // PanelSeparator
      // 
      this.PanelSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelSeparator.Location = new System.Drawing.Point(10, 563);
      this.PanelSeparator.Name = "PanelSeparator";
      this.PanelSeparator.Size = new System.Drawing.Size(964, 10);
      this.PanelSeparator.TabIndex = 39;
      // 
      // PanelOptions
      // 
      this.PanelOptions.Controls.Add(this.EditUseLongDateFormat);
      this.PanelOptions.Controls.Add(this.EditFontSize);
      this.PanelOptions.Controls.Add(this.SelectYear1);
      this.PanelOptions.Controls.Add(this.SelectYear2);
      this.PanelOptions.Controls.Add(this.label3);
      this.PanelOptions.Controls.Add(this.label2);
      this.PanelOptions.Controls.Add(this.label1);
      this.PanelOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelOptions.Location = new System.Drawing.Point(10, 461);
      this.PanelOptions.Name = "PanelOptions";
      this.PanelOptions.Size = new System.Drawing.Size(964, 102);
      this.PanelOptions.TabIndex = 40;
      // 
      // EditUseLongDateFormat
      // 
      this.EditUseLongDateFormat.AutoSize = true;
      this.EditUseLongDateFormat.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationsBoardFormUseLongDateFormat;
      this.EditUseLongDateFormat.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditUseLongDateFormat.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationsBoardFormUseLongDateFormat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditUseLongDateFormat.Location = new System.Drawing.Point(214, 74);
      this.EditUseLongDateFormat.Name = "EditUseLongDateFormat";
      this.EditUseLongDateFormat.Size = new System.Drawing.Size(124, 17);
      this.EditUseLongDateFormat.TabIndex = 4;
      this.EditUseLongDateFormat.Text = "Use long date format";
      this.EditUseLongDateFormat.UseVisualStyleBackColor = true;
      this.EditUseLongDateFormat.CheckedChanged += new System.EventHandler(this.EditUseLongDateFormat_CheckedChanged);
      // 
      // EditFontSize
      // 
      this.EditFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationsBoardFormFontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditFontSize.Location = new System.Drawing.Point(214, 26);
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
      this.EditFontSize.Size = new System.Drawing.Size(46, 20);
      this.EditFontSize.TabIndex = 3;
      this.EditFontSize.Value = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationsBoardFormFontSize;
      this.EditFontSize.ValueChanged += new System.EventHandler(this.EditFontSize_ValueChanged);
      // 
      // SelectYear1
      // 
      this.SelectYear1.AutoSize = true;
      this.SelectYear1.Location = new System.Drawing.Point(13, 26);
      this.SelectYear1.Name = "SelectYear1";
      this.SelectYear1.SelectedIndex = -1;
      this.SelectYear1.SelectedItem = null;
      this.SelectYear1.Size = new System.Drawing.Size(179, 25);
      this.SelectYear1.TabIndex = 2;
      // 
      // SelectYear2
      // 
      this.SelectYear2.AutoSize = true;
      this.SelectYear2.Location = new System.Drawing.Point(13, 70);
      this.SelectYear2.Name = "SelectYear2";
      this.SelectYear2.SelectedIndex = -1;
      this.SelectYear2.SelectedItem = null;
      this.SelectYear2.Size = new System.Drawing.Size(179, 25);
      this.SelectYear2.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(10, 54);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(26, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "End";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Start";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(211, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Font size";
      // 
      // CelebrationsBoardForm
      // 
      this.AcceptButton = this.ActionClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.ClientSize = new System.Drawing.Size(984, 611);
      this.Controls.Add(this.DataGridView);
      this.Controls.Add(this.PanelOptions);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.PanelBottom);
      this.MinimumSize = new System.Drawing.Size(600, 500);
      this.Name = "CelebrationsBoardForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Celebrations board";
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
    private System.Windows.Forms.Panel PanelSeparator;
    private System.Windows.Forms.Panel PanelOptions;
    private System.Windows.Forms.CheckBox EditUseLongDateFormat;
    private System.Windows.Forms.NumericUpDown EditFontSize;
    private SelectYearControl SelectYear1;
    private SelectYearControl SelectYear2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}
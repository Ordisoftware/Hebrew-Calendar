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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.selectYearControl2 = new Ordisoftware.Hebrew.Calendar.SelectYearControl();
      this.selectYearControl1 = new Ordisoftware.Hebrew.Calendar.SelectYearControl();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
      this.PanelOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottom.Location = new System.Drawing.Point(10, 709);
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Size = new System.Drawing.Size(1009, 28);
      this.PanelBottom.TabIndex = 37;
      // 
      // ActionClose
      // 
      this.ActionClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionClose.Location = new System.Drawing.Point(927, 2);
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Size = new System.Drawing.Size(75, 24);
      this.ActionClose.TabIndex = 24;
      this.ActionClose.Text = "Close";
      // 
      // DataGridView
      // 
      this.DataGridView.AllowUserToAddRows = false;
      this.DataGridView.AllowUserToDeleteRows = false;
      this.DataGridView.AllowUserToOrderColumns = true;
      this.DataGridView.AllowUserToResizeColumns = false;
      this.DataGridView.AllowUserToResizeRows = false;
      this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.DataGridView.BackgroundColor = System.Drawing.Color.White;
      this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DataGridView.Location = new System.Drawing.Point(10, 10);
      this.DataGridView.MultiSelect = false;
      this.DataGridView.Name = "DataGridView";
      this.DataGridView.ReadOnly = true;
      this.DataGridView.RowHeadersVisible = false;
      this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DataGridView.Size = new System.Drawing.Size(1009, 587);
      this.DataGridView.TabIndex = 25;
      // 
      // PanelSeparator
      // 
      this.PanelSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelSeparator.Location = new System.Drawing.Point(10, 699);
      this.PanelSeparator.Name = "PanelSeparator";
      this.PanelSeparator.Size = new System.Drawing.Size(1009, 10);
      this.PanelSeparator.TabIndex = 39;
      // 
      // PanelOptions
      // 
      this.PanelOptions.Controls.Add(this.checkBox1);
      this.PanelOptions.Controls.Add(this.numericUpDown1);
      this.PanelOptions.Controls.Add(this.selectYearControl2);
      this.PanelOptions.Controls.Add(this.selectYearControl1);
      this.PanelOptions.Controls.Add(this.label3);
      this.PanelOptions.Controls.Add(this.label2);
      this.PanelOptions.Controls.Add(this.label1);
      this.PanelOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelOptions.Location = new System.Drawing.Point(10, 597);
      this.PanelOptions.Name = "PanelOptions";
      this.PanelOptions.Size = new System.Drawing.Size(1009, 102);
      this.PanelOptions.TabIndex = 40;
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
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Start";
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
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(214, 26);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numericUpDown1.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(46, 20);
      this.numericUpDown1.TabIndex = 3;
      this.numericUpDown1.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(214, 74);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(124, 17);
      this.checkBox1.TabIndex = 4;
      this.checkBox1.Text = "Use long date format";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // selectYearControl2
      // 
      this.selectYearControl2.AutoSize = true;
      this.selectYearControl2.Location = new System.Drawing.Point(13, 26);
      this.selectYearControl2.Name = "selectYearControl2";
      this.selectYearControl2.SelectedIndex = -1;
      this.selectYearControl2.SelectedItem = null;
      this.selectYearControl2.Size = new System.Drawing.Size(179, 25);
      this.selectYearControl2.TabIndex = 2;
      // 
      // selectYearControl1
      // 
      this.selectYearControl1.AutoSize = true;
      this.selectYearControl1.Location = new System.Drawing.Point(13, 70);
      this.selectYearControl1.Name = "selectYearControl1";
      this.selectYearControl1.SelectedIndex = -1;
      this.selectYearControl1.SelectedItem = null;
      this.selectYearControl1.Size = new System.Drawing.Size(179, 25);
      this.selectYearControl1.TabIndex = 1;
      // 
      // CelebrationsBoardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1029, 747);
      this.Controls.Add(this.DataGridView);
      this.Controls.Add(this.PanelOptions);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.PanelBottom);
      this.Name = "CelebrationsBoardForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.Text = "Celebrations board";
      this.Load += new System.EventHandler(this.CelebrationsBoardForm_Load);
      this.PanelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
      this.PanelOptions.ResumeLayout(false);
      this.PanelOptions.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.DataGridView DataGridView;
    private System.Windows.Forms.Panel PanelSeparator;
    private System.Windows.Forms.Panel PanelOptions;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private SelectYearControl selectYearControl2;
    private SelectYearControl selectYearControl1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}
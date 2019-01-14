namespace Ordisoftware.HebrewCalendar
{
  partial class SelectYearsForm
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
      this.editYearLast = new System.Windows.Forms.NumericUpDown();
      this.labelYearLast = new System.Windows.Forms.Label();
      this.editYearFirst = new System.Windows.Forms.NumericUpDown();
      this.labelYearFirst = new System.Windows.Forms.Label();
      this.buttonOk = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.buttonCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.editYearLast)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.editYearFirst)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // editYearLast
      // 
      this.editYearLast.Location = new System.Drawing.Point(94, 44);
      this.editYearLast.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
      this.editYearLast.Minimum = new decimal(new int[] {
            1902,
            0,
            0,
            0});
      this.editYearLast.Name = "editYearLast";
      this.editYearLast.Size = new System.Drawing.Size(50, 20);
      this.editYearLast.TabIndex = 47;
      this.editYearLast.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
      // 
      // labelYearLast
      // 
      this.labelYearLast.AutoSize = true;
      this.labelYearLast.Location = new System.Drawing.Point(37, 46);
      this.labelYearLast.Name = "labelYearLast";
      this.labelYearLast.Size = new System.Drawing.Size(52, 13);
      this.labelYearLast.TabIndex = 48;
      this.labelYearLast.Text = "Last Year";
      // 
      // editYearFirst
      // 
      this.editYearFirst.Location = new System.Drawing.Point(94, 19);
      this.editYearFirst.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
      this.editYearFirst.Minimum = new decimal(new int[] {
            1902,
            0,
            0,
            0});
      this.editYearFirst.Name = "editYearFirst";
      this.editYearFirst.Size = new System.Drawing.Size(50, 20);
      this.editYearFirst.TabIndex = 46;
      this.editYearFirst.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
      // 
      // labelYearFirst
      // 
      this.labelYearFirst.AutoSize = true;
      this.labelYearFirst.Location = new System.Drawing.Point(37, 21);
      this.labelYearFirst.Name = "labelYearFirst";
      this.labelYearFirst.Size = new System.Drawing.Size(51, 13);
      this.labelYearFirst.TabIndex = 49;
      this.labelYearFirst.Text = "First Year";
      // 
      // buttonOk
      // 
      this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOk.Location = new System.Drawing.Point(2, 2);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 24);
      this.buttonOk.TabIndex = 50;
      this.buttonOk.Text = "Ok";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.buttonCancel);
      this.panel1.Controls.Add(this.buttonOk);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(10, 78);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(161, 28);
      this.panel1.TabIndex = 52;
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(83, 2);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 24);
      this.buttonCancel.TabIndex = 24;
      this.buttonCancel.Text = "Cancel";
      // 
      // SelectYearsRangeForm
      // 
      this.AcceptButton = this.buttonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(181, 116);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.editYearLast);
      this.Controls.Add(this.labelYearLast);
      this.Controls.Add(this.editYearFirst);
      this.Controls.Add(this.labelYearFirst);
      this.Name = "SelectYearsRangeForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select years";
      this.Load += new System.EventHandler(this.SelectYearsRangeForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.editYearLast)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.editYearFirst)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label labelYearLast;
    private System.Windows.Forms.Label labelYearFirst;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button buttonCancel;
    internal System.Windows.Forms.NumericUpDown editYearLast;
    internal System.Windows.Forms.NumericUpDown editYearFirst;
  }
}
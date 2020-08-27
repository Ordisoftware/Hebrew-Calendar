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
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionCalculate = new System.Windows.Forms.Button();
      this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
      this.MonthCalendar2 = new System.Windows.Forms.MonthCalendar();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Controls.Add(this.ActionCalculate);
      this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottom.Location = new System.Drawing.Point(10, 376);
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Size = new System.Drawing.Size(559, 28);
      this.PanelBottom.TabIndex = 38;
      // 
      // ActionClose
      // 
      this.ActionClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionClose.Location = new System.Drawing.Point(478, 2);
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Size = new System.Drawing.Size(75, 24);
      this.ActionClose.TabIndex = 24;
      this.ActionClose.Text = "Close";
      // 
      // ActionCalculate
      // 
      this.ActionCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionCalculate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionCalculate.Location = new System.Drawing.Point(397, 2);
      this.ActionCalculate.Name = "ActionCalculate";
      this.ActionCalculate.Size = new System.Drawing.Size(75, 24);
      this.ActionCalculate.TabIndex = 24;
      this.ActionCalculate.Text = "Calculate";
      this.ActionCalculate.Click += new System.EventHandler(this.ActionCalculate_Click);
      // 
      // MonthCalendar1
      // 
      this.MonthCalendar1.Location = new System.Drawing.Point(333, 19);
      this.MonthCalendar1.Name = "MonthCalendar1";
      this.MonthCalendar1.TabIndex = 39;
      // 
      // MonthCalendar2
      // 
      this.MonthCalendar2.Location = new System.Drawing.Point(333, 199);
      this.MonthCalendar2.Name = "MonthCalendar2";
      this.MonthCalendar2.TabIndex = 40;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(18, 244);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(300, 117);
      this.textBox1.TabIndex = 41;
      // 
      // DatesDiffForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.ClientSize = new System.Drawing.Size(579, 414);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.MonthCalendar2);
      this.Controls.Add(this.MonthCalendar1);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = new System.Drawing.Point(-1, -1);
      this.Name = "DatesDiffForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "DateDiffForm";
      this.Load += new System.EventHandler(this.DateDiffForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Button ActionCalculate;
    private System.Windows.Forms.MonthCalendar MonthCalendar1;
    private System.Windows.Forms.MonthCalendar MonthCalendar2;
    private System.Windows.Forms.TextBox textBox1;
  }
}
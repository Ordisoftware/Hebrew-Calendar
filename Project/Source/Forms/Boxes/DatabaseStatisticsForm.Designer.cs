namespace Ordisoftware.HebrewCalendar
{
  partial class DatabaseStatisticsForm
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
      this.TextBox = new System.Windows.Forms.TextBox();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottom.Location = new System.Drawing.Point(10, 325);
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Size = new System.Drawing.Size(425, 28);
      this.PanelBottom.TabIndex = 37;
      // 
      // ActionClose
      // 
      this.ActionClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionClose.Location = new System.Drawing.Point(343, 2);
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Size = new System.Drawing.Size(75, 24);
      this.ActionClose.TabIndex = 24;
      this.ActionClose.Text = "Close";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // TextBox
      // 
      this.TextBox.Location = new System.Drawing.Point(13, 13);
      this.TextBox.Multiline = true;
      this.TextBox.Name = "TextBox";
      this.TextBox.Size = new System.Drawing.Size(419, 300);
      this.TextBox.TabIndex = 38;
      // 
      // DatabaseStatisticsForm
      // 
      this.AcceptButton = this.ActionClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.ClientSize = new System.Drawing.Size(445, 363);
      this.Controls.Add(this.TextBox);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = new System.Drawing.Point(-1, -1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DatabaseStatisticsForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Statistics";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseStatisticsForm_FormClosing);
      this.Load += new System.EventHandler(this.DatabaseStatisticsForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.TextBox TextBox;
  }
}
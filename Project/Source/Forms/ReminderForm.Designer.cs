namespace Ordisoftware.HebrewCalendar
{
  partial class ReminderForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderForm));
      this.LabelNextCelebrationText = new System.Windows.Forms.Label();
      this.LabelNextCelebrationDate = new System.Windows.Forms.LinkLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.ButtonClose = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelNextCelebrationText
      // 
      resources.ApplyResources(this.LabelNextCelebrationText, "LabelNextCelebrationText");
      this.LabelNextCelebrationText.ForeColor = System.Drawing.Color.DarkRed;
      this.LabelNextCelebrationText.Name = "LabelNextCelebrationText";
      // 
      // LabelNextCelebrationDate
      // 
      resources.ApplyResources(this.LabelNextCelebrationDate, "LabelNextCelebrationDate");
      this.LabelNextCelebrationDate.ForeColor = System.Drawing.SystemColors.ControlText;
      this.LabelNextCelebrationDate.Name = "LabelNextCelebrationDate";
      this.LabelNextCelebrationDate.TabStop = true;
      this.LabelNextCelebrationDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelNextCelebrationDate_LinkClicked);
      // 
      // pictureBox1
      // 
      resources.ApplyResources(this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      // 
      // ButtonClose
      // 
      this.ButtonClose.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ButtonClose, "ButtonClose");
      this.ButtonClose.Name = "ButtonClose";
      this.ButtonClose.UseVisualStyleBackColor = true;
      this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
      // 
      // ReminderForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ButtonClose);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.LabelNextCelebrationDate);
      this.Controls.Add(this.LabelNextCelebrationText);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ReminderForm";
      this.TopMost = true;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReminderForm_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LabelNextCelebrationText;
    private System.Windows.Forms.LinkLabel LabelNextCelebrationDate;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button ButtonClose;
  }
}
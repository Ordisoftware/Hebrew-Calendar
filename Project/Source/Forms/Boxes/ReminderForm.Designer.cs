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
      this.PictureBox = new System.Windows.Forms.PictureBox();
      this.ActionClose = new System.Windows.Forms.Button();
      this.LabelHours = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
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
      this.LabelNextCelebrationDate.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.LabelNextCelebrationDate, "LabelNextCelebrationDate");
      this.LabelNextCelebrationDate.ForeColor = System.Drawing.SystemColors.ControlText;
      this.LabelNextCelebrationDate.LinkColor = System.Drawing.Color.Navy;
      this.LabelNextCelebrationDate.Name = "LabelNextCelebrationDate";
      this.LabelNextCelebrationDate.TabStop = true;
      this.LabelNextCelebrationDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelNextCelebrationDate_LinkClicked);
      // 
      // PictureBox
      // 
      resources.ApplyResources(this.PictureBox, "PictureBox");
      this.PictureBox.Name = "PictureBox";
      this.PictureBox.TabStop = false;
      this.PictureBox.Click += new System.EventHandler(this.Form_Click);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.FlatAppearance.BorderSize = 0;
      this.ActionClose.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.UseVisualStyleBackColor = true;
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // LabelHours
      // 
      resources.ApplyResources(this.LabelHours, "LabelHours");
      this.LabelHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.LabelHours.Name = "LabelHours";
      // 
      // ReminderForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.LabelHours);
      this.Controls.Add(this.ActionClose);
      this.Controls.Add(this.PictureBox);
      this.Controls.Add(this.LabelNextCelebrationDate);
      this.Controls.Add(this.LabelNextCelebrationText);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ReminderForm";
      this.TopMost = true;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReminderForm_FormClosed);
      this.Shown += new System.EventHandler(this.ReminderForm_Shown);
      this.Click += new System.EventHandler(this.Form_Click);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LabelNextCelebrationText;
    private System.Windows.Forms.LinkLabel LabelNextCelebrationDate;
    private System.Windows.Forms.PictureBox PictureBox;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Label LabelHours;
  }
}
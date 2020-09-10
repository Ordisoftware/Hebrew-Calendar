namespace Ordisoftware.Hebrew.Calendar
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
      this.LabelTitle = new System.Windows.Forms.Label();
      this.LabelDate = new System.Windows.Forms.LinkLabel();
      this.PictureBox = new System.Windows.Forms.PictureBox();
      this.ActionClose = new System.Windows.Forms.Button();
      this.LabelHours = new System.Windows.Forms.Label();
      this.ActionSetup = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelTitle
      // 
      resources.ApplyResources(this.LabelTitle, "LabelTitle");
      this.LabelTitle.ForeColor = System.Drawing.Color.DarkRed;
      this.LabelTitle.Name = "LabelTitle";
      // 
      // LabelDate
      // 
      this.LabelDate.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.LabelDate, "LabelDate");
      this.LabelDate.ForeColor = System.Drawing.SystemColors.ControlText;
      this.LabelDate.LinkColor = System.Drawing.Color.Navy;
      this.LabelDate.Name = "LabelDate";
      this.LabelDate.TabStop = true;
      this.LabelDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelDate_LinkClicked);
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
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
      // ActionSetup
      // 
      resources.ApplyResources(this.ActionSetup, "ActionSetup");
      this.ActionSetup.FlatAppearance.BorderSize = 0;
      this.ActionSetup.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ActionSetup.Name = "ActionSetup";
      this.ActionSetup.UseVisualStyleBackColor = true;
      this.ActionSetup.Click += new System.EventHandler(this.ActionSetup_Click);
      // 
      // ReminderForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.LabelHours);
      this.Controls.Add(this.ActionSetup);
      this.Controls.Add(this.ActionClose);
      this.Controls.Add(this.PictureBox);
      this.Controls.Add(this.LabelDate);
      this.Controls.Add(this.LabelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.LinkLabel LabelDate;
    private System.Windows.Forms.PictureBox PictureBox;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Label LabelHours;
    private System.Windows.Forms.Button ActionSetup;
  }
}
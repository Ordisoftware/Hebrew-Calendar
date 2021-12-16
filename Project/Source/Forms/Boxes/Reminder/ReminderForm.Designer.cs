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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderForm));
      this.LabelTitle = new System.Windows.Forms.Label();
      this.LabelDate = new System.Windows.Forms.LinkLabel();
      this.PictureBox = new System.Windows.Forms.PictureBox();
      this.ActionClose = new System.Windows.Forms.Button();
      this.LabelStartTime = new System.Windows.Forms.Label();
      this.ActionPreferences = new System.Windows.Forms.Button();
      this.LabelEndTime = new System.Windows.Forms.Label();
      this.LabelArrow = new System.Windows.Forms.Label();
      this.LabelStartDay = new System.Windows.Forms.Label();
      this.LabelEndDay = new System.Windows.Forms.Label();
      this.LabelParashahValue = new System.Windows.Forms.LinkLabel();
      this.ContextMenuParashah = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionViewParashahInfos = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewParashot = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionStudyOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenVerseOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewWordsVerse = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionLockout = new System.Windows.Forms.Button();
      this.ContextMenuLockout = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.MenuDefaultLockout = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionSetupSound = new System.Windows.Forms.Button();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
      this.ContextMenuParashah.SuspendLayout();
      this.ContextMenuLockout.SuspendLayout();
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
      this.PictureBox.BackColor = System.Drawing.Color.Transparent;
      resources.ApplyResources(this.PictureBox, "PictureBox");
      this.PictureBox.Name = "PictureBox";
      this.PictureBox.TabStop = false;
      this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
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
      // LabelStartTime
      // 
      resources.ApplyResources(this.LabelStartTime, "LabelStartTime");
      this.LabelStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.LabelStartTime.Name = "LabelStartTime";
      // 
      // ActionPreferences
      // 
      resources.ApplyResources(this.ActionPreferences, "ActionPreferences");
      this.ActionPreferences.FlatAppearance.BorderSize = 0;
      this.ActionPreferences.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ActionPreferences.Name = "ActionPreferences";
      this.ActionPreferences.UseVisualStyleBackColor = true;
      this.ActionPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      // 
      // LabelEndTime
      // 
      resources.ApplyResources(this.LabelEndTime, "LabelEndTime");
      this.LabelEndTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.LabelEndTime.Name = "LabelEndTime";
      // 
      // LabelArrow
      // 
      resources.ApplyResources(this.LabelArrow, "LabelArrow");
      this.LabelArrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.LabelArrow.Name = "LabelArrow";
      // 
      // LabelStartDay
      // 
      resources.ApplyResources(this.LabelStartDay, "LabelStartDay");
      this.LabelStartDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.LabelStartDay.Name = "LabelStartDay";
      // 
      // LabelEndDay
      // 
      resources.ApplyResources(this.LabelEndDay, "LabelEndDay");
      this.LabelEndDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.LabelEndDay.Name = "LabelEndDay";
      // 
      // LabelParashahValue
      // 
      this.LabelParashahValue.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.LabelParashahValue, "LabelParashahValue");
      this.LabelParashahValue.ContextMenuStrip = this.ContextMenuParashah;
      this.LabelParashahValue.LinkColor = System.Drawing.Color.Navy;
      this.LabelParashahValue.Name = "LabelParashahValue";
      this.LabelParashahValue.TabStop = true;
      this.LabelParashahValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelParashahValue_LinkClicked);
      // 
      // ContextMenuParashah
      // 
      this.ContextMenuParashah.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionViewParashahInfos,
            this.toolStripSeparator3,
            this.ActionViewParashot,
            this.toolStripSeparator1,
            this.ActionStudyOnline,
            this.ActionOpenVerseOnline,
            this.toolStripSeparator2,
            this.ActionOpenHebrewWordsVerse});
      this.ContextMenuParashah.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenuParashah, "ContextMenuParashah");
      // 
      // ActionViewParashahInfos
      // 
      resources.ApplyResources(this.ActionViewParashahInfos, "ActionViewParashahInfos");
      this.ActionViewParashahInfos.Name = "ActionViewParashahInfos";
      this.ActionViewParashahInfos.Click += new System.EventHandler(this.ActionViewParashahDescription_Click);
      // 
      // ActionViewParashot
      // 
      resources.ApplyResources(this.ActionViewParashot, "ActionViewParashot");
      this.ActionViewParashot.Name = "ActionViewParashot";
      this.ActionViewParashot.Click += new System.EventHandler(this.ActionViewParashot_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // ActionStudyOnline
      // 
      resources.ApplyResources(this.ActionStudyOnline, "ActionStudyOnline");
      this.ActionStudyOnline.Name = "ActionStudyOnline";
      // 
      // ActionOpenVerseOnline
      // 
      resources.ApplyResources(this.ActionOpenVerseOnline, "ActionOpenVerseOnline");
      this.ActionOpenVerseOnline.Name = "ActionOpenVerseOnline";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // ActionOpenHebrewWordsVerse
      // 
      resources.ApplyResources(this.ActionOpenHebrewWordsVerse, "ActionOpenHebrewWordsVerse");
      this.ActionOpenHebrewWordsVerse.Name = "ActionOpenHebrewWordsVerse";
      this.ActionOpenHebrewWordsVerse.Click += new System.EventHandler(this.ActionOpenHebrewWordsVerse_Click);
      // 
      // ActionLockout
      // 
      this.ActionLockout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionLockout.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionLockout, "ActionLockout");
      this.ActionLockout.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ActionLockout.Name = "ActionLockout";
      this.ActionLockout.UseVisualStyleBackColor = true;
      this.ActionLockout.Click += new System.EventHandler(this.ActionLockout_Click);
      // 
      // ContextMenuLockout
      // 
      this.ContextMenuLockout.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDefaultLockout});
      this.ContextMenuLockout.Name = "ContextMenuStripLockout";
      resources.ApplyResources(this.ContextMenuLockout, "ContextMenuLockout");
      // 
      // MenuDefaultLockout
      // 
      resources.ApplyResources(this.MenuDefaultLockout, "MenuDefaultLockout");
      this.MenuDefaultLockout.Name = "MenuDefaultLockout";
      // 
      // ActionSetupSound
      // 
      resources.ApplyResources(this.ActionSetupSound, "ActionSetupSound");
      this.ActionSetupSound.FlatAppearance.BorderSize = 0;
      this.ActionSetupSound.Name = "ActionSetupSound";
      this.ActionSetupSound.UseVisualStyleBackColor = true;
      this.ActionSetupSound.Click += new System.EventHandler(this.ActionSetupSound_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
      // 
      // ReminderForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.ActionSetupSound);
      this.Controls.Add(this.LabelParashahValue);
      this.Controls.Add(this.LabelEndDay);
      this.Controls.Add(this.LabelEndTime);
      this.Controls.Add(this.LabelArrow);
      this.Controls.Add(this.LabelStartDay);
      this.Controls.Add(this.LabelStartTime);
      this.Controls.Add(this.ActionPreferences);
      this.Controls.Add(this.ActionLockout);
      this.Controls.Add(this.ActionClose);
      this.Controls.Add(this.PictureBox);
      this.Controls.Add(this.LabelDate);
      this.Controls.Add(this.LabelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ReminderForm";
      this.ShowIcon = false;
      this.TopMost = true;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReminderForm_FormClosed);
      this.Load += new System.EventHandler(this.ReminderForm_Load);
      this.Shown += new System.EventHandler(this.ReminderForm_Shown);
      this.Click += new System.EventHandler(this.Form_Click);
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
      this.ContextMenuParashah.ResumeLayout(false);
      this.ContextMenuLockout.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.LinkLabel LabelDate;
    private System.Windows.Forms.PictureBox PictureBox;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Label LabelStartTime;
    private System.Windows.Forms.Button ActionPreferences;
    private System.Windows.Forms.Label LabelEndTime;
    private System.Windows.Forms.Label LabelArrow;
    private System.Windows.Forms.Label LabelStartDay;
    private System.Windows.Forms.Label LabelEndDay;
    private System.Windows.Forms.LinkLabel LabelParashahValue;
    private System.Windows.Forms.ContextMenuStrip ContextMenuParashah;
    private System.Windows.Forms.ToolStripMenuItem ActionStudyOnline;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenVerseOnline;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewParashot;
    private System.Windows.Forms.ToolStripMenuItem ActionViewParashahInfos;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.Button ActionLockout;
    private System.Windows.Forms.ContextMenuStrip ContextMenuLockout;
    private System.Windows.Forms.ToolStripMenuItem MenuDefaultLockout;
    private System.Windows.Forms.Button ActionSetupSound;
    private ToolStripMenuItem ActionOpenHebrewWordsVerse;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSeparator toolStripSeparator3;
  }
}
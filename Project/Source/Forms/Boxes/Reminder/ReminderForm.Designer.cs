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
      this.ActionSetup = new System.Windows.Forms.Button();
      this.LabelEndTime = new System.Windows.Forms.Label();
      this.LabelArrow = new System.Windows.Forms.Label();
      this.LabelStartDay = new System.Windows.Forms.Label();
      this.LabelEndDay = new System.Windows.Forms.Label();
      this.LabelParashahValue = new System.Windows.Forms.LinkLabel();
      this.ContextMenuParashah = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionViewParashot = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionViewParashahInfos = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionStudyOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenVerseOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionLockout = new System.Windows.Forms.Button();
      this.ContextMenuStripLockout = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.MenuDefaultLockout = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
      this.ContextMenuParashah.SuspendLayout();
      this.ContextMenuStripLockout.SuspendLayout();
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
      // LabelStartTime
      // 
      resources.ApplyResources(this.LabelStartTime, "LabelStartTime");
      this.LabelStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.LabelStartTime.Name = "LabelStartTime";
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
            this.ActionViewParashot,
            this.toolStripSeparator1,
            this.ActionViewParashahInfos,
            this.toolStripSeparator2,
            this.ActionStudyOnline,
            this.ActionOpenVerseOnline});
      this.ContextMenuParashah.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenuParashah, "ContextMenuParashah");
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
      // ActionViewParashahInfos
      // 
      resources.ApplyResources(this.ActionViewParashahInfos, "ActionViewParashahInfos");
      this.ActionViewParashahInfos.Name = "ActionViewParashahInfos";
      this.ActionViewParashahInfos.Click += new System.EventHandler(this.ActionViewParashahInfos_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
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
      // ActionLockout
      // 
      resources.ApplyResources(this.ActionLockout, "ActionLockout");
      this.ActionLockout.ContextMenuStrip = this.ContextMenuParashah;
      this.ActionLockout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionLockout.FlatAppearance.BorderSize = 0;
      this.ActionLockout.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ActionLockout.Name = "ActionLockout";
      this.ActionLockout.UseVisualStyleBackColor = true;
      this.ActionLockout.Click += new System.EventHandler(this.ActionLockout_Click);
      // 
      // ContextMenuStripLockout
      // 
      this.ContextMenuStripLockout.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDefaultLockout});
      this.ContextMenuStripLockout.Name = "ContextMenuStripLockout";
      resources.ApplyResources(this.ContextMenuStripLockout, "ContextMenuStripLockout");
      // 
      // MenuDefaultLockout
      // 
      resources.ApplyResources(this.MenuDefaultLockout, "MenuDefaultLockout");
      this.MenuDefaultLockout.Name = "MenuDefaultLockout";
      // 
      // ReminderForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.LabelParashahValue);
      this.Controls.Add(this.LabelEndDay);
      this.Controls.Add(this.LabelEndTime);
      this.Controls.Add(this.LabelArrow);
      this.Controls.Add(this.LabelStartDay);
      this.Controls.Add(this.LabelStartTime);
      this.Controls.Add(this.ActionSetup);
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
      this.ContextMenuStripLockout.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.LinkLabel LabelDate;
    private System.Windows.Forms.PictureBox PictureBox;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Label LabelStartTime;
    private System.Windows.Forms.Button ActionSetup;
    private System.Windows.Forms.Label LabelEndTime;
    private System.Windows.Forms.Label LabelArrow;
    private System.Windows.Forms.Label LabelStartDay;
    private System.Windows.Forms.Label LabelEndDay;
    private System.Windows.Forms.LinkLabel LabelParashahValue;
    private System.Windows.Forms.ContextMenuStrip ContextMenuParashah;
    private System.Windows.Forms.ToolStripMenuItem ActionStudyOnline;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenVerseOnline;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewParashot;
    private System.Windows.Forms.ToolStripMenuItem ActionViewParashahInfos;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.Button ActionLockout;
    private System.Windows.Forms.ContextMenuStrip ContextMenuStripLockout;
    private System.Windows.Forms.ToolStripMenuItem MenuDefaultLockout;
  }
}
namespace Ordisoftware.Hebrew.Calendar
{
  partial class LockSessionForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockSessionForm));
      this.LabelCountDown = new System.Windows.Forms.Label();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionDisable = new System.Windows.Forms.Button();
      this.ActionOk = new System.Windows.Forms.Button();
      this.ActionShutdown = new System.Windows.Forms.LinkLabel();
      this.ActionHibernate = new System.Windows.Forms.LinkLabel();
      this.ActionStandby = new System.Windows.Forms.LinkLabel();
      this.LabelMessage = new System.Windows.Forms.Label();
      this.Timer = new System.Windows.Forms.Timer(this.components);
      this.EditMediaStop = new System.Windows.Forms.CheckBox();
      this.ActionLock = new System.Windows.Forms.LinkLabel();
      this.ActionPreferences = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // LabelCountDown
      // 
      resources.ApplyResources(this.LabelCountDown, "LabelCountDown");
      this.LabelCountDown.ForeColor = System.Drawing.Color.DarkRed;
      this.LabelCountDown.Name = "LabelCountDown";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Click += new System.EventHandler(this.ActionCancel_Click);
      // 
      // ActionDisable
      // 
      resources.ApplyResources(this.ActionDisable, "ActionDisable");
      this.ActionDisable.Name = "ActionDisable";
      this.ActionDisable.UseVisualStyleBackColor = true;
      this.ActionDisable.Click += new System.EventHandler(this.ActionDisable_Click);
      // 
      // ActionOk
      // 
      resources.ApplyResources(this.ActionOk, "ActionOk");
      this.ActionOk.Name = "ActionOk";
      this.ActionOk.UseVisualStyleBackColor = true;
      this.ActionOk.Click += new System.EventHandler(this.ActionOk_Click);
      // 
      // ActionShutdown
      // 
      this.ActionShutdown.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionShutdown, "ActionShutdown");
      this.ActionShutdown.LinkColor = System.Drawing.Color.DarkBlue;
      this.ActionShutdown.Name = "ActionShutdown";
      this.ActionShutdown.TabStop = true;
      this.ActionShutdown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionShutdown_Click);
      // 
      // ActionHibernate
      // 
      this.ActionHibernate.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionHibernate, "ActionHibernate");
      this.ActionHibernate.LinkColor = System.Drawing.Color.DarkBlue;
      this.ActionHibernate.Name = "ActionHibernate";
      this.ActionHibernate.TabStop = true;
      this.ActionHibernate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionHibernate_Click);
      // 
      // ActionStandby
      // 
      this.ActionStandby.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionStandby, "ActionStandby");
      this.ActionStandby.LinkColor = System.Drawing.Color.DarkBlue;
      this.ActionStandby.Name = "ActionStandby";
      this.ActionStandby.TabStop = true;
      this.ActionStandby.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionStandby_Click);
      // 
      // LabelMessage
      // 
      resources.ApplyResources(this.LabelMessage, "LabelMessage");
      this.LabelMessage.Name = "LabelMessage";
      // 
      // Timer
      // 
      this.Timer.Interval = 1000;
      this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
      // 
      // EditMediaStop
      // 
      resources.ApplyResources(this.EditMediaStop, "EditMediaStop");
      this.EditMediaStop.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.LockSessionMediaStop;
      this.EditMediaStop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "LockSessionMediaStop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditMediaStop.Name = "EditMediaStop";
      this.EditMediaStop.UseVisualStyleBackColor = true;
      // 
      // ActionLock
      // 
      this.ActionLock.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionLock, "ActionLock");
      this.ActionLock.LinkColor = System.Drawing.Color.DarkBlue;
      this.ActionLock.Name = "ActionLock";
      this.ActionLock.TabStop = true;
      this.ActionLock.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionStandby_Click);
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
      // LockSessionForm
      // 
      this.AcceptButton = this.ActionOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ActionPreferences);
      this.Controls.Add(this.LabelCountDown);
      this.Controls.Add(this.ActionShutdown);
      this.Controls.Add(this.ActionCancel);
      this.Controls.Add(this.EditMediaStop);
      this.Controls.Add(this.ActionDisable);
      this.Controls.Add(this.ActionHibernate);
      this.Controls.Add(this.ActionOk);
      this.Controls.Add(this.ActionLock);
      this.Controls.Add(this.ActionStandby);
      this.Controls.Add(this.LabelMessage);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LockSessionForm";
      this.TopMost = true;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LockSessionForm_FormClosed);
      this.Load += new System.EventHandler(this.LockSessionForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOk;
    private System.Windows.Forms.Label LabelCountDown;
    private System.Windows.Forms.Label LabelMessage;
    public System.Windows.Forms.Timer Timer;
    private System.Windows.Forms.CheckBox EditMediaStop;
    private System.Windows.Forms.LinkLabel ActionHibernate;
    private System.Windows.Forms.LinkLabel ActionStandby;
    private System.Windows.Forms.LinkLabel ActionShutdown;
    private System.Windows.Forms.Button ActionDisable;
    private System.Windows.Forms.LinkLabel ActionLock;
    private System.Windows.Forms.Button ActionPreferences;
  }
}
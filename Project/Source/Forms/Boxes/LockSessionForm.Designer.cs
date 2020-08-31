namespace Ordisoftware.HebrewCalendar
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
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.LabelCountDown = new System.Windows.Forms.Label();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionDisable = new System.Windows.Forms.Button();
      this.ActionLock = new System.Windows.Forms.Button();
      this.ActionShutdown = new System.Windows.Forms.LinkLabel();
      this.ActionHibernate = new System.Windows.Forms.LinkLabel();
      this.ActionStandby = new System.Windows.Forms.LinkLabel();
      this.LabelMessage = new System.Windows.Forms.Label();
      this.Timer = new System.Windows.Forms.Timer(this.components);
      this.EditMediaStop = new System.Windows.Forms.CheckBox();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.LabelCountDown);
      this.PanelButtons.Controls.Add(this.ActionCancel);
      this.PanelButtons.Controls.Add(this.ActionDisable);
      this.PanelButtons.Controls.Add(this.ActionLock);
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Name = "PanelButtons";
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
      // ActionLock
      // 
      resources.ApplyResources(this.ActionLock, "ActionLock");
      this.ActionLock.Name = "ActionLock";
      this.ActionLock.UseVisualStyleBackColor = true;
      this.ActionLock.Click += new System.EventHandler(this.ActionOK_Click);
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
      this.EditMediaStop.Checked = global::Ordisoftware.HebrewCalendar.Properties.Settings.Default.LockSessionMediaStop;
      this.EditMediaStop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.HebrewCalendar.Properties.Settings.Default, "LockSessionMediaStop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditMediaStop.Name = "EditMediaStop";
      this.EditMediaStop.UseVisualStyleBackColor = true;
      // 
      // LockSessionForm
      // 
      this.AcceptButton = this.ActionLock;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.ActionShutdown);
      this.Controls.Add(this.EditMediaStop);
      this.Controls.Add(this.ActionHibernate);
      this.Controls.Add(this.ActionStandby);
      this.Controls.Add(this.LabelMessage);
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LockSessionForm";
      this.TopMost = true;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LockSessionForm_FormClosed);
      this.Load += new System.EventHandler(this.LockSessionForm_Load);
      this.PanelButtons.ResumeLayout(false);
      this.PanelButtons.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionLock;
    private System.Windows.Forms.Label LabelCountDown;
    private System.Windows.Forms.Label LabelMessage;
    internal System.Windows.Forms.Timer Timer;
    private System.Windows.Forms.CheckBox EditMediaStop;
    private System.Windows.Forms.LinkLabel ActionHibernate;
    private System.Windows.Forms.LinkLabel ActionStandby;
    private System.Windows.Forms.LinkLabel ActionShutdown;
    private System.Windows.Forms.Button ActionDisable;
  }
}
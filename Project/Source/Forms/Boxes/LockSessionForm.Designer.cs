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
      this.ActionShutdown = new System.Windows.Forms.Button();
      this.ActionHibernate = new System.Windows.Forms.Button();
      this.ActionStandby = new System.Windows.Forms.Button();
      this.LabelCountDown = new System.Windows.Forms.Label();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOk = new System.Windows.Forms.Button();
      this.LabelMessage = new System.Windows.Forms.Label();
      this.Timer = new System.Windows.Forms.Timer(this.components);
      this.EditMediaStop = new System.Windows.Forms.CheckBox();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.ActionShutdown);
      this.PanelButtons.Controls.Add(this.ActionHibernate);
      this.PanelButtons.Controls.Add(this.ActionStandby);
      this.PanelButtons.Controls.Add(this.LabelCountDown);
      this.PanelButtons.Controls.Add(this.ActionCancel);
      this.PanelButtons.Controls.Add(this.ActionOk);
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Name = "PanelButtons";
      // 
      // ActionShutdown
      // 
      resources.ApplyResources(this.ActionShutdown, "ActionShutdown");
      this.ActionShutdown.FlatAppearance.BorderSize = 0;
      this.ActionShutdown.Name = "ActionShutdown";
      this.ActionShutdown.UseVisualStyleBackColor = true;
      this.ActionShutdown.Click += new System.EventHandler(this.ActionShutdown_Click);
      // 
      // ActionHibernate
      // 
      resources.ApplyResources(this.ActionHibernate, "ActionHibernate");
      this.ActionHibernate.FlatAppearance.BorderSize = 0;
      this.ActionHibernate.Name = "ActionHibernate";
      this.ActionHibernate.UseVisualStyleBackColor = true;
      this.ActionHibernate.Click += new System.EventHandler(this.ActionHibernate_Click);
      // 
      // ActionStandby
      // 
      resources.ApplyResources(this.ActionStandby, "ActionStandby");
      this.ActionStandby.FlatAppearance.BorderSize = 0;
      this.ActionStandby.Name = "ActionStandby";
      this.ActionStandby.UseVisualStyleBackColor = true;
      this.ActionStandby.Click += new System.EventHandler(this.ActionStandby_Click);
      // 
      // LabelCountDown
      // 
      resources.ApplyResources(this.LabelCountDown, "LabelCountDown");
      this.LabelCountDown.Name = "LabelCountDown";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Click += new System.EventHandler(this.ActionCancel_Click);
      // 
      // ActionOk
      // 
      resources.ApplyResources(this.ActionOk, "ActionOk");
      this.ActionOk.Name = "ActionOk";
      this.ActionOk.UseVisualStyleBackColor = true;
      this.ActionOk.Click += new System.EventHandler(this.ActionOk_Click);
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
      this.AcceptButton = this.ActionOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.EditMediaStop);
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
    private System.Windows.Forms.Button ActionOk;
    private System.Windows.Forms.Label LabelCountDown;
    private System.Windows.Forms.Label LabelMessage;
    private System.Windows.Forms.Timer Timer;
    private System.Windows.Forms.CheckBox EditMediaStop;
    private System.Windows.Forms.Button ActionHibernate;
    private System.Windows.Forms.Button ActionStandby;
    private System.Windows.Forms.Button ActionShutdown;
  }
}
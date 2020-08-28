namespace Ordisoftware.HebrewCalendar
{
  partial class StatisticsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.TextBox = new System.Windows.Forms.TextBox();
      this.Timer = new System.Windows.Forms.Timer(this.components);
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // TextBox
      // 
      resources.ApplyResources(this.TextBox, "TextBox");
      this.TextBox.Name = "TextBox";
      // 
      // Timer
      // 
      this.Timer.Interval = 1000;
      this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
      // 
      // StatisticsForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.TextBox);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.HebrewCalendar.Properties.Settings.Default, "StatisticsFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.HebrewCalendar.Properties.Settings.Default.StatisticsFormLocation;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "StatisticsForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseStatisticsForm_FormClosing);
      this.Load += new System.EventHandler(this.DatabaseStatisticsForm_Load);
      this.Shown += new System.EventHandler(this.StatisticsForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.TextBox TextBox;
    private System.Windows.Forms.Timer Timer;
  }
}
namespace Ordisoftware.HebrewCalendar
{
  partial class SelectDayForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDayForm));
      this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.ButtonOk = new System.Windows.Forms.Button();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // MonthCalendar
      // 
      resources.ApplyResources(this.MonthCalendar, "MonthCalendar");
      this.MonthCalendar.MaxSelectionCount = 1;
      this.MonthCalendar.Name = "MonthCalendar";
      this.MonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateChanged);
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.ButtonCancel);
      this.PanelButtons.Controls.Add(this.ButtonOk);
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Name = "PanelButtons";
      // 
      // ButtonCancel
      // 
      resources.ApplyResources(this.ButtonCancel, "ButtonCancel");
      this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ButtonCancel.Name = "ButtonCancel";
      this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
      // 
      // ButtonOk
      // 
      resources.ApplyResources(this.ButtonOk, "ButtonOk");
      this.ButtonOk.Name = "ButtonOk";
      this.ButtonOk.UseVisualStyleBackColor = true;
      this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
      // 
      // SelectDayForm
      // 
      this.AcceptButton = this.ButtonOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.MonthCalendar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectDayForm";
      this.ShowInTaskbar = false;
      this.PanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ButtonCancel;
    private System.Windows.Forms.Button ButtonOk;
    internal System.Windows.Forms.MonthCalendar MonthCalendar;
  }
}
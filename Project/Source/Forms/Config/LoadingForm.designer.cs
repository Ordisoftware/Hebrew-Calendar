namespace Ordisoftware.HebrewCalendar
{
  partial class LoadingForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
      this.PanelMain = new System.Windows.Forms.Panel();
      this.ProgressBar = new System.Windows.Forms.ProgressBar();
      this.LabelApplicationName = new System.Windows.Forms.Label();
      this.LabelOperation = new System.Windows.Forms.Label();
      this.PanelMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelMain
      // 
      this.PanelMain.BackColor = System.Drawing.Color.LemonChiffon;
      this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelMain.Controls.Add(this.ProgressBar);
      this.PanelMain.Controls.Add(this.LabelApplicationName);
      this.PanelMain.Controls.Add(this.LabelOperation);
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.Name = "PanelMain";
      // 
      // ProgressBar
      // 
      resources.ApplyResources(this.ProgressBar, "ProgressBar");
      this.ProgressBar.Name = "ProgressBar";
      this.ProgressBar.Step = 1;
      // 
      // LabelApplicationName
      // 
      resources.ApplyResources(this.LabelApplicationName, "LabelApplicationName");
      this.LabelApplicationName.Name = "LabelApplicationName";
      // 
      // LabelOperation
      // 
      resources.ApplyResources(this.LabelOperation, "LabelOperation");
      this.LabelOperation.Name = "LabelOperation";
      // 
      // LoadingForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMain);
      this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "LoadingForm";
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.PanelMain.ResumeLayout(false);
      this.PanelMain.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.Label LabelApplicationName;
    internal System.Windows.Forms.ProgressBar ProgressBar;
    internal System.Windows.Forms.Label LabelOperation;
  }
}
namespace Ordisoftware.Core
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
      this.Panel = new System.Windows.Forms.Panel();
      this.ProgressBar = new System.Windows.Forms.ProgressBar();
      this.LabelTitle = new System.Windows.Forms.Label();
      this.LabelCount = new System.Windows.Forms.Label();
      this.LabelOperation = new System.Windows.Forms.Label();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.Panel.SuspendLayout();
      this.SuspendLayout();
      // 
      // Panel
      // 
      this.Panel.BackColor = System.Drawing.Color.LemonChiffon;
      this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Panel.Controls.Add(this.ActionCancel);
      this.Panel.Controls.Add(this.ProgressBar);
      this.Panel.Controls.Add(this.LabelTitle);
      this.Panel.Controls.Add(this.LabelCount);
      this.Panel.Controls.Add(this.LabelOperation);
      resources.ApplyResources(this.Panel, "Panel");
      this.Panel.Name = "Panel";
      // 
      // ProgressBar
      // 
      resources.ApplyResources(this.ProgressBar, "ProgressBar");
      this.ProgressBar.Name = "ProgressBar";
      this.ProgressBar.Step = 1;
      // 
      // LabelTitle
      // 
      resources.ApplyResources(this.LabelTitle, "LabelTitle");
      this.LabelTitle.Name = "LabelTitle";
      // 
      // LabelCount
      // 
      resources.ApplyResources(this.LabelCount, "LabelCount");
      this.LabelCount.Name = "LabelCount";
      // 
      // LabelOperation
      // 
      resources.ApplyResources(this.LabelOperation, "LabelOperation");
      this.LabelOperation.Name = "LabelOperation";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.FlatAppearance.BorderSize = 0;
      this.ActionCancel.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.UseVisualStyleBackColor = true;
      this.ActionCancel.Click += new System.EventHandler(this.ActionCancel_Click);
      // 
      // LoadingForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.Panel);
      this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "LoadingForm";
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.Load += new System.EventHandler(this.LoadingForm_Load);
      this.Panel.ResumeLayout(false);
      this.Panel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel Panel;
    public System.Windows.Forms.ProgressBar ProgressBar;
    public System.Windows.Forms.Label LabelOperation;
    public System.Windows.Forms.Label LabelTitle;
    public System.Windows.Forms.Label LabelCount;
    private System.Windows.Forms.Button ActionCancel;
  }
}
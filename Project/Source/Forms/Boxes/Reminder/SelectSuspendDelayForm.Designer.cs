namespace Ordisoftware.Hebrew.Calendar
{
  partial class SelectSuspendDelayForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSuspendDelayForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.SelectDelay = new System.Windows.Forms.ListBox();
      this.LabelCustom = new System.Windows.Forms.Label();
      this.EditDelay = new System.Windows.Forms.NumericUpDown();
      this.PanelBottom.SuspendLayout();
      ( (System.ComponentModel.ISupportInitialize)( this.EditDelay ) ).BeginInit();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      // 
      // ActionOK
      // 
      resources.ApplyResources(this.ActionOK, "ActionOK");
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.UseVisualStyleBackColor = true;
      this.ActionOK.Click += new System.EventHandler(this.ActionOK_Click);
      // 
      // SelectDelay
      // 
      resources.ApplyResources(this.SelectDelay, "SelectDelay");
      this.SelectDelay.FormattingEnabled = true;
      this.SelectDelay.Name = "SelectDelay";
      this.SelectDelay.SelectedIndexChanged += new System.EventHandler(this.SelectDelay_SelectedIndexChanged);
      // 
      // LabelCustom
      // 
      resources.ApplyResources(this.LabelCustom, "LabelCustom");
      this.LabelCustom.Name = "LabelCustom";
      // 
      // EditDelay
      // 
      resources.ApplyResources(this.EditDelay, "EditDelay");
      this.EditDelay.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
      this.EditDelay.Name = "EditDelay";
      // 
      // SelectSuspendDelayForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.EditDelay);
      this.Controls.Add(this.LabelCustom);
      this.Controls.Add(this.SelectDelay);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectSuspendDelayForm";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.SelectSuspendDelayForm_Load);
      this.PanelBottom.ResumeLayout(false);
      ( (System.ComponentModel.ISupportInitialize)( this.EditDelay ) ).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.ListBox SelectDelay;
    private System.Windows.Forms.Label LabelCustom;
    private System.Windows.Forms.NumericUpDown EditDelay;
  }
}
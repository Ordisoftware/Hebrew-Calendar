namespace Ordisoftware.HebrewCalendar
{
  partial class SelectYearsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectYearsForm));
      this.EditYearLast = new System.Windows.Forms.NumericUpDown();
      this.LabelYearLast = new System.Windows.Forms.Label();
      this.EditYearFirst = new System.Windows.Forms.NumericUpDown();
      this.LabelYearFirst = new System.Windows.Forms.Label();
      this.ButtonOk = new System.Windows.Forms.Button();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ButtonCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.EditYearLast)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditYearFirst)).BeginInit();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // EditYearLast
      // 
      resources.ApplyResources(this.EditYearLast, "EditYearLast");
      this.EditYearLast.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
      this.EditYearLast.Minimum = new decimal(new int[] {
            1902,
            0,
            0,
            0});
      this.EditYearLast.Name = "EditYearLast";
      this.EditYearLast.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
      // 
      // LabelYearLast
      // 
      resources.ApplyResources(this.LabelYearLast, "LabelYearLast");
      this.LabelYearLast.Name = "LabelYearLast";
      // 
      // EditYearFirst
      // 
      resources.ApplyResources(this.EditYearFirst, "EditYearFirst");
      this.EditYearFirst.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
      this.EditYearFirst.Minimum = new decimal(new int[] {
            1902,
            0,
            0,
            0});
      this.EditYearFirst.Name = "EditYearFirst";
      this.EditYearFirst.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
      // 
      // LabelYearFirst
      // 
      resources.ApplyResources(this.LabelYearFirst, "LabelYearFirst");
      this.LabelYearFirst.Name = "LabelYearFirst";
      // 
      // ButtonOk
      // 
      resources.ApplyResources(this.ButtonOk, "ButtonOk");
      this.ButtonOk.Name = "ButtonOk";
      this.ButtonOk.UseVisualStyleBackColor = true;
      this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
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
      // 
      // SelectYearsForm
      // 
      this.AcceptButton = this.ButtonOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.EditYearLast);
      this.Controls.Add(this.LabelYearLast);
      this.Controls.Add(this.EditYearFirst);
      this.Controls.Add(this.LabelYearFirst);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectYearsForm";
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.SelectYearsRangeForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.EditYearLast)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditYearFirst)).EndInit();
      this.PanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LabelYearLast;
    private System.Windows.Forms.Label LabelYearFirst;
    private System.Windows.Forms.Button ButtonOk;
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ButtonCancel;
    internal System.Windows.Forms.NumericUpDown EditYearLast;
    internal System.Windows.Forms.NumericUpDown EditYearFirst;
  }
}
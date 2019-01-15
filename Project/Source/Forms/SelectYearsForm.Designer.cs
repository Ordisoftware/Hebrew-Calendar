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
      this.editYearLast = new System.Windows.Forms.NumericUpDown();
      this.labelYearLast = new System.Windows.Forms.Label();
      this.editYearFirst = new System.Windows.Forms.NumericUpDown();
      this.labelYearFirst = new System.Windows.Forms.Label();
      this.buttonOk = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.buttonCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.editYearLast)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.editYearFirst)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // editYearLast
      // 
      resources.ApplyResources(this.editYearLast, "editYearLast");
      this.editYearLast.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
      this.editYearLast.Minimum = new decimal(new int[] {
            1902,
            0,
            0,
            0});
      this.editYearLast.Name = "editYearLast";
      this.editYearLast.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
      // 
      // labelYearLast
      // 
      resources.ApplyResources(this.labelYearLast, "labelYearLast");
      this.labelYearLast.Name = "labelYearLast";
      // 
      // editYearFirst
      // 
      resources.ApplyResources(this.editYearFirst, "editYearFirst");
      this.editYearFirst.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
      this.editYearFirst.Minimum = new decimal(new int[] {
            1902,
            0,
            0,
            0});
      this.editYearFirst.Name = "editYearFirst";
      this.editYearFirst.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
      // 
      // labelYearFirst
      // 
      resources.ApplyResources(this.labelYearFirst, "labelYearFirst");
      this.labelYearFirst.Name = "labelYearFirst";
      // 
      // buttonOk
      // 
      resources.ApplyResources(this.buttonOk, "buttonOk");
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // panel1
      // 
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Controls.Add(this.buttonCancel);
      this.panel1.Controls.Add(this.buttonOk);
      this.panel1.Name = "panel1";
      // 
      // buttonCancel
      // 
      resources.ApplyResources(this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      // 
      // SelectYearsForm
      // 
      this.AcceptButton = this.buttonOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.editYearLast);
      this.Controls.Add(this.labelYearLast);
      this.Controls.Add(this.editYearFirst);
      this.Controls.Add(this.labelYearFirst);
      this.Name = "SelectYearsForm";
      this.Load += new System.EventHandler(this.SelectYearsRangeForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.editYearLast)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.editYearFirst)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label labelYearLast;
    private System.Windows.Forms.Label labelYearFirst;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button buttonCancel;
    internal System.Windows.Forms.NumericUpDown editYearLast;
    internal System.Windows.Forms.NumericUpDown editYearFirst;
  }
}
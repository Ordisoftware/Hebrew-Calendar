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
      this.ActionOk = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.EditYearLast)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditYearFirst)).BeginInit();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // EditYearLast
      // 
      this.EditYearLast.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditYearLast, "EditYearLast");
      this.EditYearLast.Name = "EditYearLast";
      this.EditYearLast.ReadOnly = true;
      this.EditYearLast.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.EditYearLast.ValueChanged += new System.EventHandler(this.EditYearLast_ValueChanged);
      this.EditYearLast.Leave += new System.EventHandler(this.EditYearLast_ValueChanged);
      // 
      // LabelYearLast
      // 
      resources.ApplyResources(this.LabelYearLast, "LabelYearLast");
      this.LabelYearLast.Name = "LabelYearLast";
      // 
      // EditYearFirst
      // 
      this.EditYearFirst.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditYearFirst, "EditYearFirst");
      this.EditYearFirst.Name = "EditYearFirst";
      this.EditYearFirst.ReadOnly = true;
      this.EditYearFirst.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.EditYearFirst.ValueChanged += new System.EventHandler(this.EditYearFirst_ValueChanged);
      this.EditYearFirst.Enter += new System.EventHandler(this.EditYearFirst_ValueChanged);
      // 
      // LabelYearFirst
      // 
      resources.ApplyResources(this.LabelYearFirst, "LabelYearFirst");
      this.LabelYearFirst.Name = "LabelYearFirst";
      // 
      // ActionOk
      // 
      resources.ApplyResources(this.ActionOk, "ActionOk");
      this.ActionOk.Name = "ActionOk";
      this.ActionOk.UseVisualStyleBackColor = true;
      this.ActionOk.Click += new System.EventHandler(this.ActionOk_Click);
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOk);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      // 
      // SelectYearsForm
      // 
      this.AcceptButton = this.ActionOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.EditYearLast);
      this.Controls.Add(this.LabelYearLast);
      this.Controls.Add(this.EditYearFirst);
      this.Controls.Add(this.LabelYearFirst);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectYearsForm";
      this.ShowInTaskbar = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectYearsForm_FormClosing);
      this.Load += new System.EventHandler(this.SelectYearsRangeForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.EditYearLast)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EditYearFirst)).EndInit();
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LabelYearLast;
    private System.Windows.Forms.Label LabelYearFirst;
    private System.Windows.Forms.Button ActionOk;
    private System.Windows.Forms.Panel PanelBottom;
    internal System.Windows.Forms.NumericUpDown EditYearLast;
    internal System.Windows.Forms.NumericUpDown EditYearFirst;
    internal System.Windows.Forms.Button ActionCancel;
  }
}
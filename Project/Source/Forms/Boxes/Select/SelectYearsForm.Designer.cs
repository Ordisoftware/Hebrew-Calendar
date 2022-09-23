namespace Ordisoftware.Hebrew.Calendar
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectYearsForm));
      this.EditYearLast = new System.Windows.Forms.NumericUpDown();
      this.LabelYearLast = new System.Windows.Forms.Label();
      this.EditYearFirst = new System.Windows.Forms.NumericUpDown();
      this.LabelYearFirst = new System.Windows.Forms.Label();
      this.ActionOK = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionPrefefinedInterval = new System.Windows.Forms.Button();
      this.MenuPredefinedYears = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionDefaultInterval = new System.Windows.Forms.Button();
      ( (System.ComponentModel.ISupportInitialize)( this.EditYearLast ) ).BeginInit();
      ( (System.ComponentModel.ISupportInitialize)( this.EditYearFirst ) ).BeginInit();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // EditYearLast
      // 
      resources.ApplyResources(this.EditYearLast, "EditYearLast");
      this.EditYearLast.BackColor = System.Drawing.SystemColors.Window;
      this.EditYearLast.Name = "EditYearLast";
      this.EditYearLast.ReadOnly = true;
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
      resources.ApplyResources(this.EditYearFirst, "EditYearFirst");
      this.EditYearFirst.BackColor = System.Drawing.SystemColors.Window;
      this.EditYearFirst.Name = "EditYearFirst";
      this.EditYearFirst.ReadOnly = true;
      this.EditYearFirst.ValueChanged += new System.EventHandler(this.EditYearFirst_ValueChanged);
      this.EditYearFirst.Enter += new System.EventHandler(this.EditYearFirst_ValueChanged);
      // 
      // LabelYearFirst
      // 
      resources.ApplyResources(this.LabelYearFirst, "LabelYearFirst");
      this.LabelYearFirst.Name = "LabelYearFirst";
      // 
      // ActionOK
      // 
      resources.ApplyResources(this.ActionOK, "ActionOK");
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.UseVisualStyleBackColor = true;
      this.ActionOK.Click += new System.EventHandler(this.ActionOK_Click);
      // 
      // PanelBottom
      // 
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      // 
      // ActionPrefefinedInterval
      // 
      resources.ApplyResources(this.ActionPrefefinedInterval, "ActionPrefefinedInterval");
      this.ActionPrefefinedInterval.AllowDrop = true;
      this.ActionPrefefinedInterval.ContextMenuStrip = this.MenuPredefinedYears;
      this.ActionPrefefinedInterval.FlatAppearance.BorderSize = 0;
      this.ActionPrefefinedInterval.Name = "ActionPrefefinedInterval";
      this.ActionPrefefinedInterval.UseVisualStyleBackColor = true;
      this.ActionPrefefinedInterval.Click += new System.EventHandler(this.ActionPrefefinedInterval_Click);
      // 
      // MenuPredefinedYears
      // 
      resources.ApplyResources(this.MenuPredefinedYears, "MenuPredefinedYears");
      this.MenuPredefinedYears.Name = "MenuSelectMoonDayTextFormat";
      this.MenuPredefinedYears.ShowImageMargin = false;
      // 
      // ActionDefaultInterval
      // 
      resources.ApplyResources(this.ActionDefaultInterval, "ActionDefaultInterval");
      this.ActionDefaultInterval.AllowDrop = true;
      this.ActionDefaultInterval.FlatAppearance.BorderSize = 0;
      this.ActionDefaultInterval.Name = "ActionDefaultInterval";
      this.ActionDefaultInterval.UseVisualStyleBackColor = true;
      this.ActionDefaultInterval.Click += new System.EventHandler(this.ActionDefaultInterval_Click);
      // 
      // SelectYearsForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.ActionDefaultInterval);
      this.Controls.Add(this.ActionPrefefinedInterval);
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
      ( (System.ComponentModel.ISupportInitialize)( this.EditYearLast ) ).EndInit();
      ( (System.ComponentModel.ISupportInitialize)( this.EditYearFirst ) ).EndInit();
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label LabelYearLast;
    private System.Windows.Forms.Label LabelYearFirst;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.Panel PanelBottom;
    public System.Windows.Forms.NumericUpDown EditYearLast;
    public System.Windows.Forms.NumericUpDown EditYearFirst;
    public System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionPrefefinedInterval;
    private System.Windows.Forms.ContextMenuStrip MenuPredefinedYears;
    private System.Windows.Forms.Button ActionDefaultInterval;
  }
}
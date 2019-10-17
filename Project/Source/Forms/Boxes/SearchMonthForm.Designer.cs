namespace Ordisoftware.HebrewCalendar
{
  partial class SearchMonthForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchMonthForm));
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.ButtonOk = new System.Windows.Forms.Button();
      this.EditYear = new System.Windows.Forms.NumericUpDown();
      this.LabelYear = new System.Windows.Forms.Label();
      this.SelectMonth = new System.Windows.Forms.ListBox();
      this.PanelButtons.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditYear)).BeginInit();
      this.SuspendLayout();
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
      // EditYear
      // 
      this.EditYear.BackColor = System.Drawing.SystemColors.Window;
      resources.ApplyResources(this.EditYear, "EditYear");
      this.EditYear.Name = "EditYear";
      this.EditYear.ReadOnly = true;
      this.EditYear.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.EditYear.ValueChanged += new System.EventHandler(this.EditYear_ValueChanged);
      // 
      // LabelYear
      // 
      resources.ApplyResources(this.LabelYear, "LabelYear");
      this.LabelYear.Name = "LabelYear";
      // 
      // SelectMonth
      // 
      resources.ApplyResources(this.SelectMonth, "SelectMonth");
      this.SelectMonth.FormattingEnabled = true;
      this.SelectMonth.Name = "SelectMonth";
      this.SelectMonth.SelectedIndexChanged += new System.EventHandler(this.SelectMonth_SelectedIndexChanged);
      this.SelectMonth.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.SelectMonth_Format);
      this.SelectMonth.DoubleClick += new System.EventHandler(this.SelectEvents_DoubleClick);
      // 
      // SearchMonthForm
      // 
      this.AcceptButton = this.ButtonOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.Controls.Add(this.SelectMonth);
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.EditYear);
      this.Controls.Add(this.LabelYear);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchMonthForm";
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.SearchEventForm_Load);
      this.PanelButtons.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.EditYear)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ButtonCancel;
    private System.Windows.Forms.Button ButtonOk;
    internal System.Windows.Forms.NumericUpDown EditYear;
    private System.Windows.Forms.Label LabelYear;
    internal System.Windows.Forms.ListBox SelectMonth;
  }
}
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
      this.ListItems = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.PanelButtons.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditYear)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelButtons
      // 
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Controls.Add(this.ButtonCancel);
      this.PanelButtons.Controls.Add(this.ButtonOk);
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
      resources.ApplyResources(this.EditYear, "EditYear");
      this.EditYear.BackColor = System.Drawing.SystemColors.Window;
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
      // ListItems
      // 
      resources.ApplyResources(this.ListItems, "ListItems");
      this.ListItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.ListItems.FullRowSelect = true;
      this.ListItems.HideSelection = false;
      this.ListItems.MultiSelect = false;
      this.ListItems.Name = "ListItems";
      this.ListItems.UseCompatibleStateImageBehavior = false;
      this.ListItems.View = System.Windows.Forms.View.Details;
      this.ListItems.SelectedIndexChanged += new System.EventHandler(this.SelectMonth_SelectedIndexChanged);
      this.ListItems.DoubleClick += new System.EventHandler(this.SelectEvents_DoubleClick);
      // 
      // columnHeader1
      // 
      resources.ApplyResources(this.columnHeader1, "columnHeader1");
      // 
      // columnHeader2
      // 
      resources.ApplyResources(this.columnHeader2, "columnHeader2");
      // 
      // SearchMonthForm
      // 
      this.AcceptButton = this.ButtonOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.Controls.Add(this.ListItems);
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
    internal System.Windows.Forms.ListView ListItems;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
  }
}
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
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOk = new System.Windows.Forms.Button();
      this.EditYear = new System.Windows.Forms.NumericUpDown();
      this.LabelYear = new System.Windows.Forms.Label();
      this.ListItems = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditYear)).BeginInit();
      this.SuspendLayout();
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
      this.ActionCancel.Click += new System.EventHandler(this.ActionCancel_Click);
      // 
      // ActionOk
      // 
      resources.ApplyResources(this.ActionOk, "ActionOk");
      this.ActionOk.Name = "ActionOk";
      this.ActionOk.UseVisualStyleBackColor = true;
      this.ActionOk.Click += new System.EventHandler(this.ActionOk_Click);
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
      this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
      this.ListItems.DoubleClick += new System.EventHandler(this.ListItems_DoubleClick);
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
      this.AcceptButton = this.ActionOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.ListItems);
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.EditYear);
      this.Controls.Add(this.LabelYear);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.HebrewCalendar.Properties.Settings.Default, "SearchLunarMonthFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.HebrewCalendar.Properties.Settings.Default.SearchLunarMonthFormLocation;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchMonthForm";
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.SearchEventForm_Load);
      this.PanelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.EditYear)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOk;
    internal System.Windows.Forms.NumericUpDown EditYear;
    private System.Windows.Forms.Label LabelYear;
    internal System.Windows.Forms.ListView ListItems;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
  }
}
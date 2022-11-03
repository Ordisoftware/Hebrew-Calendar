namespace Ordisoftware.Hebrew.Calendar
{
  partial class SearchGregorianMonthForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchGregorianMonthForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.LabelYear = new System.Windows.Forms.Label();
      this.ListItems = new System.Windows.Forms.ListView();
      this.ColumnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ColumnMonth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SelectYear = new Ordisoftware.Core.SelectYearsControl();
      this.SelectDay = new System.Windows.Forms.ComboBox();
      this.LabelDay = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
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
            this.ColumnNumber,
            this.ColumnMonth});
      this.ListItems.FullRowSelect = true;
      this.ListItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.ListItems.HideSelection = false;
      this.ListItems.MultiSelect = false;
      this.ListItems.Name = "ListItems";
      this.ListItems.UseCompatibleStateImageBehavior = false;
      this.ListItems.View = System.Windows.Forms.View.Details;
      this.ListItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
      this.ListItems.DoubleClick += new System.EventHandler(this.ListItems_DoubleClick);
      // 
      // ColumnNumber
      // 
      resources.ApplyResources(this.ColumnNumber, "ColumnNumber");
      // 
      // ColumnMonth
      // 
      resources.ApplyResources(this.ColumnMonth, "ColumnMonth");
      // 
      // SelectYear
      // 
      resources.ApplyResources(this.SelectYear, "SelectYear");
      this.SelectYear.Name = "SelectYear";
      this.SelectYear.SelectedIndex = -1;
      this.SelectYear.SelectedItem = null;
      this.SelectYear.Value = -1;
      this.SelectYear.SelectedIndexChanged += new System.EventHandler(this.SelectYear_SelectedIndexChanged);
      // 
      // SelectDay
      // 
      this.SelectDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectDay.FormattingEnabled = true;
      resources.ApplyResources(this.SelectDay, "SelectDay");
      this.SelectDay.Name = "SelectDay";
      this.SelectDay.SelectedIndexChanged += new System.EventHandler(this.SelectDay_SelectedIndexChanged);
      // 
      // LabelDay
      // 
      resources.ApplyResources(this.LabelDay, "LabelDay");
      this.LabelDay.Name = "LabelDay";
      // 
      // SearchGregorianMonthForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.SelectDay);
      this.Controls.Add(this.LabelDay);
      this.Controls.Add(this.SelectYear);
      this.Controls.Add(this.ListItems);
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.LabelYear);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "SearchGregorianMonthFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.SearchGregorianMonthFormLocation;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchGregorianMonthForm";
      this.ShowInTaskbar = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchMonthForm_FormClosing);
      this.Load += new System.EventHandler(this.SearchGregorianMonthForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.Label LabelYear;
    public System.Windows.Forms.ListView ListItems;
    private System.Windows.Forms.ColumnHeader ColumnMonth;
    private System.Windows.Forms.ColumnHeader ColumnNumber;
    private Ordisoftware.Core.SelectYearsControl SelectYear;
    private ComboBox SelectDay;
    private Label LabelDay;
  }
}
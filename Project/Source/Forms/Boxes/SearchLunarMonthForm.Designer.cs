namespace Ordisoftware.Hebrew.Calendar
{
  partial class SearchLunarMonthForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchLunarMonthForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.LabelYear = new System.Windows.Forms.Label();
      this.ListItems = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.EditYear = new System.Windows.Forms.ComboBox();
      this.ActionNext = new System.Windows.Forms.Button();
      this.ActionPrevious = new System.Windows.Forms.Button();
      this.ActionFirst = new System.Windows.Forms.Button();
      this.ActionLast = new System.Windows.Forms.Button();
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
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
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
      // columnHeader3
      // 
      resources.ApplyResources(this.columnHeader3, "columnHeader3");
      // 
      // columnHeader1
      // 
      resources.ApplyResources(this.columnHeader1, "columnHeader1");
      // 
      // columnHeader2
      // 
      resources.ApplyResources(this.columnHeader2, "columnHeader2");
      // 
      // EditYear
      // 
      this.EditYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.EditYear.FormattingEnabled = true;
      resources.ApplyResources(this.EditYear, "EditYear");
      this.EditYear.Name = "EditYear";
      this.EditYear.SelectedIndexChanged += new System.EventHandler(this.EditYear_SelectedIndexChanged);
      // 
      // ActionNext
      // 
      resources.ApplyResources(this.ActionNext, "ActionNext");
      this.ActionNext.Name = "ActionNext";
      this.ActionNext.Click += new System.EventHandler(this.ActionNext_Click);
      // 
      // ActionPrevious
      // 
      resources.ApplyResources(this.ActionPrevious, "ActionPrevious");
      this.ActionPrevious.Name = "ActionPrevious";
      this.ActionPrevious.Click += new System.EventHandler(this.ActionPrevious_Click);
      // 
      // ActionFirst
      // 
      resources.ApplyResources(this.ActionFirst, "ActionFirst");
      this.ActionFirst.Name = "ActionFirst";
      this.ActionFirst.Click += new System.EventHandler(this.ActionFirst_Click);
      // 
      // ActionLast
      // 
      resources.ApplyResources(this.ActionLast, "ActionLast");
      this.ActionLast.Name = "ActionLast";
      this.ActionLast.Click += new System.EventHandler(this.ActionLast_Click);
      // 
      // SearchLunarMonthForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.ActionLast);
      this.Controls.Add(this.ActionNext);
      this.Controls.Add(this.ActionFirst);
      this.Controls.Add(this.ActionPrevious);
      this.Controls.Add(this.EditYear);
      this.Controls.Add(this.ListItems);
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.LabelYear);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "SearchLunarMonthFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.SearchLunarMonthFormLocation;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchLunarMonthForm";
      this.ShowInTaskbar = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchMonthForm_FormClosing);
      this.Load += new System.EventHandler(this.SearchEventForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.Label LabelYear;
    internal System.Windows.Forms.ListView ListItems;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ComboBox EditYear;
    private System.Windows.Forms.Button ActionNext;
    private System.Windows.Forms.Button ActionPrevious;
    private System.Windows.Forms.Button ActionFirst;
    private System.Windows.Forms.Button ActionLast;
  }
}
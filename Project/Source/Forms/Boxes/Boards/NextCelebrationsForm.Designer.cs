namespace Ordisoftware.Hebrew.Calendar
{
  partial class NextCelebrationsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NextCelebrationsForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ListView
      // 
      resources.ApplyResources(this.ListView, "ListView");
      this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.ListView.FullRowSelect = true;
      this.ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.ListView.HideSelection = false;
      this.ListView.MultiSelect = false;
      this.ListView.Name = "ListView";
      this.ListView.UseCompatibleStateImageBehavior = false;
      this.ListView.View = System.Windows.Forms.View.Details;
      this.ListView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
      this.ListView.DoubleClick += new System.EventHandler(this.ListView_DoubleClick);
      // 
      // columnHeader1
      // 
      resources.ApplyResources(this.columnHeader1, "columnHeader1");
      // 
      // columnHeader2
      // 
      resources.ApplyResources(this.columnHeader2, "columnHeader2");
      // 
      // NextCelebrationsForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.ListView);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "NextCelebrationsFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.NextCelebrationsFormLocation;
      this.MaximizeBox = false;
      this.Name = "NextCelebrationsForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CelebrationsForm_FormClosing);
      this.Load += new System.EventHandler(this.CelebrationsForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.ListView ListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
  }
}
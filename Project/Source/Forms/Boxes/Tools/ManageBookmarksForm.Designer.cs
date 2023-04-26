namespace Ordisoftware.Hebrew.Calendar
{
  partial class ManageBookmarksForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBookmarksForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionExport = new System.Windows.Forms.Button();
      this.ActionImport = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.ActionClear = new System.Windows.Forms.Button();
      this.ListBox = new System.Windows.Forms.ListBox();
      this.ActionDelete = new System.Windows.Forms.Button();
      this.ActionUp = new System.Windows.Forms.Button();
      this.ActionDown = new System.Windows.Forms.Button();
      this.ActionSort = new System.Windows.Forms.Button();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.SaveBookmarksDialog = new System.Windows.Forms.SaveFileDialog();
      this.OpenBookmarksDialog = new System.Windows.Forms.OpenFileDialog();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionExport);
      this.PanelBottom.Controls.Add(this.ActionImport);
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionExport
      // 
      this.ActionExport.AllowDrop = true;
      resources.ApplyResources(this.ActionExport, "ActionExport");
      this.ActionExport.FlatAppearance.BorderSize = 0;
      this.ActionExport.Name = "ActionExport";
      this.ActionExport.UseVisualStyleBackColor = true;
      this.ActionExport.Click += new System.EventHandler(this.ActionExport_Click);
      // 
      // ActionImport
      // 
      this.ActionImport.AllowDrop = true;
      resources.ApplyResources(this.ActionImport, "ActionImport");
      this.ActionImport.FlatAppearance.BorderSize = 0;
      this.ActionImport.Name = "ActionImport";
      this.ActionImport.UseVisualStyleBackColor = true;
      this.ActionImport.Click += new System.EventHandler(this.ActionImport_Click);
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
      // ActionClear
      // 
      this.ActionClear.AllowDrop = true;
      resources.ApplyResources(this.ActionClear, "ActionClear");
      this.ActionClear.FlatAppearance.BorderSize = 0;
      this.ActionClear.Name = "ActionClear";
      this.ActionClear.UseVisualStyleBackColor = true;
      this.ActionClear.Click += new System.EventHandler(this.ActionClear_Click);
      // 
      // ListBox
      // 
      resources.ApplyResources(this.ListBox, "ListBox");
      this.ListBox.FormattingEnabled = true;
      this.ListBox.Name = "ListBox";
      this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
      this.ListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseDoubleClick);
      // 
      // ActionDelete
      // 
      resources.ApplyResources(this.ActionDelete, "ActionDelete");
      this.ActionDelete.FlatAppearance.BorderSize = 0;
      this.ActionDelete.Name = "ActionDelete";
      this.ActionDelete.UseVisualStyleBackColor = true;
      this.ActionDelete.Click += new System.EventHandler(this.ActionDelete_Click);
      // 
      // ActionUp
      // 
      resources.ApplyResources(this.ActionUp, "ActionUp");
      this.ActionUp.FlatAppearance.BorderSize = 0;
      this.ActionUp.Name = "ActionUp";
      this.ActionUp.UseVisualStyleBackColor = true;
      this.ActionUp.Click += new System.EventHandler(this.ActionUp_Click);
      // 
      // ActionDown
      // 
      resources.ApplyResources(this.ActionDown, "ActionDown");
      this.ActionDown.FlatAppearance.BorderSize = 0;
      this.ActionDown.Name = "ActionDown";
      this.ActionDown.UseVisualStyleBackColor = true;
      this.ActionDown.Click += new System.EventHandler(this.ActionDown_Click);
      // 
      // ActionSort
      // 
      resources.ApplyResources(this.ActionSort, "ActionSort");
      this.ActionSort.FlatAppearance.BorderSize = 0;
      this.ActionSort.Name = "ActionSort";
      this.ActionSort.UseVisualStyleBackColor = true;
      this.ActionSort.Click += new System.EventHandler(this.ActionSort_Click);
      // 
      // PanelSeparator
      // 
      resources.ApplyResources(this.PanelSeparator, "PanelSeparator");
      this.PanelSeparator.Name = "PanelSeparator";
      // 
      // ManageBookmarksForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.ManageDateBookmarksFormClientSize;
      this.Controls.Add(this.ActionClear);
      this.Controls.Add(this.ListBox);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.ActionDown);
      this.Controls.Add(this.ActionSort);
      this.Controls.Add(this.ActionUp);
      this.Controls.Add(this.ActionDelete);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "ManageDateBookmarksFormClientSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ManageBookmarksForm";
      this.ShowInTaskbar = false;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageDateBookmarks_FormClosed);
      this.Load += new System.EventHandler(this.ManageDateBookmarks_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.ListBox ListBox;
    private System.Windows.Forms.Button ActionSort;
    private System.Windows.Forms.Button ActionDelete;
    private System.Windows.Forms.Button ActionUp;
    private System.Windows.Forms.Button ActionDown;
    private System.Windows.Forms.Button ActionClear;
    private System.Windows.Forms.Panel PanelSeparator;
    private System.Windows.Forms.Button ActionExport;
    private System.Windows.Forms.Button ActionImport;
    private System.Windows.Forms.SaveFileDialog SaveBookmarksDialog;
    private System.Windows.Forms.OpenFileDialog OpenBookmarksDialog;
  }
}
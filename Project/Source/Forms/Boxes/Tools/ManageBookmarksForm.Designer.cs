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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBookmarksForm));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionResetColors = new System.Windows.Forms.LinkLabel();
      this.ActionExport = new System.Windows.Forms.Button();
      this.ActionImport = new System.Windows.Forms.Button();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionClear = new System.Windows.Forms.Button();
      this.SaveBookmarksDialog = new System.Windows.Forms.SaveFileDialog();
      this.OpenBookmarksDialog = new System.Windows.Forms.OpenFileDialog();
      this.panel1 = new System.Windows.Forms.Panel();
      this.ActionAdd = new System.Windows.Forms.Button();
      this.ActionDelete = new System.Windows.Forms.Button();
      this.ActionUndo = new System.Windows.Forms.Button();
      this.ActionSave = new System.Windows.Forms.Button();
      this.EditBookmarks = new System.Windows.Forms.DataGridView();
      this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnColor = new System.Windows.Forms.DataGridViewButtonColumn();
      this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.ColorDialog = new System.Windows.Forms.ColorDialog();
      this.PanelBottom.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditBookmarks)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionResetColors);
      this.PanelBottom.Controls.Add(this.ActionExport);
      this.PanelBottom.Controls.Add(this.ActionImport);
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionResetColors
      // 
      this.ActionResetColors.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionResetColors, "ActionResetColors");
      this.ActionResetColors.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionResetColors.LinkColor = System.Drawing.Color.Navy;
      this.ActionResetColors.Name = "ActionResetColors";
      this.ActionResetColors.TabStop = true;
      this.ActionResetColors.VisitedLinkColor = System.Drawing.Color.Navy;
      this.ActionResetColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionResetColors_LinkClicked);
      // 
      // ActionExport
      // 
      this.ActionExport.AllowDrop = true;
      this.ActionExport.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionExport, "ActionExport");
      this.ActionExport.Name = "ActionExport";
      this.ActionExport.UseVisualStyleBackColor = true;
      this.ActionExport.Click += new System.EventHandler(this.ActionExport_Click);
      // 
      // ActionImport
      // 
      this.ActionImport.AllowDrop = true;
      this.ActionImport.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionImport, "ActionImport");
      this.ActionImport.Name = "ActionImport";
      this.ActionImport.UseVisualStyleBackColor = true;
      this.ActionImport.Click += new System.EventHandler(this.ActionImport_Click);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.UseVisualStyleBackColor = true;
      // 
      // ActionClear
      // 
      resources.ApplyResources(this.ActionClear, "ActionClear");
      this.ActionClear.FlatAppearance.BorderSize = 0;
      this.ActionClear.Name = "ActionClear";
      this.ActionClear.UseVisualStyleBackColor = true;
      this.ActionClear.Click += new System.EventHandler(this.ActionClear_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.ActionAdd);
      this.panel1.Controls.Add(this.ActionDelete);
      this.panel1.Controls.Add(this.ActionUndo);
      this.panel1.Controls.Add(this.ActionSave);
      this.panel1.Controls.Add(this.EditBookmarks);
      this.panel1.Controls.Add(this.ActionClear);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // ActionAdd
      // 
      resources.ApplyResources(this.ActionAdd, "ActionAdd");
      this.ActionAdd.FlatAppearance.BorderSize = 0;
      this.ActionAdd.Name = "ActionAdd";
      this.ActionAdd.UseVisualStyleBackColor = true;
      this.ActionAdd.Click += new System.EventHandler(this.ActionAdd_Click);
      // 
      // ActionDelete
      // 
      resources.ApplyResources(this.ActionDelete, "ActionDelete");
      this.ActionDelete.FlatAppearance.BorderSize = 0;
      this.ActionDelete.Name = "ActionDelete";
      this.ActionDelete.UseVisualStyleBackColor = true;
      this.ActionDelete.Click += new System.EventHandler(this.ActionDelete_Click);
      // 
      // ActionUndo
      // 
      resources.ApplyResources(this.ActionUndo, "ActionUndo");
      this.ActionUndo.FlatAppearance.BorderSize = 0;
      this.ActionUndo.Name = "ActionUndo";
      this.ActionUndo.UseVisualStyleBackColor = true;
      this.ActionUndo.Click += new System.EventHandler(this.ActionUndo_Click);
      // 
      // ActionSave
      // 
      resources.ApplyResources(this.ActionSave, "ActionSave");
      this.ActionSave.FlatAppearance.BorderSize = 0;
      this.ActionSave.Name = "ActionSave";
      this.ActionSave.UseVisualStyleBackColor = true;
      this.ActionSave.Click += new System.EventHandler(this.ActionSave_Click);
      // 
      // EditBookmarks
      // 
      this.EditBookmarks.AllowUserToAddRows = false;
      this.EditBookmarks.AllowUserToDeleteRows = false;
      this.EditBookmarks.AllowUserToResizeColumns = false;
      this.EditBookmarks.AllowUserToResizeRows = false;
      resources.ApplyResources(this.EditBookmarks, "EditBookmarks");
      this.EditBookmarks.AutoGenerateColumns = false;
      this.EditBookmarks.BackgroundColor = System.Drawing.Color.White;
      this.EditBookmarks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.EditBookmarks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.EditBookmarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.EditBookmarks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnMemo,
            this.ColumnColor});
      this.EditBookmarks.DataSource = this.BindingSource;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle4.NullValue = "string.Empty";
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.EditBookmarks.DefaultCellStyle = dataGridViewCellStyle4;
      this.EditBookmarks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.EditBookmarks.EnableHeadersVisualStyles = false;
      this.EditBookmarks.MultiSelect = false;
      this.EditBookmarks.Name = "EditBookmarks";
      this.EditBookmarks.RowHeadersVisible = false;
      this.EditBookmarks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.EditBookmarks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.EditBookmarks.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.EditBookmarks_CellBeginEdit);
      this.EditBookmarks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditBookmarks_CellContentClick);
      this.EditBookmarks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditBookmarks_CellDoubleClick);
      this.EditBookmarks.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditBookmarks_CellEndEdit);
      this.EditBookmarks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.EditBookmarks_CellFormatting);
      this.EditBookmarks.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EditBookmarks_CellValidating);
      this.EditBookmarks.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditBookmarks_CellValueChanged);
      this.EditBookmarks.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.EditBookmarks_DataError);
      this.EditBookmarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditBookmarks_KeyDown);
      // 
      // ColumnDate
      // 
      this.ColumnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
      this.ColumnDate.DataPropertyName = "Date";
      dataGridViewCellStyle2.Format = "d";
      dataGridViewCellStyle2.NullValue = null;
      this.ColumnDate.DefaultCellStyle = dataGridViewCellStyle2;
      resources.ApplyResources(this.ColumnDate, "ColumnDate");
      this.ColumnDate.Name = "ColumnDate";
      this.ColumnDate.ReadOnly = true;
      this.ColumnDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      // 
      // ColumnMemo
      // 
      this.ColumnMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.ColumnMemo.DataPropertyName = "Memo";
      resources.ApplyResources(this.ColumnMemo, "ColumnMemo");
      this.ColumnMemo.Name = "ColumnMemo";
      this.ColumnMemo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.ColumnMemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // ColumnColor
      // 
      this.ColumnColor.DataPropertyName = "Color";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
      this.ColumnColor.DefaultCellStyle = dataGridViewCellStyle3;
      this.ColumnColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      resources.ApplyResources(this.ColumnColor, "ColumnColor");
      this.ColumnColor.Name = "ColumnColor";
      this.ColumnColor.ReadOnly = true;
      this.ColumnColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.ColumnColor.Text = "";
      this.ColumnColor.UseColumnTextForButtonValue = true;
      // 
      // BindingSource
      // 
      this.BindingSource.DataSource = typeof(Ordisoftware.Hebrew.Calendar.DateBookmarkRow);
      this.BindingSource.Sort = "";
      // 
      // ManageBookmarksForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.ManageDateBookmarksFormClientSize;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "ManageDateBookmarksFormClientSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ManageBookmarksForm";
      this.ShowInTaskbar = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageBookmarksForm_FormClosing);
      this.Load += new System.EventHandler(this.ManageDateBookmarks_Load);
      this.Shown += new System.EventHandler(this.ManageBookmarksForm_Shown);
      this.SizeChanged += new System.EventHandler(this.ManageBookmarksForm_SizeChanged);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.EditBookmarks)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Button ActionClear;
    private System.Windows.Forms.SaveFileDialog SaveBookmarksDialog;
    private System.Windows.Forms.OpenFileDialog OpenBookmarksDialog;
    private Panel panel1;
    private BindingSource BindingSource;
    private DataGridView EditBookmarks;
    private Button ActionUndo;
    private Button ActionSave;
    private Button ActionDelete;
    private Button ActionAdd;
    private Button ActionExport;
    private Button ActionImport;
    private ColorDialog ColorDialog;
    private LinkLabel ActionResetColors;
    private DataGridViewTextBoxColumn ColumnDate;
    private DataGridViewTextBoxColumn ColumnMemo;
    private DataGridViewButtonColumn ColumnColor;
  }
}
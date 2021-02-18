namespace Ordisoftware.Hebrew.Calendar
{
  partial class ParashotForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParashotForm));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.DataGridView = new System.Windows.Forms.DataGridView();
      this.Unicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IsLinkedToNext = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionSearchOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewLetters = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyHebrewChars = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyUnicodeChars = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyLineHebrew = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyLineUnicode = new System.Windows.Forms.ToolStripMenuItem();
      this.bookDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.unicodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.verseBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.verseEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.isLinkedToNextDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.ActionOpenVerseOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenHebrewWords = new System.Windows.Forms.ToolStripMenuItem();
      this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel1.SuspendLayout();
      this.PanelMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
      this.ContextMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      // 
      // PanelMain
      // 
      this.PanelMain.Controls.Add(this.DataGridView);
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.Name = "PanelMain";
      // 
      // DataGridView
      // 
      this.DataGridView.AllowUserToAddRows = false;
      this.DataGridView.AllowUserToDeleteRows = false;
      this.DataGridView.AllowUserToResizeRows = false;
      this.DataGridView.AutoGenerateColumns = false;
      resources.ApplyResources(this.DataGridView, "DataGridView");
      this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Unicode,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.IsLinkedToNext});
      this.DataGridView.ContextMenuStrip = this.ContextMenu;
      this.DataGridView.DataSource = this.BindingSource;
      this.DataGridView.MultiSelect = false;
      this.DataGridView.Name = "DataGridView";
      this.DataGridView.RowHeadersVisible = false;
      this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DataGridView.ShowCellToolTips = false;
      this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
      this.DataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDown);
      // 
      // Unicode
      // 
      this.Unicode.DataPropertyName = "Unicode";
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Hebrew", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Unicode.DefaultCellStyle = dataGridViewCellStyle1;
      resources.ApplyResources(this.Unicode, "Unicode");
      this.Unicode.Name = "Unicode";
      this.Unicode.ReadOnly = true;
      // 
      // IsLinkedToNext
      // 
      this.IsLinkedToNext.DataPropertyName = "IsLinkedToNext";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.IsLinkedToNext.DefaultCellStyle = dataGridViewCellStyle2;
      resources.ApplyResources(this.IsLinkedToNext, "IsLinkedToNext");
      this.IsLinkedToNext.Name = "IsLinkedToNext";
      this.IsLinkedToNext.ReadOnly = true;
      // 
      // ContextMenu
      // 
      this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionSearchOnline,
            this.ActionOpenVerseOnline,
            this.toolStripSeparator1,
            this.ActionOpenHebrewWords,
            this.ActionOpenHebrewLetters,
            this.MenuSeparator2,
            this.ActionCopyHebrewChars,
            this.ActionCopyUnicodeChars,
            this.toolStripSeparator2,
            this.ActionCopyLineHebrew,
            this.ActionCopyLineUnicode});
      this.ContextMenu.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenu, "ContextMenu");
      // 
      // ActionSearchOnline
      // 
      resources.ApplyResources(this.ActionSearchOnline, "ActionSearchOnline");
      this.ActionSearchOnline.Name = "ActionSearchOnline";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // ActionOpenHebrewLetters
      // 
      resources.ApplyResources(this.ActionOpenHebrewLetters, "ActionOpenHebrewLetters");
      this.ActionOpenHebrewLetters.Name = "ActionOpenHebrewLetters";
      // 
      // MenuSeparator2
      // 
      this.MenuSeparator2.Name = "MenuSeparator2";
      resources.ApplyResources(this.MenuSeparator2, "MenuSeparator2");
      // 
      // ActionCopyHebrewChars
      // 
      resources.ApplyResources(this.ActionCopyHebrewChars, "ActionCopyHebrewChars");
      this.ActionCopyHebrewChars.Name = "ActionCopyHebrewChars";
      // 
      // ActionCopyUnicodeChars
      // 
      resources.ApplyResources(this.ActionCopyUnicodeChars, "ActionCopyUnicodeChars");
      this.ActionCopyUnicodeChars.Name = "ActionCopyUnicodeChars";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // ActionCopyLineHebrew
      // 
      resources.ApplyResources(this.ActionCopyLineHebrew, "ActionCopyLineHebrew");
      this.ActionCopyLineHebrew.Name = "ActionCopyLineHebrew";
      // 
      // ActionCopyLineUnicode
      // 
      resources.ApplyResources(this.ActionCopyLineUnicode, "ActionCopyLineUnicode");
      this.ActionCopyLineUnicode.Name = "ActionCopyLineUnicode";
      // 
      // bookDataGridViewTextBoxColumn
      // 
      this.bookDataGridViewTextBoxColumn.DataPropertyName = "Book";
      resources.ApplyResources(this.bookDataGridViewTextBoxColumn, "bookDataGridViewTextBoxColumn");
      this.bookDataGridViewTextBoxColumn.Name = "bookDataGridViewTextBoxColumn";
      this.bookDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // numberDataGridViewTextBoxColumn
      // 
      this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
      resources.ApplyResources(this.numberDataGridViewTextBoxColumn, "numberDataGridViewTextBoxColumn");
      this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
      this.numberDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      resources.ApplyResources(this.nameDataGridViewTextBoxColumn, "nameDataGridViewTextBoxColumn");
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // unicodeDataGridViewTextBoxColumn
      // 
      this.unicodeDataGridViewTextBoxColumn.DataPropertyName = "Unicode";
      resources.ApplyResources(this.unicodeDataGridViewTextBoxColumn, "unicodeDataGridViewTextBoxColumn");
      this.unicodeDataGridViewTextBoxColumn.Name = "unicodeDataGridViewTextBoxColumn";
      this.unicodeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // verseBeginDataGridViewTextBoxColumn
      // 
      this.verseBeginDataGridViewTextBoxColumn.DataPropertyName = "VerseBegin";
      resources.ApplyResources(this.verseBeginDataGridViewTextBoxColumn, "verseBeginDataGridViewTextBoxColumn");
      this.verseBeginDataGridViewTextBoxColumn.Name = "verseBeginDataGridViewTextBoxColumn";
      this.verseBeginDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // verseEndDataGridViewTextBoxColumn
      // 
      this.verseEndDataGridViewTextBoxColumn.DataPropertyName = "VerseEnd";
      resources.ApplyResources(this.verseEndDataGridViewTextBoxColumn, "verseEndDataGridViewTextBoxColumn");
      this.verseEndDataGridViewTextBoxColumn.Name = "verseEndDataGridViewTextBoxColumn";
      this.verseEndDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // isLinkedToNextDataGridViewCheckBoxColumn
      // 
      this.isLinkedToNextDataGridViewCheckBoxColumn.DataPropertyName = "IsLinkedToNext";
      resources.ApplyResources(this.isLinkedToNextDataGridViewCheckBoxColumn, "isLinkedToNextDataGridViewCheckBoxColumn");
      this.isLinkedToNextDataGridViewCheckBoxColumn.Name = "isLinkedToNextDataGridViewCheckBoxColumn";
      this.isLinkedToNextDataGridViewCheckBoxColumn.ReadOnly = true;
      // 
      // ActionOpenVerseOnline
      // 
      resources.ApplyResources(this.ActionOpenVerseOnline, "ActionOpenVerseOnline");
      this.ActionOpenVerseOnline.Name = "ActionOpenVerseOnline";
      // 
      // ActionOpenHebrewWords
      // 
      resources.ApplyResources(this.ActionOpenHebrewWords, "ActionOpenHebrewWords");
      this.ActionOpenHebrewWords.Name = "ActionOpenHebrewWords";
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Name";
      resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Book";
      resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Number";
      resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn9
      // 
      this.dataGridViewTextBoxColumn9.DataPropertyName = "VerseBegin";
      resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      this.dataGridViewTextBoxColumn9.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn10
      // 
      this.dataGridViewTextBoxColumn10.DataPropertyName = "VerseEnd";
      resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      this.dataGridViewTextBoxColumn10.ReadOnly = true;
      // 
      // BindingSource
      // 
      this.BindingSource.DataSource = typeof(Ordisoftware.Hebrew.Parashah);
      // 
      // ParashotForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ParashotForm";
      this.ShowInTaskbar = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditBooksForm_FormClosing);
      this.Load += new System.EventHandler(this.EditBooksForm_Load);
      this.panel1.ResumeLayout(false);
      this.PanelMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
      this.ContextMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.ContextMenuStrip ContextMenu;
    private System.Windows.Forms.ToolStripMenuItem ActionSearchOnline;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenHebrewLetters;
    private System.Windows.Forms.ToolStripSeparator MenuSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyHebrewChars;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyUnicodeChars;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyLineHebrew;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyLineUnicode;
    private System.Windows.Forms.DataGridView DataGridView;
    private System.Windows.Forms.BindingSource BindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn bookDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn unicodeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn verseBeginDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn verseEndDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn isLinkedToNextDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn Unicode;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private System.Windows.Forms.DataGridViewTextBoxColumn IsLinkedToNext;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenVerseOnline;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenHebrewWords;
  }
}
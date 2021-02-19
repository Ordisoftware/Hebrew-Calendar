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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionSave = new System.Windows.Forms.Button();
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.DataGridView = new System.Windows.Forms.DataGridView();
      this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionOpenVerseOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionSearchOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowGrammarGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenShorashon = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewLetters = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenHebrewWords = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyHebrewChars = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyUnicodeChars = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyLineHebrew = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyLineUnicode = new System.Windows.Forms.ToolStripMenuItem();
      this.bookDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.unicodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.verseBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.verseEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.isLinkedToNextDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.ColumnBook = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnTranslation = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnLettriq = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnLinked = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColumnUnicode = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.PanelBottom.SuspendLayout();
      this.PanelMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
      this.ContextMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionSave);
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionSave
      // 
      this.ActionSave.AllowDrop = true;
      this.ActionSave.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSave, "ActionSave");
      this.ActionSave.Name = "ActionSave";
      this.ActionSave.UseVisualStyleBackColor = true;
      this.ActionSave.Click += new System.EventHandler(this.ActionSave_Click);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
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
      this.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.DataGridView.BackgroundColor = System.Drawing.Color.White;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      resources.ApplyResources(this.DataGridView, "DataGridView");
      this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBook,
            this.ColumnNumber,
            this.ColumnName,
            this.ColumnTranslation,
            this.ColumnLettriq,
            this.ColumnBegin,
            this.ColumnEnd,
            this.ColumnLinked,
            this.ColumnUnicode});
      this.DataGridView.ContextMenuStrip = this.ContextMenu;
      this.DataGridView.DataSource = this.BindingSource;
      this.DataGridView.EnableHeadersVisualStyles = false;
      this.DataGridView.MultiSelect = false;
      this.DataGridView.Name = "DataGridView";
      this.DataGridView.RowHeadersVisible = false;
      this.DataGridView.RowTemplate.Height = 28;
      this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DataGridView.ShowCellToolTips = false;
      this.DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
      this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
      this.DataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDown);
      this.DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
      // 
      // ContextMenu
      // 
      this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionOpenVerseOnline,
            this.ActionSearchOnline,
            this.MenuSeparator1,
            this.ActionShowGrammarGuide,
            this.ActionOpenShorashon,
            this.toolStripSeparator1,
            this.ActionOpenHebrewLetters,
            this.ActionOpenHebrewWords,
            this.MenuSeparator2,
            this.ActionCopyHebrewChars,
            this.ActionCopyUnicodeChars,
            this.MenuSeparator3,
            this.ActionCopyLineHebrew,
            this.ActionCopyLineUnicode});
      this.ContextMenu.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenu, "ContextMenu");
      // 
      // ActionOpenVerseOnline
      // 
      resources.ApplyResources(this.ActionOpenVerseOnline, "ActionOpenVerseOnline");
      this.ActionOpenVerseOnline.Name = "ActionOpenVerseOnline";
      // 
      // ActionSearchOnline
      // 
      resources.ApplyResources(this.ActionSearchOnline, "ActionSearchOnline");
      this.ActionSearchOnline.Name = "ActionSearchOnline";
      // 
      // MenuSeparator1
      // 
      this.MenuSeparator1.Name = "MenuSeparator1";
      resources.ApplyResources(this.MenuSeparator1, "MenuSeparator1");
      // 
      // ActionShowGrammarGuide
      // 
      resources.ApplyResources(this.ActionShowGrammarGuide, "ActionShowGrammarGuide");
      this.ActionShowGrammarGuide.Name = "ActionShowGrammarGuide";
      this.ActionShowGrammarGuide.Click += new System.EventHandler(this.ActionShowGrammarGuide_Click);
      // 
      // ActionOpenShorashon
      // 
      resources.ApplyResources(this.ActionOpenShorashon, "ActionOpenShorashon");
      this.ActionOpenShorashon.Name = "ActionOpenShorashon";
      this.ActionOpenShorashon.Tag = "http://shorashon.free.fr/online/";
      this.ActionOpenShorashon.Click += new System.EventHandler(this.ActionOpenShorashon_Click);
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
      this.ActionOpenHebrewLetters.Click += new System.EventHandler(this.ActionOpenHebrewLetters_Click);
      // 
      // ActionOpenHebrewWords
      // 
      resources.ApplyResources(this.ActionOpenHebrewWords, "ActionOpenHebrewWords");
      this.ActionOpenHebrewWords.Name = "ActionOpenHebrewWords";
      this.ActionOpenHebrewWords.Click += new System.EventHandler(this.ActionOpenHebrewWords_Click);
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
      this.ActionCopyHebrewChars.Click += new System.EventHandler(this.ActionCopyHebrewChars_Click);
      // 
      // ActionCopyUnicodeChars
      // 
      resources.ApplyResources(this.ActionCopyUnicodeChars, "ActionCopyUnicodeChars");
      this.ActionCopyUnicodeChars.Name = "ActionCopyUnicodeChars";
      this.ActionCopyUnicodeChars.Click += new System.EventHandler(this.ActionCopyUnicodeChars_Click);
      // 
      // MenuSeparator3
      // 
      this.MenuSeparator3.Name = "MenuSeparator3";
      resources.ApplyResources(this.MenuSeparator3, "MenuSeparator3");
      // 
      // ActionCopyLineHebrew
      // 
      resources.ApplyResources(this.ActionCopyLineHebrew, "ActionCopyLineHebrew");
      this.ActionCopyLineHebrew.Name = "ActionCopyLineHebrew";
      this.ActionCopyLineHebrew.Click += new System.EventHandler(this.ActionCopyLineHebrew_Click);
      // 
      // ActionCopyLineUnicode
      // 
      resources.ApplyResources(this.ActionCopyLineUnicode, "ActionCopyLineUnicode");
      this.ActionCopyLineUnicode.Name = "ActionCopyLineUnicode";
      this.ActionCopyLineUnicode.Click += new System.EventHandler(this.ActionCopyLineUnicode_Click);
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
      // BindingSource
      // 
      this.BindingSource.DataSource = typeof(Ordisoftware.Hebrew.Parashah);
      // 
      // ColumnBook
      // 
      this.ColumnBook.DataPropertyName = "Book";
      resources.ApplyResources(this.ColumnBook, "ColumnBook");
      this.ColumnBook.Name = "ColumnBook";
      this.ColumnBook.ReadOnly = true;
      // 
      // ColumnNumber
      // 
      this.ColumnNumber.DataPropertyName = "Number";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.ColumnNumber.DefaultCellStyle = dataGridViewCellStyle2;
      resources.ApplyResources(this.ColumnNumber, "ColumnNumber");
      this.ColumnNumber.Name = "ColumnNumber";
      this.ColumnNumber.ReadOnly = true;
      // 
      // ColumnName
      // 
      this.ColumnName.DataPropertyName = "Name";
      resources.ApplyResources(this.ColumnName, "ColumnName");
      this.ColumnName.Name = "ColumnName";
      this.ColumnName.ReadOnly = true;
      // 
      // ColumnTranslation
      // 
      this.ColumnTranslation.DataPropertyName = "Translation";
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.ColumnTranslation.DefaultCellStyle = dataGridViewCellStyle3;
      resources.ApplyResources(this.ColumnTranslation, "ColumnTranslation");
      this.ColumnTranslation.Name = "ColumnTranslation";
      this.ColumnTranslation.ReadOnly = true;
      // 
      // ColumnLettriq
      // 
      this.ColumnLettriq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.ColumnLettriq.DataPropertyName = "Lettriq";
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.ColumnLettriq.DefaultCellStyle = dataGridViewCellStyle4;
      resources.ApplyResources(this.ColumnLettriq, "ColumnLettriq");
      this.ColumnLettriq.Name = "ColumnLettriq";
      this.ColumnLettriq.ReadOnly = true;
      // 
      // ColumnBegin
      // 
      this.ColumnBegin.DataPropertyName = "VerseBegin";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.ColumnBegin.DefaultCellStyle = dataGridViewCellStyle5;
      resources.ApplyResources(this.ColumnBegin, "ColumnBegin");
      this.ColumnBegin.Name = "ColumnBegin";
      this.ColumnBegin.ReadOnly = true;
      // 
      // ColumnEnd
      // 
      this.ColumnEnd.DataPropertyName = "VerseEnd";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.ColumnEnd.DefaultCellStyle = dataGridViewCellStyle6;
      resources.ApplyResources(this.ColumnEnd, "ColumnEnd");
      this.ColumnEnd.Name = "ColumnEnd";
      this.ColumnEnd.ReadOnly = true;
      // 
      // ColumnLinked
      // 
      this.ColumnLinked.DataPropertyName = "IsLinkedToNext";
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ColumnLinked.DefaultCellStyle = dataGridViewCellStyle7;
      resources.ApplyResources(this.ColumnLinked, "ColumnLinked");
      this.ColumnLinked.Name = "ColumnLinked";
      this.ColumnLinked.ReadOnly = true;
      // 
      // ColumnUnicode
      // 
      this.ColumnUnicode.DataPropertyName = "Unicode";
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Hebrew", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ColumnUnicode.DefaultCellStyle = dataGridViewCellStyle8;
      resources.ApplyResources(this.ColumnUnicode, "ColumnUnicode");
      this.ColumnUnicode.Name = "ColumnUnicode";
      this.ColumnUnicode.ReadOnly = true;
      // 
      // ParashotForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.PanelBottom);
      this.Name = "ParashotForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParashotForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParashotForm_FormClosed);
      this.Load += new System.EventHandler(this.ParashotForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.PanelMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
      this.ContextMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.ContextMenuStrip ContextMenu;
    private System.Windows.Forms.ToolStripMenuItem ActionSearchOnline;
    private System.Windows.Forms.ToolStripSeparator MenuSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenHebrewLetters;
    private System.Windows.Forms.ToolStripSeparator MenuSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyHebrewChars;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyUnicodeChars;
    private System.Windows.Forms.ToolStripSeparator MenuSeparator3;
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
    private System.Windows.Forms.ToolStripMenuItem ActionOpenVerseOnline;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenHebrewWords;
    private System.Windows.Forms.Button ActionSave;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenShorashon;
    private System.Windows.Forms.ToolStripMenuItem ActionShowGrammarGuide;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBook;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTranslation;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLettriq;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBegin;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnd;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLinked;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnicode;
  }
}
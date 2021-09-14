namespace Ordisoftware.Hebrew.Calendar
{
  partial class CelebrationVersesBoardForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CelebrationVersesBoardForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.SelectVerse = new System.Windows.Forms.ListView();
      this.ColumnBook = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ColumnVerseBegin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ColumnVerseEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ContextMenuVerse = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionOpenVerseOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewWordsVerse = new System.Windows.Forms.ToolStripMenuItem();
      this.SelectCelebration = new System.Windows.Forms.ListView();
      this.ColumnCelebration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ContextMenuCelebration = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionStudyOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.PanelBottom.SuspendLayout();
      this.ContextMenuVerse.SuspendLayout();
      this.ContextMenuCelebration.SuspendLayout();
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
      // SelectVerse
      // 
      resources.ApplyResources(this.SelectVerse, "SelectVerse");
      this.SelectVerse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnBook,
            this.ColumnVerseBegin,
            this.ColumnVerseEnd});
      this.SelectVerse.ContextMenuStrip = this.ContextMenuVerse;
      this.SelectVerse.FullRowSelect = true;
      this.SelectVerse.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.SelectVerse.HideSelection = false;
      this.SelectVerse.MultiSelect = false;
      this.SelectVerse.Name = "SelectVerse";
      this.SelectVerse.UseCompatibleStateImageBehavior = false;
      this.SelectVerse.View = System.Windows.Forms.View.Details;
      this.SelectVerse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lists_KeyDown);
      // 
      // ColumnBook
      // 
      resources.ApplyResources(this.ColumnBook, "ColumnBook");
      // 
      // ColumnVerseBegin
      // 
      resources.ApplyResources(this.ColumnVerseBegin, "ColumnVerseBegin");
      // 
      // ColumnVerseEnd
      // 
      resources.ApplyResources(this.ColumnVerseEnd, "ColumnVerseEnd");
      // 
      // ContextMenuVerse
      // 
      this.ContextMenuVerse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionOpenVerseOnline,
            this.toolStripSeparator2,
            this.ActionOpenHebrewWordsVerse});
      this.ContextMenuVerse.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenuVerse, "ContextMenuVerse");
      // 
      // ActionOpenVerseOnline
      // 
      resources.ApplyResources(this.ActionOpenVerseOnline, "ActionOpenVerseOnline");
      this.ActionOpenVerseOnline.Name = "ActionOpenVerseOnline";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // ActionOpenHebrewWordsVerse
      // 
      resources.ApplyResources(this.ActionOpenHebrewWordsVerse, "ActionOpenHebrewWordsVerse");
      this.ActionOpenHebrewWordsVerse.Name = "ActionOpenHebrewWordsVerse";
      this.ActionOpenHebrewWordsVerse.Click += new System.EventHandler(this.ActionOpenHebrewWordsVerse_Click);
      // 
      // SelectCelebration
      // 
      resources.ApplyResources(this.SelectCelebration, "SelectCelebration");
      this.SelectCelebration.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnCelebration});
      this.SelectCelebration.ContextMenuStrip = this.ContextMenuCelebration;
      this.SelectCelebration.FullRowSelect = true;
      this.SelectCelebration.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.SelectCelebration.HideSelection = false;
      this.SelectCelebration.MultiSelect = false;
      this.SelectCelebration.Name = "SelectCelebration";
      this.SelectCelebration.UseCompatibleStateImageBehavior = false;
      this.SelectCelebration.View = System.Windows.Forms.View.Details;
      this.SelectCelebration.SelectedIndexChanged += new System.EventHandler(this.SelectCelebration_SelectedIndexChanged);
      this.SelectCelebration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lists_KeyDown);
      // 
      // ColumnCelebration
      // 
      resources.ApplyResources(this.ColumnCelebration, "ColumnCelebration");
      // 
      // ContextMenuCelebration
      // 
      this.ContextMenuCelebration.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionStudyOnline});
      this.ContextMenuCelebration.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenuCelebration, "ContextMenuCelebration");
      // 
      // ActionStudyOnline
      // 
      resources.ApplyResources(this.ActionStudyOnline, "ActionStudyOnline");
      this.ActionStudyOnline.Name = "ActionStudyOnline";
      // 
      // CelebrationVersesBoardForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.SelectCelebration);
      this.Controls.Add(this.SelectVerse);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "CelebrationVersesBoardFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.CelebrationVersesBoardFormLocation;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CelebrationVersesBoardForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CelebrationVersesBoardForm_FormClosing);
      this.Load += new System.EventHandler(this.CelebrationVersesBoardForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ContextMenuVerse.ResumeLayout(false);
      this.ContextMenuCelebration.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    public System.Windows.Forms.ListView SelectVerse;
    private System.Windows.Forms.ColumnHeader ColumnBook;
    private System.Windows.Forms.ColumnHeader ColumnVerseBegin;
    private System.Windows.Forms.ColumnHeader ColumnVerseEnd;
    public System.Windows.Forms.ListView SelectCelebration;
    private System.Windows.Forms.ColumnHeader ColumnCelebration;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenVerseOnline;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenHebrewWordsVerse;
    private System.Windows.Forms.ContextMenuStrip ContextMenuVerse;
    private System.Windows.Forms.ContextMenuStrip ContextMenuCelebration;
    private System.Windows.Forms.ToolStripMenuItem ActionStudyOnline;
  }
}
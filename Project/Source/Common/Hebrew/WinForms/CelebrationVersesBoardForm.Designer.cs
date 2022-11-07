namespace Ordisoftware.Hebrew
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
      this.ListBoxVerses = new System.Windows.Forms.ListView();
      this.ColumnBook = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
      this.ColumnVerseBegin = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
      this.ColumnVerseEnd = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
      this.ContextMenuVerse = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionOpenVerseOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewWordsVerse = new System.Windows.Forms.ToolStripMenuItem();
      this.ListBoxCelebrations = new System.Windows.Forms.ListView();
      this.ColumnCelebration = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
      this.ContextMenuCelebration = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionStudyOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.LabelInfoOccurences = new System.Windows.Forms.Label();
      this.PanelBottom.SuspendLayout();
      this.ContextMenuVerse.SuspendLayout();
      this.ContextMenuCelebration.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.LabelInfoOccurences);
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
      this.ListBoxVerses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnBook,
            this.ColumnVerseBegin,
            this.ColumnVerseEnd});
      this.ListBoxVerses.ContextMenuStrip = this.ContextMenuVerse;
      resources.ApplyResources(this.ListBoxVerses, "SelectVerse");
      this.ListBoxVerses.FullRowSelect = true;
      this.ListBoxVerses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.ListBoxVerses.HideSelection = false;
      this.ListBoxVerses.Name = "SelectVerse";
      this.ListBoxVerses.UseCompatibleStateImageBehavior = false;
      this.ListBoxVerses.View = System.Windows.Forms.View.Details;
      this.ListBoxVerses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxes_KeyDown);
      this.ListBoxVerses.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxVerses_MouseDoubleClick);
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
      this.ListBoxCelebrations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnCelebration});
      this.ListBoxCelebrations.ContextMenuStrip = this.ContextMenuCelebration;
      resources.ApplyResources(this.ListBoxCelebrations, "SelectCelebration");
      this.ListBoxCelebrations.FullRowSelect = true;
      this.ListBoxCelebrations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.ListBoxCelebrations.HideSelection = false;
      this.ListBoxCelebrations.MultiSelect = false;
      this.ListBoxCelebrations.Name = "SelectCelebration";
      this.ListBoxCelebrations.UseCompatibleStateImageBehavior = false;
      this.ListBoxCelebrations.View = System.Windows.Forms.View.Details;
      this.ListBoxCelebrations.SelectedIndexChanged += new System.EventHandler(this.ListBoxCelebrations_SelectedIndexChanged);
      this.ListBoxCelebrations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxes_KeyDown);
      this.ListBoxCelebrations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxCelebrations_MouseDoubleClick);
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
      // panel1
      // 
      this.panel1.Controls.Add(this.ListBoxCelebrations);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.ListBoxVerses);
      resources.ApplyResources(this.panel2, "panel2");
      this.panel2.Name = "panel2";
      // 
      // LabelInfoOccurences
      // 
      resources.ApplyResources(this.LabelInfoOccurences, "LabelInfoOccurences");
      this.LabelInfoOccurences.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.LabelInfoOccurences.Name = "LabelInfoOccurences";
      // 
      // CelebrationVersesBoardForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.PanelBottom);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CelebrationVersesBoardForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Deactivate += new System.EventHandler(this.CelebrationVersesBoardForm_Deactivate);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CelebrationVersesBoardForm_FormClosed);
      this.Load += new System.EventHandler(this.CelebrationVersesBoardForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      this.ContextMenuVerse.ResumeLayout(false);
      this.ContextMenuCelebration.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    public System.Windows.Forms.ListView ListBoxVerses;
    private System.Windows.Forms.ColumnHeader ColumnBook;
    private System.Windows.Forms.ColumnHeader ColumnVerseBegin;
    private System.Windows.Forms.ColumnHeader ColumnVerseEnd;
    public System.Windows.Forms.ListView ListBoxCelebrations;
    private System.Windows.Forms.ColumnHeader ColumnCelebration;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenVerseOnline;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenHebrewWordsVerse;
    private System.Windows.Forms.ContextMenuStrip ContextMenuVerse;
    private System.Windows.Forms.ContextMenuStrip ContextMenuCelebration;
    private System.Windows.Forms.ToolStripMenuItem ActionStudyOnline;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private Label LabelInfoOccurences;
  }
}
namespace Ordisoftware.Hebrew.Calendar
{
  partial class LunarMonthsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LunarMonthsForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionSwapColors = new System.Windows.Forms.Button();
      this.ActionEditFiles = new System.Windows.Forms.Button();
      this.ActionViewNotice = new System.Windows.Forms.Button();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ContextMenuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionSearchOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewLetters = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyHebrewChars = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyUnicodeChars = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyLineHebrew = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyLineUnicode = new System.Windows.Forms.ToolStripMenuItem();
      this.PanelMonths = new System.Windows.Forms.Panel();
      this.PanelBottom.SuspendLayout();
      this.ContextMenuItems.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Controls.Add(this.ActionSwapColors);
      this.PanelBottom.Controls.Add(this.ActionEditFiles);
      this.PanelBottom.Controls.Add(this.ActionViewNotice);
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionSwapColors
      // 
      resources.ApplyResources(this.ActionSwapColors, "ActionSwapColors");
      this.ActionSwapColors.AllowDrop = true;
      this.ActionSwapColors.FlatAppearance.BorderSize = 0;
      this.ActionSwapColors.Name = "ActionSwapColors";
      this.ActionSwapColors.TabStop = false;
      this.ActionSwapColors.UseVisualStyleBackColor = true;
      this.ActionSwapColors.Click += new System.EventHandler(this.ActionSwapColors_Click);
      // 
      // ActionEditFiles
      // 
      resources.ApplyResources(this.ActionEditFiles, "ActionEditFiles");
      this.ActionEditFiles.AllowDrop = true;
      this.ActionEditFiles.FlatAppearance.BorderSize = 0;
      this.ActionEditFiles.Name = "ActionEditFiles";
      this.ActionEditFiles.TabStop = false;
      this.ActionEditFiles.UseVisualStyleBackColor = true;
      this.ActionEditFiles.Click += new System.EventHandler(this.ActionEditFiles_Click);
      // 
      // ActionViewNotice
      // 
      resources.ApplyResources(this.ActionViewNotice, "ActionViewNotice");
      this.ActionViewNotice.AllowDrop = true;
      this.ActionViewNotice.FlatAppearance.BorderSize = 0;
      this.ActionViewNotice.Name = "ActionViewNotice";
      this.ActionViewNotice.TabStop = false;
      this.ActionViewNotice.UseVisualStyleBackColor = true;
      this.ActionViewNotice.Click += new System.EventHandler(this.ActionViewNotice_Click);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ContextMenuItems
      // 
      resources.ApplyResources(this.ContextMenuItems, "ContextMenuItems");
      this.ContextMenuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionSearchOnline,
            this.toolStripSeparator1,
            this.ActionOpenHebrewLetters,
            this.MenuSeparator2,
            this.ActionCopyHebrewChars,
            this.ActionCopyUnicodeChars,
            this.toolStripSeparator2,
            this.ActionCopyLineHebrew,
            this.ActionCopyLineUnicode});
      this.ContextMenuItems.Name = "ContextMenuStrip";
      // 
      // ActionSearchOnline
      // 
      resources.ApplyResources(this.ActionSearchOnline, "ActionSearchOnline");
      this.ActionSearchOnline.Name = "ActionSearchOnline";
      // 
      // toolStripSeparator1
      // 
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      // 
      // ActionOpenHebrewLetters
      // 
      resources.ApplyResources(this.ActionOpenHebrewLetters, "ActionOpenHebrewLetters");
      this.ActionOpenHebrewLetters.Name = "ActionOpenHebrewLetters";
      this.ActionOpenHebrewLetters.Click += new System.EventHandler(this.ActionOpenHebrewLetters_Click);
      // 
      // MenuSeparator2
      // 
      resources.ApplyResources(this.MenuSeparator2, "MenuSeparator2");
      this.MenuSeparator2.Name = "MenuSeparator2";
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
      // toolStripSeparator2
      // 
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripSeparator2.Name = "toolStripSeparator2";
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
      // PanelMonths
      // 
      resources.ApplyResources(this.PanelMonths, "PanelMonths");
      this.PanelMonths.Name = "PanelMonths";
      // 
      // LunarMonthsForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelMonths);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "LunarMonthsFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.LunarMonthsFormLocation;
      this.MaximizeBox = false;
      this.Name = "LunarMonthsForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LunarMonthsForm_FormClosing);
      this.Load += new System.EventHandler(this.LunarMonthsForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ContextMenuItems.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.ContextMenuStrip ContextMenuItems;
    private System.Windows.Forms.ToolStripMenuItem ActionSearchOnline;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenHebrewLetters;
    private System.Windows.Forms.ToolStripSeparator MenuSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyHebrewChars;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyUnicodeChars;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyLineHebrew;
    private System.Windows.Forms.Panel PanelMonths;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.Button ActionSwapColors;
    private System.Windows.Forms.Button ActionEditFiles;
    private System.Windows.Forms.Button ActionViewNotice;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyLineUnicode;
  }
}
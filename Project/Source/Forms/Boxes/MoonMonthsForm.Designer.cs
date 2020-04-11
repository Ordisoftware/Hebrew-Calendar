namespace Ordisoftware.HebrewCalendar
{
  partial class MoonMonthsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoonMonthsForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionSwapColors = new System.Windows.Forms.LinkLabel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionReloadFiles = new System.Windows.Forms.LinkLabel();
      this.ActionEditFiles = new System.Windows.Forms.LinkLabel();
      this.ContextMenuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionSearchOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenHebrewLetters = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyFontChars = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyUnicodeChars = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCopyLine = new System.Windows.Forms.ToolStripMenuItem();
      this.PanelMonths = new System.Windows.Forms.Panel();
      this.PanelBottom.SuspendLayout();
      this.ContextMenuItems.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionSwapColors);
      this.PanelBottom.Controls.Add(this.ActionClose);
      this.PanelBottom.Controls.Add(this.ActionReloadFiles);
      this.PanelBottom.Controls.Add(this.ActionEditFiles);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionSwapColors
      // 
      this.ActionSwapColors.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionSwapColors, "ActionSwapColors");
      this.ActionSwapColors.LinkColor = System.Drawing.Color.Navy;
      this.ActionSwapColors.Name = "ActionSwapColors";
      this.ActionSwapColors.TabStop = true;
      this.ActionSwapColors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionSwapColors_LinkClicked);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ActionReloadFiles
      // 
      this.ActionReloadFiles.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionReloadFiles, "ActionReloadFiles");
      this.ActionReloadFiles.LinkColor = System.Drawing.Color.Navy;
      this.ActionReloadFiles.Name = "ActionReloadFiles";
      this.ActionReloadFiles.TabStop = true;
      this.ActionReloadFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionReloadFiles_LinkClicked);
      // 
      // ActionEditFiles
      // 
      this.ActionEditFiles.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionEditFiles, "ActionEditFiles");
      this.ActionEditFiles.LinkColor = System.Drawing.Color.Navy;
      this.ActionEditFiles.Name = "ActionEditFiles";
      this.ActionEditFiles.TabStop = true;
      this.ActionEditFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionEditFiles_LinkClicked);
      // 
      // ContextMenuItems
      // 
      this.ContextMenuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionSearchOnline,
            this.toolStripSeparator1,
            this.ActionOpenHebrewLetters,
            this.MenuSeparator2,
            this.ActionCopyFontChars,
            this.ActionCopyUnicodeChars,
            this.ActionCopyLine});
      this.ContextMenuItems.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenuItems, "ContextMenuItems");
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
      this.ActionOpenHebrewLetters.Click += new System.EventHandler(this.ActionOpenHebrewLetters_Click);
      // 
      // MenuSeparator2
      // 
      this.MenuSeparator2.Name = "MenuSeparator2";
      resources.ApplyResources(this.MenuSeparator2, "MenuSeparator2");
      // 
      // ActionCopyFontChars
      // 
      resources.ApplyResources(this.ActionCopyFontChars, "ActionCopyFontChars");
      this.ActionCopyFontChars.Name = "ActionCopyFontChars";
      this.ActionCopyFontChars.Click += new System.EventHandler(this.ActionCopyFontChars_Click);
      // 
      // ActionCopyUnicodeChars
      // 
      resources.ApplyResources(this.ActionCopyUnicodeChars, "ActionCopyUnicodeChars");
      this.ActionCopyUnicodeChars.Name = "ActionCopyUnicodeChars";
      this.ActionCopyUnicodeChars.Click += new System.EventHandler(this.ActionCopyUnicodeChars_Click);
      // 
      // ActionCopyLine
      // 
      resources.ApplyResources(this.ActionCopyLine, "ActionCopyLine");
      this.ActionCopyLine.Name = "ActionCopyLine";
      this.ActionCopyLine.Click += new System.EventHandler(this.ActionCopyLine_Click);
      // 
      // PanelMonths
      // 
      resources.ApplyResources(this.PanelMonths, "PanelMonths");
      this.PanelMonths.Name = "PanelMonths";
      // 
      // MoonMonthsForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelMonths);
      this.Controls.Add(this.PanelBottom);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.HebrewCalendar.Properties.Settings.Default, "MoonMonthsFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Location = global::Ordisoftware.HebrewCalendar.Properties.Settings.Default.MoonMonthsFormLocation;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MoonMonthsForm";
      this.Load += new System.EventHandler(this.MoonMonthsForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
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
    private System.Windows.Forms.ToolStripMenuItem ActionCopyFontChars;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyUnicodeChars;
    private System.Windows.Forms.ToolStripMenuItem ActionCopyLine;
    private System.Windows.Forms.Panel PanelMonths;
    private System.Windows.Forms.LinkLabel ActionSwapColors;
    private System.Windows.Forms.LinkLabel ActionEditFiles;
    private System.Windows.Forms.LinkLabel ActionReloadFiles;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
  }
}
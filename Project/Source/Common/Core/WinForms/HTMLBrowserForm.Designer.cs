namespace Ordisoftware.Core
{
  partial class HTMLBrowserForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTMLBrowserForm));
      this.WebBrowser = new System.Windows.Forms.WebBrowser();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ActionPrevious = new System.Windows.Forms.ToolStripButton();
      this.ActionNext = new System.Windows.Forms.ToolStripButton();
      this.ActionClose = new System.Windows.Forms.ToolStripButton();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.PanelMainOuter = new System.Windows.Forms.Panel();
      this.PanelMainInner = new System.Windows.Forms.Panel();
      this.PanelMainCenter = new System.Windows.Forms.Panel();
      this.ToolStrip.SuspendLayout();
      this.PanelMain.SuspendLayout();
      this.PanelMainOuter.SuspendLayout();
      this.PanelMainInner.SuspendLayout();
      this.PanelMainCenter.SuspendLayout();
      this.SuspendLayout();
      // 
      // WebBrowser
      // 
      this.WebBrowser.AllowWebBrowserDrop = false;
      resources.ApplyResources(this.WebBrowser, "WebBrowser");
      this.WebBrowser.IsWebBrowserContextMenuEnabled = false;
      this.WebBrowser.Name = "WebBrowser";
      this.WebBrowser.ScriptErrorsSuppressed = true;
      this.WebBrowser.WebBrowserShortcutsEnabled = false;
      this.WebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
      // 
      // ToolStrip
      // 
      resources.ApplyResources(this.ToolStrip, "ToolStrip");
      this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionPrevious,
            this.ActionNext,
            this.ActionClose});
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.ShowItemToolTips = false;
      // 
      // ActionPrevious
      // 
      this.ActionPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionPrevious, "ActionPrevious");
      this.ActionPrevious.Name = "ActionPrevious";
      this.ActionPrevious.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPrevious.Click += new System.EventHandler(this.ActionPrevious_Click);
      // 
      // ActionNext
      // 
      this.ActionNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionNext, "ActionNext");
      this.ActionNext.Name = "ActionNext";
      this.ActionNext.Padding = new System.Windows.Forms.Padding(5);
      this.ActionNext.Click += new System.EventHandler(this.ActionNext_Click);
      // 
      // ActionClose
      // 
      this.ActionClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Padding = new System.Windows.Forms.Padding(5);
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // PanelMain
      // 
      this.PanelMain.Controls.Add(this.PanelMainOuter);
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.Name = "PanelMain";
      // 
      // PanelMainOuter
      // 
      this.PanelMainOuter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelMainOuter.Controls.Add(this.PanelMainInner);
      resources.ApplyResources(this.PanelMainOuter, "PanelMainOuter");
      this.PanelMainOuter.Name = "PanelMainOuter";
      // 
      // PanelMainInner
      // 
      this.PanelMainInner.BackColor = System.Drawing.SystemColors.Control;
      this.PanelMainInner.Controls.Add(this.PanelMainCenter);
      resources.ApplyResources(this.PanelMainInner, "PanelMainInner");
      this.PanelMainInner.Name = "PanelMainInner";
      // 
      // PanelMainCenter
      // 
      this.PanelMainCenter.BackColor = System.Drawing.SystemColors.Control;
      this.PanelMainCenter.Controls.Add(this.WebBrowser);
      resources.ApplyResources(this.PanelMainCenter, "PanelMainCenter");
      this.PanelMainCenter.Name = "PanelMainCenter";
      // 
      // HTMLBrowserForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.ToolStrip);
      this.MaximizeBox = false;
      this.Name = "HTMLBrowserForm";
      this.Deactivate += new System.EventHandler(this.HTMLBrowserForm_Deactivate);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HTMLBrowserForm_FormClosing);
      this.Load += new System.EventHandler(this.HTMLBrowserForm_Load);
      this.Shown += new System.EventHandler(this.HTMLBrowserForm_Shown);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.PanelMain.ResumeLayout(false);
      this.PanelMainOuter.ResumeLayout(false);
      this.PanelMainInner.ResumeLayout(false);
      this.PanelMainCenter.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.WebBrowser WebBrowser;
    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.ToolStripButton ActionPrevious;
    private System.Windows.Forms.ToolStripButton ActionNext;
    private System.Windows.Forms.ToolStripButton ActionClose;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.Panel PanelMainOuter;
    private System.Windows.Forms.Panel PanelMainInner;
    internal System.Windows.Forms.Panel PanelMainCenter;
  }
}

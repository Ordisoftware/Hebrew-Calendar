namespace Ordisoftware.HebrewCommon
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
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelBottomSeparator = new System.Windows.Forms.Panel();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.WebBrowser = new System.Windows.Forms.WebBrowser();
      this.PanelBottom.SuspendLayout();
      this.PanelMain.SuspendLayout();
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
      // PanelBottomSeparator
      // 
      resources.ApplyResources(this.PanelBottomSeparator, "PanelBottomSeparator");
      this.PanelBottomSeparator.Name = "PanelBottomSeparator";
      // 
      // PanelMain
      // 
      this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.PanelMain.Controls.Add(this.WebBrowser);
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.Name = "PanelMain";
      // 
      // WebBrowser
      // 
      this.WebBrowser.AllowWebBrowserDrop = false;
      resources.ApplyResources(this.WebBrowser, "WebBrowser");
      this.WebBrowser.IsWebBrowserContextMenuEnabled = false;
      this.WebBrowser.Name = "WebBrowser";
      this.WebBrowser.ScriptErrorsSuppressed = true;
      this.WebBrowser.WebBrowserShortcutsEnabled = false;
      // 
      // HTMLBrowserForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.PanelBottomSeparator);
      this.Controls.Add(this.PanelBottom);
      this.MaximizeBox = false;
      this.Name = "HTMLBrowserForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HTMLBrowserForm_FormClosing);
      this.Load += new System.EventHandler(this.HTMLBrowserForm_Load);
      this.Shown += new System.EventHandler(this.HTMLBrowserForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.PanelMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelBottomSeparator;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.WebBrowser WebBrowser;
  }
}

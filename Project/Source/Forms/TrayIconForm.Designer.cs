namespace Ordisoftware.HebrewCalendar
{
  partial class TrayIconForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrayIconForm));
      this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.MenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.MenuShowHide = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuNavigate = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuCelebrations = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorTrayMenuView = new System.Windows.Forms.ToolStripSeparator();
      this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuTray.SuspendLayout();
      this.SuspendLayout();
      // 
      // TrayIcon
      // 
      this.TrayIcon.ContextMenuStrip = this.MenuTray;
      resources.ApplyResources(this.TrayIcon, "TrayIcon");
      this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
      // 
      // MenuTray
      // 
      this.MenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuShowHide,
            this.MenuNavigate,
            this.MenuCelebrations,
            this.SeparatorTrayMenuView,
            this.MenuAbout,
            this.MenuExit});
      this.MenuTray.Name = "contextMenuStrip";
      resources.ApplyResources(this.MenuTray, "MenuTray");
      // 
      // MenuShowHide
      // 
      this.MenuShowHide.Name = "MenuShowHide";
      resources.ApplyResources(this.MenuShowHide, "MenuShowHide");
      this.MenuShowHide.Click += new System.EventHandler(this.MenuShowHide_Click);
      // 
      // MenuNavigate
      // 
      resources.ApplyResources(this.MenuNavigate, "MenuNavigate");
      this.MenuNavigate.Name = "MenuNavigate";
      this.MenuNavigate.Click += new System.EventHandler(this.MenuNavigate_Click);
      // 
      // MenuCelebrations
      // 
      resources.ApplyResources(this.MenuCelebrations, "MenuCelebrations");
      this.MenuCelebrations.Name = "MenuCelebrations";
      this.MenuCelebrations.Click += new System.EventHandler(this.MenuCelebrations_Click);
      // 
      // SeparatorTrayMenuView
      // 
      this.SeparatorTrayMenuView.Name = "SeparatorTrayMenuView";
      resources.ApplyResources(this.SeparatorTrayMenuView, "SeparatorTrayMenuView");
      // 
      // MenuAbout
      // 
      resources.ApplyResources(this.MenuAbout, "MenuAbout");
      this.MenuAbout.Name = "MenuAbout";
      this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
      // 
      // MenuExit
      // 
      resources.ApplyResources(this.MenuExit, "MenuExit");
      this.MenuExit.Name = "MenuExit";
      this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
      // 
      // TrayIconForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TrayIconForm";
      this.ShowInTaskbar = false;
      this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TrayIconForm_FormClosed);
      this.Load += new System.EventHandler(this.TrayIconForm_Load);
      this.MenuTray.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip MenuTray;
    internal System.Windows.Forms.ToolStripMenuItem MenuExit;
    private System.Windows.Forms.ToolStripMenuItem MenuAbout;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenuView;
    internal System.Windows.Forms.ToolStripMenuItem MenuShowHide;
    internal System.Windows.Forms.NotifyIcon TrayIcon;
    private System.Windows.Forms.ToolStripMenuItem MenuNavigate;
    private System.Windows.Forms.ToolStripMenuItem MenuCelebrations;
  }
}
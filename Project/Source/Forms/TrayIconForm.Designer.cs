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
      this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorTrayMenuView = new System.Windows.Forms.ToolStripSeparator();
      this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuTray.SuspendLayout();
      this.SuspendLayout();
      // 
      // TrayIcon
      // 
      this.TrayIcon.ContextMenuStrip = this.MenuTray;
      this.TrayIcon.Text = "Hebrew Calendar";
      this.TrayIcon.Visible = true;
      this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
      // 
      // MenuTray
      // 
      this.MenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuShowHide,
            this.MenuAbout,
            this.SeparatorTrayMenuView,
            this.MenuExit});
      this.MenuTray.Name = "contextMenuStrip";
      this.MenuTray.Size = new System.Drawing.Size(181, 98);
      // 
      // MenuShowHide
      // 
      this.MenuShowHide.Name = "MenuShowHide";
      this.MenuShowHide.Size = new System.Drawing.Size(180, 22);
      this.MenuShowHide.Text = "Restore";
      this.MenuShowHide.Click += new System.EventHandler(this.MenuShowHide_Click);
      // 
      // MenuAbout
      // 
      this.MenuAbout.Image = ((System.Drawing.Image)(resources.GetObject("MenuAbout.Image")));
      this.MenuAbout.Name = "MenuAbout";
      this.MenuAbout.Size = new System.Drawing.Size(180, 22);
      this.MenuAbout.Text = "About";
      this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
      // 
      // SeparatorTrayMenuView
      // 
      this.SeparatorTrayMenuView.Name = "SeparatorTrayMenuView";
      this.SeparatorTrayMenuView.Size = new System.Drawing.Size(177, 6);
      // 
      // MenuExit
      // 
      this.MenuExit.Image = ((System.Drawing.Image)(resources.GetObject("MenuExit.Image")));
      this.MenuExit.Name = "MenuExit";
      this.MenuExit.Size = new System.Drawing.Size(180, 22);
      this.MenuExit.Text = "Exit";
      this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
      // 
      // TrayIconForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 66);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TrayIconForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "TrayIcon";
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
  }
}
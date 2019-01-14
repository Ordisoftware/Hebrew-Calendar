namespace Ordisoftware.HebrewCalendar
{
  partial class AboutBox
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && (components != null) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.labelTitle = new System.Windows.Forms.Label();
      this.labelVersion = new System.Windows.Forms.Label();
      this.labelCopyright = new System.Windows.Forms.Label();
      this.labelTrademark = new System.Windows.Forms.LinkLabel();
      this.buttonClose = new System.Windows.Forms.Button();
      this.editLicense = new System.Windows.Forms.RichTextBox();
      this.labelIcons = new System.Windows.Forms.Label();
      this.linkProvider1 = new System.Windows.Forms.LinkLabel();
      this.labelDescription = new System.Windows.Forms.Label();
      this.linkProvider2 = new System.Windows.Forms.LinkLabel();
      this.linkProvider3 = new System.Windows.Forms.LinkLabel();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.linkLabel2 = new System.Windows.Forms.LinkLabel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.linkLabel3 = new System.Windows.Forms.LinkLabel();
      this.label6 = new System.Windows.Forms.Label();
      this.linkLabel4 = new System.Windows.Forms.LinkLabel();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelTitle
      // 
      this.labelTitle.AutoSize = true;
      this.labelTitle.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTitle.Location = new System.Drawing.Point(11, 10);
      this.labelTitle.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(84, 25);
      this.labelTitle.TabIndex = 20;
      this.labelTitle.Text = "-Title-";
      this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelVersion
      // 
      this.labelVersion.AutoSize = true;
      this.labelVersion.Location = new System.Drawing.Point(16, 60);
      this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(45, 13);
      this.labelVersion.TabIndex = 21;
      this.labelVersion.Text = "Version ";
      this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelCopyright
      // 
      this.labelCopyright.AutoSize = true;
      this.labelCopyright.Location = new System.Drawing.Point(16, 80);
      this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new System.Drawing.Size(57, 13);
      this.labelCopyright.TabIndex = 22;
      this.labelCopyright.Text = "-Copyright-";
      this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelTrademark
      // 
      this.labelTrademark.AutoSize = true;
      this.labelTrademark.Location = new System.Drawing.Point(16, 100);
      this.labelTrademark.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.labelTrademark.MaximumSize = new System.Drawing.Size(0, 17);
      this.labelTrademark.Name = "labelTrademark";
      this.labelTrademark.Size = new System.Drawing.Size(64, 13);
      this.labelTrademark.TabIndex = 23;
      this.labelTrademark.TabStop = true;
      this.labelTrademark.Text = "-Trademark-";
      this.labelTrademark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labelTrademark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelTrademarkName_LinkClicked);
      // 
      // buttonClose
      // 
      this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonClose.Location = new System.Drawing.Point(416, 2);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new System.Drawing.Size(75, 24);
      this.buttonClose.TabIndex = 24;
      this.buttonClose.Text = "Close";
      // 
      // editLicense
      // 
      this.editLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.editLicense.BackColor = System.Drawing.SystemColors.Window;
      this.editLicense.Location = new System.Drawing.Point(16, 125);
      this.editLicense.Name = "editLicense";
      this.editLicense.ReadOnly = true;
      this.editLicense.Size = new System.Drawing.Size(483, 204);
      this.editLicense.TabIndex = 26;
      this.editLicense.Text = "";
      this.editLicense.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.editLicense_LinkClicked);
      // 
      // labelIcons
      // 
      this.labelIcons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelIcons.AutoSize = true;
      this.labelIcons.Location = new System.Drawing.Point(112, 340);
      this.labelIcons.Name = "labelIcons";
      this.labelIcons.Size = new System.Drawing.Size(190, 13);
      this.labelIcons.TabIndex = 27;
      this.labelIcons.Text = "Unmodified buttons icons (CC BY 3.0) :";
      // 
      // linkProvider1
      // 
      this.linkProvider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkProvider1.AutoSize = true;
      this.linkProvider1.Location = new System.Drawing.Point(300, 340);
      this.linkProvider1.Name = "linkProvider1";
      this.linkProvider1.Size = new System.Drawing.Size(140, 13);
      this.linkProvider1.TabIndex = 29;
      this.linkProvider1.TabStop = true;
      this.linkProvider1.Text = "www.fatcow.com/free-icons";
      this.linkProvider1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelIconsProvider_LinkClicked);
      // 
      // labelDescription
      // 
      this.labelDescription.AutoSize = true;
      this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelDescription.Location = new System.Drawing.Point(16, 40);
      this.labelDescription.Name = "labelDescription";
      this.labelDescription.Size = new System.Drawing.Size(94, 14);
      this.labelDescription.TabIndex = 30;
      this.labelDescription.Text = "-Description-";
      // 
      // linkProvider2
      // 
      this.linkProvider2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkProvider2.AutoSize = true;
      this.linkProvider2.Location = new System.Drawing.Point(300, 356);
      this.linkProvider2.Name = "linkProvider2";
      this.linkProvider2.Size = new System.Drawing.Size(186, 13);
      this.linkProvider2.TabIndex = 32;
      this.linkProvider2.TabStop = true;
      this.linkProvider2.Text = "github.com/pasnox/oxygen-icons-png";
      this.linkProvider2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelIconsProvider_LinkClicked);
      // 
      // linkProvider3
      // 
      this.linkProvider3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkProvider3.AutoSize = true;
      this.linkProvider3.Location = new System.Drawing.Point(300, 420);
      this.linkProvider3.Name = "linkProvider3";
      this.linkProvider3.Size = new System.Drawing.Size(107, 13);
      this.linkProvider3.TabIndex = 34;
      this.linkProvider3.TabStop = true;
      this.linkProvider3.Text = "aaplus.codeplex.com";
      this.linkProvider3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelIconsProvider_LinkClicked);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(38, 420);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(264, 13);
      this.label1.TabIndex = 33;
      this.label1.Text = "Dynamic linked library seasons computation (MIT 2.0) :";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(118, 356);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(184, 13);
      this.label2.TabIndex = 27;
      this.label2.Text = "Modified application icon (LGPL 3.0) :";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(19, 404);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(283, 13);
      this.label3.TabIndex = 33;
      this.label3.Text = "Unmodified rises and sets computation (unknown license) :";
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(87, 372);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(215, 13);
      this.label4.TabIndex = 33;
      this.label4.Text = "Modified moon phase drawing (COPL 1.02) :";
      // 
      // linkLabel1
      // 
      this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkLabel1.Location = new System.Drawing.Point(300, 404);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(120, 13);
      this.linkLabel1.TabIndex = 34;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "samik26.webgarden.cz/temata/class-sun-moonrise-set";
      this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelIconsProvider_LinkClicked);
      // 
      // linkLabel2
      // 
      this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkLabel2.Location = new System.Drawing.Point(300, 388);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new System.Drawing.Size(65, 13);
      this.linkLabel2.TabIndex = 34;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "jivebay.com/2008/09/07/calculating-the-moon-phase";
      this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelIconsProvider_LinkClicked);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.buttonClose);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(10, 460);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(494, 28);
      this.panel1.TabIndex = 35;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(33, 436);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(269, 13);
      this.label5.TabIndex = 33;
      this.label5.Text = "Included Ordisoftware Core Library preview (LGPL 3.0) :";
      // 
      // linkLabel3
      // 
      this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkLabel3.Location = new System.Drawing.Point(300, 436);
      this.linkLabel3.Name = "linkLabel3";
      this.linkLabel3.Size = new System.Drawing.Size(165, 13);
      this.linkLabel3.TabIndex = 34;
      this.linkLabel3.TabStop = true;
      this.linkLabel3.Text = "ordisoftware/projects/core-library";
      this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelIconsProvider_LinkClicked);
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(38, 388);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(264, 13);
      this.label6.TabIndex = 33;
      this.label6.Text = "Modified moon phase computation (unknown license) :";
      // 
      // linkLabel4
      // 
      this.linkLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.linkLabel4.Location = new System.Drawing.Point(300, 372);
      this.linkLabel4.Name = "linkLabel4";
      this.linkLabel4.Size = new System.Drawing.Size(196, 13);
      this.linkLabel4.TabIndex = 34;
      this.linkLabel4.TabStop = true;
      this.linkLabel4.Text = "www.codeproject.com/Articles/100174/Calculate-and-Draw-Moon-Phase";
      this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelIconsProvider_LinkClicked);
      // 
      // AboutBox
      // 
      this.AcceptButton = this.buttonClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonClose;
      this.ClientSize = new System.Drawing.Size(514, 498);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.linkLabel3);
      this.Controls.Add(this.linkLabel4);
      this.Controls.Add(this.linkLabel2);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.linkProvider3);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.linkProvider2);
      this.Controls.Add(this.labelDescription);
      this.Controls.Add(this.linkProvider1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.labelIcons);
      this.Controls.Add(this.editLicense);
      this.Controls.Add(this.labelTrademark);
      this.Controls.Add(this.labelCopyright);
      this.Controls.Add(this.labelVersion);
      this.Controls.Add(this.labelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "About ";
      this.Load += new System.EventHandler(this.AboutBox_Load);
      this.Shown += new System.EventHandler(this.AboutBox_Shown);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label labelCopyright;
    private System.Windows.Forms.LinkLabel labelTrademark;
    private System.Windows.Forms.Button buttonClose;
    private System.Windows.Forms.RichTextBox editLicense;
    private System.Windows.Forms.Label labelIcons;
    private System.Windows.Forms.LinkLabel linkProvider1;
    private System.Windows.Forms.Label labelDescription;
    private System.Windows.Forms.LinkLabel linkProvider2;
    private System.Windows.Forms.LinkLabel linkProvider3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.LinkLabel linkLabel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.LinkLabel linkLabel3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.LinkLabel linkLabel4;
  }
}

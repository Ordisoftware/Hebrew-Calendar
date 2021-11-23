namespace Ordisoftware.Core
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
      if ( disposing && ( components != null ) )
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
      this.LabelTitle = new System.Windows.Forms.Label();
      this.LabelVersion = new System.Windows.Forms.Label();
      this.LabelCopyright = new System.Windows.Forms.Label();
      this.LabelTrademark = new System.Windows.Forms.LinkLabel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.EditLicense = new System.Windows.Forms.RichTextBox();
      this.LabelDescription = new System.Windows.Forms.Label();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCheckUpdate = new System.Windows.Forms.Button();
      this.ActionViewStats = new System.Windows.Forms.Button();
      this.ActionPrivacyNotice = new System.Windows.Forms.Button();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // LabelTitle
      // 
      resources.ApplyResources(this.LabelTitle, "LabelTitle");
      this.LabelTitle.Name = "LabelTitle";
      // 
      // LabelVersion
      // 
      resources.ApplyResources(this.LabelVersion, "LabelVersion");
      this.LabelVersion.Name = "LabelVersion";
      // 
      // LabelCopyright
      // 
      resources.ApplyResources(this.LabelCopyright, "LabelCopyright");
      this.LabelCopyright.Name = "LabelCopyright";
      // 
      // LabelTrademark
      // 
      this.LabelTrademark.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.LabelTrademark, "LabelTrademark");
      this.LabelTrademark.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.LabelTrademark.LinkColor = System.Drawing.Color.Navy;
      this.LabelTrademark.Name = "LabelTrademark";
      this.LabelTrademark.TabStop = true;
      this.LabelTrademark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelTrademarkName_LinkClicked);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      // 
      // EditLicense
      // 
      resources.ApplyResources(this.EditLicense, "EditLicense");
      this.EditLicense.BackColor = System.Drawing.SystemColors.Window;
      this.EditLicense.Name = "EditLicense";
      this.EditLicense.ReadOnly = true;
      this.EditLicense.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.EditLicense_LinkClicked);
      // 
      // LabelDescription
      // 
      resources.ApplyResources(this.LabelDescription, "LabelDescription");
      this.LabelDescription.Name = "LabelDescription";
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCheckUpdate);
      this.PanelBottom.Controls.Add(this.ActionViewStats);
      this.PanelBottom.Controls.Add(this.ActionPrivacyNotice);
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionCheckUpdate
      // 
      this.ActionCheckUpdate.AllowDrop = true;
      this.ActionCheckUpdate.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionCheckUpdate, "ActionCheckUpdate");
      this.ActionCheckUpdate.Name = "ActionCheckUpdate";
      this.ActionCheckUpdate.UseVisualStyleBackColor = true;
      // 
      // ActionViewStats
      // 
      this.ActionViewStats.AllowDrop = true;
      this.ActionViewStats.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionViewStats, "ActionViewStats");
      this.ActionViewStats.Name = "ActionViewStats";
      this.ActionViewStats.UseVisualStyleBackColor = true;
      // 
      // ActionPrivacyNotice
      // 
      this.ActionPrivacyNotice.AllowDrop = true;
      this.ActionPrivacyNotice.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionPrivacyNotice, "ActionPrivacyNotice");
      this.ActionPrivacyNotice.Name = "ActionPrivacyNotice";
      this.ActionPrivacyNotice.UseVisualStyleBackColor = true;
      this.ActionPrivacyNotice.Click += new System.EventHandler(this.ActionPrivacyNotice_Click);
      // 
      // AboutBox
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.EditLicense);
      this.Controls.Add(this.LabelDescription);
      this.Controls.Add(this.LabelTrademark);
      this.Controls.Add(this.LabelCopyright);
      this.Controls.Add(this.LabelVersion);
      this.Controls.Add(this.LabelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
      this.Load += new System.EventHandler(this.AboutBox_Load);
      this.Shown += new System.EventHandler(this.AboutBox_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.Label LabelVersion;
    private System.Windows.Forms.Label LabelCopyright;
    private System.Windows.Forms.LinkLabel LabelTrademark;
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.RichTextBox EditLicense;
    private System.Windows.Forms.Label LabelDescription;
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionPrivacyNotice;
    public System.Windows.Forms.Button ActionViewStats;
    public System.Windows.Forms.Button ActionCheckUpdate;
  }
}

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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
      this.LabelDependencies = new System.Windows.Forms.Label();
      this.DataGridViewDependencies = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
      this.LabelMedias = new System.Windows.Forms.Label();
      this.DataGridViewMedias = new System.Windows.Forms.DataGridView();
      this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
      this.ActionOpenFolderMedias = new System.Windows.Forms.Button();
      this.ActionOpenFolderDependencies = new System.Windows.Forms.Button();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDependencies)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMedias)).BeginInit();
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
      // LabelDependencies
      // 
      resources.ApplyResources(this.LabelDependencies, "LabelDependencies");
      this.LabelDependencies.Name = "LabelDependencies";
      // 
      // DataGridViewDependencies
      // 
      this.DataGridViewDependencies.AllowUserToAddRows = false;
      this.DataGridViewDependencies.AllowUserToDeleteRows = false;
      this.DataGridViewDependencies.AllowUserToResizeColumns = false;
      this.DataGridViewDependencies.AllowUserToResizeRows = false;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      this.DataGridViewDependencies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
      this.DataGridViewDependencies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.DataGridViewDependencies.BackgroundColor = System.Drawing.SystemColors.Control;
      this.DataGridViewDependencies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.DataGridViewDependencies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.DataGridViewDependencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGridViewDependencies.ColumnHeadersVisible = false;
      this.DataGridViewDependencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
      resources.ApplyResources(this.DataGridViewDependencies, "DataGridViewDependencies");
      this.DataGridViewDependencies.Name = "DataGridViewDependencies";
      this.DataGridViewDependencies.ReadOnly = true;
      this.DataGridViewDependencies.RowHeadersVisible = false;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
      this.DataGridViewDependencies.RowsDefaultCellStyle = dataGridViewCellStyle6;
      this.DataGridViewDependencies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DataGridViewDependencies.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
      // 
      // Column1
      // 
      this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      resources.ApplyResources(this.Column1, "Column1");
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      // 
      // LabelMedias
      // 
      resources.ApplyResources(this.LabelMedias, "LabelMedias");
      this.LabelMedias.Name = "LabelMedias";
      // 
      // DataGridViewMedias
      // 
      this.DataGridViewMedias.AllowUserToAddRows = false;
      this.DataGridViewMedias.AllowUserToDeleteRows = false;
      this.DataGridViewMedias.AllowUserToResizeColumns = false;
      this.DataGridViewMedias.AllowUserToResizeRows = false;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
      this.DataGridViewMedias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
      this.DataGridViewMedias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.DataGridViewMedias.BackgroundColor = System.Drawing.SystemColors.Control;
      this.DataGridViewMedias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.DataGridViewMedias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.DataGridViewMedias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGridViewMedias.ColumnHeadersVisible = false;
      this.DataGridViewMedias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn1});
      resources.ApplyResources(this.DataGridViewMedias, "DataGridViewMedias");
      this.DataGridViewMedias.Name = "DataGridViewMedias";
      this.DataGridViewMedias.ReadOnly = true;
      this.DataGridViewMedias.RowHeadersVisible = false;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
      this.DataGridViewMedias.RowsDefaultCellStyle = dataGridViewCellStyle8;
      this.DataGridViewMedias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DataGridViewMedias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
      // 
      // dataGridViewLinkColumn1
      // 
      this.dataGridViewLinkColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      resources.ApplyResources(this.dataGridViewLinkColumn1, "dataGridViewLinkColumn1");
      this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
      this.dataGridViewLinkColumn1.ReadOnly = true;
      // 
      // ActionOpenFolderMedias
      // 
      this.ActionOpenFolderMedias.AllowDrop = true;
      this.ActionOpenFolderMedias.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionOpenFolderMedias, "ActionOpenFolderMedias");
      this.ActionOpenFolderMedias.Name = "ActionOpenFolderMedias";
      this.ActionOpenFolderMedias.UseVisualStyleBackColor = true;
      this.ActionOpenFolderMedias.Click += new System.EventHandler(this.ActionOpenFolderMedias_Click);
      // 
      // ActionOpenFolderDependencies
      // 
      this.ActionOpenFolderDependencies.AllowDrop = true;
      this.ActionOpenFolderDependencies.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionOpenFolderDependencies, "ActionOpenFolderDependencies");
      this.ActionOpenFolderDependencies.Name = "ActionOpenFolderDependencies";
      this.ActionOpenFolderDependencies.UseVisualStyleBackColor = true;
      this.ActionOpenFolderDependencies.Click += new System.EventHandler(this.ActionOpenFolderDependencies_Click);
      // 
      // AboutBox
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.DataGridViewMedias);
      this.Controls.Add(this.ActionOpenFolderDependencies);
      this.Controls.Add(this.ActionOpenFolderMedias);
      this.Controls.Add(this.DataGridViewDependencies);
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.EditLicense);
      this.Controls.Add(this.LabelDescription);
      this.Controls.Add(this.LabelTrademark);
      this.Controls.Add(this.LabelCopyright);
      this.Controls.Add(this.LabelMedias);
      this.Controls.Add(this.LabelDependencies);
      this.Controls.Add(this.LabelVersion);
      this.Controls.Add(this.LabelTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AboutBox";
      this.Load += new System.EventHandler(this.AboutBox_Load);
      this.Shown += new System.EventHandler(this.AboutBox_Shown);
      this.PanelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDependencies)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMedias)).EndInit();
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
    private Label LabelDependencies;
    private DataGridView DataGridViewDependencies;
    private Label LabelMedias;
    private DataGridViewLinkColumn Column1;
    private DataGridView DataGridViewMedias;
    private DataGridViewLinkColumn dataGridViewLinkColumn1;
    public Button ActionOpenFolderMedias;
    public Button ActionOpenFolderDependencies;
  }
}

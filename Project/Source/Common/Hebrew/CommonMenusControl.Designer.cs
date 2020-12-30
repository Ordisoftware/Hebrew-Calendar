namespace Ordisoftware.Hebrew
{
  partial class CommonMenusControl
  {
    /// <summary> 
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur de composants

    /// <summary> 
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonMenusControl));
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.MenuInformation = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionReadme = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionReleaseNotes = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuApplication = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionApplicationHome = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionGitHubRepo = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorOnlineArchive = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSoftpedia = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionAlternativeTo = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuAssistance = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionForumQA = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorForumQA = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCreateGitHubIssueBug = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCreateGitHubIssueFeature = new System.Windows.Forms.ToolStripMenuItem();
      this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuAuthor = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionAuthorHome = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionContact = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorAuthor1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTwitter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionYouTube = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorAuthor2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTipeee = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSoftware = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionHebrewCalendar = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionHebrewLetters = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionHebrewWords = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // ToolStrip
      // 
      this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuInformation});
      resources.ApplyResources(this.ToolStrip, "ToolStrip");
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.ShowItemToolTips = false;
      // 
      // MenuInformation
      // 
      this.MenuInformation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.MenuInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.MenuInformation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionAbout,
            this.ActionHelp,
            this.Separator1,
            this.ActionReadme,
            this.ActionReleaseNotes,
            this.ActionCheckUpdate,
            this.Separator2,
            this.MenuApplication,
            this.MenuAssistance,
            this.Separator4,
            this.MenuAuthor,
            this.MenuSoftware});
      resources.ApplyResources(this.MenuInformation, "MenuInformation");
      this.MenuInformation.Name = "MenuInformation";
      // 
      // ActionAbout
      // 
      this.ActionAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionAbout, "ActionAbout");
      this.ActionAbout.Name = "ActionAbout";
      this.ActionAbout.Click += new System.EventHandler(this.ActionAbout_Click);
      // 
      // ActionHelp
      // 
      this.ActionHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionHelp, "ActionHelp");
      this.ActionHelp.Name = "ActionHelp";
      this.ActionHelp.Click += new System.EventHandler(this.ActionHelp_Click);
      // 
      // Separator1
      // 
      this.Separator1.Name = "Separator1";
      resources.ApplyResources(this.Separator1, "Separator1");
      // 
      // ActionReadme
      // 
      this.ActionReadme.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionReadme, "ActionReadme");
      this.ActionReadme.Name = "ActionReadme";
      this.ActionReadme.Click += new System.EventHandler(this.ActionReadme_Click);
      // 
      // ActionReleaseNotes
      // 
      this.ActionReleaseNotes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionReleaseNotes, "ActionReleaseNotes");
      this.ActionReleaseNotes.Name = "ActionReleaseNotes";
      this.ActionReleaseNotes.Click += new System.EventHandler(this.ActionReleaseNotes_Click);
      // 
      // ActionCheckUpdate
      // 
      this.ActionCheckUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionCheckUpdate, "ActionCheckUpdate");
      this.ActionCheckUpdate.Name = "ActionCheckUpdate";
      this.ActionCheckUpdate.Click += new System.EventHandler(this.ActionCheckUpdate_Click);
      // 
      // Separator2
      // 
      this.Separator2.Name = "Separator2";
      resources.ApplyResources(this.Separator2, "Separator2");
      // 
      // MenuApplication
      // 
      this.MenuApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionApplicationHome,
            this.ActionGitHubRepo,
            this.SeparatorOnlineArchive,
            this.ActionSoftpedia,
            this.ActionAlternativeTo});
      resources.ApplyResources(this.MenuApplication, "MenuApplication");
      this.MenuApplication.Name = "MenuApplication";
      // 
      // ActionApplicationHome
      // 
      this.ActionApplicationHome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionApplicationHome, "ActionApplicationHome");
      this.ActionApplicationHome.Name = "ActionApplicationHome";
      this.ActionApplicationHome.Click += new System.EventHandler(this.ActionApplicationHome_Click);
      // 
      // ActionGitHubRepo
      // 
      this.ActionGitHubRepo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionGitHubRepo, "ActionGitHubRepo");
      this.ActionGitHubRepo.Name = "ActionGitHubRepo";
      this.ActionGitHubRepo.Tag = "";
      this.ActionGitHubRepo.Click += new System.EventHandler(this.ActionGitHubRepo_Click);
      // 
      // SeparatorOnlineArchive
      // 
      this.SeparatorOnlineArchive.Name = "SeparatorOnlineArchive";
      resources.ApplyResources(this.SeparatorOnlineArchive, "SeparatorOnlineArchive");
      // 
      // ActionSoftpedia
      // 
      resources.ApplyResources(this.ActionSoftpedia, "ActionSoftpedia");
      this.ActionSoftpedia.Name = "ActionSoftpedia";
      this.ActionSoftpedia.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionAlternativeTo
      // 
      resources.ApplyResources(this.ActionAlternativeTo, "ActionAlternativeTo");
      this.ActionAlternativeTo.Name = "ActionAlternativeTo";
      this.ActionAlternativeTo.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // MenuAssistance
      // 
      this.MenuAssistance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionForumQA,
            this.SeparatorForumQA,
            this.ActionCreateGitHubIssueBug,
            this.ActionCreateGitHubIssueFeature});
      resources.ApplyResources(this.MenuAssistance, "MenuAssistance");
      this.MenuAssistance.Name = "MenuAssistance";
      // 
      // ActionForumQA
      // 
      resources.ApplyResources(this.ActionForumQA, "ActionForumQA");
      this.ActionForumQA.Name = "ActionForumQA";
      this.ActionForumQA.Tag = "http://asherhaimhalevi.free-bb.fr/";
      this.ActionForumQA.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // SeparatorForumQA
      // 
      this.SeparatorForumQA.Name = "SeparatorForumQA";
      resources.ApplyResources(this.SeparatorForumQA, "SeparatorForumQA");
      // 
      // ActionCreateGitHubIssueBug
      // 
      this.ActionCreateGitHubIssueBug.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionCreateGitHubIssueBug, "ActionCreateGitHubIssueBug");
      this.ActionCreateGitHubIssueBug.Name = "ActionCreateGitHubIssueBug";
      this.ActionCreateGitHubIssueBug.Tag = "";
      this.ActionCreateGitHubIssueBug.Click += new System.EventHandler(this.ActionSubmitBug_Click);
      // 
      // ActionCreateGitHubIssueFeature
      // 
      this.ActionCreateGitHubIssueFeature.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionCreateGitHubIssueFeature, "ActionCreateGitHubIssueFeature");
      this.ActionCreateGitHubIssueFeature.Name = "ActionCreateGitHubIssueFeature";
      this.ActionCreateGitHubIssueFeature.Tag = "";
      this.ActionCreateGitHubIssueFeature.Click += new System.EventHandler(this.ActionSubmitFeature_Click);
      // 
      // Separator4
      // 
      this.Separator4.Name = "Separator4";
      resources.ApplyResources(this.Separator4, "Separator4");
      // 
      // MenuAuthor
      // 
      this.MenuAuthor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionAuthorHome,
            this.ActionContact,
            this.SeparatorAuthor1,
            this.ActionTwitter,
            this.ActionYouTube,
            this.SeparatorAuthor2,
            this.ActionTipeee,
            this.ActionLinkedIn});
      resources.ApplyResources(this.MenuAuthor, "MenuAuthor");
      this.MenuAuthor.Name = "MenuAuthor";
      // 
      // ActionAuthorHome
      // 
      this.ActionAuthorHome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionAuthorHome, "ActionAuthorHome");
      this.ActionAuthorHome.Name = "ActionAuthorHome";
      this.ActionAuthorHome.Click += new System.EventHandler(this.ActionAuthorHome_Click);
      // 
      // ActionContact
      // 
      this.ActionContact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionContact, "ActionContact");
      this.ActionContact.Name = "ActionContact";
      this.ActionContact.Click += new System.EventHandler(this.ActionContact_Click);
      // 
      // SeparatorAuthor1
      // 
      this.SeparatorAuthor1.Name = "SeparatorAuthor1";
      resources.ApplyResources(this.SeparatorAuthor1, "SeparatorAuthor1");
      // 
      // ActionTwitter
      // 
      this.ActionTwitter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionTwitter, "ActionTwitter");
      this.ActionTwitter.Name = "ActionTwitter";
      this.ActionTwitter.Tag = "https://twitter.com/ordisoftware";
      this.ActionTwitter.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionYouTube
      // 
      this.ActionYouTube.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionYouTube, "ActionYouTube");
      this.ActionYouTube.Name = "ActionYouTube";
      this.ActionYouTube.Tag = "https://www.youtube.com/user/Ordisoftware";
      this.ActionYouTube.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // SeparatorAuthor2
      // 
      this.SeparatorAuthor2.Name = "SeparatorAuthor2";
      resources.ApplyResources(this.SeparatorAuthor2, "SeparatorAuthor2");
      // 
      // ActionTipeee
      // 
      this.ActionTipeee.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionTipeee, "ActionTipeee");
      this.ActionTipeee.Name = "ActionTipeee";
      this.ActionTipeee.Tag = "https://fr.tipeee.com/ordisoftware";
      this.ActionTipeee.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionLinkedIn
      // 
      this.ActionLinkedIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionLinkedIn, "ActionLinkedIn");
      this.ActionLinkedIn.Name = "ActionLinkedIn";
      this.ActionLinkedIn.Tag = "https://www.linkedin.com/in/ordisoftware";
      this.ActionLinkedIn.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // MenuSoftware
      // 
      this.MenuSoftware.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionHebrewCalendar,
            this.ActionHebrewLetters,
            this.ActionHebrewWords});
      resources.ApplyResources(this.MenuSoftware, "MenuSoftware");
      this.MenuSoftware.Name = "MenuSoftware";
      // 
      // ActionHebrewCalendar
      // 
      resources.ApplyResources(this.ActionHebrewCalendar, "ActionHebrewCalendar");
      this.ActionHebrewCalendar.Name = "ActionHebrewCalendar";
      this.ActionHebrewCalendar.Tag = "https://www.ordisoftware.com/projects/hebrew-calendar";
      this.ActionHebrewCalendar.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionHebrewLetters
      // 
      resources.ApplyResources(this.ActionHebrewLetters, "ActionHebrewLetters");
      this.ActionHebrewLetters.Name = "ActionHebrewLetters";
      this.ActionHebrewLetters.Tag = "https://www.ordisoftware.com/projects/hebrew-letters";
      this.ActionHebrewLetters.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionHebrewWords
      // 
      resources.ApplyResources(this.ActionHebrewWords, "ActionHebrewWords");
      this.ActionHebrewWords.Name = "ActionHebrewWords";
      this.ActionHebrewWords.Tag = "https://www.ordisoftware.com/projects/hebrew-words";
      this.ActionHebrewWords.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // CommonMenusControl
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ToolStrip);
      this.Name = "CommonMenusControl";
      this.Load += new System.EventHandler(this.CommonMenusControl_Load);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip ToolStrip;
    public System.Windows.Forms.ToolStripDropDownButton MenuInformation;
    public System.Windows.Forms.ToolStripMenuItem ActionAbout;
    public System.Windows.Forms.ToolStripMenuItem ActionReleaseNotes;
    public System.Windows.Forms.ToolStripMenuItem ActionCheckUpdate;
    private System.Windows.Forms.ToolStripSeparator Separator1;
    public System.Windows.Forms.ToolStripMenuItem ActionReadme;
    public System.Windows.Forms.ToolStripMenuItem ActionHelp;
    private System.Windows.Forms.ToolStripSeparator Separator2;
    private System.Windows.Forms.ToolStripMenuItem MenuApplication;
    public System.Windows.Forms.ToolStripMenuItem ActionApplicationHome;
    public System.Windows.Forms.ToolStripMenuItem ActionGitHubRepo;
    private System.Windows.Forms.ToolStripSeparator SeparatorOnlineArchive;
    private System.Windows.Forms.ToolStripMenuItem ActionAlternativeTo;
    private System.Windows.Forms.ToolStripMenuItem MenuAssistance;
    public System.Windows.Forms.ToolStripMenuItem ActionForumQA;
    private System.Windows.Forms.ToolStripSeparator SeparatorForumQA;
    public System.Windows.Forms.ToolStripMenuItem ActionCreateGitHubIssueBug;
    public System.Windows.Forms.ToolStripMenuItem ActionCreateGitHubIssueFeature;
    private System.Windows.Forms.ToolStripSeparator Separator4;
    private System.Windows.Forms.ToolStripMenuItem MenuAuthor;
    public System.Windows.Forms.ToolStripMenuItem ActionAuthorHome;
    public System.Windows.Forms.ToolStripMenuItem ActionContact;
    private System.Windows.Forms.ToolStripSeparator SeparatorAuthor1;
    public System.Windows.Forms.ToolStripMenuItem ActionTwitter;
    public System.Windows.Forms.ToolStripMenuItem ActionYouTube;
    private System.Windows.Forms.ToolStripSeparator SeparatorAuthor2;
    public System.Windows.Forms.ToolStripMenuItem ActionTipeee;
    public System.Windows.Forms.ToolStripMenuItem ActionLinkedIn;
    private System.Windows.Forms.ToolStripMenuItem MenuSoftware;
    public System.Windows.Forms.ToolStripMenuItem ActionHebrewCalendar;
    public System.Windows.Forms.ToolStripMenuItem ActionHebrewLetters;
    public System.Windows.Forms.ToolStripMenuItem ActionHebrewWords;
    private System.Windows.Forms.ToolStripMenuItem ActionSoftpedia;
  }
}

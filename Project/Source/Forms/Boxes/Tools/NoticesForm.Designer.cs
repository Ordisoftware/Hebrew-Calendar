namespace Ordisoftware.Hebrew.Calendar;

partial class NoticesForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticesForm));
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.PanelBottomSeparator = new System.Windows.Forms.Panel();
      this.MenuPredefinedYears = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.DialogColor = new System.Windows.Forms.ColorDialog();
      this.TabPageNoticeParashah = new System.Windows.Forms.TabPage();
      this.NoticeParashah = new Ordisoftware.Core.RichTextBoxEx();
      this.TabPageNoticeShabat = new System.Windows.Forms.TabPage();
      this.NoticeShabat = new Ordisoftware.Core.RichTextBoxEx();
      this.TabPageNoticeFood = new System.Windows.Forms.TabPage();
      this.NoticeFood = new Ordisoftware.Core.RichTextBoxEx();
      this.TabPageNoticeCelebrations = new System.Windows.Forms.TabPage();
      this.NoticeCelebrations = new Ordisoftware.Core.RichTextBoxEx();
      this.TabPageNoticeGeneration = new System.Windows.Forms.TabPage();
      this.NoticeGeneration = new Ordisoftware.Core.RichTextBoxEx();
      this.TabControlMain = new System.Windows.Forms.TabControl();
      this.PanelButtons.SuspendLayout();
      this.TabPageNoticeParashah.SuspendLayout();
      this.TabPageNoticeShabat.SuspendLayout();
      this.TabPageNoticeFood.SuspendLayout();
      this.TabPageNoticeCelebrations.SuspendLayout();
      this.TabPageNoticeGeneration.SuspendLayout();
      this.TabControlMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Name = "PanelButtons";
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.UseVisualStyleBackColor = true;
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // PanelBottomSeparator
      // 
      resources.ApplyResources(this.PanelBottomSeparator, "PanelBottomSeparator");
      this.PanelBottomSeparator.Name = "PanelBottomSeparator";
      // 
      // MenuPredefinedYears
      // 
      this.MenuPredefinedYears.Name = "MenuSelectMoonDayTextFormat";
      this.MenuPredefinedYears.ShowImageMargin = false;
      resources.ApplyResources(this.MenuPredefinedYears, "MenuPredefinedYears");
      // 
      // DialogColor
      // 
      this.DialogColor.FullOpen = true;
      // 
      // TabPageNoticeParashah
      // 
      this.TabPageNoticeParashah.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageNoticeParashah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageNoticeParashah.Controls.Add(this.NoticeParashah);
      resources.ApplyResources(this.TabPageNoticeParashah, "TabPageNoticeParashah");
      this.TabPageNoticeParashah.Name = "TabPageNoticeParashah";
      // 
      // NoticeParashah
      // 
      this.NoticeParashah.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NoticeParashah.DetectUrls = false;
      resources.ApplyResources(this.NoticeParashah, "NoticeParashah");
      this.NoticeParashah.Name = "NoticeParashah";
      this.NoticeParashah.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // TabPageNoticeShabat
      // 
      this.TabPageNoticeShabat.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageNoticeShabat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageNoticeShabat.Controls.Add(this.NoticeShabat);
      resources.ApplyResources(this.TabPageNoticeShabat, "TabPageNoticeShabat");
      this.TabPageNoticeShabat.Name = "TabPageNoticeShabat";
      // 
      // NoticeShabat
      // 
      this.NoticeShabat.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NoticeShabat.DetectUrls = false;
      resources.ApplyResources(this.NoticeShabat, "NoticeShabat");
      this.NoticeShabat.Name = "NoticeShabat";
      this.NoticeShabat.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // TabPageNoticeFood
      // 
      this.TabPageNoticeFood.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageNoticeFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageNoticeFood.Controls.Add(this.NoticeFood);
      resources.ApplyResources(this.TabPageNoticeFood, "TabPageNoticeFood");
      this.TabPageNoticeFood.Name = "TabPageNoticeFood";
      // 
      // NoticeFood
      // 
      this.NoticeFood.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NoticeFood.DetectUrls = false;
      resources.ApplyResources(this.NoticeFood, "NoticeFood");
      this.NoticeFood.Name = "NoticeFood";
      this.NoticeFood.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // TabPageNoticeCelebrations
      // 
      this.TabPageNoticeCelebrations.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageNoticeCelebrations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageNoticeCelebrations.Controls.Add(this.NoticeCelebrations);
      resources.ApplyResources(this.TabPageNoticeCelebrations, "TabPageNoticeCelebrations");
      this.TabPageNoticeCelebrations.Name = "TabPageNoticeCelebrations";
      // 
      // NoticeCelebrations
      // 
      this.NoticeCelebrations.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NoticeCelebrations.DetectUrls = false;
      resources.ApplyResources(this.NoticeCelebrations, "NoticeCelebrations");
      this.NoticeCelebrations.Name = "NoticeCelebrations";
      this.NoticeCelebrations.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // TabPageNoticeGeneration
      // 
      this.TabPageNoticeGeneration.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageNoticeGeneration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TabPageNoticeGeneration.Controls.Add(this.NoticeGeneration);
      resources.ApplyResources(this.TabPageNoticeGeneration, "TabPageNoticeGeneration");
      this.TabPageNoticeGeneration.Name = "TabPageNoticeGeneration";
      // 
      // NoticeGeneration
      // 
      this.NoticeGeneration.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NoticeGeneration.DetectUrls = false;
      resources.ApplyResources(this.NoticeGeneration, "NoticeGeneration");
      this.NoticeGeneration.Name = "NoticeGeneration";
      this.NoticeGeneration.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // TabControlMain
      // 
      resources.ApplyResources(this.TabControlMain, "TabControlMain");
      this.TabControlMain.Controls.Add(this.TabPageNoticeGeneration);
      this.TabControlMain.Controls.Add(this.TabPageNoticeCelebrations);
      this.TabControlMain.Controls.Add(this.TabPageNoticeFood);
      this.TabControlMain.Controls.Add(this.TabPageNoticeShabat);
      this.TabControlMain.Controls.Add(this.TabPageNoticeParashah);
      this.TabControlMain.Multiline = true;
      this.TabControlMain.Name = "TabControlMain";
      this.TabControlMain.SelectedIndex = 0;
      // 
      // NoticesForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelBottomSeparator);
      this.Controls.Add(this.TabControlMain);
      this.Controls.Add(this.PanelButtons);
      this.MaximizeBox = false;
      this.Name = "NoticesForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Load += new System.EventHandler(this.NoticesForm_Load);
      this.PanelButtons.ResumeLayout(false);
      this.TabPageNoticeParashah.ResumeLayout(false);
      this.TabPageNoticeShabat.ResumeLayout(false);
      this.TabPageNoticeFood.ResumeLayout(false);
      this.TabPageNoticeCelebrations.ResumeLayout(false);
      this.TabPageNoticeGeneration.ResumeLayout(false);
      this.TabControlMain.ResumeLayout(false);
      this.ResumeLayout(false);

  }

  #endregion

  private Panel PanelButtons;
  private Button ActionClose;
  private FolderBrowserDialog FolderBrowserDialog;
  private Panel PanelBottomSeparator;
  private ContextMenuStrip MenuPredefinedYears;
  private ColorDialog DialogColor;
  private TabPage TabPageNoticeParashah;
  private TabPage TabPageNoticeShabat;
  private TabPage TabPageNoticeFood;
  private TabPage TabPageNoticeCelebrations;
  private TabPage TabPageNoticeGeneration;
  private TabControl TabControlMain;
  private RichTextBoxEx NoticeGeneration;
  private RichTextBoxEx NoticeParashah;
  private RichTextBoxEx NoticeShabat;
  private RichTextBoxEx NoticeFood;
  private RichTextBoxEx NoticeCelebrations;
}
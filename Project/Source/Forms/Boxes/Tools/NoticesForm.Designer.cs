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
      this.NoticeFoodMain = new Ordisoftware.Core.RichTextBoxEx();
      this.TabPageNoticeCelebrations = new System.Windows.Forms.TabPage();
      this.NoticeCelebrations = new Ordisoftware.Core.RichTextBoxEx();
      this.TabPageNoticeGeneration = new System.Windows.Forms.TabPage();
      this.NoticeGeneration = new Ordisoftware.Core.RichTextBoxEx();
      this.TabControlMain = new System.Windows.Forms.TabControl();
      this.TabControlFood = new System.Windows.Forms.TabControl();
      this.TabPageFoodMain = new System.Windows.Forms.TabPage();
      this.TabPageFoodPessah = new System.Windows.Forms.TabPage();
      this.TabPageFoodShavuhotDiet = new System.Windows.Forms.TabPage();
      this.TabPageFoodShavuhotLamb = new System.Windows.Forms.TabPage();
      this.TabPageFoodShavuotEnd = new System.Windows.Forms.TabPage();
      this.TabPageFoodTeruhah = new System.Windows.Forms.TabPage();
      this.TabPageFoodKipur = new System.Windows.Forms.TabPage();
      this.TabPageFoodSukot = new System.Windows.Forms.TabPage();
      this.richTextBoxEx1 = new Ordisoftware.Core.RichTextBoxEx();
      this.richTextBoxEx2 = new Ordisoftware.Core.RichTextBoxEx();
      this.richTextBoxEx3 = new Ordisoftware.Core.RichTextBoxEx();
      this.richTextBoxEx4 = new Ordisoftware.Core.RichTextBoxEx();
      this.richTextBoxEx5 = new Ordisoftware.Core.RichTextBoxEx();
      this.richTextBoxEx6 = new Ordisoftware.Core.RichTextBoxEx();
      this.richTextBoxEx7 = new Ordisoftware.Core.RichTextBoxEx();
      this.PanelButtons.SuspendLayout();
      this.TabPageNoticeParashah.SuspendLayout();
      this.TabPageNoticeShabat.SuspendLayout();
      this.TabPageNoticeFood.SuspendLayout();
      this.TabPageNoticeCelebrations.SuspendLayout();
      this.TabPageNoticeGeneration.SuspendLayout();
      this.TabControlMain.SuspendLayout();
      this.TabControlFood.SuspendLayout();
      this.TabPageFoodMain.SuspendLayout();
      this.TabPageFoodPessah.SuspendLayout();
      this.TabPageFoodShavuhotDiet.SuspendLayout();
      this.TabPageFoodShavuhotLamb.SuspendLayout();
      this.TabPageFoodShavuotEnd.SuspendLayout();
      this.TabPageFoodTeruhah.SuspendLayout();
      this.TabPageFoodKipur.SuspendLayout();
      this.TabPageFoodSukot.SuspendLayout();
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
      this.TabPageNoticeFood.Controls.Add(this.TabControlFood);
      resources.ApplyResources(this.TabPageNoticeFood, "TabPageNoticeFood");
      this.TabPageNoticeFood.Name = "TabPageNoticeFood";
      // 
      // NoticeFoodMain
      // 
      this.NoticeFoodMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NoticeFoodMain.DetectUrls = false;
      resources.ApplyResources(this.NoticeFoodMain, "NoticeFoodMain");
      this.NoticeFoodMain.Name = "NoticeFoodMain";
      this.NoticeFoodMain.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
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
      // TabControlFood
      // 
      this.TabControlFood.Controls.Add(this.TabPageFoodMain);
      this.TabControlFood.Controls.Add(this.TabPageFoodPessah);
      this.TabControlFood.Controls.Add(this.TabPageFoodShavuhotDiet);
      this.TabControlFood.Controls.Add(this.TabPageFoodShavuhotLamb);
      this.TabControlFood.Controls.Add(this.TabPageFoodShavuotEnd);
      this.TabControlFood.Controls.Add(this.TabPageFoodTeruhah);
      this.TabControlFood.Controls.Add(this.TabPageFoodKipur);
      this.TabControlFood.Controls.Add(this.TabPageFoodSukot);
      resources.ApplyResources(this.TabControlFood, "TabControlFood");
      this.TabControlFood.Name = "TabControlFood";
      this.TabControlFood.SelectedIndex = 0;
      // 
      // TabPageFoodMain
      // 
      this.TabPageFoodMain.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageFoodMain.Controls.Add(this.NoticeFoodMain);
      resources.ApplyResources(this.TabPageFoodMain, "TabPageFoodMain");
      this.TabPageFoodMain.Name = "TabPageFoodMain";
      this.TabPageFoodMain.UseVisualStyleBackColor = true;
      // 
      // TabPageFoodPessah
      // 
      this.TabPageFoodPessah.Controls.Add(this.richTextBoxEx1);
      resources.ApplyResources(this.TabPageFoodPessah, "TabPageFoodPessah");
      this.TabPageFoodPessah.Name = "TabPageFoodPessah";
      this.TabPageFoodPessah.UseVisualStyleBackColor = true;
      // 
      // TabPageFoodShavuhotDiet
      // 
      this.TabPageFoodShavuhotDiet.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageFoodShavuhotDiet.Controls.Add(this.richTextBoxEx2);
      resources.ApplyResources(this.TabPageFoodShavuhotDiet, "TabPageFoodShavuhotDiet");
      this.TabPageFoodShavuhotDiet.Name = "TabPageFoodShavuhotDiet";
      this.TabPageFoodShavuhotDiet.UseVisualStyleBackColor = true;
      // 
      // TabPageFoodShavuhotLamb
      // 
      this.TabPageFoodShavuhotLamb.Controls.Add(this.richTextBoxEx3);
      resources.ApplyResources(this.TabPageFoodShavuhotLamb, "TabPageFoodShavuhotLamb");
      this.TabPageFoodShavuhotLamb.Name = "TabPageFoodShavuhotLamb";
      this.TabPageFoodShavuhotLamb.UseVisualStyleBackColor = true;
      // 
      // TabPageFoodShavuotEnd
      // 
      this.TabPageFoodShavuotEnd.Controls.Add(this.richTextBoxEx4);
      resources.ApplyResources(this.TabPageFoodShavuotEnd, "TabPageFoodShavuotEnd");
      this.TabPageFoodShavuotEnd.Name = "TabPageFoodShavuotEnd";
      this.TabPageFoodShavuotEnd.UseVisualStyleBackColor = true;
      // 
      // TabPageFoodTeruhah
      // 
      this.TabPageFoodTeruhah.Controls.Add(this.richTextBoxEx5);
      resources.ApplyResources(this.TabPageFoodTeruhah, "TabPageFoodTeruhah");
      this.TabPageFoodTeruhah.Name = "TabPageFoodTeruhah";
      this.TabPageFoodTeruhah.UseVisualStyleBackColor = true;
      // 
      // TabPageFoodKipur
      // 
      this.TabPageFoodKipur.Controls.Add(this.richTextBoxEx6);
      resources.ApplyResources(this.TabPageFoodKipur, "TabPageFoodKipur");
      this.TabPageFoodKipur.Name = "TabPageFoodKipur";
      this.TabPageFoodKipur.UseVisualStyleBackColor = true;
      // 
      // TabPageFoodSukot
      // 
      this.TabPageFoodSukot.Controls.Add(this.richTextBoxEx7);
      resources.ApplyResources(this.TabPageFoodSukot, "TabPageFoodSukot");
      this.TabPageFoodSukot.Name = "TabPageFoodSukot";
      this.TabPageFoodSukot.UseVisualStyleBackColor = true;
      // 
      // richTextBoxEx1
      // 
      this.richTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxEx1.DetectUrls = false;
      resources.ApplyResources(this.richTextBoxEx1, "richTextBoxEx1");
      this.richTextBoxEx1.Name = "richTextBoxEx1";
      this.richTextBoxEx1.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // richTextBoxEx2
      // 
      this.richTextBoxEx2.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxEx2.DetectUrls = false;
      resources.ApplyResources(this.richTextBoxEx2, "richTextBoxEx2");
      this.richTextBoxEx2.Name = "richTextBoxEx2";
      this.richTextBoxEx2.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // richTextBoxEx3
      // 
      this.richTextBoxEx3.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxEx3.DetectUrls = false;
      resources.ApplyResources(this.richTextBoxEx3, "richTextBoxEx3");
      this.richTextBoxEx3.Name = "richTextBoxEx3";
      this.richTextBoxEx3.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // richTextBoxEx4
      // 
      this.richTextBoxEx4.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxEx4.DetectUrls = false;
      resources.ApplyResources(this.richTextBoxEx4, "richTextBoxEx4");
      this.richTextBoxEx4.Name = "richTextBoxEx4";
      this.richTextBoxEx4.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // richTextBoxEx5
      // 
      this.richTextBoxEx5.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxEx5.DetectUrls = false;
      resources.ApplyResources(this.richTextBoxEx5, "richTextBoxEx5");
      this.richTextBoxEx5.Name = "richTextBoxEx5";
      this.richTextBoxEx5.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // richTextBoxEx6
      // 
      this.richTextBoxEx6.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxEx6.DetectUrls = false;
      resources.ApplyResources(this.richTextBoxEx6, "richTextBoxEx6");
      this.richTextBoxEx6.Name = "richTextBoxEx6";
      this.richTextBoxEx6.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
      // 
      // richTextBoxEx7
      // 
      this.richTextBoxEx7.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBoxEx7.DetectUrls = false;
      resources.ApplyResources(this.richTextBoxEx7, "richTextBoxEx7");
      this.richTextBoxEx7.Name = "richTextBoxEx7";
      this.richTextBoxEx7.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
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
      this.TabControlFood.ResumeLayout(false);
      this.TabPageFoodMain.ResumeLayout(false);
      this.TabPageFoodPessah.ResumeLayout(false);
      this.TabPageFoodShavuhotDiet.ResumeLayout(false);
      this.TabPageFoodShavuhotLamb.ResumeLayout(false);
      this.TabPageFoodShavuotEnd.ResumeLayout(false);
      this.TabPageFoodTeruhah.ResumeLayout(false);
      this.TabPageFoodKipur.ResumeLayout(false);
      this.TabPageFoodSukot.ResumeLayout(false);
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
  private RichTextBoxEx NoticeFoodMain;
  private RichTextBoxEx NoticeCelebrations;
  private TabControl TabControlFood;
  private TabPage TabPageFoodMain;
  private TabPage TabPageFoodPessah;
  private TabPage TabPageFoodShavuhotDiet;
  private TabPage TabPageFoodShavuhotLamb;
  private TabPage TabPageFoodShavuotEnd;
  private TabPage TabPageFoodTeruhah;
  private TabPage TabPageFoodKipur;
  private TabPage TabPageFoodSukot;
  private RichTextBoxEx richTextBoxEx1;
  private RichTextBoxEx richTextBoxEx2;
  private RichTextBoxEx richTextBoxEx3;
  private RichTextBoxEx richTextBoxEx4;
  private RichTextBoxEx richTextBoxEx5;
  private RichTextBoxEx richTextBoxEx6;
  private RichTextBoxEx richTextBoxEx7;
}
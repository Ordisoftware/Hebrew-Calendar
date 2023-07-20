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
    this.PanelBottomSeparator = new System.Windows.Forms.Panel();
    this.TabPageNoticeParashah = new System.Windows.Forms.TabPage();
    this.TabPageNoticeShabat = new System.Windows.Forms.TabPage();
    this.TabPageNoticeFood = new System.Windows.Forms.TabPage();
    this.TabControlFood = new System.Windows.Forms.TabControl();
    this.TabPageFoodMain = new System.Windows.Forms.TabPage();
    this.TabPageFoodPessah = new System.Windows.Forms.TabPage();
    this.TabPageFoodShavuhotDiet = new System.Windows.Forms.TabPage();
    this.TabPageFoodShavuhotLamb = new System.Windows.Forms.TabPage();
    this.TabPageFoodShavuotEnd = new System.Windows.Forms.TabPage();
    this.TabPageFoodTeruhah = new System.Windows.Forms.TabPage();
    this.TabPageFoodKipur = new System.Windows.Forms.TabPage();
    this.TabPageFoodSukot = new System.Windows.Forms.TabPage();
    this.TabPageNoticeCelebrations = new System.Windows.Forms.TabPage();
    this.TabPageNoticeGeneration = new System.Windows.Forms.TabPage();
    this.TabControlMain = new System.Windows.Forms.TabControl();
    this.ImageList = new System.Windows.Forms.ImageList(this.components);
    this.NoticeGeneration = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeCelebrations = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodMain = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodPessah = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodShavuhotDiet = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodShavuhotLamb = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodShavuhotEnd = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodTeruhah = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodKipur = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeFoodSukot = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeShabat = new Ordisoftware.Core.RichTextBoxEx();
    this.NoticeParashah = new Ordisoftware.Core.RichTextBoxEx();
    this.PanelButtons.SuspendLayout();
    this.TabPageNoticeParashah.SuspendLayout();
    this.TabPageNoticeShabat.SuspendLayout();
    this.TabPageNoticeFood.SuspendLayout();
    this.TabControlFood.SuspendLayout();
    this.TabPageFoodMain.SuspendLayout();
    this.TabPageFoodPessah.SuspendLayout();
    this.TabPageFoodShavuhotDiet.SuspendLayout();
    this.TabPageFoodShavuhotLamb.SuspendLayout();
    this.TabPageFoodShavuotEnd.SuspendLayout();
    this.TabPageFoodTeruhah.SuspendLayout();
    this.TabPageFoodKipur.SuspendLayout();
    this.TabPageFoodSukot.SuspendLayout();
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
    // TabPageNoticeParashah
    // 
    this.TabPageNoticeParashah.BackColor = System.Drawing.SystemColors.Window;
    this.TabPageNoticeParashah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.TabPageNoticeParashah.Controls.Add(this.NoticeParashah);
    resources.ApplyResources(this.TabPageNoticeParashah, "TabPageNoticeParashah");
    this.TabPageNoticeParashah.Name = "TabPageNoticeParashah";
    // 
    // TabPageNoticeShabat
    // 
    this.TabPageNoticeShabat.BackColor = System.Drawing.SystemColors.Window;
    this.TabPageNoticeShabat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.TabPageNoticeShabat.Controls.Add(this.NoticeShabat);
    resources.ApplyResources(this.TabPageNoticeShabat, "TabPageNoticeShabat");
    this.TabPageNoticeShabat.Name = "TabPageNoticeShabat";
    // 
    // TabPageNoticeFood
    // 
    this.TabPageNoticeFood.BackColor = System.Drawing.SystemColors.Window;
    this.TabPageNoticeFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.TabPageNoticeFood.Controls.Add(this.TabControlFood);
    resources.ApplyResources(this.TabPageNoticeFood, "TabPageNoticeFood");
    this.TabPageNoticeFood.Name = "TabPageNoticeFood";
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
    this.TabPageFoodPessah.Controls.Add(this.NoticeFoodPessah);
    resources.ApplyResources(this.TabPageFoodPessah, "TabPageFoodPessah");
    this.TabPageFoodPessah.Name = "TabPageFoodPessah";
    this.TabPageFoodPessah.UseVisualStyleBackColor = true;
    // 
    // TabPageFoodShavuhotDiet
    // 
    this.TabPageFoodShavuhotDiet.BackColor = System.Drawing.SystemColors.Window;
    this.TabPageFoodShavuhotDiet.Controls.Add(this.NoticeFoodShavuhotDiet);
    resources.ApplyResources(this.TabPageFoodShavuhotDiet, "TabPageFoodShavuhotDiet");
    this.TabPageFoodShavuhotDiet.Name = "TabPageFoodShavuhotDiet";
    this.TabPageFoodShavuhotDiet.UseVisualStyleBackColor = true;
    // 
    // TabPageFoodShavuhotLamb
    // 
    this.TabPageFoodShavuhotLamb.Controls.Add(this.NoticeFoodShavuhotLamb);
    resources.ApplyResources(this.TabPageFoodShavuhotLamb, "TabPageFoodShavuhotLamb");
    this.TabPageFoodShavuhotLamb.Name = "TabPageFoodShavuhotLamb";
    this.TabPageFoodShavuhotLamb.UseVisualStyleBackColor = true;
    // 
    // TabPageFoodShavuotEnd
    // 
    this.TabPageFoodShavuotEnd.Controls.Add(this.NoticeFoodShavuhotEnd);
    resources.ApplyResources(this.TabPageFoodShavuotEnd, "TabPageFoodShavuotEnd");
    this.TabPageFoodShavuotEnd.Name = "TabPageFoodShavuotEnd";
    this.TabPageFoodShavuotEnd.UseVisualStyleBackColor = true;
    // 
    // TabPageFoodTeruhah
    // 
    this.TabPageFoodTeruhah.Controls.Add(this.NoticeFoodTeruhah);
    resources.ApplyResources(this.TabPageFoodTeruhah, "TabPageFoodTeruhah");
    this.TabPageFoodTeruhah.Name = "TabPageFoodTeruhah";
    this.TabPageFoodTeruhah.UseVisualStyleBackColor = true;
    // 
    // TabPageFoodKipur
    // 
    this.TabPageFoodKipur.Controls.Add(this.NoticeFoodKipur);
    resources.ApplyResources(this.TabPageFoodKipur, "TabPageFoodKipur");
    this.TabPageFoodKipur.Name = "TabPageFoodKipur";
    this.TabPageFoodKipur.UseVisualStyleBackColor = true;
    // 
    // TabPageFoodSukot
    // 
    this.TabPageFoodSukot.Controls.Add(this.NoticeFoodSukot);
    resources.ApplyResources(this.TabPageFoodSukot, "TabPageFoodSukot");
    this.TabPageFoodSukot.Name = "TabPageFoodSukot";
    this.TabPageFoodSukot.UseVisualStyleBackColor = true;
    // 
    // TabPageNoticeCelebrations
    // 
    this.TabPageNoticeCelebrations.BackColor = System.Drawing.SystemColors.Window;
    this.TabPageNoticeCelebrations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.TabPageNoticeCelebrations.Controls.Add(this.NoticeCelebrations);
    resources.ApplyResources(this.TabPageNoticeCelebrations, "TabPageNoticeCelebrations");
    this.TabPageNoticeCelebrations.Name = "TabPageNoticeCelebrations";
    // 
    // TabPageNoticeGeneration
    // 
    this.TabPageNoticeGeneration.BackColor = System.Drawing.SystemColors.Window;
    this.TabPageNoticeGeneration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.TabPageNoticeGeneration.Controls.Add(this.NoticeGeneration);
    resources.ApplyResources(this.TabPageNoticeGeneration, "TabPageNoticeGeneration");
    this.TabPageNoticeGeneration.Name = "TabPageNoticeGeneration";
    // 
    // TabControlMain
    // 
    resources.ApplyResources(this.TabControlMain, "TabControlMain");
    this.TabControlMain.Controls.Add(this.TabPageNoticeGeneration);
    this.TabControlMain.Controls.Add(this.TabPageNoticeCelebrations);
    this.TabControlMain.Controls.Add(this.TabPageNoticeFood);
    this.TabControlMain.Controls.Add(this.TabPageNoticeShabat);
    this.TabControlMain.Controls.Add(this.TabPageNoticeParashah);
    this.TabControlMain.ImageList = this.ImageList;
    this.TabControlMain.Multiline = true;
    this.TabControlMain.Name = "TabControlMain";
    this.TabControlMain.SelectedIndex = 0;
    // 
    // ImageList
    // 
    this.ImageList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject("ImageList.ImageStream") ) );
    this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
    this.ImageList.Images.SetKeyName(0, "counter16.ico");
    this.ImageList.Images.SetKeyName(1, "emotion_mah_playlist16.ico");
    this.ImageList.Images.SetKeyName(2, "hamburger16.ico");
    this.ImageList.Images.SetKeyName(3, "candles16.ico");
    this.ImageList.Images.SetKeyName(4, "reading_view16.ico");
    // 
    // NoticeGeneration
    // 
    this.NoticeGeneration.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeGeneration.DetectUrls = false;
    resources.ApplyResources(this.NoticeGeneration, "NoticeGeneration");
    this.NoticeGeneration.Name = "NoticeGeneration";
    this.NoticeGeneration.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeCelebrations
    // 
    this.NoticeCelebrations.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeCelebrations.DetectUrls = false;
    resources.ApplyResources(this.NoticeCelebrations, "NoticeCelebrations");
    this.NoticeCelebrations.Name = "NoticeCelebrations";
    this.NoticeCelebrations.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodMain
    // 
    this.NoticeFoodMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodMain.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodMain, "NoticeFoodMain");
    this.NoticeFoodMain.Name = "NoticeFoodMain";
    this.NoticeFoodMain.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodPessah
    // 
    this.NoticeFoodPessah.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodPessah.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodPessah, "NoticeFoodPessah");
    this.NoticeFoodPessah.Name = "NoticeFoodPessah";
    this.NoticeFoodPessah.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodShavuhotDiet
    // 
    this.NoticeFoodShavuhotDiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodShavuhotDiet.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodShavuhotDiet, "NoticeFoodShavuhotDiet");
    this.NoticeFoodShavuhotDiet.Name = "NoticeFoodShavuhotDiet";
    this.NoticeFoodShavuhotDiet.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodShavuhotLamb
    // 
    this.NoticeFoodShavuhotLamb.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodShavuhotLamb.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodShavuhotLamb, "NoticeFoodShavuhotLamb");
    this.NoticeFoodShavuhotLamb.Name = "NoticeFoodShavuhotLamb";
    this.NoticeFoodShavuhotLamb.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodShavuhotEnd
    // 
    this.NoticeFoodShavuhotEnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodShavuhotEnd.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodShavuhotEnd, "NoticeFoodShavuhotEnd");
    this.NoticeFoodShavuhotEnd.Name = "NoticeFoodShavuhotEnd";
    this.NoticeFoodShavuhotEnd.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodTeruhah
    // 
    this.NoticeFoodTeruhah.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodTeruhah.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodTeruhah, "NoticeFoodTeruhah");
    this.NoticeFoodTeruhah.Name = "NoticeFoodTeruhah";
    this.NoticeFoodTeruhah.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodKipur
    // 
    this.NoticeFoodKipur.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodKipur.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodKipur, "NoticeFoodKipur");
    this.NoticeFoodKipur.Name = "NoticeFoodKipur";
    this.NoticeFoodKipur.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeFoodSukot
    // 
    this.NoticeFoodSukot.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeFoodSukot.DetectUrls = false;
    resources.ApplyResources(this.NoticeFoodSukot, "NoticeFoodSukot");
    this.NoticeFoodSukot.Name = "NoticeFoodSukot";
    this.NoticeFoodSukot.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeShabat
    // 
    this.NoticeShabat.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeShabat.DetectUrls = false;
    resources.ApplyResources(this.NoticeShabat, "NoticeShabat");
    this.NoticeShabat.Name = "NoticeShabat";
    this.NoticeShabat.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticeParashah
    // 
    this.NoticeParashah.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.NoticeParashah.DetectUrls = false;
    resources.ApplyResources(this.NoticeParashah, "NoticeParashah");
    this.NoticeParashah.Name = "NoticeParashah";
    this.NoticeParashah.SelectionAlignment = Ordisoftware.Core.TextAlign.Justify;
    // 
    // NoticesForm
    // 
    resources.ApplyResources(this, "$this");
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.CancelButton = this.ActionClose;
    this.ClientSize = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.NoticesFormSize;
    this.Controls.Add(this.PanelBottomSeparator);
    this.Controls.Add(this.TabControlMain);
    this.Controls.Add(this.PanelButtons);
    this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "NoticesFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "NoticesFormSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
    this.Location = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.NoticesFormLocation;
    this.MaximizeBox = false;
    this.Name = "NoticesForm";
    this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoticesForm_FormClosing);
    this.Load += new System.EventHandler(this.NoticesForm_Load);
    this.PanelButtons.ResumeLayout(false);
    this.TabPageNoticeParashah.ResumeLayout(false);
    this.TabPageNoticeShabat.ResumeLayout(false);
    this.TabPageNoticeFood.ResumeLayout(false);
    this.TabControlFood.ResumeLayout(false);
    this.TabPageFoodMain.ResumeLayout(false);
    this.TabPageFoodPessah.ResumeLayout(false);
    this.TabPageFoodShavuhotDiet.ResumeLayout(false);
    this.TabPageFoodShavuhotLamb.ResumeLayout(false);
    this.TabPageFoodShavuotEnd.ResumeLayout(false);
    this.TabPageFoodTeruhah.ResumeLayout(false);
    this.TabPageFoodKipur.ResumeLayout(false);
    this.TabPageFoodSukot.ResumeLayout(false);
    this.TabPageNoticeCelebrations.ResumeLayout(false);
    this.TabPageNoticeGeneration.ResumeLayout(false);
    this.TabControlMain.ResumeLayout(false);
    this.ResumeLayout(false);

  }

  #endregion

  private Panel PanelButtons;
  private Button ActionClose;
  private Panel PanelBottomSeparator;
  private TabPage TabPageNoticeParashah;
  private TabPage TabPageNoticeShabat;
  private TabPage TabPageNoticeFood;
  private TabPage TabPageNoticeCelebrations;
  private TabPage TabPageNoticeGeneration;
  private TabControl TabControlMain;
  private RichTextBoxEx NoticeGeneration;
  private RichTextBoxEx NoticeParashah;
  private RichTextBoxEx NoticeShabat;
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
  private ImageList ImageList;
  private RichTextBoxEx NoticeFoodMain;
  private RichTextBoxEx NoticeFoodPessah;
  private RichTextBoxEx NoticeFoodShavuhotDiet;
  private RichTextBoxEx NoticeFoodShavuhotLamb;
  private RichTextBoxEx NoticeFoodShavuhotEnd;
  private RichTextBoxEx NoticeFoodTeruhah;
  private RichTextBoxEx NoticeFoodKipur;
  private RichTextBoxEx NoticeFoodSukot;
}
namespace CoolPrintPreview
{
  partial class CoolPrintPreviewDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoolPrintPreviewDialog));
      this._toolStrip = new System.Windows.Forms.ToolStrip();
      this._btnPrint = new System.Windows.Forms.ToolStripButton();
      this._btnPageSetup = new System.Windows.Forms.ToolStripButton();
      this._btnZoom = new System.Windows.Forms.ToolStripSplitButton();
      this._itemActualSize = new System.Windows.Forms.ToolStripMenuItem();
      this._itemFullPage = new System.Windows.Forms.ToolStripMenuItem();
      this._itemPageWidth = new System.Windows.Forms.ToolStripMenuItem();
      this._itemTwoPages = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this._item500 = new System.Windows.Forms.ToolStripMenuItem();
      this._item200 = new System.Windows.Forms.ToolStripMenuItem();
      this._item150 = new System.Windows.Forms.ToolStripMenuItem();
      this._item100 = new System.Windows.Forms.ToolStripMenuItem();
      this._item75 = new System.Windows.Forms.ToolStripMenuItem();
      this._item50 = new System.Windows.Forms.ToolStripMenuItem();
      this._item25 = new System.Windows.Forms.ToolStripMenuItem();
      this._item10 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this._btnFirst = new System.Windows.Forms.ToolStripButton();
      this._btnPrev = new System.Windows.Forms.ToolStripButton();
      this._txtStartPage = new System.Windows.Forms.ToolStripTextBox();
      this._lblPageCount = new System.Windows.Forms.ToolStripLabel();
      this._btnNext = new System.Windows.Forms.ToolStripButton();
      this._btnLast = new System.Windows.Forms.ToolStripButton();
      this._separator = new System.Windows.Forms.ToolStripSeparator();
      this._btnCancel = new System.Windows.Forms.ToolStripButton();
      this._btnClose = new System.Windows.Forms.ToolStripButton();
      this._preview = new CoolPrintPreview.CoolPrintPreviewControl();
      this._toolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // _toolStrip
      // 
      this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this._toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnPrint,
            this._btnPageSetup,
            this._btnZoom,
            this.toolStripSeparator1,
            this._btnFirst,
            this._btnPrev,
            this._txtStartPage,
            this._lblPageCount,
            this._btnNext,
            this._btnLast,
            this._separator,
            this._btnCancel,
            this._btnClose});
      resources.ApplyResources(this._toolStrip, "_toolStrip");
      this._toolStrip.Name = "_toolStrip";
      // 
      // _btnPrint
      // 
      this._btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnPrint, "_btnPrint");
      this._btnPrint.Name = "_btnPrint";
      this._btnPrint.Padding = new System.Windows.Forms.Padding(5);
      this._btnPrint.Click += new System.EventHandler(this._btnPrint_Click);
      // 
      // _btnPageSetup
      // 
      this._btnPageSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnPageSetup, "_btnPageSetup");
      this._btnPageSetup.Name = "_btnPageSetup";
      this._btnPageSetup.Padding = new System.Windows.Forms.Padding(5);
      this._btnPageSetup.Click += new System.EventHandler(this._btnPageSetup_Click);
      // 
      // _btnZoom
      // 
      this._btnZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._itemActualSize,
            this._itemFullPage,
            this._itemPageWidth,
            this._itemTwoPages,
            this.toolStripMenuItem1,
            this._item500,
            this._item200,
            this._item150,
            this._item100,
            this._item75,
            this._item50,
            this._item25,
            this._item10});
      resources.ApplyResources(this._btnZoom, "_btnZoom");
      this._btnZoom.Name = "_btnZoom";
      this._btnZoom.Padding = new System.Windows.Forms.Padding(5);
      this._btnZoom.ButtonClick += new System.EventHandler(this._btnZoom_ButtonClick);
      this._btnZoom.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._btnZoom_DropDownItemClicked);
      // 
      // _itemActualSize
      // 
      resources.ApplyResources(this._itemActualSize, "_itemActualSize");
      this._itemActualSize.Name = "_itemActualSize";
      // 
      // _itemFullPage
      // 
      resources.ApplyResources(this._itemFullPage, "_itemFullPage");
      this._itemFullPage.Name = "_itemFullPage";
      // 
      // _itemPageWidth
      // 
      resources.ApplyResources(this._itemPageWidth, "_itemPageWidth");
      this._itemPageWidth.Name = "_itemPageWidth";
      // 
      // _itemTwoPages
      // 
      resources.ApplyResources(this._itemTwoPages, "_itemTwoPages");
      this._itemTwoPages.Name = "_itemTwoPages";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
      // 
      // _item500
      // 
      this._item500.Name = "_item500";
      resources.ApplyResources(this._item500, "_item500");
      // 
      // _item200
      // 
      this._item200.Name = "_item200";
      resources.ApplyResources(this._item200, "_item200");
      // 
      // _item150
      // 
      this._item150.Name = "_item150";
      resources.ApplyResources(this._item150, "_item150");
      // 
      // _item100
      // 
      this._item100.Name = "_item100";
      resources.ApplyResources(this._item100, "_item100");
      // 
      // _item75
      // 
      this._item75.Name = "_item75";
      resources.ApplyResources(this._item75, "_item75");
      // 
      // _item50
      // 
      this._item50.Name = "_item50";
      resources.ApplyResources(this._item50, "_item50");
      // 
      // _item25
      // 
      this._item25.Name = "_item25";
      resources.ApplyResources(this._item25, "_item25");
      // 
      // _item10
      // 
      this._item10.Name = "_item10";
      resources.ApplyResources(this._item10, "_item10");
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // _btnFirst
      // 
      this._btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnFirst, "_btnFirst");
      this._btnFirst.Name = "_btnFirst";
      this._btnFirst.Padding = new System.Windows.Forms.Padding(5);
      this._btnFirst.Click += new System.EventHandler(this._btnFirst_Click);
      // 
      // _btnPrev
      // 
      this._btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnPrev, "_btnPrev");
      this._btnPrev.Name = "_btnPrev";
      this._btnPrev.Padding = new System.Windows.Forms.Padding(5);
      this._btnPrev.Click += new System.EventHandler(this._btnPrev_Click);
      // 
      // _txtStartPage
      // 
      resources.ApplyResources(this._txtStartPage, "_txtStartPage");
      this._txtStartPage.Name = "_txtStartPage";
      this._txtStartPage.Enter += new System.EventHandler(this._txtStartPage_Enter);
      this._txtStartPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtStartPage_KeyPress);
      this._txtStartPage.Validating += new System.ComponentModel.CancelEventHandler(this._txtStartPage_Validating);
      // 
      // _lblPageCount
      // 
      this._lblPageCount.Name = "_lblPageCount";
      resources.ApplyResources(this._lblPageCount, "_lblPageCount");
      // 
      // _btnNext
      // 
      this._btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnNext, "_btnNext");
      this._btnNext.Name = "_btnNext";
      this._btnNext.Padding = new System.Windows.Forms.Padding(5);
      this._btnNext.Click += new System.EventHandler(this._btnNext_Click);
      // 
      // _btnLast
      // 
      this._btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnLast, "_btnLast");
      this._btnLast.Name = "_btnLast";
      this._btnLast.Padding = new System.Windows.Forms.Padding(5);
      this._btnLast.Click += new System.EventHandler(this._btnLast_Click);
      // 
      // _separator
      // 
      this._separator.Name = "_separator";
      resources.ApplyResources(this._separator, "_separator");
      // 
      // _btnCancel
      // 
      this._btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnCancel, "_btnCancel");
      this._btnCancel.Name = "_btnCancel";
      this._btnCancel.Padding = new System.Windows.Forms.Padding(5);
      this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
      // 
      // _btnClose
      // 
      this._btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this._btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this._btnClose, "_btnClose");
      this._btnClose.Name = "_btnClose";
      this._btnClose.Padding = new System.Windows.Forms.Padding(5);
      this._btnClose.Click += new System.EventHandler(this._btnCancel_Click);
      // 
      // _preview
      // 
      resources.ApplyResources(this._preview, "_preview");
      this._preview.Document = null;
      this._preview.Name = "_preview";
      this._preview.StartPageChanged += new System.EventHandler(this._preview_StartPageChanged);
      this._preview.PageCountChanged += new System.EventHandler(this._preview_PageCountChanged);
      // 
      // CoolPrintPreviewDialog
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this._preview);
      this.Controls.Add(this._toolStrip);
      this.Name = "CoolPrintPreviewDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this._toolStrip.ResumeLayout(false);
      this._toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip _toolStrip;
    private System.Windows.Forms.ToolStripButton _btnPrint;
    private System.Windows.Forms.ToolStripButton _btnPageSetup;
    private CoolPrintPreviewControl _preview;
    private System.Windows.Forms.ToolStripSplitButton _btnZoom;
    private System.Windows.Forms.ToolStripMenuItem _itemActualSize;
    private System.Windows.Forms.ToolStripMenuItem _itemFullPage;
    private System.Windows.Forms.ToolStripMenuItem _itemPageWidth;
    private System.Windows.Forms.ToolStripMenuItem _itemTwoPages;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem _item500;
    private System.Windows.Forms.ToolStripMenuItem _item200;
    private System.Windows.Forms.ToolStripMenuItem _item150;
    private System.Windows.Forms.ToolStripMenuItem _item100;
    private System.Windows.Forms.ToolStripMenuItem _item75;
    private System.Windows.Forms.ToolStripMenuItem _item50;
    private System.Windows.Forms.ToolStripMenuItem _item25;
    private System.Windows.Forms.ToolStripMenuItem _item10;
    private System.Windows.Forms.ToolStripButton _btnFirst;
    private System.Windows.Forms.ToolStripButton _btnPrev;
    private System.Windows.Forms.ToolStripTextBox _txtStartPage;
    private System.Windows.Forms.ToolStripLabel _lblPageCount;
    private System.Windows.Forms.ToolStripButton _btnNext;
    private System.Windows.Forms.ToolStripButton _btnLast;
    private System.Windows.Forms.ToolStripSeparator _separator;
    private System.Windows.Forms.ToolStripButton _btnCancel;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton _btnClose;
  }
}
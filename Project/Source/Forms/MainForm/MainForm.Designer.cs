namespace Ordisoftware.HebrewCalendar
{
  partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.PanelCalendarOuter = new System.Windows.Forms.Panel();
      this.PanelCalendarInner = new System.Windows.Forms.Panel();
      this.PanelCalendar = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageText = new System.Windows.Forms.TabPage();
      this.PanelViewText = new System.Windows.Forms.Panel();
      this.CalendarText = new System.Windows.Forms.RichTextBox();
      this.TabPageMonth = new System.Windows.Forms.TabPage();
      this.PanelViewMonth = new System.Windows.Forms.Panel();
      this.TabPageGrid = new System.Windows.Forms.TabPage();
      this.PanelViewGrid = new System.Windows.Forms.Panel();
      this.CalendarGrid = new System.Windows.Forms.DataGridView();
      this.LunisolarDaysBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
      this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.PanelSepTop = new System.Windows.Forms.Panel();
      this.PanelTitle = new System.Windows.Forms.Panel();
      this.LabelTitle = new System.Windows.Forms.Label();
      this.moonPhaseImagePictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.TimerTooltip = new System.Windows.Forms.Timer(this.components);
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ActionSaveReport = new System.Windows.Forms.ToolStripButton();
      this.ActionExportCSV = new System.Windows.Forms.ToolStripButton();
      this.Sep1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopyReportToClipboard = new System.Windows.Forms.ToolStripButton();
      this.ActionPrint = new System.Windows.Forms.ToolStripButton();
      this.Sep2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSearchEvent = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchMonth = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchDay = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionNavigate = new System.Windows.Forms.ToolStripButton();
      this.ActionViewCelebrations = new System.Windows.Forms.ToolStripButton();
      this.Sep3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionExit = new System.Windows.Forms.ToolStripButton();
      this.Sep4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionHelp = new System.Windows.Forms.ToolStripButton();
      this.ActionInformation = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWebReleaseNotes = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCreateGitHubIssue = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebQA = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWebHome = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebContact = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebTipeee = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWebLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebTwitter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebYouTube = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionDownloadHebrewLetters = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionDownloadHebrewWords = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionResetReminder = new System.Windows.Forms.ToolStripButton();
      this.ActionDisableReminder = new System.Windows.Forms.ToolStripButton();
      this.ActionEnableReminder = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTools = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionViewMoonMonths = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowCelebrationsNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowShabatNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCalculateDateDiff = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenCalculator = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenSystemDateAndTime = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionGenerate = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebLinks = new System.Windows.Forms.ToolStripDropDownButton();
      this.Sep6 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionPreferences = new System.Windows.Forms.ToolStripButton();
      this.ActionSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.MenuitemScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenNone = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenTopRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenBottomRight = new System.Windows.Forms.ToolStripMenuItem();
      this.EditScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionResetWinSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.Sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.EditShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.EditESCtoExit = new System.Windows.Forms.ToolStripMenuItem();
      this.EditConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionView = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionViewReport = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewMonth = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewGrid = new System.Windows.Forms.ToolStripMenuItem();
      this.SaveCSVDialog = new System.Windows.Forms.SaveFileDialog();
      this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.MenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.MenuShowHide = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorTrayMenu1 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuNavigate = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuCelebrations = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorTrayMenu3 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuResetReminder = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuEnableReminder = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuDisableReminder = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorTrayMenu2 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuTools = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuWebLinks = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuInformation = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorTrayMenu5 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuPreferences = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.PrintDialog = new System.Windows.Forms.PrintDialog();
      this.TimerReminder = new System.Windows.Forms.Timer(this.components);
      this.TimerBallon = new System.Windows.Forms.Timer(this.components);
      this.TimerTrayMouseMove = new System.Windows.Forms.Timer(this.components);
      this.TimerResumeReminder = new System.Windows.Forms.Timer(this.components);
      this.CalendarMonth = new Calendar.NET.Calendar();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LunisolarDaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.DataSet = new Ordisoftware.HebrewCalendar.Data.DataSet();
      this.LunisolarDaysTableAdapter = new Ordisoftware.HebrewCalendar.Data.DataSetTableAdapters.LunisolarDaysTableAdapter();
      this.TableAdapterManager = new Ordisoftware.HebrewCalendar.Data.DataSetTableAdapters.TableAdapterManager();
      this.ReportTableAdapter = new Ordisoftware.HebrewCalendar.Data.DataSetTableAdapters.ReportTableAdapter();
      this.PanelMain.SuspendLayout();
      this.PanelCalendarOuter.SuspendLayout();
      this.PanelCalendarInner.SuspendLayout();
      this.PanelCalendar.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.TabPageText.SuspendLayout();
      this.PanelViewText.SuspendLayout();
      this.TabPageMonth.SuspendLayout();
      this.PanelViewMonth.SuspendLayout();
      this.TabPageGrid.SuspendLayout();
      this.PanelViewGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CalendarGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingNavigator)).BeginInit();
      this.LunisolarDaysBindingNavigator.SuspendLayout();
      this.PanelTitle.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).BeginInit();
      this.ToolStrip.SuspendLayout();
      this.MenuTray.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // SaveFileDialog
      // 
      this.SaveFileDialog.FileName = "Hebrew Calendar.txt";
      resources.ApplyResources(this.SaveFileDialog, "SaveFileDialog");
      // 
      // PanelMain
      // 
      this.PanelMain.Controls.Add(this.PanelCalendarOuter);
      this.PanelMain.Controls.Add(this.PanelSepTop);
      this.PanelMain.Controls.Add(this.PanelTitle);
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.Name = "PanelMain";
      // 
      // PanelCalendarOuter
      // 
      this.PanelCalendarOuter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelCalendarOuter.Controls.Add(this.PanelCalendarInner);
      resources.ApplyResources(this.PanelCalendarOuter, "PanelCalendarOuter");
      this.PanelCalendarOuter.Name = "PanelCalendarOuter";
      // 
      // PanelCalendarInner
      // 
      this.PanelCalendarInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.PanelCalendarInner.Controls.Add(this.PanelCalendar);
      resources.ApplyResources(this.PanelCalendarInner, "PanelCalendarInner");
      this.PanelCalendarInner.Name = "PanelCalendarInner";
      // 
      // PanelCalendar
      // 
      this.PanelCalendar.Controls.Add(this.TabControl);
      resources.ApplyResources(this.PanelCalendar, "PanelCalendar");
      this.PanelCalendar.Name = "PanelCalendar";
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.TabPageText);
      this.TabControl.Controls.Add(this.TabPageMonth);
      this.TabControl.Controls.Add(this.TabPageGrid);
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.TabStop = false;
      // 
      // TabPageText
      // 
      this.TabPageText.Controls.Add(this.PanelViewText);
      resources.ApplyResources(this.TabPageText, "TabPageText");
      this.TabPageText.Name = "TabPageText";
      this.TabPageText.UseVisualStyleBackColor = true;
      // 
      // PanelViewText
      // 
      this.PanelViewText.Controls.Add(this.CalendarText);
      resources.ApplyResources(this.PanelViewText, "PanelViewText");
      this.PanelViewText.Name = "PanelViewText";
      // 
      // CalendarText
      // 
      this.CalendarText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.CalendarText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      resources.ApplyResources(this.CalendarText, "CalendarText");
      this.CalendarText.Name = "CalendarText";
      this.CalendarText.ReadOnly = true;
      this.CalendarText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalendarText_KeyDown);
      // 
      // TabPageMonth
      // 
      this.TabPageMonth.Controls.Add(this.PanelViewMonth);
      resources.ApplyResources(this.TabPageMonth, "TabPageMonth");
      this.TabPageMonth.Name = "TabPageMonth";
      this.TabPageMonth.UseVisualStyleBackColor = true;
      // 
      // PanelViewMonth
      // 
      this.PanelViewMonth.Controls.Add(this.CalendarMonth);
      resources.ApplyResources(this.PanelViewMonth, "PanelViewMonth");
      this.PanelViewMonth.Name = "PanelViewMonth";
      // 
      // TabPageGrid
      // 
      this.TabPageGrid.Controls.Add(this.PanelViewGrid);
      resources.ApplyResources(this.TabPageGrid, "TabPageGrid");
      this.TabPageGrid.Name = "TabPageGrid";
      this.TabPageGrid.UseVisualStyleBackColor = true;
      // 
      // PanelViewGrid
      // 
      this.PanelViewGrid.Controls.Add(this.CalendarGrid);
      this.PanelViewGrid.Controls.Add(this.LunisolarDaysBindingNavigator);
      resources.ApplyResources(this.PanelViewGrid, "PanelViewGrid");
      this.PanelViewGrid.Name = "PanelViewGrid";
      // 
      // CalendarGrid
      // 
      this.CalendarGrid.AllowUserToAddRows = false;
      this.CalendarGrid.AllowUserToDeleteRows = false;
      this.CalendarGrid.AllowUserToResizeRows = false;
      this.CalendarGrid.AutoGenerateColumns = false;
      this.CalendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.CalendarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
      this.CalendarGrid.DataSource = this.LunisolarDaysBindingSource;
      resources.ApplyResources(this.CalendarGrid, "CalendarGrid");
      this.CalendarGrid.MultiSelect = false;
      this.CalendarGrid.Name = "CalendarGrid";
      this.CalendarGrid.ReadOnly = true;
      this.CalendarGrid.RowHeadersVisible = false;
      this.CalendarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.CalendarGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CalendarGrid_CellFormatting);
      // 
      // LunisolarDaysBindingNavigator
      // 
      this.LunisolarDaysBindingNavigator.AddNewItem = null;
      this.LunisolarDaysBindingNavigator.BindingSource = this.LunisolarDaysBindingSource;
      this.LunisolarDaysBindingNavigator.CountItem = this.bindingNavigatorCountItem;
      this.LunisolarDaysBindingNavigator.DeleteItem = null;
      this.LunisolarDaysBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
      resources.ApplyResources(this.LunisolarDaysBindingNavigator, "LunisolarDaysBindingNavigator");
      this.LunisolarDaysBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
      this.LunisolarDaysBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
      this.LunisolarDaysBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
      this.LunisolarDaysBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
      this.LunisolarDaysBindingNavigator.Name = "LunisolarDaysBindingNavigator";
      this.LunisolarDaysBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
      // 
      // bindingNavigatorCountItem
      // 
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
      // 
      // bindingNavigatorMoveFirstItem
      // 
      this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      // 
      // bindingNavigatorMovePreviousItem
      // 
      this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      // 
      // bindingNavigatorSeparator
      // 
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
      // 
      // bindingNavigatorPositionItem
      // 
      resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      // 
      // bindingNavigatorSeparator1
      // 
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
      // 
      // bindingNavigatorMoveNextItem
      // 
      this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      // 
      // bindingNavigatorMoveLastItem
      // 
      this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      // 
      // PanelSepTop
      // 
      resources.ApplyResources(this.PanelSepTop, "PanelSepTop");
      this.PanelSepTop.Name = "PanelSepTop";
      // 
      // PanelTitle
      // 
      this.PanelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelTitle.Controls.Add(this.LabelTitle);
      resources.ApplyResources(this.PanelTitle, "PanelTitle");
      this.PanelTitle.Name = "PanelTitle";
      // 
      // LabelTitle
      // 
      this.LabelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelTitle, "LabelTitle");
      this.LabelTitle.Name = "LabelTitle";
      // 
      // moonPhaseImagePictureBox
      // 
      this.moonPhaseImagePictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
      resources.ApplyResources(this.moonPhaseImagePictureBox, "moonPhaseImagePictureBox");
      this.moonPhaseImagePictureBox.Name = "moonPhaseImagePictureBox";
      this.moonPhaseImagePictureBox.TabStop = false;
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // TimerTooltip
      // 
      this.TimerTooltip.Interval = 500;
      this.TimerTooltip.Tick += new System.EventHandler(this.TimerTooltip_Tick);
      // 
      // ToolStrip
      // 
      this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionSaveReport,
            this.ActionExportCSV,
            this.Sep1,
            this.ActionCopyReportToClipboard,
            this.ActionPrint,
            this.Sep2,
            this.ActionSearchEvent,
            this.ActionSearchMonth,
            this.ActionSearchDay,
            this.toolStripSeparator12,
            this.ActionNavigate,
            this.ActionViewCelebrations,
            this.Sep3,
            this.ActionExit,
            this.Sep4,
            this.ActionHelp,
            this.ActionInformation,
            this.ActionResetReminder,
            this.ActionDisableReminder,
            this.ActionEnableReminder,
            this.toolStripSeparator4,
            this.ActionTools,
            this.ActionWebLinks,
            this.Sep6,
            this.ActionPreferences,
            this.ActionSettings,
            this.ActionView});
      resources.ApplyResources(this.ToolStrip, "ToolStrip");
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.ShowItemToolTips = false;
      // 
      // ActionSaveReport
      // 
      this.ActionSaveReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSaveReport, "ActionSaveReport");
      this.ActionSaveReport.Name = "ActionSaveReport";
      this.ActionSaveReport.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSaveReport.Click += new System.EventHandler(this.ActionSaveReport_Click);
      this.ActionSaveReport.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionSaveReport.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionExportCSV
      // 
      this.ActionExportCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionExportCSV, "ActionExportCSV");
      this.ActionExportCSV.Name = "ActionExportCSV";
      this.ActionExportCSV.Padding = new System.Windows.Forms.Padding(5);
      this.ActionExportCSV.Click += new System.EventHandler(this.ActionExportCSV_Click);
      this.ActionExportCSV.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionExportCSV.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // Sep1
      // 
      this.Sep1.Name = "Sep1";
      resources.ApplyResources(this.Sep1, "Sep1");
      // 
      // ActionCopyReportToClipboard
      // 
      this.ActionCopyReportToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionCopyReportToClipboard, "ActionCopyReportToClipboard");
      this.ActionCopyReportToClipboard.Name = "ActionCopyReportToClipboard";
      this.ActionCopyReportToClipboard.Padding = new System.Windows.Forms.Padding(5);
      this.ActionCopyReportToClipboard.Click += new System.EventHandler(this.ActionCopyReportToClipboard_Click);
      this.ActionCopyReportToClipboard.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionCopyReportToClipboard.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionPrint
      // 
      this.ActionPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionPrint, "ActionPrint");
      this.ActionPrint.Name = "ActionPrint";
      this.ActionPrint.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPrint.Click += new System.EventHandler(this.ActionPrint_Click);
      this.ActionPrint.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionPrint.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // Sep2
      // 
      this.Sep2.Name = "Sep2";
      resources.ApplyResources(this.Sep2, "Sep2");
      // 
      // ActionSearchEvent
      // 
      this.ActionSearchEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchEvent, "ActionSearchEvent");
      this.ActionSearchEvent.Name = "ActionSearchEvent";
      this.ActionSearchEvent.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchEvent.Click += new System.EventHandler(this.ActionSearchEvent_Click);
      this.ActionSearchEvent.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionSearchEvent.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionSearchMonth
      // 
      this.ActionSearchMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchMonth, "ActionSearchMonth");
      this.ActionSearchMonth.Name = "ActionSearchMonth";
      this.ActionSearchMonth.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchMonth.Click += new System.EventHandler(this.ActionSearchMonth_Click);
      this.ActionSearchMonth.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionSearchMonth.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionSearchDay
      // 
      this.ActionSearchDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchDay, "ActionSearchDay");
      this.ActionSearchDay.Name = "ActionSearchDay";
      this.ActionSearchDay.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchDay.Click += new System.EventHandler(this.ActionSearchDay_Click);
      this.ActionSearchDay.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionSearchDay.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // toolStripSeparator12
      // 
      this.toolStripSeparator12.Name = "toolStripSeparator12";
      resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
      // 
      // ActionNavigate
      // 
      this.ActionNavigate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionNavigate, "ActionNavigate");
      this.ActionNavigate.Name = "ActionNavigate";
      this.ActionNavigate.Padding = new System.Windows.Forms.Padding(5);
      this.ActionNavigate.Click += new System.EventHandler(this.ActionNavigate_Click);
      this.ActionNavigate.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionNavigate.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionViewCelebrations
      // 
      this.ActionViewCelebrations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewCelebrations, "ActionViewCelebrations");
      this.ActionViewCelebrations.Name = "ActionViewCelebrations";
      this.ActionViewCelebrations.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewCelebrations.Click += new System.EventHandler(this.ActionViewCelebrations_Click);
      this.ActionViewCelebrations.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionViewCelebrations.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // Sep3
      // 
      this.Sep3.Name = "Sep3";
      resources.ApplyResources(this.Sep3, "Sep3");
      // 
      // ActionExit
      // 
      this.ActionExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionExit, "ActionExit");
      this.ActionExit.Name = "ActionExit";
      this.ActionExit.Padding = new System.Windows.Forms.Padding(5);
      this.ActionExit.Click += new System.EventHandler(this.ActionExit_Click);
      this.ActionExit.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionExit.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      this.ActionExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ActionExit_MouseUp);
      // 
      // Sep4
      // 
      this.Sep4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep4.Name = "Sep4";
      resources.ApplyResources(this.Sep4, "Sep4");
      // 
      // ActionHelp
      // 
      this.ActionHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionHelp, "ActionHelp");
      this.ActionHelp.Name = "ActionHelp";
      this.ActionHelp.Padding = new System.Windows.Forms.Padding(5);
      this.ActionHelp.Click += new System.EventHandler(this.ActionHelp_Click);
      this.ActionHelp.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionHelp.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionInformation
      // 
      this.ActionInformation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionInformation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionAbout,
            this.toolStripSeparator6,
            this.ActionWebReleaseNotes,
            this.ActionWebCheckUpdate,
            this.toolStripSeparator9,
            this.ActionCreateGitHubIssue,
            this.ActionWebQA,
            this.toolStripSeparator3,
            this.ActionWebHome,
            this.ActionWebContact,
            this.ActionWebTipeee,
            this.toolStripSeparator2,
            this.ActionWebLinkedIn,
            this.ActionWebTwitter,
            this.ActionWebYouTube,
            this.toolStripSeparator5,
            this.ActionDownloadHebrewLetters,
            this.ActionDownloadHebrewWords});
      resources.ApplyResources(this.ActionInformation, "ActionInformation");
      this.ActionInformation.Name = "ActionInformation";
      // 
      // ActionAbout
      // 
      this.ActionAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionAbout, "ActionAbout");
      this.ActionAbout.Name = "ActionAbout";
      this.ActionAbout.Click += new System.EventHandler(this.ActionAbout_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
      // 
      // ActionWebReleaseNotes
      // 
      this.ActionWebReleaseNotes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebReleaseNotes, "ActionWebReleaseNotes");
      this.ActionWebReleaseNotes.Name = "ActionWebReleaseNotes";
      this.ActionWebReleaseNotes.Click += new System.EventHandler(this.ActionWebReleaseNotes_Click);
      // 
      // ActionWebCheckUpdate
      // 
      this.ActionWebCheckUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebCheckUpdate, "ActionWebCheckUpdate");
      this.ActionWebCheckUpdate.Name = "ActionWebCheckUpdate";
      this.ActionWebCheckUpdate.Click += new System.EventHandler(this.ActionCheckUpdate_Click);
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
      // 
      // ActionCreateGitHubIssue
      // 
      this.ActionCreateGitHubIssue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionCreateGitHubIssue, "ActionCreateGitHubIssue");
      this.ActionCreateGitHubIssue.Name = "ActionCreateGitHubIssue";
      this.ActionCreateGitHubIssue.Tag = "";
      this.ActionCreateGitHubIssue.Click += new System.EventHandler(this.ActionCreateGitHubIssue_Click);
      // 
      // ActionWebQA
      // 
      resources.ApplyResources(this.ActionWebQA, "ActionWebQA");
      this.ActionWebQA.Name = "ActionWebQA";
      this.ActionWebQA.Tag = "http://asherhaimhalevi.free-bb.fr/";
      this.ActionWebQA.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
      // 
      // ActionWebHome
      // 
      this.ActionWebHome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebHome, "ActionWebHome");
      this.ActionWebHome.Name = "ActionWebHome";
      this.ActionWebHome.Click += new System.EventHandler(this.ActionApplicationHome_Click);
      // 
      // ActionWebContact
      // 
      this.ActionWebContact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebContact, "ActionWebContact");
      this.ActionWebContact.Name = "ActionWebContact";
      this.ActionWebContact.Click += new System.EventHandler(this.ActionContact_Click);
      // 
      // ActionWebTipeee
      // 
      this.ActionWebTipeee.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebTipeee, "ActionWebTipeee");
      this.ActionWebTipeee.Name = "ActionWebTipeee";
      this.ActionWebTipeee.Tag = "https://fr.tipeee.com/ordisoftware";
      this.ActionWebTipeee.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // ActionWebLinkedIn
      // 
      this.ActionWebLinkedIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebLinkedIn, "ActionWebLinkedIn");
      this.ActionWebLinkedIn.Name = "ActionWebLinkedIn";
      this.ActionWebLinkedIn.Tag = "https://www.linkedin.com/in/ordisoftware";
      this.ActionWebLinkedIn.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionWebTwitter
      // 
      this.ActionWebTwitter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebTwitter, "ActionWebTwitter");
      this.ActionWebTwitter.Name = "ActionWebTwitter";
      this.ActionWebTwitter.Tag = "https://twitter.com/ordisoftware";
      this.ActionWebTwitter.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionWebYouTube
      // 
      this.ActionWebYouTube.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionWebYouTube, "ActionWebYouTube");
      this.ActionWebYouTube.Name = "ActionWebYouTube";
      this.ActionWebYouTube.Tag = "https://www.youtube.com/user/Ordisoftware";
      this.ActionWebYouTube.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // ActionDownloadHebrewLetters
      // 
      resources.ApplyResources(this.ActionDownloadHebrewLetters, "ActionDownloadHebrewLetters");
      this.ActionDownloadHebrewLetters.Name = "ActionDownloadHebrewLetters";
      this.ActionDownloadHebrewLetters.Tag = "https://www.ordisoftware.com/projects/hebrew-letters";
      this.ActionDownloadHebrewLetters.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionDownloadHebrewWords
      // 
      resources.ApplyResources(this.ActionDownloadHebrewWords, "ActionDownloadHebrewWords");
      this.ActionDownloadHebrewWords.Name = "ActionDownloadHebrewWords";
      this.ActionDownloadHebrewWords.Tag = "https://www.ordisoftware.com/projects/hebrew-words";
      this.ActionDownloadHebrewWords.Click += new System.EventHandler(this.ActionOpenWebsiteURL_Click);
      // 
      // ActionResetReminder
      // 
      this.ActionResetReminder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionResetReminder, "ActionResetReminder");
      this.ActionResetReminder.Name = "ActionResetReminder";
      this.ActionResetReminder.Padding = new System.Windows.Forms.Padding(5);
      this.ActionResetReminder.Click += new System.EventHandler(this.MenuRefreshReminder_Click);
      this.ActionResetReminder.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionResetReminder.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionDisableReminder
      // 
      this.ActionDisableReminder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionDisableReminder, "ActionDisableReminder");
      this.ActionDisableReminder.Name = "ActionDisableReminder";
      this.ActionDisableReminder.Padding = new System.Windows.Forms.Padding(5);
      this.ActionDisableReminder.Click += new System.EventHandler(this.MenuDisableReminder_Click);
      this.ActionDisableReminder.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionDisableReminder.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionEnableReminder
      // 
      this.ActionEnableReminder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionEnableReminder, "ActionEnableReminder");
      this.ActionEnableReminder.Name = "ActionEnableReminder";
      this.ActionEnableReminder.Padding = new System.Windows.Forms.Padding(5);
      this.ActionEnableReminder.Click += new System.EventHandler(this.MenuEnableReminder_Click);
      this.ActionEnableReminder.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionEnableReminder.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
      // 
      // ActionTools
      // 
      this.ActionTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionViewMoonMonths,
            this.toolStripSeparator1,
            this.ActionShowCelebrationsNotice,
            this.ActionShowShabatNotice,
            this.toolStripSeparator8,
            this.ActionCalculateDateDiff,
            this.ActionOpenCalculator,
            this.ActionOpenSystemDateAndTime,
            this.toolStripMenuItem1,
            this.ActionGenerate});
      resources.ApplyResources(this.ActionTools, "ActionTools");
      this.ActionTools.Name = "ActionTools";
      // 
      // ActionViewMoonMonths
      // 
      resources.ApplyResources(this.ActionViewMoonMonths, "ActionViewMoonMonths");
      this.ActionViewMoonMonths.Name = "ActionViewMoonMonths";
      this.ActionViewMoonMonths.Click += new System.EventHandler(this.ActionViewMoonMonths_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // ActionShowCelebrationsNotice
      // 
      resources.ApplyResources(this.ActionShowCelebrationsNotice, "ActionShowCelebrationsNotice");
      this.ActionShowCelebrationsNotice.Name = "ActionShowCelebrationsNotice";
      this.ActionShowCelebrationsNotice.Click += new System.EventHandler(this.ActionShowCelebrationsNotice_Click);
      // 
      // ActionShowShabatNotice
      // 
      resources.ApplyResources(this.ActionShowShabatNotice, "ActionShowShabatNotice");
      this.ActionShowShabatNotice.Name = "ActionShowShabatNotice";
      this.ActionShowShabatNotice.Click += new System.EventHandler(this.ActionShowShabatNotice_Click);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
      // 
      // ActionCalculateDateDiff
      // 
      resources.ApplyResources(this.ActionCalculateDateDiff, "ActionCalculateDateDiff");
      this.ActionCalculateDateDiff.Name = "ActionCalculateDateDiff";
      this.ActionCalculateDateDiff.Click += new System.EventHandler(this.ActionCalculateDateDiff_Click);
      // 
      // ActionOpenCalculator
      // 
      this.ActionOpenCalculator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionOpenCalculator, "ActionOpenCalculator");
      this.ActionOpenCalculator.Name = "ActionOpenCalculator";
      this.ActionOpenCalculator.Click += new System.EventHandler(this.ActionOpenCalculator_Click);
      // 
      // ActionOpenSystemDateAndTime
      // 
      this.ActionOpenSystemDateAndTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionOpenSystemDateAndTime, "ActionOpenSystemDateAndTime");
      this.ActionOpenSystemDateAndTime.Name = "ActionOpenSystemDateAndTime";
      this.ActionOpenSystemDateAndTime.Click += new System.EventHandler(this.ActionOpenSystemDateAndTime_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
      // 
      // ActionGenerate
      // 
      resources.ApplyResources(this.ActionGenerate, "ActionGenerate");
      this.ActionGenerate.Name = "ActionGenerate";
      this.ActionGenerate.Click += new System.EventHandler(this.ActionGenerate_Click);
      // 
      // ActionWebLinks
      // 
      this.ActionWebLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionWebLinks, "ActionWebLinks");
      this.ActionWebLinks.Name = "ActionWebLinks";
      // 
      // Sep6
      // 
      this.Sep6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep6.Name = "Sep6";
      resources.ApplyResources(this.Sep6, "Sep6");
      // 
      // ActionPreferences
      // 
      this.ActionPreferences.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionPreferences, "ActionPreferences");
      this.ActionPreferences.Name = "ActionPreferences";
      this.ActionPreferences.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      this.ActionPreferences.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.ActionPreferences.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // ActionSettings
      // 
      this.ActionSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuitemScreenPosition,
            this.ActionResetWinSettings,
            this.Sep7,
            this.EditShowTips,
            this.EditESCtoExit,
            this.EditConfirmClosing});
      resources.ApplyResources(this.ActionSettings, "ActionSettings");
      this.ActionSettings.Name = "ActionSettings";
      // 
      // MenuitemScreenPosition
      // 
      this.MenuitemScreenPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditScreenNone,
            this.EditScreenTopLeft,
            this.EditScreenTopRight,
            this.EditScreenBottomLeft,
            this.EditScreenBottomRight,
            this.EditScreenCenter});
      resources.ApplyResources(this.MenuitemScreenPosition, "MenuitemScreenPosition");
      this.MenuitemScreenPosition.Name = "MenuitemScreenPosition";
      // 
      // EditScreenNone
      // 
      this.EditScreenNone.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenNone, "EditScreenNone");
      this.EditScreenNone.Name = "EditScreenNone";
      this.EditScreenNone.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopLeft
      // 
      this.EditScreenTopLeft.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenTopLeft, "EditScreenTopLeft");
      this.EditScreenTopLeft.Name = "EditScreenTopLeft";
      this.EditScreenTopLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenTopRight
      // 
      this.EditScreenTopRight.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenTopRight, "EditScreenTopRight");
      this.EditScreenTopRight.Name = "EditScreenTopRight";
      this.EditScreenTopRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomLeft
      // 
      this.EditScreenBottomLeft.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenBottomLeft, "EditScreenBottomLeft");
      this.EditScreenBottomLeft.Name = "EditScreenBottomLeft";
      this.EditScreenBottomLeft.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenBottomRight
      // 
      this.EditScreenBottomRight.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenBottomRight, "EditScreenBottomRight");
      this.EditScreenBottomRight.Name = "EditScreenBottomRight";
      this.EditScreenBottomRight.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // EditScreenCenter
      // 
      this.EditScreenCenter.CheckOnClick = true;
      resources.ApplyResources(this.EditScreenCenter, "EditScreenCenter");
      this.EditScreenCenter.Name = "EditScreenCenter";
      this.EditScreenCenter.Click += new System.EventHandler(this.EditScreenPosition_Click);
      // 
      // ActionResetWinSettings
      // 
      resources.ApplyResources(this.ActionResetWinSettings, "ActionResetWinSettings");
      this.ActionResetWinSettings.Name = "ActionResetWinSettings";
      this.ActionResetWinSettings.Click += new System.EventHandler(this.ActionResetWinSettings_Click);
      // 
      // Sep7
      // 
      this.Sep7.Name = "Sep7";
      resources.ApplyResources(this.Sep7, "Sep7");
      // 
      // EditShowTips
      // 
      this.EditShowTips.Checked = true;
      this.EditShowTips.CheckOnClick = true;
      this.EditShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditShowTips, "EditShowTips");
      this.EditShowTips.Name = "EditShowTips";
      // 
      // EditESCtoExit
      // 
      this.EditESCtoExit.Checked = true;
      this.EditESCtoExit.CheckOnClick = true;
      this.EditESCtoExit.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditESCtoExit, "EditESCtoExit");
      this.EditESCtoExit.Name = "EditESCtoExit";
      // 
      // EditConfirmClosing
      // 
      resources.ApplyResources(this.EditConfirmClosing, "EditConfirmClosing");
      this.EditConfirmClosing.Checked = true;
      this.EditConfirmClosing.CheckOnClick = true;
      this.EditConfirmClosing.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditConfirmClosing.Name = "EditConfirmClosing";
      // 
      // ActionView
      // 
      this.ActionView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionViewReport,
            this.ActionViewMonth,
            this.ActionViewGrid});
      resources.ApplyResources(this.ActionView, "ActionView");
      this.ActionView.Name = "ActionView";
      // 
      // ActionViewReport
      // 
      this.ActionViewReport.CheckOnClick = true;
      resources.ApplyResources(this.ActionViewReport, "ActionViewReport");
      this.ActionViewReport.Name = "ActionViewReport";
      this.ActionViewReport.Click += new System.EventHandler(this.ActionViewReport_Click);
      // 
      // ActionViewMonth
      // 
      resources.ApplyResources(this.ActionViewMonth, "ActionViewMonth");
      this.ActionViewMonth.Name = "ActionViewMonth";
      this.ActionViewMonth.Click += new System.EventHandler(this.ActionViewMonth_Click);
      // 
      // ActionViewGrid
      // 
      this.ActionViewGrid.CheckOnClick = true;
      resources.ApplyResources(this.ActionViewGrid, "ActionViewGrid");
      this.ActionViewGrid.Name = "ActionViewGrid";
      this.ActionViewGrid.Click += new System.EventHandler(this.ActionViewGrid_Click);
      // 
      // SaveCSVDialog
      // 
      this.SaveCSVDialog.FileName = "Hebrew Calendar.csv";
      resources.ApplyResources(this.SaveCSVDialog, "SaveCSVDialog");
      // 
      // TrayIcon
      // 
      this.TrayIcon.ContextMenuStrip = this.MenuTray;
      resources.ApplyResources(this.TrayIcon, "TrayIcon");
      this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
      this.TrayIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseMove);
      // 
      // MenuTray
      // 
      this.MenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuShowHide,
            this.SeparatorTrayMenu1,
            this.MenuNavigate,
            this.MenuCelebrations,
            this.SeparatorTrayMenu3,
            this.MenuResetReminder,
            this.MenuEnableReminder,
            this.MenuDisableReminder,
            this.SeparatorTrayMenu2,
            this.MenuTools,
            this.MenuWebLinks,
            this.MenuInformation,
            this.SeparatorTrayMenu5,
            this.MenuPreferences,
            this.MenuExit});
      this.MenuTray.Name = "contextMenuStrip";
      resources.ApplyResources(this.MenuTray, "MenuTray");
      this.MenuTray.VisibleChanged += new System.EventHandler(this.MenuTray_VisibleChanged);
      // 
      // MenuShowHide
      // 
      resources.ApplyResources(this.MenuShowHide, "MenuShowHide");
      this.MenuShowHide.Name = "MenuShowHide";
      this.MenuShowHide.Click += new System.EventHandler(this.MenuShowHide_Click);
      // 
      // SeparatorTrayMenu1
      // 
      this.SeparatorTrayMenu1.Name = "SeparatorTrayMenu1";
      resources.ApplyResources(this.SeparatorTrayMenu1, "SeparatorTrayMenu1");
      // 
      // MenuNavigate
      // 
      resources.ApplyResources(this.MenuNavigate, "MenuNavigate");
      this.MenuNavigate.Name = "MenuNavigate";
      this.MenuNavigate.Click += new System.EventHandler(this.ActionNavigate_Click);
      // 
      // MenuCelebrations
      // 
      resources.ApplyResources(this.MenuCelebrations, "MenuCelebrations");
      this.MenuCelebrations.Name = "MenuCelebrations";
      this.MenuCelebrations.Click += new System.EventHandler(this.ActionViewCelebrations_Click);
      // 
      // SeparatorTrayMenu3
      // 
      this.SeparatorTrayMenu3.Name = "SeparatorTrayMenu3";
      resources.ApplyResources(this.SeparatorTrayMenu3, "SeparatorTrayMenu3");
      // 
      // MenuResetReminder
      // 
      resources.ApplyResources(this.MenuResetReminder, "MenuResetReminder");
      this.MenuResetReminder.Name = "MenuResetReminder";
      this.MenuResetReminder.Click += new System.EventHandler(this.MenuRefreshReminder_Click);
      // 
      // MenuEnableReminder
      // 
      resources.ApplyResources(this.MenuEnableReminder, "MenuEnableReminder");
      this.MenuEnableReminder.Name = "MenuEnableReminder";
      this.MenuEnableReminder.Click += new System.EventHandler(this.MenuEnableReminder_Click);
      // 
      // MenuDisableReminder
      // 
      resources.ApplyResources(this.MenuDisableReminder, "MenuDisableReminder");
      this.MenuDisableReminder.Name = "MenuDisableReminder";
      this.MenuDisableReminder.Click += new System.EventHandler(this.MenuDisableReminder_Click);
      // 
      // SeparatorTrayMenu2
      // 
      this.SeparatorTrayMenu2.Name = "SeparatorTrayMenu2";
      resources.ApplyResources(this.SeparatorTrayMenu2, "SeparatorTrayMenu2");
      // 
      // MenuTools
      // 
      resources.ApplyResources(this.MenuTools, "MenuTools");
      this.MenuTools.Name = "MenuTools";
      // 
      // MenuWebLinks
      // 
      resources.ApplyResources(this.MenuWebLinks, "MenuWebLinks");
      this.MenuWebLinks.Name = "MenuWebLinks";
      // 
      // MenuInformation
      // 
      resources.ApplyResources(this.MenuInformation, "MenuInformation");
      this.MenuInformation.Name = "MenuInformation";
      // 
      // SeparatorTrayMenu5
      // 
      this.SeparatorTrayMenu5.Name = "SeparatorTrayMenu5";
      resources.ApplyResources(this.SeparatorTrayMenu5, "SeparatorTrayMenu5");
      // 
      // MenuPreferences
      // 
      resources.ApplyResources(this.MenuPreferences, "MenuPreferences");
      this.MenuPreferences.Name = "MenuPreferences";
      this.MenuPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      // 
      // MenuExit
      // 
      resources.ApplyResources(this.MenuExit, "MenuExit");
      this.MenuExit.Name = "MenuExit";
      this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
      // 
      // PrintDialog
      // 
      this.PrintDialog.UseEXDialog = true;
      // 
      // TimerReminder
      // 
      this.TimerReminder.Interval = 60000;
      this.TimerReminder.Tick += new System.EventHandler(this.TimerReminder_Tick);
      // 
      // TimerBallon
      // 
      this.TimerBallon.Interval = 1000;
      this.TimerBallon.Tick += new System.EventHandler(this.TimerBallon_Tick);
      // 
      // TimerTrayMouseMove
      // 
      this.TimerTrayMouseMove.Interval = 10;
      this.TimerTrayMouseMove.Tick += new System.EventHandler(this.TimerTrayMouseMove_Tick);
      // 
      // TimerResumeReminder
      // 
      this.TimerResumeReminder.Tick += new System.EventHandler(this.TimerResumeReminder_Tick);
      // 
      // CalendarMonth
      // 
      this.CalendarMonth.AllowEditingEvents = false;
      this.CalendarMonth.BackColor = System.Drawing.Color.White;
      this.CalendarMonth.CalendarDate = new System.DateTime(2019, 1, 19, 13, 27, 20, 916);
      this.CalendarMonth.CalendarView = Calendar.NET.CalendarViews.Month;
      this.CalendarMonth.DateHeaderFont = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CalendarMonth.DayOfWeekFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CalendarMonth.DaysFont = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CalendarMonth.DayViewTimeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CalendarMonth.DimDisabledEvents = true;
      resources.ApplyResources(this.CalendarMonth, "CalendarMonth");
      this.CalendarMonth.HighlightCurrentDay = false;
      this.CalendarMonth.LoadPresetHolidays = false;
      this.CalendarMonth.Name = "CalendarMonth";
      this.CalendarMonth.ShowArrowControls = true;
      this.CalendarMonth.ShowDashedBorderOnDisabledEvents = true;
      this.CalendarMonth.ShowDateInHeader = true;
      this.CalendarMonth.ShowDisabledEvents = false;
      this.CalendarMonth.ShowEventTooltips = true;
      this.CalendarMonth.ShowTodayButton = true;
      this.CalendarMonth.TodayFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
      resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "LunarMonth";
      resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "LunarDay";
      resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.ReadOnly = true;
      this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "Sunrise";
      resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Sunset";
      resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "Moonrise";
      resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn6.ReadOnly = true;
      this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Moonset";
      resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn8
      // 
      this.dataGridViewTextBoxColumn8.DataPropertyName = "MoonriseType";
      resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      this.dataGridViewTextBoxColumn8.ReadOnly = true;
      this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn9
      // 
      this.dataGridViewTextBoxColumn9.DataPropertyName = "IsNewMoon";
      resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      this.dataGridViewTextBoxColumn9.ReadOnly = true;
      this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn10
      // 
      this.dataGridViewTextBoxColumn10.DataPropertyName = "IsFullMoon";
      resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      this.dataGridViewTextBoxColumn10.ReadOnly = true;
      this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn11
      // 
      this.dataGridViewTextBoxColumn11.DataPropertyName = "MoonPhase";
      resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
      this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
      this.dataGridViewTextBoxColumn11.ReadOnly = true;
      this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn12
      // 
      this.dataGridViewTextBoxColumn12.DataPropertyName = "SeasonChange";
      resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
      this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
      this.dataGridViewTextBoxColumn12.ReadOnly = true;
      this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn13
      // 
      this.dataGridViewTextBoxColumn13.DataPropertyName = "TorahEvents";
      resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
      this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
      this.dataGridViewTextBoxColumn13.ReadOnly = true;
      this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // LunisolarDaysBindingSource
      // 
      this.LunisolarDaysBindingSource.DataMember = "LunisolarDays";
      this.LunisolarDaysBindingSource.DataSource = this.DataSet;
      this.LunisolarDaysBindingSource.CurrentItemChanged += new System.EventHandler(this.LunisolarDaysBindingSource_CurrentItemChanged);
      // 
      // DataSet
      // 
      this.DataSet.DataSetName = "DataSet";
      this.DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // LunisolarDaysTableAdapter
      // 
      this.LunisolarDaysTableAdapter.ClearBeforeFill = true;
      // 
      // TableAdapterManager
      // 
      this.TableAdapterManager.BackupDataSetBeforeUpdate = false;
      this.TableAdapterManager.LunisolarDaysTableAdapter = this.LunisolarDaysTableAdapter;
      this.TableAdapterManager.ReportTableAdapter = this.ReportTableAdapter;
      this.TableAdapterManager.UpdateOrder = Ordisoftware.HebrewCalendar.Data.DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
      // 
      // ReportTableAdapter
      // 
      this.ReportTableAdapter.ClearBeforeFill = true;
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.ToolStrip);
      this.Name = "MainForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.ClientSizeChanged += new System.EventHandler(this.MainForm_WindowsChanged);
      this.LocationChanged += new System.EventHandler(this.MainForm_WindowsChanged);
      this.PanelMain.ResumeLayout(false);
      this.PanelCalendarOuter.ResumeLayout(false);
      this.PanelCalendarInner.ResumeLayout(false);
      this.PanelCalendar.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.TabPageText.ResumeLayout(false);
      this.PanelViewText.ResumeLayout(false);
      this.TabPageMonth.ResumeLayout(false);
      this.PanelViewMonth.ResumeLayout(false);
      this.TabPageGrid.ResumeLayout(false);
      this.PanelViewGrid.ResumeLayout(false);
      this.PanelViewGrid.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CalendarGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingNavigator)).EndInit();
      this.LunisolarDaysBindingNavigator.ResumeLayout(false);
      this.LunisolarDaysBindingNavigator.PerformLayout();
      this.PanelTitle.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).EndInit();
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.MenuTray.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.ToolStripButton ActionExit;
    private System.Windows.Forms.ToolStripSeparator Sep4;
    private System.Windows.Forms.ToolStripDropDownButton ActionSettings;
    private System.Windows.Forms.ToolStripMenuItem MenuitemScreenPosition;
    private System.Windows.Forms.ToolStripButton ActionHelp;
    private System.Windows.Forms.ToolStripSeparator Sep7;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenNone;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenCenter;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenTopLeft;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenTopRight;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenBottomLeft;
    internal System.Windows.Forms.ToolStripMenuItem EditScreenBottomRight;
    internal System.Windows.Forms.ToolStripMenuItem EditConfirmClosing;
    internal System.Windows.Forms.ToolStripMenuItem EditESCtoExit;
    internal System.Windows.Forms.ToolStripMenuItem EditShowTips;
    private System.Windows.Forms.ToolStripSeparator Sep3;
    private System.Windows.Forms.SaveFileDialog SaveFileDialog;
    private System.Windows.Forms.ToolStripSeparator Sep6;
    private System.Windows.Forms.ToolStripButton ActionCopyReportToClipboard;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.Panel PanelSepTop;
    private System.Windows.Forms.Panel PanelTitle;
    private System.Windows.Forms.Label LabelTitle;
    private System.Windows.Forms.Panel PanelCalendarOuter;
    private System.Windows.Forms.Panel PanelCalendarInner;
    private System.Windows.Forms.ToolStripDropDownButton ActionView;
    private System.Windows.Forms.ToolStripMenuItem ActionViewReport;
    private System.Windows.Forms.ToolStripMenuItem ActionViewGrid;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageText;
    private System.Windows.Forms.Panel PanelViewText;
    internal System.Windows.Forms.RichTextBox CalendarText;
    private System.Windows.Forms.TabPage TabPageGrid;
    private System.Windows.Forms.Panel PanelViewGrid;
    private System.Windows.Forms.PictureBox moonPhaseImagePictureBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel PanelCalendar;
    private System.Windows.Forms.Timer TimerTooltip;
    private Data.DataSetTableAdapters.LunisolarDaysTableAdapter LunisolarDaysTableAdapter;
    private Data.DataSetTableAdapters.TableAdapterManager TableAdapterManager;
    private System.Windows.Forms.BindingSource LunisolarDaysBindingSource;
    private System.Windows.Forms.BindingNavigator LunisolarDaysBindingNavigator;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    private System.Windows.Forms.DataGridView CalendarGrid;
    internal Data.DataSet DataSet;
    private System.Windows.Forms.ToolStripButton ActionSaveReport;
    private System.Windows.Forms.ToolStripButton ActionSearchDay;
    private System.Windows.Forms.ToolStripButton ActionPreferences;
    private System.Windows.Forms.ToolStripButton ActionExportCSV;
    private System.Windows.Forms.ToolStripSeparator Sep2;
    private System.Windows.Forms.SaveFileDialog SaveCSVDialog;
    private Data.DataSetTableAdapters.ReportTableAdapter ReportTableAdapter;
    private System.Windows.Forms.ToolStripButton ActionNavigate;
    private System.Windows.Forms.ToolStripButton ActionViewCelebrations;
    private System.Windows.Forms.NotifyIcon TrayIcon;
    internal System.Windows.Forms.ToolStripMenuItem MenuShowHide;
    private System.Windows.Forms.ToolStripMenuItem MenuNavigate;
    private System.Windows.Forms.ToolStripMenuItem MenuCelebrations;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu3;
    private System.Windows.Forms.ToolStripMenuItem MenuInformation;
    private System.Windows.Forms.ToolStripMenuItem MenuExit;
    private System.Windows.Forms.TabPage TabPageMonth;
    private System.Windows.Forms.ToolStripMenuItem ActionViewMonth;
    private System.Windows.Forms.ToolStripButton ActionPrint;
    private System.Windows.Forms.PrintDialog PrintDialog;
    private System.Windows.Forms.ToolStripSeparator Sep1;
    internal Calendar.NET.Calendar CalendarMonth;
    internal System.Windows.Forms.Panel PanelViewMonth;
    private System.Windows.Forms.Timer TimerBallon;
    private System.Windows.Forms.Timer TimerTrayMouseMove;
    private System.Windows.Forms.ToolStripDropDownButton ActionInformation;
    private System.Windows.Forms.ToolStripMenuItem ActionWebHome;
    private System.Windows.Forms.ToolStripMenuItem ActionWebContact;
    private System.Windows.Forms.ToolStripMenuItem ActionCreateGitHubIssue;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem ActionWebCheckUpdate;
    internal System.Windows.Forms.Timer TimerReminder;
    private System.Windows.Forms.ToolStripMenuItem MenuPreferences;
    private System.Windows.Forms.ToolStripButton ActionSearchEvent;
    private System.Windows.Forms.ToolStripButton ActionSearchMonth;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem ActionDownloadHebrewWords;
    private System.Windows.Forms.ToolStripMenuItem ActionResetWinSettings;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu2;
    private System.Windows.Forms.ToolStripMenuItem MenuResetReminder;
    internal System.Windows.Forms.ToolStripMenuItem MenuEnableReminder;
    internal System.Windows.Forms.ToolStripMenuItem MenuDisableReminder;
    private System.Windows.Forms.ToolStripButton ActionResetReminder;
    private System.Windows.Forms.ToolStripButton ActionEnableReminder;
    private System.Windows.Forms.ToolStripButton ActionDisableReminder;
    private System.Windows.Forms.ToolStripDropDownButton ActionTools;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenCalculator;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripMenuItem ActionCalculateDateDiff;
    private System.Windows.Forms.ToolStripMenuItem ActionViewMoonMonths;
    internal System.Windows.Forms.ToolStripMenuItem ActionDownloadHebrewLetters;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu1;
    internal System.Windows.Forms.ContextMenuStrip MenuTray;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
    internal System.Windows.Forms.ToolStripMenuItem ActionShowShabatNotice;
    internal System.Windows.Forms.ToolStripMenuItem ActionShowCelebrationsNotice;
    private System.Windows.Forms.ToolStripMenuItem ActionWebTwitter;
    private System.Windows.Forms.ToolStripMenuItem ActionWebYouTube;
    private System.Windows.Forms.ToolStripMenuItem ActionWebTipeee;
    private System.Windows.Forms.ToolStripMenuItem ActionWebLinkedIn;
    private System.Windows.Forms.ToolStripMenuItem ActionAbout;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    private System.Windows.Forms.ToolStripDropDownButton ActionWebLinks;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem ActionWebQA;
    private System.Windows.Forms.ToolStripMenuItem ActionGenerate;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.Timer TimerResumeReminder;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    private System.Windows.Forms.ToolStripMenuItem MenuWebLinks;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenSystemDateAndTime;
    private System.Windows.Forms.ToolStripMenuItem ActionWebReleaseNotes;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu5;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripMenuItem MenuTools;
  }
}


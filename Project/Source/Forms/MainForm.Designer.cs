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
      this.statusBottom = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.panelMain = new System.Windows.Forms.Panel();
      this.panelCalendarOuter = new System.Windows.Forms.Panel();
      this.panelCalendarInner = new System.Windows.Forms.Panel();
      this.panelCalendar = new System.Windows.Forms.Panel();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabPageText = new System.Windows.Forms.TabPage();
      this.panelViewText = new System.Windows.Forms.Panel();
      this.calendarText = new System.Windows.Forms.RichTextBox();
      this.tabPageGrid = new System.Windows.Forms.TabPage();
      this.panelViewGrid = new System.Windows.Forms.Panel();
      this.calendarGrid = new System.Windows.Forms.DataGridView();
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
      this.lunisolarDaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.lunisolarCalendar = new Ordisoftware.HebrewCalendar.Data.LunisolarCalendar();
      this.lunisolarDaysBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
      this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.panelSepBottom = new System.Windows.Forms.Panel();
      this.panelSepTop = new System.Windows.Forms.Panel();
      this.panelProgress = new System.Windows.Forms.Panel();
      this.barProgress = new System.Windows.Forms.ProgressBar();
      this.panelTitle = new System.Windows.Forms.Panel();
      this.labelTitle = new System.Windows.Forms.Label();
      this.moonPhaseImagePictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.timerTooltip = new System.Windows.Forms.Timer(this.components);
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.sep2 = new System.Windows.Forms.ToolStripSeparator();
      this.actionSaveReport = new System.Windows.Forms.ToolStripButton();
      this.actionCopyReportToClipboard = new System.Windows.Forms.ToolStripButton();
      this.actionFindDay = new System.Windows.Forms.ToolStripButton();
      this.sep3 = new System.Windows.Forms.ToolStripSeparator();
      this.actionGenerate = new System.Windows.Forms.ToolStripButton();
      this.actionExit = new System.Windows.Forms.ToolStripButton();
      this.sep4 = new System.Windows.Forms.ToolStripSeparator();
      this.actionContact = new System.Windows.Forms.ToolStripButton();
      this.actionWebsite = new System.Windows.Forms.ToolStripButton();
      this.sep5 = new System.Windows.Forms.ToolStripSeparator();
      this.actionHelp = new System.Windows.Forms.ToolStripButton();
      this.actionAbout = new System.Windows.Forms.ToolStripButton();
      this.sep6 = new System.Windows.Forms.ToolStripSeparator();
      this.actionPreferences = new System.Windows.Forms.ToolStripButton();
      this.menuSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.menuitemScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
      this.editScreenNone = new System.Windows.Forms.ToolStripMenuItem();
      this.editScreenTopLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.editScreenTopRight = new System.Windows.Forms.ToolStripMenuItem();
      this.editScreenBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
      this.editScreenBottomRight = new System.Windows.Forms.ToolStripMenuItem();
      this.editScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
      this.actionResetWinSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.sep7 = new System.Windows.Forms.ToolStripSeparator();
      this.editShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.editESCtoExit = new System.Windows.Forms.ToolStripMenuItem();
      this.editConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.menuView = new System.Windows.Forms.ToolStripDropDownButton();
      this.actionViewText = new System.Windows.Forms.ToolStripMenuItem();
      this.actionViewGrid = new System.Windows.Forms.ToolStripMenuItem();
      this.actionStop = new System.Windows.Forms.ToolStripButton();
      this.lunisolarDaysTableAdapter = new Ordisoftware.HebrewCalendar.Data.LunisolarCalendarTableAdapters.LunisolarDaysTableAdapter();
      this.tableAdapterManager = new Ordisoftware.HebrewCalendar.Data.LunisolarCalendarTableAdapters.TableAdapterManager();
      this.statusBottom.SuspendLayout();
      this.panelMain.SuspendLayout();
      this.panelCalendarOuter.SuspendLayout();
      this.panelCalendarInner.SuspendLayout();
      this.panelCalendar.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tabPageText.SuspendLayout();
      this.panelViewText.SuspendLayout();
      this.tabPageGrid.SuspendLayout();
      this.panelViewGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.calendarGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lunisolarDaysBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lunisolarCalendar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lunisolarDaysBindingNavigator)).BeginInit();
      this.lunisolarDaysBindingNavigator.SuspendLayout();
      this.panelProgress.SuspendLayout();
      this.panelTitle.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).BeginInit();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusBottom
      // 
      this.statusBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labelStatus});
      resources.ApplyResources(this.statusBottom, "statusBottom");
      this.statusBottom.Name = "statusBottom";
      // 
      // toolStripStatusLabel1
      // 
      resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      // 
      // labelStatus
      // 
      this.labelStatus.Name = "labelStatus";
      resources.ApplyResources(this.labelStatus, "labelStatus");
      // 
      // saveFileDialog
      // 
      resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
      // 
      // panelMain
      // 
      this.panelMain.Controls.Add(this.panelCalendarOuter);
      this.panelMain.Controls.Add(this.panelSepBottom);
      this.panelMain.Controls.Add(this.panelSepTop);
      this.panelMain.Controls.Add(this.panelProgress);
      this.panelMain.Controls.Add(this.panelTitle);
      resources.ApplyResources(this.panelMain, "panelMain");
      this.panelMain.Name = "panelMain";
      // 
      // panelCalendarOuter
      // 
      this.panelCalendarOuter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.panelCalendarOuter.Controls.Add(this.panelCalendarInner);
      resources.ApplyResources(this.panelCalendarOuter, "panelCalendarOuter");
      this.panelCalendarOuter.Name = "panelCalendarOuter";
      // 
      // panelCalendarInner
      // 
      this.panelCalendarInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.panelCalendarInner.Controls.Add(this.panelCalendar);
      resources.ApplyResources(this.panelCalendarInner, "panelCalendarInner");
      this.panelCalendarInner.Name = "panelCalendarInner";
      // 
      // panelCalendar
      // 
      this.panelCalendar.Controls.Add(this.tabControl);
      resources.ApplyResources(this.panelCalendar, "panelCalendar");
      this.panelCalendar.Name = "panelCalendar";
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tabPageText);
      this.tabControl.Controls.Add(this.tabPageGrid);
      resources.ApplyResources(this.tabControl, "tabControl");
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.TabStop = false;
      // 
      // tabPageText
      // 
      this.tabPageText.Controls.Add(this.panelViewText);
      resources.ApplyResources(this.tabPageText, "tabPageText");
      this.tabPageText.Name = "tabPageText";
      this.tabPageText.UseVisualStyleBackColor = true;
      // 
      // panelViewText
      // 
      this.panelViewText.Controls.Add(this.calendarText);
      resources.ApplyResources(this.panelViewText, "panelViewText");
      this.panelViewText.Name = "panelViewText";
      // 
      // calendarText
      // 
      this.calendarText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.calendarText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      resources.ApplyResources(this.calendarText, "calendarText");
      this.calendarText.Name = "calendarText";
      this.calendarText.ReadOnly = true;
      // 
      // tabPageGrid
      // 
      this.tabPageGrid.Controls.Add(this.panelViewGrid);
      resources.ApplyResources(this.tabPageGrid, "tabPageGrid");
      this.tabPageGrid.Name = "tabPageGrid";
      this.tabPageGrid.UseVisualStyleBackColor = true;
      // 
      // panelViewGrid
      // 
      this.panelViewGrid.Controls.Add(this.calendarGrid);
      this.panelViewGrid.Controls.Add(this.lunisolarDaysBindingNavigator);
      resources.ApplyResources(this.panelViewGrid, "panelViewGrid");
      this.panelViewGrid.Name = "panelViewGrid";
      // 
      // calendarGrid
      // 
      this.calendarGrid.AutoGenerateColumns = false;
      this.calendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.calendarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
      this.calendarGrid.DataSource = this.lunisolarDaysBindingSource;
      resources.ApplyResources(this.calendarGrid, "calendarGrid");
      this.calendarGrid.Name = "calendarGrid";
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
      resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "LunarMonth";
      resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "LunarDay";
      resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "Sunrise";
      resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Sunset";
      resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "Moonrise";
      resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Moonset";
      resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      // 
      // dataGridViewTextBoxColumn8
      // 
      this.dataGridViewTextBoxColumn8.DataPropertyName = "MoonriseType";
      resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      // 
      // dataGridViewTextBoxColumn9
      // 
      this.dataGridViewTextBoxColumn9.DataPropertyName = "IsNewMoon";
      resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      // 
      // dataGridViewTextBoxColumn10
      // 
      this.dataGridViewTextBoxColumn10.DataPropertyName = "IsFullMoon";
      resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      // 
      // dataGridViewTextBoxColumn11
      // 
      this.dataGridViewTextBoxColumn11.DataPropertyName = "MoonPhase";
      resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
      this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
      // 
      // dataGridViewTextBoxColumn12
      // 
      this.dataGridViewTextBoxColumn12.DataPropertyName = "SeasonChange";
      resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
      this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
      // 
      // dataGridViewTextBoxColumn13
      // 
      this.dataGridViewTextBoxColumn13.DataPropertyName = "TorahEvents";
      resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
      this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
      // 
      // lunisolarDaysBindingSource
      // 
      this.lunisolarDaysBindingSource.DataMember = "LunisolarDays";
      this.lunisolarDaysBindingSource.DataSource = this.lunisolarCalendar;
      // 
      // lunisolarCalendar
      // 
      this.lunisolarCalendar.DataSetName = "LunisolarCalendar";
      this.lunisolarCalendar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // lunisolarDaysBindingNavigator
      // 
      this.lunisolarDaysBindingNavigator.AddNewItem = null;
      this.lunisolarDaysBindingNavigator.BindingSource = this.lunisolarDaysBindingSource;
      this.lunisolarDaysBindingNavigator.CountItem = this.bindingNavigatorCountItem;
      this.lunisolarDaysBindingNavigator.DeleteItem = null;
      this.lunisolarDaysBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
      resources.ApplyResources(this.lunisolarDaysBindingNavigator, "lunisolarDaysBindingNavigator");
      this.lunisolarDaysBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
      this.lunisolarDaysBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
      this.lunisolarDaysBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
      this.lunisolarDaysBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
      this.lunisolarDaysBindingNavigator.Name = "lunisolarDaysBindingNavigator";
      this.lunisolarDaysBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
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
      // panelSepBottom
      // 
      resources.ApplyResources(this.panelSepBottom, "panelSepBottom");
      this.panelSepBottom.Name = "panelSepBottom";
      // 
      // panelSepTop
      // 
      resources.ApplyResources(this.panelSepTop, "panelSepTop");
      this.panelSepTop.Name = "panelSepTop";
      // 
      // panelProgress
      // 
      this.panelProgress.Controls.Add(this.barProgress);
      resources.ApplyResources(this.panelProgress, "panelProgress");
      this.panelProgress.Name = "panelProgress";
      // 
      // barProgress
      // 
      resources.ApplyResources(this.barProgress, "barProgress");
      this.barProgress.Name = "barProgress";
      this.barProgress.Step = 1;
      // 
      // panelTitle
      // 
      this.panelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.panelTitle.Controls.Add(this.labelTitle);
      resources.ApplyResources(this.panelTitle, "panelTitle");
      this.panelTitle.Name = "panelTitle";
      // 
      // labelTitle
      // 
      this.labelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.labelTitle, "labelTitle");
      this.labelTitle.Name = "labelTitle";
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
      // timerTooltip
      // 
      this.timerTooltip.Interval = 500;
      this.timerTooltip.Tick += new System.EventHandler(this.timerTooltip_Tick);
      // 
      // toolStrip
      // 
      resources.ApplyResources(this.toolStrip, "toolStrip");
      this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sep2,
            this.actionSaveReport,
            this.actionCopyReportToClipboard,
            this.actionFindDay,
            this.sep3,
            this.actionGenerate,
            this.actionExit,
            this.sep4,
            this.actionContact,
            this.actionWebsite,
            this.sep5,
            this.actionHelp,
            this.actionAbout,
            this.sep6,
            this.actionPreferences,
            this.menuSettings,
            this.menuView,
            this.actionStop});
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.ShowItemToolTips = false;
      // 
      // sep2
      // 
      this.sep2.Name = "sep2";
      resources.ApplyResources(this.sep2, "sep2");
      // 
      // actionSaveReport
      // 
      this.actionSaveReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionSaveReport, "actionSaveReport");
      this.actionSaveReport.Name = "actionSaveReport";
      this.actionSaveReport.Padding = new System.Windows.Forms.Padding(5);
      this.actionSaveReport.Click += new System.EventHandler(this.actionSaveReport_Click);
      this.actionSaveReport.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionSaveReport.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionCopyReportToClipboard
      // 
      this.actionCopyReportToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionCopyReportToClipboard, "actionCopyReportToClipboard");
      this.actionCopyReportToClipboard.Name = "actionCopyReportToClipboard";
      this.actionCopyReportToClipboard.Padding = new System.Windows.Forms.Padding(5);
      this.actionCopyReportToClipboard.Click += new System.EventHandler(this.actionCopyReportToClipboard_Click);
      this.actionCopyReportToClipboard.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionCopyReportToClipboard.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionFindDay
      // 
      this.actionFindDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionFindDay, "actionFindDay");
      this.actionFindDay.Name = "actionFindDay";
      this.actionFindDay.Padding = new System.Windows.Forms.Padding(5);
      this.actionFindDay.Click += new System.EventHandler(this.actionFindDay_Click);
      this.actionFindDay.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionFindDay.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep3
      // 
      this.sep3.Name = "sep3";
      resources.ApplyResources(this.sep3, "sep3");
      // 
      // actionGenerate
      // 
      this.actionGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionGenerate, "actionGenerate");
      this.actionGenerate.Name = "actionGenerate";
      this.actionGenerate.Padding = new System.Windows.Forms.Padding(5);
      this.actionGenerate.Click += new System.EventHandler(this.actionGenerate_Click);
      this.actionGenerate.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionGenerate.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionExit
      // 
      this.actionExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionExit, "actionExit");
      this.actionExit.Name = "actionExit";
      this.actionExit.Padding = new System.Windows.Forms.Padding(5);
      this.actionExit.Click += new System.EventHandler(this.actionExit_Click);
      this.actionExit.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionExit.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep4
      // 
      this.sep4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sep4.Name = "sep4";
      resources.ApplyResources(this.sep4, "sep4");
      // 
      // actionContact
      // 
      this.actionContact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionContact, "actionContact");
      this.actionContact.Name = "actionContact";
      this.actionContact.Padding = new System.Windows.Forms.Padding(5);
      this.actionContact.Click += new System.EventHandler(this.actionContact_Click);
      this.actionContact.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionContact.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionWebsite
      // 
      this.actionWebsite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionWebsite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionWebsite, "actionWebsite");
      this.actionWebsite.Name = "actionWebsite";
      this.actionWebsite.Padding = new System.Windows.Forms.Padding(5);
      this.actionWebsite.Click += new System.EventHandler(this.actionApplicationHome_Click);
      this.actionWebsite.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionWebsite.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep5
      // 
      this.sep5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sep5.Name = "sep5";
      resources.ApplyResources(this.sep5, "sep5");
      // 
      // actionHelp
      // 
      this.actionHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionHelp, "actionHelp");
      this.actionHelp.Name = "actionHelp";
      this.actionHelp.Padding = new System.Windows.Forms.Padding(5);
      this.actionHelp.Click += new System.EventHandler(this.actionHelp_Click);
      this.actionHelp.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionHelp.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionAbout
      // 
      this.actionAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionAbout, "actionAbout");
      this.actionAbout.Name = "actionAbout";
      this.actionAbout.Padding = new System.Windows.Forms.Padding(5);
      this.actionAbout.Click += new System.EventHandler(this.actionAbout_Click);
      this.actionAbout.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionAbout.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep6
      // 
      this.sep6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sep6.Name = "sep6";
      resources.ApplyResources(this.sep6, "sep6");
      // 
      // actionPreferences
      // 
      this.actionPreferences.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionPreferences, "actionPreferences");
      this.actionPreferences.Name = "actionPreferences";
      this.actionPreferences.Padding = new System.Windows.Forms.Padding(5);
      this.actionPreferences.Click += new System.EventHandler(this.actionPreferences_Click);
      this.actionPreferences.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionPreferences.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // menuSettings
      // 
      this.menuSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.menuSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemScreenPosition,
            this.actionResetWinSettings,
            this.sep7,
            this.editShowTips,
            this.editESCtoExit,
            this.editConfirmClosing});
      resources.ApplyResources(this.menuSettings, "menuSettings");
      this.menuSettings.Name = "menuSettings";
      // 
      // menuitemScreenPosition
      // 
      this.menuitemScreenPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editScreenNone,
            this.editScreenTopLeft,
            this.editScreenTopRight,
            this.editScreenBottomLeft,
            this.editScreenBottomRight,
            this.editScreenCenter});
      resources.ApplyResources(this.menuitemScreenPosition, "menuitemScreenPosition");
      this.menuitemScreenPosition.Name = "menuitemScreenPosition";
      // 
      // editScreenNone
      // 
      this.editScreenNone.CheckOnClick = true;
      resources.ApplyResources(this.editScreenNone, "editScreenNone");
      this.editScreenNone.Name = "editScreenNone";
      this.editScreenNone.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenTopLeft
      // 
      this.editScreenTopLeft.CheckOnClick = true;
      resources.ApplyResources(this.editScreenTopLeft, "editScreenTopLeft");
      this.editScreenTopLeft.Name = "editScreenTopLeft";
      this.editScreenTopLeft.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenTopRight
      // 
      this.editScreenTopRight.CheckOnClick = true;
      resources.ApplyResources(this.editScreenTopRight, "editScreenTopRight");
      this.editScreenTopRight.Name = "editScreenTopRight";
      this.editScreenTopRight.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenBottomLeft
      // 
      this.editScreenBottomLeft.CheckOnClick = true;
      resources.ApplyResources(this.editScreenBottomLeft, "editScreenBottomLeft");
      this.editScreenBottomLeft.Name = "editScreenBottomLeft";
      this.editScreenBottomLeft.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenBottomRight
      // 
      this.editScreenBottomRight.CheckOnClick = true;
      resources.ApplyResources(this.editScreenBottomRight, "editScreenBottomRight");
      this.editScreenBottomRight.Name = "editScreenBottomRight";
      this.editScreenBottomRight.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenCenter
      // 
      this.editScreenCenter.CheckOnClick = true;
      resources.ApplyResources(this.editScreenCenter, "editScreenCenter");
      this.editScreenCenter.Name = "editScreenCenter";
      this.editScreenCenter.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // actionResetWinSettings
      // 
      resources.ApplyResources(this.actionResetWinSettings, "actionResetWinSettings");
      this.actionResetWinSettings.Name = "actionResetWinSettings";
      this.actionResetWinSettings.Click += new System.EventHandler(this.actionResetWinSettings_Click);
      // 
      // sep7
      // 
      this.sep7.Name = "sep7";
      resources.ApplyResources(this.sep7, "sep7");
      // 
      // editShowTips
      // 
      this.editShowTips.Checked = true;
      this.editShowTips.CheckOnClick = true;
      this.editShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.editShowTips, "editShowTips");
      this.editShowTips.Name = "editShowTips";
      // 
      // editESCtoExit
      // 
      this.editESCtoExit.Checked = true;
      this.editESCtoExit.CheckOnClick = true;
      this.editESCtoExit.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.editESCtoExit, "editESCtoExit");
      this.editESCtoExit.Name = "editESCtoExit";
      // 
      // editConfirmClosing
      // 
      resources.ApplyResources(this.editConfirmClosing, "editConfirmClosing");
      this.editConfirmClosing.Checked = true;
      this.editConfirmClosing.CheckOnClick = true;
      this.editConfirmClosing.CheckState = System.Windows.Forms.CheckState.Checked;
      this.editConfirmClosing.Name = "editConfirmClosing";
      // 
      // menuView
      // 
      this.menuView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.menuView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionViewText,
            this.actionViewGrid});
      resources.ApplyResources(this.menuView, "menuView");
      this.menuView.Name = "menuView";
      // 
      // actionViewText
      // 
      this.actionViewText.CheckOnClick = true;
      resources.ApplyResources(this.actionViewText, "actionViewText");
      this.actionViewText.Name = "actionViewText";
      this.actionViewText.Click += new System.EventHandler(this.actionViewText_Click);
      // 
      // actionViewGrid
      // 
      this.actionViewGrid.CheckOnClick = true;
      resources.ApplyResources(this.actionViewGrid, "actionViewGrid");
      this.actionViewGrid.Name = "actionViewGrid";
      this.actionViewGrid.Click += new System.EventHandler(this.actionViewGrid_Click);
      // 
      // actionStop
      // 
      this.actionStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.actionStop, "actionStop");
      this.actionStop.Name = "actionStop";
      this.actionStop.Padding = new System.Windows.Forms.Padding(5);
      this.actionStop.Click += new System.EventHandler(this.actionStop_Click);
      this.actionStop.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionStop.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // lunisolarDaysTableAdapter
      // 
      this.lunisolarDaysTableAdapter.ClearBeforeFill = true;
      // 
      // tableAdapterManager
      // 
      this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
      this.tableAdapterManager.LunisolarDaysTableAdapter = this.lunisolarDaysTableAdapter;
      this.tableAdapterManager.UpdateOrder = Ordisoftware.HebrewCalendar.Data.LunisolarCalendarTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panelMain);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.statusBottom);
      this.Name = "MainForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.statusBottom.ResumeLayout(false);
      this.statusBottom.PerformLayout();
      this.panelMain.ResumeLayout(false);
      this.panelCalendarOuter.ResumeLayout(false);
      this.panelCalendarInner.ResumeLayout(false);
      this.panelCalendar.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.tabPageText.ResumeLayout(false);
      this.panelViewText.ResumeLayout(false);
      this.tabPageGrid.ResumeLayout(false);
      this.panelViewGrid.ResumeLayout(false);
      this.panelViewGrid.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.calendarGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lunisolarDaysBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lunisolarCalendar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lunisolarDaysBindingNavigator)).EndInit();
      this.lunisolarDaysBindingNavigator.ResumeLayout(false);
      this.lunisolarDaysBindingNavigator.PerformLayout();
      this.panelProgress.ResumeLayout(false);
      this.panelTitle.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).EndInit();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton actionWebsite;
    private System.Windows.Forms.ToolStripButton actionContact;
    private System.Windows.Forms.ToolStripButton actionExit;
    private System.Windows.Forms.ToolStripButton actionAbout;
    private System.Windows.Forms.ToolStripSeparator sep4;
    private System.Windows.Forms.ToolStripSeparator sep5;
    private System.Windows.Forms.StatusStrip statusBottom;
    private System.Windows.Forms.ToolStripButton actionStop;
    private System.Windows.Forms.ToolStripStatusLabel labelStatus;
    private System.Windows.Forms.ToolStripDropDownButton menuSettings;
    private System.Windows.Forms.ToolStripMenuItem menuitemScreenPosition;
    private System.Windows.Forms.ToolStripButton actionHelp;
    private System.Windows.Forms.ToolStripSeparator sep7;
    internal System.Windows.Forms.ToolStripMenuItem editScreenNone;
    internal System.Windows.Forms.ToolStripMenuItem editScreenCenter;
    internal System.Windows.Forms.ToolStripMenuItem editScreenTopLeft;
    internal System.Windows.Forms.ToolStripMenuItem editScreenTopRight;
    internal System.Windows.Forms.ToolStripMenuItem editScreenBottomLeft;
    internal System.Windows.Forms.ToolStripMenuItem editScreenBottomRight;
    internal System.Windows.Forms.ToolStripMenuItem editConfirmClosing;
    internal System.Windows.Forms.ToolStripMenuItem editESCtoExit;
    private System.Windows.Forms.ToolStripMenuItem actionResetWinSettings;
    private System.Windows.Forms.ToolStripSeparator sep3;
    internal System.Windows.Forms.ToolStripMenuItem editShowTips;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.ToolStripSeparator sep6;
    private System.Windows.Forms.ToolStripSeparator sep2;
    private System.Windows.Forms.ToolStripButton actionCopyReportToClipboard;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Panel panelProgress;
    private System.Windows.Forms.ProgressBar barProgress;
    private System.Windows.Forms.Panel panelSepTop;
    private System.Windows.Forms.Panel panelTitle;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.Panel panelSepBottom;
    private System.Windows.Forms.Panel panelCalendarOuter;
    private System.Windows.Forms.Panel panelCalendarInner;
    private System.Windows.Forms.ToolStripDropDownButton menuView;
    internal System.Windows.Forms.ToolStripMenuItem actionViewText;
    internal System.Windows.Forms.ToolStripMenuItem actionViewGrid;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPageText;
    private System.Windows.Forms.Panel panelViewText;
    internal System.Windows.Forms.RichTextBox calendarText;
    private System.Windows.Forms.TabPage tabPageGrid;
    private System.Windows.Forms.Panel panelViewGrid;
    private System.Windows.Forms.PictureBox moonPhaseImagePictureBox;
    private System.Windows.Forms.Label label1;
    internal System.Windows.Forms.Panel panelCalendar;
    private System.Windows.Forms.Timer timerTooltip;
    private Data.LunisolarCalendarTableAdapters.LunisolarDaysTableAdapter lunisolarDaysTableAdapter;
    private Data.LunisolarCalendarTableAdapters.TableAdapterManager tableAdapterManager;
    private System.Windows.Forms.BindingSource lunisolarDaysBindingSource;
    private System.Windows.Forms.BindingNavigator lunisolarDaysBindingNavigator;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    private System.Windows.Forms.DataGridView calendarGrid;
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
    internal Data.LunisolarCalendar lunisolarCalendar;
    private System.Windows.Forms.ToolStripButton actionSaveReport;
    private System.Windows.Forms.ToolStripButton actionFindDay;
    internal System.Windows.Forms.ToolStripButton actionGenerate;
    internal System.Windows.Forms.ToolStripButton actionPreferences;
  }
}


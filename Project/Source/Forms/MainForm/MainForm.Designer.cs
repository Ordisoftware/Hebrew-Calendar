﻿namespace Ordisoftware.Hebrew.Calendar
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
      TimerMidnight.Dispose();
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.SaveTextDialog = new System.Windows.Forms.SaveFileDialog();
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
      this.CalendarMonth = new CodeProjectCalendar.NET.Calendar();
      this.TabPageGrid = new System.Windows.Forms.TabPage();
      this.PanelViewGrid = new System.Windows.Forms.Panel();
      this.EditEnumsAsTranslations = new System.Windows.Forms.CheckBox();
      this.CalendarGrid = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LunisolarDaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.LunisolarDaysBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
      this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.LabelGridGoToToday = new System.Windows.Forms.ToolStripLabel();
      this.PanelSepTop = new System.Windows.Forms.Panel();
      this.PanelTitle = new System.Windows.Forms.Panel();
      this.LabelSubTitleGPS = new System.Windows.Forms.Label();
      this.LabelSubTitleCalendar = new System.Windows.Forms.Label();
      this.LabelSubTitleOmer = new System.Windows.Forms.Label();
      this.moonPhaseImagePictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.TimerTooltip = new System.Windows.Forms.Timer(this.components);
      this.SaveDataGridDialog = new System.Windows.Forms.SaveFileDialog();
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
      this.SeparatorTrayMenu5 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuInformation = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuPreferences = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.TimerReminder = new System.Windows.Forms.Timer(this.components);
      this.TimerBallon = new System.Windows.Forms.Timer(this.components);
      this.TimerTrayMouseMove = new System.Windows.Forms.Timer(this.components);
      this.TimerResumeReminder = new System.Windows.Forms.Timer(this.components);
      this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
      this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.ActionSaveToFile = new System.Windows.Forms.ToolStripButton();
      this.ActionCopyToClipboard = new System.Windows.Forms.ToolStripButton();
      this.ActionPrint = new System.Windows.Forms.ToolStripButton();
      this.Sep2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSearchEvent = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchMonth = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchGregorianMonth = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchDay = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionNavigate = new System.Windows.Forms.ToolStripButton();
      this.ActionViewCelebrations = new System.Windows.Forms.ToolStripButton();
      this.Sep3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionExit = new System.Windows.Forms.ToolStripButton();
      this.ActionInformation = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionResetReminder = new System.Windows.Forms.ToolStripButton();
      this.ActionDisableReminder = new System.Windows.Forms.ToolStripButton();
      this.ActionEnableReminder = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTools = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionOnlineParashah = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewParashahInfos = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionStudyOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenVerseOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowParashahNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowCelebrationsNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowShabatNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionViewParashot = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewCelebrationsBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewNewMoonsBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewLunarMonths = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCalculateDateDiff = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenCalculator = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenSystemDateAndTime = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionLocalWeather = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOnlineWeather = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorMenuWeather = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenExportFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionGenerate = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionVacuumAtNextStartup = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebLinks = new System.Windows.Forms.ToolStripDropDownButton();
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
      this.ActionShowKeyboardNotice = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionSelectReminderBoxSound = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.EditShowTips = new System.Windows.Forms.ToolStripMenuItem();
      this.EditUseAdvancedDialogBoxes = new System.Windows.Forms.ToolStripMenuItem();
      this.EditSoundsEnabled = new System.Windows.Forms.ToolStripMenuItem();
      this.EditShowSuccessDialogs = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.EditESCtoExit = new System.Windows.Forms.ToolStripMenuItem();
      this.EditConfirmClosing = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionView = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionViewReport = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewMonth = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewGrid = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.Sep6 = new System.Windows.Forms.ToolStripSeparator();
      this.SaveDataBoardDialog = new System.Windows.Forms.SaveFileDialog();
      this.TimerUpdateTitles = new System.Windows.Forms.Timer(this.components);
      this.TimerKillProcesses = new System.Windows.Forms.Timer(this.components);
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
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingNavigator)).BeginInit();
      this.LunisolarDaysBindingNavigator.SuspendLayout();
      this.PanelTitle.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).BeginInit();
      this.MenuTray.SuspendLayout();
      this.ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // SaveTextDialog
      // 
      resources.ApplyResources(this.SaveTextDialog, "SaveTextDialog");
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
      this.PanelCalendarInner.BackColor = System.Drawing.SystemColors.Control;
      this.PanelCalendarInner.Controls.Add(this.PanelCalendar);
      resources.ApplyResources(this.PanelCalendarInner, "PanelCalendarInner");
      this.PanelCalendarInner.Name = "PanelCalendarInner";
      // 
      // PanelCalendar
      // 
      this.PanelCalendar.BackColor = System.Drawing.SystemColors.Window;
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
      this.CalendarText.HideSelection = false;
      this.CalendarText.Name = "CalendarText";
      this.CalendarText.ReadOnly = true;
      this.CalendarText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalendarText_KeyDown);
      // 
      // TabPageMonth
      // 
      this.TabPageMonth.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageMonth.Controls.Add(this.PanelViewMonth);
      resources.ApplyResources(this.TabPageMonth, "TabPageMonth");
      this.TabPageMonth.Name = "TabPageMonth";
      // 
      // PanelViewMonth
      // 
      this.PanelViewMonth.BackColor = System.Drawing.SystemColors.Window;
      this.PanelViewMonth.Controls.Add(this.CalendarMonth);
      resources.ApplyResources(this.PanelViewMonth, "PanelViewMonth");
      this.PanelViewMonth.Name = "PanelViewMonth";
      // 
      // CalendarMonth
      // 
      this.CalendarMonth.AllowEditingEvents = false;
      this.CalendarMonth.BackColor = System.Drawing.Color.White;
      this.CalendarMonth.CalendarDate = new System.DateTime(2019, 1, 19, 13, 27, 20, 916);
      this.CalendarMonth.CalendarView = CodeProjectCalendar.NET.CalendarViews.Month;
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
      // TabPageGrid
      // 
      this.TabPageGrid.Controls.Add(this.PanelViewGrid);
      resources.ApplyResources(this.TabPageGrid, "TabPageGrid");
      this.TabPageGrid.Name = "TabPageGrid";
      this.TabPageGrid.UseVisualStyleBackColor = true;
      // 
      // PanelViewGrid
      // 
      this.PanelViewGrid.Controls.Add(this.EditEnumsAsTranslations);
      this.PanelViewGrid.Controls.Add(this.CalendarGrid);
      this.PanelViewGrid.Controls.Add(this.LunisolarDaysBindingNavigator);
      resources.ApplyResources(this.PanelViewGrid, "PanelViewGrid");
      this.PanelViewGrid.Name = "PanelViewGrid";
      // 
      // EditEnumsAsTranslations
      // 
      resources.ApplyResources(this.EditEnumsAsTranslations, "EditEnumsAsTranslations");
      this.EditEnumsAsTranslations.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.ExportDataEnumsAsTranslations;
      this.EditEnumsAsTranslations.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditEnumsAsTranslations.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "ExportDataEnumsAsTranslations", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditEnumsAsTranslations.Name = "EditEnumsAsTranslations";
      this.EditEnumsAsTranslations.UseVisualStyleBackColor = true;
      this.EditEnumsAsTranslations.CheckedChanged += new System.EventHandler(this.EditExportDataEnumsAsTranslations_CheckedChanged);
      // 
      // CalendarGrid
      // 
      this.CalendarGrid.AllowUserToAddRows = false;
      this.CalendarGrid.AllowUserToDeleteRows = false;
      this.CalendarGrid.AllowUserToResizeRows = false;
      this.CalendarGrid.AutoGenerateColumns = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.CalendarGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.CalendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.CalendarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
      this.CalendarGrid.DataSource = this.LunisolarDaysBindingSource;
      resources.ApplyResources(this.CalendarGrid, "CalendarGrid");
      this.CalendarGrid.EnableHeadersVisualStyles = false;
      this.CalendarGrid.MultiSelect = false;
      this.CalendarGrid.Name = "CalendarGrid";
      this.CalendarGrid.ReadOnly = true;
      this.CalendarGrid.RowHeadersVisible = false;
      this.CalendarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.CalendarGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CalendarGrid_CellFormatting);
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
      this.dataGridViewTextBoxColumn4.DataPropertyName = "SunriseAsString";
      resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "SunsetAsString";
      resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn8
      // 
      this.dataGridViewTextBoxColumn8.DataPropertyName = "MoonriseOccuring";
      resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      this.dataGridViewTextBoxColumn8.ReadOnly = true;
      this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "MoonriseAsString";
      resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn6.ReadOnly = true;
      this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "MoonsetAsString";
      resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
      this.dataGridViewTextBoxColumn13.DataPropertyName = "TorahEvent";
      resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
      this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
      this.dataGridViewTextBoxColumn13.ReadOnly = true;
      this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // LunisolarDaysBindingSource
      // 
      this.LunisolarDaysBindingSource.DataSource = typeof(Ordisoftware.Hebrew.Calendar.LunisolarDay);
      this.LunisolarDaysBindingSource.CurrentItemChanged += new System.EventHandler(this.LunisolarDaysBindingSource_CurrentItemChanged);
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
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator5,
            this.LabelGridGoToToday});
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
      this.bindingNavigatorPositionItem.ReadOnly = true;
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
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // LabelGridGoToToday
      // 
      this.LabelGridGoToToday.Name = "LabelGridGoToToday";
      resources.ApplyResources(this.LabelGridGoToToday, "LabelGridGoToToday");
      this.LabelGridGoToToday.Click += new System.EventHandler(this.LabelGridGoToToday_Click);
      // 
      // PanelSepTop
      // 
      resources.ApplyResources(this.PanelSepTop, "PanelSepTop");
      this.PanelSepTop.Name = "PanelSepTop";
      // 
      // PanelTitle
      // 
      this.PanelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelTitle.Controls.Add(this.LabelSubTitleGPS);
      this.PanelTitle.Controls.Add(this.LabelSubTitleCalendar);
      this.PanelTitle.Controls.Add(this.LabelSubTitleOmer);
      resources.ApplyResources(this.PanelTitle, "PanelTitle");
      this.PanelTitle.Name = "PanelTitle";
      // 
      // LabelSubTitleGPS
      // 
      this.LabelSubTitleGPS.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelSubTitleGPS, "LabelSubTitleGPS");
      this.LabelSubTitleGPS.Name = "LabelSubTitleGPS";
      // 
      // LabelSubTitleCalendar
      // 
      this.LabelSubTitleCalendar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelSubTitleCalendar, "LabelSubTitleCalendar");
      this.LabelSubTitleCalendar.Name = "LabelSubTitleCalendar";
      // 
      // LabelSubTitleOmer
      // 
      this.LabelSubTitleOmer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelSubTitleOmer, "LabelSubTitleOmer");
      this.LabelSubTitleOmer.Name = "LabelSubTitleOmer";
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
            this.SeparatorTrayMenu5,
            this.MenuInformation,
            this.MenuPreferences,
            this.toolStripSeparator6,
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
      // SeparatorTrayMenu5
      // 
      this.SeparatorTrayMenu5.Name = "SeparatorTrayMenu5";
      resources.ApplyResources(this.SeparatorTrayMenu5, "SeparatorTrayMenu5");
      // 
      // MenuInformation
      // 
      resources.ApplyResources(this.MenuInformation, "MenuInformation");
      this.MenuInformation.Name = "MenuInformation";
      // 
      // MenuPreferences
      // 
      resources.ApplyResources(this.MenuPreferences, "MenuPreferences");
      this.MenuPreferences.Name = "MenuPreferences";
      this.MenuPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
      // 
      // MenuExit
      // 
      resources.ApplyResources(this.MenuExit, "MenuExit");
      this.MenuExit.Name = "MenuExit";
      this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
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
      // SaveImageDialog
      // 
      resources.ApplyResources(this.SaveImageDialog, "SaveImageDialog");
      // 
      // ActionSaveToFile
      // 
      this.ActionSaveToFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSaveToFile, "ActionSaveToFile");
      this.ActionSaveToFile.Name = "ActionSaveToFile";
      this.ActionSaveToFile.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSaveToFile.Click += new System.EventHandler(this.ActionSave_Click);
      this.ActionSaveToFile.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionSaveToFile.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionCopyToClipboard
      // 
      this.ActionCopyToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionCopyToClipboard, "ActionCopyToClipboard");
      this.ActionCopyToClipboard.Name = "ActionCopyToClipboard";
      this.ActionCopyToClipboard.Padding = new System.Windows.Forms.Padding(5);
      this.ActionCopyToClipboard.Click += new System.EventHandler(this.ActionCopyToClipboard_Click);
      this.ActionCopyToClipboard.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionCopyToClipboard.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionPrint
      // 
      this.ActionPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionPrint, "ActionPrint");
      this.ActionPrint.Name = "ActionPrint";
      this.ActionPrint.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPrint.Click += new System.EventHandler(this.ActionPrint_Click);
      this.ActionPrint.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionPrint.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
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
      this.ActionSearchEvent.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionSearchEvent.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionSearchMonth
      // 
      this.ActionSearchMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchMonth, "ActionSearchMonth");
      this.ActionSearchMonth.Name = "ActionSearchMonth";
      this.ActionSearchMonth.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchMonth.Click += new System.EventHandler(this.ActionSearchMonth_Click);
      this.ActionSearchMonth.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionSearchMonth.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionSearchGregorianMonth
      // 
      this.ActionSearchGregorianMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchGregorianMonth, "ActionSearchGregorianMonth");
      this.ActionSearchGregorianMonth.Name = "ActionSearchGregorianMonth";
      this.ActionSearchGregorianMonth.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchGregorianMonth.Click += new System.EventHandler(this.ActionSearchGregorianMonth_Click);
      this.ActionSearchGregorianMonth.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionSearchGregorianMonth.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionSearchDay
      // 
      this.ActionSearchDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchDay, "ActionSearchDay");
      this.ActionSearchDay.Name = "ActionSearchDay";
      this.ActionSearchDay.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchDay.Click += new System.EventHandler(this.ActionSearchDay_Click);
      this.ActionSearchDay.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionSearchDay.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
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
      this.ActionNavigate.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionNavigate.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionViewCelebrations
      // 
      this.ActionViewCelebrations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewCelebrations, "ActionViewCelebrations");
      this.ActionViewCelebrations.Name = "ActionViewCelebrations";
      this.ActionViewCelebrations.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewCelebrations.Click += new System.EventHandler(this.ActionViewCelebrations_Click);
      this.ActionViewCelebrations.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionViewCelebrations.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
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
      this.ActionExit.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionExit.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      this.ActionExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ActionExit_MouseUp);
      // 
      // ActionInformation
      // 
      this.ActionInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionInformation, "ActionInformation");
      this.ActionInformation.Name = "ActionInformation";
      this.ActionInformation.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionResetReminder
      // 
      this.ActionResetReminder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionResetReminder, "ActionResetReminder");
      this.ActionResetReminder.Name = "ActionResetReminder";
      this.ActionResetReminder.Padding = new System.Windows.Forms.Padding(5);
      this.ActionResetReminder.Click += new System.EventHandler(this.MenuRefreshReminder_Click);
      this.ActionResetReminder.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionResetReminder.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionDisableReminder
      // 
      this.ActionDisableReminder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionDisableReminder, "ActionDisableReminder");
      this.ActionDisableReminder.Name = "ActionDisableReminder";
      this.ActionDisableReminder.Padding = new System.Windows.Forms.Padding(5);
      this.ActionDisableReminder.Click += new System.EventHandler(this.MenuDisableReminder_Click);
      this.ActionDisableReminder.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionDisableReminder.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionEnableReminder
      // 
      this.ActionEnableReminder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionEnableReminder, "ActionEnableReminder");
      this.ActionEnableReminder.Name = "ActionEnableReminder";
      this.ActionEnableReminder.Padding = new System.Windows.Forms.Padding(5);
      this.ActionEnableReminder.Click += new System.EventHandler(this.MenuEnableReminder_Click);
      this.ActionEnableReminder.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionEnableReminder.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
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
            this.ActionOnlineParashah,
            this.toolStripSeparator11,
            this.ActionShowParashahNotice,
            this.ActionShowCelebrationsNotice,
            this.ActionShowShabatNotice,
            this.toolStripSeparator8,
            this.ActionViewParashot,
            this.ActionViewCelebrationsBoard,
            this.ActionViewNewMoonsBoard,
            this.ActionViewLunarMonths,
            this.toolStripSeparator1,
            this.ActionCalculateDateDiff,
            this.ActionOpenCalculator,
            this.ActionOpenSystemDateAndTime,
            this.toolStripSeparator9,
            this.ActionLocalWeather,
            this.ActionOnlineWeather,
            this.SeparatorMenuWeather,
            this.ActionOpenExportFolder,
            this.toolStripSeparator10,
            this.ActionGenerate,
            this.ActionVacuumAtNextStartup});
      resources.ApplyResources(this.ActionTools, "ActionTools");
      this.ActionTools.Name = "ActionTools";
      this.ActionTools.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionOnlineParashah
      // 
      this.ActionOnlineParashah.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionViewParashahInfos,
            this.toolStripSeparator13,
            this.ActionStudyOnline,
            this.ActionOpenVerseOnline});
      resources.ApplyResources(this.ActionOnlineParashah, "ActionOnlineParashah");
      this.ActionOnlineParashah.Name = "ActionOnlineParashah";
      // 
      // ActionViewParashahInfos
      // 
      resources.ApplyResources(this.ActionViewParashahInfos, "ActionViewParashahInfos");
      this.ActionViewParashahInfos.Name = "ActionViewParashahInfos";
      this.ActionViewParashahInfos.Click += new System.EventHandler(this.ActionViewParashahInfos_Click);
      // 
      // toolStripSeparator13
      // 
      this.toolStripSeparator13.Name = "toolStripSeparator13";
      resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
      // 
      // ActionStudyOnline
      // 
      resources.ApplyResources(this.ActionStudyOnline, "ActionStudyOnline");
      this.ActionStudyOnline.Name = "ActionStudyOnline";
      // 
      // ActionOpenVerseOnline
      // 
      resources.ApplyResources(this.ActionOpenVerseOnline, "ActionOpenVerseOnline");
      this.ActionOpenVerseOnline.Name = "ActionOpenVerseOnline";
      // 
      // toolStripSeparator11
      // 
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
      // 
      // ActionShowParashahNotice
      // 
      resources.ApplyResources(this.ActionShowParashahNotice, "ActionShowParashahNotice");
      this.ActionShowParashahNotice.Name = "ActionShowParashahNotice";
      this.ActionShowParashahNotice.Click += new System.EventHandler(this.ActionShowParashahNotice_Click);
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
      // ActionViewParashot
      // 
      resources.ApplyResources(this.ActionViewParashot, "ActionViewParashot");
      this.ActionViewParashot.Name = "ActionViewParashot";
      this.ActionViewParashot.Click += new System.EventHandler(this.ActionViewParashot_Click);
      // 
      // ActionViewCelebrationsBoard
      // 
      resources.ApplyResources(this.ActionViewCelebrationsBoard, "ActionViewCelebrationsBoard");
      this.ActionViewCelebrationsBoard.Name = "ActionViewCelebrationsBoard";
      this.ActionViewCelebrationsBoard.Click += new System.EventHandler(this.ActionViewCelebrationsBoard_Click);
      // 
      // ActionViewNewMoonsBoard
      // 
      resources.ApplyResources(this.ActionViewNewMoonsBoard, "ActionViewNewMoonsBoard");
      this.ActionViewNewMoonsBoard.Name = "ActionViewNewMoonsBoard";
      this.ActionViewNewMoonsBoard.Click += new System.EventHandler(this.ActionViewMoonsBoard_Click);
      // 
      // ActionViewLunarMonths
      // 
      resources.ApplyResources(this.ActionViewLunarMonths, "ActionViewLunarMonths");
      this.ActionViewLunarMonths.Name = "ActionViewLunarMonths";
      this.ActionViewLunarMonths.Click += new System.EventHandler(this.ActionViewLunarMonths_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
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
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
      // 
      // ActionLocalWeather
      // 
      this.ActionLocalWeather.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionLocalWeather, "ActionLocalWeather");
      this.ActionLocalWeather.Name = "ActionLocalWeather";
      this.ActionLocalWeather.Click += new System.EventHandler(this.ActionLocalWeather_Click);
      // 
      // ActionOnlineWeather
      // 
      this.ActionOnlineWeather.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionOnlineWeather, "ActionOnlineWeather");
      this.ActionOnlineWeather.Name = "ActionOnlineWeather";
      this.ActionOnlineWeather.Click += new System.EventHandler(this.ActionOnlineWeather_Click);
      // 
      // SeparatorMenuWeather
      // 
      this.SeparatorMenuWeather.Name = "SeparatorMenuWeather";
      resources.ApplyResources(this.SeparatorMenuWeather, "SeparatorMenuWeather");
      // 
      // ActionOpenExportFolder
      // 
      resources.ApplyResources(this.ActionOpenExportFolder, "ActionOpenExportFolder");
      this.ActionOpenExportFolder.Name = "ActionOpenExportFolder";
      this.ActionOpenExportFolder.Click += new System.EventHandler(this.ActionOpenExportFolder_Click);
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
      // 
      // ActionGenerate
      // 
      resources.ApplyResources(this.ActionGenerate, "ActionGenerate");
      this.ActionGenerate.Name = "ActionGenerate";
      this.ActionGenerate.Click += new System.EventHandler(this.ActionGenerate_Click);
      // 
      // ActionVacuumAtNextStartup
      // 
      this.ActionVacuumAtNextStartup.CheckOnClick = true;
      resources.ApplyResources(this.ActionVacuumAtNextStartup, "ActionVacuumAtNextStartup");
      this.ActionVacuumAtNextStartup.Name = "ActionVacuumAtNextStartup";
      this.ActionVacuumAtNextStartup.Click += new System.EventHandler(this.ActionVacuumAtNextStartup_Click);
      // 
      // ActionWebLinks
      // 
      this.ActionWebLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionWebLinks, "ActionWebLinks");
      this.ActionWebLinks.Name = "ActionWebLinks";
      this.ActionWebLinks.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionPreferences
      // 
      this.ActionPreferences.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionPreferences, "ActionPreferences");
      this.ActionPreferences.Name = "ActionPreferences";
      this.ActionPreferences.Padding = new System.Windows.Forms.Padding(5);
      this.ActionPreferences.Click += new System.EventHandler(this.ActionPreferences_Click);
      this.ActionPreferences.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionPreferences.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ActionSettings
      // 
      this.ActionSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ActionSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuitemScreenPosition,
            this.ActionResetWinSettings,
            this.Sep7,
            this.ActionShowKeyboardNotice,
            this.ActionSelectReminderBoxSound,
            this.toolStripSeparator3,
            this.EditShowTips,
            this.EditUseAdvancedDialogBoxes,
            this.EditSoundsEnabled,
            this.EditShowSuccessDialogs,
            this.toolStripSeparator2,
            this.EditESCtoExit,
            this.EditConfirmClosing});
      resources.ApplyResources(this.ActionSettings, "ActionSettings");
      this.ActionSettings.Name = "ActionSettings";
      this.ActionSettings.Padding = new System.Windows.Forms.Padding(5);
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
      // ActionShowKeyboardNotice
      // 
      resources.ApplyResources(this.ActionShowKeyboardNotice, "ActionShowKeyboardNotice");
      this.ActionShowKeyboardNotice.Name = "ActionShowKeyboardNotice";
      this.ActionShowKeyboardNotice.Click += new System.EventHandler(this.ActionShowKeyboardNotice_Click);
      // 
      // ActionSelectReminderBoxSound
      // 
      resources.ApplyResources(this.ActionSelectReminderBoxSound, "ActionSelectReminderBoxSound");
      this.ActionSelectReminderBoxSound.Name = "ActionSelectReminderBoxSound";
      this.ActionSelectReminderBoxSound.Click += new System.EventHandler(this.ActionSelectReminderBoxSound_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
      // 
      // EditShowTips
      // 
      this.EditShowTips.Checked = true;
      this.EditShowTips.CheckOnClick = true;
      this.EditShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditShowTips, "EditShowTips");
      this.EditShowTips.Name = "EditShowTips";
      // 
      // EditUseAdvancedDialogBoxes
      // 
      this.EditUseAdvancedDialogBoxes.Checked = true;
      this.EditUseAdvancedDialogBoxes.CheckOnClick = true;
      this.EditUseAdvancedDialogBoxes.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditUseAdvancedDialogBoxes, "EditUseAdvancedDialogBoxes");
      this.EditUseAdvancedDialogBoxes.Name = "EditUseAdvancedDialogBoxes";
      this.EditUseAdvancedDialogBoxes.CheckedChanged += new System.EventHandler(this.EditDialogBoxesSettings_CheckedChanged);
      // 
      // EditSoundsEnabled
      // 
      this.EditSoundsEnabled.Checked = true;
      this.EditSoundsEnabled.CheckOnClick = true;
      this.EditSoundsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditSoundsEnabled, "EditSoundsEnabled");
      this.EditSoundsEnabled.Name = "EditSoundsEnabled";
      this.EditSoundsEnabled.CheckedChanged += new System.EventHandler(this.EditDialogBoxesSettings_CheckedChanged);
      // 
      // EditShowSuccessDialogs
      // 
      this.EditShowSuccessDialogs.Checked = true;
      this.EditShowSuccessDialogs.CheckOnClick = true;
      this.EditShowSuccessDialogs.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.EditShowSuccessDialogs, "EditShowSuccessDialogs");
      this.EditShowSuccessDialogs.Name = "EditShowSuccessDialogs";
      this.EditShowSuccessDialogs.CheckedChanged += new System.EventHandler(this.EditShowSuccessDialogs_CheckedChanged);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
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
      this.ActionView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionViewReport,
            this.ActionViewMonth,
            this.ActionViewGrid});
      resources.ApplyResources(this.ActionView, "ActionView");
      this.ActionView.Name = "ActionView";
      this.ActionView.Padding = new System.Windows.Forms.Padding(5);
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
      this.ActionViewMonth.CheckOnClick = true;
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
      // ToolStrip
      // 
      this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionView,
            this.toolStripSeparator7,
            this.ActionSaveToFile,
            this.ActionCopyToClipboard,
            this.ActionPrint,
            this.Sep2,
            this.ActionSearchEvent,
            this.ActionSearchMonth,
            this.ActionSearchGregorianMonth,
            this.ActionSearchDay,
            this.toolStripSeparator12,
            this.ActionNavigate,
            this.ActionViewCelebrations,
            this.Sep3,
            this.ActionExit,
            this.ActionResetReminder,
            this.ActionDisableReminder,
            this.ActionEnableReminder,
            this.toolStripSeparator4,
            this.ActionTools,
            this.ActionWebLinks,
            this.ActionInformation,
            this.Sep6,
            this.ActionPreferences,
            this.ActionSettings});
      resources.ApplyResources(this.ToolStrip, "ToolStrip");
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.ShowItemToolTips = false;
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      // 
      // Sep6
      // 
      this.Sep6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.Sep6.Name = "Sep6";
      resources.ApplyResources(this.Sep6, "Sep6");
      // 
      // TimerUpdateTitles
      // 
      this.TimerUpdateTitles.Interval = 60000;
      this.TimerUpdateTitles.Tick += new System.EventHandler(this.TimerUpdateTitles_Tick);
      // 
      // TimerKillProcesses
      // 
      this.TimerKillProcesses.Interval = 5000;
      this.TimerKillProcesses.Tick += new System.EventHandler(this.TimerKillProcesses_Tick);
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
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingNavigator)).EndInit();
      this.LunisolarDaysBindingNavigator.ResumeLayout(false);
      this.LunisolarDaysBindingNavigator.PerformLayout();
      this.PanelTitle.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).EndInit();
      this.MenuTray.ResumeLayout(false);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.SaveFileDialog SaveTextDialog;
    private System.Windows.Forms.Panel PanelMain;
    private System.Windows.Forms.Panel PanelSepTop;
    private System.Windows.Forms.Panel PanelTitle;
    private System.Windows.Forms.Label LabelSubTitleCalendar;
    private System.Windows.Forms.Panel PanelCalendarOuter;
    private System.Windows.Forms.Panel PanelCalendarInner;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageText;
    private System.Windows.Forms.Panel PanelViewText;
    public System.Windows.Forms.RichTextBox CalendarText;
    private System.Windows.Forms.TabPage TabPageGrid;
    internal System.Windows.Forms.Panel PanelViewGrid;
    private System.Windows.Forms.PictureBox moonPhaseImagePictureBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel PanelCalendar;
    private System.Windows.Forms.Timer TimerTooltip;
    private System.Windows.Forms.DataGridView CalendarGrid;
    public System.Windows.Forms.SaveFileDialog SaveDataGridDialog;
    private System.Windows.Forms.NotifyIcon TrayIcon;
    public System.Windows.Forms.ToolStripMenuItem MenuShowHide;
    private System.Windows.Forms.ToolStripMenuItem MenuNavigate;
    private System.Windows.Forms.ToolStripMenuItem MenuCelebrations;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu3;
    private System.Windows.Forms.ToolStripMenuItem MenuInformation;
    private System.Windows.Forms.ToolStripMenuItem MenuExit;
    private System.Windows.Forms.TabPage TabPageMonth;
    public global::CodeProjectCalendar.NET.Calendar CalendarMonth;
    public System.Windows.Forms.Panel PanelViewMonth;
    private System.Windows.Forms.Timer TimerTrayMouseMove;
    public System.Windows.Forms.Timer TimerReminder;
    private System.Windows.Forms.ToolStripMenuItem MenuPreferences;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu2;
    private System.Windows.Forms.ToolStripMenuItem MenuResetReminder;
    public System.Windows.Forms.ToolStripMenuItem MenuEnableReminder;
    public System.Windows.Forms.ToolStripMenuItem MenuDisableReminder;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu1;
    public System.Windows.Forms.ContextMenuStrip MenuTray;
    private System.Windows.Forms.Timer TimerResumeReminder;
    private System.Windows.Forms.ToolStripMenuItem MenuWebLinks;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu5;
    private System.Windows.Forms.ToolStripMenuItem MenuTools;
    private System.Windows.Forms.SaveFileDialog SaveImageDialog;
    internal System.Windows.Forms.CheckBox EditEnumsAsTranslations;
    private System.Windows.Forms.FolderBrowserDialog FolderDialog;
    private System.Windows.Forms.ToolStripButton ActionSaveToFile;
    private System.Windows.Forms.ToolStripButton ActionCopyToClipboard;
    private System.Windows.Forms.ToolStripButton ActionPrint;
    private System.Windows.Forms.ToolStripSeparator Sep2;
    private System.Windows.Forms.ToolStripButton ActionSearchEvent;
    private System.Windows.Forms.ToolStripButton ActionSearchMonth;
    private System.Windows.Forms.ToolStripButton ActionSearchGregorianMonth;
    private System.Windows.Forms.ToolStripButton ActionSearchDay;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
    private System.Windows.Forms.ToolStripSeparator Sep3;
    private System.Windows.Forms.ToolStripButton ActionExit;
    public System.Windows.Forms.ToolStripDropDownButton ActionInformation;
    internal System.Windows.Forms.ToolStripButton ActionResetReminder;
    private System.Windows.Forms.ToolStripButton ActionDisableReminder;
    private System.Windows.Forms.ToolStripButton ActionEnableReminder;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripDropDownButton ActionTools;
    private System.Windows.Forms.ToolStripMenuItem ActionShowCelebrationsNotice;
    private System.Windows.Forms.ToolStripMenuItem ActionShowShabatNotice;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenCalculator;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenSystemDateAndTime;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenExportFolder;
    internal System.Windows.Forms.ToolStripMenuItem ActionGenerate;
    private System.Windows.Forms.ToolStripMenuItem ActionVacuumAtNextStartup;
    private System.Windows.Forms.ToolStripDropDownButton ActionWebLinks;
    private System.Windows.Forms.ToolStripButton ActionPreferences;
    private System.Windows.Forms.ToolStripDropDownButton ActionSettings;
    private System.Windows.Forms.ToolStripMenuItem MenuitemScreenPosition;
    public System.Windows.Forms.ToolStripMenuItem EditScreenNone;
    public System.Windows.Forms.ToolStripMenuItem EditScreenTopLeft;
    public System.Windows.Forms.ToolStripMenuItem EditScreenTopRight;
    public System.Windows.Forms.ToolStripMenuItem EditScreenBottomLeft;
    public System.Windows.Forms.ToolStripMenuItem EditScreenBottomRight;
    public System.Windows.Forms.ToolStripMenuItem EditScreenCenter;
    private System.Windows.Forms.ToolStripMenuItem ActionResetWinSettings;
    private System.Windows.Forms.ToolStripSeparator Sep7;
    private System.Windows.Forms.ToolStripMenuItem ActionShowKeyboardNotice;
    private System.Windows.Forms.ToolStripMenuItem ActionSelectReminderBoxSound;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    public System.Windows.Forms.ToolStripMenuItem EditShowTips;
    public System.Windows.Forms.ToolStripMenuItem EditUseAdvancedDialogBoxes;
    public System.Windows.Forms.ToolStripMenuItem EditSoundsEnabled;
    public System.Windows.Forms.ToolStripMenuItem EditShowSuccessDialogs;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    public System.Windows.Forms.ToolStripMenuItem EditESCtoExit;
    public System.Windows.Forms.ToolStripMenuItem EditConfirmClosing;
    private System.Windows.Forms.ToolStripDropDownButton ActionView;
    private System.Windows.Forms.ToolStripMenuItem ActionViewReport;
    private System.Windows.Forms.ToolStripMenuItem ActionViewMonth;
    private System.Windows.Forms.ToolStripMenuItem ActionViewGrid;
    private System.Windows.Forms.ToolStrip ToolStrip;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripSeparator Sep6;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    public System.Windows.Forms.ToolStripSeparator SeparatorMenuWeather;
    public System.Windows.Forms.ToolStripMenuItem ActionOnlineWeather;
    public System.Windows.Forms.ToolStripMenuItem ActionLocalWeather;
    private System.Windows.Forms.Label LabelSubTitleOmer;
    private System.Windows.Forms.Label LabelSubTitleGPS;
    public System.Windows.Forms.SaveFileDialog SaveDataBoardDialog;
    public System.Windows.Forms.ToolStripMenuItem ActionShowParashahNotice;
    private System.Windows.Forms.Timer TimerUpdateTitles;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewLunarMonths;
    internal System.Windows.Forms.ToolStripMenuItem ActionCalculateDateDiff;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewCelebrationsBoard;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewNewMoonsBoard;
    internal System.Windows.Forms.ToolStripMenuItem ActionViewParashot;
    public System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    internal System.Windows.Forms.ToolStripButton ActionNavigate;
    internal System.Windows.Forms.ToolStripButton ActionViewCelebrations;
    private System.Windows.Forms.ToolStripMenuItem ActionOnlineParashah;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
    private System.Windows.Forms.ToolStripMenuItem ActionStudyOnline;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenVerseOnline;
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
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripLabel LabelGridGoToToday;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    private System.Windows.Forms.ToolStripMenuItem ActionViewParashahInfos;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
    internal System.Windows.Forms.Timer TimerBallon;
    private System.Windows.Forms.Timer TimerKillProcesses;
  }
}


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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.SaveReportDialog = new System.Windows.Forms.SaveFileDialog();
      this.PanelMainOuter1 = new System.Windows.Forms.Panel();
      this.PanelMainOuter2 = new System.Windows.Forms.Panel();
      this.PanelMainInner1 = new System.Windows.Forms.Panel();
      this.PanelMainInner2 = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageTextReport = new System.Windows.Forms.TabPage();
      this.PanelViewTextReport = new System.Windows.Forms.Panel();
      this.TextReport = new System.Windows.Forms.RichTextBox();
      this.TabPageMonthlyCalendar = new System.Windows.Forms.TabPage();
      this.PanelViewMonthlyCalendar = new System.Windows.Forms.Panel();
      this.MonthlyCalendar = new CodeProjectCalendar.NET.Calendar();
      this.TabPageGrid = new System.Windows.Forms.TabPage();
      this.PanelViewGrid = new System.Windows.Forms.Panel();
      this.DataGridView = new System.Windows.Forms.DataGridView();
      this.GridColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnLunarMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnLunarDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnSunrise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnSunset = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnMoonriseOccuring = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnMoonrise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnMoonset = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnNewMoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnFullMoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnMoonPhase = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnSeasonChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.GridColumnTorahEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LunisolarDaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.LunisolarDaysBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
      this.BindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.LabelGridGoToToday = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.BindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.BindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.BindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.BindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.BindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.BindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.BindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.BindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.EditExportDataEnumsAsTranslations = new Ordisoftware.Core.ToolStripCheckBoxItem();
      this.LabelEnumsAsTranslations = new System.Windows.Forms.ToolStripLabel();
      this.PanelSepTop = new System.Windows.Forms.Panel();
      this.PanelTitle = new System.Windows.Forms.Panel();
      this.PanelTitleInner = new System.Windows.Forms.Panel();
      this.LabelSubTitleGPS = new System.Windows.Forms.Label();
      this.LabelSubTitleOmer = new System.Windows.Forms.Label();
      this.LabelSubTitleCalendar = new System.Windows.Forms.Label();
      this.moonPhaseImagePictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.TimerTooltip = new System.Windows.Forms.Timer(this.components);
      this.SaveGridDialog = new System.Windows.Forms.SaveFileDialog();
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
      this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuInformation = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuPreferences = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.TimerReminder = new System.Windows.Forms.Timer(this.components);
      this.TimerBalloon = new System.Windows.Forms.Timer(this.components);
      this.TimerTrayMouseMove = new System.Windows.Forms.Timer(this.components);
      this.TimerResumeReminder = new System.Windows.Forms.Timer(this.components);
      this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
      this.SelectImagesFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.ActionSaveToFile = new System.Windows.Forms.ToolStripButton();
      this.ActionCopyToClipboard = new System.Windows.Forms.ToolStripButton();
      this.ActionPrint = new System.Windows.Forms.ToolStripButton();
      this.ToolStripTopSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionSearchEvent = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchLunarMonth = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchGregorianMonth = new System.Windows.Forms.ToolStripButton();
      this.ActionSearchDay = new System.Windows.Forms.ToolStripButton();
      this.ToolStripTopSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionNavigate = new System.Windows.Forms.ToolStripButton();
      this.ActionViewNextCelebrations = new System.Windows.Forms.ToolStripButton();
      this.ToolStripTopSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionExit = new System.Windows.Forms.ToolStripButton();
      this.ActionInformation = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionResetReminder = new System.Windows.Forms.ToolStripButton();
      this.ActionDisableReminder = new System.Windows.Forms.ToolStripButton();
      this.ActionEnableReminder = new System.Windows.Forms.ToolStripButton();
      this.ToolStripTopSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTools = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionShowShabatVerses = new System.Windows.Forms.ToolStripMenuItem();
      this.WeeklyParashahSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWeeklyParashah = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWeeklyParashahDescription = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionParashahReadDefault = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWeeklyParashahReadOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWeeklyParashahStudyOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionWeeklyParashahOpenWithHebrewWords = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowParashotBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowCelebrationVersesBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowCelebrationsBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowNewMoonsBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowLunarMonths = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionManageBookmarks = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCalculateDateDiff = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenSystemDateAndTime = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenCalculator = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionTakeScreenshotWindow = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionTakeScreenshotView = new System.Windows.Forms.ToolStripMenuItem();
      this.SeparatorMenuWeather = new System.Windows.Forms.ToolStripSeparator();
      this.ActionLocalWeather = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOnlineWeather = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionOpenFolderExport = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionOpenFolderDatabase = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionGenerate = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionVacuumDB = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionWebLinks = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionPreferences = new System.Windows.Forms.ToolStripButton();
      this.ActionSettings = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionScreenPosition = new System.Windows.Forms.ToolStripMenuItem();
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
      this.ActionSelectView = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionViewReport = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewMonth = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionViewGrid = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStrip = new System.Windows.Forms.ToolStrip();
      this.ToolStripTopSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionHelp = new System.Windows.Forms.ToolStripDropDownButton();
      this.ActionShowNotices = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionShowTranscriptionGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionShowGrammarGuide = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripTopSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.MainMenuSeparatorLeftButtons = new System.Windows.Forms.ToolStripSeparator();
      this.SaveDataBoardDialog = new System.Windows.Forms.SaveFileDialog();
      this.TimerUpdateTitles = new System.Windows.Forms.Timer(this.components);
      this.ContextMenuStripDay = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ContextMenuDayDate = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDaySunrise = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDaySunset = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuSunMoonSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayMoonrise = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayMoonset = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayTimesSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuShabatVerses = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuParashahSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayParashah = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayParashahDescription = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuParashahReadDefault = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayParashahReadOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayParashahStudyOnline = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuOpenWithHebrewWords = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayParashotBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayCelebrationVersesBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDaySetAsActive = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDaySelectDate = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayClearSelection = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayGoToToday = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayGoToSelected = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayGoToBookmark = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDaySaveBookmark = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayManageBookmark = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayDatesDiffToToday = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuDayDatesDiffToSelected = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
      this.ContextMenuDayNavigation = new System.Windows.Forms.ToolStripMenuItem();
      this.ImageListRisesAndSets = new System.Windows.Forms.ImageList(this.components);
      this.MenuBookmarks = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ContextMenuDayDatesDiffToActive = new System.Windows.Forms.ToolStripMenuItem();
      this.PanelMainOuter1.SuspendLayout();
      this.PanelMainOuter2.SuspendLayout();
      this.PanelMainInner1.SuspendLayout();
      this.PanelMainInner2.SuspendLayout();
      this.TabControl.SuspendLayout();
      this.TabPageTextReport.SuspendLayout();
      this.PanelViewTextReport.SuspendLayout();
      this.TabPageMonthlyCalendar.SuspendLayout();
      this.PanelViewMonthlyCalendar.SuspendLayout();
      this.TabPageGrid.SuspendLayout();
      this.PanelViewGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingNavigator)).BeginInit();
      this.LunisolarDaysBindingNavigator.SuspendLayout();
      this.PanelTitle.SuspendLayout();
      this.PanelTitleInner.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).BeginInit();
      this.MenuTray.SuspendLayout();
      this.ToolStrip.SuspendLayout();
      this.ContextMenuStripDay.SuspendLayout();
      this.SuspendLayout();
      // 
      // SaveReportDialog
      // 
      resources.ApplyResources(this.SaveReportDialog, "SaveReportDialog");
      // 
      // PanelMainOuter1
      // 
      this.PanelMainOuter1.Controls.Add(this.PanelMainOuter2);
      this.PanelMainOuter1.Controls.Add(this.PanelSepTop);
      this.PanelMainOuter1.Controls.Add(this.PanelTitle);
      resources.ApplyResources(this.PanelMainOuter1, "PanelMainOuter1");
      this.PanelMainOuter1.Name = "PanelMainOuter1";
      // 
      // PanelMainOuter2
      // 
      this.PanelMainOuter2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelMainOuter2.Controls.Add(this.PanelMainInner1);
      resources.ApplyResources(this.PanelMainOuter2, "PanelMainOuter2");
      this.PanelMainOuter2.Name = "PanelMainOuter2";
      // 
      // PanelMainInner1
      // 
      this.PanelMainInner1.BackColor = System.Drawing.SystemColors.Control;
      this.PanelMainInner1.Controls.Add(this.PanelMainInner2);
      resources.ApplyResources(this.PanelMainInner1, "PanelMainInner1");
      this.PanelMainInner1.Name = "PanelMainInner1";
      // 
      // PanelMainInner2
      // 
      this.PanelMainInner2.BackColor = System.Drawing.SystemColors.Window;
      this.PanelMainInner2.Controls.Add(this.TabControl);
      resources.ApplyResources(this.PanelMainInner2, "PanelMainInner2");
      this.PanelMainInner2.Name = "PanelMainInner2";
      // 
      // TabControl
      // 
      this.TabControl.Controls.Add(this.TabPageTextReport);
      this.TabControl.Controls.Add(this.TabPageMonthlyCalendar);
      this.TabControl.Controls.Add(this.TabPageGrid);
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.TabStop = false;
      // 
      // TabPageTextReport
      // 
      this.TabPageTextReport.Controls.Add(this.PanelViewTextReport);
      resources.ApplyResources(this.TabPageTextReport, "TabPageTextReport");
      this.TabPageTextReport.Name = "TabPageTextReport";
      this.TabPageTextReport.UseVisualStyleBackColor = true;
      // 
      // PanelViewTextReport
      // 
      this.PanelViewTextReport.Controls.Add(this.TextReport);
      resources.ApplyResources(this.PanelViewTextReport, "PanelViewTextReport");
      this.PanelViewTextReport.Name = "PanelViewTextReport";
      // 
      // TextReport
      // 
      resources.ApplyResources(this.TextReport, "TextReport");
      this.TextReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.TextReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.TextReport.HideSelection = false;
      this.TextReport.Name = "TextReport";
      this.TextReport.ReadOnly = true;
      this.TextReport.SelectionChanged += new System.EventHandler(this.TextBoxReport_SelectionChanged);
      this.TextReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxReport_KeyDown);
      this.TextReport.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxReport_KeyUp);
      // 
      // TabPageMonthlyCalendar
      // 
      this.TabPageMonthlyCalendar.BackColor = System.Drawing.SystemColors.Window;
      this.TabPageMonthlyCalendar.Controls.Add(this.PanelViewMonthlyCalendar);
      resources.ApplyResources(this.TabPageMonthlyCalendar, "TabPageMonthlyCalendar");
      this.TabPageMonthlyCalendar.Name = "TabPageMonthlyCalendar";
      // 
      // PanelViewMonthlyCalendar
      // 
      this.PanelViewMonthlyCalendar.BackColor = System.Drawing.SystemColors.Window;
      this.PanelViewMonthlyCalendar.Controls.Add(this.MonthlyCalendar);
      resources.ApplyResources(this.PanelViewMonthlyCalendar, "PanelViewMonthlyCalendar");
      this.PanelViewMonthlyCalendar.Name = "PanelViewMonthlyCalendar";
      // 
      // MonthlyCalendar
      // 
      this.MonthlyCalendar.AllowEditingEvents = false;
      this.MonthlyCalendar.BackColor = System.Drawing.Color.White;
      this.MonthlyCalendar.CalendarDate = new System.DateTime(2019, 1, 19, 13, 27, 20, 916);
      this.MonthlyCalendar.CalendarView = CodeProjectCalendar.NET.CalendarViews.Month;
      this.MonthlyCalendar.DateHeaderFont = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MonthlyCalendar.DayOfWeekFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MonthlyCalendar.DaysFont = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MonthlyCalendar.DayViewTimeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MonthlyCalendar.DimDisabledEvents = true;
      resources.ApplyResources(this.MonthlyCalendar, "MonthlyCalendar");
      this.MonthlyCalendar.HighlightCurrentDay = false;
      this.MonthlyCalendar.LoadPresetHolidays = false;
      this.MonthlyCalendar.Name = "MonthlyCalendar";
      this.MonthlyCalendar.ShowArrowControls = true;
      this.MonthlyCalendar.ShowDashedBorderOnDisabledEvents = true;
      this.MonthlyCalendar.ShowDateInHeader = true;
      this.MonthlyCalendar.ShowDisabledEvents = false;
      this.MonthlyCalendar.ShowEventTooltips = true;
      this.MonthlyCalendar.ShowTodayButton = true;
      this.MonthlyCalendar.TodayFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MonthlyCalendar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CalendarMonth_MouseClick);
      this.MonthlyCalendar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CalendarMonth_MouseClick);
      this.MonthlyCalendar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CalendarMonth_MouseMove);
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
      this.PanelViewGrid.Controls.Add(this.DataGridView);
      this.PanelViewGrid.Controls.Add(this.LunisolarDaysBindingNavigator);
      resources.ApplyResources(this.PanelViewGrid, "PanelViewGrid");
      this.PanelViewGrid.Name = "PanelViewGrid";
      // 
      // DataGridView
      // 
      this.DataGridView.AllowUserToAddRows = false;
      this.DataGridView.AllowUserToDeleteRows = false;
      this.DataGridView.AllowUserToResizeRows = false;
      this.DataGridView.AutoGenerateColumns = false;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridColumnDate,
            this.GridColumnLunarMonth,
            this.GridColumnLunarDay,
            this.GridColumnSunrise,
            this.GridColumnSunset,
            this.GridColumnMoonriseOccuring,
            this.GridColumnMoonrise,
            this.GridColumnMoonset,
            this.GridColumnNewMoon,
            this.GridColumnFullMoon,
            this.GridColumnMoonPhase,
            this.GridColumnSeasonChange,
            this.GridColumnTorahEvent});
      this.DataGridView.DataSource = this.LunisolarDaysBindingSource;
      resources.ApplyResources(this.DataGridView, "DataGridView");
      this.DataGridView.EnableHeadersVisualStyles = false;
      this.DataGridView.MultiSelect = false;
      this.DataGridView.Name = "DataGridView";
      this.DataGridView.ReadOnly = true;
      this.DataGridView.RowHeadersVisible = false;
      this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CalendarGrid_CellFormatting);
      // 
      // GridColumnDate
      // 
      this.GridColumnDate.DataPropertyName = "Date";
      resources.ApplyResources(this.GridColumnDate, "GridColumnDate");
      this.GridColumnDate.Name = "GridColumnDate";
      this.GridColumnDate.ReadOnly = true;
      this.GridColumnDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnLunarMonth
      // 
      this.GridColumnLunarMonth.DataPropertyName = "LunarMonth";
      resources.ApplyResources(this.GridColumnLunarMonth, "GridColumnLunarMonth");
      this.GridColumnLunarMonth.Name = "GridColumnLunarMonth";
      this.GridColumnLunarMonth.ReadOnly = true;
      this.GridColumnLunarMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnLunarDay
      // 
      this.GridColumnLunarDay.DataPropertyName = "LunarDay";
      resources.ApplyResources(this.GridColumnLunarDay, "GridColumnLunarDay");
      this.GridColumnLunarDay.Name = "GridColumnLunarDay";
      this.GridColumnLunarDay.ReadOnly = true;
      this.GridColumnLunarDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnSunrise
      // 
      this.GridColumnSunrise.DataPropertyName = "SunriseAsString";
      resources.ApplyResources(this.GridColumnSunrise, "GridColumnSunrise");
      this.GridColumnSunrise.Name = "GridColumnSunrise";
      this.GridColumnSunrise.ReadOnly = true;
      this.GridColumnSunrise.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnSunset
      // 
      this.GridColumnSunset.DataPropertyName = "SunsetAsString";
      resources.ApplyResources(this.GridColumnSunset, "GridColumnSunset");
      this.GridColumnSunset.Name = "GridColumnSunset";
      this.GridColumnSunset.ReadOnly = true;
      this.GridColumnSunset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnMoonriseOccuring
      // 
      this.GridColumnMoonriseOccuring.DataPropertyName = "MoonriseOccurring";
      resources.ApplyResources(this.GridColumnMoonriseOccuring, "GridColumnMoonriseOccuring");
      this.GridColumnMoonriseOccuring.Name = "GridColumnMoonriseOccuring";
      this.GridColumnMoonriseOccuring.ReadOnly = true;
      this.GridColumnMoonriseOccuring.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnMoonrise
      // 
      this.GridColumnMoonrise.DataPropertyName = "MoonriseAsString";
      resources.ApplyResources(this.GridColumnMoonrise, "GridColumnMoonrise");
      this.GridColumnMoonrise.Name = "GridColumnMoonrise";
      this.GridColumnMoonrise.ReadOnly = true;
      this.GridColumnMoonrise.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnMoonset
      // 
      this.GridColumnMoonset.DataPropertyName = "MoonsetAsString";
      resources.ApplyResources(this.GridColumnMoonset, "GridColumnMoonset");
      this.GridColumnMoonset.Name = "GridColumnMoonset";
      this.GridColumnMoonset.ReadOnly = true;
      this.GridColumnMoonset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnNewMoon
      // 
      this.GridColumnNewMoon.DataPropertyName = "IsNewMoon";
      resources.ApplyResources(this.GridColumnNewMoon, "GridColumnNewMoon");
      this.GridColumnNewMoon.Name = "GridColumnNewMoon";
      this.GridColumnNewMoon.ReadOnly = true;
      this.GridColumnNewMoon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnFullMoon
      // 
      this.GridColumnFullMoon.DataPropertyName = "IsFullMoon";
      resources.ApplyResources(this.GridColumnFullMoon, "GridColumnFullMoon");
      this.GridColumnFullMoon.Name = "GridColumnFullMoon";
      this.GridColumnFullMoon.ReadOnly = true;
      this.GridColumnFullMoon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnMoonPhase
      // 
      this.GridColumnMoonPhase.DataPropertyName = "MoonPhase";
      resources.ApplyResources(this.GridColumnMoonPhase, "GridColumnMoonPhase");
      this.GridColumnMoonPhase.Name = "GridColumnMoonPhase";
      this.GridColumnMoonPhase.ReadOnly = true;
      this.GridColumnMoonPhase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnSeasonChange
      // 
      this.GridColumnSeasonChange.DataPropertyName = "SeasonChange";
      resources.ApplyResources(this.GridColumnSeasonChange, "GridColumnSeasonChange");
      this.GridColumnSeasonChange.Name = "GridColumnSeasonChange";
      this.GridColumnSeasonChange.ReadOnly = true;
      this.GridColumnSeasonChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // GridColumnTorahEvent
      // 
      this.GridColumnTorahEvent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.GridColumnTorahEvent.DataPropertyName = "TorahEvent";
      resources.ApplyResources(this.GridColumnTorahEvent, "GridColumnTorahEvent");
      this.GridColumnTorahEvent.Name = "GridColumnTorahEvent";
      this.GridColumnTorahEvent.ReadOnly = true;
      this.GridColumnTorahEvent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // LunisolarDaysBindingSource
      // 
      this.LunisolarDaysBindingSource.DataSource = typeof(Ordisoftware.Hebrew.Calendar.LunisolarDayRow);
      this.LunisolarDaysBindingSource.CurrentItemChanged += new System.EventHandler(this.LunisolarDaysBindingSource_CurrentItemChanged);
      // 
      // LunisolarDaysBindingNavigator
      // 
      this.LunisolarDaysBindingNavigator.AddNewItem = null;
      this.LunisolarDaysBindingNavigator.BindingSource = this.LunisolarDaysBindingSource;
      this.LunisolarDaysBindingNavigator.CountItem = this.BindingNavigatorCountItem;
      this.LunisolarDaysBindingNavigator.DeleteItem = null;
      this.LunisolarDaysBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelGridGoToToday,
            this.bindingNavigatorSeparator1,
            this.BindingNavigatorMoveFirstItem,
            this.BindingNavigatorMovePreviousItem,
            this.BindingNavigatorSeparator2,
            this.BindingNavigatorPositionItem,
            this.BindingNavigatorCountItem,
            this.BindingNavigatorSeparator3,
            this.BindingNavigatorMoveNextItem,
            this.BindingNavigatorMoveLastItem,
            this.BindingNavigatorSeparator4,
            this.EditExportDataEnumsAsTranslations,
            this.LabelEnumsAsTranslations});
      resources.ApplyResources(this.LunisolarDaysBindingNavigator, "LunisolarDaysBindingNavigator");
      this.LunisolarDaysBindingNavigator.MoveFirstItem = this.BindingNavigatorMoveFirstItem;
      this.LunisolarDaysBindingNavigator.MoveLastItem = this.BindingNavigatorMoveLastItem;
      this.LunisolarDaysBindingNavigator.MoveNextItem = this.BindingNavigatorMoveNextItem;
      this.LunisolarDaysBindingNavigator.MovePreviousItem = this.BindingNavigatorMovePreviousItem;
      this.LunisolarDaysBindingNavigator.Name = "LunisolarDaysBindingNavigator";
      this.LunisolarDaysBindingNavigator.PositionItem = this.BindingNavigatorPositionItem;
      // 
      // BindingNavigatorCountItem
      // 
      this.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem";
      resources.ApplyResources(this.BindingNavigatorCountItem, "BindingNavigatorCountItem");
      // 
      // LabelGridGoToToday
      // 
      this.LabelGridGoToToday.Name = "LabelGridGoToToday";
      resources.ApplyResources(this.LabelGridGoToToday, "LabelGridGoToToday");
      this.LabelGridGoToToday.Click += new System.EventHandler(this.LabelGridGoToToday_Click);
      // 
      // bindingNavigatorSeparator1
      // 
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
      // 
      // BindingNavigatorMoveFirstItem
      // 
      this.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.BindingNavigatorMoveFirstItem, "BindingNavigatorMoveFirstItem");
      this.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem";
      // 
      // BindingNavigatorMovePreviousItem
      // 
      this.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.BindingNavigatorMovePreviousItem, "BindingNavigatorMovePreviousItem");
      this.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem";
      // 
      // BindingNavigatorSeparator2
      // 
      this.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2";
      resources.ApplyResources(this.BindingNavigatorSeparator2, "BindingNavigatorSeparator2");
      // 
      // BindingNavigatorPositionItem
      // 
      resources.ApplyResources(this.BindingNavigatorPositionItem, "BindingNavigatorPositionItem");
      this.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem";
      this.BindingNavigatorPositionItem.ReadOnly = true;
      // 
      // BindingNavigatorSeparator3
      // 
      this.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3";
      resources.ApplyResources(this.BindingNavigatorSeparator3, "BindingNavigatorSeparator3");
      // 
      // BindingNavigatorMoveNextItem
      // 
      this.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.BindingNavigatorMoveNextItem, "BindingNavigatorMoveNextItem");
      this.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem";
      // 
      // BindingNavigatorMoveLastItem
      // 
      this.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.BindingNavigatorMoveLastItem, "BindingNavigatorMoveLastItem");
      this.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem";
      // 
      // BindingNavigatorSeparator4
      // 
      this.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4";
      resources.ApplyResources(this.BindingNavigatorSeparator4, "BindingNavigatorSeparator4");
      // 
      // EditExportDataEnumsAsTranslations
      // 
      resources.ApplyResources(this.EditExportDataEnumsAsTranslations, "EditExportDataEnumsAsTranslations");
      this.EditExportDataEnumsAsTranslations.BackColor = System.Drawing.Color.Transparent;
      this.EditExportDataEnumsAsTranslations.Checked = true;
      this.EditExportDataEnumsAsTranslations.Name = "EditExportDataEnumsAsTranslations";
      this.EditExportDataEnumsAsTranslations.CheckedChanged += new System.EventHandler(this.EditExportDataEnumsAsTranslations_CheckedChanged);
      // 
      // LabelEnumsAsTranslations
      // 
      this.LabelEnumsAsTranslations.Name = "LabelEnumsAsTranslations";
      resources.ApplyResources(this.LabelEnumsAsTranslations, "LabelEnumsAsTranslations");
      this.LabelEnumsAsTranslations.Click += new System.EventHandler(this.LabelEnumsAsTranslations_Click);
      // 
      // PanelSepTop
      // 
      resources.ApplyResources(this.PanelSepTop, "PanelSepTop");
      this.PanelSepTop.Name = "PanelSepTop";
      // 
      // PanelTitle
      // 
      this.PanelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.PanelTitle.Controls.Add(this.PanelTitleInner);
      resources.ApplyResources(this.PanelTitle, "PanelTitle");
      this.PanelTitle.Name = "PanelTitle";
      // 
      // PanelTitleInner
      // 
      this.PanelTitleInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.PanelTitleInner.Controls.Add(this.LabelSubTitleGPS);
      this.PanelTitleInner.Controls.Add(this.LabelSubTitleOmer);
      this.PanelTitleInner.Controls.Add(this.LabelSubTitleCalendar);
      resources.ApplyResources(this.PanelTitleInner, "PanelTitleInner");
      this.PanelTitleInner.Name = "PanelTitleInner";
      // 
      // LabelSubTitleGPS
      // 
      this.LabelSubTitleGPS.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelSubTitleGPS, "LabelSubTitleGPS");
      this.LabelSubTitleGPS.Name = "LabelSubTitleGPS";
      // 
      // LabelSubTitleOmer
      // 
      this.LabelSubTitleOmer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelSubTitleOmer, "LabelSubTitleOmer");
      this.LabelSubTitleOmer.Name = "LabelSubTitleOmer";
      // 
      // LabelSubTitleCalendar
      // 
      this.LabelSubTitleCalendar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      resources.ApplyResources(this.LabelSubTitleCalendar, "LabelSubTitleCalendar");
      this.LabelSubTitleCalendar.Name = "LabelSubTitleCalendar";
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
            this.MenuHelp,
            this.MenuInformation,
            this.toolStripSeparator4,
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
      // MenuHelp
      // 
      resources.ApplyResources(this.MenuHelp, "MenuHelp");
      this.MenuHelp.Name = "MenuHelp";
      // 
      // MenuInformation
      // 
      resources.ApplyResources(this.MenuInformation, "MenuInformation");
      this.MenuInformation.Name = "MenuInformation";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
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
      // TimerBalloon
      // 
      this.TimerBalloon.Interval = 1000;
      this.TimerBalloon.Tick += new System.EventHandler(this.TimerBallon_Tick);
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
      // ToolStripTopSeparator2
      // 
      this.ToolStripTopSeparator2.Name = "ToolStripTopSeparator2";
      resources.ApplyResources(this.ToolStripTopSeparator2, "ToolStripTopSeparator2");
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
      // ActionSearchLunarMonth
      // 
      this.ActionSearchLunarMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionSearchLunarMonth, "ActionSearchLunarMonth");
      this.ActionSearchLunarMonth.Name = "ActionSearchLunarMonth";
      this.ActionSearchLunarMonth.Padding = new System.Windows.Forms.Padding(5);
      this.ActionSearchLunarMonth.Click += new System.EventHandler(this.ActionSearchMonth_Click);
      this.ActionSearchLunarMonth.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionSearchLunarMonth.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
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
      // ToolStripTopSeparator3
      // 
      this.ToolStripTopSeparator3.Name = "ToolStripTopSeparator3";
      resources.ApplyResources(this.ToolStripTopSeparator3, "ToolStripTopSeparator3");
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
      // ActionViewNextCelebrations
      // 
      this.ActionViewNextCelebrations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.ActionViewNextCelebrations, "ActionViewNextCelebrations");
      this.ActionViewNextCelebrations.Name = "ActionViewNextCelebrations";
      this.ActionViewNextCelebrations.Padding = new System.Windows.Forms.Padding(5);
      this.ActionViewNextCelebrations.Click += new System.EventHandler(this.ActionViewCelebrations_Click);
      this.ActionViewNextCelebrations.MouseEnter += new System.EventHandler(this.ShowToolTip_OnMouseEnter);
      this.ActionViewNextCelebrations.MouseLeave += new System.EventHandler(this.ShowToolTip_OnMouseLeave);
      // 
      // ToolStripTopSeparator4
      // 
      this.ToolStripTopSeparator4.Name = "ToolStripTopSeparator4";
      resources.ApplyResources(this.ToolStripTopSeparator4, "ToolStripTopSeparator4");
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
      // ToolStripTopSeparator5
      // 
      this.ToolStripTopSeparator5.Name = "ToolStripTopSeparator5";
      resources.ApplyResources(this.ToolStripTopSeparator5, "ToolStripTopSeparator5");
      // 
      // ActionTools
      // 
      this.ActionTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionShowShabatVerses,
            this.WeeklyParashahSeparator,
            this.ActionWeeklyParashah,
            this.toolStripSeparator5,
            this.ActionShowParashotBoard,
            this.ActionShowCelebrationVersesBoard,
            this.ActionShowCelebrationsBoard,
            this.ActionShowNewMoonsBoard,
            this.ActionShowLunarMonths,
            this.toolStripSeparator8,
            this.ActionManageBookmarks,
            this.toolStripSeparator11,
            this.ActionCalculateDateDiff,
            this.toolStripSeparator10,
            this.ActionOpenSystemDateAndTime,
            this.ActionOpenCalculator,
            this.toolStripSeparator29,
            this.ActionTakeScreenshotWindow,
            this.ActionTakeScreenshotView,
            this.SeparatorMenuWeather,
            this.ActionLocalWeather,
            this.ActionOnlineWeather,
            this.toolStripSeparator9,
            this.ActionOpenFolderExport,
            this.ActionOpenFolderDatabase,
            this.toolStripSeparator26,
            this.ActionGenerate,
            this.toolStripSeparator23,
            this.ActionVacuumDB});
      resources.ApplyResources(this.ActionTools, "ActionTools");
      this.ActionTools.Name = "ActionTools";
      this.ActionTools.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionShowShabatVerses
      // 
      resources.ApplyResources(this.ActionShowShabatVerses, "ActionShowShabatVerses");
      this.ActionShowShabatVerses.Name = "ActionShowShabatVerses";
      this.ActionShowShabatVerses.Click += new System.EventHandler(this.ActionShowShabatVerses_Click);
      // 
      // WeeklyParashahSeparator
      // 
      this.WeeklyParashahSeparator.Name = "WeeklyParashahSeparator";
      resources.ApplyResources(this.WeeklyParashahSeparator, "WeeklyParashahSeparator");
      // 
      // ActionWeeklyParashah
      // 
      this.ActionWeeklyParashah.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionWeeklyParashahDescription,
            this.toolStripSeparator13,
            this.ActionParashahReadDefault,
            this.ActionWeeklyParashahReadOnline,
            this.ActionWeeklyParashahStudyOnline,
            this.toolStripSeparator1,
            this.ActionWeeklyParashahOpenWithHebrewWords});
      resources.ApplyResources(this.ActionWeeklyParashah, "ActionWeeklyParashah");
      this.ActionWeeklyParashah.Name = "ActionWeeklyParashah";
      // 
      // ActionWeeklyParashahDescription
      // 
      resources.ApplyResources(this.ActionWeeklyParashahDescription, "ActionWeeklyParashahDescription");
      this.ActionWeeklyParashahDescription.Name = "ActionWeeklyParashahDescription";
      this.ActionWeeklyParashahDescription.Click += new System.EventHandler(this.ActionViewParashahInfos_Click);
      // 
      // toolStripSeparator13
      // 
      this.toolStripSeparator13.Name = "toolStripSeparator13";
      resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
      // 
      // ActionParashahReadDefault
      // 
      resources.ApplyResources(this.ActionParashahReadDefault, "ActionParashahReadDefault");
      this.ActionParashahReadDefault.Name = "ActionParashahReadDefault";
      this.ActionParashahReadDefault.Click += new System.EventHandler(this.ActionParashahReadDefault_Click);
      // 
      // ActionWeeklyParashahReadOnline
      // 
      resources.ApplyResources(this.ActionWeeklyParashahReadOnline, "ActionWeeklyParashahReadOnline");
      this.ActionWeeklyParashahReadOnline.Name = "ActionWeeklyParashahReadOnline";
      // 
      // ActionWeeklyParashahStudyOnline
      // 
      resources.ApplyResources(this.ActionWeeklyParashahStudyOnline, "ActionWeeklyParashahStudyOnline");
      this.ActionWeeklyParashahStudyOnline.Name = "ActionWeeklyParashahStudyOnline";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // ActionWeeklyParashahOpenWithHebrewWords
      // 
      resources.ApplyResources(this.ActionWeeklyParashahOpenWithHebrewWords, "ActionWeeklyParashahOpenWithHebrewWords");
      this.ActionWeeklyParashahOpenWithHebrewWords.Name = "ActionWeeklyParashahOpenWithHebrewWords";
      this.ActionWeeklyParashahOpenWithHebrewWords.Click += new System.EventHandler(this.ActionOpenHebrewWordsVerse_Click);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // ActionShowParashotBoard
      // 
      resources.ApplyResources(this.ActionShowParashotBoard, "ActionShowParashotBoard");
      this.ActionShowParashotBoard.Name = "ActionShowParashotBoard";
      this.ActionShowParashotBoard.Click += new System.EventHandler(this.ActionShowParashot_Click);
      // 
      // ActionShowCelebrationVersesBoard
      // 
      resources.ApplyResources(this.ActionShowCelebrationVersesBoard, "ActionShowCelebrationVersesBoard");
      this.ActionShowCelebrationVersesBoard.Name = "ActionShowCelebrationVersesBoard";
      this.ActionShowCelebrationVersesBoard.Click += new System.EventHandler(this.ActionShowCelebrationVersesBoard_Click);
      // 
      // ActionShowCelebrationsBoard
      // 
      resources.ApplyResources(this.ActionShowCelebrationsBoard, "ActionShowCelebrationsBoard");
      this.ActionShowCelebrationsBoard.Name = "ActionShowCelebrationsBoard";
      this.ActionShowCelebrationsBoard.Click += new System.EventHandler(this.ActionShowCelebrationsBoard_Click);
      // 
      // ActionShowNewMoonsBoard
      // 
      resources.ApplyResources(this.ActionShowNewMoonsBoard, "ActionShowNewMoonsBoard");
      this.ActionShowNewMoonsBoard.Name = "ActionShowNewMoonsBoard";
      this.ActionShowNewMoonsBoard.Click += new System.EventHandler(this.ActionShowMoonsBoard_Click);
      // 
      // ActionShowLunarMonths
      // 
      resources.ApplyResources(this.ActionShowLunarMonths, "ActionShowLunarMonths");
      this.ActionShowLunarMonths.Name = "ActionShowLunarMonths";
      this.ActionShowLunarMonths.Click += new System.EventHandler(this.ActionShowLunarMonths_Click);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
      // 
      // ActionManageBookmarks
      // 
      resources.ApplyResources(this.ActionManageBookmarks, "ActionManageBookmarks");
      this.ActionManageBookmarks.Name = "ActionManageBookmarks";
      this.ActionManageBookmarks.Click += new System.EventHandler(this.ActionManageBookmark_Click);
      // 
      // toolStripSeparator11
      // 
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
      // 
      // ActionCalculateDateDiff
      // 
      resources.ApplyResources(this.ActionCalculateDateDiff, "ActionCalculateDateDiff");
      this.ActionCalculateDateDiff.Name = "ActionCalculateDateDiff";
      this.ActionCalculateDateDiff.Click += new System.EventHandler(this.ActionCalculateDateDiff_Click);
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
      // 
      // ActionOpenSystemDateAndTime
      // 
      this.ActionOpenSystemDateAndTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionOpenSystemDateAndTime, "ActionOpenSystemDateAndTime");
      this.ActionOpenSystemDateAndTime.Name = "ActionOpenSystemDateAndTime";
      this.ActionOpenSystemDateAndTime.Click += new System.EventHandler(this.ActionOpenSystemDateAndTime_Click);
      // 
      // ActionOpenCalculator
      // 
      this.ActionOpenCalculator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.ActionOpenCalculator, "ActionOpenCalculator");
      this.ActionOpenCalculator.Name = "ActionOpenCalculator";
      this.ActionOpenCalculator.Click += new System.EventHandler(this.ActionOpenCalculator_Click);
      // 
      // toolStripSeparator29
      // 
      this.toolStripSeparator29.Name = "toolStripSeparator29";
      resources.ApplyResources(this.toolStripSeparator29, "toolStripSeparator29");
      // 
      // ActionTakeScreenshotWindow
      // 
      resources.ApplyResources(this.ActionTakeScreenshotWindow, "ActionTakeScreenshotWindow");
      this.ActionTakeScreenshotWindow.Name = "ActionTakeScreenshotWindow";
      this.ActionTakeScreenshotWindow.Click += new System.EventHandler(this.ActionTakeScreenshotWindow_Click);
      // 
      // ActionTakeScreenshotView
      // 
      resources.ApplyResources(this.ActionTakeScreenshotView, "ActionTakeScreenshotView");
      this.ActionTakeScreenshotView.Name = "ActionTakeScreenshotView";
      this.ActionTakeScreenshotView.Click += new System.EventHandler(this.ActionTakeScreenshotView_Click);
      // 
      // SeparatorMenuWeather
      // 
      this.SeparatorMenuWeather.Name = "SeparatorMenuWeather";
      resources.ApplyResources(this.SeparatorMenuWeather, "SeparatorMenuWeather");
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
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
      // 
      // ActionOpenFolderExport
      // 
      resources.ApplyResources(this.ActionOpenFolderExport, "ActionOpenFolderExport");
      this.ActionOpenFolderExport.Name = "ActionOpenFolderExport";
      this.ActionOpenFolderExport.Click += new System.EventHandler(this.ActionOpenFolderExport_Click);
      // 
      // ActionOpenFolderDatabase
      // 
      resources.ApplyResources(this.ActionOpenFolderDatabase, "ActionOpenFolderDatabase");
      this.ActionOpenFolderDatabase.Name = "ActionOpenFolderDatabase";
      this.ActionOpenFolderDatabase.Click += new System.EventHandler(this.ActionOpenFolderDatabase_Click);
      // 
      // toolStripSeparator26
      // 
      this.toolStripSeparator26.Name = "toolStripSeparator26";
      resources.ApplyResources(this.toolStripSeparator26, "toolStripSeparator26");
      // 
      // ActionGenerate
      // 
      resources.ApplyResources(this.ActionGenerate, "ActionGenerate");
      this.ActionGenerate.Name = "ActionGenerate";
      this.ActionGenerate.Click += new System.EventHandler(this.ActionGenerate_Click);
      // 
      // toolStripSeparator23
      // 
      this.toolStripSeparator23.Name = "toolStripSeparator23";
      resources.ApplyResources(this.toolStripSeparator23, "toolStripSeparator23");
      // 
      // ActionVacuumDB
      // 
      resources.ApplyResources(this.ActionVacuumDB, "ActionVacuumDB");
      this.ActionVacuumDB.Name = "ActionVacuumDB";
      this.ActionVacuumDB.Click += new System.EventHandler(this.ActionVacuumDB_Click);
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
            this.ActionScreenPosition,
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
      // ActionScreenPosition
      // 
      this.ActionScreenPosition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditScreenNone,
            this.EditScreenTopLeft,
            this.EditScreenTopRight,
            this.EditScreenBottomLeft,
            this.EditScreenBottomRight,
            this.EditScreenCenter});
      resources.ApplyResources(this.ActionScreenPosition, "ActionScreenPosition");
      this.ActionScreenPosition.Name = "ActionScreenPosition";
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
      // ActionSelectView
      // 
      this.ActionSelectView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionSelectView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionViewReport,
            this.ActionViewMonth,
            this.ActionViewGrid});
      resources.ApplyResources(this.ActionSelectView, "ActionSelectView");
      this.ActionSelectView.Name = "ActionSelectView";
      this.ActionSelectView.Padding = new System.Windows.Forms.Padding(5);
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
            this.ActionSelectView,
            this.ToolStripTopSeparator1,
            this.ActionSaveToFile,
            this.ActionCopyToClipboard,
            this.ActionPrint,
            this.ToolStripTopSeparator2,
            this.ActionSearchEvent,
            this.ActionSearchLunarMonth,
            this.ActionSearchGregorianMonth,
            this.ActionSearchDay,
            this.ToolStripTopSeparator3,
            this.ActionNavigate,
            this.ActionViewNextCelebrations,
            this.ToolStripTopSeparator4,
            this.ActionExit,
            this.ActionResetReminder,
            this.ActionDisableReminder,
            this.ActionEnableReminder,
            this.ToolStripTopSeparator5,
            this.ActionTools,
            this.ActionWebLinks,
            this.ActionHelp,
            this.ActionInformation,
            this.ToolStripTopSeparator6,
            this.ActionPreferences,
            this.ActionSettings,
            this.MainMenuSeparatorLeftButtons});
      resources.ApplyResources(this.ToolStrip, "ToolStrip");
      this.ToolStrip.Name = "ToolStrip";
      this.ToolStrip.ShowItemToolTips = false;
      // 
      // ToolStripTopSeparator1
      // 
      this.ToolStripTopSeparator1.Name = "ToolStripTopSeparator1";
      resources.ApplyResources(this.ToolStripTopSeparator1, "ToolStripTopSeparator1");
      // 
      // ActionHelp
      // 
      this.ActionHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ActionHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionShowNotices,
            this.toolStripSeparator7,
            this.ActionShowTranscriptionGuide,
            this.ActionShowGrammarGuide});
      resources.ApplyResources(this.ActionHelp, "ActionHelp");
      this.ActionHelp.Name = "ActionHelp";
      this.ActionHelp.Padding = new System.Windows.Forms.Padding(5);
      // 
      // ActionShowNotices
      // 
      resources.ApplyResources(this.ActionShowNotices, "ActionShowNotices");
      this.ActionShowNotices.Name = "ActionShowNotices";
      this.ActionShowNotices.Click += new System.EventHandler(this.ActionShowNotices_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      // 
      // ActionShowTranscriptionGuide
      // 
      resources.ApplyResources(this.ActionShowTranscriptionGuide, "ActionShowTranscriptionGuide");
      this.ActionShowTranscriptionGuide.Name = "ActionShowTranscriptionGuide";
      this.ActionShowTranscriptionGuide.Click += new System.EventHandler(this.ActionShowTranscriptionGuide_Click);
      // 
      // ActionShowGrammarGuide
      // 
      resources.ApplyResources(this.ActionShowGrammarGuide, "ActionShowGrammarGuide");
      this.ActionShowGrammarGuide.Name = "ActionShowGrammarGuide";
      this.ActionShowGrammarGuide.Click += new System.EventHandler(this.ActionShowGrammarGuide_Click);
      // 
      // ToolStripTopSeparator6
      // 
      this.ToolStripTopSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ToolStripTopSeparator6.Name = "ToolStripTopSeparator6";
      resources.ApplyResources(this.ToolStripTopSeparator6, "ToolStripTopSeparator6");
      // 
      // MainMenuSeparatorLeftButtons
      // 
      this.MainMenuSeparatorLeftButtons.Name = "MainMenuSeparatorLeftButtons";
      this.MainMenuSeparatorLeftButtons.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
      resources.ApplyResources(this.MainMenuSeparatorLeftButtons, "MainMenuSeparatorLeftButtons");
      // 
      // TimerUpdateTitles
      // 
      this.TimerUpdateTitles.Interval = 60000;
      this.TimerUpdateTitles.Tick += new System.EventHandler(this.TimerUpdateTitles_Tick);
      // 
      // ContextMenuStripDay
      // 
      this.ContextMenuStripDay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuDayDate,
            this.toolStripSeparator15,
            this.ContextMenuDaySunrise,
            this.ContextMenuDaySunset,
            this.ContextMenuSunMoonSeparator,
            this.ContextMenuDayMoonrise,
            this.ContextMenuDayMoonset,
            this.ContextMenuDayTimesSeparator,
            this.ContextMenuShabatVerses,
            this.ContextMenuParashahSeparator,
            this.ContextMenuDayParashah,
            this.toolStripSeparator18,
            this.ContextMenuDayCelebrationVersesBoard,
            this.toolStripSeparator12,
            this.ContextMenuDaySetAsActive,
            this.toolStripSeparator19,
            this.ContextMenuDaySelectDate,
            this.ContextMenuDayClearSelection,
            this.toolStripSeparator14,
            this.ContextMenuDayGoToToday,
            this.ContextMenuDayGoToSelected,
            this.toolStripSeparator20,
            this.ContextMenuDayGoToBookmark,
            this.ContextMenuDaySaveBookmark,
            this.ContextMenuDayManageBookmark,
            this.toolStripSeparator21,
            this.ContextMenuDayDatesDiffToToday,
            this.ContextMenuDayDatesDiffToSelected,
            this.ContextMenuDayDatesDiffToActive,
            this.toolStripSeparator17,
            this.ContextMenuDayNavigation});
      this.ContextMenuStripDay.Name = "ContextMenuStripDay";
      resources.ApplyResources(this.ContextMenuStripDay, "ContextMenuStripDay");
      this.ContextMenuStripDay.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.ContextMenuStripDay_Closing);
      this.ContextMenuStripDay.Opened += new System.EventHandler(this.ContextMenuStripDay_Opened);
      // 
      // ContextMenuDayDate
      // 
      resources.ApplyResources(this.ContextMenuDayDate, "ContextMenuDayDate");
      this.ContextMenuDayDate.Name = "ContextMenuDayDate";
      this.ContextMenuDayDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContextMenuDayDate_MouseDown);
      // 
      // toolStripSeparator15
      // 
      this.toolStripSeparator15.Name = "toolStripSeparator15";
      resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
      // 
      // ContextMenuDaySunrise
      // 
      this.ContextMenuDaySunrise.Name = "ContextMenuDaySunrise";
      resources.ApplyResources(this.ContextMenuDaySunrise, "ContextMenuDaySunrise");
      this.ContextMenuDaySunrise.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContextMenuDayDate_MouseDown);
      // 
      // ContextMenuDaySunset
      // 
      this.ContextMenuDaySunset.Name = "ContextMenuDaySunset";
      resources.ApplyResources(this.ContextMenuDaySunset, "ContextMenuDaySunset");
      this.ContextMenuDaySunset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContextMenuDayDate_MouseDown);
      // 
      // ContextMenuSunMoonSeparator
      // 
      this.ContextMenuSunMoonSeparator.Name = "ContextMenuSunMoonSeparator";
      resources.ApplyResources(this.ContextMenuSunMoonSeparator, "ContextMenuSunMoonSeparator");
      // 
      // ContextMenuDayMoonrise
      // 
      this.ContextMenuDayMoonrise.Name = "ContextMenuDayMoonrise";
      resources.ApplyResources(this.ContextMenuDayMoonrise, "ContextMenuDayMoonrise");
      this.ContextMenuDayMoonrise.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContextMenuDayDate_MouseDown);
      // 
      // ContextMenuDayMoonset
      // 
      this.ContextMenuDayMoonset.Name = "ContextMenuDayMoonset";
      resources.ApplyResources(this.ContextMenuDayMoonset, "ContextMenuDayMoonset");
      this.ContextMenuDayMoonset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContextMenuDayDate_MouseDown);
      // 
      // ContextMenuDayTimesSeparator
      // 
      this.ContextMenuDayTimesSeparator.Name = "ContextMenuDayTimesSeparator";
      resources.ApplyResources(this.ContextMenuDayTimesSeparator, "ContextMenuDayTimesSeparator");
      // 
      // ContextMenuShabatVerses
      // 
      resources.ApplyResources(this.ContextMenuShabatVerses, "ContextMenuShabatVerses");
      this.ContextMenuShabatVerses.Name = "ContextMenuShabatVerses";
      this.ContextMenuShabatVerses.Click += new System.EventHandler(this.ActionShowShabatVerses_Click);
      // 
      // ContextMenuParashahSeparator
      // 
      this.ContextMenuParashahSeparator.Name = "ContextMenuParashahSeparator";
      resources.ApplyResources(this.ContextMenuParashahSeparator, "ContextMenuParashahSeparator");
      // 
      // ContextMenuDayParashah
      // 
      this.ContextMenuDayParashah.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuDayParashahDescription,
            this.toolStripSeparator24,
            this.ContextMenuParashahReadDefault,
            this.ContextMenuDayParashahReadOnline,
            this.ContextMenuDayParashahStudyOnline,
            this.toolStripSeparator22,
            this.ContextMenuOpenWithHebrewWords,
            this.toolStripSeparator16,
            this.ContextMenuDayParashotBoard});
      resources.ApplyResources(this.ContextMenuDayParashah, "ContextMenuDayParashah");
      this.ContextMenuDayParashah.Name = "ContextMenuDayParashah";
      // 
      // ContextMenuDayParashahDescription
      // 
      resources.ApplyResources(this.ContextMenuDayParashahDescription, "ContextMenuDayParashahDescription");
      this.ContextMenuDayParashahDescription.Name = "ContextMenuDayParashahDescription";
      this.ContextMenuDayParashahDescription.Click += new System.EventHandler(this.ContextMenuDayParashah_Click);
      // 
      // toolStripSeparator24
      // 
      this.toolStripSeparator24.Name = "toolStripSeparator24";
      resources.ApplyResources(this.toolStripSeparator24, "toolStripSeparator24");
      // 
      // ContextMenuParashahReadDefault
      // 
      resources.ApplyResources(this.ContextMenuParashahReadDefault, "ContextMenuParashahReadDefault");
      this.ContextMenuParashahReadDefault.Name = "ContextMenuParashahReadDefault";
      this.ContextMenuParashahReadDefault.Click += new System.EventHandler(this.ContextMenuParashahReadDefault_Click);
      // 
      // ContextMenuDayParashahReadOnline
      // 
      resources.ApplyResources(this.ContextMenuDayParashahReadOnline, "ContextMenuDayParashahReadOnline");
      this.ContextMenuDayParashahReadOnline.Name = "ContextMenuDayParashahReadOnline";
      // 
      // ContextMenuDayParashahStudyOnline
      // 
      resources.ApplyResources(this.ContextMenuDayParashahStudyOnline, "ContextMenuDayParashahStudyOnline");
      this.ContextMenuDayParashahStudyOnline.Name = "ContextMenuDayParashahStudyOnline";
      // 
      // toolStripSeparator22
      // 
      this.toolStripSeparator22.Name = "toolStripSeparator22";
      resources.ApplyResources(this.toolStripSeparator22, "toolStripSeparator22");
      // 
      // ContextMenuOpenWithHebrewWords
      // 
      resources.ApplyResources(this.ContextMenuOpenWithHebrewWords, "ContextMenuOpenWithHebrewWords");
      this.ContextMenuOpenWithHebrewWords.Name = "ContextMenuOpenWithHebrewWords";
      this.ContextMenuOpenWithHebrewWords.Click += new System.EventHandler(this.ContextMenuOpenHebrewWordsVerse_Click);
      // 
      // toolStripSeparator16
      // 
      this.toolStripSeparator16.Name = "toolStripSeparator16";
      resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
      // 
      // ContextMenuDayParashotBoard
      // 
      resources.ApplyResources(this.ContextMenuDayParashotBoard, "ContextMenuDayParashotBoard");
      this.ContextMenuDayParashotBoard.Name = "ContextMenuDayParashotBoard";
      this.ContextMenuDayParashotBoard.Click += new System.EventHandler(this.ContextMenuDayParashah_Click);
      // 
      // toolStripSeparator18
      // 
      this.toolStripSeparator18.Name = "toolStripSeparator18";
      resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
      // 
      // ContextMenuDayCelebrationVersesBoard
      // 
      resources.ApplyResources(this.ContextMenuDayCelebrationVersesBoard, "ContextMenuDayCelebrationVersesBoard");
      this.ContextMenuDayCelebrationVersesBoard.Name = "ContextMenuDayCelebrationVersesBoard";
      this.ContextMenuDayCelebrationVersesBoard.Click += new System.EventHandler(this.ContextMenuDayCelebrationVersesBoard_Click);
      // 
      // toolStripSeparator12
      // 
      this.toolStripSeparator12.Name = "toolStripSeparator12";
      resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
      // 
      // ContextMenuDaySetAsActive
      // 
      resources.ApplyResources(this.ContextMenuDaySetAsActive, "ContextMenuDaySetAsActive");
      this.ContextMenuDaySetAsActive.Name = "ContextMenuDaySetAsActive";
      this.ContextMenuDaySetAsActive.Click += new System.EventHandler(this.ContextMenuDaySetAsActive_Click);
      // 
      // toolStripSeparator19
      // 
      this.toolStripSeparator19.Name = "toolStripSeparator19";
      resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
      // 
      // ContextMenuDaySelectDate
      // 
      resources.ApplyResources(this.ContextMenuDaySelectDate, "ContextMenuDaySelectDate");
      this.ContextMenuDaySelectDate.Name = "ContextMenuDaySelectDate";
      this.ContextMenuDaySelectDate.Click += new System.EventHandler(this.ContextMenuDaySelect_Click);
      // 
      // ContextMenuDayClearSelection
      // 
      resources.ApplyResources(this.ContextMenuDayClearSelection, "ContextMenuDayClearSelection");
      this.ContextMenuDayClearSelection.Name = "ContextMenuDayClearSelection";
      this.ContextMenuDayClearSelection.Click += new System.EventHandler(this.ContextMenuDayClearSelection_Click);
      // 
      // toolStripSeparator14
      // 
      this.toolStripSeparator14.Name = "toolStripSeparator14";
      resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
      // 
      // ContextMenuDayGoToToday
      // 
      resources.ApplyResources(this.ContextMenuDayGoToToday, "ContextMenuDayGoToToday");
      this.ContextMenuDayGoToToday.Name = "ContextMenuDayGoToToday";
      this.ContextMenuDayGoToToday.Click += new System.EventHandler(this.ContextMenuDayGoToToday_Click);
      // 
      // ContextMenuDayGoToSelected
      // 
      resources.ApplyResources(this.ContextMenuDayGoToSelected, "ContextMenuDayGoToSelected");
      this.ContextMenuDayGoToSelected.Name = "ContextMenuDayGoToSelected";
      this.ContextMenuDayGoToSelected.Click += new System.EventHandler(this.ContextMenuDayGoToSelected_Click);
      // 
      // toolStripSeparator20
      // 
      this.toolStripSeparator20.Name = "toolStripSeparator20";
      resources.ApplyResources(this.toolStripSeparator20, "toolStripSeparator20");
      // 
      // ContextMenuDayGoToBookmark
      // 
      resources.ApplyResources(this.ContextMenuDayGoToBookmark, "ContextMenuDayGoToBookmark");
      this.ContextMenuDayGoToBookmark.Name = "ContextMenuDayGoToBookmark";
      // 
      // ContextMenuDaySaveBookmark
      // 
      resources.ApplyResources(this.ContextMenuDaySaveBookmark, "ContextMenuDaySaveBookmark");
      this.ContextMenuDaySaveBookmark.Name = "ContextMenuDaySaveBookmark";
      this.ContextMenuDaySaveBookmark.Click += new System.EventHandler(this.ContextMenuDaySaveBookmark_Click);
      // 
      // ContextMenuDayManageBookmark
      // 
      resources.ApplyResources(this.ContextMenuDayManageBookmark, "ContextMenuDayManageBookmark");
      this.ContextMenuDayManageBookmark.Name = "ContextMenuDayManageBookmark";
      this.ContextMenuDayManageBookmark.Click += new System.EventHandler(this.ActionManageBookmark_Click);
      // 
      // toolStripSeparator21
      // 
      this.toolStripSeparator21.Name = "toolStripSeparator21";
      resources.ApplyResources(this.toolStripSeparator21, "toolStripSeparator21");
      // 
      // ContextMenuDayDatesDiffToToday
      // 
      resources.ApplyResources(this.ContextMenuDayDatesDiffToToday, "ContextMenuDayDatesDiffToToday");
      this.ContextMenuDayDatesDiffToToday.Name = "ContextMenuDayDatesDiffToToday";
      this.ContextMenuDayDatesDiffToToday.Click += new System.EventHandler(this.ContextMenuDayDatesDiffToToday_Click);
      // 
      // ContextMenuDayDatesDiffToSelected
      // 
      resources.ApplyResources(this.ContextMenuDayDatesDiffToSelected, "ContextMenuDayDatesDiffToSelected");
      this.ContextMenuDayDatesDiffToSelected.Name = "ContextMenuDayDatesDiffToSelected";
      this.ContextMenuDayDatesDiffToSelected.Click += new System.EventHandler(this.ContextMenuDayDatesDiffToSelected_Click);
      // 
      // toolStripSeparator17
      // 
      this.toolStripSeparator17.Name = "toolStripSeparator17";
      resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
      // 
      // ContextMenuDayNavigation
      // 
      resources.ApplyResources(this.ContextMenuDayNavigation, "ContextMenuDayNavigation");
      this.ContextMenuDayNavigation.Name = "ContextMenuDayNavigation";
      this.ContextMenuDayNavigation.Click += new System.EventHandler(this.ContextMenuDayNavigation_Click);
      // 
      // ImageListRisesAndSets
      // 
      this.ImageListRisesAndSets.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListRisesAndSets.ImageStream")));
      this.ImageListRisesAndSets.TransparentColor = System.Drawing.Color.White;
      this.ImageListRisesAndSets.Images.SetKeyName(0, "316109_sunrise_icon16.png");
      this.ImageListRisesAndSets.Images.SetKeyName(1, "316110_sunset_icon16.png");
      this.ImageListRisesAndSets.Images.SetKeyName(2, "316121_moonrise_icon16.png");
      this.ImageListRisesAndSets.Images.SetKeyName(3, "316122_moonset_icon16.png");
      // 
      // MenuBookmarks
      // 
      this.MenuBookmarks.Name = "MenuBookmarks";
      this.MenuBookmarks.ShowImageMargin = false;
      resources.ApplyResources(this.MenuBookmarks, "MenuBookmarks");
      // 
      // ContextMenuDayDatesDiffToActive
      // 
      resources.ApplyResources(this.ContextMenuDayDatesDiffToActive, "ContextMenuDayDatesDiffToActive");
      this.ContextMenuDayDatesDiffToActive.Name = "ContextMenuDayDatesDiffToActive";
      this.ContextMenuDayDatesDiffToActive.Click += new System.EventHandler(this.ContextMenuDayDatesDiffToActive_Click);
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMainOuter1);
      this.Controls.Add(this.ToolStrip);
      this.Name = "MainForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.ClientSizeChanged += new System.EventHandler(this.MainForm_WindowsChanged);
      this.LocationChanged += new System.EventHandler(this.MainForm_WindowsChanged);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.PanelMainOuter1.ResumeLayout(false);
      this.PanelMainOuter2.ResumeLayout(false);
      this.PanelMainInner1.ResumeLayout(false);
      this.PanelMainInner2.ResumeLayout(false);
      this.TabControl.ResumeLayout(false);
      this.TabPageTextReport.ResumeLayout(false);
      this.PanelViewTextReport.ResumeLayout(false);
      this.TabPageMonthlyCalendar.ResumeLayout(false);
      this.PanelViewMonthlyCalendar.ResumeLayout(false);
      this.TabPageGrid.ResumeLayout(false);
      this.PanelViewGrid.ResumeLayout(false);
      this.PanelViewGrid.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LunisolarDaysBindingNavigator)).EndInit();
      this.LunisolarDaysBindingNavigator.ResumeLayout(false);
      this.LunisolarDaysBindingNavigator.PerformLayout();
      this.PanelTitle.ResumeLayout(false);
      this.PanelTitleInner.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.moonPhaseImagePictureBox)).EndInit();
      this.MenuTray.ResumeLayout(false);
      this.ToolStrip.ResumeLayout(false);
      this.ToolStrip.PerformLayout();
      this.ContextMenuStripDay.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.SaveFileDialog SaveReportDialog;
    private System.Windows.Forms.Panel PanelMainOuter1;
    private System.Windows.Forms.Panel PanelSepTop;
    private System.Windows.Forms.Panel PanelTitle;
    private System.Windows.Forms.Panel PanelMainOuter2;
    private System.Windows.Forms.Panel PanelMainInner1;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageTextReport;
    private System.Windows.Forms.Panel PanelViewTextReport;
    public System.Windows.Forms.RichTextBox TextReport;
    private System.Windows.Forms.TabPage TabPageGrid;
    internal System.Windows.Forms.Panel PanelViewGrid;
    private System.Windows.Forms.PictureBox moonPhaseImagePictureBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel PanelMainInner2;
    private System.Windows.Forms.Timer TimerTooltip;
    private System.Windows.Forms.DataGridView DataGridView;
    public System.Windows.Forms.SaveFileDialog SaveGridDialog;
    private System.Windows.Forms.NotifyIcon TrayIcon;
    public System.Windows.Forms.ToolStripMenuItem MenuShowHide;
    private System.Windows.Forms.ToolStripMenuItem MenuNavigate;
    private System.Windows.Forms.ToolStripMenuItem MenuCelebrations;
    private System.Windows.Forms.ToolStripSeparator SeparatorTrayMenu3;
    private System.Windows.Forms.ToolStripMenuItem MenuInformation;
    private System.Windows.Forms.ToolStripMenuItem MenuExit;
    private System.Windows.Forms.TabPage TabPageMonthlyCalendar;
    public global::CodeProjectCalendar.NET.Calendar MonthlyCalendar;
    public System.Windows.Forms.Panel PanelViewMonthlyCalendar;
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
    private System.Windows.Forms.FolderBrowserDialog SelectImagesFolderDialog;
    private System.Windows.Forms.ToolStripButton ActionSaveToFile;
    private System.Windows.Forms.ToolStripButton ActionCopyToClipboard;
    private System.Windows.Forms.ToolStripButton ActionPrint;
    private System.Windows.Forms.ToolStripSeparator ToolStripTopSeparator2;
    private System.Windows.Forms.ToolStripButton ActionSearchEvent;
    private System.Windows.Forms.ToolStripButton ActionSearchLunarMonth;
    private System.Windows.Forms.ToolStripButton ActionSearchGregorianMonth;
    private System.Windows.Forms.ToolStripButton ActionSearchDay;
    private System.Windows.Forms.ToolStripSeparator ToolStripTopSeparator3;
    private System.Windows.Forms.ToolStripSeparator ToolStripTopSeparator4;
    private System.Windows.Forms.ToolStripButton ActionExit;
    public System.Windows.Forms.ToolStripDropDownButton ActionInformation;
    internal System.Windows.Forms.ToolStripButton ActionResetReminder;
    private System.Windows.Forms.ToolStripButton ActionDisableReminder;
    private System.Windows.Forms.ToolStripButton ActionEnableReminder;
    private System.Windows.Forms.ToolStripSeparator ToolStripTopSeparator5;
    private System.Windows.Forms.ToolStripDropDownButton ActionTools;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    internal System.Windows.Forms.ToolStripMenuItem ActionOpenCalculator;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenSystemDateAndTime;
    private System.Windows.Forms.ToolStripMenuItem ActionOpenFolderExport;
    internal System.Windows.Forms.ToolStripMenuItem ActionGenerate;
    private System.Windows.Forms.ToolStripMenuItem ActionVacuumDB;
    private System.Windows.Forms.ToolStripDropDownButton ActionWebLinks;
    internal System.Windows.Forms.ToolStripButton ActionPreferences;
    private System.Windows.Forms.ToolStripDropDownButton ActionSettings;
    private System.Windows.Forms.ToolStripMenuItem ActionScreenPosition;
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
    private System.Windows.Forms.ToolStripDropDownButton ActionSelectView;
    private System.Windows.Forms.ToolStripMenuItem ActionViewReport;
    private System.Windows.Forms.ToolStripMenuItem ActionViewMonth;
    private System.Windows.Forms.ToolStripMenuItem ActionViewGrid;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripSeparator ToolStripTopSeparator1;
    private System.Windows.Forms.ToolStripSeparator ToolStripTopSeparator6;
    public System.Windows.Forms.ToolStripSeparator SeparatorMenuWeather;
    public System.Windows.Forms.ToolStripMenuItem ActionOnlineWeather;
    public System.Windows.Forms.ToolStripMenuItem ActionLocalWeather;
    public System.Windows.Forms.SaveFileDialog SaveDataBoardDialog;
    private System.Windows.Forms.Timer TimerUpdateTitles;
    internal System.Windows.Forms.ToolStripMenuItem ActionShowLunarMonths;
    internal System.Windows.Forms.ToolStripMenuItem ActionCalculateDateDiff;
    internal System.Windows.Forms.ToolStripMenuItem ActionShowCelebrationsBoard;
    internal System.Windows.Forms.ToolStripMenuItem ActionShowNewMoonsBoard;
    internal System.Windows.Forms.ToolStripMenuItem ActionShowParashotBoard;
    internal System.Windows.Forms.ToolStripButton ActionNavigate;
    internal System.Windows.Forms.ToolStripButton ActionViewNextCelebrations;
    private System.Windows.Forms.ToolStripMenuItem ActionWeeklyParashah;
    private System.Windows.Forms.ToolStripSeparator WeeklyParashahSeparator;
    private System.Windows.Forms.ToolStripMenuItem ActionWeeklyParashahStudyOnline;
    private System.Windows.Forms.ToolStripMenuItem ActionWeeklyParashahReadOnline;
    private System.Windows.Forms.BindingSource LunisolarDaysBindingSource;
    private System.Windows.Forms.ToolStripLabel BindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton BindingNavigatorMoveFirstItem;
    private System.Windows.Forms.ToolStripButton BindingNavigatorMovePreviousItem;
    private System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator2;
    private System.Windows.Forms.ToolStripTextBox BindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator3;
    private System.Windows.Forms.ToolStripButton BindingNavigatorMoveNextItem;
    private System.Windows.Forms.ToolStripButton BindingNavigatorMoveLastItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripLabel LabelGridGoToToday;
    internal System.Windows.Forms.ToolStripMenuItem ActionWeeklyParashahDescription;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
    internal System.Windows.Forms.Timer TimerBalloon;
    private System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator4;
    private System.Windows.Forms.ToolStripLabel LabelEnumsAsTranslations;
    private System.Windows.Forms.BindingNavigator LunisolarDaysBindingNavigator;
    internal Core.ToolStripCheckBoxItem EditExportDataEnumsAsTranslations;
    internal System.Windows.Forms.ToolStripMenuItem ActionShowCelebrationVersesBoard;
    private System.Windows.Forms.ContextMenuStrip ContextMenuStripDay;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayMoonrise;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayMoonset;
    private System.Windows.Forms.ToolStripSeparator ContextMenuDayTimesSeparator;
    internal System.Windows.Forms.ToolStripMenuItem ContextMenuDayCelebrationVersesBoard;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayParashah;
    internal System.Windows.Forms.ToolStripMenuItem ContextMenuDayParashahDescription;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayParashahStudyOnline;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayParashahReadOnline;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayNavigation;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
    internal System.Windows.Forms.ToolStripMenuItem ContextMenuDayDatesDiffToSelected;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDaySelectDate;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDaySunrise;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDaySunset;
    private System.Windows.Forms.ImageList ImageListRisesAndSets;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayDate;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
    internal System.Windows.Forms.ToolStripMenuItem ContextMenuDayDatesDiffToToday;
    internal System.Windows.Forms.ToolStripMenuItem ContextMenuDayParashotBoard;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayGoToToday;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayGoToSelected;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayClearSelection;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDaySetAsActive;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayGoToBookmark;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDaySaveBookmark;
    private System.Windows.Forms.ToolStripMenuItem ContextMenuDayManageBookmark;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
    internal System.Windows.Forms.ContextMenuStrip MenuBookmarks;
    internal System.Windows.Forms.ToolStrip ToolStrip;
    private Panel PanelTitleInner;
    private Label LabelSubTitleGPS;
    private Label LabelSubTitleOmer;
    internal Label LabelSubTitleCalendar;
    private ToolStripMenuItem ContextMenuOpenWithHebrewWords;
    private ToolStripMenuItem ActionWeeklyParashahOpenWithHebrewWords;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSeparator toolStripSeparator22;
    public ToolStripSeparator toolStripSeparator23;
    private ToolStripSeparator toolStripSeparator24;
    private DataGridViewTextBoxColumn GridColumnDate;
    private DataGridViewTextBoxColumn GridColumnLunarMonth;
    private DataGridViewTextBoxColumn GridColumnLunarDay;
    private DataGridViewTextBoxColumn GridColumnSunrise;
    private DataGridViewTextBoxColumn GridColumnSunset;
    private DataGridViewTextBoxColumn GridColumnMoonriseOccuring;
    private DataGridViewTextBoxColumn GridColumnMoonrise;
    private DataGridViewTextBoxColumn GridColumnMoonset;
    private DataGridViewTextBoxColumn GridColumnNewMoon;
    private DataGridViewTextBoxColumn GridColumnFullMoon;
    private DataGridViewTextBoxColumn GridColumnMoonPhase;
    private DataGridViewTextBoxColumn GridColumnSeasonChange;
    private DataGridViewTextBoxColumn GridColumnTorahEvent;
    private ToolStripSeparator toolStripSeparator26;
    private ToolStripSeparator ContextMenuParashahSeparator;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripMenuItem ActionOpenFolderDatabase;
    private ToolStripSeparator toolStripSeparator29;
    private ToolStripMenuItem ActionTakeScreenshotView;
    private ToolStripMenuItem ActionTakeScreenshotWindow;
    private ToolStripSeparator ContextMenuSunMoonSeparator;
    internal ToolStripMenuItem ContextMenuShabatVerses;
    internal ToolStripMenuItem ActionShowShabatVerses;
    private ToolStripMenuItem ContextMenuParashahReadDefault;
    private ToolStripMenuItem ActionParashahReadDefault;
    private ToolStripMenuItem ActionManageBookmarks;
    public ToolStripSeparator toolStripSeparator11;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripDropDownButton ActionHelp;
    private ToolStripMenuItem ActionShowNotices;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripMenuItem ActionShowTranscriptionGuide;
    private ToolStripMenuItem ActionShowGrammarGuide;
    private ToolStripMenuItem MenuHelp;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripSeparator MainMenuSeparatorLeftButtons;
    private ToolStripSeparator toolStripSeparator12;
    private ToolStripSeparator toolStripSeparator14;
    private ToolStripSeparator toolStripSeparator10;
    internal ToolStripMenuItem ContextMenuDayDatesDiffToActive;
  }
}

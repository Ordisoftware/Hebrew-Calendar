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
      this.statusBottom.Location = new System.Drawing.Point(0, 644);
      this.statusBottom.Name = "statusBottom";
      this.statusBottom.Size = new System.Drawing.Size(1012, 22);
      this.statusBottom.TabIndex = 8;
      this.statusBottom.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.AutoSize = false;
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
      // 
      // labelStatus
      // 
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new System.Drawing.Size(59, 17);
      this.labelStatus.Text = "Label Info";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.Filter = "Text files|*.txt|CSV files|*.csv";
      // 
      // panelMain
      // 
      this.panelMain.Controls.Add(this.panelCalendarOuter);
      this.panelMain.Controls.Add(this.panelSepBottom);
      this.panelMain.Controls.Add(this.panelSepTop);
      this.panelMain.Controls.Add(this.panelProgress);
      this.panelMain.Controls.Add(this.panelTitle);
      this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelMain.Location = new System.Drawing.Point(0, 54);
      this.panelMain.Name = "panelMain";
      this.panelMain.Padding = new System.Windows.Forms.Padding(10);
      this.panelMain.Size = new System.Drawing.Size(1012, 590);
      this.panelMain.TabIndex = 9;
      // 
      // panelCalendarOuter
      // 
      this.panelCalendarOuter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.panelCalendarOuter.Controls.Add(this.panelCalendarInner);
      this.panelCalendarOuter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelCalendarOuter.Location = new System.Drawing.Point(10, 44);
      this.panelCalendarOuter.Name = "panelCalendarOuter";
      this.panelCalendarOuter.Padding = new System.Windows.Forms.Padding(1);
      this.panelCalendarOuter.Size = new System.Drawing.Size(992, 512);
      this.panelCalendarOuter.TabIndex = 18;
      // 
      // panelCalendarInner
      // 
      this.panelCalendarInner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.panelCalendarInner.Controls.Add(this.panelCalendar);
      this.panelCalendarInner.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelCalendarInner.Location = new System.Drawing.Point(1, 1);
      this.panelCalendarInner.Name = "panelCalendarInner";
      this.panelCalendarInner.Size = new System.Drawing.Size(990, 510);
      this.panelCalendarInner.TabIndex = 0;
      // 
      // panelCalendar
      // 
      this.panelCalendar.Controls.Add(this.tabControl);
      this.panelCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelCalendar.Location = new System.Drawing.Point(0, 0);
      this.panelCalendar.Name = "panelCalendar";
      this.panelCalendar.Size = new System.Drawing.Size(990, 510);
      this.panelCalendar.TabIndex = 0;
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tabPageText);
      this.tabControl.Controls.Add(this.tabPageGrid);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(990, 510);
      this.tabControl.TabIndex = 1;
      this.tabControl.TabStop = false;
      this.tabControl.Visible = false;
      // 
      // tabPageText
      // 
      this.tabPageText.Controls.Add(this.panelViewText);
      this.tabPageText.Location = new System.Drawing.Point(4, 22);
      this.tabPageText.Name = "tabPageText";
      this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageText.Size = new System.Drawing.Size(982, 484);
      this.tabPageText.TabIndex = 0;
      this.tabPageText.Text = "Raw text";
      this.tabPageText.UseVisualStyleBackColor = true;
      // 
      // panelViewText
      // 
      this.panelViewText.Controls.Add(this.calendarText);
      this.panelViewText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelViewText.Location = new System.Drawing.Point(3, 3);
      this.panelViewText.Name = "panelViewText";
      this.panelViewText.Size = new System.Drawing.Size(976, 478);
      this.panelViewText.TabIndex = 0;
      // 
      // calendarText
      // 
      this.calendarText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.calendarText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.calendarText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.calendarText.Location = new System.Drawing.Point(0, 0);
      this.calendarText.Name = "calendarText";
      this.calendarText.ReadOnly = true;
      this.calendarText.Size = new System.Drawing.Size(976, 478);
      this.calendarText.TabIndex = 17;
      this.calendarText.Text = "";
      this.calendarText.WordWrap = false;
      // 
      // tabPageGrid
      // 
      this.tabPageGrid.Controls.Add(this.panelViewGrid);
      this.tabPageGrid.Location = new System.Drawing.Point(4, 22);
      this.tabPageGrid.Name = "tabPageGrid";
      this.tabPageGrid.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageGrid.Size = new System.Drawing.Size(982, 484);
      this.tabPageGrid.TabIndex = 1;
      this.tabPageGrid.Text = "Simple grid";
      this.tabPageGrid.UseVisualStyleBackColor = true;
      // 
      // panelViewGrid
      // 
      this.panelViewGrid.Controls.Add(this.calendarGrid);
      this.panelViewGrid.Controls.Add(this.lunisolarDaysBindingNavigator);
      this.panelViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelViewGrid.Location = new System.Drawing.Point(3, 3);
      this.panelViewGrid.Name = "panelViewGrid";
      this.panelViewGrid.Size = new System.Drawing.Size(976, 478);
      this.panelViewGrid.TabIndex = 0;
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
      this.calendarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.calendarGrid.Location = new System.Drawing.Point(0, 25);
      this.calendarGrid.Name = "calendarGrid";
      this.calendarGrid.Size = new System.Drawing.Size(976, 453);
      this.calendarGrid.TabIndex = 11;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
      this.dataGridViewTextBoxColumn1.HeaderText = "Date";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "LunarMonth";
      this.dataGridViewTextBoxColumn2.HeaderText = "LunarMonth";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "LunarDay";
      this.dataGridViewTextBoxColumn3.HeaderText = "LunarDay";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "Sunrise";
      this.dataGridViewTextBoxColumn4.HeaderText = "Sunrise";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Sunset";
      this.dataGridViewTextBoxColumn5.HeaderText = "Sunset";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "Moonrise";
      this.dataGridViewTextBoxColumn6.HeaderText = "Moonrise";
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Moonset";
      this.dataGridViewTextBoxColumn7.HeaderText = "Moonset";
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      // 
      // dataGridViewTextBoxColumn8
      // 
      this.dataGridViewTextBoxColumn8.DataPropertyName = "MoonriseType";
      this.dataGridViewTextBoxColumn8.HeaderText = "MoonriseType";
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      // 
      // dataGridViewTextBoxColumn9
      // 
      this.dataGridViewTextBoxColumn9.DataPropertyName = "IsNewMoon";
      this.dataGridViewTextBoxColumn9.HeaderText = "IsNewMoon";
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      // 
      // dataGridViewTextBoxColumn10
      // 
      this.dataGridViewTextBoxColumn10.DataPropertyName = "IsFullMoon";
      this.dataGridViewTextBoxColumn10.HeaderText = "IsFullMoon";
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      // 
      // dataGridViewTextBoxColumn11
      // 
      this.dataGridViewTextBoxColumn11.DataPropertyName = "MoonPhase";
      this.dataGridViewTextBoxColumn11.HeaderText = "MoonPhase";
      this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
      // 
      // dataGridViewTextBoxColumn12
      // 
      this.dataGridViewTextBoxColumn12.DataPropertyName = "SeasonChange";
      this.dataGridViewTextBoxColumn12.HeaderText = "SeasonChange";
      this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
      // 
      // dataGridViewTextBoxColumn13
      // 
      this.dataGridViewTextBoxColumn13.DataPropertyName = "TorahEvents";
      this.dataGridViewTextBoxColumn13.HeaderText = "TorahEvents";
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
      this.lunisolarDaysBindingNavigator.Location = new System.Drawing.Point(0, 0);
      this.lunisolarDaysBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
      this.lunisolarDaysBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
      this.lunisolarDaysBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
      this.lunisolarDaysBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
      this.lunisolarDaysBindingNavigator.Name = "lunisolarDaysBindingNavigator";
      this.lunisolarDaysBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
      this.lunisolarDaysBindingNavigator.Size = new System.Drawing.Size(976, 25);
      this.lunisolarDaysBindingNavigator.TabIndex = 10;
      this.lunisolarDaysBindingNavigator.Text = "bindingNavigator1";
      // 
      // bindingNavigatorCountItem
      // 
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
      this.bindingNavigatorCountItem.Text = "de {0}";
      this.bindingNavigatorCountItem.ToolTipText = "Nombre total d\'éléments";
      // 
      // bindingNavigatorMoveFirstItem
      // 
      this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveFirstItem.Text = "Placer en premier";
      // 
      // bindingNavigatorMovePreviousItem
      // 
      this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMovePreviousItem.Text = "Déplacer vers le haut";
      // 
      // bindingNavigatorSeparator
      // 
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
      // 
      // bindingNavigatorPositionItem
      // 
      this.bindingNavigatorPositionItem.AccessibleName = "Position";
      this.bindingNavigatorPositionItem.AutoSize = false;
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
      this.bindingNavigatorPositionItem.Text = "0";
      this.bindingNavigatorPositionItem.ToolTipText = "Position actuelle";
      // 
      // bindingNavigatorSeparator1
      // 
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // bindingNavigatorMoveNextItem
      // 
      this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveNextItem.Text = "Déplacer vers le bas";
      // 
      // bindingNavigatorMoveLastItem
      // 
      this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveLastItem.Text = "Placer en dernier";
      // 
      // panelSepBottom
      // 
      this.panelSepBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelSepBottom.Location = new System.Drawing.Point(10, 556);
      this.panelSepBottom.Name = "panelSepBottom";
      this.panelSepBottom.Size = new System.Drawing.Size(992, 10);
      this.panelSepBottom.TabIndex = 17;
      // 
      // panelSepTop
      // 
      this.panelSepTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelSepTop.Location = new System.Drawing.Point(10, 34);
      this.panelSepTop.Name = "panelSepTop";
      this.panelSepTop.Size = new System.Drawing.Size(992, 10);
      this.panelSepTop.TabIndex = 16;
      // 
      // panelProgress
      // 
      this.panelProgress.Controls.Add(this.barProgress);
      this.panelProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelProgress.Location = new System.Drawing.Point(10, 566);
      this.panelProgress.Name = "panelProgress";
      this.panelProgress.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
      this.panelProgress.Size = new System.Drawing.Size(992, 14);
      this.panelProgress.TabIndex = 14;
      // 
      // barProgress
      // 
      this.barProgress.Dock = System.Windows.Forms.DockStyle.Fill;
      this.barProgress.Location = new System.Drawing.Point(0, 0);
      this.barProgress.Name = "barProgress";
      this.barProgress.Size = new System.Drawing.Size(992, 12);
      this.barProgress.Step = 1;
      this.barProgress.TabIndex = 0;
      // 
      // panelTitle
      // 
      this.panelTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.panelTitle.Controls.Add(this.labelTitle);
      this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTitle.Location = new System.Drawing.Point(10, 10);
      this.panelTitle.Name = "panelTitle";
      this.panelTitle.Padding = new System.Windows.Forms.Padding(1);
      this.panelTitle.Size = new System.Drawing.Size(992, 24);
      this.panelTitle.TabIndex = 3;
      // 
      // labelTitle
      // 
      this.labelTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTitle.Location = new System.Drawing.Point(1, 1);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(990, 22);
      this.labelTitle.TabIndex = 0;
      this.labelTitle.Text = "LUNASOLAIR CALENDAR";
      this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // moonPhaseImagePictureBox
      // 
      this.moonPhaseImagePictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.moonPhaseImagePictureBox.Location = new System.Drawing.Point(3, 3);
      this.moonPhaseImagePictureBox.Name = "moonPhaseImagePictureBox";
      this.moonPhaseImagePictureBox.Size = new System.Drawing.Size(40, 40);
      this.moonPhaseImagePictureBox.TabIndex = 4;
      this.moonPhaseImagePictureBox.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(49, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "label1";
      // 
      // timerTooltip
      // 
      this.timerTooltip.Interval = 500;
      this.timerTooltip.Tick += new System.EventHandler(this.timerTooltip_Tick);
      // 
      // toolStrip
      // 
      this.toolStrip.AutoSize = false;
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
            this.actionPreferences,
            this.actionAbout,
            this.sep6,
            this.menuSettings,
            this.menuView,
            this.actionStop});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
      this.toolStrip.ShowItemToolTips = false;
      this.toolStrip.Size = new System.Drawing.Size(1012, 54);
      this.toolStrip.TabIndex = 7;
      this.toolStrip.Text = "toolStrip1";
      // 
      // sep2
      // 
      this.sep2.Name = "sep2";
      this.sep2.Size = new System.Drawing.Size(6, 49);
      this.sep2.Visible = false;
      // 
      // actionSaveReport
      // 
      this.actionSaveReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionSaveReport.Image = ((System.Drawing.Image)(resources.GetObject("actionSaveReport.Image")));
      this.actionSaveReport.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionSaveReport.Name = "actionSaveReport";
      this.actionSaveReport.Padding = new System.Windows.Forms.Padding(5);
      this.actionSaveReport.Size = new System.Drawing.Size(46, 46);
      this.actionSaveReport.Text = "Save report to file";
      this.actionSaveReport.ToolTipText = "Save report to file (Ctrl+S)";
      this.actionSaveReport.Click += new System.EventHandler(this.actionSaveReport_Click);
      this.actionSaveReport.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionSaveReport.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionCopyReportToClipboard
      // 
      this.actionCopyReportToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionCopyReportToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("actionCopyReportToClipboard.Image")));
      this.actionCopyReportToClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionCopyReportToClipboard.Name = "actionCopyReportToClipboard";
      this.actionCopyReportToClipboard.Padding = new System.Windows.Forms.Padding(5);
      this.actionCopyReportToClipboard.Size = new System.Drawing.Size(46, 46);
      this.actionCopyReportToClipboard.Text = "Copy report to clipboard";
      this.actionCopyReportToClipboard.ToolTipText = "Copy report to clipboard (Ctrl+C)";
      this.actionCopyReportToClipboard.Click += new System.EventHandler(this.actionCopyReportToClipboard_Click);
      this.actionCopyReportToClipboard.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionCopyReportToClipboard.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionFindDay
      // 
      this.actionFindDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionFindDay.Image = ((System.Drawing.Image)(resources.GetObject("actionFindDay.Image")));
      this.actionFindDay.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionFindDay.Name = "actionFindDay";
      this.actionFindDay.Padding = new System.Windows.Forms.Padding(5);
      this.actionFindDay.Size = new System.Drawing.Size(46, 46);
      this.actionFindDay.Text = "Find a day";
      this.actionFindDay.ToolTipText = "Find a day (Ctrl+D)";
      this.actionFindDay.Click += new System.EventHandler(this.actionFindDay_Click);
      this.actionFindDay.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionFindDay.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep3
      // 
      this.sep3.Name = "sep3";
      this.sep3.Size = new System.Drawing.Size(6, 49);
      // 
      // actionGenerate
      // 
      this.actionGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionGenerate.Image = ((System.Drawing.Image)(resources.GetObject("actionGenerate.Image")));
      this.actionGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionGenerate.Name = "actionGenerate";
      this.actionGenerate.Padding = new System.Windows.Forms.Padding(5);
      this.actionGenerate.Size = new System.Drawing.Size(46, 46);
      this.actionGenerate.Text = "Generate";
      this.actionGenerate.ToolTipText = "Generate (F2)";
      this.actionGenerate.Click += new System.EventHandler(this.actionGenerate_Click);
      this.actionGenerate.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionGenerate.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionExit
      // 
      this.actionExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionExit.Image = ((System.Drawing.Image)(resources.GetObject("actionExit.Image")));
      this.actionExit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionExit.Name = "actionExit";
      this.actionExit.Padding = new System.Windows.Forms.Padding(5);
      this.actionExit.Size = new System.Drawing.Size(46, 46);
      this.actionExit.Text = "Exit";
      this.actionExit.ToolTipText = "Exit (Esc, Alt+F4)";
      this.actionExit.Click += new System.EventHandler(this.actionExit_Click);
      this.actionExit.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionExit.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep4
      // 
      this.sep4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sep4.Name = "sep4";
      this.sep4.Size = new System.Drawing.Size(6, 49);
      // 
      // actionContact
      // 
      this.actionContact.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionContact.Image = ((System.Drawing.Image)(resources.GetObject("actionContact.Image")));
      this.actionContact.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionContact.Name = "actionContact";
      this.actionContact.Padding = new System.Windows.Forms.Padding(5);
      this.actionContact.Size = new System.Drawing.Size(46, 46);
      this.actionContact.Text = "Contact";
      this.actionContact.Click += new System.EventHandler(this.actionContact_Click);
      this.actionContact.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionContact.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionWebsite
      // 
      this.actionWebsite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionWebsite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionWebsite.Image = ((System.Drawing.Image)(resources.GetObject("actionWebsite.Image")));
      this.actionWebsite.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionWebsite.Name = "actionWebsite";
      this.actionWebsite.Padding = new System.Windows.Forms.Padding(5);
      this.actionWebsite.Size = new System.Drawing.Size(46, 46);
      this.actionWebsite.Text = "Website";
      this.actionWebsite.Click += new System.EventHandler(this.actionApplicationHome_Click);
      this.actionWebsite.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionWebsite.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep5
      // 
      this.sep5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sep5.Name = "sep5";
      this.sep5.Size = new System.Drawing.Size(6, 49);
      this.sep5.Visible = false;
      // 
      // actionHelp
      // 
      this.actionHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionHelp.Image = ((System.Drawing.Image)(resources.GetObject("actionHelp.Image")));
      this.actionHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionHelp.Name = "actionHelp";
      this.actionHelp.Padding = new System.Windows.Forms.Padding(5);
      this.actionHelp.Size = new System.Drawing.Size(46, 46);
      this.actionHelp.Text = "Help";
      this.actionHelp.ToolTipText = "Help (F1)";
      this.actionHelp.Visible = false;
      this.actionHelp.Click += new System.EventHandler(this.actionHelp_Click);
      this.actionHelp.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionHelp.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // actionAbout
      // 
      this.actionAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionAbout.Image = ((System.Drawing.Image)(resources.GetObject("actionAbout.Image")));
      this.actionAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionAbout.Name = "actionAbout";
      this.actionAbout.Padding = new System.Windows.Forms.Padding(5);
      this.actionAbout.Size = new System.Drawing.Size(46, 46);
      this.actionAbout.Text = "About";
      this.actionAbout.ToolTipText = "About (F12)";
      this.actionAbout.Click += new System.EventHandler(this.actionAbout_Click);
      this.actionAbout.MouseEnter += new System.EventHandler(this.ShowToolTipOnMouseEnter);
      this.actionAbout.MouseLeave += new System.EventHandler(this.ShowToolTipOnMouseLeave);
      // 
      // sep6
      // 
      this.sep6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.sep6.Name = "sep6";
      this.sep6.Size = new System.Drawing.Size(6, 49);
      // 
      // actionPreferences
      // 
      this.actionPreferences.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.actionPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionPreferences.Image = ((System.Drawing.Image)(resources.GetObject("actionPreferences.Image")));
      this.actionPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionPreferences.Name = "actionPreferences";
      this.actionPreferences.Padding = new System.Windows.Forms.Padding(5);
      this.actionPreferences.Size = new System.Drawing.Size(46, 46);
      this.actionPreferences.Text = "Preferences";
      this.actionPreferences.ToolTipText = "Preferences (F8)";
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
      this.menuSettings.Image = ((System.Drawing.Image)(resources.GetObject("menuSettings.Image")));
      this.menuSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.menuSettings.Name = "menuSettings";
      this.menuSettings.Size = new System.Drawing.Size(45, 46);
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
      this.menuitemScreenPosition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.menuitemScreenPosition.Name = "menuitemScreenPosition";
      this.menuitemScreenPosition.Size = new System.Drawing.Size(221, 22);
      this.menuitemScreenPosition.Text = "Screen position";
      // 
      // editScreenNone
      // 
      this.editScreenNone.CheckOnClick = true;
      this.editScreenNone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editScreenNone.Name = "editScreenNone";
      this.editScreenNone.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
      this.editScreenNone.Size = new System.Drawing.Size(178, 22);
      this.editScreenNone.Text = "None";
      this.editScreenNone.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenTopLeft
      // 
      this.editScreenTopLeft.CheckOnClick = true;
      this.editScreenTopLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editScreenTopLeft.Name = "editScreenTopLeft";
      this.editScreenTopLeft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
      this.editScreenTopLeft.Size = new System.Drawing.Size(178, 22);
      this.editScreenTopLeft.Text = "Top left";
      this.editScreenTopLeft.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenTopRight
      // 
      this.editScreenTopRight.CheckOnClick = true;
      this.editScreenTopRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editScreenTopRight.Name = "editScreenTopRight";
      this.editScreenTopRight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
      this.editScreenTopRight.Size = new System.Drawing.Size(178, 22);
      this.editScreenTopRight.Text = "Top right";
      this.editScreenTopRight.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenBottomLeft
      // 
      this.editScreenBottomLeft.CheckOnClick = true;
      this.editScreenBottomLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editScreenBottomLeft.Name = "editScreenBottomLeft";
      this.editScreenBottomLeft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
      this.editScreenBottomLeft.Size = new System.Drawing.Size(178, 22);
      this.editScreenBottomLeft.Text = "Bottom left";
      this.editScreenBottomLeft.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenBottomRight
      // 
      this.editScreenBottomRight.CheckOnClick = true;
      this.editScreenBottomRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editScreenBottomRight.Name = "editScreenBottomRight";
      this.editScreenBottomRight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
      this.editScreenBottomRight.Size = new System.Drawing.Size(178, 22);
      this.editScreenBottomRight.Text = "Bottom right";
      this.editScreenBottomRight.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // editScreenCenter
      // 
      this.editScreenCenter.CheckOnClick = true;
      this.editScreenCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editScreenCenter.Name = "editScreenCenter";
      this.editScreenCenter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
      this.editScreenCenter.Size = new System.Drawing.Size(178, 22);
      this.editScreenCenter.Text = "Center";
      this.editScreenCenter.Click += new System.EventHandler(this.editScreenPosition_Click);
      // 
      // actionResetWinSettings
      // 
      this.actionResetWinSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.actionResetWinSettings.Name = "actionResetWinSettings";
      this.actionResetWinSettings.Size = new System.Drawing.Size(221, 22);
      this.actionResetWinSettings.Text = "Reset window settings";
      this.actionResetWinSettings.Click += new System.EventHandler(this.actionResetWinSettings_Click);
      // 
      // sep7
      // 
      this.sep7.Name = "sep7";
      this.sep7.Size = new System.Drawing.Size(218, 6);
      // 
      // editShowTips
      // 
      this.editShowTips.Checked = true;
      this.editShowTips.CheckOnClick = true;
      this.editShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
      this.editShowTips.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editShowTips.Name = "editShowTips";
      this.editShowTips.Size = new System.Drawing.Size(221, 22);
      this.editShowTips.Text = "Show menu tips";
      // 
      // editESCtoExit
      // 
      this.editESCtoExit.Checked = true;
      this.editESCtoExit.CheckOnClick = true;
      this.editESCtoExit.CheckState = System.Windows.Forms.CheckState.Checked;
      this.editESCtoExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editESCtoExit.Name = "editESCtoExit";
      this.editESCtoExit.Size = new System.Drawing.Size(221, 22);
      this.editESCtoExit.Text = "Escape key hides form";
      // 
      // editConfirmClosing
      // 
      this.editConfirmClosing.AccessibleName = "";
      this.editConfirmClosing.Checked = true;
      this.editConfirmClosing.CheckOnClick = true;
      this.editConfirmClosing.CheckState = System.Windows.Forms.CheckState.Checked;
      this.editConfirmClosing.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.editConfirmClosing.Name = "editConfirmClosing";
      this.editConfirmClosing.Size = new System.Drawing.Size(221, 22);
      this.editConfirmClosing.Text = "Confirm application closing";
      // 
      // menuView
      // 
      this.menuView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.menuView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionViewText,
            this.actionViewGrid});
      this.menuView.Image = ((System.Drawing.Image)(resources.GetObject("menuView.Image")));
      this.menuView.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.menuView.Name = "menuView";
      this.menuView.Size = new System.Drawing.Size(45, 46);
      // 
      // actionViewText
      // 
      this.actionViewText.CheckOnClick = true;
      this.actionViewText.Image = ((System.Drawing.Image)(resources.GetObject("actionViewText.Image")));
      this.actionViewText.Name = "actionViewText";
      this.actionViewText.Size = new System.Drawing.Size(134, 22);
      this.actionViewText.Text = "Raw text";
      this.actionViewText.Click += new System.EventHandler(this.actionViewText_Click);
      // 
      // actionViewGrid
      // 
      this.actionViewGrid.CheckOnClick = true;
      this.actionViewGrid.Image = ((System.Drawing.Image)(resources.GetObject("actionViewGrid.Image")));
      this.actionViewGrid.Name = "actionViewGrid";
      this.actionViewGrid.Size = new System.Drawing.Size(134, 22);
      this.actionViewGrid.Text = "Simple grid";
      this.actionViewGrid.Click += new System.EventHandler(this.actionViewGrid_Click);
      // 
      // actionStop
      // 
      this.actionStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.actionStop.Image = ((System.Drawing.Image)(resources.GetObject("actionStop.Image")));
      this.actionStop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionStop.Name = "actionStop";
      this.actionStop.Padding = new System.Windows.Forms.Padding(5);
      this.actionStop.Size = new System.Drawing.Size(46, 46);
      this.actionStop.Text = "Stop";
      this.actionStop.ToolTipText = "Stop (Esc)";
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
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1012, 666);
      this.Controls.Add(this.panelMain);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.statusBottom);
      this.MinimumSize = new System.Drawing.Size(1020, 700);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Ordisoftware Hebrew Calendar";
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


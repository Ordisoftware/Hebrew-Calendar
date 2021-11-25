namespace Ordisoftware.Core
{
  partial class TraceForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraceForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionOpenLogsFolder = new System.Windows.Forms.Button();
      this.TrackBarFontSize = new System.Windows.Forms.TrackBar();
      this.LabelLinesCount = new System.Windows.Forms.Label();
      this.ActionClearLogs = new System.Windows.Forms.Button();
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.TabPageCurrent = new System.Windows.Forms.TabPage();
      this.TextBoxCurrent = new Ordisoftware.Core.RichTextBoxEx();
      this.TabPagePrevious = new System.Windows.Forms.TabPage();
      this.TextBoxPrevious = new Ordisoftware.Core.RichTextBoxEx();
      this.panel1 = new System.Windows.Forms.Panel();
      this.EditOnlyErrors = new System.Windows.Forms.CheckBox();
      this.SelectFileNavigator = new Ordisoftware.Core.ComboBoxNavigator();
      this.SelectFile = new System.Windows.Forms.ComboBox();
      this.LabelFilesCount = new System.Windows.Forms.Label();
      this.ActionRefreshFiles = new System.Windows.Forms.Button();
      this.ActionDeleteFile = new System.Windows.Forms.Button();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TrackBarFontSize)).BeginInit();
      this.TabControl.SuspendLayout();
      this.TabPageCurrent.SuspendLayout();
      this.TabPagePrevious.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionOpenLogsFolder);
      this.PanelBottom.Controls.Add(this.TrackBarFontSize);
      this.PanelBottom.Controls.Add(this.LabelLinesCount);
      this.PanelBottom.Controls.Add(this.ActionClearLogs);
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionOpenLogsFolder
      // 
      resources.ApplyResources(this.ActionOpenLogsFolder, "ActionOpenLogsFolder");
      this.ActionOpenLogsFolder.FlatAppearance.BorderSize = 0;
      this.ActionOpenLogsFolder.Name = "ActionOpenLogsFolder";
      this.ActionOpenLogsFolder.UseVisualStyleBackColor = true;
      this.ActionOpenLogsFolder.Click += new System.EventHandler(this.ActionOpenLogsFolder_Click);
      // 
      // TrackBarFontSize
      // 
      resources.ApplyResources(this.TrackBarFontSize, "TrackBarFontSize");
      this.TrackBarFontSize.Maximum = 12;
      this.TrackBarFontSize.Minimum = 7;
      this.TrackBarFontSize.Name = "TrackBarFontSize";
      this.TrackBarFontSize.Value = 7;
      this.TrackBarFontSize.ValueChanged += new System.EventHandler(this.TrackBarFontSize_ValueChanged);
      // 
      // LabelLinesCount
      // 
      resources.ApplyResources(this.LabelLinesCount, "LabelLinesCount");
      this.LabelLinesCount.Name = "LabelLinesCount";
      // 
      // ActionClearLogs
      // 
      resources.ApplyResources(this.ActionClearLogs, "ActionClearLogs");
      this.ActionClearLogs.FlatAppearance.BorderSize = 0;
      this.ActionClearLogs.Name = "ActionClearLogs";
      this.ActionClearLogs.UseVisualStyleBackColor = true;
      this.ActionClearLogs.Click += new System.EventHandler(this.ActionClearLogs_Click);
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // PanelSeparator
      // 
      resources.ApplyResources(this.PanelSeparator, "PanelSeparator");
      this.PanelSeparator.Name = "PanelSeparator";
      // 
      // TabControl
      // 
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Controls.Add(this.TabPageCurrent);
      this.TabControl.Controls.Add(this.TabPagePrevious);
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TextBox_TextChanged);
      // 
      // TabPageCurrent
      // 
      this.TabPageCurrent.Controls.Add(this.TextBoxCurrent);
      resources.ApplyResources(this.TabPageCurrent, "TabPageCurrent");
      this.TabPageCurrent.Name = "TabPageCurrent";
      this.TabPageCurrent.UseVisualStyleBackColor = true;
      // 
      // TextBoxCurrent
      // 
      this.TextBoxCurrent.BackColor = System.Drawing.SystemColors.Window;
      this.TextBoxCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.TextBoxCurrent, "TextBoxCurrent");
      this.TextBoxCurrent.Name = "TextBoxCurrent";
      this.TextBoxCurrent.ReadOnly = true;
      this.TextBoxCurrent.SelectionAlignment = Ordisoftware.Core.TextAlign.Left;
      this.TextBoxCurrent.TabStop = false;
      this.TextBoxCurrent.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
      // 
      // TabPagePrevious
      // 
      this.TabPagePrevious.Controls.Add(this.TextBoxPrevious);
      this.TabPagePrevious.Controls.Add(this.panel1);
      resources.ApplyResources(this.TabPagePrevious, "TabPagePrevious");
      this.TabPagePrevious.Name = "TabPagePrevious";
      this.TabPagePrevious.UseVisualStyleBackColor = true;
      // 
      // TextBoxPrevious
      // 
      this.TextBoxPrevious.BackColor = System.Drawing.SystemColors.Window;
      this.TextBoxPrevious.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.TextBoxPrevious, "TextBoxPrevious");
      this.TextBoxPrevious.Name = "TextBoxPrevious";
      this.TextBoxPrevious.ReadOnly = true;
      this.TextBoxPrevious.SelectionAlignment = Ordisoftware.Core.TextAlign.Left;
      this.TextBoxPrevious.TabStop = false;
      this.TextBoxPrevious.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.EditOnlyErrors);
      this.panel1.Controls.Add(this.SelectFileNavigator);
      this.panel1.Controls.Add(this.LabelFilesCount);
      this.panel1.Controls.Add(this.SelectFile);
      this.panel1.Controls.Add(this.ActionRefreshFiles);
      this.panel1.Controls.Add(this.ActionDeleteFile);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // EditOnlyErrors
      // 
      resources.ApplyResources(this.EditOnlyErrors, "EditOnlyErrors");
      this.EditOnlyErrors.Checked = true;
      this.EditOnlyErrors.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditOnlyErrors.Name = "EditOnlyErrors";
      this.EditOnlyErrors.UseVisualStyleBackColor = true;
      this.EditOnlyErrors.CheckedChanged += new System.EventHandler(this.ActionRefreshFiles_Click);
      // 
      // SelectFileNavigator
      // 
      resources.ApplyResources(this.SelectFileNavigator, "SelectFileNavigator");
      this.SelectFileNavigator.ComboBox = this.SelectFile;
      this.SelectFileNavigator.Name = "SelectFileNavigator";
      this.SelectFileNavigator.SelectedIndex = -1;
      this.SelectFileNavigator.SelectedItem = null;
      // 
      // SelectFile
      // 
      this.SelectFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectFile.FormattingEnabled = true;
      resources.ApplyResources(this.SelectFile, "SelectFile");
      this.SelectFile.Name = "SelectFile";
      this.SelectFile.SelectedIndexChanged += new System.EventHandler(this.SelectFile_SelectedIndexChanged);
      this.SelectFile.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.SelectFile_Format);
      // 
      // LabelFilesCount
      // 
      resources.ApplyResources(this.LabelFilesCount, "LabelFilesCount");
      this.LabelFilesCount.Name = "LabelFilesCount";
      // 
      // ActionRefreshFiles
      // 
      this.ActionRefreshFiles.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionRefreshFiles, "ActionRefreshFiles");
      this.ActionRefreshFiles.Name = "ActionRefreshFiles";
      this.ActionRefreshFiles.UseVisualStyleBackColor = true;
      this.ActionRefreshFiles.Click += new System.EventHandler(this.ActionRefreshFiles_Click);
      // 
      // ActionDeleteFile
      // 
      this.ActionDeleteFile.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionDeleteFile, "ActionDeleteFile");
      this.ActionDeleteFile.Name = "ActionDeleteFile";
      this.ActionDeleteFile.UseVisualStyleBackColor = true;
      this.ActionDeleteFile.Click += new System.EventHandler(this.ActionDeleteFile_Click);
      // 
      // TraceForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.TabControl);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.PanelBottom);
      this.Name = "TraceForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Activated += new System.EventHandler(this.LogForm_Activated);
      this.Deactivate += new System.EventHandler(this.TraceForm_Deactivate);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TraceForm_FormClosing);
      this.Load += new System.EventHandler(this.LogForm_Load);
      this.Shown += new System.EventHandler(this.TraceForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TrackBarFontSize)).EndInit();
      this.TabControl.ResumeLayout(false);
      this.TabPageCurrent.ResumeLayout(false);
      this.TabPagePrevious.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelSeparator;
    public System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Label LabelLinesCount;
    private System.Windows.Forms.Button ActionClearLogs;
    private System.Windows.Forms.TrackBar TrackBarFontSize;
    private System.Windows.Forms.Button ActionOpenLogsFolder;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.TabPage TabPageCurrent;
    private System.Windows.Forms.TabPage TabPagePrevious;
    public RichTextBoxEx TextBoxCurrent;
    public RichTextBoxEx TextBoxPrevious;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ComboBox SelectFile;
    private System.Windows.Forms.Button ActionRefreshFiles;
    private System.Windows.Forms.Button ActionDeleteFile;
    private ComboBoxNavigator SelectFileNavigator;
    private CheckBox EditOnlyErrors;
    private Label LabelFilesCount;
  }
}
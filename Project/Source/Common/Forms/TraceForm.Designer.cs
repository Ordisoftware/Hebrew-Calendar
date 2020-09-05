namespace Ordisoftware.HebrewCommon
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
      this.TrackBarFontSize = new System.Windows.Forms.TrackBar();
      this.LabelLinesCount = new System.Windows.Forms.Label();
      this.ActionClearLogs = new System.Windows.Forms.Button();
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.PanelTextBox = new System.Windows.Forms.Panel();
      this.ActionOpenLogsFolder = new System.Windows.Forms.Button();
      this.TextBox = new Ordisoftware.HebrewCommon.RichTextBoxEx();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TrackBarFontSize)).BeginInit();
      this.PanelTextBox.SuspendLayout();
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
      this.ActionClearLogs.TabStop = false;
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
      // PanelTextBox
      // 
      this.PanelTextBox.BackColor = System.Drawing.SystemColors.Window;
      this.PanelTextBox.Controls.Add(this.TextBox);
      resources.ApplyResources(this.PanelTextBox, "PanelTextBox");
      this.PanelTextBox.Name = "PanelTextBox";
      // 
      // ActionOpenLogsFolder
      // 
      resources.ApplyResources(this.ActionOpenLogsFolder, "ActionOpenLogsFolder");
      this.ActionOpenLogsFolder.FlatAppearance.BorderSize = 0;
      this.ActionOpenLogsFolder.Name = "ActionOpenLogsFolder";
      this.ActionOpenLogsFolder.TabStop = false;
      this.ActionOpenLogsFolder.UseVisualStyleBackColor = true;
      this.ActionOpenLogsFolder.Click += new System.EventHandler(this.ActionOpenLogsFolder_Click);
      // 
      // TextBox
      // 
      this.TextBox.BackColor = System.Drawing.SystemColors.Window;
      this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.TextBox, "TextBox");
      this.TextBox.Name = "TextBox";
      this.TextBox.ReadOnly = true;
      this.TextBox.SelectionAlignment = Ordisoftware.HebrewCommon.TextAlign.Left;
      this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
      // 
      // TraceForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelTextBox);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.PanelBottom);
      this.Name = "TraceForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Activated += new System.EventHandler(this.LogForm_Activated);
      this.Deactivate += new System.EventHandler(this.TraceForm_Deactivate);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowTextForm_FormClosing);
      this.Load += new System.EventHandler(this.LogForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TrackBarFontSize)).EndInit();
      this.PanelTextBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelSeparator;
    private System.Windows.Forms.Panel PanelTextBox;
    internal RichTextBoxEx TextBox;
    public System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Label LabelLinesCount;
    private System.Windows.Forms.Button ActionClearLogs;
    private System.Windows.Forms.TrackBar TrackBarFontSize;
    private System.Windows.Forms.Button ActionOpenLogsFolder;
  }
}
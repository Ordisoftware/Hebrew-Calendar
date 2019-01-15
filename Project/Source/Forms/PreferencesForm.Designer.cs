namespace Ordisoftware.HebrewCalendar
{
  partial class PreferencesForm
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
      if ( disposing && (components != null) )
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
      System.Windows.Forms.Label gPSLatitudeLabel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
      System.Windows.Forms.Label gPSLongitudeLabel;
      this.dialogColor = new System.Windows.Forms.ColorDialog();
      this.buttonClose = new System.Windows.Forms.Button();
      this.editFontName = new System.Windows.Forms.ComboBox();
      this.labelShabatDay = new System.Windows.Forms.Label();
      this.editFontSize = new System.Windows.Forms.NumericUpDown();
      this.labelFontSize = new System.Windows.Forms.Label();
      this.panelBackColor = new System.Windows.Forms.Panel();
      this.labelTextColor = new System.Windows.Forms.Label();
      this.editShabatDay = new System.Windows.Forms.ComboBox();
      this.labelFontName = new System.Windows.Forms.Label();
      this.panelTextColor = new System.Windows.Forms.Panel();
      this.labelBackColor = new System.Windows.Forms.Label();
      this.gPSLatitudeTextBox = new System.Windows.Forms.TextBox();
      this.gPSLongitudeTextBox = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.actionUsePersonalShabat = new System.Windows.Forms.LinkLabel();
      this.bindingSettings = new System.Windows.Forms.BindingSource(this.components);
      gPSLatitudeLabel = new System.Windows.Forms.Label();
      gPSLongitudeLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.editFontSize)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSettings)).BeginInit();
      this.SuspendLayout();
      // 
      // gPSLatitudeLabel
      // 
      resources.ApplyResources(gPSLatitudeLabel, "gPSLatitudeLabel");
      gPSLatitudeLabel.Name = "gPSLatitudeLabel";
      // 
      // gPSLongitudeLabel
      // 
      resources.ApplyResources(gPSLongitudeLabel, "gPSLongitudeLabel");
      gPSLongitudeLabel.Name = "gPSLongitudeLabel";
      // 
      // dialogColor
      // 
      this.dialogColor.FullOpen = true;
      // 
      // buttonClose
      // 
      resources.ApplyResources(this.buttonClose, "buttonClose");
      this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.UseVisualStyleBackColor = true;
      // 
      // editFontName
      // 
      this.editFontName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSettings, "FontName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.editFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.editFontName.FormattingEnabled = true;
      resources.ApplyResources(this.editFontName, "editFontName");
      this.editFontName.Name = "editFontName";
      this.editFontName.SelectedIndexChanged += new System.EventHandler(this.editFont_Changed);
      // 
      // labelShabatDay
      // 
      resources.ApplyResources(this.labelShabatDay, "labelShabatDay");
      this.labelShabatDay.Name = "labelShabatDay";
      // 
      // editFontSize
      // 
      this.editFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSettings, "FontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      resources.ApplyResources(this.editFontSize, "editFontSize");
      this.editFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
      this.editFontSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
      this.editFontSize.Name = "editFontSize";
      this.editFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.editFontSize.ValueChanged += new System.EventHandler(this.editFont_Changed);
      // 
      // labelFontSize
      // 
      resources.ApplyResources(this.labelFontSize, "labelFontSize");
      this.labelFontSize.Name = "labelFontSize";
      // 
      // panelBackColor
      // 
      this.panelBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.panelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.panelBackColor, "panelBackColor");
      this.panelBackColor.Name = "panelBackColor";
      this.panelBackColor.Click += new System.EventHandler(this.panelBackColor_Click);
      // 
      // labelTextColor
      // 
      resources.ApplyResources(this.labelTextColor, "labelTextColor");
      this.labelTextColor.Name = "labelTextColor";
      // 
      // editShabatDay
      // 
      this.editShabatDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.editShabatDay.FormattingEnabled = true;
      resources.ApplyResources(this.editShabatDay, "editShabatDay");
      this.editShabatDay.Name = "editShabatDay";
      // 
      // labelFontName
      // 
      resources.ApplyResources(this.labelFontName, "labelFontName");
      this.labelFontName.Name = "labelFontName";
      // 
      // panelTextColor
      // 
      this.panelTextColor.BackColor = System.Drawing.Color.Black;
      this.panelTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.panelTextColor, "panelTextColor");
      this.panelTextColor.Name = "panelTextColor";
      this.panelTextColor.Click += new System.EventHandler(this.panelTextColor_Click);
      // 
      // labelBackColor
      // 
      resources.ApplyResources(this.labelBackColor, "labelBackColor");
      this.labelBackColor.Name = "labelBackColor";
      // 
      // gPSLatitudeTextBox
      // 
      this.gPSLatitudeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSettings, "Latitude", true));
      resources.ApplyResources(this.gPSLatitudeTextBox, "gPSLatitudeTextBox");
      this.gPSLatitudeTextBox.Name = "gPSLatitudeTextBox";
      // 
      // gPSLongitudeTextBox
      // 
      this.gPSLongitudeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSettings, "Longitude", true));
      resources.ApplyResources(this.gPSLongitudeTextBox, "gPSLongitudeTextBox");
      this.gPSLongitudeTextBox.Name = "gPSLongitudeTextBox";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.buttonClose);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // actionUsePersonalShabat
      // 
      resources.ApplyResources(this.actionUsePersonalShabat, "actionUsePersonalShabat");
      this.actionUsePersonalShabat.LinkColor = System.Drawing.Color.Blue;
      this.actionUsePersonalShabat.Name = "actionUsePersonalShabat";
      this.actionUsePersonalShabat.TabStop = true;
      this.actionUsePersonalShabat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.actionUsePersonalShabat_LinkClicked);
      // 
      // bindingSettings
      // 
      this.bindingSettings.DataSource = typeof(System.Configuration.ApplicationSettingsBase);
      // 
      // PreferencesForm
      // 
      this.AcceptButton = this.buttonClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.actionUsePersonalShabat);
      this.Controls.Add(this.panel1);
      this.Controls.Add(gPSLongitudeLabel);
      this.Controls.Add(this.gPSLongitudeTextBox);
      this.Controls.Add(gPSLatitudeLabel);
      this.Controls.Add(this.gPSLatitudeTextBox);
      this.Controls.Add(this.editFontName);
      this.Controls.Add(this.labelShabatDay);
      this.Controls.Add(this.editFontSize);
      this.Controls.Add(this.labelFontSize);
      this.Controls.Add(this.panelBackColor);
      this.Controls.Add(this.labelTextColor);
      this.Controls.Add(this.editShabatDay);
      this.Controls.Add(this.labelFontName);
      this.Controls.Add(this.panelTextColor);
      this.Controls.Add(this.labelBackColor);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesForm";
      this.ShowInTaskbar = false;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
      this.Shown += new System.EventHandler(this.PreferencesForm_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.editFontSize)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSettings)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ColorDialog dialogColor;
    private System.Windows.Forms.Button buttonClose;
    private System.Windows.Forms.Label labelShabatDay;
    private System.Windows.Forms.Label labelFontSize;
    private System.Windows.Forms.Label labelTextColor;
    private System.Windows.Forms.Label labelFontName;
    private System.Windows.Forms.Label labelBackColor;
    private System.Windows.Forms.BindingSource bindingSettings;
    private System.Windows.Forms.ComboBox editFontName;
    private System.Windows.Forms.NumericUpDown editFontSize;
    private System.Windows.Forms.Panel panelBackColor;
    private System.Windows.Forms.ComboBox editShabatDay;
    private System.Windows.Forms.Panel panelTextColor;
    private System.Windows.Forms.TextBox gPSLatitudeTextBox;
    private System.Windows.Forms.TextBox gPSLongitudeTextBox;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.LinkLabel actionUsePersonalShabat;
  }
}
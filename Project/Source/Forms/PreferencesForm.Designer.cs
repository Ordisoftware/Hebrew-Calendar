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
      System.Windows.Forms.Label gPSLongitudeLabel;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
      this.dialogColor = new System.Windows.Forms.ColorDialog();
      this.buttonClose = new System.Windows.Forms.Button();
      this.editFontName = new System.Windows.Forms.ComboBox();
      this.bindingSettings = new System.Windows.Forms.BindingSource(this.components);
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
      gPSLatitudeLabel = new System.Windows.Forms.Label();
      gPSLongitudeLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSettings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.editFontSize)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // gPSLatitudeLabel
      // 
      gPSLatitudeLabel.AutoSize = true;
      gPSLatitudeLabel.Location = new System.Drawing.Point(38, 66);
      gPSLatitudeLabel.Name = "gPSLatitudeLabel";
      gPSLatitudeLabel.Size = new System.Drawing.Size(45, 13);
      gPSLatitudeLabel.TabIndex = 54;
      gPSLatitudeLabel.Text = "Latitude";
      // 
      // gPSLongitudeLabel
      // 
      gPSLongitudeLabel.AutoSize = true;
      gPSLongitudeLabel.Location = new System.Drawing.Point(29, 92);
      gPSLongitudeLabel.Name = "gPSLongitudeLabel";
      gPSLongitudeLabel.Size = new System.Drawing.Size(54, 13);
      gPSLongitudeLabel.TabIndex = 55;
      gPSLongitudeLabel.Text = "Longitude";
      // 
      // dialogColor
      // 
      this.dialogColor.FullOpen = true;
      // 
      // buttonClose
      // 
      this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonClose.Location = new System.Drawing.Point(382, 3);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new System.Drawing.Size(75, 23);
      this.buttonClose.TabIndex = 0;
      this.buttonClose.Text = "Close";
      this.buttonClose.UseVisualStyleBackColor = true;
      this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
      // 
      // editFontName
      // 
      this.editFontName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSettings, "FontName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.editFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.editFontName.FormattingEnabled = true;
      this.editFontName.Location = new System.Drawing.Point(284, 35);
      this.editFontName.Name = "editFontName";
      this.editFontName.Size = new System.Drawing.Size(175, 21);
      this.editFontName.TabIndex = 5;
      this.editFontName.SelectedIndexChanged += new System.EventHandler(this.editFont_Changed);
      // 
      // bindingSettings
      // 
      this.bindingSettings.DataSource = typeof(System.Configuration.ApplicationSettingsBase);
      // 
      // labelShabatDay
      // 
      this.labelShabatDay.AutoSize = true;
      this.labelShabatDay.Location = new System.Drawing.Point(22, 37);
      this.labelShabatDay.Name = "labelShabatDay";
      this.labelShabatDay.Size = new System.Drawing.Size(61, 13);
      this.labelShabatDay.TabIndex = 48;
      this.labelShabatDay.Text = "Shabat day";
      // 
      // editFontSize
      // 
      this.editFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSettings, "FontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.editFontSize.Location = new System.Drawing.Point(284, 65);
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
      this.editFontSize.Size = new System.Drawing.Size(37, 20);
      this.editFontSize.TabIndex = 6;
      this.editFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.editFontSize.ValueChanged += new System.EventHandler(this.editFont_Changed);
      // 
      // labelFontSize
      // 
      this.labelFontSize.AutoSize = true;
      this.labelFontSize.Location = new System.Drawing.Point(229, 69);
      this.labelFontSize.Name = "labelFontSize";
      this.labelFontSize.Size = new System.Drawing.Size(49, 13);
      this.labelFontSize.TabIndex = 45;
      this.labelFontSize.Text = "Font size";
      // 
      // panelBackColor
      // 
      this.panelBackColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.panelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panelBackColor.Location = new System.Drawing.Point(284, 96);
      this.panelBackColor.Name = "panelBackColor";
      this.panelBackColor.Size = new System.Drawing.Size(25, 25);
      this.panelBackColor.TabIndex = 7;
      this.panelBackColor.Click += new System.EventHandler(this.panelBackColor_Click);
      // 
      // labelTextColor
      // 
      this.labelTextColor.AutoSize = true;
      this.labelTextColor.Location = new System.Drawing.Point(224, 137);
      this.labelTextColor.Name = "labelTextColor";
      this.labelTextColor.Size = new System.Drawing.Size(54, 13);
      this.labelTextColor.TabIndex = 49;
      this.labelTextColor.Text = "Text color";
      // 
      // editShabatDay
      // 
      this.editShabatDay.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSettings, "ShabatDay", true));
      this.editShabatDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.editShabatDay.FormattingEnabled = true;
      this.editShabatDay.Location = new System.Drawing.Point(89, 34);
      this.editShabatDay.Name = "editShabatDay";
      this.editShabatDay.Size = new System.Drawing.Size(100, 21);
      this.editShabatDay.TabIndex = 0;
      // 
      // labelFontName
      // 
      this.labelFontName.AutoSize = true;
      this.labelFontName.Location = new System.Drawing.Point(221, 37);
      this.labelFontName.Name = "labelFontName";
      this.labelFontName.Size = new System.Drawing.Size(57, 13);
      this.labelFontName.TabIndex = 46;
      this.labelFontName.Text = "Font name";
      // 
      // panelTextColor
      // 
      this.panelTextColor.BackColor = System.Drawing.Color.Black;
      this.panelTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panelTextColor.Location = new System.Drawing.Point(284, 131);
      this.panelTextColor.Name = "panelTextColor";
      this.panelTextColor.Size = new System.Drawing.Size(25, 25);
      this.panelTextColor.TabIndex = 8;
      this.panelTextColor.Click += new System.EventHandler(this.panelTextColor_Click);
      // 
      // labelBackColor
      // 
      this.labelBackColor.AutoSize = true;
      this.labelBackColor.Location = new System.Drawing.Point(220, 102);
      this.labelBackColor.Name = "labelBackColor";
      this.labelBackColor.Size = new System.Drawing.Size(58, 13);
      this.labelBackColor.TabIndex = 47;
      this.labelBackColor.Text = "Back color";
      // 
      // gPSLatitudeTextBox
      // 
      this.gPSLatitudeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSettings, "Latitude", true));
      this.gPSLatitudeTextBox.Location = new System.Drawing.Point(89, 64);
      this.gPSLatitudeTextBox.Name = "gPSLatitudeTextBox";
      this.gPSLatitudeTextBox.Size = new System.Drawing.Size(100, 20);
      this.gPSLatitudeTextBox.TabIndex = 3;
      // 
      // gPSLongitudeTextBox
      // 
      this.gPSLongitudeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSettings, "Longitude", true));
      this.gPSLongitudeTextBox.Location = new System.Drawing.Point(90, 90);
      this.gPSLongitudeTextBox.Name = "gPSLongitudeTextBox";
      this.gPSLongitudeTextBox.Size = new System.Drawing.Size(100, 20);
      this.gPSLongitudeTextBox.TabIndex = 4;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.buttonClose);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(10, 172);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(460, 28);
      this.panel1.TabIndex = 57;
      // 
      // actionUsePersonalShabat
      // 
      this.actionUsePersonalShabat.AutoSize = true;
      this.actionUsePersonalShabat.LinkColor = System.Drawing.Color.Blue;
      this.actionUsePersonalShabat.Location = new System.Drawing.Point(87, 14);
      this.actionUsePersonalShabat.Name = "actionUsePersonalShabat";
      this.actionUsePersonalShabat.Size = new System.Drawing.Size(104, 13);
      this.actionUsePersonalShabat.TabIndex = 58;
      this.actionUsePersonalShabat.TabStop = true;
      this.actionUsePersonalShabat.Text = "Use personal shabat";
      this.actionUsePersonalShabat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.actionUsePersonalShabat_LinkClicked);
      // 
      // PreferencesForm
      // 
      this.AcceptButton = this.buttonClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(480, 210);
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
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PreferencesForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Preferences";
      this.Shown += new System.EventHandler(this.PreferencesForm_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.bindingSettings)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.editFontSize)).EndInit();
      this.panel1.ResumeLayout(false);
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
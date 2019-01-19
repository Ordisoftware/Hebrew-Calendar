namespace Calendar.NET
{
    partial class EventDetails
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
            if (disposing && (components != null))
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gbBasics = new System.Windows.Forms.GroupBox();
            this.gbRecurringOptions = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRecurringFrequency = new System.Windows.Forms.ComboBox();
            this.chkThisDayForwardOnly = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.lblFont = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlEventColor = new System.Windows.Forms.Panel();
            this.pnlTextColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIgnoreTimeComponent = new System.Windows.Forms.CheckBox();
            this.chkEnableTooltip = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbBasics.SuspendLayout();
            this.gbRecurringOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event Name:";
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(71, 36);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(200, 20);
            this.txtEventName.TabIndex = 1;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "M/d/yyyy h:mm tt";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(71, 13);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(200, 20);
            this.dtDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Event Date:";
            // 
            // gbBasics
            // 
            this.gbBasics.Controls.Add(this.chkIgnoreTimeComponent);
            this.gbBasics.Controls.Add(this.chkEnabled);
            this.gbBasics.Controls.Add(this.label2);
            this.gbBasics.Controls.Add(this.label1);
            this.gbBasics.Controls.Add(this.dtDate);
            this.gbBasics.Controls.Add(this.txtEventName);
            this.gbBasics.Location = new System.Drawing.Point(12, 12);
            this.gbBasics.Name = "gbBasics";
            this.gbBasics.Size = new System.Drawing.Size(276, 86);
            this.gbBasics.TabIndex = 4;
            this.gbBasics.TabStop = false;
            this.gbBasics.Text = "Basics";
            // 
            // gbRecurringOptions
            // 
            this.gbRecurringOptions.Controls.Add(this.chkThisDayForwardOnly);
            this.gbRecurringOptions.Controls.Add(this.cbRecurringFrequency);
            this.gbRecurringOptions.Controls.Add(this.label3);
            this.gbRecurringOptions.Location = new System.Drawing.Point(12, 104);
            this.gbRecurringOptions.Name = "gbRecurringOptions";
            this.gbRecurringOptions.Size = new System.Drawing.Size(323, 68);
            this.gbRecurringOptions.TabIndex = 5;
            this.gbRecurringOptions.TabStop = false;
            this.gbRecurringOptions.Text = "Recurring Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recurring Frequency:";
            // 
            // cbRecurringFrequency
            // 
            this.cbRecurringFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecurringFrequency.FormattingEnabled = true;
            this.cbRecurringFrequency.Location = new System.Drawing.Point(117, 17);
            this.cbRecurringFrequency.Name = "cbRecurringFrequency";
            this.cbRecurringFrequency.Size = new System.Drawing.Size(200, 21);
            this.cbRecurringFrequency.TabIndex = 1;
            // 
            // chkThisDayForwardOnly
            // 
            this.chkThisDayForwardOnly.AutoSize = true;
            this.chkThisDayForwardOnly.Location = new System.Drawing.Point(8, 48);
            this.chkThisDayForwardOnly.Name = "chkThisDayForwardOnly";
            this.chkThisDayForwardOnly.Size = new System.Drawing.Size(109, 17);
            this.chkThisDayForwardOnly.TabIndex = 2;
            this.chkThisDayForwardOnly.Text = "This Day Forward";
            this.chkThisDayForwardOnly.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(7, 63);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnableTooltip);
            this.groupBox1.Controls.Add(this.pnlTextColor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pnlEventColor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnFont);
            this.groupBox1.Controls.Add(this.lblFont);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appearance Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Font:";
            // 
            // fontDialog1
            // 
            this.fontDialog1.ScriptsOnly = true;
            // 
            // lblFont
            // 
            this.lblFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFont.Location = new System.Drawing.Point(97, 20);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(176, 16);
            this.lblFont.TabIndex = 1;
            this.lblFont.Text = "label5";
            this.lblFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(275, 18);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(24, 20);
            this.btnFont.TabIndex = 2;
            this.btnFont.Text = "...";
            this.btnFont.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.BtnFontClick);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 293);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Event Color:";
            // 
            // pnlEventColor
            // 
            this.pnlEventColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEventColor.Location = new System.Drawing.Point(96, 40);
            this.pnlEventColor.Name = "pnlEventColor";
            this.pnlEventColor.Size = new System.Drawing.Size(30, 15);
            this.pnlEventColor.TabIndex = 4;
            this.pnlEventColor.DoubleClick += new System.EventHandler(this.PnlEventColorDoubleClick);
            // 
            // pnlTextColor
            // 
            this.pnlTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTextColor.Location = new System.Drawing.Point(269, 42);
            this.pnlTextColor.Name = "pnlTextColor";
            this.pnlTextColor.Size = new System.Drawing.Size(30, 15);
            this.pnlTextColor.TabIndex = 6;
            this.pnlTextColor.DoubleClick += new System.EventHandler(this.PnlTextColorDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Event Text Color:";
            // 
            // chkIgnoreTimeComponent
            // 
            this.chkIgnoreTimeComponent.AutoSize = true;
            this.chkIgnoreTimeComponent.Location = new System.Drawing.Point(129, 61);
            this.chkIgnoreTimeComponent.Name = "chkIgnoreTimeComponent";
            this.chkIgnoreTimeComponent.Size = new System.Drawing.Size(139, 17);
            this.chkIgnoreTimeComponent.TabIndex = 5;
            this.chkIgnoreTimeComponent.Text = "Ignore Time Component";
            this.chkIgnoreTimeComponent.UseVisualStyleBackColor = true;
            this.chkIgnoreTimeComponent.CheckedChanged += new System.EventHandler(this.ChkIgnoreTimeComponentCheckedChanged);
            // 
            // chkEnableTooltip
            // 
            this.chkEnableTooltip.AutoSize = true;
            this.chkEnableTooltip.Location = new System.Drawing.Point(131, 70);
            this.chkEnableTooltip.Name = "chkEnableTooltip";
            this.chkEnableTooltip.Size = new System.Drawing.Size(94, 17);
            this.chkEnableTooltip.TabIndex = 7;
            this.chkEnableTooltip.Text = "Enable Tooltip";
            this.chkEnableTooltip.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // EventDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 323);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRecurringOptions);
            this.Controls.Add(this.gbBasics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EventDetails";
            this.Load += new System.EventHandler(this.EventDetailsLoad);
            this.gbBasics.ResumeLayout(false);
            this.gbBasics.PerformLayout();
            this.gbRecurringOptions.ResumeLayout(false);
            this.gbRecurringOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbBasics;
        private System.Windows.Forms.GroupBox gbRecurringOptions;
        private System.Windows.Forms.ComboBox cbRecurringFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkThisDayForwardOnly;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel pnlEventColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlTextColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIgnoreTimeComponent;
        private System.Windows.Forms.CheckBox chkEnableTooltip;
        private System.Windows.Forms.Button btnCancel;
    }
}
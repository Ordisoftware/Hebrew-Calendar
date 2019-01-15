namespace Ordisoftware.HebrewCalendar
{
  partial class ShowDayForm
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.labelDate = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.pictureMoon = new System.Windows.Forms.PictureBox();
      this.labelMoonsetValue = new System.Windows.Forms.Label();
      this.labelMoonriseValue = new System.Windows.Forms.Label();
      this.labelSunsetValue = new System.Windows.Forms.Label();
      this.labelSunriseValue = new System.Windows.Forms.Label();
      this.labelMoonset = new System.Windows.Forms.Label();
      this.labelMoonrise = new System.Windows.Forms.Label();
      this.labelLunarDayValue = new System.Windows.Forms.Label();
      this.labelLunarMonthValue = new System.Windows.Forms.Label();
      this.labelSunset = new System.Windows.Forms.Label();
      this.labelSunrise = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.buttonPreviousDay = new System.Windows.Forms.Button();
      this.buttonNextDay = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMoon)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.panel1.Controls.Add(this.labelDate);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(5);
      this.panel1.Size = new System.Drawing.Size(294, 35);
      this.panel1.TabIndex = 0;
      // 
      // labelDate
      // 
      this.labelDate.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelDate.Location = new System.Drawing.Point(5, 5);
      this.labelDate.Name = "labelDate";
      this.labelDate.Size = new System.Drawing.Size(284, 25);
      this.labelDate.TabIndex = 0;
      this.labelDate.Text = "labelDate";
      this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.buttonNextDay);
      this.panel2.Controls.Add(this.buttonPreviousDay);
      this.panel2.Controls.Add(this.pictureMoon);
      this.panel2.Controls.Add(this.labelMoonsetValue);
      this.panel2.Controls.Add(this.labelMoonriseValue);
      this.panel2.Controls.Add(this.labelSunsetValue);
      this.panel2.Controls.Add(this.labelSunriseValue);
      this.panel2.Controls.Add(this.labelMoonset);
      this.panel2.Controls.Add(this.labelMoonrise);
      this.panel2.Controls.Add(this.labelLunarDayValue);
      this.panel2.Controls.Add(this.labelLunarMonthValue);
      this.panel2.Controls.Add(this.labelSunset);
      this.panel2.Controls.Add(this.labelSunrise);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 35);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(294, 158);
      this.panel2.TabIndex = 5;
      // 
      // pictureMoon
      // 
      this.pictureMoon.Location = new System.Drawing.Point(2, 2);
      this.pictureMoon.Name = "pictureMoon";
      this.pictureMoon.Size = new System.Drawing.Size(75, 75);
      this.pictureMoon.TabIndex = 15;
      this.pictureMoon.TabStop = false;
      // 
      // labelMoonsetValue
      // 
      this.labelMoonsetValue.AutoSize = true;
      this.labelMoonsetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelMoonsetValue.Location = new System.Drawing.Point(100, 125);
      this.labelMoonsetValue.Name = "labelMoonsetValue";
      this.labelMoonsetValue.Size = new System.Drawing.Size(39, 16);
      this.labelMoonsetValue.TabIndex = 11;
      this.labelMoonsetValue.Text = "00:00";
      // 
      // labelMoonriseValue
      // 
      this.labelMoonriseValue.AutoSize = true;
      this.labelMoonriseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelMoonriseValue.Location = new System.Drawing.Point(100, 105);
      this.labelMoonriseValue.Name = "labelMoonriseValue";
      this.labelMoonriseValue.Size = new System.Drawing.Size(39, 16);
      this.labelMoonriseValue.TabIndex = 12;
      this.labelMoonriseValue.Text = "00:00";
      // 
      // labelSunsetValue
      // 
      this.labelSunsetValue.AutoSize = true;
      this.labelSunsetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSunsetValue.Location = new System.Drawing.Point(100, 80);
      this.labelSunsetValue.Name = "labelSunsetValue";
      this.labelSunsetValue.Size = new System.Drawing.Size(39, 16);
      this.labelSunsetValue.TabIndex = 13;
      this.labelSunsetValue.Text = "00:00";
      // 
      // labelSunriseValue
      // 
      this.labelSunriseValue.AutoSize = true;
      this.labelSunriseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSunriseValue.Location = new System.Drawing.Point(100, 60);
      this.labelSunriseValue.Name = "labelSunriseValue";
      this.labelSunriseValue.Size = new System.Drawing.Size(39, 16);
      this.labelSunriseValue.TabIndex = 14;
      this.labelSunriseValue.Text = "00:00";
      // 
      // labelMoonset
      // 
      this.labelMoonset.AutoSize = true;
      this.labelMoonset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelMoonset.Location = new System.Drawing.Point(138, 125);
      this.labelMoonset.Name = "labelMoonset";
      this.labelMoonset.Size = new System.Drawing.Size(60, 16);
      this.labelMoonset.TabIndex = 6;
      this.labelMoonset.Text = "Moonset";
      // 
      // labelMoonrise
      // 
      this.labelMoonrise.AutoSize = true;
      this.labelMoonrise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelMoonrise.Location = new System.Drawing.Point(138, 105);
      this.labelMoonrise.Name = "labelMoonrise";
      this.labelMoonrise.Size = new System.Drawing.Size(64, 16);
      this.labelMoonrise.TabIndex = 7;
      this.labelMoonrise.Text = "Moonrise";
      // 
      // labelLunarDayValue
      // 
      this.labelLunarDayValue.AutoSize = true;
      this.labelLunarDayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelLunarDayValue.Location = new System.Drawing.Point(100, 35);
      this.labelLunarDayValue.Name = "labelLunarDayValue";
      this.labelLunarDayValue.Size = new System.Drawing.Size(149, 16);
      this.labelLunarDayValue.TabIndex = 8;
      this.labelLunarDayValue.Text = "labelLunarDayValue";
      // 
      // labelLunarMonthValue
      // 
      this.labelLunarMonthValue.AutoSize = true;
      this.labelLunarMonthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelLunarMonthValue.Location = new System.Drawing.Point(100, 15);
      this.labelLunarMonthValue.Name = "labelLunarMonthValue";
      this.labelLunarMonthValue.Size = new System.Drawing.Size(162, 16);
      this.labelLunarMonthValue.TabIndex = 9;
      this.labelLunarMonthValue.Text = "labelLunarMonthValue";
      // 
      // labelSunset
      // 
      this.labelSunset.AutoSize = true;
      this.labelSunset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSunset.Location = new System.Drawing.Point(138, 60);
      this.labelSunset.Name = "labelSunset";
      this.labelSunset.Size = new System.Drawing.Size(53, 16);
      this.labelSunset.TabIndex = 10;
      this.labelSunset.Text = "Sunrise";
      // 
      // labelSunrise
      // 
      this.labelSunrise.AutoSize = true;
      this.labelSunrise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelSunrise.Location = new System.Drawing.Point(138, 80);
      this.labelSunrise.Name = "labelSunrise";
      this.labelSunrise.Size = new System.Drawing.Size(49, 16);
      this.labelSunrise.TabIndex = 5;
      this.labelSunrise.Text = "Sunset";
      // 
      // panel3
      // 
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 35);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(294, 1);
      this.panel3.TabIndex = 6;
      // 
      // buttonPreviousDay
      // 
      this.buttonPreviousDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.buttonPreviousDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonPreviousDay.Location = new System.Drawing.Point(3, 130);
      this.buttonPreviousDay.Name = "buttonPreviousDay";
      this.buttonPreviousDay.Size = new System.Drawing.Size(25, 25);
      this.buttonPreviousDay.TabIndex = 16;
      this.buttonPreviousDay.Text = "<";
      this.buttonPreviousDay.UseVisualStyleBackColor = true;
      this.buttonPreviousDay.Click += new System.EventHandler(this.buttonPreviousDay_Click);
      // 
      // buttonNextDay
      // 
      this.buttonNextDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.buttonNextDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonNextDay.Location = new System.Drawing.Point(266, 130);
      this.buttonNextDay.Name = "buttonNextDay";
      this.buttonNextDay.Size = new System.Drawing.Size(25, 25);
      this.buttonNextDay.TabIndex = 16;
      this.buttonNextDay.Text = ">";
      this.buttonNextDay.UseVisualStyleBackColor = true;
      this.buttonNextDay.Click += new System.EventHandler(this.buttonNextDay_Click);
      // 
      // ShowDayForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(294, 193);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ShowDayForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Hebrew Calendar";
      this.TopMost = true;
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureMoon)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    internal System.Windows.Forms.Label labelDate;
    private System.Windows.Forms.Panel panel2;
    internal System.Windows.Forms.PictureBox pictureMoon;
    internal System.Windows.Forms.Label labelMoonsetValue;
    internal System.Windows.Forms.Label labelMoonriseValue;
    internal System.Windows.Forms.Label labelSunsetValue;
    internal System.Windows.Forms.Label labelSunriseValue;
    internal System.Windows.Forms.Label labelMoonset;
    internal System.Windows.Forms.Label labelMoonrise;
    internal System.Windows.Forms.Label labelLunarDayValue;
    internal System.Windows.Forms.Label labelLunarMonthValue;
    internal System.Windows.Forms.Label labelSunset;
    internal System.Windows.Forms.Label labelSunrise;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button buttonNextDay;
    private System.Windows.Forms.Button buttonPreviousDay;
  }
}
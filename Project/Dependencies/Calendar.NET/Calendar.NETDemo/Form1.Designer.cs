namespace Calendar.NETDemo
{
    partial class Form1
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
      this.calendar1 = new Calendar.NET.Calendar();
      this.SuspendLayout();
      // 
      // calendar1
      // 
      this.calendar1.AllowEditingEvents = false;
      this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.calendar1.BackColor = System.Drawing.Color.Transparent;
      this.calendar1.CalendarDate = new System.DateTime(2012, 4, 24, 13, 16, 0, 0);
      this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
      this.calendar1.DateHeaderFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.calendar1.DayOfWeekFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.calendar1.DaysFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.calendar1.DayViewTimeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.calendar1.DimDisabledEvents = true;
      this.calendar1.HighlightCurrentDay = true;
      this.calendar1.LoadPresetHolidays = false;
      this.calendar1.Location = new System.Drawing.Point(12, 12);
      this.calendar1.Name = "calendar1";
      this.calendar1.ShowArrowControls = false;
      this.calendar1.ShowDashedBorderOnDisabledEvents = true;
      this.calendar1.ShowDateInHeader = true;
      this.calendar1.ShowDisabledEvents = false;
      this.calendar1.ShowEventTooltips = false;
      this.calendar1.ShowTodayButton = false;
      this.calendar1.Size = new System.Drawing.Size(714, 497);
      this.calendar1.TabIndex = 0;
      this.calendar1.TodayFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(805, 530);
      this.Controls.Add(this.calendar1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

        }

        #endregion

        private NET.Calendar calendar1;


    }
}


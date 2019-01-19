namespace Calendar.NET
{
    partial class CoolButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CoolButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Name = "CoolButton";
            this.Size = new System.Drawing.Size(72, 29);
            this.Load += new System.EventHandler(this.CoolButtonLoad);
            this.SizeChanged += new System.EventHandler(this.CoolButtonSizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CoolButtonPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CoolButtonMouseDown);
            this.MouseEnter += new System.EventHandler(this.CoolButtonMouseEnter);
            this.MouseLeave += new System.EventHandler(this.CoolButtonMouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CoolButtonMouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

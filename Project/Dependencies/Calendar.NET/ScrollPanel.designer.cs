namespace Calendar.NET
{
    partial class ScrollPanel
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
            // ScrollPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "ScrollPanel";
            this.Size = new System.Drawing.Size(280, 242);
            this.Load += new System.EventHandler(this.ScrollPanel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrollPanel_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScrollPanel_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScrollPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScrollPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScrollPanel_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

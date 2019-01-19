namespace Calendar.NET
{
    internal class NavigateLeftButton : CoolButton
    {
        public NavigateLeftButton()
        {
            Size = new System.Drawing.Size(42, 29);
            ButtonText = "<";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NavigateLeftButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.DoubleBuffered = true;
            this.Name = "NavigateLeftButton";
            this.ResumeLayout(false);

        }
    }
}

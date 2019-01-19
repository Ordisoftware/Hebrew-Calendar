namespace Calendar.NET
{
    internal class TodayButton : CoolButton
    {
        public TodayButton()
        {
            Size = new System.Drawing.Size(72, 29);
            ButtonText = "Today";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TodayButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.DoubleBuffered = true;
            this.Name = "TodayButton";
            this.ResumeLayout(false);

        }
    }
}

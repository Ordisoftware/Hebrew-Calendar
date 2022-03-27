namespace CodeProjectCalendar.NET
{
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  internal class TodayButton : CoolButton
  {
    public TodayButton()
    {
      Size = new System.Drawing.Size(85, 29);
      ButtonText = "Today";
      //}

      //private void InitializeComponent()
      //{
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

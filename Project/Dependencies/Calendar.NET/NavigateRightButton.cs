﻿namespace CodeProjectCalendar.NET
{
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  internal class NavigateRightButton : CoolButton
  {
    public NavigateRightButton()
    {
      Size = new System.Drawing.Size(42, 29);
      ButtonText = ">";
      //}

      //private void InitializeComponent()
      //{
      this.SuspendLayout();
      // 
      // NavigateRightButton
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.DoubleBuffered = true;
      this.Name = "NavigateRightButton";
      this.ResumeLayout(false);

    }
  }
}

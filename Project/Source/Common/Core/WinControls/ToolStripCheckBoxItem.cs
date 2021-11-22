namespace Ordisoftware.Core;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

// https://social.msdn.microsoft.com/Forums/windows/en-US/6b6f71af-902f-440d-8b33-8d57403300eb/add-check-box-to-binding-navigator-control?forum=winforms
[DefaultBindingProperty("CheckState")]
[DefaultEvent("CheckedChanged")]
[DefaultProperty("Checked")]
[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
public class ToolStripCheckBoxItem : ToolStripControlHost
{

  private readonly CheckBox CheckBox = new();

  public bool Checked
  {
    get { return CheckBox.Checked; }
    set { CheckBox.Checked = value; }
  }

  public event EventHandler CheckedChanged
  {
    add => CheckBox.CheckedChanged += value;
    remove => CheckBox.CheckedChanged -= value;
  }

  public ToolStripCheckBoxItem() : base(new FlowLayoutPanel())
  {
    var panel = (FlowLayoutPanel)Control;
    panel.BackColor = Color.Transparent;
    CheckBox.AutoSize = true;
    CheckBox.Text = string.Empty;
    AutoSize = false;
    Width = 20;
    Height = 20;
    panel.Controls.Add(CheckBox);
  }

}

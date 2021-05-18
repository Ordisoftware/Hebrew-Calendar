// https://social.msdn.microsoft.com/Forums/windows/en-US/6b6f71af-902f-440d-8b33-8d57403300eb/add-check-box-to-binding-navigator-control?forum=winforms
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Ordisoftware.Core
{

  [DefaultBindingProperty("CheckState")]
  [DefaultEvent("CheckedChanged")]
  [DefaultProperty("Checked")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
  public class CheckBoxToolStripItem : ToolStripControlHost
  {

    private FlowLayoutPanel ControlPanel;
    private CheckBox CheckBox = new CheckBox();

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

    public CheckBoxToolStripItem() : base(new FlowLayoutPanel())
    {
      ControlPanel = (FlowLayoutPanel)Control;
      ControlPanel.BackColor = Color.Transparent;
      CheckBox.AutoSize = true;
      CheckBox.Text = string.Empty;
      AutoSize = false;
      Width = 20;
      Height = 20;
      ControlPanel.Controls.Add(CheckBox);
    }

  }

}

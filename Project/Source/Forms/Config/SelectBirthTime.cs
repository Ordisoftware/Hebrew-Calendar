using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectBirthTime : Form
  {

    public SelectBirthTime()
    {
      InitializeComponent();
    }

    private void ActionOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }
  }

}

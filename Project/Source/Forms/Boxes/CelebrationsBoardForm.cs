using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class CelebrationsBoardForm : Form
  {

    public CelebrationsBoardForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void CelebrationsBoardForm_Load(object sender, EventArgs e)
    {
      // Create board
      var board = new DataTable();
      board.PrimaryKey = new DataColumn[] { board.Columns.Add(AppTranslations.Year.GetLang(), typeof(int)) };
      foreach ( TorahEvent col in Enum.GetValues(typeof(TorahEvent)) )
        if ( col != TorahEvent.None && col < TorahEvent.SoukotD8 ) // TODO change when others managed
          board.Columns.Add(col.ToStringExport(AppTranslations.TorahEvent), typeof(DateTime));
      // Get data
      var query = from day in MainForm.Instance.DataSet.LunisolarDays
                  where day.TorahEventsAsEnum != TorahEvent.None
                     && day.TorahEventsAsEnum < TorahEvent.SoukotD8 // TODO change when others managed
                  select new
                  {
                    date = SQLiteDate.ToDateTime(day.Date),
                    torah = day.TorahEventsAsEnum
                  };
      // Fill table
      foreach ( var item in query )
      {
        var row = board.Rows.Find(item.date.Year);
        if ( row != null )
          row[(int)item.torah] = item.date;
        else
        {
          row = board.NewRow();
          row[0] = item.date.Year;
          row[(int)item.torah] = item.date;
          board.Rows.Add(row);
        }
      }
      board.AcceptChanges();
      // Display
      DataGridView.CellFormatting += DataGridView_CellFormatting;
      DataGridView.DataSource = board;
      // TODO clickable link
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if ( e.ColumnIndex > 0 && e.Value != null )
        if (checkBox1.Checked)
          e.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(( (DateTime)e.Value ).ToLongDateString());
        else
          e.Value = ( (DateTime)e.Value ).ToShortDateString();
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      DataGridView.Font = new Font("Microsoft Sans Serif", (float)numericUpDown1.Value);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      DataGridView.Refresh();
      DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }

  }

}

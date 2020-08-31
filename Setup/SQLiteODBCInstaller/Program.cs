using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SQLiteODBCInstaller
{

  static class Program
  {

    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      if ( IntPtr.Size > 4 )
        RunShell("..\\SQLiteODBC\\sqliteodbc_w64.exe", "/S");
      else
        RunShell("..\\SQLiteODBC\\sqliteodbc.exe", "/S");
    }

    static public void RunShell(string filename, string arguments = "")
    {
      using ( var process = new Process() )
        try
        {
          process.StartInfo.FileName = filename;
          process.StartInfo.Arguments = arguments;
          process.Start();
        }
        catch ( Exception ex )
        {
          MessageBox.Show(ex.Message + Environment.NewLine + process.StartInfo.FileName);
        }
    }

  }

}

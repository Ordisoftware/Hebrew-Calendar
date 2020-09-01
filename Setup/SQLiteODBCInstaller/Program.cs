using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SQLiteODBCInstaller
{

  static class Program
  {

    [STAThread]
    static void Main(string[] args)
    {
      string arguments = string.Join(" ", args);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      if ( IntPtr.Size > 4 )
        RunShell("..\\SQLiteODBC\\sqliteodbc_w64.exe", arguments);
      else
        RunShell("..\\SQLiteODBC\\sqliteodbc.exe", arguments);
    }

    static public void RunShell(string filename, string arguments = "")
    {
      var process = new Process();
      try
      {
        process.StartInfo.FileName = filename;
        process.StartInfo.Arguments = arguments;
        process.Start();
        process.WaitForExit();
      }
      catch ( Exception ex )
      {
        MessageBox.Show(ex.Message + Environment.NewLine + filename);
      }
    }

  }

}

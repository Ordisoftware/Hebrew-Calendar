using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SQLiteODBCInstaller
{

  static class Program
  {

    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      try
      {
        using ( RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\SQLite3 Datasource") )
          if ( key != null )
          {
            var o = key.GetValue("Driver");
            if ( o != null )
              if ( (string)o == "C:\\Windows\\system32\\sqlite3odbc.dll" )
                return;
          }
      }
      catch ( Exception ex )
      {
        MessageBox.Show(ex.Message);
      }
      if ( IntPtr.Size == 8 )
        RunShell("sqliteodbc_w64.exe", "/S");
      else
        RunShell("sqliteodbc.exe", "/S");
    }

    static public void RunShell(string filename, string arguments)
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Ordisoftware.SQLiteODBCInstaller
{

  static class Program
  {

    private const string SQLiteODBCSetupPath = "..\\SQLiteODBC\\";

    private const string SQLiteODBCSetupFileame32 = SQLiteODBCSetupPath + "sqliteodbc.exe";
    private const string SQLiteODBCSetupFilename64 = SQLiteODBCSetupPath + "sqliteodbc_w64.exe";

    static public readonly Dictionary<string, string> CloseApplicationText
      = new Dictionary<string, string>
      {
        { "en", $"Close these applications, please:{Environment.NewLine}{Environment.NewLine}{{0}}" },
        { "fr", $"Veuillez fermer ces applications :{Environment.NewLine}{Environment.NewLine}{{0}}" }
      };

    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      if ( args.Length > 0 )
        if ( args[0] == "english" ) lang = "en"; 
        else
        if ( args[0] == "french" ) lang = "fr";
      string arguments = string.Join(" ", args.Skip(1));
      if ( !CloseApplicationText.Keys.Contains(lang) ) lang = "en";
      DialogResult result = DialogResult.None;
      List<Process> processes = GetOrdisoftwareHebrewProcesses();
      while ( processes.Count() != 0 && result != DialogResult.Cancel )
      {
        var applications = string.Join(Environment.NewLine, processes.Select(p => p.ProcessName));
        string msg = string.Format(CloseApplicationText[lang], applications);
        result = MessageBox.Show(msg, AssemblyTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        processes = GetOrdisoftwareHebrewProcesses();
      }
      if ( processes.Count() != 0 || result == DialogResult.Cancel ) return;
      RunShell(IntPtr.Size > 4 ? SQLiteODBCSetupFilename64 : SQLiteODBCSetupFileame32, arguments);
    }

    static private List<Process> GetOrdisoftwareHebrewProcesses()
    {
      return Process.GetProcesses().Where(p => p.ProcessName.Contains("Ordisoftware.Hebrew")).ToList();
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

    static public string AssemblyTitle
    {
      get
      {
        var assembly = Assembly.GetExecutingAssembly();
        var attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if ( attributes.Length > 0 )
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if ( titleAttribute.Title != "" )
            return titleAttribute.Title;
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

  }

}

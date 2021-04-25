using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.SQLiteODBCInstaller
{

  static class Program
  {

    private const string SQLiteODBCSetupPath = @"..\..\SQLiteODBC\";

    private const string SQLiteODBCSetupFileame32 = SQLiteODBCSetupPath + "sqliteodbc.exe";
    private const string SQLiteODBCSetupFilename64 = SQLiteODBCSetupPath + "sqliteodbc_w64.exe";

    static private string NL = Environment.NewLine;
    static private string NL2 = NL + NL;

    static public readonly TranslationsDictionary CloseApplicationText
      = new TranslationsDictionary
      {
        [Language.EN] = "This or these applications must be closed:" + NL2 +
                        "{0}" + NL2 +
                        "Do you want to try to close them automatically?",

        [Language.FR] = "Cette ou ces applications doivent être fermées :" + NL2 +
                        "{0}" + NL2 +
                        "Voulez-vous tenter de les fermer automatiquement ?"
      };

    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      CultureInfo culture = null;
      if ( args.Length > 0 )
      {
        if ( args[0] == "english" ) culture = new CultureInfo("en-US");
        else
        if ( args[0] == "french" ) culture = new CultureInfo("fr-FR");
      }
      else
        culture = CultureInfo.CurrentCulture;
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      string arguments = string.Join(" ", args.Skip(1).ToArray());
      DialogResult result = DialogResult.None;
      List<Process> processes = GetProcesses();
      while ( processes.Count() != 0 && result != DialogResult.Cancel )
      {
        var applications = string.Join(NL, processes.Select(p => p.ProcessName).ToArray());
        var form = new MessageBoxEx(AssemblyTitle,
                                    CloseApplicationText.GetLang(applications.Indent(5, 5)),
                                    buttons: MessageBoxButtons.RetryCancel,
                                    icon: MessageBoxIcon.Exclamation);
        form.ActionYes.Visible = true;
        form.ActiveControl = form.ActionRetry;
        form.AcceptButton = form.ActionYes;
        form.CancelButton = form.ActionCancel;
        form.ShowInTaskbar = true;
        result = form.ShowDialog();
        if ( result == DialogResult.Yes )
        {
          foreach ( var process in processes )
            try { process.Kill(); }
            catch { }
          Thread.Sleep(2000);
        }
        processes = GetProcesses();
      }
      if ( processes.Count() != 0 || result == DialogResult.Cancel ) return;
      RunShell(IntPtr.Size > 4 ? SQLiteODBCSetupFilename64 : SQLiteODBCSetupFileame32, arguments);
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

    static public string Indent(this string str, int first, int corpus)
    {
      return new string(' ', first) + str.Replace(NL, NL + new string(' ', corpus));
    }

    static private List<Process> GetProcesses()
    {
      return Process.GetProcesses().Where(p => p.ProcessName.Contains("Ordisoftware.")).ToList();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Infralution.Localization;
namespace TestCultureManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateLanguageMenus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateLanguageMenus()
        {
            CultureInfo culture = CultureManager.ApplicationUICulture;
            englishToolStripMenuItem.Checked = (culture.TwoLetterISOLanguageName == "en");
            frenchToolStripMenuItem.Checked = (culture.TwoLetterISOLanguageName == "fr");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureManager.ApplicationUICulture = new CultureInfo("en-us");
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureManager.ApplicationUICulture = new CultureInfo("fr-fr");
        }

        private void cultureManager_UICultureChanged(CultureInfo newCulture)
        {
            UpdateLanguageMenus();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace DandTSoftware.Timers.WindowsApplication
{
    public partial class Form1 : Form
    {
        // A timer which happens at midnight
        private DandTSoftware.Timers.MidnightTimer m_MidnightTimer = new MidnightTimer();

        // A timer which happens 10mins past midnight
        private DandTSoftware.Timers.MidnightTimer m_MidnightTimer_plus10 = new MidnightTimer(10);

        /// <summary>
        /// Constructor for the Form
        /// </summary>
        public Form1()
        {
            // Startard stuff...
            InitializeComponent();

            // Lets setup a event handler for when the application exits to stop our timers
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            // Example Code below:

            // Midnight Timer Test
            this.m_MidnightTimer.TimeReached += new TimeReachedEventHandler(this.m_MidnightTimer_TimeReached);
            this.m_MidnightTimer.Start();

            // Midnight Timer + 10mins Test
            this.m_MidnightTimer_plus10.TimeReached += new TimeReachedEventHandler(this.m_MidnightTimer_plus10_TimeReached);
            this.m_MidnightTimer_plus10.Start();
        }

        private void m_MidnightTimer_TimeReached(DateTime Time)
        {
            // Show a message box
            MessageBox.Show(string.Format("Midnight Timer Raised. It is now : {0}", Time.ToString()));
        }


        private void m_MidnightTimer_plus10_TimeReached(DateTime Time)
        {
            // Show a message box
            MessageBox.Show(string.Format("Midnight Timer Raised. It is now 10mins past midnight: {0}", Time.ToString()));
        }


        /// <summary>
        /// Fires when the application exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            // when the application exits, stop the timers
            this.m_MidnightTimer.Stop();
            this.m_MidnightTimer_plus10.Stop();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        private DateTime startTimer;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void START_Click(object sender, EventArgs e)
        {
            startTimer = DateTime.Now;        //strat the timer 

            formTimer.Start();                //start stopwatch
        }

        private void STOP_Click(object sender, EventArgs e)
        {
            formTimer.Stop();
        }

        private void RESTART_Click(object sender, EventArgs e)
        {
            formTimer.Stop();
            StopWatch.Text = "00:00.0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - startTimer;
            StopWatch.Text = span.ToString(@"mm\:ss\.ff");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My2D_Engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MicroTimerTest();
        }
        #region 全局变量 
        int TimerTickCount = 0; 
        int TimerInterval = 1000; 
        bool bTimerStart = false;
        #endregion
        MicroTimer microTimer = null;
        double period = 0;
        double time1 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            bTimerStart = !bTimerStart;
            if (bTimerStart)
            {
                time1 = TimerTickCount;
                //this.timer1.Start();
                this.microTimer.Enabled = true;
                this.button1.Text = "STOP";
            }
            else
            {
                //this.timer1.Stop();
                this.microTimer.Abort();
                this.microTimer.Enabled = false;
                this.button1.Text = "START";
                time1 = TimerTickCount - time1;
                this.label2.Text = (TimerInterval * time1 / 1000).ToString();
                this.toolStripStatusLabel1.Text = "TimerTickCounts=" + TimerTickCount.ToString();
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerTickCount++;
            //this.timer1.
            //this.toolStripStatusLabel1.Text = "TimerTickCounts=" + TimerTickCount.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "TimerTickCounts=" + TimerTickCount.ToString();
            this.button1.Enabled = false;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != "")
            {
                TimerInterval = int.Parse(this.comboBox1.Text);
                this.timer1.Interval = TimerInterval;
                this.button1.Enabled = true;
                this.button1.Focus();
            }
        }
        private void MicroTimerTest()
        {
            // Instantiate new MicroTimer and add event handler
            microTimer = new MicroTimer();
            microTimer.SetLowAccuracy();
            microTimer.MicroTimerElapsed += new MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
            microTimer.Interval = 1000; // Call micro timer every 1000µs (1ms)
        }
        private void OnTimedEvent(object sender, MicroTimerEventArgs timerEventArgs)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    this.toolStripStatusLabel1.Text = TimerTickCount.ToString();
                }));
                TimerTickCount++;
            }
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

    }
}

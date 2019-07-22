using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace GUI
{
    public partial class frmSplash : Form
    {
        private bool fadein = true;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;

        public frmSplash()
        {
            InitializeComponent();
            this.Opacity = 0;
            if (timer1 == null)
            {
                timer1 = new System.Windows.Forms.Timer();
                timer1.Enabled = true;
                timer1.Interval = 300;
                timer1.Tick += Timer_Tick;
            }

            if (timer2 == null)
            {
                timer2 = new System.Windows.Forms.Timer();
                timer2.Enabled = false;
                timer2.Interval = 1200;
                timer2.Tick += Timer2_Tick;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (fadein && this.Opacity<1)
            {
                this.Opacity += 0.1;
            }
            else
            {
                fadein = false;
                timer2.Enabled = true;
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            
        }
    }
}

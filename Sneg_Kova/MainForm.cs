using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sneg_Kova
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TimerInitialize();
        }
        private void TimerInitialize()
        {
            Timer timerSnow = new Timer
            {
                Interval = 80
            };
            timerSnow.Tick += timerSnow_Tick;
            timerSnow.Start();
        }

        private void timerSnow_Tick(object sender, EventArgs e)
        {

        }
    }
}

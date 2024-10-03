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
        private List<Snowflake> snowflakes;
        public MainForm()
        {
            InitializeComponent();
            InitializeSnowflakes();
            TimerInitialize();
        }

        private void InitializeSnowflakes()
        {
            const int initialCount = 50;
            var snowflakes = new List<Snowflake>();
            for (int i = 0; i < initialCount; i++)
            {
                float weight = new Random().Next(1, 10);
                snowflakes.Add(new Snowflake(weight, this));
            }
            this.snowflakes = snowflakes;
        }
        private void TimerInitialize()
        {
            Timer timerSnow = new Timer
            {
                Interval = 16
            };
            timerSnow.Tick += timerSnow_Tick;
            timerSnow.Start();
        }

        private void timerSnow_Tick(object sender, EventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.UpdatePosition();
            }
            Invalidate();
        }
    }
}

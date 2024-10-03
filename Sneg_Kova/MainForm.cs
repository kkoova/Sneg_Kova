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
        private Snowflake[] snowflakes;
        public MainForm()
        {
            InitializeComponent();
            InitializeSnowflakes();
            TimerInitialize();
        }

        private void InitializeSnowflakes()
        {
            const int initialCount = 50;
            var snowflakes = new Snowflake[initialCount];
            for (int i = 0; i < initialCount; i++)
            {
                float weight = new Random().Next(1, 10); // Вес снежинка от 1 до 10
                snowflakes[i] = new Snowflake(weight);
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

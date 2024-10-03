using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sneg_Kova
{
    public partial class MainForm : Form
    {
        private List<Snowflake> snowflakes = new List<Snowflake>();
        private Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
            CreateSnowflakes(100);
            TimerInitialize();
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
            UpdateSnowflakes();
            Invalidate();
        }

        private void UpdateSnowflakes()
        {
            for (int i = 0; i < snowflakes.Count; i++)
            {
                snowflakes[i].Y += snowflakes[i].Speed;
                if (snowflakes[i].Y > this.ClientSize.Height)
                {
                    snowflakes[i].Y = 0;
                    snowflakes[i].X = random.Next(0, this.ClientSize.Width);
                }
            }
        }

        private void CreateSnowflakes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                snowflakes.Add(new Snowflake
                {
                    X = random.Next(0, this.ClientSize.Width),
                    Y = random.Next(0, this.ClientSize.Height),
                    Speed = random.Next(1, 5),
                    Size = random.Next(2, 6)
                });
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            foreach (var snowflake in snowflakes)
            {
                g.FillEllipse(Brushes.White, snowflake.X, snowflake.Y, snowflake.Size, snowflake.Size);
            }
        }
    }
}

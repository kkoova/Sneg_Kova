using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sneg_Kova
{
    public partial class MainForm : Form
    {
        private readonly List<Snowflake> snowflakes = new List<Snowflake>();
        private readonly Random random = new Random();

        /// <summary>
        /// Инициализация главной формы <see cref="MainForm"/>
        /// Создание снежинок <see cref="CreateSnowflakes(int)"/> 
        /// и инициализация таймера <see cref="TimerInitialize"/>
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            CreateSnowflakes(100);
            TimerInitialize();
        }

        /// <summary>
        /// Создание и настройка таймера <see cref="timerSnow"/>
        /// </summary>
        private void TimerInitialize()
        {
            var timerSnow = new Timer
            {
                Interval = 16
            };
            timerSnow.Tick += TimerSnow_Tick;
            timerSnow.Start();
        }

        /// <summary>
        /// Обновление снежинок <see cref="UpdateSnowflakes"/> 
        /// и отчистка поверхности элемента каждый тик таймера 
        /// </summary>
        private void TimerSnow_Tick(object sender, EventArgs e)
        {
            UpdateSnowflakes();
            Invalidate();
        }

        /// <summary>
        /// Обновление снежинок
        /// </summary>
        private void UpdateSnowflakes()
        {
            for (int i = 0; i < snowflakes.Count; i++)
            {
                snowflakes[i].Y += snowflakes[i].Speed;
                if (snowflakes[i].Y > ClientSize.Height)
                {
                    snowflakes[i].Y = 0;
                    snowflakes[i].X = random.Next(0, ClientSize.Width);
                }
            }
        }
        
        /// <summary>
        /// Создание снежинок
        /// </summary>
        /// <param name="count">Количество снежинок</param>
        private void CreateSnowflakes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                snowflakes.Add(new Snowflake
                {
                    X = random.Next(0, ClientSize.Width),
                    Y = random.Next(0, ClientSize.Height),
                    Speed = random.Next(1, 5),
                    Size = random.Next(2, 6),
                });
            }
        }
        
        /// <summary>
        /// Отрисовка снежинок 
        /// </summary>
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

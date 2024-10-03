using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sneg_Kova
{
    public class Snowflake
    {
        public PictureBox Control { get; set; }
        public float Weight { get; set; }
        public float Speed { get; set; }
        private MainForm Main;

        public Snowflake(float weight, MainForm Main)
        {
            this.Main = Main;
            Weight = weight;
            Speed = CalculateSpeed(Weight);
            CreateControl();
        }

        private void CreateControl()
        {
            Control = new PictureBox
            {
                Parrent = Properties.Resources.ss,
                Size = new Size(100, 100), // Увеличьте размер
                //BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,
                Parent = Main,
            };


            Control.Location = new Point(
                new Random().Next(Control.Parent.ClientRectangle.Width),
                0);
        }

        private float CalculateSpeed(float weight)
        {
            return 1f / (weight * 0.1f + 0.5f);
        }

        public void UpdatePosition()
        {
            Control.Top += (int)(Speed * 2);
            if (Control.Bottom > Main.ClientSize.Height)
            {
                ResetPosition();
            }
        }

        private void ResetPosition()
        {
            Control.Left = new Random().Next(Main.ClientSize.Width);
            Control.Top = 0;
        }
    }
}

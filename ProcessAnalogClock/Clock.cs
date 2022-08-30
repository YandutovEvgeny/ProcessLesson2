using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessAnalogClock
{
    class Clock : PictureBox
    {
        Graphics gr;
        float x, y;

        public Clock()
        {
            Height = 200;
            Width = 200;
            gr = CreateGraphics();
        }

        private void GenerateCoord(float xb, float yb, float angle, int len)
        {
            angle -= 90;
            angle = angle * (float)(Math.PI / 180f);
            x = (float)Math.Cos(angle) * len + xb;
            y = (float)Math.Sin(angle) * len + yb;
        }
        public void DrawClock()
        {
            DateTime now = DateTime.Now;
            gr.Clear(Color.White);

            GenerateCoord(Width / 2, Height / 2, now.Second * 6, 80);
            gr.DrawLine(new Pen(Color.Blue, 3), Width / 2, Height / 2, x, y);

            GenerateCoord(Width / 2, Height / 2, now.Minute * 6, 60);
            gr.DrawLine(new Pen(Color.Blue, 4), Width / 2, Height / 2, x, y);

            GenerateCoord(Width / 2, Height / 2, now.Hour * 30 + now.Minute * 0.5f, 40);
            gr.DrawLine(new Pen(Color.Red, 5), Width / 2, Height / 2, x, y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessThread
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

        public void GenerateCoord(float xb, float yb, float angle, int len)
        {
            angle = angle * (float)(Math.PI / 180f);
            x = (float)Math.Cos(180 - angle) * len + xb;
            y = (float)Math.Sin(180 - angle) * len + yb;
        }
        public void DrawClock()
        {
            DateTime now = DateTime.Now;
            gr.Clear(Color.White);

            GenerateCoord(Width / 2, Height / 2, now.Second * 6, 100);
            gr.DrawLine(new Pen(Color.Blue), Width / 2, Height / 2, x, y);
        }
    }
}

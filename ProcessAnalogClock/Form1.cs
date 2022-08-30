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

namespace ProcessAnalogClock
{
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(UpdateClock);
            thread.Start();
        }

        public void UpdateClock()
        {
            while(true)
            {
                clock1.Invoke(new Action(() => clock1.DrawClock()));
                Thread.Sleep(1000);
            }
        }
    }
}

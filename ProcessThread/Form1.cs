using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProcessThread
{
    public partial class Form1 : Form
    {
        Thread thread;
        Thread thread2;

        public Form1()
        {
            InitializeComponent();
        }

        void SetProgessBar(Object progress)
        {
            Progress prog = progress as Progress;
            for (int i = 0; i < 100; i++)
            {
                i++;
                progressBar1.Invoke(new Action(() => prog.ProgressBar.Value = i));
                Thread.Sleep(prog.SleepTime);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Progress progress = new Progress();
            progress.ProgressBar = progressBar1;
            progress.SleepTime = 50;

            Progress progress2 = new Progress();
            progress2.ProgressBar = progressBar2;
            progress2.SleepTime = 50;

            if(thread == null || !thread.IsAlive)
            {
                thread = new Thread(new ParameterizedThreadStart(SetProgessBar));
                thread2 = new Thread(new ParameterizedThreadStart(SetProgessBar));
                thread.Start(progress);
                thread.Join();  //Блокирует поток, не работает с UI элементами
                thread2.Start(progress2);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort(); 
            }
            if(thread2 != null)
            {
                thread2.Abort();
            }
        }

        int x = 0;
        void JoinThread()
        {
            while(x<200)
            {
                x++;
                Thread.Sleep(10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread test = new Thread(JoinThread);
            test.Start();
            test.Join();
            MessageBox.Show(x.ToString());
        }
    }
}

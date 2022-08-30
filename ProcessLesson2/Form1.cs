using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessLesson2
{
    public partial class Form1 : Form
    {

        const uint SETTEXT = 0x0C;
        List<Process> Processes = new List<Process>();

        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage
            (IntPtr hWnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.LPStr)]string lParam);
       
        void RunProcess(string Name)
        {
            Process process = Process.Start(Name);
            Processes.Add(process);
            process.EnableRaisingEvents = true;
        }

        int GetParentId(int processId)
        {
            int parentId = 0;
            ManagementObject obj = new ManagementObject
                ("win32_process.handle=" + processId.ToString());
            obj.Get();
            parentId = Convert.ToInt32(obj["ParentProcessId"]);
            obj.Dispose();
            return parentId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunProcess("notepad.exe");
            MessageBox.Show(Process.GetCurrentProcess().Id.ToString() + " " + GetParentId(Processes[0].Id).ToString());
            SetWindowText(Processes[0].MainWindowHandle, "TEST");
        }

        void SetWindowText(IntPtr handle, string text)
        {
            SendMessage(handle, (int)SETTEXT, 0, text);
        }
    }
}

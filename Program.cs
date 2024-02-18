using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CS_Lab1
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            Application.Run(form);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MFEditorUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "ThisShouldOnlyRunOnce");
            bool Running = !mutex.WaitOne(0, false);
            if (!Running)
            {
                //Application.Run(new formMain());

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
                MessageBox.Show("程序已启动！"); 


            
        }
    }
}
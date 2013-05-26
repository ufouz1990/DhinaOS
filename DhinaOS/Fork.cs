using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace DhinaOS
{
    class Fork
    {
        public string s = "";
        public static int fork()
        {
            int pid = Process.GetCurrentProcess().Id;
            int val = 0;

            try
            {
                Console.WriteLine("Pid {0}", pid);

                string fileName = Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", "");

                ProcessStartInfo info = new ProcessStartInfo(fileName);

                info.UseShellExecute = false;

                Process processChild = Process.Start(info);

                val = 1;
            }
            catch
            {
                val = 0;
            }

            return val;

        }
        public void forker()
        {
            
            int pid;
            s += "\n\n Fork Function Testing";
            s += "\n\n My Process ID=" + Process.GetCurrentProcess().Id;
            s += "\n\n My Parent's ID=" + Process.GetCurrentProcess().Id;
            pid = fork();
            if (pid == -1)
            {
                s+= "\n\n Error occurred... \n Process cannot be created ";
                return;
            }
            if (pid != 0)
            {
                s += "\n\n Parent : My ID=" + Process.GetCurrentProcess().Id;
                s += "\n\n My Parent ID=" + Process.GetCurrentProcess().Id;
                return;
            }
            else
            {
                s += "\n\nChild : My ID=" + Process.GetCurrentProcess().Id;
                s += "\n\n My Parents's ID=" + Process.GetCurrentProcess().Id;
                return;
            }
        }
    }
}

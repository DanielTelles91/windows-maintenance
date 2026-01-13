using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manutenção_Windows
{
    internal static class Program
    {
        static void Main()
        {
            try
            {
                AdminLauncher();
                //only admins can run this wizard
                if (IsAdmin())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
            catch (Exception ex)
            {
                // handle how do you want to react here..
            }
        }
        private static void AdminLauncher()
        {
            if (!IsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Application.ExecutablePath;
                proc.Verb = "runas";
                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    // If dont want to lauch application as admin or do not have permissions
                    return;
                }
                Environment.Exit(0); // Quit itself
            }
        }
        // check if application is lauched with admin permissions.
        private static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);


        }










    }





}

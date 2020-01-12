using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace AntiProcrastinate
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NotifyIcon Noti = new NotifyIcon();
            Noti.ContextMenuStrip = GetMenu();
            string Dir = Directory.GetCurrentDirectory();
            //Noti.Icon = new Icon($@"{Dir}\Imagenes\Logo.ico");
            Noti.Icon = new Icon(@"C:\Users\Aimara\source\repos\AntiProcrastinate\AntiProcrastinate\Imagenes\Logo.ico");
            Noti.Visible = true;
            Application.Run();

            
        }

        private static ContextMenuStrip GetMenu()
        {
            ContextMenuStrip CMS = new ContextMenuStrip();
            CMS.Items.Add("Admin", null, new EventHandler(AdminLoad_Click));
            CMS.Items.Add("User", null, new EventHandler(UserLoad_Click));
            return CMS;

        }

        private static void AdminLoad_Click(object sender, EventArgs e)
        {
            AdminForm AdminFRM = new AdminForm();
            AdminFRM.Show();

        }
        private static void UserLoad_Click(object sender, EventArgs e)
        {
            UserForm FrmUser = new UserForm();
            FrmUser.Show();
            
        }
    }
}

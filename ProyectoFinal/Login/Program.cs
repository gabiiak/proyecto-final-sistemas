using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Login
{
    internal static class Program
    {
        /// Punto de entrada principal para la aplicación.
        /// </summary>|
        [STAThread]
        static void Main()
        {
            System.Globalization.CultureInfo culturaAR = new System.Globalization.CultureInfo("es-AR");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culturaAR;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culturaAR;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login()); //Login()
            //var menu = new UIMenu2(); //solo para debug
            //Application.Run(menu);
            bool seguirCorriendo = true;
            while (seguirCorriendo)
            {
                using (var login = new Login())
                {
                    //var menu = new UIMenu2();
                   if (login.ShowDialog() == DialogResult.OK)
                   {
                        var menu = new UIMenu2();
                        menu.SetUsuario(login.usuarioLogueado);
                        Application.Run(menu); //Login()
                   }
                    else seguirCorriendo = false;
               }
            }
        }
    }
}

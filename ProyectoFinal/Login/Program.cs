using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Login
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //para gabi del futuro: agregar un boton para acceder a los transportes
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
                   if (login.ShowDialog() == DialogResult.OK)
                   {
                        var menu = new UIMenu2();
                        menu.SetUsuario(login.usuarioLogueado);
                        Application.Run(menu); 
                   }
                    else seguirCorriendo = false;
               }
            }
        }
    }
}
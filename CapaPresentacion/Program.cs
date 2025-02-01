using CapaPresentacion.CRUD;
using CapaPresentacion.MenuOpciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar la pantalla de bienvenida
            using (var splash = new FormInicio())
            {
                splash.ShowDialog(); // Mostrar el Splash Screen
            }

            Application.Run(new FormObjetivoEuraceCrud());
        }
    }
}

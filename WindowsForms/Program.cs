using System;
using System.Windows.Forms;

namespace WindowsForms
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

            // Crear una instancia del formulario de inicio de sesión.
            InicioSesion formularioInicio = new InicioSesion();

            Application.Run(formularioInicio);

            // Si el formulario de inicio de sesión se cierra, abrir el formulario de facturación.
            if (formularioInicio.DialogResult == DialogResult.OK)
            {
                Application.Run(new Facturacion());
            }
        }
    }
}

using ManteHos.Persistence;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManteHosGUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                IManteHosService service = new ManteHosService(new EntityFrameworkDAL(new ManteHosDbContext()));
                // Inicializar DB si es necesario para pruebas
                service.DBInitialization(); 
                try
                {
                    service.Login("e1", "e1"); // Intento de login con usuario de prueba
                }
                catch { /* Ignorar si falla, el formulario manejará el estado no logueado */ }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new HospitalApp(service));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"FATAL ERROR en Program.cs: {ex.Message}\n{ex.InnerException?.Message}\n{ex.StackTrace}");
            }
        }
    }
}

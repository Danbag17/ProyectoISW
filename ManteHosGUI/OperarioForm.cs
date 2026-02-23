using ManteHos.Services;
using ManteHos.Entities;
using System;
using System.Windows.Forms;

namespace ManteHosGUI
{
    // Hereda de EmpleadoForm, como el JefeForm
    public partial class OperarioForm : EmpleadoForm
    {
       public OperarioForm()
        {
            InitializeComponent();
        }
        public OperarioForm(IManteHosService s) : base(s)
        {
            InitializeComponent();
           

            // Asumimos que el usuario ya está logueado y es un Operario
            this.usuario = s.UserLogged();
            this.Text = "Menú de Operario";
        }

        private void OperarioForm_Load(object sender, EventArgs e)
        {
        

        lblRol.Text = "Rol : Operario";

            lblSaludo.Text = "Hola " + usuario.FullName;
        }


        private void btnCerrarOrden_Click(object sender, EventArgs e)
        {

            var frm = new CerrarOrdenTrabajo(service);
            frm.ShowDialog();
        }

        // Manejador del botón Cerrar Sesión
        private void btnLogout_Click(object sender, EventArgs e)
        {
            service.Logout();
            this.Close();

        }
    }
}
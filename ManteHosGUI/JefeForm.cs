using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class JefeForm : EmpleadoForm
    {
        
        public JefeForm()
        {
            InitializeComponent();
        }
        
        public JefeForm(IManteHosService s) : base(s)
        {
            InitializeComponent();
        }
        private void JefeForm_Load(object sender, EventArgs e)
        {
            lblRol.Text = "Rol : Jefe";
            lblSaludo.Text = "Hola " + usuario.FullName;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            service.Logout();
            this.Close();
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            RevisarIncidencia ventana = new RevisarIncidencia(service);
            ventana.ShowDialog();
        }


       
    }
}

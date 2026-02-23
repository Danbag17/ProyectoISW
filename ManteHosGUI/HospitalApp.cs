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
    public partial class HospitalApp : ManteHosFormBase
    {
        public HospitalApp()
        {
            InitializeComponent();
        }

        public HospitalApp(IManteHosService s) : base(s)
        {
            InitializeComponent();
        }

        private void HospitalApp_Load(object sender, EventArgs e)
        {
            // Crear el menú de Incidencias
            ToolStripMenuItem incidenciasMenu = new ToolStripMenuItem("Incidencias");
            ToolStripMenuItem añadirIncidenciaItem = new ToolStripMenuItem("Añadir Incidencia");
            
            // Conectar el evento click
            añadirIncidenciaItem.Click += (s, args) => 
            {
                AñadirIncidencia form = new AñadirIncidencia(this.service);
                form.ShowDialog();
            };

            // Añadir el item al menú y el menú al MenuStrip
            incidenciasMenu.DropDownItems.Add(añadirIncidenciaItem);
            this.menuStrip1.Items.Add(incidenciasMenu);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btInicioSesion_Click(object sender, EventArgs e)
        {
            try { 
            //El formulario llama al servicio para que intente loguear al usuario
            this.service.Login(txtUsuario.Text, txtContraseña.Text);
          
                
                Employee usuario = this.service.UserLogged();

                //Vemos quien se logea y dependiendo de su rango tendran unas funciones u otras
                // Variable para guardar la ventana que vamos a abrir
                Form ventanaApertura = null;

                // Lista de roles

                if (usuario is Head) // ¿Es Jefe?
                {
                    ventanaApertura = new JefeForm(this.service);
                }
                else if (usuario is Master) // ¿Es Maestro?
                {
                    ventanaApertura = new MaestroForm(this.service);
                }
                else if (usuario is Operator) // ¿Es Operario?
                {
                    ventanaApertura = new OperarioForm(this.service);
                }
                else if (usuario is Employee) // ¿Es un empleado?
                {
                    
                    ventanaApertura = new EmpleadoForm(this.service);
                }

                //Abrir ventana
                if (ventanaApertura != null)
                {
                    this.Hide(); // Ocultamos el Login

                    MessageBox.Show("Bienvenido " + usuario.FullName);

                    
                    ventanaApertura.ShowDialog();

                    // Al cerrarse la otra ventana, el código sigue por aquí:
                    this.service.Logout(); // Hacemos Logout
                    this.Show(); // Volvemos a mostrar el Login
                    txtContraseña.Text = ""; // Limpiamos la contraseña
                    txtUsuario.Text = ""; //Limpiamos el usuario
                }
            }
            catch (Exception ex) {
            MessageBox.Show(ex.Message); // Si el servicio no funciona, mostramos el error
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}

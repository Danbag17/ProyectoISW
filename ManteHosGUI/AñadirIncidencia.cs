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
    public partial class AñadirIncidencia : ManteHosFormBase
    {
        public AñadirIncidencia()
        {
            InitializeComponent();
        }
        public AñadirIncidencia(IManteHosService s) : base(s)
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al iniciar AñadirIncidencia: {ex.Message}\nStack: {ex.StackTrace}", "Error de Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtDepartamento.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Por favor, rellena todos los campos y selecciona una prioridad.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string departamento = txtDepartamento.Text;
                string descripcion = txtDescripcion.Text;
                DateTime fecha = dateFecha.Value;

                Employee reportero = service.UserLogged();

                if (reportero == null)
                {
                    MessageBox.Show("No hay usuario logueado. Debe iniciar sesión.", "Error de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                Incident incidente = new Incident(departamento, descripcion, fecha, reportero);

                service.AddIncident(incidente);

                MessageBox.Show("Incidencia registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la incidencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AñadirIncidencia_Load(object sender, EventArgs e)
        {

        }
    }
}

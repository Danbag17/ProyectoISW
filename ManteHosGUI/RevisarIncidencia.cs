using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManteHos.Services;
using ManteHos.Entities;
using System.Drawing.Text;
using System.Runtime.Remoting;
using ManteHos.Persistence;

namespace ManteHosGUI
{
    public partial class RevisarIncidencia : ManteHosFormBase
    {
        
        private Incident incident;
        public RevisarIncidencia()
        {
            InitializeComponent();
        }
        public RevisarIncidencia(IManteHosService s): base(s)
        {
            InitializeComponent();
            
        }

        private void RevisarIncidencia_Load(object sender, EventArgs e)
        {
            CargarIncidenciasPendientes();
            CargarAreas();
            CargarPrioridades();
            ConfigurarDecision(); 
            ActualizarInterfaz();
        }

        private void CargarIncidenciasPendientes()
        {
            var incidencias = service.GetIncidentsPendingReview().ToList();
            dgvIncidencias.DataSource = incidencias;  
        }

        private void dgvIncidencias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIncidencias.SelectedRows.Count == 0)
            {
                return;
            }
            
             incident = dgvIncidencias.SelectedRows[0].DataBoundItem as Incident;

            if(incident != null)
            {
                CargarDatosIncidencia(incident);
            }
        }
        
        private void CargarDatosIncidencia(Incident incident)
        {
            txtDescripcion.Text = incident.Description;

            lblFecha.Text = incident.ReportDate.ToString();
            string nombre = "(desconocido)";
            if (incident.Reporter != null)
                nombre = incident.Reporter.FullName;
            lblReportado.Text = nombre;
            lblDept.Text = incident.Department;
           
            
        }
        private void CargarAreas()
        {
            var listaAreas = service.GetAreas();
            cbArea.DataSource= listaAreas;
            cbArea.DisplayMember= "Name";
            cbArea.ValueMember = "Id";
        }
        private void CargarPrioridades()
        {
            cbPrioridad.DataSource = Enum.GetValues(typeof(Priority));
        }

        private void ConfigurarDecision()
        {
            rbAceptar.CheckedChanged += (s, e) => ActualizarInterfaz();
            rbRechazar.CheckedChanged += (s, e) => ActualizarInterfaz();
        }

        private void ActualizarInterfaz()
        {
            if (rbAceptar.Checked)  
            {
                cbArea.Enabled = true;          // Activar selección de área
                cbPrioridad.Enabled = true;     // Activar selección de prioridad

                txtMotivoRechazo.Enabled = false;      // No permitir escribir motivo de rechazo
                txtMotivoRechazo.Clear();              // Limpiar cualquier texto previo
            }
            else  
            {
                cbArea.Enabled = false;        
                cbPrioridad.Enabled = false;    

                txtMotivoRechazo.Enabled = true;       
            }
        }

        private void limpiarPantalla()
        {
            txtDescripcion.Clear();
            lblFecha.Text = "";
            lblReportado.Text = "";
            lblDept.Text = "";
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            service.Logout();
            this.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (incident == null)
            {
                MessageBox.Show("Debe seleccionar una incidencia.");
                return;
            }

            try
            {
                bool aceptar = rbAceptar.Checked;

                Area area = null;
                Priority prioridad = incident.Priority;
                string motivo = null;

                if (aceptar)
                {
                    area = cbArea.SelectedItem as Area;

                    if (area == null)
                    {
                        MessageBox.Show("Debe seleccionar un área.");
                        return;
                    }

                    prioridad = (Priority)cbPrioridad.SelectedItem;
                }
                else
                {
                    motivo = txtMotivoRechazo.Text.Trim();

                    if (string.IsNullOrWhiteSpace(motivo))
                    {
                        MessageBox.Show("Debe indicar el motivo del rechazo.");
                        return;
                    }
                }

                service.ReviewIncident(incident, aceptar, motivo, area, prioridad);

                MessageBox.Show("Incidencia revisada correctamente");
                CargarIncidenciasPendientes();
                incident = null;
                limpiarPantalla();

                this.Close();
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            dgvIncidencias.ClearSelection();

            incident = null;

            limpiarPantalla();

            rbAceptar.Checked = false;
            rbRechazar.Checked = false;

            ActualizarInterfaz();
        }
    }
}

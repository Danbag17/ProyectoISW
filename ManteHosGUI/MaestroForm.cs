using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class MaestroForm : EmpleadoForm 
    {
        public MaestroForm(){
            
            InitializeComponent();
        }

        public MaestroForm(IManteHosService service) : base(service){
            
            InitializeComponent();
        }


        private void CargarIncidencias()
        {
     
            Master maestro = service.UserLogged() as Master;

            if (maestro != null)
            {

                var listaIncidencias = service.GetIncidentsForMaster(maestro.Id);


                dgvIncidencias.DataSource = null; // Limpiar primero
                dgvIncidencias.DataSource = listaIncidencias;


                if (dgvIncidencias.Columns["WorkOrder"] != null)
                    dgvIncidencias.Columns["WorkOrder"].Visible = false;

                if (dgvIncidencias.Columns["Area"] != null)
                    dgvIncidencias.Columns["Area"].Visible = false;
            }
        }

  
        private void MaestroForm_Load(object sender, EventArgs e)
        {
            CargarIncidencias();
        }

        



        private void button1_Click(object sender, EventArgs e)
        {
           
            if (dgvIncidencias.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una incidencia primero.");
                return;
            }

            Incident incidenciaSeleccionada = (Incident)dgvIncidencias.CurrentRow.DataBoundItem;

            
            WorkOrder ordenExistente = service.GetWorkOrderByIncident(incidenciaSeleccionada);

            if (ordenExistente == null)
            {
                DialogResult respuesta = MessageBox.Show(
                    "No hay orden de trabajo asociada a esta incidencia.\n¿Desea crear una nueva?",
                    "Crear Orden de Trabajo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                   
                    return;
                }
              
            }
            
            if (incidenciaSeleccionada.Status == Status.Completed)
            {
                MessageBox.Show("Esta incidencia ya está cerrada.");
                return;
            }

            AsignarOrdenDeTrabajo ventanaHija = new AsignarOrdenDeTrabajo(this.service, incidenciaSeleccionada);

            ventanaHija.ShowDialog();

            CargarIncidencias();
        
        }

        private void dgvIncidencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

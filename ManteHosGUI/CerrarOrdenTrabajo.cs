using ManteHos.Services;
using ManteHos.Entities;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ManteHosGUI
{
    public partial class CerrarOrdenTrabajo : ManteHosFormBase
    {
        private readonly Operator loggedOp;
        private WorkOrder selectedOrder;
        public CerrarOrdenTrabajo()
        {
            InitializeComponent();
        }

        public CerrarOrdenTrabajo(IManteHosService s) : base(s)
        {
            InitializeComponent();

            this.loggedOp = service.UserLogged() as Operator;

            this.Text = "Cerrar Orden de Trabajo";
            dtpFechaCierre.Value = DateTime.Now; 

            ClearOrderDetails();
        }

        private void CerrarOrdenTrabajo_Load(object sender, EventArgs e)
        {
            LoadWorkOrders();
        }

        private void LoadWorkOrders()
        {
            try
            {
                List<WorkOrder> orders = service.GetOpenWorkOrdersForOperator(loggedOp);

                dfvOrdenes.DataSource = orders
                    .Select(wo => new {
                        wo.Id,
                        Incidencia = wo.Incident.Description,
                        Fecha_Inicio = wo.StartDate.ToString("d")
                    }).ToList();

                if (!orders.Any())
                {
                    MessageBox.Show("No tienes órdenes de trabajo pendientes de cerrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar órdenes: " + ex.Message);
            }
        }

        private void dfvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dfvOrdenes.CurrentRow == null) return;

            int id = Convert.ToInt32(dfvOrdenes.CurrentRow.Cells[0].Value);

            try
            {
             
                selectedOrder = service.GetWorkOrderById(id);

                if (selectedOrder != null)
                {
                    DisplayOrderDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información: " + ex.Message);
            }
        }


        private void DisplayOrderDetails()
        {
            txtDescripcion.Text = selectedOrder.Incident.Description;
            lblFechaInicio.Text = selectedOrder.StartDate.ToString("g");


            var piezasInfo = selectedOrder.UsedParts.Select(up => new
            {
                Pieza = up.Part.Description,
                Cantidad = up.Quantity,
                Precio_Unid = up.Part.UnitPrice,
                Subtotal = up.Quantity * up.Part.UnitPrice
            }).ToList();

            dgvPiezasUsadas.DataSource = piezasInfo;


            double totalCost = piezasInfo.Sum(p => p.Subtotal);
            lblCoste.Text = totalCost.ToString("C2");
        }

        private void btnCerrarOrden_Click(object sender, EventArgs e)
        {
            
            if (dfvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una orden.");
                return;
            }

            try
            {
                
                int idOrden = Convert.ToInt32(dfvOrdenes.CurrentRow.Cells[0].Value);

               
                WorkOrder ordenReal = service.GetWorkOrderById(idOrden);

                if (ordenReal == null)
                {
                    MessageBox.Show("No se encontró la orden en la BD.");
                    return;
                }

                
                string informe = txtInforme.Text; 
                DateTime fechaFin = dtpFechaCierre.Value; 


                service.CloseWorkOrder(ordenReal, informe, fechaFin);

                MessageBox.Show("¡Orden cerrada con éxito!");
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar: " + ex.Message);
            }
        }

        private void ClearOrderDetails()
        {
            txtDescripcion.Clear();
            lblFechaInicio.Text = "-";
            lblCoste.Text = "0,00 €";
            dgvPiezasUsadas.DataSource = null;
            txtInforme.Clear();
            selectedOrder = null;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       //Evitar errores compilacion
        private void txtInforme_TextChanged(object sender, EventArgs e) { }
        private void dtpFechaCierre_ValueChanged(object sender, EventArgs e) { }
    }
}
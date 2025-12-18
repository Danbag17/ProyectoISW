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

            // Paso 1: El sistema ya sabe quién es el operario por el Login previo
            this.loggedOp = service.UserLogged() as Operator;

            // Configuración inicial de UI
            this.Text = "Cerrar Orden de Trabajo";
            dtpFechaCierre.Value = DateTime.Now; // Paso 5: Fecha actual por defecto

            ClearOrderDetails();
        }

        private void CerrarOrdenTrabajo_Load(object sender, EventArgs e)
        {
            LoadWorkOrders();
        }

        // PASO 2: El sistema busca las ordenes de trabajo asignadas al operario no cerradas
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

        // PASO 3: El operario escoge una orden de trabajo (al hacer clic en la fila)
        private void dfvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dfvOrdenes.CurrentRow == null) return;

            // Obtenemos el ID de la columna 0
            int id = Convert.ToInt32(dfvOrdenes.CurrentRow.Cells[0].Value);

            try
            {
                // PASO 4: Recuperamos la orden REAL con todas sus relaciones desde el servicio
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

        // PASO 4: Mostrar información, piezas y coste total
        private void DisplayOrderDetails()
        {
            // Información básica
            txtDescripcion.Text = selectedOrder.Incident.Description;
            lblFechaInicio.Text = selectedOrder.StartDate.ToString("g");

            // Información de piezas utilizadas
            var piezasInfo = selectedOrder.UsedParts.Select(up => new
            {
                Pieza = up.Part.Description,
                Cantidad = up.Quantity,
                Precio_Unid = up.Part.UnitPrice,
                Subtotal = up.Quantity * up.Part.UnitPrice
            }).ToList();

            dgvPiezasUsadas.DataSource = piezasInfo;

            // Cálculo del coste total (Obligación del sistema 4)
            double totalCost = piezasInfo.Sum(p => p.Subtotal);
            lblCoste.Text = totalCost.ToString("C2");
        }

        // PASO 6: El sistema cierra la orden (al pulsar el botón)
        private void btnCerrarOrden_Click(object sender, EventArgs e)
        {
            // 1. Validar que hay fila seleccionada
            if (dfvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una orden.");
                return;
            }

            try
            {
                // 2. EL TRUCO: Cogemos solo el ID de la primera celda (Columna 0)
                // Esto NO falla aunque uses tipos anónimos
                int idOrden = Convert.ToInt32(dfvOrdenes.CurrentRow.Cells[0].Value);

                // 3. Recuperamos la orden REAL usando el servicio (Paso 1)
                WorkOrder ordenReal = service.GetWorkOrderById(idOrden);

                if (ordenReal == null)
                {
                    MessageBox.Show("No se encontró la orden en la BD.");
                    return;
                }

                // 4. Recogemos los datos del formulario
                string informe = txtInforme.Text; // Asegúrate de que tu TextBox se llama así
                DateTime fechaFin = dtpFechaCierre.Value; // Asegúrate de que tu DateTimePicker se llama así

                // 5. ¡CERRAMOS!
                service.CloseWorkOrder(ordenReal, informe, fechaFin);

                MessageBox.Show("¡Orden cerrada con éxito!");
                this.Close();
                // 6. Recargar la tabla para que desaparezca
                // ActualizarGrid(); // O el método que uses para refrescar
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

        // Métodos vacíos requeridos por el Designer para evitar errores de compilación
        private void txtInforme_TextChanged(object sender, EventArgs e) { }
        private void dtpFechaCierre_ValueChanged(object sender, EventArgs e) { }
    }
}
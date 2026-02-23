namespace ManteHosGUI
{
    partial class CerrarOrdenTrabajo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dfvOrdenes = new System.Windows.Forms.DataGridView();
            this.panelOrdenes = new System.Windows.Forms.Panel();
            this.lblOrdenes = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnAtras = new System.Windows.Forms.Button();
            this.panelInfoOrden = new System.Windows.Forms.Panel();
            this.lblInfoOrdenTitulo = new System.Windows.Forms.Label();
            this.lblCoste = new System.Windows.Forms.Label();
            this.lblCosteTitulo = new System.Windows.Forms.Label();
            this.dgvPiezasUsadas = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPiezasTitulo = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.panelInforme = new System.Windows.Forms.Panel();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCierre = new System.Windows.Forms.Label();
            this.txtInforme = new System.Windows.Forms.TextBox();
            this.lblInformeTexto = new System.Windows.Forms.Label();
            this.lblInformeTitulo = new System.Windows.Forms.Label();
            this.btnCerrarOrden = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dfvOrdenes)).BeginInit();
            this.panelOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelInfoOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiezasUsadas)).BeginInit();
            this.panelInforme.SuspendLayout();
            this.SuspendLayout();
            // 
            // dfvOrdenes
            // 
            this.dfvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dfvOrdenes.Location = new System.Drawing.Point(13, 60);
            this.dfvOrdenes.MultiSelect = false;
            this.dfvOrdenes.Name = "dfvOrdenes";
            this.dfvOrdenes.ReadOnly = true;
            this.dfvOrdenes.RowHeadersWidth = 51;
            this.dfvOrdenes.RowTemplate.Height = 24;
            this.dfvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dfvOrdenes.Size = new System.Drawing.Size(441, 286);
            this.dfvOrdenes.TabIndex = 0;
            this.dfvOrdenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dfvOrdenes_CellContentClick);
            // 
            // panelOrdenes
            // 
            this.panelOrdenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrdenes.Controls.Add(this.lblOrdenes);
            this.panelOrdenes.Controls.Add(this.dfvOrdenes);
            this.panelOrdenes.Location = new System.Drawing.Point(23, 28);
            this.panelOrdenes.Name = "panelOrdenes";
            this.panelOrdenes.Size = new System.Drawing.Size(471, 367);
            this.panelOrdenes.TabIndex = 1;
            // 
            // lblOrdenes
            // 
            this.lblOrdenes.AutoSize = true;
            this.lblOrdenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenes.Location = new System.Drawing.Point(9, 15);
            this.lblOrdenes.Name = "lblOrdenes";
            this.lblOrdenes.Size = new System.Drawing.Size(190, 22);
            this.lblOrdenes.TabIndex = 1;
            this.lblOrdenes.Text = "Órdenes pendientes";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(23, 401);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(95, 37);
            this.btnAtras.TabIndex = 3;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // panelInfoOrden
            // 
            this.panelInfoOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfoOrden.Controls.Add(this.lblInfoOrdenTitulo);
            this.panelInfoOrden.Controls.Add(this.lblCoste);
            this.panelInfoOrden.Controls.Add(this.lblCosteTitulo);
            this.panelInfoOrden.Controls.Add(this.dgvPiezasUsadas);
            this.panelInfoOrden.Controls.Add(this.txtDescripcion);
            this.panelInfoOrden.Controls.Add(this.lblPiezasTitulo);
            this.panelInfoOrden.Controls.Add(this.lblFechaInicio);
            this.panelInfoOrden.Controls.Add(this.lblFechaTitulo);
            this.panelInfoOrden.Controls.Add(this.lblDescripcion);
            this.panelInfoOrden.Location = new System.Drawing.Point(522, 28);
            this.panelInfoOrden.Name = "panelInfoOrden";
            this.panelInfoOrden.Size = new System.Drawing.Size(494, 367);
            this.panelInfoOrden.TabIndex = 4;
            // 
            // lblInfoOrdenTitulo
            // 
            this.lblInfoOrdenTitulo.AutoSize = true;
            this.lblInfoOrdenTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoOrdenTitulo.Location = new System.Drawing.Point(17, 14);
            this.lblInfoOrdenTitulo.Name = "lblInfoOrdenTitulo";
            this.lblInfoOrdenTitulo.Size = new System.Drawing.Size(170, 22);
            this.lblInfoOrdenTitulo.TabIndex = 8;
            this.lblInfoOrdenTitulo.Text = "Información orden";
            // 
            // lblCoste
            // 
            this.lblCoste.AutoSize = true;
            this.lblCoste.Location = new System.Drawing.Point(113, 340);
            this.lblCoste.Name = "lblCoste";
            this.lblCoste.Size = new System.Drawing.Size(0, 16);
            this.lblCoste.TabIndex = 7;
            // 
            // lblCosteTitulo
            // 
            this.lblCosteTitulo.AutoSize = true;
            this.lblCosteTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosteTitulo.Location = new System.Drawing.Point(21, 341);
            this.lblCosteTitulo.Name = "lblCosteTitulo";
            this.lblCosteTitulo.Size = new System.Drawing.Size(85, 16);
            this.lblCosteTitulo.TabIndex = 6;
            this.lblCosteTitulo.Text = "Coste total:";
            // 
            // dgvPiezasUsadas
            // 
            this.dgvPiezasUsadas.AllowUserToAddRows = false;
            this.dgvPiezasUsadas.AllowUserToDeleteRows = false;
            this.dgvPiezasUsadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPiezasUsadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPiezasUsadas.Location = new System.Drawing.Point(21, 246);
            this.dgvPiezasUsadas.Name = "dgvPiezasUsadas";
            this.dgvPiezasUsadas.ReadOnly = true;
            this.dgvPiezasUsadas.RowHeadersWidth = 51;
            this.dgvPiezasUsadas.RowTemplate.Height = 24;
            this.dgvPiezasUsadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPiezasUsadas.Size = new System.Drawing.Size(455, 61);
            this.dgvPiezasUsadas.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(18, 88);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(458, 71);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lblPiezasTitulo
            // 
            this.lblPiezasTitulo.AutoSize = true;
            this.lblPiezasTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPiezasTitulo.Location = new System.Drawing.Point(18, 217);
            this.lblPiezasTitulo.Name = "lblPiezasTitulo";
            this.lblPiezasTitulo.Size = new System.Drawing.Size(128, 16);
            this.lblPiezasTitulo.TabIndex = 3;
            this.lblPiezasTitulo.Text = "Piezas utilizadas:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(141, 201);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(0, 16);
            this.lblFechaInicio.TabIndex = 2;
            // 
            // lblFechaTitulo
            // 
            this.lblFechaTitulo.AutoSize = true;
            this.lblFechaTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaTitulo.Location = new System.Drawing.Point(18, 181);
            this.lblFechaTitulo.Name = "lblFechaTitulo";
            this.lblFechaTitulo.Size = new System.Drawing.Size(117, 16);
            this.lblFechaTitulo.TabIndex = 1;
            this.lblFechaTitulo.Text = "Fecha de inicio:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(15, 59);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(94, 16);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // panelInforme
            // 
            this.panelInforme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInforme.Controls.Add(this.dtpFechaCierre);
            this.panelInforme.Controls.Add(this.lblFechaCierre);
            this.panelInforme.Controls.Add(this.txtInforme);
            this.panelInforme.Controls.Add(this.lblInformeTexto);
            this.panelInforme.Controls.Add(this.lblInformeTitulo);
            this.panelInforme.Location = new System.Drawing.Point(1022, 28);
            this.panelInforme.Name = "panelInforme";
            this.panelInforme.Size = new System.Drawing.Size(261, 367);
            this.panelInforme.TabIndex = 5;
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCierre.Location = new System.Drawing.Point(19, 278);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(117, 22);
            this.dtpFechaCierre.TabIndex = 4;
            this.dtpFechaCierre.ValueChanged += new System.EventHandler(this.dtpFechaCierre_ValueChanged);
            // 
            // lblFechaCierre
            // 
            this.lblFechaCierre.AutoSize = true;
            this.lblFechaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCierre.Location = new System.Drawing.Point(19, 259);
            this.lblFechaCierre.Name = "lblFechaCierre";
            this.lblFechaCierre.Size = new System.Drawing.Size(120, 16);
            this.lblFechaCierre.TabIndex = 3;
            this.lblFechaCierre.Text = "Fecha de cierre:";
            // 
            // txtInforme
            // 
            this.txtInforme.Location = new System.Drawing.Point(19, 74);
            this.txtInforme.Multiline = true;
            this.txtInforme.Name = "txtInforme";
            this.txtInforme.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInforme.Size = new System.Drawing.Size(223, 170);
            this.txtInforme.TabIndex = 2;
            this.txtInforme.TextChanged += new System.EventHandler(this.txtInforme_TextChanged);
            // 
            // lblInformeTexto
            // 
            this.lblInformeTexto.AutoSize = true;
            this.lblInformeTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformeTexto.Location = new System.Drawing.Point(16, 55);
            this.lblInformeTexto.Name = "lblInformeTexto";
            this.lblInformeTexto.Size = new System.Drawing.Size(135, 16);
            this.lblInformeTexto.TabIndex = 1;
            this.lblInformeTexto.Text = "Trabajo realizado:";
            // 
            // lblInformeTitulo
            // 
            this.lblInformeTitulo.AutoSize = true;
            this.lblInformeTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformeTitulo.Location = new System.Drawing.Point(15, 16);
            this.lblInformeTitulo.Name = "lblInformeTitulo";
            this.lblInformeTitulo.Size = new System.Drawing.Size(76, 22);
            this.lblInformeTitulo.TabIndex = 0;
            this.lblInformeTitulo.Text = "Informe";
            // 
            // btnCerrarOrden
            // 
            this.btnCerrarOrden.Location = new System.Drawing.Point(1184, 401);
            this.btnCerrarOrden.Name = "btnCerrarOrden";
            this.btnCerrarOrden.Size = new System.Drawing.Size(99, 37);
            this.btnCerrarOrden.TabIndex = 6;
            this.btnCerrarOrden.Text = "Cerrar orden";
            this.btnCerrarOrden.UseVisualStyleBackColor = true;
            this.btnCerrarOrden.Click += new System.EventHandler(this.btnCerrarOrden_Click);
            // 
            // CerrarOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 466);
            this.Controls.Add(this.btnCerrarOrden);
            this.Controls.Add(this.panelInforme);
            this.Controls.Add(this.panelInfoOrden);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.panelOrdenes);
            this.Name = "CerrarOrdenTrabajo";
            this.Text = "CerrarOrdenTrabajo";
            this.Load += new System.EventHandler(this.CerrarOrdenTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dfvOrdenes)).EndInit();
            this.panelOrdenes.ResumeLayout(false);
            this.panelOrdenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panelInfoOrden.ResumeLayout(false);
            this.panelInfoOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiezasUsadas)).EndInit();
            this.panelInforme.ResumeLayout(false);
            this.panelInforme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dfvOrdenes;
        private System.Windows.Forms.Panel panelOrdenes;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label lblOrdenes;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Panel panelInfoOrden;
        private System.Windows.Forms.Label lblPiezasTitulo;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblCoste;
        private System.Windows.Forms.Label lblCosteTitulo;
        private System.Windows.Forms.DataGridView dgvPiezasUsadas;
        private System.Windows.Forms.Label lblInfoOrdenTitulo;
        private System.Windows.Forms.Panel panelInforme;
        private System.Windows.Forms.Label lblInformeTexto;
        private System.Windows.Forms.Label lblInformeTitulo;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.Label lblFechaCierre;
        private System.Windows.Forms.TextBox txtInforme;
        private System.Windows.Forms.Button btnCerrarOrden;
    }
}
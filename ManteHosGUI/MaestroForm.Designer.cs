namespace ManteHosGUI
{
    partial class MaestroForm
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
            this.BotonAsignarOrdenDetrabajo = new System.Windows.Forms.Button();
            this.dgvIncidencias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).BeginInit();
            this.SuspendLayout();
            // 
            // BotonAsignarOrdenDetrabajo
            // 
            this.BotonAsignarOrdenDetrabajo.Location = new System.Drawing.Point(241, 271);
            this.BotonAsignarOrdenDetrabajo.Name = "BotonAsignarOrdenDetrabajo";
            this.BotonAsignarOrdenDetrabajo.Size = new System.Drawing.Size(261, 43);
            this.BotonAsignarOrdenDetrabajo.TabIndex = 1;
            this.BotonAsignarOrdenDetrabajo.Text = "Asignar Orden de Trabajo";
            this.BotonAsignarOrdenDetrabajo.UseVisualStyleBackColor = true;
            this.BotonAsignarOrdenDetrabajo.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvIncidencias
            // 
            this.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidencias.Location = new System.Drawing.Point(85, 52);
            this.dgvIncidencias.Name = "dgvIncidencias";
            this.dgvIncidencias.RowHeadersWidth = 51;
            this.dgvIncidencias.RowTemplate.Height = 24;
            this.dgvIncidencias.Size = new System.Drawing.Size(624, 191);
            this.dgvIncidencias.TabIndex = 2;
            this.dgvIncidencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidencias_CellContentClick);
            // 
            // MaestroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvIncidencias);
            this.Controls.Add(this.BotonAsignarOrdenDetrabajo);
            this.Name = "MaestroForm";
            this.Text = "MaestroForm";
            this.Load += new System.EventHandler(this.MaestroForm_Load);
            this.Controls.SetChildIndex(this.BotonAsignarOrdenDetrabajo, 0);
            this.Controls.SetChildIndex(this.dgvIncidencias, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BotonAsignarOrdenDetrabajo;
        private System.Windows.Forms.DataGridView dgvIncidencias;
    }
}
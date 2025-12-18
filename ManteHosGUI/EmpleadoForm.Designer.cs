namespace ManteHosGUI
{
    partial class EmpleadoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpleadoForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ReportarIncidencia = new System.Windows.Forms.ToolStripButton();
            this.CerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportarIncidencia,
            this.CerrarSesion});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ReportarIncidencia
            // 
            this.ReportarIncidencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReportarIncidencia.Image = ((System.Drawing.Image)(resources.GetObject("ReportarIncidencia.Image")));
            this.ReportarIncidencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReportarIncidencia.Name = "ReportarIncidencia";
            this.ReportarIncidencia.Size = new System.Drawing.Size(142, 24);
            this.ReportarIncidencia.Text = "Reportar incidencia";
            this.ReportarIncidencia.Click += new System.EventHandler(this.ReportarIncidencia_Click);
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("CerrarSesion.Image")));
            this.CerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Size = new System.Drawing.Size(98, 24);
            this.CerrarSesion.Text = "Cerrar sesión";
            this.CerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CerrarSesion.Click += new System.EventHandler(this.CerrarSesion_Click);
            // 
            // EmpleadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EmpleadoForm";
            this.Text = "EmpleadoForm";
            this.Load += new System.EventHandler(this.EmpleadoForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CerrarSesion;
        private System.Windows.Forms.ToolStripButton ReportarIncidencia;
    }
}
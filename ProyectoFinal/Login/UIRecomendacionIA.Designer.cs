namespace Login
{
    partial class UIRecomendacionIA
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
            this.lblTituloRecomendacion = new System.Windows.Forms.Label();
            this.lblProveedorSugerido = new System.Windows.Forms.Label();
            this.lblDetalleRecomendacion = new System.Windows.Forms.Label();
            this.pnlGraficoRecomendacionIA = new System.Windows.Forms.Panel();
            this.dgvRecomendacionesIA = new System.Windows.Forms.DataGridView();
            this.lblAvisoIA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecomendacionesIA)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloRecomendacion
            // 
            this.lblTituloRecomendacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloRecomendacion.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRecomendacion.Location = new System.Drawing.Point(30, 30);
            this.lblTituloRecomendacion.Name = "lblTituloRecomendacion";
            this.lblTituloRecomendacion.Size = new System.Drawing.Size(1000, 35);
            this.lblTituloRecomendacion.TabIndex = 0;
            this.lblTituloRecomendacion.Text = "Recomendación Inteligente de Proveedores";
            // 
            // lblProveedorSugerido
            // 
            this.lblProveedorSugerido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProveedorSugerido.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedorSugerido.Location = new System.Drawing.Point(30, 110);
            this.lblProveedorSugerido.Name = "lblProveedorSugerido";
            this.lblProveedorSugerido.Size = new System.Drawing.Size(1000, 35);
            this.lblProveedorSugerido.TabIndex = 1;
            this.lblProveedorSugerido.Text = "Proveedor sugerido: Pendiente";
            // 
            // lblDetalleRecomendacion
            // 
            this.lblDetalleRecomendacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetalleRecomendacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleRecomendacion.Location = new System.Drawing.Point(30, 155);
            this.lblDetalleRecomendacion.Name = "lblDetalleRecomendacion";
            this.lblDetalleRecomendacion.Size = new System.Drawing.Size(1000, 45);
            this.lblDetalleRecomendacion.TabIndex = 2;
            this.lblDetalleRecomendacion.Text = "Esperando resultados del modelo...";
            // 
            // pnlGraficoRecomendacionIA
            // 
            this.pnlGraficoRecomendacionIA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGraficoRecomendacionIA.BackColor = System.Drawing.Color.White;
            this.pnlGraficoRecomendacionIA.Location = new System.Drawing.Point(550, 225);
            this.pnlGraficoRecomendacionIA.Name = "pnlGraficoRecomendacionIA";
            this.pnlGraficoRecomendacionIA.Size = new System.Drawing.Size(500, 300);
            this.pnlGraficoRecomendacionIA.TabIndex = 3;
            // 
            // dgvRecomendacionesIA
            // 
            this.dgvRecomendacionesIA.AllowUserToAddRows = false;
            this.dgvRecomendacionesIA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRecomendacionesIA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecomendacionesIA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecomendacionesIA.Location = new System.Drawing.Point(30, 225);
            this.dgvRecomendacionesIA.Name = "dgvRecomendacionesIA";
            this.dgvRecomendacionesIA.ReadOnly = true;
            this.dgvRecomendacionesIA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecomendacionesIA.Size = new System.Drawing.Size(500, 300);
            this.dgvRecomendacionesIA.TabIndex = 4;
            // 
            // lblAvisoIA
            // 
            this.lblAvisoIA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvisoIA.AutoSize = true;
            this.lblAvisoIA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoIA.Location = new System.Drawing.Point(30, 550);
            this.lblAvisoIA.Name = "lblAvisoIA";
            this.lblAvisoIA.Size = new System.Drawing.Size(457, 15);
            this.lblAvisoIA.TabIndex = 5;
            this.lblAvisoIA.Text = "Predicción experimental: los resultados no garantizan el cumplimiento de las entr" +
    "egas.";
            // 
            // UIRecomendacionIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.lblAvisoIA);
            this.Controls.Add(this.dgvRecomendacionesIA);
            this.Controls.Add(this.pnlGraficoRecomendacionIA);
            this.Controls.Add(this.lblDetalleRecomendacion);
            this.Controls.Add(this.lblProveedorSugerido);
            this.Controls.Add(this.lblTituloRecomendacion);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "UIRecomendacionIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recomendación Inteligente de Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecomendacionesIA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloRecomendacion;
        private System.Windows.Forms.Label lblProveedorSugerido;
        private System.Windows.Forms.Label lblDetalleRecomendacion;
        private System.Windows.Forms.Panel pnlGraficoRecomendacionIA;
        private System.Windows.Forms.DataGridView dgvRecomendacionesIA;
        private System.Windows.Forms.Label lblAvisoIA;
    }
}
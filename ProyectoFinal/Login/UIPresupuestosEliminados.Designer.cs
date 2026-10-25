namespace Login
{
    partial class UIPresupuestosEliminados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.dgvPresupuestosEliminados = new System.Windows.Forms.DataGridView();
            this.colIdPresupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReactivar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestosEliminados)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(720, 520);
            this.Text = "Presupuestos eliminados";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIPresupuestosEliminados";
            this.Load += new System.EventHandler(this.UIPresupuestosEliminados_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Presupuestos eliminados";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(500, 32);
            this.lblTitulo.Name = "lblTitulo";

            this.lblSeleccion.Text = "Presupuesto:";
            this.lblSeleccion.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSeleccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSeleccion.Location = new System.Drawing.Point(20, 56);
            this.lblSeleccion.Size = new System.Drawing.Size(140, 20);
            this.lblSeleccion.Name = "lblSeleccion";

            this.labelId.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(160, 56);
            this.labelId.Size = new System.Drawing.Size(200, 20);
            this.labelId.Name = "labelId";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvPresupuestosEliminados.Location = new System.Drawing.Point(20, 88);
            this.dgvPresupuestosEliminados.Size = new System.Drawing.Size(680, 340);
            this.dgvPresupuestosEliminados.Name = "dgvPresupuestosEliminados";
            this.dgvPresupuestosEliminados.TabIndex = 0;
            this.dgvPresupuestosEliminados.AllowUserToAddRows = false;
            this.dgvPresupuestosEliminados.AllowUserToDeleteRows = false;
            this.dgvPresupuestosEliminados.ReadOnly = true;
            this.dgvPresupuestosEliminados.RowTemplate.Height = 32;
            this.dgvPresupuestosEliminados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresupuestosEliminados.RowHeadersVisible = false;
            this.dgvPresupuestosEliminados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresupuestosEliminados.AutoGenerateColumns = false;
            this.dgvPresupuestosEliminados.SelectionChanged += new System.EventHandler(this.dgvPresupuestosEliminados_SelectionChanged);
            this.dgvPresupuestosEliminados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPresupuestosEliminados_CellFormatting);

            this.colIdPresupuesto.HeaderText = "N° Presupuesto";
            this.colIdPresupuesto.Name = "IdPresupuesto";
            this.colIdPresupuesto.DataPropertyName = "IdPresupuesto";
            this.colIdPresupuesto.FillWeight = 60;

            this.colIdSolicitud.HeaderText = "N° Cotización";
            this.colIdSolicitud.Name = "IdSolicitud";
            this.colIdSolicitud.DataPropertyName = "IdSolicitud";
            this.colIdSolicitud.FillWeight = 60;

            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "Proveedor";
            this.colProveedor.DataPropertyName = "NombreProveedor";
            this.colProveedor.FillWeight = 90;

            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "Fecha";
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.FillWeight = 60;
            this.colFecha.ValueType = typeof(System.DateTime);
            this.colFecha.DefaultCellStyle.Format = "dd-MM-yyyy";

            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "Total";
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.FillWeight = 60;
            this.colTotal.DefaultCellStyle.Format = "$#,##0.00";
            this.colTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.dgvPresupuestosEliminados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colIdPresupuesto, this.colIdSolicitud, this.colProveedor, this.colFecha, this.colTotal
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSeleccion);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.dgvPresupuestosEliminados);
            this.Controls.Add(this.btnReactivar);
            this.Controls.Add(this.btnCerrar);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestosEliminados)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSeleccion;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.DataGridView dgvPresupuestosEliminados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPresupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Button btnReactivar;
        private System.Windows.Forms.Button btnCerrar;
    }
}

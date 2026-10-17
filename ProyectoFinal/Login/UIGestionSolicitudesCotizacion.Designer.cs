namespace Login
{
    partial class UIGestionSolicitudesCotizacion
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
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnNuevaSolicitud = new System.Windows.Forms.Button();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.colIdSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Text = "Solicitudes de cotización";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIGestionSolicitudesCotizacion";
            this.Load += new System.EventHandler(this.UIGestionSolicitudesCotizacion_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Solicitudes de cotización";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL ACCIONES ──────────────────────────────────────
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Location = new System.Drawing.Point(20, 56);
            this.pnlAcciones.Size = new System.Drawing.Size(320, 240);
            this.pnlAcciones.Name = "pnlAcciones";

            this.pnlAcciones.Controls.Add(this.btnNuevaSolicitud);
            this.pnlAcciones.Controls.Add(this.btnVerPdf);
            this.pnlAcciones.Controls.Add(this.btnCerrar);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvSolicitudes.Location = new System.Drawing.Point(356, 56);
            this.dgvSolicitudes.Size = new System.Drawing.Size(624, 564);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.TabIndex = 3;
            this.dgvSolicitudes.AllowUserToAddRows = false;
            this.dgvSolicitudes.AllowUserToDeleteRows = false;
            this.dgvSolicitudes.ReadOnly = true;
            this.dgvSolicitudes.RowTemplate.Height = 35;
            this.dgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudes.RowHeadersVisible = false;
            this.dgvSolicitudes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudes.AutoGenerateColumns = false;

            this.colIdSolicitud.HeaderText = "IdSolicitud";
            this.colIdSolicitud.Name = "IdSolicitud";
            this.colIdSolicitud.FillWeight = 40;

            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "Proveedor";
            this.colProveedor.FillWeight = 90;

            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "Fecha";
            this.colFecha.FillWeight = 60;
            this.colFecha.ValueType = typeof(System.DateTime);
            this.colFecha.DefaultCellStyle.Format = "dd-MM-yyyy";

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.FillWeight = 70;

            this.dgvSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colIdSolicitud, this.colProveedor, this.colFecha, this.colEstado
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.dgvSolicitudes);

            this.pnlAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnNuevaSolicitud;
        private System.Windows.Forms.Button btnVerPdf;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}

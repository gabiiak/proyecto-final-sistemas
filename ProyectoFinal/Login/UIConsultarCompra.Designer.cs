namespace Login
{
    partial class UIConsultarCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblProveedorKey = new System.Windows.Forms.Label();
            this.labelProveedor = new System.Windows.Forms.Label();
            this.lblFechaKey = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.lblFechaRecepcionKey = new System.Windows.Forms.Label();
            this.labelFechaRecepcion = new System.Windows.Forms.Label();
            this.lblDeudaKey = new System.Windows.Forms.Label();
            this.labelDeuda = new System.Windows.Forms.Label();
            this.lblEstadoKey = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.lblEstadoPagoKey = new System.Windows.Forms.Label();
            this.labelEstadoPago = new System.Windows.Forms.Label();
            this.lblPagadoKey = new System.Windows.Forms.Label();
            this.labelPagado = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvConsultaCompra = new System.Windows.Forms.DataGridView();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalKey = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnEmitirOrden = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEditarFechas = new System.Windows.Forms.Button();

            this.pnlInfo.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaCompra)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(480, 650);
            this.Text = "Consultar Compra";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIConsultarCompra";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIConsultarCompra_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Consultar Compra";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(440, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL INFO ──────────────────────────────────────────
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(20, 56);
            this.pnlInfo.Size = new System.Drawing.Size(440, 188);
            this.pnlInfo.Name = "pnlInfo";

            this.pnlInfo.Controls.Add(this.lblProveedorKey);
            this.pnlInfo.Controls.Add(this.labelProveedor);
            this.pnlInfo.Controls.Add(this.lblFechaKey);
            this.pnlInfo.Controls.Add(this.labelFecha);
            this.pnlInfo.Controls.Add(this.lblFechaRecepcionKey);
            this.pnlInfo.Controls.Add(this.labelFechaRecepcion);
            this.pnlInfo.Controls.Add(this.lblDeudaKey);
            this.pnlInfo.Controls.Add(this.labelDeuda);
            this.pnlInfo.Controls.Add(this.lblEstadoKey);
            this.pnlInfo.Controls.Add(this.labelEstado);
            this.pnlInfo.Controls.Add(this.lblEstadoPagoKey);
            this.pnlInfo.Controls.Add(this.labelEstadoPago);
            this.pnlInfo.Controls.Add(this.lblPagadoKey);
            this.pnlInfo.Controls.Add(this.labelPagado);

            // ── LABEL DETALLES ──────────────────────────────────────
            this.lblDetalles.Text = "Insumos";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 260);
            this.lblDetalles.Size = new System.Drawing.Size(200, 24);
            this.lblDetalles.Name = "lblDetalles";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvConsultaCompra.Location = new System.Drawing.Point(20, 288);
            this.dgvConsultaCompra.Size = new System.Drawing.Size(440, 176);
            this.dgvConsultaCompra.Name = "dgvConsultaCompra";
            this.dgvConsultaCompra.TabIndex = 0;
            this.dgvConsultaCompra.AllowUserToAddRows = false;
            this.dgvConsultaCompra.AllowUserToDeleteRows = false;
            this.dgvConsultaCompra.ReadOnly = true;
            this.dgvConsultaCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaCompra.RowHeadersVisible = false;
            this.dgvConsultaCompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsultaCompra.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsultaCompra.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvConsultaCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultaCompra.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvConsultaCompra.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvConsultaCompra.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvConsultaCompra.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvConsultaCompra.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvConsultaCompra.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvConsultaCompra.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvConsultaCompra.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvConsultaCompra.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "Insumo";
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "Cantidad";
            this.colCantidad.ValueType = typeof(decimal);
            this.colCantidad.DefaultCellStyle.Format = "N2";
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSubTotal.HeaderText = "Subtotal";
            this.colSubTotal.Name = "SubTotal";
            this.colSubTotal.ValueType = typeof(double);
            this.colSubTotal.DefaultCellStyle.Format = "$#,##0.00";
            this.colSubTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.dgvConsultaCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colInsumo, this.colCantidad, this.colSubTotal
            });

            // ── PANEL TOTAL ─────────────────────────────────────────
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 476);
            this.pnlTotal.Size = new System.Drawing.Size(440, 56);
            this.pnlTotal.Name = "pnlTotal";

            this.lblTotalKey.Text = "TOTAL";
            this.lblTotalKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalKey.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalKey.Location = new System.Drawing.Point(16, 8);
            this.lblTotalKey.Size = new System.Drawing.Size(60, 16);
            this.lblTotalKey.Name = "lblTotalKey";

            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(16, 24);
            this.labelTotal.Size = new System.Drawing.Size(200, 26);
            this.labelTotal.Name = "labelTotal";

            this.pnlTotal.Controls.Add(this.lblTotalKey);
            this.pnlTotal.Controls.Add(this.labelTotal);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvConsultaCompra);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.btnEmitirOrden);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEditarFechas);

            this.pnlInfo.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaCompra)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProveedorKey;
        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.Label lblFechaKey;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label lblFechaRecepcionKey;
        private System.Windows.Forms.Label labelFechaRecepcion;
        private System.Windows.Forms.Label lblDeudaKey;
        private System.Windows.Forms.Label labelDeuda;
        private System.Windows.Forms.Label lblEstadoKey;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label lblEstadoPagoKey;
        private System.Windows.Forms.Label labelEstadoPago;
        private System.Windows.Forms.Label lblPagadoKey;
        private System.Windows.Forms.Label labelPagado;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvConsultaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.Label lblTotalKey;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnEmitirOrden;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEditarFechas;
    }
}
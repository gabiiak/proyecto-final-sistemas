namespace Login
{
    partial class UIGestionCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.pnlSepVertical = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblIdCompraLabel = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.btnRegistrarCompra = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnConsultarCompra = new System.Windows.Forms.Button();
            this.btnSolicitudesCotizacion = new System.Windows.Forms.Button();
            this.btnPresupuestos = new System.Windows.Forms.Button();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarPorFecha = new System.Windows.Forms.Button();
            this.lblFiltroProveedor = new System.Windows.Forms.Label();
            this.cbProveedorFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltroProveedor = new System.Windows.Forms.Button();
            this.btnDesfiltrar = new System.Windows.Forms.Button();
            this.btnVerCanceladas = new System.Windows.Forms.Button();
            this.dgvTodasLasCompras = new System.Windows.Forms.DataGridView();
            this.colIdCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReporteMensual = new System.Windows.Forms.Button();
            this.pnlDerecha = new System.Windows.Forms.Panel();

            this.pnlDerecha.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasCompras)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1300, 680);
            //this.ClientSize = new System.Drawing.Size(1000, 680); en el size original. estamos experimentando
            this.Text = "Gestión de Compras";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIGestionCompras";
            this.Load += new System.EventHandler(this.UIGestionCompras_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Gestión de Compras";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL ACCIONES ──────────────────────────────────────
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Location = new System.Drawing.Point(20, 56);
            this.pnlAcciones.Size = new System.Drawing.Size(320, 300);
            this.pnlAcciones.Name = "pnlAcciones";

            this.lblIdCompraLabel.Text = "Compra seleccionada:";
            this.lblIdCompraLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblIdCompraLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdCompraLabel.Location = new System.Drawing.Point(16, 128);
            this.lblIdCompraLabel.Size = new System.Drawing.Size(140, 20);
            this.lblIdCompraLabel.Name = "lblIdCompraLabel";

            this.labelId.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(162, 128);
            this.labelId.Size = new System.Drawing.Size(80, 20);
            this.labelId.Name = "labelId";

            this.pnlAcciones.Controls.Add(this.btnRegistrarCompra);
            this.pnlAcciones.Controls.Add(this.btnCambiarEstado);
            this.pnlAcciones.Controls.Add(this.btnRegistrarPago);
            this.pnlAcciones.Controls.Add(this.lblIdCompraLabel);
            this.pnlAcciones.Controls.Add(this.labelId);
            this.pnlAcciones.Controls.Add(this.btnConsultarCompra);
            this.pnlAcciones.Controls.Add(this.btnSolicitudesCotizacion);
            this.pnlAcciones.Controls.Add(this.btnPresupuestos);
            this.pnlAcciones.Controls.Add(this.btnExportarExcel);
            this.btnSolicitudesCotizacion.Name = "btnSolicitudesCotizacion";

            // ── PANEL FILTROS ───────────────────────────────────────
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Location = new System.Drawing.Point(356, 56);
            this.pnlFiltros.Size = new System.Drawing.Size(624, 240);
            this.pnlFiltros.Name = "pnlFiltros";

            // ── PANEL DERECHA ───────────────────────────────────
            this.pnlDerecha.BackColor = System.Drawing.Color.Magenta;
            this.pnlDerecha.Location = new System.Drawing.Point(900, 56);
            this.pnlDerecha.Size = new System.Drawing.Size(720, 240);
            this.pnlDerecha.Name = "pnlDerecha";

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(16, 36);
            this.dtpDesde.Size = new System.Drawing.Size(180, 28);
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesde.TabIndex = 4;
            this.dtpDesde.Name = "dtpDesde";

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(16, 88);
            this.dtpHasta.Size = new System.Drawing.Size(180, 28);
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.TabIndex = 5;
            this.dtpHasta.Name = "dtpHasta";

            this.pnlSepVertical.BackColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.pnlSepVertical.Location = new System.Drawing.Point(226, 16);
            this.pnlSepVertical.Size = new System.Drawing.Size(1, 168);
            this.pnlSepVertical.Name = "pnlSepVertical";

            this.cbProveedorFiltro.Location = new System.Drawing.Point(246, 36);
            this.cbProveedorFiltro.Size = new System.Drawing.Size(196, 28);
            this.cbProveedorFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbProveedorFiltro.FormattingEnabled = true;
            this.cbProveedorFiltro.TabIndex = 7;
            this.cbProveedorFiltro.Name = "cbProveedorFiltro";

            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnFiltrarPorFecha);
            this.pnlFiltros.Controls.Add(this.pnlSepVertical);
            this.pnlFiltros.Controls.Add(this.lblFiltroProveedor);
            this.pnlFiltros.Controls.Add(this.cbProveedorFiltro);
            this.pnlFiltros.Controls.Add(this.btnFiltroProveedor);
            this.pnlFiltros.Controls.Add(this.btnReporteMensual);
            this.pnlFiltros.Controls.Add(this.btnDesfiltrar);
            this.pnlFiltros.Controls.Add(this.btnVerCanceladas);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvTodasLasCompras.Location = new System.Drawing.Point(20, 372);
            this.dgvTodasLasCompras.Size = new System.Drawing.Size(960, 292);
            this.dgvTodasLasCompras.Name = "dgvTodasLasCompras";
            this.dgvTodasLasCompras.TabIndex = 10;
            this.dgvTodasLasCompras.AllowUserToAddRows = false;
            this.dgvTodasLasCompras.AllowUserToDeleteRows = false;
            this.dgvTodasLasCompras.ReadOnly = true;
            this.dgvTodasLasCompras.RowTemplate.Height = 35;
            this.dgvTodasLasCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodasLasCompras.RowHeadersVisible = false;
            this.dgvTodasLasCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTodasLasCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodasLasCompras.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvTodasLasCompras.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvTodasLasCompras.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvTodasLasCompras.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvTodasLasCompras.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvTodasLasCompras.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTodasLasCompras.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvTodasLasCompras.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTodasLasCompras.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvTodasLasCompras.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            this.dgvTodasLasCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodasLasCompras.SelectionChanged += new System.EventHandler(this.dgvTodasLasCompras_SelectionChanged);
            this.dgvTodasLasCompras.AutoGenerateColumns = false;

            this.colIdCompra.HeaderText = "IdCompra";
            this.colIdCompra.Name = "IdCompra";
            this.colIdCompra.FillWeight = 40;

            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "Proveedor";
            this.colProveedor.FillWeight = 90;

            // CAMBIO: tipo DateTime + formato
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "Fecha";
            this.colFecha.FillWeight = 60;
            this.colFecha.ValueType = typeof(System.DateTime);
            this.colFecha.DefaultCellStyle.Format = "dd-MM-yyyy";

            // CAMBIO: tipo decimal + formato moneda
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "Total";
            this.colTotal.FillWeight = 80;
            this.colTotal.ValueType = typeof(double);
            this.colTotal.DefaultCellStyle.Format = "C2";
            this.colTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            // CAMBIO: tipo decimal + formato moneda
            this.colMontoPagado.HeaderText = "Monto pagado";
            this.colMontoPagado.Name = "MontoPagado";
            this.colMontoPagado.FillWeight = 80;
            this.colMontoPagado.ValueType = typeof(double);
            this.colMontoPagado.DefaultCellStyle.Format = "C2";
            this.colMontoPagado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.FillWeight = 70;

            this.colEstadoPago.HeaderText = "Pago";
            this.colEstadoPago.Name = "EstadoPago";
            this.colEstadoPago.FillWeight = 70;

            this.dgvTodasLasCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colIdCompra, this.colProveedor, this.colFecha,
                this.colTotal, this.colMontoPagado, this.colEstado, this.colEstadoPago
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.dgvTodasLasCompras);

            this.pnlAcciones.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasCompras)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Button btnReporteMensual;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Panel pnlSepVertical;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdCompraLabel;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnRegistrarCompra;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnConsultarCompra;
        private System.Windows.Forms.Button btnSolicitudesCotizacion;
        private System.Windows.Forms.Button btnPresupuestos;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrarPorFecha;
        private System.Windows.Forms.Label lblFiltroProveedor;
        private System.Windows.Forms.ComboBox cbProveedorFiltro;
        private System.Windows.Forms.Button btnFiltroProveedor;
        private System.Windows.Forms.Button btnDesfiltrar;
        private System.Windows.Forms.Button btnVerCanceladas;
        private System.Windows.Forms.DataGridView dgvTodasLasCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoPago;
        private System.Windows.Forms.Panel pnlDerecha;
    }
}
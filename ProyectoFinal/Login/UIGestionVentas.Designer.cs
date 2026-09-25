namespace Login
{
    partial class UIGestionVentas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnTransporte = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblIdVentaLabel = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.btnEstadoPago = new System.Windows.Forms.Button();
            this.btnEstadoPedido = new System.Windows.Forms.Button();
            this.btnConsultarVenta = new System.Windows.Forms.Button();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarPorFecha = new System.Windows.Forms.Button();
            this.lblFiltroCliente = new System.Windows.Forms.Label();
            this.cbClienteFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltroCliente = new System.Windows.Forms.Button();
            this.btnDesfiltrar = new System.Windows.Forms.Button();
            this.dgvTodasLasVentas = new System.Windows.Forms.DataGridView();
            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoDePedido = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlAcciones.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasVentas)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Text = "Gestión de Ventas";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UISalesManagement";
            this.Load += new System.EventHandler(this.UISalesManagement_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Gestión de Ventas";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL ACCIONES ──────────────────────────────────────
            // Zona izquierda: registrar + cambiar estados + ID seleccionada
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Location = new System.Drawing.Point(20, 56);
            this.pnlAcciones.Size = new System.Drawing.Size(320, 240);
            this.pnlAcciones.Name = "pnlAcciones";
            //this.pnlAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.pnlAcciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Botón principal — ocupa todo el ancho del panel
            

            // Separador visual: ID de venta seleccionada
            this.lblIdVentaLabel.Text = "Venta seleccionada:";
            this.lblIdVentaLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblIdVentaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdVentaLabel.Location = new System.Drawing.Point(16, 128);
            this.lblIdVentaLabel.Size = new System.Drawing.Size(140, 20);
            this.lblIdVentaLabel.Name = "lblIdVentaLabel";

            this.labelId.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(162, 128);
            this.labelId.Size = new System.Drawing.Size(80, 20);
            this.labelId.Name = "labelId";

            

            this.pnlAcciones.Controls.Add(this.btnTransporte);
            this.pnlAcciones.Controls.Add(this.btnRegistrarVenta);
            this.pnlAcciones.Controls.Add(this.btnEstadoPago);
            this.pnlAcciones.Controls.Add(this.btnEstadoPedido);
            this.pnlAcciones.Controls.Add(this.lblIdVentaLabel);
            this.pnlAcciones.Controls.Add(this.labelId);
            this.pnlAcciones.Controls.Add(this.btnConsultarVenta);
            this.pnlAcciones.Controls.Add(this.btnExportarExcel);

            // ── PANEL FILTROS ───────────────────────────────────────
            // Zona derecha: filtros por fecha y por cliente
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Location = new System.Drawing.Point(356, 56);
            this.pnlFiltros.Size = new System.Drawing.Size(624, 240);
            this.pnlFiltros.Name = "pnlFiltros";
            //this.pnlFiltros.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Sección filtro por fecha
            

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

            

            // Separador vertical simulado con un panel de 1px
            var pnlSepVertical = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.FromArgb(211, 209, 199),
                Location = new System.Drawing.Point(226, 16),
                Size = new System.Drawing.Size(1, 168),
                Name = "pnlSepVertical"
            };

            // Sección filtro por cliente
            

            this.cbClienteFiltro.Location = new System.Drawing.Point(246, 36);
            this.cbClienteFiltro.Size = new System.Drawing.Size(196, 28);
            this.cbClienteFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbClienteFiltro.FormattingEnabled = true;
            this.cbClienteFiltro.TabIndex = 7;
            this.cbClienteFiltro.Name = "cbClienteFiltro";

            

            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnFiltrarPorFecha);
            this.pnlFiltros.Controls.Add(pnlSepVertical);
            this.pnlFiltros.Controls.Add(this.lblFiltroCliente);
            this.pnlFiltros.Controls.Add(this.cbClienteFiltro);
            this.pnlFiltros.Controls.Add(this.btnFiltroCliente);
            this.pnlFiltros.Controls.Add(this.btnDesfiltrar);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvTodasLasVentas.Location = new System.Drawing.Point(20, 302);
            this.dgvTodasLasVentas.Size = new System.Drawing.Size(960, 384);
            this.dgvTodasLasVentas.Name = "dgvTodasLasVentas";
            this.dgvTodasLasVentas.TabIndex = 10;
            this.dgvTodasLasVentas.AllowUserToAddRows = false;
            this.dgvTodasLasVentas.AllowUserToDeleteRows = false;
            this.dgvTodasLasVentas.ReadOnly = true;
            this.dgvTodasLasVentas.RowTemplate.Height = 35;
            this.dgvTodasLasVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodasLasVentas.RowHeadersVisible = false;
            this.dgvTodasLasVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTodasLasVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodasLasVentas.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvTodasLasVentas.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvTodasLasVentas.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvTodasLasVentas.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvTodasLasVentas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvTodasLasVentas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTodasLasVentas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvTodasLasVentas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTodasLasVentas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvTodasLasVentas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            this.dgvTodasLasVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodasLasVentas.SelectionChanged += new System.EventHandler(this.dgvTodasLasVentas_SelectionChanged);
            this.dgvTodasLasVentas.AutoGenerateColumns = false;

            // Columnas con headers en español
            this.IdVenta.HeaderText = "IdVenta";
            this.IdVenta.Name = "IdVenta";
            this.IdVenta.FillWeight = 40;

            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.FillWeight = 80;

            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.FillWeight = 60;

            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.FillWeight = 80;

            this.MetodoPago.HeaderText = "MetodoPago";
            this.MetodoPago.Name = "MetodoPago";
            this.MetodoPago.FillWeight = 80;

            this.EstadoDePago.HeaderText = "Estado de Pago";
            this.EstadoDePago.Name = "EstadoDePago";
            this.EstadoDePago.FillWeight = 80;

            this.EstadoDePedido.HeaderText = "Estado de Pedido";
            this.EstadoDePedido.Name = "EstadoDePedido";
            this.EstadoDePedido.FillWeight = 80;

            this.dgvTodasLasVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.IdVenta, this.Cliente, this.Fecha, this.Total,
                this.MetodoPago, this.EstadoDePago, this.EstadoDePedido
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.dgvTodasLasVentas);

            this.pnlAcciones.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasVentas)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdVentaLabel;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnEstadoPago;
        private System.Windows.Forms.Button btnEstadoPedido;
        private System.Windows.Forms.Button btnConsultarVenta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrarPorFecha;
        private System.Windows.Forms.Label lblFiltroCliente;
        private System.Windows.Forms.ComboBox cbClienteFiltro;
        private System.Windows.Forms.Button btnFiltroCliente;
        private System.Windows.Forms.Button btnDesfiltrar;
        private System.Windows.Forms.DataGridView dgvTodasLasVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDePedido;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnTransporte;
    }
}
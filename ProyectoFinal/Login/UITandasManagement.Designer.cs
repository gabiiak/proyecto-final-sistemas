namespace Login
{
    partial class UITandasManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblIdTandaLabel = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.btnRegistrarTanda = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnConsultarTanda = new System.Windows.Forms.Button();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarPorFecha = new System.Windows.Forms.Button();
            this.lblFiltroProducto = new System.Windows.Forms.Label();
            this.cbProductoFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltroProducto = new System.Windows.Forms.Button();
            this.btnDesfiltrar = new System.Windows.Forms.Button();
            this.dgvTodasLasTandas = new System.Windows.Forms.DataGridView();
            this.IdTanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlAcciones.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasTandas)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Text = "Gestión de Tandas de Producción";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Load += new System.EventHandler(this.UITandasManagement_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Gestión de Tandas de Producción";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);

            // ── PANEL ACCIONES ──────────────────────────────────────
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Location = new System.Drawing.Point(20, 56);
            this.pnlAcciones.Size = new System.Drawing.Size(320, 240);

            // Botón principal
            ConfigurarBotonPrimario(this.btnRegistrarTanda, "Nueva Tanda", new System.Drawing.Point(16, 16), 0);
            this.btnRegistrarTanda.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarTanda.Click += new System.EventHandler(this.btnRegistrarTanda_Click);

            // Botones secundarios en fila
            ConfigurarBotonSecundario(this.btnCambiarEstado, "Cambiar Estado", new System.Drawing.Point(16, 68), 1);
            this.btnCambiarEstado.Size = new System.Drawing.Size(138, 36);
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);

            ConfigurarBotonSecundario(this.btnConsultarTanda, "Ver Detalle", new System.Drawing.Point(166, 68), 2);
            this.btnConsultarTanda.Size = new System.Drawing.Size(138, 36);
            this.btnConsultarTanda.Click += new System.EventHandler(this.btnConsultarTanda_Click);

            // Indicador de ID seleccionada
            this.lblIdTandaLabel.Text = "Tanda seleccionada:";
            this.lblIdTandaLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblIdTandaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdTandaLabel.Location = new System.Drawing.Point(16, 124);
            this.lblIdTandaLabel.Size = new System.Drawing.Size(140, 20);

            this.labelId.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(160, 124);
            this.labelId.Size = new System.Drawing.Size(80, 20);

            this.pnlAcciones.Controls.Add(this.btnRegistrarTanda);
            this.pnlAcciones.Controls.Add(this.btnCambiarEstado);
            this.pnlAcciones.Controls.Add(this.btnConsultarTanda);
            this.pnlAcciones.Controls.Add(this.lblIdTandaLabel);
            this.pnlAcciones.Controls.Add(this.labelId);

            // ── PANEL FILTROS ───────────────────────────────────────
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Location = new System.Drawing.Point(356, 56);
            this.pnlFiltros.Size = new System.Drawing.Size(624, 240);

            ConfigurarLabel(this.lblDesde, "Desde", new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblHasta, "Hasta", new System.Drawing.Point(16, 68));

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(16, 36);
            this.dtpDesde.Size = new System.Drawing.Size(180, 28);

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(16, 88);
            this.dtpHasta.Size = new System.Drawing.Size(180, 28);

            ConfigurarBotonPrimario(this.btnFiltrarPorFecha, "Filtrar por fecha", new System.Drawing.Point(16, 145), 3);
            this.btnFiltrarPorFecha.Size = new System.Drawing.Size(180, 36);
            this.btnFiltrarPorFecha.Click += new System.EventHandler(this.btnFiltrarPorFecha_Click);

            var pnlSepVertical = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.FromArgb(211, 209, 199),
                Location = new System.Drawing.Point(226, 16),
                Size = new System.Drawing.Size(1, 168)
            };

            ConfigurarLabel(this.lblFiltroProducto, "Filtrar por producto", new System.Drawing.Point(246, 16));
            this.cbProductoFiltro.Location = new System.Drawing.Point(246, 36);
            this.cbProductoFiltro.Size = new System.Drawing.Size(196, 28);

            ConfigurarBotonPrimario(this.btnFiltroProducto, "Filtrar", new System.Drawing.Point(246, 76), 4);
            this.btnFiltroProducto.Size = new System.Drawing.Size(120, 36);
            this.btnFiltroProducto.Click += new System.EventHandler(this.btnFiltroProducto_Click);

            ConfigurarBotonFantasma(this.btnDesfiltrar, "Quitar filtros", new System.Drawing.Point(246, 124), 5);
            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);

            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.btnFiltrarPorFecha);
            this.pnlFiltros.Controls.Add(pnlSepVertical);
            this.pnlFiltros.Controls.Add(this.lblFiltroProducto);
            this.pnlFiltros.Controls.Add(this.cbProductoFiltro);
            this.pnlFiltros.Controls.Add(this.btnFiltroProducto);
            this.pnlFiltros.Controls.Add(this.btnDesfiltrar);

            // ── DATAGRIDVIEW PRINCIPAL ──────────────────────────────
            this.dgvTodasLasTandas.Location = new System.Drawing.Point(20, 302);
            this.dgvTodasLasTandas.Size = new System.Drawing.Size(960, 360);
            this.dgvTodasLasTandas.ReadOnly = true;
            this.dgvTodasLasTandas.RowTemplate.Height = 35;
            this.dgvTodasLasTandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodasLasTandas.RowHeadersVisible = false;
            this.dgvTodasLasTandas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTodasLasTandas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodasLasTandas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodasLasTandas.SelectionChanged += new System.EventHandler(this.dgvTodasLasTandas_SelectionChanged);

            this.IdTanda.HeaderText = "ID Tanda";
            this.IdTanda.Name = "IdTanda";
            this.IdTanda.FillWeight = 40;

            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.FillWeight = 90;

            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.FillWeight = 60;

            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.FillWeight = 60;

            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.FillWeight = 70;

            this.dgvTodasLasTandas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.IdTanda, this.Producto, this.Fecha, this.Hora, this.Estado
            });

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.dgvTodasLasTandas);

            this.pnlAcciones.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasTandas)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(200, 18);
        }

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
        }

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
        }

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(200, 30);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
        }

        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdTandaLabel;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnRegistrarTanda;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnConsultarTanda;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrarPorFecha;
        private System.Windows.Forms.Label lblFiltroProducto;
        private System.Windows.Forms.ComboBox cbProductoFiltro;
        private System.Windows.Forms.Button btnFiltroProducto;
        private System.Windows.Forms.Button btnDesfiltrar;
        private System.Windows.Forms.DataGridView dgvTodasLasTandas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}
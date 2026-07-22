//namespace Login
//{
//    partial class UISalesManagement
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.btnFiltrarPorFecha = new System.Windows.Forms.Button();
//            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
//            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
//            this.panel2 = new System.Windows.Forms.Panel();
//            this.dgvTodasLasVentas = new System.Windows.Forms.DataGridView();
//            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.EstadoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.EstadoDePedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.btnConsultarVenta = new System.Windows.Forms.Button();
//            this.labelId = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.btnEstadoPedido = new System.Windows.Forms.Button();
//            this.btnEstadoPago = new System.Windows.Forms.Button();
//            this.label1 = new System.Windows.Forms.Label();
//            this.btnRegistrarVenta = new System.Windows.Forms.Button();
//            this.label5 = new System.Windows.Forms.Label();
//            this.label6 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.btnFiltroCliente = new System.Windows.Forms.Button();
//            this.btnDesfiltrar = new System.Windows.Forms.Button();
//            this.cbClienteFiltro = new System.Windows.Forms.ComboBox();
//            this.panel1.SuspendLayout();
//            this.panel2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasVentas)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.cbClienteFiltro);
//            this.panel1.Controls.Add(this.btnDesfiltrar);
//            this.panel1.Controls.Add(this.btnFiltroCliente);
//            this.panel1.Controls.Add(this.label3);
//            this.panel1.Controls.Add(this.label6);
//            this.panel1.Controls.Add(this.label5);
//            this.panel1.Controls.Add(this.btnFiltrarPorFecha);
//            this.panel1.Controls.Add(this.dtpHasta);
//            this.panel1.Controls.Add(this.dtpDesde);
//            this.panel1.Controls.Add(this.panel2);
//            this.panel1.Controls.Add(this.btnConsultarVenta);
//            this.panel1.Controls.Add(this.labelId);
//            this.panel1.Controls.Add(this.label2);
//            this.panel1.Controls.Add(this.btnEstadoPedido);
//            this.panel1.Controls.Add(this.btnEstadoPago);
//            this.panel1.Controls.Add(this.label1);
//            this.panel1.Controls.Add(this.btnRegistrarVenta);
//            this.panel1.Location = new System.Drawing.Point(12, 12);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(687, 519);
//            this.panel1.TabIndex = 0;
//            // 
//            // btnFiltrarPorFecha
//            // 
//            this.btnFiltrarPorFecha.Location = new System.Drawing.Point(420, 123);
//            this.btnFiltrarPorFecha.Name = "btnFiltrarPorFecha";
//            this.btnFiltrarPorFecha.Size = new System.Drawing.Size(148, 23);
//            this.btnFiltrarPorFecha.TabIndex = 15;
//            this.btnFiltrarPorFecha.Text = "Filtrar por fecha";
//            this.btnFiltrarPorFecha.UseVisualStyleBackColor = true;
//            this.btnFiltrarPorFecha.Click += new System.EventHandler(this.btnFiltrarPorFecha_Click);
//            // 
//            // dtpHasta
//            // 
//            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
//            this.dtpHasta.Location = new System.Drawing.Point(467, 97);
//            this.dtpHasta.Name = "dtpHasta";
//            this.dtpHasta.Size = new System.Drawing.Size(101, 20);
//            this.dtpHasta.TabIndex = 14;
//            // 
//            // dtpDesde
//            // 
//            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
//            this.dtpDesde.Location = new System.Drawing.Point(467, 71);
//            this.dtpDesde.Name = "dtpDesde";
//            this.dtpDesde.Size = new System.Drawing.Size(101, 20);
//            this.dtpDesde.TabIndex = 13;
//            this.dtpDesde.Value = new System.DateTime(2026, 4, 1, 0, 0, 0, 0);
//            // 
//            // panel2
//            // 
//            this.panel2.Controls.Add(this.dgvTodasLasVentas);
//            this.panel2.Location = new System.Drawing.Point(19, 240);
//            this.panel2.Name = "panel2";
//            this.panel2.Size = new System.Drawing.Size(654, 268);
//            this.panel2.TabIndex = 12;
//            // 
//            // dgvTodasLasVentas
//            // 
//            this.dgvTodasLasVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvTodasLasVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.IdVenta,
//            this.Cliente,
//            this.Fecha,
//            this.Total,
//            this.MetodoPago,
//            this.EstadoDePago,
//            this.EstadoDePedido});
//            this.dgvTodasLasVentas.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.dgvTodasLasVentas.Location = new System.Drawing.Point(0, 0);
//            this.dgvTodasLasVentas.Name = "dgvTodasLasVentas";
//            this.dgvTodasLasVentas.Size = new System.Drawing.Size(654, 268);
//            this.dgvTodasLasVentas.TabIndex = 0;
//            this.dgvTodasLasVentas.SelectionChanged += new System.EventHandler(this.dgvTodasLasVentas_SelectionChanged);
//            // 
//            // IdVenta
//            // 
//            this.IdVenta.HeaderText = "ID";
//            this.IdVenta.Name = "IdVenta";
//            this.IdVenta.Width = 40;
//            // 
//            // Cliente
//            // 
//            this.Cliente.HeaderText = "Cliente";
//            this.Cliente.Name = "Cliente";
//            this.Cliente.Width = 80;
//            // 
//            // Fecha
//            // 
//            this.Fecha.HeaderText = "Fecha";
//            this.Fecha.Name = "Fecha";
//            // 
//            // Total
//            // 
//            this.Total.HeaderText = "Total";
//            this.Total.Name = "Total";
//            // 
//            // MetodoPago
//            // 
//            this.MetodoPago.HeaderText = "MetodoPago";
//            this.MetodoPago.Name = "MetodoPago";
//            // 
//            // EstadoDePago
//            // 
//            this.EstadoDePago.HeaderText = "EstadoDePago";
//            this.EstadoDePago.Name = "EstadoDePago";
//            // 
//            // EstadoDePedido
//            // 
//            this.EstadoDePedido.HeaderText = "EstadoDePedido";
//            this.EstadoDePedido.Name = "EstadoDePedido";
//            // 
//            // btnConsultarVenta
//            // 
//            this.btnConsultarVenta.Location = new System.Drawing.Point(266, 163);
//            this.btnConsultarVenta.Name = "btnConsultarVenta";
//            this.btnConsultarVenta.Size = new System.Drawing.Size(145, 25);
//            this.btnConsultarVenta.TabIndex = 7;
//            this.btnConsultarVenta.Text = "Consultar Venta";
//            this.btnConsultarVenta.UseVisualStyleBackColor = true;
//            this.btnConsultarVenta.Click += new System.EventHandler(this.btnConsultarVenta_Click);
//            // 
//            // labelId
//            // 
//            this.labelId.AutoSize = true;
//            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelId.Location = new System.Drawing.Point(216, 167);
//            this.labelId.Name = "labelId";
//            this.labelId.Size = new System.Drawing.Size(44, 16);
//            this.labelId.TabIndex = 6;
//            this.labelId.Text = "label3";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.Location = new System.Drawing.Point(16, 167);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(194, 16);
//            this.label2.TabIndex = 5;
//            this.label2.Text = "ID de Venta seleccionada: ";
//            // 
//            // btnEstadoPedido
//            // 
//            this.btnEstadoPedido.Location = new System.Drawing.Point(216, 112);
//            this.btnEstadoPedido.Name = "btnEstadoPedido";
//            this.btnEstadoPedido.Size = new System.Drawing.Size(195, 34);
//            this.btnEstadoPedido.TabIndex = 4;
//            this.btnEstadoPedido.Text = "Cambiar Estado Pedido";
//            this.btnEstadoPedido.UseVisualStyleBackColor = true;
//            this.btnEstadoPedido.Click += new System.EventHandler(this.btnEstadoPedido_Click);
//            // 
//            // btnEstadoPago
//            // 
//            this.btnEstadoPago.Location = new System.Drawing.Point(216, 71);
//            this.btnEstadoPago.Name = "btnEstadoPago";
//            this.btnEstadoPago.Size = new System.Drawing.Size(195, 35);
//            this.btnEstadoPago.TabIndex = 3;
//            this.btnEstadoPago.Text = "Cambiar Estado Pago";
//            this.btnEstadoPago.UseVisualStyleBackColor = true;
//            this.btnEstadoPago.Click += new System.EventHandler(this.btnEstadoPago_Click);
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(15, 17);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(150, 20);
//            this.label1.TabIndex = 2;
//            this.label1.Text = "Gestionar Ventas";
//            // 
//            // btnRegistrarVenta
//            // 
//            this.btnRegistrarVenta.Location = new System.Drawing.Point(15, 71);
//            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
//            this.btnRegistrarVenta.Size = new System.Drawing.Size(195, 75);
//            this.btnRegistrarVenta.TabIndex = 1;
//            this.btnRegistrarVenta.Text = "Registrar Venta";
//            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
//            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(417, 71);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(44, 13);
//            this.label5.TabIndex = 21;
//            this.label5.Text = "Desde: ";
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Location = new System.Drawing.Point(417, 97);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(38, 13);
//            this.label6.TabIndex = 22;
//            this.label6.Text = "Hasta:";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(16, 203);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(87, 13);
//            this.label3.TabIndex = 23;
//            this.label3.Text = "Filtrar por cliente:";
//            // 
//            // btnFiltroCliente
//            // 
//            this.btnFiltroCliente.Location = new System.Drawing.Point(263, 203);
//            this.btnFiltroCliente.Name = "btnFiltroCliente";
//            this.btnFiltroCliente.Size = new System.Drawing.Size(148, 23);
//            this.btnFiltroCliente.TabIndex = 25;
//            this.btnFiltroCliente.Text = "Filtrar";
//            this.btnFiltroCliente.UseVisualStyleBackColor = true;
//            this.btnFiltroCliente.Click += new System.EventHandler(this.btnFiltroCliente_Click);
//            // 
//            // btnDesfiltrar
//            // 
//            this.btnDesfiltrar.Location = new System.Drawing.Point(417, 203);
//            this.btnDesfiltrar.Name = "btnDesfiltrar";
//            this.btnDesfiltrar.Size = new System.Drawing.Size(166, 23);
//            this.btnDesfiltrar.TabIndex = 26;
//            this.btnDesfiltrar.Text = "Desfiltrar";
//            this.btnDesfiltrar.UseVisualStyleBackColor = true;
//            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);
//            // 
//            // cbClienteFiltro
//            // 
//            this.cbClienteFiltro.FormattingEnabled = true;
//            this.cbClienteFiltro.Location = new System.Drawing.Point(109, 203);
//            this.cbClienteFiltro.Name = "cbClienteFiltro";
//            this.cbClienteFiltro.Size = new System.Drawing.Size(148, 21);
//            this.cbClienteFiltro.TabIndex = 27;
//            // 
//            // UISalesManagement
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(707, 543);
//            this.Controls.Add(this.panel1);
//            this.Name = "UISalesManagement";
//            this.Text = "UISalesManagement";
//            this.Load += new System.EventHandler(this.UISalesManagement_Load);
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            this.panel2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasVentas)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.DataGridView dgvTodasLasVentas;
//        private System.Windows.Forms.Button btnRegistrarVenta;
//        private System.Windows.Forms.Label labelId;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Button btnEstadoPedido;
//        private System.Windows.Forms.Button btnEstadoPago;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Button btnConsultarVenta;
//        private System.Windows.Forms.Panel panel2;
//        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
//        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoPago;
//        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDePago;
//        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDePedido;
//        private System.Windows.Forms.Button btnFiltrarPorFecha;
//        private System.Windows.Forms.DateTimePicker dtpHasta;
//        private System.Windows.Forms.DateTimePicker dtpDesde;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Button btnFiltroCliente;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Button btnDesfiltrar;
//        private System.Windows.Forms.ComboBox cbClienteFiltro;
//    }
//}
namespace Login
{
    partial class UISalesManagement
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
            this.pnlAcciones.Size = new System.Drawing.Size(320, 200);
            this.pnlAcciones.Name = "pnlAcciones";
            //this.pnlAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.pnlAcciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Botón principal — ocupa todo el ancho del panel
            ConfigurarBotonPrimario(this.btnRegistrarVenta, "Registrar Venta",
                new System.Drawing.Point(16, 16), 0);
            this.btnRegistrarVenta.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);

            // Botones de estado — lado a lado
            ConfigurarBotonSecundario(this.btnEstadoPago, "Estado de Pago",
                new System.Drawing.Point(16, 72), 1);
            this.btnEstadoPago.Size = new System.Drawing.Size(138, 36);
            this.btnEstadoPago.Click += new System.EventHandler(this.btnEstadoPago_Click);

            ConfigurarBotonSecundario(this.btnEstadoPedido, "Estado de Pedido",
                new System.Drawing.Point(166, 72), 2);
            this.btnEstadoPedido.Size = new System.Drawing.Size(138, 36);
            this.btnEstadoPedido.Click += new System.EventHandler(this.btnEstadoPedido_Click);

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

            ConfigurarBotonSecundario(this.btnConsultarVenta, "Ver detalle",
                new System.Drawing.Point(16, 156), 3);
            this.btnConsultarVenta.Size = new System.Drawing.Size(138, 32);
            this.btnConsultarVenta.Click += new System.EventHandler(this.btnConsultarVenta_Click);

            ConfigurarBotonSecundario(this.btnExportarExcel, "Exportar Excel",
                new System.Drawing.Point(166, 156), 4);
            this.btnExportarExcel.Size = new System.Drawing.Size(138, 32);  // ancho completo, texto largo
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

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
            this.pnlFiltros.Size = new System.Drawing.Size(624, 200);
            this.pnlFiltros.Name = "pnlFiltros";
            //this.pnlFiltros.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Sección filtro por fecha
            ConfigurarLabel(this.lblDesde, "Desde",
                new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblHasta, "Hasta",
                new System.Drawing.Point(16, 68));

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

            ConfigurarBotonPrimario(this.btnFiltrarPorFecha, "Filtrar por fecha",
                new System.Drawing.Point(16, 145), 6);
            this.btnFiltrarPorFecha.Size = new System.Drawing.Size(180, 36);
            this.btnFiltrarPorFecha.Click += new System.EventHandler(this.btnFiltrarPorFecha_Click);

            // Separador vertical simulado con un panel de 1px
            var pnlSepVertical = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.FromArgb(211, 209, 199),
                Location = new System.Drawing.Point(226, 16),
                Size = new System.Drawing.Size(1, 168),
                Name = "pnlSepVertical"
            };

            // Sección filtro por cliente
            ConfigurarLabel(this.lblFiltroCliente, "Filtrar por cliente",
                new System.Drawing.Point(246, 16));

            this.cbClienteFiltro.Location = new System.Drawing.Point(246, 36);
            this.cbClienteFiltro.Size = new System.Drawing.Size(196, 28);
            this.cbClienteFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbClienteFiltro.FormattingEnabled = true;
            this.cbClienteFiltro.TabIndex = 7;
            this.cbClienteFiltro.Name = "cbClienteFiltro";

            ConfigurarBotonPrimario(this.btnFiltroCliente, "Filtrar",
                new System.Drawing.Point(246, 76), 8);
            this.btnFiltroCliente.Size = new System.Drawing.Size(120, 36);
            this.btnFiltroCliente.Click += new System.EventHandler(this.btnFiltroCliente_Click);

            ConfigurarBotonFantasma(this.btnDesfiltrar, "Quitar filtros",
                new System.Drawing.Point(246, 124), 9);
            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);

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
            this.dgvTodasLasVentas.Location = new System.Drawing.Point(20, 272);
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

        // ── HELPERS DE ESTILO ────────────────────────────────────
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(200, 18);
            lbl.AutoSize = false;
        }

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(140, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(140, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
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
            btn.Name = texto.ToLower();
        }

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var panel = sender as System.Windows.Forms.Panel;
            var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(211, 209, 199), 1f);
            var rect = new System.Drawing.Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            int r = 8;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            e.Graphics.DrawPath(pen, path);
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
    }
}
namespace Login
{
    partial class UIJornadaLaboral
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
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTandasTitulo = new System.Windows.Forms.Label();
            this.dgvTandas = new System.Windows.Forms.DataGridView();
            this.IdTanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCaducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInsumosTitulo = new System.Windows.Forms.Label();
            this.dgvInsumos = new System.Windows.Forms.DataGridView();
            this.Insumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblTandasKey = new System.Windows.Forms.Label();
            this.lblTandasValor = new System.Windows.Forms.Label();
            this.lblProductosKey = new System.Windows.Forms.Label();
            this.lblProductosValor = new System.Windows.Forms.Label();
            this.lblEmpleadoKey = new System.Windows.Forms.Label();
            this.txtEmpleadoACargo = new System.Windows.Forms.TextBox();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnGenerarPdf = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTandas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Text = "Informe diario de producción";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIJornadaLaboral_Load);

            // Título
            this.lblTitulo.Text = "Informe diario de producción";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(500, 32);

            // Filtro
            this.lblFecha.Text = "Fecha de jornada";
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.Location = new System.Drawing.Point(20, 62);
            this.lblFecha.Size = new System.Drawing.Size(180, 18);

            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(20, 82);
            this.dtpFecha.Size = new System.Drawing.Size(180, 28);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);

            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Location = new System.Drawing.Point(220, 78);
            this.btnFiltrar.Size = new System.Drawing.Size(120, 34);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            this.lblMensaje.Text = "";
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMensaje.Location = new System.Drawing.Point(360, 78);
            this.lblMensaje.Size = new System.Drawing.Size(640, 54);

            // Grilla de tandas
            this.lblTandasTitulo.Text = "Tandas terminadas";
            this.lblTandasTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTandasTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTandasTitulo.Location = new System.Drawing.Point(20, 145);
            this.lblTandasTitulo.Size = new System.Drawing.Size(300, 22);

            this.dgvTandas.Location = new System.Drawing.Point(20, 170);
            this.dgvTandas.Size = new System.Drawing.Size(680, 210);
            this.dgvTandas.ReadOnly = true;
            this.dgvTandas.AllowUserToAddRows = false;
            this.dgvTandas.RowHeadersVisible = false;
            this.dgvTandas.RowTemplate.Height = 32;
            this.dgvTandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTandas.MultiSelect = false;
            this.dgvTandas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTandas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTandas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTandas.SelectionChanged += new System.EventHandler(this.dgvTandas_SelectionChanged);

            this.IdTanda.HeaderText = "ID";
            this.IdTanda.Name = "IdTanda";
            this.IdTanda.FillWeight = 10;

            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.FillWeight = 15;

            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.FillWeight = 40;

            this.Cantidad.HeaderText = "Cantidad producida";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.FillWeight = 20;

            this.FechaCaducidad.HeaderText = "Caducidad";
            this.FechaCaducidad.Name = "FechaCaducidad";
            this.FechaCaducidad.FillWeight = 15;

            this.dgvTandas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.IdTanda, this.Hora, this.Producto, this.Cantidad, this.FechaCaducidad
            });

            // Grilla de insumos
            this.lblInsumosTitulo.Text = "Insumos consumidos en la jornada";
            this.lblInsumosTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblInsumosTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInsumosTitulo.Location = new System.Drawing.Point(20, 395);
            this.lblInsumosTitulo.Size = new System.Drawing.Size(400, 22);

            this.dgvInsumos.Location = new System.Drawing.Point(20, 420);
            this.dgvInsumos.Size = new System.Drawing.Size(680, 210);
            this.dgvInsumos.ReadOnly = true;
            this.dgvInsumos.AllowUserToAddRows = false;
            this.dgvInsumos.RowHeadersVisible = false;
            this.dgvInsumos.RowTemplate.Height = 32;
            this.dgvInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumos.MultiSelect = false;
            this.dgvInsumos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInsumos.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.Insumo.HeaderText = "Insumo";
            this.Insumo.Name = "Insumo";
            this.Insumo.FillWeight = 50;

            this.Unidad.HeaderText = "Unidad de medida";
            this.Unidad.Name = "Unidad";
            this.Unidad.FillWeight = 25;

            this.CantidadTotal.HeaderText = "Cantidad total";
            this.CantidadTotal.Name = "CantidadTotal";
            this.CantidadTotal.FillWeight = 25;

            this.dgvInsumos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Insumo, this.Unidad, this.CantidadTotal
            });

            // Panel de resumen
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Location = new System.Drawing.Point(720, 145);
            this.pnlResumen.Size = new System.Drawing.Size(300, 485);

            this.lblTandasKey.Text = "Tandas:";
            this.lblTandasKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTandasKey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTandasKey.Location = new System.Drawing.Point(16, 20);
            this.lblTandasKey.Size = new System.Drawing.Size(180, 18);

            this.lblTandasValor.Text = "0";
            this.lblTandasValor.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTandasValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTandasValor.Location = new System.Drawing.Point(16, 40);
            this.lblTandasValor.Size = new System.Drawing.Size(120, 30);

            this.lblProductosKey.Text = "Productos fabricados:";
            this.lblProductosKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblProductosKey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductosKey.Location = new System.Drawing.Point(16, 84);
            this.lblProductosKey.Size = new System.Drawing.Size(200, 18);

            this.lblProductosValor.Text = "0";
            this.lblProductosValor.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblProductosValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProductosValor.Location = new System.Drawing.Point(16, 104);
            this.lblProductosValor.Size = new System.Drawing.Size(120, 30);

            this.lblEmpleadoKey.Text = "Empleado a cargo";
            this.lblEmpleadoKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblEmpleadoKey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmpleadoKey.Location = new System.Drawing.Point(16, 150);
            this.lblEmpleadoKey.Size = new System.Drawing.Size(268, 18);

            this.txtEmpleadoACargo.Location = new System.Drawing.Point(16, 170);
            this.txtEmpleadoACargo.Size = new System.Drawing.Size(268, 28);
            this.txtEmpleadoACargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnVerDetalle.Text = "Ver detalle";
            this.btnVerDetalle.Location = new System.Drawing.Point(16, 230);
            this.btnVerDetalle.Size = new System.Drawing.Size(268, 36);
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);

            this.btnGenerarPdf.Text = "Generar PDF";
            this.btnGenerarPdf.Location = new System.Drawing.Point(16, 276);
            this.btnGenerarPdf.Size = new System.Drawing.Size(268, 36);
            this.btnGenerarPdf.Click += new System.EventHandler(this.btnGenerarPdf_Click);

            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new System.Drawing.Point(16, 322);
            this.btnCerrar.Size = new System.Drawing.Size(268, 36);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.pnlResumen.Controls.Add(this.lblTandasKey);
            this.pnlResumen.Controls.Add(this.lblTandasValor);
            this.pnlResumen.Controls.Add(this.lblProductosKey);
            this.pnlResumen.Controls.Add(this.lblProductosValor);
            this.pnlResumen.Controls.Add(this.lblEmpleadoKey);
            this.pnlResumen.Controls.Add(this.txtEmpleadoACargo);
            this.pnlResumen.Controls.Add(this.btnVerDetalle);
            this.pnlResumen.Controls.Add(this.btnGenerarPdf);
            this.pnlResumen.Controls.Add(this.btnCerrar);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblTandasTitulo);
            this.Controls.Add(this.dgvTandas);
            this.Controls.Add(this.lblInsumosTitulo);
            this.Controls.Add(this.dgvInsumos);
            this.Controls.Add(this.pnlResumen);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTandas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTandasTitulo;
        private System.Windows.Forms.DataGridView dgvTandas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCaducidad;
        private System.Windows.Forms.Label lblInsumosTitulo;
        private System.Windows.Forms.DataGridView dgvInsumos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadTotal;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblTandasKey;
        private System.Windows.Forms.Label lblTandasValor;
        private System.Windows.Forms.Label lblProductosKey;
        private System.Windows.Forms.Label lblProductosValor;
        private System.Windows.Forms.Label lblEmpleadoKey;
        private System.Windows.Forms.TextBox txtEmpleadoACargo;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnGenerarPdf;
        private System.Windows.Forms.Button btnCerrar;
    }
}

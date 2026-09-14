namespace Login
{
    partial class UIConsultarTanda
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
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblIdLabel = new System.Windows.Forms.Label();
            this.lblValorId = new System.Windows.Forms.Label();
            this.lblProductoLabel = new System.Windows.Forms.Label();
            this.lblValorProducto = new System.Windows.Forms.Label();
            this.lblFechaLabel = new System.Windows.Forms.Label();
            this.lblValorFecha = new System.Windows.Forms.Label();
            this.lblHoraLabel = new System.Windows.Forms.Label();
            this.lblValorHora = new System.Windows.Forms.Label();
            this.lblEstadoLabel = new System.Windows.Forms.Label();
            this.lblValorEstado = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvDetallesTanda = new System.Windows.Forms.DataGridView();
            this.IdDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Insumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalCantidad = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.pnlCabecera.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesTanda)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(650, 600);
            this.Text = "Detalle de Tanda de Producción";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIEstadoTanda_Load);

            // Titulo
            this.lblTitulo.Text = "Información de la Tanda";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 30);

            // Panel Cabecera
            this.pnlCabecera.BackColor = System.Drawing.Color.White;
            this.pnlCabecera.Location = new System.Drawing.Point(20, 52);
            this.pnlCabecera.Size = new System.Drawing.Size(610, 110);

            ConfigurarLabelHeader(this.lblIdLabel, "ID Tanda:", new System.Drawing.Point(16, 12));
            ConfigurarLabelHeaderValor(this.lblValorId, "-", new System.Drawing.Point(90, 12));

            ConfigurarLabelHeader(this.lblProductoLabel, "Producto:", new System.Drawing.Point(16, 40));
            ConfigurarLabelHeaderValor(this.lblValorProducto, "-", new System.Drawing.Point(90, 40));

            ConfigurarLabelHeader(this.lblEstadoLabel, "Estado:", new System.Drawing.Point(16, 70));
            ConfigurarLabelHeaderValor(this.lblValorEstado, "-", new System.Drawing.Point(90, 70));

            ConfigurarLabelHeader(this.lblFechaLabel, "Fecha:", new System.Drawing.Point(340, 12));
            ConfigurarLabelHeaderValor(this.lblValorFecha, "-", new System.Drawing.Point(400, 12));

            ConfigurarLabelHeader(this.lblHoraLabel, "Hora:", new System.Drawing.Point(340, 40));
            ConfigurarLabelHeaderValor(this.lblValorHora, "-", new System.Drawing.Point(400, 40));

            this.pnlCabecera.Controls.Add(this.lblIdLabel);
            this.pnlCabecera.Controls.Add(this.lblValorId);
            this.pnlCabecera.Controls.Add(this.lblProductoLabel);
            this.pnlCabecera.Controls.Add(this.lblValorProducto);
            this.pnlCabecera.Controls.Add(this.lblEstadoLabel);
            this.pnlCabecera.Controls.Add(this.lblValorEstado);
            this.pnlCabecera.Controls.Add(this.lblFechaLabel);
            this.pnlCabecera.Controls.Add(this.lblValorFecha);
            this.pnlCabecera.Controls.Add(this.lblHoraLabel);
            this.pnlCabecera.Controls.Add(this.lblValorHora);

            // Subtítulo Grilla
            this.lblDetalles.Text = "Insumos y Personal Utilizado";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 175);
            this.lblDetalles.Size = new System.Drawing.Size(300, 24);

            // DataGridView
            this.dgvDetallesTanda.Location = new System.Drawing.Point(20, 202);
            this.dgvDetallesTanda.Size = new System.Drawing.Size(610, 240);
            this.dgvDetallesTanda.ReadOnly = true;
            this.dgvDetallesTanda.RowTemplate.Height = 30;
            this.dgvDetallesTanda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesTanda.RowHeadersVisible = false;
            this.dgvDetallesTanda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetallesTanda.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetallesTanda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.IdDetalle.HeaderText = "ID";
            this.IdDetalle.Name = "IdDetalle";
            this.IdDetalle.FillWeight = 30;

            this.Insumo.HeaderText = "Insumo";
            this.Insumo.Name = "Insumo";
            this.Insumo.FillWeight = 80;

            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Empleado.FillWeight = 90;

            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.FillWeight = 70;

            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.FillWeight = 50;

            this.dgvDetallesTanda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.IdDetalle, this.Insumo, this.Empleado, this.Cargo, this.Cantidad
            });

            // Panel Resumen Total
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 452);
            this.pnlTotal.Size = new System.Drawing.Size(610, 60);

            this.lblTotalLabel.Text = "TOTAL UNIDADES PRODUCIDAS:";
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 20);
            this.lblTotalLabel.Size = new System.Drawing.Size(220, 20);

            this.lblTotalCantidad.Text = "0";
            this.lblTotalCantidad.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCantidad.Location = new System.Drawing.Point(240, 14);
            this.lblTotalCantidad.Size = new System.Drawing.Size(200, 30);

            this.pnlTotal.Controls.Add(this.lblTotalLabel);
            this.pnlTotal.Controls.Add(this.lblTotalCantidad);

            // Botón Cerrar
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new System.Drawing.Point(490, 526);
            this.btnCerrar.Size = new System.Drawing.Size(140, 38);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 1;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlCabecera);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvDetallesTanda);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.btnCerrar);

            this.pnlCabecera.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesTanda)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarLabelHeader(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(70, 20);
        }

        private void ConfigurarLabelHeaderValor(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(230, 20);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblIdLabel;
        private System.Windows.Forms.Label lblValorId;
        private System.Windows.Forms.Label lblProductoLabel;
        private System.Windows.Forms.Label lblValorProducto;
        private System.Windows.Forms.Label lblFechaLabel;
        private System.Windows.Forms.Label lblValorFecha;
        private System.Windows.Forms.Label lblHoraLabel;
        private System.Windows.Forms.Label lblValorHora;
        private System.Windows.Forms.Label lblEstadoLabel;
        private System.Windows.Forms.Label lblValorEstado;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvDetallesTanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalCantidad;
        private System.Windows.Forms.Button btnCerrar;
    }
}
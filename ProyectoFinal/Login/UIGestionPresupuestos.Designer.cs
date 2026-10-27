namespace Login
{
    partial class UIGestionPresupuestos
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
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnRegistrarSolicitud = new System.Windows.Forms.Button();
            this.btnRegistrarPresupuesto = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.lblIdPresupuestoLabel = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.btnPresupuestosEliminados = new System.Windows.Forms.Button();
            this.lblFiltroProveedor = new System.Windows.Forms.Label();
            this.cbProveedorFiltro = new System.Windows.Forms.ComboBox();
            this.lblNumeroCotizacion = new System.Windows.Forms.Label();
            this.txtNumeroCotizacion = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnDesfiltrar = new System.Windows.Forms.Button();
            this.dgvPresupuestos = new System.Windows.Forms.DataGridView();
            this.colIdPresupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlAcciones.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Text = "Gestión de Presupuestos";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIGestionPresupuestos";
            this.Load += new System.EventHandler(this.UIGestionPresupuestos_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Gestión de Presupuestos";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(500, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL ACCIONES ──────────────────────────────────────
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Location = new System.Drawing.Point(20, 56);
            this.pnlAcciones.Size = new System.Drawing.Size(320, 300);
            this.pnlAcciones.Name = "pnlAcciones";

            this.lblIdPresupuestoLabel.Text = "Presupuesto:";
            this.lblIdPresupuestoLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblIdPresupuestoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdPresupuestoLabel.Location = new System.Drawing.Point(166, 220);
            this.lblIdPresupuestoLabel.Size = new System.Drawing.Size(138, 18);
            this.lblIdPresupuestoLabel.Name = "lblIdPresupuestoLabel";

            this.labelId.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(166, 240);
            this.labelId.Size = new System.Drawing.Size(138, 20);
            this.labelId.Name = "labelId";

            this.pnlAcciones.Controls.Add(this.btnRegistrarSolicitud);
            this.pnlAcciones.Controls.Add(this.btnRegistrarPresupuesto);
            this.pnlAcciones.Controls.Add(this.btnVerDetalle);
            this.pnlAcciones.Controls.Add(this.btnModificar);
            this.pnlAcciones.Controls.Add(this.btnEliminar);
            this.pnlAcciones.Controls.Add(this.btnAceptar);
            this.pnlAcciones.Controls.Add(this.btnRechazar);
            this.pnlAcciones.Controls.Add(this.lblIdPresupuestoLabel);
            this.pnlAcciones.Controls.Add(this.labelId);
            this.pnlAcciones.Controls.Add(this.btnPresupuestosEliminados);

            // ── PANEL FILTROS ───────────────────────────────────────
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Location = new System.Drawing.Point(356, 56);
            this.pnlFiltros.Size = new System.Drawing.Size(624, 140);
            this.pnlFiltros.Name = "pnlFiltros";

            this.pnlFiltros.Controls.Add(this.lblFiltroProveedor);
            this.pnlFiltros.Controls.Add(this.cbProveedorFiltro);
            this.pnlFiltros.Controls.Add(this.lblNumeroCotizacion);
            this.pnlFiltros.Controls.Add(this.txtNumeroCotizacion);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.btnDesfiltrar);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvPresupuestos.Location = new System.Drawing.Point(20, 372);
            this.dgvPresupuestos.Size = new System.Drawing.Size(960, 292);
            this.dgvPresupuestos.Name = "dgvPresupuestos";
            this.dgvPresupuestos.TabIndex = 11;
            this.dgvPresupuestos.AllowUserToAddRows = false;
            this.dgvPresupuestos.AllowUserToDeleteRows = false;
            this.dgvPresupuestos.ReadOnly = true;
            this.dgvPresupuestos.RowTemplate.Height = 35;
            this.dgvPresupuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresupuestos.RowHeadersVisible = false;
            this.dgvPresupuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresupuestos.AutoGenerateColumns = false;
            this.dgvPresupuestos.SelectionChanged += new System.EventHandler(this.dgvPresupuestos_SelectionChanged);

            this.colIdPresupuesto.HeaderText = "N° Presupuesto";
            this.colIdPresupuesto.Name = "IdPresupuesto";
            this.colIdPresupuesto.FillWeight = 60;

            this.colIdSolicitud.HeaderText = "N° Cotización";
            this.colIdSolicitud.Name = "IdSolicitud";
            this.colIdSolicitud.FillWeight = 60;

            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "Proveedor";
            this.colProveedor.FillWeight = 90;

            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "Fecha";
            this.colFecha.FillWeight = 60;
            this.colFecha.ValueType = typeof(System.DateTime);
            this.colFecha.DefaultCellStyle.Format = "dd-MM-yyyy";

            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "Total";
            this.colTotal.FillWeight = 70;
            this.colTotal.ValueType = typeof(decimal);
            this.colTotal.DefaultCellStyle.Format = "$#,##0.00";
            this.colTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.FillWeight = 70;

            this.dgvPresupuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colIdPresupuesto, this.colIdSolicitud, this.colProveedor,
                this.colFecha, this.colTotal, this.colEstado
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.dgvPresupuestos);

            this.pnlAcciones.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnRegistrarSolicitud;
        private System.Windows.Forms.Button btnRegistrarPresupuesto;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Label lblIdPresupuestoLabel;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnPresupuestosEliminados;
        private System.Windows.Forms.Label lblFiltroProveedor;
        private System.Windows.Forms.ComboBox cbProveedorFiltro;
        private System.Windows.Forms.Label lblNumeroCotizacion;
        private System.Windows.Forms.TextBox txtNumeroCotizacion;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnDesfiltrar;
        private System.Windows.Forms.DataGridView dgvPresupuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPresupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}

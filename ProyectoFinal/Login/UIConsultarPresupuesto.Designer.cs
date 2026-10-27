namespace Login
{
    partial class UIConsultarPresupuesto
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblCotizacionKey = new System.Windows.Forms.Label();
            this.labelCotizacion = new System.Windows.Forms.Label();
            this.lblProveedorKey = new System.Windows.Forms.Label();
            this.labelProveedor = new System.Windows.Forms.Label();
            this.lblFechaKey = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.lblEstadoKey = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.lblTotalKey = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(520, 520);
            this.Text = "Consultar Presupuesto";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIConsultarPresupuesto";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIConsultarPresupuesto_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Consultar Presupuesto";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(480, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL INFO ──────────────────────────────────────────
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(20, 56);
            this.pnlInfo.Size = new System.Drawing.Size(480, 148);
            this.pnlInfo.Name = "pnlInfo";

            this.pnlInfo.Controls.Add(this.lblCotizacionKey);
            this.pnlInfo.Controls.Add(this.labelCotizacion);
            this.pnlInfo.Controls.Add(this.lblProveedorKey);
            this.pnlInfo.Controls.Add(this.labelProveedor);
            this.pnlInfo.Controls.Add(this.lblFechaKey);
            this.pnlInfo.Controls.Add(this.labelFecha);
            this.pnlInfo.Controls.Add(this.lblEstadoKey);
            this.pnlInfo.Controls.Add(this.labelEstado);
            this.pnlInfo.Controls.Add(this.lblTotalKey);
            this.pnlInfo.Controls.Add(this.labelTotal);

            // ── LABEL DETALLES ──────────────────────────────────────
            this.lblDetalles.Text = "Insumos";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Size = new System.Drawing.Size(300, 24);
            this.lblDetalles.Name = "lblDetalles";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvDetalle.Location = new System.Drawing.Point(20, 248);
            this.dgvDetalle.Size = new System.Drawing.Size(480, 200);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowTemplate.Height = 30;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.AutoGenerateColumns = false;

            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "Insumo";
            this.colInsumo.FillWeight = 40;

            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.Name = "Unidad";
            this.colUnidad.FillWeight = 15;

            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "Cantidad";
            this.colCantidad.FillWeight = 15;
            this.colCantidad.DefaultCellStyle.Format = "N2";
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "Precio";
            this.colPrecio.FillWeight = 15;
            this.colPrecio.DefaultCellStyle.Format = "$#,##0.00";
            this.colPrecio.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "Subtotal";
            this.colSubtotal.FillWeight = 15;
            this.colSubtotal.DefaultCellStyle.Format = "$#,##0.00";
            this.colSubtotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colInsumo, this.colUnidad, this.colCantidad, this.colPrecio, this.colSubtotal
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnCerrar);

            this.pnlInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblCotizacionKey;
        private System.Windows.Forms.Label labelCotizacion;
        private System.Windows.Forms.Label lblProveedorKey;
        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.Label lblFechaKey;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label lblEstadoKey;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label lblTotalKey;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Button btnCerrar;
    }
}

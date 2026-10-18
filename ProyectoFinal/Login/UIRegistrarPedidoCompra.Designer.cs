namespace Login
{
    partial class UIRegistrarPedidoCompra
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
            this.lblPresupuesto = new System.Windows.Forms.Label();
            this.cbPresupuesto = new System.Windows.Forms.ComboBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalKey = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnAgregarInsumo = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(700, 560);
            this.Text = "Pedido de Compra";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegistrarPedidoCompra";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegistrarPedidoCompra_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Pedido de Compra";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(660, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PRESUPUESTO ─────────────────────────────────────────
            this.cbPresupuesto.FormattingEnabled = true;
            this.cbPresupuesto.Name = "cbPresupuesto";
            this.cbPresupuesto.SelectedIndexChanged += new System.EventHandler(this.cbPresupuesto_SelectedIndexChanged);
            this.cbPresupuesto.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbPresupuesto_Format);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvDetalle.Location = new System.Drawing.Point(20, 148);
            this.dgvDetalle.Size = new System.Drawing.Size(660, 290);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.TabIndex = 5;
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.RowTemplate.Height = 32;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetalle_CellValidating);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            this.dgvDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalle_DataError);

            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "Insumo";
            this.colInsumo.FillWeight = 40;
            this.colInsumo.ReadOnly = true;

            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.Name = "Unidad";
            this.colUnidad.FillWeight = 14;
            this.colUnidad.ReadOnly = true;

            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "Cantidad";
            this.colCantidad.FillWeight = 16;
            this.colCantidad.ReadOnly = false;
            this.colCantidad.ValueType = typeof(decimal);
            this.colCantidad.DefaultCellStyle.Format = "N2";
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colPrecioUnitario.HeaderText = "Precio unitario";
            this.colPrecioUnitario.Name = "PrecioUnitario";
            this.colPrecioUnitario.FillWeight = 15;
            this.colPrecioUnitario.ReadOnly = true;
            this.colPrecioUnitario.ValueType = typeof(decimal);
            this.colPrecioUnitario.DefaultCellStyle.Format = "C2";
            this.colPrecioUnitario.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "Subtotal";
            this.colSubtotal.FillWeight = 15;
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.ValueType = typeof(decimal);
            this.colSubtotal.DefaultCellStyle.Format = "C2";
            this.colSubtotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colInsumo, this.colUnidad, this.colCantidad, this.colPrecioUnitario, this.colSubtotal
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblPresupuesto);
            this.Controls.Add(this.cbPresupuesto);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblTotalKey);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.btnAgregarInsumo);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPresupuesto;
        private System.Windows.Forms.ComboBox cbPresupuesto;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label lblTotalKey;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnAgregarInsumo;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

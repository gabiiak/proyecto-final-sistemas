namespace Login
{
    partial class UIGestionPedidosCompra
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
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEmitirPedido = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.btnRegistrarManual = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Text = "Pedidos de Compra";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIGestionPedidosCompra";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIGestionPedidosCompra_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Pedidos de Compra";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(860, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvPedidos.Location = new System.Drawing.Point(20, 60);
            this.dgvPedidos.Size = new System.Drawing.Size(860, 400);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.TabIndex = 7;
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowTemplate.Height = 35;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.AutoGenerateColumns = false;
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            this.dgvPedidos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPedidos_CellFormatting);

            this.colNumero.HeaderText = "N°";
            this.colNumero.Name = "Numero";
            this.colNumero.FillWeight = 8;

            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "Proveedor";
            this.colProveedor.FillWeight = 32;

            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "Fecha";
            this.colFecha.FillWeight = 15;
            this.colFecha.ValueType = typeof(System.DateTime);
            this.colFecha.DefaultCellStyle.Format = "dd-MM-yyyy";

            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "Total";
            this.colTotal.FillWeight = 20;
            this.colTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.FillWeight = 15;

            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colNumero, this.colProveedor, this.colFecha, this.colTotal, this.colEstado
            });

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnEmitirPedido);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnVerPdf);
            this.Controls.Add(this.btnRegistrarManual);
            this.Controls.Add(this.btnCerrar);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Button btnEmitirPedido;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnVerPdf;
        private System.Windows.Forms.Button btnRegistrarManual;
        private System.Windows.Forms.Button btnCerrar;
    }
}

namespace Login
{
    partial class UIConsultarVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblClienteKey = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.lblMetodoKey = new System.Windows.Forms.Label();
            this.labelMetodo = new System.Windows.Forms.Label();
            this.lblFechaKey = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.lblEstadoPagoKey = new System.Windows.Forms.Label();
            this.labelEstadoPago = new System.Windows.Forms.Label();
            this.lblEstadoPedidoKey = new System.Windows.Forms.Label();
            this.labelEstadoPedido = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvConsultaVenta = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalKey = new System.Windows.Forms.Label();
            this.lblTotalSimbolo = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnEmitirFactura = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            this.pnlInfo.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVenta)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(480, 590);
            this.Text = "Consultar Venta";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIConsultSale";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIConsultSale_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Consultar Venta";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(440, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL INFO ──────────────────────────────────────────
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(20, 56);
            this.pnlInfo.Size = new System.Drawing.Size(440, 148);
            this.pnlInfo.Name = "pnlInfo";
            //this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Fila de datos: label clave (gris) + label valor (azul oscuro)
            // Columna izquierda
            
            this.pnlInfo.Controls.Add(this.lblClienteKey);
            this.pnlInfo.Controls.Add(this.labelCliente);
            this.pnlInfo.Controls.Add(this.lblFechaKey);
            this.pnlInfo.Controls.Add(this.labelFecha);
            this.pnlInfo.Controls.Add(this.lblEstadoPagoKey);
            this.pnlInfo.Controls.Add(this.labelEstadoPago);
            this.pnlInfo.Controls.Add(this.lblEstadoPedidoKey);
            this.pnlInfo.Controls.Add(this.labelEstadoPedido);
            this.pnlInfo.Controls.Add(this.lblMetodoKey);
            this.pnlInfo.Controls.Add(this.labelMetodo);

            // ── LABEL DETALLES ──────────────────────────────────────
            this.lblDetalles.Text = "Productos";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Size = new System.Drawing.Size(200, 24);
            this.lblDetalles.Name = "lblDetalles";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvConsultaVenta.Location = new System.Drawing.Point(20, 248);
            this.dgvConsultaVenta.Size = new System.Drawing.Size(440, 196);
            this.dgvConsultaVenta.Name = "dgvConsultaVenta";
            this.dgvConsultaVenta.TabIndex = 0;
            this.dgvConsultaVenta.AllowUserToAddRows = false;
            this.dgvConsultaVenta.AllowUserToDeleteRows = false;
            this.dgvConsultaVenta.ReadOnly = true;
            this.dgvConsultaVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaVenta.RowHeadersVisible = false;
            this.dgvConsultaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsultaVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsultaVenta.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvConsultaVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultaVenta.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvConsultaVenta.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvConsultaVenta.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvConsultaVenta.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvConsultaVenta.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvConsultaVenta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvConsultaVenta.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvConsultaVenta.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvConsultaVenta.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.Nombre.HeaderText = "Producto";
            this.Nombre.Name = "Nombre";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.SubTotal.HeaderText = "Subtotal";
            this.SubTotal.Name = "SubTotal";

            this.dgvConsultaVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.Nombre, this.Cantidad, this.SubTotal
            });

            // ── PANEL TOTAL ─────────────────────────────────────────
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 456);
            this.pnlTotal.Size = new System.Drawing.Size(440, 56);
            this.pnlTotal.Name = "pnlTotal";
            //this.pnlTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            this.lblTotalKey.Text = "TOTAL";
            this.lblTotalKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalKey.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalKey.Location = new System.Drawing.Point(16, 8);
            this.lblTotalKey.Size = new System.Drawing.Size(60, 16);
            this.lblTotalKey.Name = "lblTotalKey";

            //this.lblTotalSimbolo.Text = "$";
            this.lblTotalSimbolo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTotalSimbolo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalSimbolo.Location = new System.Drawing.Point(16, 24);
            this.lblTotalSimbolo.Size = new System.Drawing.Size(0, 0);
            this.lblTotalSimbolo.Name = "lblTotalSimbolo";

            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(20, 24);
            this.labelTotal.Size = new System.Drawing.Size(200, 26);
            this.labelTotal.Name = "labelTotal";

            this.pnlTotal.Controls.Add(this.lblTotalKey);
            this.pnlTotal.Controls.Add(this.lblTotalSimbolo);
            this.pnlTotal.Controls.Add(this.labelTotal);

            // ── BOTONES ─────────────────────────────────────────────
            

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvConsultaVenta);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.btnEmitirFactura);
            this.Controls.Add(this.btnSalir);

            this.pnlInfo.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVenta)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblClienteKey;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label lblMetodoKey;
        private System.Windows.Forms.Label labelMetodo;
        private System.Windows.Forms.Label lblFechaKey;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label lblEstadoPagoKey;
        private System.Windows.Forms.Label labelEstadoPago;
        private System.Windows.Forms.Label lblEstadoPedidoKey;
        private System.Windows.Forms.Label labelEstadoPedido;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvConsultaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label lblTotalKey;
        private System.Windows.Forms.Label lblTotalSimbolo;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnEmitirFactura;
        private System.Windows.Forms.Button btnSalir;
    }
}
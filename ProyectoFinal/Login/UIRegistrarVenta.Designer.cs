namespace Login
{
    partial class UIRegistrarVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.cbMetodo = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvVenta_DetalleVenta = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.btnQuitarDetalle = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalSimbolo = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.lblPagoRecibido = new System.Windows.Forms.Label();
            this.txtPagoRecibido = new System.Windows.Forms.TextBox();
            this.btnPagoJusto = new System.Windows.Forms.Button();
            this.lblEstadoHint = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(520, 680);
            this.Text = "Registrar Venta";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegisterSale";
            this.Load += new System.EventHandler(this.UIRegisterSale_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Registrar Venta";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL FORMULARIO ────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 56);
            this.pnlFormulario.Size = new System.Drawing.Size(480, 148);
            this.pnlFormulario.Name = "pnlFormulario";
            //this.pnlFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Fila 1: Cliente + Método de pago
            

            this.pnlFormulario.Controls.Add(this.lblCliente);
            this.pnlFormulario.Controls.Add(this.cbCliente);
            this.pnlFormulario.Controls.Add(this.lblMetodo);
            this.pnlFormulario.Controls.Add(this.cbMetodo);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.txtFecha);

            // ── LABEL DETALLES ──────────────────────────────────────
            this.lblDetalles.Text = "Detalle de la venta";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Size = new System.Drawing.Size(300, 24);
            this.lblDetalles.Name = "lblDetalles";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvVenta_DetalleVenta.Location = new System.Drawing.Point(20, 248);
            this.dgvVenta_DetalleVenta.Size = new System.Drawing.Size(480, 200);
            this.dgvVenta_DetalleVenta.Name = "dgvVenta_DetalleVenta";
            this.dgvVenta_DetalleVenta.TabIndex = 3;
            this.dgvVenta_DetalleVenta.AllowUserToAddRows = false;
            this.dgvVenta_DetalleVenta.AllowUserToDeleteRows = false;
            this.dgvVenta_DetalleVenta.ReadOnly = true;
            this.dgvVenta_DetalleVenta.RowTemplate.Height = 35;
            this.dgvVenta_DetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenta_DetalleVenta.RowHeadersVisible = false;
            this.dgvVenta_DetalleVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVenta_DetalleVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvVenta_DetalleVenta.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvVenta_DetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVenta_DetalleVenta.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvVenta_DetalleVenta.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvVenta_DetalleVenta.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvVenta_DetalleVenta.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvVenta_DetalleVenta.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvVenta_DetalleVenta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvVenta_DetalleVenta.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvVenta_DetalleVenta.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvVenta_DetalleVenta.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.SubTotal.HeaderText = "Subtotal";
            this.SubTotal.Name = "SubTotal";

            this.dgvVenta_DetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.Producto, this.Cantidad, this.SubTotal
            });

            // ── BOTONES DETALLE ─────────────────────────────────────
            

            // ── PANEL TOTAL ─────────────────────────────────────────
            // Zona de resumen: total + pago recibido
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 512);
            this.pnlTotal.Size = new System.Drawing.Size(480, 80);
            this.pnlTotal.Name = "pnlTotal";
            //this.pnlTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            this.lblTotalLabel.Text = "TOTAL";
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 10);
            this.lblTotalLabel.Size = new System.Drawing.Size(60, 16);
            this.lblTotalLabel.Name = "lblTotalLabel";

            this.lblTotalSimbolo.Text = "$";
            this.lblTotalSimbolo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTotalSimbolo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalSimbolo.Location = new System.Drawing.Point(16, 28);
            this.lblTotalSimbolo.Size = new System.Drawing.Size(24, 32);
            this.lblTotalSimbolo.Name = "lblTotalSimbolo";

            this.labelTotal.Text = "0,00";
            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(44, 28);
            this.labelTotal.Size = new System.Drawing.Size(160, 32);
            this.labelTotal.Name = "labelTotal";

            // Pago recibido — lado derecho del panel total
            

            this.pnlTotal.Controls.Add(this.lblTotalLabel);
            this.pnlTotal.Controls.Add(this.lblTotalSimbolo);
            this.pnlTotal.Controls.Add(this.labelTotal);
            this.pnlTotal.Controls.Add(this.lblPagoRecibido);
            this.pnlTotal.Controls.Add(this.txtPagoRecibido);
            this.pnlTotal.Controls.Add(this.btnPagoJusto);

            // ── HINT DE ESTADOS ─────────────────────────────────────
            this.lblEstadoHint.Text = "≤ 0 o sin pago → PENDIENTE   |   pago justo → PAGADO";
            this.lblEstadoHint.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblEstadoHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblEstadoHint.Location = new System.Drawing.Point(20, 600);
            this.lblEstadoHint.Size = new System.Drawing.Size(480, 18);
            this.lblEstadoHint.Name = "lblEstadoHint";

            // ── BOTÓN REGISTRAR ─────────────────────────────────────
            

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvVenta_DetalleVenta);
            this.Controls.Add(this.btnAgregarDetalle);
            this.Controls.Add(this.btnQuitarDetalle);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.lblEstadoHint);
            this.Controls.Add(this.btnRegistrarVenta);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.ComboBox cbMetodo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvVenta_DetalleVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Button btnQuitarDetalle;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalSimbolo;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label lblPagoRecibido;
        private System.Windows.Forms.TextBox txtPagoRecibido;
        private System.Windows.Forms.Button btnPagoJusto;
        private System.Windows.Forms.Label lblEstadoHint;
        private System.Windows.Forms.Button btnRegistrarVenta;
    }
}
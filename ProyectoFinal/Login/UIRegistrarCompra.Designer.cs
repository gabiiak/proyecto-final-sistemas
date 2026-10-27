namespace Login
{
    partial class UIRegistrarCompra
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
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvCompra_DetalleCompra = new System.Windows.Forms.DataGridView();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.btnQuitarDetalle = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalSimbolo = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.lblPagoRealizado = new System.Windows.Forms.Label();
            this.txtPagoRealizado = new System.Windows.Forms.TextBox();
            this.btnPagoTotal = new System.Windows.Forms.Button();
            this.lblEstadoHint = new System.Windows.Forms.Label();
            this.btnRegistrarCompra = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra_DetalleCompra)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(520, 680);
            this.Text = "Registrar Compra";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegistrarCompra";
            this.Load += new System.EventHandler(this.UIRegistrarCompra_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Registrar Compra";
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

            this.pnlFormulario.Controls.Add(this.lblProveedor);
            this.pnlFormulario.Controls.Add(this.cbProveedor);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.txtFecha);

            // ── LABEL DETALLES ──────────────────────────────────────
            this.lblDetalles.Text = "Detalle de la compra";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Size = new System.Drawing.Size(300, 24);
            this.lblDetalles.Name = "lblDetalles";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvCompra_DetalleCompra.Location = new System.Drawing.Point(20, 248);
            this.dgvCompra_DetalleCompra.Size = new System.Drawing.Size(480, 200);
            this.dgvCompra_DetalleCompra.Name = "dgvCompra_DetalleCompra";
            this.dgvCompra_DetalleCompra.TabIndex = 7;
            this.dgvCompra_DetalleCompra.AllowUserToAddRows = false;
            this.dgvCompra_DetalleCompra.AllowUserToDeleteRows = false;
            this.dgvCompra_DetalleCompra.ReadOnly = true;
            this.dgvCompra_DetalleCompra.RowTemplate.Height = 35;
            this.dgvCompra_DetalleCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompra_DetalleCompra.RowHeadersVisible = false;
            this.dgvCompra_DetalleCompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompra_DetalleCompra.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompra_DetalleCompra.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvCompra_DetalleCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompra_DetalleCompra.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCompra_DetalleCompra.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvCompra_DetalleCompra.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvCompra_DetalleCompra.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvCompra_DetalleCompra.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvCompra_DetalleCompra.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvCompra_DetalleCompra.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvCompra_DetalleCompra.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvCompra_DetalleCompra.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "Insumo";
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "Cantidad";
            this.colCantidad.ValueType = typeof(decimal);
            this.colCantidad.DefaultCellStyle.Format = "N2";
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSubTotal.HeaderText = "Subtotal";
            this.colSubTotal.Name = "SubTotal";
            this.colSubTotal.ValueType = typeof(double);
            this.colSubTotal.DefaultCellStyle.Format = "$#,##0.00";
            this.colSubTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.dgvCompra_DetalleCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colInsumo, this.colCantidad, this.colSubTotal
            });

            // ── PANEL TOTAL ─────────────────────────────────────────
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 512);
            this.pnlTotal.Size = new System.Drawing.Size(480, 80);
            this.pnlTotal.Name = "pnlTotal";

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
            this.labelTotal.Size = new System.Drawing.Size(200, 32);
            this.labelTotal.Name = "labelTotal";

            this.pnlTotal.Controls.Add(this.lblTotalLabel);
            this.pnlTotal.Controls.Add(this.lblTotalSimbolo);
            this.pnlTotal.Controls.Add(this.labelTotal);
            this.pnlTotal.Controls.Add(this.lblPagoRealizado);
            this.pnlTotal.Controls.Add(this.txtPagoRealizado);
            this.pnlTotal.Controls.Add(this.btnPagoTotal);

            // ── HINT DE ESTADO ──────────────────────────────────────
            this.lblEstadoHint.Text = "La compra se registra ACEPTADA   |   el pago no puede superar el total";
            this.lblEstadoHint.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblEstadoHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblEstadoHint.Location = new System.Drawing.Point(20, 600);
            this.lblEstadoHint.Size = new System.Drawing.Size(480, 18);
            this.lblEstadoHint.Name = "lblEstadoHint";

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvCompra_DetalleCompra);
            this.Controls.Add(this.btnAgregarDetalle);
            this.Controls.Add(this.btnQuitarDetalle);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.lblEstadoHint);
            this.Controls.Add(this.btnRegistrarCompra);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra_DetalleCompra)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvCompra_DetalleCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Button btnQuitarDetalle;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalSimbolo;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label lblPagoRealizado;
        private System.Windows.Forms.TextBox txtPagoRealizado;
        private System.Windows.Forms.Button btnPagoTotal;
        private System.Windows.Forms.Label lblEstadoHint;
        private System.Windows.Forms.Button btnRegistrarCompra;
    }
}
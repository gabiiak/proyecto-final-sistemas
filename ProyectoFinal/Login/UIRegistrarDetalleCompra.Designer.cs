namespace Login
{
    partial class UIRegistrarDetalleCompra
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
            this.lblInsumo = new System.Windows.Forms.Label();
            this.cbInsumo = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.numUpDownPrecio = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.pnlSubtotal = new System.Windows.Forms.Panel();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.btnRegistrarDetalle = new System.Windows.Forms.Button();
            this.btnSalirDetalle = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlSubtotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(420, 396);
            this.Text = "Agregar Detalle";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegistrarDetalleCompra";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegistrarDetalleCompra_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Agregar Detalle de Compra";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(380, 28);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL FORMULARIO ────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 52);
            this.pnlFormulario.Size = new System.Drawing.Size(380, 212);
            this.pnlFormulario.Name = "pnlFormulario";

            // Precio unitario
            this.numUpDownPrecio.DecimalPlaces = 2;
            this.numUpDownPrecio.Maximum = 100000000;
            this.numUpDownPrecio.Minimum = 0;
            this.numUpDownPrecio.Location = new System.Drawing.Point(16, 100);
            this.numUpDownPrecio.Size = new System.Drawing.Size(160, 32);
            this.numUpDownPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUpDownPrecio.TabIndex = 1;
            this.numUpDownPrecio.Name = "numUpDownPrecio";
            this.numUpDownPrecio.ValueChanged += new System.EventHandler(this.numUpDownPrecio_ValueChanged);

            // Cantidad
            this.numUpDownCantidad.Location = new System.Drawing.Point(16, 168);
            this.numUpDownCantidad.Size = new System.Drawing.Size(80, 32);
            this.numUpDownCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUpDownCantidad.DecimalPlaces = 2;
            this.numUpDownCantidad.Maximum = 50000;
            this.numUpDownCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numUpDownCantidad.TabIndex = 2;
            this.numUpDownCantidad.Name = "numUpDownCantidad";
            this.numUpDownCantidad.ValueChanged += new System.EventHandler(this.numUpDownCantidad_ValueChanged);

            this.lblUnidades.Text = "unidades";
            this.lblUnidades.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblUnidades.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblUnidades.Location = new System.Drawing.Point(104, 172);
            this.lblUnidades.Size = new System.Drawing.Size(70, 20);
            this.lblUnidades.Name = "lblUnidades";

            this.pnlFormulario.Controls.Add(this.lblInsumo);
            this.pnlFormulario.Controls.Add(this.cbInsumo);
            this.pnlFormulario.Controls.Add(this.lblPrecio);
            this.pnlFormulario.Controls.Add(this.numUpDownPrecio);
            this.pnlFormulario.Controls.Add(this.lblCantidad);
            this.pnlFormulario.Controls.Add(this.numUpDownCantidad);
            this.pnlFormulario.Controls.Add(this.lblUnidades);

            // ── PANEL SUBTOTAL ──────────────────────────────────────
            this.pnlSubtotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlSubtotal.Location = new System.Drawing.Point(20, 276);
            this.pnlSubtotal.Size = new System.Drawing.Size(380, 56);
            this.pnlSubtotal.Name = "pnlSubtotal";

            this.lblSubtotalLabel.Text = "SUBTOTAL";
            this.lblSubtotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalLabel.Location = new System.Drawing.Point(16, 8);
            this.lblSubtotalLabel.Size = new System.Drawing.Size(80, 16);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";

            this.labelSubtotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelSubtotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelSubtotal.Location = new System.Drawing.Point(16, 24);
            this.labelSubtotal.Size = new System.Drawing.Size(200, 26);
            this.labelSubtotal.Name = "labelSubtotal";

            this.pnlSubtotal.Controls.Add(this.lblSubtotalLabel);
            this.pnlSubtotal.Controls.Add(this.labelSubtotal);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlSubtotal);
            this.Controls.Add(this.btnRegistrarDetalle);
            this.Controls.Add(this.btnSalirDetalle);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlSubtotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlSubtotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cbInsumo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown numUpDownPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numUpDownCantidad;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Button btnRegistrarDetalle;
        private System.Windows.Forms.Button btnSalirDetalle;
    }
}
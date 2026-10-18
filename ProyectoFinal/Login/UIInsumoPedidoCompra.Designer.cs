namespace Login
{
    partial class UIInsumoPedidoCompra
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
            this.lblInsumo = new System.Windows.Forms.Label();
            this.cbInsumo = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(420, 308);
            this.Text = "Agregar Insumo al Pedido";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIInsumoPedidoCompra";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIInsumoPedidoCompra_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Agregar Insumo al Pedido";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(380, 28);
            this.lblTitulo.Name = "lblTitulo";

            // ── INSUMO ──────────────────────────────────────────────
            this.cbInsumo.FormattingEnabled = true;
            this.cbInsumo.Name = "cbInsumo";
            this.cbInsumo.SelectedIndexChanged += new System.EventHandler(this.cbInsumo_SelectedIndexChanged);

            // ── CANTIDAD ────────────────────────────────────────────
            this.numUpDownCantidad.DecimalPlaces = 2;
            this.numUpDownCantidad.Maximum = 50000;
            this.numUpDownCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });

            this.lblUnidades.Text = "unidades";
            this.lblUnidades.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblUnidades.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblUnidades.Location = new System.Drawing.Point(344, 148);
            this.lblUnidades.Size = new System.Drawing.Size(62, 20);
            this.lblUnidades.Name = "lblUnidades";

            // ── AVISO ───────────────────────────────────────────────
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(176, 42, 42);
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAviso.Location = new System.Drawing.Point(16, 190);
            this.lblAviso.Size = new System.Drawing.Size(390, 40);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Visible = false;

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblInsumo);
            this.Controls.Add(this.cbInsumo);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.numUpDownCantidad);
            this.Controls.Add(this.lblUnidades);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);

            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cbInsumo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numUpDownCantidad;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

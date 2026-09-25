namespace Login
{
    partial class UIRegistrarDetalleVenta
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
            this.lblProducto = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numUpDownCantidadTandas = new System.Windows.Forms.NumericUpDown();
            this.lblTandas = new System.Windows.Forms.Label();
            this.pnlSubtotal = new System.Windows.Forms.Panel();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.lblSubtotalSimbolo = new System.Windows.Forms.Label();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.btnRegistrarDetalle = new System.Windows.Forms.Button();
            this.btnSalirDetalle = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlSubtotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(420, 396);
            this.Text = "Agregar Detalle";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegisterSaleDetail";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegisterSaleDetail_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Agregar Detalle de Venta";
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
            //this.pnlFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Producto
            

            this.numUpDownCantidadTandas.Location = new System.Drawing.Point(16, 168);
            this.numUpDownCantidadTandas.Size = new System.Drawing.Size(80, 32);
            this.numUpDownCantidadTandas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUpDownCantidadTandas.Minimum = 0;
            this.numUpDownCantidadTandas.TabIndex = 2;
            this.numUpDownCantidadTandas.Name = "numUpDownCantidadTandas";
            this.numUpDownCantidadTandas.ValueChanged += new System.EventHandler(this.numUpDownCantidadTandas_ValueChanged);

            this.lblTandas.Text = "tandas";
            this.lblTandas.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTandas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblTandas.Location = new System.Drawing.Point(104, 172);
            this.lblTandas.Size = new System.Drawing.Size(60, 20);
            this.lblTandas.Name = "lblTandas";

            this.pnlFormulario.Controls.Add(this.lblProducto);
            this.pnlFormulario.Controls.Add(this.cbProducto);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtDescripcionProducto);
            this.pnlFormulario.Controls.Add(this.lblCantidad);
            this.pnlFormulario.Controls.Add(this.numUpDownCantidadTandas);
            this.pnlFormulario.Controls.Add(this.lblTandas);

            // ── PANEL SUBTOTAL ──────────────────────────────────────
            // Mismo estilo que el pnlTotal de UIRegisterSale
            this.pnlSubtotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlSubtotal.Location = new System.Drawing.Point(20, 276);
            this.pnlSubtotal.Size = new System.Drawing.Size(380, 56);
            this.pnlSubtotal.Name = "pnlSubtotal";
            //this.pnlSubtotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            this.lblSubtotalLabel.Text = "SUBTOTAL";
            this.lblSubtotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalLabel.Location = new System.Drawing.Point(16, 8);
            this.lblSubtotalLabel.Size = new System.Drawing.Size(80, 16);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";

            this.lblSubtotalSimbolo.Text = "$";
            this.lblSubtotalSimbolo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblSubtotalSimbolo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalSimbolo.Location = new System.Drawing.Point(16, 24);
            this.lblSubtotalSimbolo.Size = new System.Drawing.Size(0, 0);
            this.lblSubtotalSimbolo.Name = "lblSubtotalSimbolo";

            //this.labelSubtotal.Text = "0,00";
            this.labelSubtotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelSubtotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelSubtotal.Location = new System.Drawing.Point(20, 24);
            this.labelSubtotal.Size = new System.Drawing.Size(200, 26);
            this.labelSubtotal.Name = "labelSubtotal";

            this.pnlSubtotal.Controls.Add(this.lblSubtotalLabel);
            this.pnlSubtotal.Controls.Add(this.lblSubtotalSimbolo);
            this.pnlSubtotal.Controls.Add(this.labelSubtotal);

            // ── BOTONES ─────────────────────────────────────────────
            

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlSubtotal);
            this.Controls.Add(this.btnRegistrarDetalle);
            this.Controls.Add(this.btnSalirDetalle);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlSubtotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlSubtotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numUpDownCantidadTandas;
        private System.Windows.Forms.Label lblTandas;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label lblSubtotalSimbolo;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Button btnRegistrarDetalle;
        private System.Windows.Forms.Button btnSalirDetalle;
    }
}
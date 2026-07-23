namespace Login
{
    partial class UITransporte
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

            // Campos de Transporte
            this.lblVentas = new System.Windows.Forms.Label();
            this.clbVentas = new System.Windows.Forms.CheckedListBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();

            // Panel de Info (Total de las ventas seleccionadas)
            this.pnlInfoVenta = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalSimbolo = new System.Windows.Forms.Label();
            this.labelTotalCobrar = new System.Windows.Forms.Label();

            // Botones
            this.btnRegistrarTransporte = new System.Windows.Forms.Button();
            this.btnSalirTransporte = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlInfoVenta.SuspendLayout();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(420, 460);
            this.Text = "Programar Transporte";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegisterTransporte";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Programar Nuevo Transporte";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(380, 28);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL FORMULARIO ────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 52);
            this.pnlFormulario.Size = new System.Drawing.Size(380, 260);
            this.pnlFormulario.Name = "pnlFormulario";

            // 1. Selección de Ventas (una o varias, con checks)
            ConfigurarLabel(this.lblVentas, "Ventas a incluir en el transporte",
                new System.Drawing.Point(16, 16));

            this.clbVentas.Location = new System.Drawing.Point(16, 36);
            this.clbVentas.Size = new System.Drawing.Size(348, 110);
            this.clbVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.clbVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbVentas.CheckOnClick = true;
            this.clbVentas.IntegralHeight = false;
            this.clbVentas.TabIndex = 0;
            this.clbVentas.Name = "clbVentas";
            // Los items (una entrada por venta, ej. "Venta #12 - Cliente Pérez - $1500,00")
            // se cargan en el code-behind consultando DataVenta, no acá.
            this.clbVentas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbVentas_ItemCheck);

            // 2. Fecha del Transporte
            ConfigurarLabel(this.lblFecha, "Fecha y Hora Programada",
                new System.Drawing.Point(16, 152));

            this.dtpFecha.Location = new System.Drawing.Point(16, 172);
            this.dtpFecha.Size = new System.Drawing.Size(348, 25);
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            // Formato personalizado para poder elegir también la hora (no solo la fecha)
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            // Con Format.Custom, el botón desplegable solo abre un calendario (sin hora).
            // ShowUpDown = true reemplaza ese botón por flechas arriba/abajo, permitiendo
            // editar cada segmento (día/mes/año/hora/minuto) haciendo clic sobre él
            // y usando las flechas del teclado o del control, o tipeando el número directamente.
            this.dtpFecha.ShowUpDown = true;
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.Name = "dtpFecha";

            // 3. Estado del Transporte
            ConfigurarLabel(this.lblEstado, "Estado del Transporte",
                new System.Drawing.Point(16, 205));

            this.cbEstado.Location = new System.Drawing.Point(16, 225);
            this.cbEstado.Size = new System.Drawing.Size(348, 32);
            this.cbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.TabIndex = 2;
            this.cbEstado.Name = "cbEstado";
            // El índice de cada item coincide con las constantes de EstadoTransporte
            // (0 = programado, 1 = EnTransito, 2 = Entregado, 3 = cancelado)
            this.cbEstado.Items.AddRange(new object[] {
                "Programado",
                "En Tránsito",
                "Entregado",
                "Cancelado"
            });
            this.cbEstado.SelectedIndex = 0;

            this.pnlFormulario.Controls.Add(this.lblVentas);
            this.pnlFormulario.Controls.Add(this.clbVentas);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.dtpFecha);
            this.pnlFormulario.Controls.Add(this.lblEstado);
            this.pnlFormulario.Controls.Add(this.cbEstado);

            // ── PANEL TOTAL A COBRAR (Info) ─────────────────────────
            this.pnlInfoVenta.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlInfoVenta.Location = new System.Drawing.Point(20, 320);
            this.pnlInfoVenta.Size = new System.Drawing.Size(380, 56);
            this.pnlInfoVenta.Name = "pnlInfoVenta";

            this.lblTotalLabel.Text = "TOTAL VENTAS SELECCIONADAS";
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 8);
            this.lblTotalLabel.Size = new System.Drawing.Size(200, 16);
            this.lblTotalLabel.Name = "lblTotalLabel";

            this.lblTotalSimbolo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTotalSimbolo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalSimbolo.Location = new System.Drawing.Point(16, 24);
            this.lblTotalSimbolo.Size = new System.Drawing.Size(20, 26);
            this.lblTotalSimbolo.Name = "lblTotalSimbolo";

            this.labelTotalCobrar.Text = "0,00";
            this.labelTotalCobrar.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelTotalCobrar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotalCobrar.Location = new System.Drawing.Point(36, 24);
            this.labelTotalCobrar.Size = new System.Drawing.Size(200, 26);
            this.labelTotalCobrar.Name = "labelTotalCobrar";

            this.pnlInfoVenta.Controls.Add(this.lblTotalLabel);
            this.pnlInfoVenta.Controls.Add(this.lblTotalSimbolo);
            this.pnlInfoVenta.Controls.Add(this.labelTotalCobrar);

            // ── BOTONES ─────────────────────────────────────────────
            ConfigurarBotonPrimario(this.btnRegistrarTransporte, "Registrar",
                new System.Drawing.Point(20, 384), 3);
            this.btnRegistrarTransporte.Size = new System.Drawing.Size(240, 40);
            this.btnRegistrarTransporte.Click += new System.EventHandler(this.btnRegistrarTransporte_Click);

            ConfigurarBotonSecundario(this.btnSalirTransporte, "Cancelar",
                new System.Drawing.Point(272, 384), 4);
            this.btnSalirTransporte.Size = new System.Drawing.Size(128, 40);
            this.btnSalirTransporte.Click += new System.EventHandler(this.btnSalirTransporte_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlInfoVenta);
            this.Controls.Add(this.btnRegistrarTransporte);
            this.Controls.Add(this.btnSalirTransporte);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlInfoVenta.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── HELPERS ──────────────────────────────────────────────
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(280, 18);
            lbl.AutoSize = false;
        }

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(140, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(140, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var panel = sender as System.Windows.Forms.Panel;
            var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(211, 209, 199), 1f);
            var rect = new System.Drawing.Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            int r = 8;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            e.Graphics.DrawPath(pen, path);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlInfoVenta;
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.CheckedListBox clbVentas;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cbEstado;

        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalSimbolo;
        private System.Windows.Forms.Label labelTotalCobrar;

        private System.Windows.Forms.Button btnRegistrarTransporte;
        private System.Windows.Forms.Button btnSalirTransporte;
    }
}
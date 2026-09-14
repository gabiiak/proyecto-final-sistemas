namespace Login
{
    partial class UIRegistrarTanda
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
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvTanda_Detalles = new System.Windows.Forms.DataGridView();
            this.Insumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.btnQuitarDetalle = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.labelTotalCantidad = new System.Windows.Forms.Label();
            this.lblEstadoHint = new System.Windows.Forms.Label();
            this.btnRegistrarTanda = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanda_Detalles)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(520, 680);
            this.Text = "Registrar Tanda de Producción";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Load += new System.EventHandler(this.UIRegistrarTanda_Load);

            // Titulo
            this.lblTitulo.Text = "Registrar Tanda de Producción";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);

            // Panel Superior
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 56);
            this.pnlFormulario.Size = new System.Drawing.Size(480, 148);

            ConfigurarLabel(this.lblProducto, "Producto a elaborar", new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbProducto, new System.Drawing.Point(16, 36), new System.Drawing.Size(448, 32), 0);

            ConfigurarLabel(this.lblFecha, "Fecha", new System.Drawing.Point(16, 84));
            ConfigurarTextBox(this.txtFecha, new System.Drawing.Point(16, 104), new System.Drawing.Size(210, 32), 1);

            ConfigurarLabel(this.lblHora, "Hora", new System.Drawing.Point(240, 84));
            ConfigurarTextBox(this.txtHora, new System.Drawing.Point(240, 104), new System.Drawing.Size(224, 32), 2);

            this.pnlFormulario.Controls.Add(this.lblProducto);
            this.pnlFormulario.Controls.Add(this.cbProducto);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.txtFecha);
            this.pnlFormulario.Controls.Add(this.lblHora);
            this.pnlFormulario.Controls.Add(this.txtHora);

            // Detalle Label
            this.lblDetalles.Text = "Insumos y Personal Asignado";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Size = new System.Drawing.Size(300, 24);

            // DataGridView
            this.dgvTanda_Detalles.Location = new System.Drawing.Point(20, 248);
            this.dgvTanda_Detalles.Size = new System.Drawing.Size(480, 200);
            this.dgvTanda_Detalles.TabIndex = 3;
            this.dgvTanda_Detalles.AllowUserToAddRows = false;
            this.dgvTanda_Detalles.ReadOnly = true;
            this.dgvTanda_Detalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTanda_Detalles.RowHeadersVisible = false;
            this.dgvTanda_Detalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTanda_Detalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvTanda_Detalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.Insumo.HeaderText = "Insumo";
            this.Insumo.Name = "Insumo";
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.dgvTanda_Detalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Insumo, this.Empleado, this.Cantidad });

            // Botones Detalle
            ConfigurarBotonPrimario(this.btnAgregarDetalle, "Agregar Insumo", new System.Drawing.Point(20, 460), 4);
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);

            ConfigurarBotonSecundario(this.btnQuitarDetalle, "Quitar detalle", new System.Drawing.Point(176, 460), 5);
            this.btnQuitarDetalle.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);

            // Panel Resumen
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 512);
            this.pnlTotal.Size = new System.Drawing.Size(480, 80);

            this.lblTotalLabel.Text = "TOTAL UNIDADES PRODUCIDAS";
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 12);
            this.lblTotalLabel.Size = new System.Drawing.Size(250, 16);

            this.labelTotalCantidad.Text = "0";
            this.labelTotalCantidad.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTotalCantidad.Location = new System.Drawing.Point(16, 32);
            this.labelTotalCantidad.Size = new System.Drawing.Size(200, 32);

            this.pnlTotal.Controls.Add(this.lblTotalLabel);
            this.pnlTotal.Controls.Add(this.labelTotalCantidad);

            this.lblEstadoHint.Text = "Las tandas creadas inician automáticamente en estado PENDIENTE.";
            this.lblEstadoHint.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblEstadoHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblEstadoHint.Location = new System.Drawing.Point(20, 600);
            this.lblEstadoHint.Size = new System.Drawing.Size(480, 18);

            ConfigurarBotonPrimario(this.btnRegistrarTanda, "Registrar Tanda", new System.Drawing.Point(20, 624), 6);
            this.btnRegistrarTanda.Size = new System.Drawing.Size(480, 44);
            this.btnRegistrarTanda.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarTanda.Click += new System.EventHandler(this.btnRegistrarTanda_Click);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvTanda_Detalles);
            this.Controls.Add(this.btnAgregarDetalle);
            this.Controls.Add(this.btnQuitarDetalle);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.lblEstadoHint);
            this.Controls.Add(this.btnRegistrarTanda);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanda_Detalles)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(220, 18);
        }

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt, System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
        {
            txt.Location = ubicacion;
            txt.Size = tamaño;
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            txt.TabIndex = tabIndex;
        }

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb, System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
        {
            cb.Location = ubicacion;
            cb.Size = tamaño;
            cb.Font = new System.Drawing.Font("Segoe UI", 10F);
            cb.FormattingEnabled = true;
            cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cb.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            cb.TabIndex = tabIndex;
        }

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
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
        }

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
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
        }

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvTanda_Detalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Button btnQuitarDetalle;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label labelTotalCantidad;
        private System.Windows.Forms.Label lblEstadoHint;
        private System.Windows.Forms.Button btnRegistrarTanda;
    }
}
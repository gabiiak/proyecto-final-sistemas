namespace Login
{
    partial class UIRegisterTandaDetail
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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcionInsumo = new System.Windows.Forms.TextBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.btnRegistrarDetalle = new System.Windows.Forms.Button();
            this.btnSalirDetalle = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(420, 396);
            this.Text = "Agregar Detalle de Tanda";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegisterTandaDetail_Load);

            // Título
            this.lblTitulo.Text = "Agregar Insumo / Detalle";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(380, 28);

            // Panel Formulario
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 52);
            this.pnlFormulario.Size = new System.Drawing.Size(380, 275);

            // Insumo
            ConfigurarLabel(this.lblInsumo, "Insumo", new System.Drawing.Point(16, 12));
            ConfigurarCombo(this.cbInsumo, new System.Drawing.Point(16, 30), new System.Drawing.Size(348, 30), 0);
            this.cbInsumo.SelectedIndexChanged += new System.EventHandler(this.cbInsumo_SelectedIndexChanged);

            // Descripción Insumo
            ConfigurarLabel(this.lblDescripcion, "Descripción del Insumo", new System.Drawing.Point(16, 68));
            ConfigurarTextBox(this.txtDescripcionInsumo, new System.Drawing.Point(16, 86), new System.Drawing.Size(348, 30), 1);
            this.txtDescripcionInsumo.ReadOnly = true;
            this.txtDescripcionInsumo.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);

            // Empleado Responsable
            ConfigurarLabel(this.lblEmpleado, "Empleado Responsable", new System.Drawing.Point(16, 126));
            ConfigurarCombo(this.cbEmpleado, new System.Drawing.Point(16, 144), new System.Drawing.Size(348, 30), 2);

            // Cantidad Producida
            ConfigurarLabel(this.lblCantidad, "Cantidad Producida", new System.Drawing.Point(16, 186));
            this.numUpDownCantidad.Location = new System.Drawing.Point(16, 206);
            this.numUpDownCantidad.Size = new System.Drawing.Size(100, 30);
            this.numUpDownCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUpDownCantidad.Maximum = 100000;
            this.numUpDownCantidad.TabIndex = 3;

            this.lblUnidades.Text = "unidades";
            this.lblUnidades.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblUnidades.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblUnidades.Location = new System.Drawing.Point(125, 210);
            this.lblUnidades.Size = new System.Drawing.Size(80, 20);

            this.pnlFormulario.Controls.Add(this.lblInsumo);
            this.pnlFormulario.Controls.Add(this.cbInsumo);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtDescripcionInsumo);
            this.pnlFormulario.Controls.Add(this.lblEmpleado);
            this.pnlFormulario.Controls.Add(this.cbEmpleado);
            this.pnlFormulario.Controls.Add(this.lblCantidad);
            this.pnlFormulario.Controls.Add(this.numUpDownCantidad);
            this.pnlFormulario.Controls.Add(this.lblUnidades);

            // Botones
            ConfigurarBotonPrimario(this.btnRegistrarDetalle, "Registrar", new System.Drawing.Point(20, 340), 4);
            this.btnRegistrarDetalle.Size = new System.Drawing.Size(240, 40);
            this.btnRegistrarDetalle.Click += new System.EventHandler(this.btnRegistrarDetalle_Click);

            ConfigurarBotonSecundario(this.btnSalirDetalle, "Cancelar", new System.Drawing.Point(272, 340), 5);
            this.btnSalirDetalle.Size = new System.Drawing.Size(128, 40);
            this.btnSalirDetalle.Click += new System.EventHandler(this.btnSalirDetalle_Click);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.btnRegistrarDetalle);
            this.Controls.Add(this.btnSalirDetalle);

            this.pnlFormulario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).EndInit();
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
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cbInsumo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcionInsumo;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cbEmpleado;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numUpDownCantidad;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Button btnRegistrarDetalle;
        private System.Windows.Forms.Button btnSalirDetalle;
    }
}
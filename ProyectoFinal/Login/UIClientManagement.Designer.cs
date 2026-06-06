//namespace Login
//{
//    partial class UIClientManagement
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIClientManagement));
//            this.dgvClientes = new System.Windows.Forms.DataGridView();
//            this.txtNombre = new System.Windows.Forms.TextBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.btnListarBorrados = new System.Windows.Forms.Button();
//            this.label6 = new System.Windows.Forms.Label();
//            this.labelId = new System.Windows.Forms.Label();
//            this.btnEliminar = new System.Windows.Forms.Button();
//            this.btnModificar = new System.Windows.Forms.Button();
//            this.btnLimpiar = new System.Windows.Forms.Button();
//            this.btnRegistrar = new System.Windows.Forms.Button();
//            this.txtTelefono = new System.Windows.Forms.TextBox();
//            this.label5 = new System.Windows.Forms.Label();
//            this.txtDireccion = new System.Windows.Forms.TextBox();
//            this.txtEmpresa = new System.Windows.Forms.TextBox();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
//            this.panel1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // dgvClientes
//            // 
//            this.dgvClientes.AllowUserToAddRows = false;
//            this.dgvClientes.AllowUserToDeleteRows = false;
//            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvClientes.Location = new System.Drawing.Point(12, 334);
//            this.dgvClientes.Margin = new System.Windows.Forms.Padding(4);
//            this.dgvClientes.Name = "dgvClientes";
//            this.dgvClientes.RowHeadersWidth = 51;
//            this.dgvClientes.Size = new System.Drawing.Size(704, 201);
//            this.dgvClientes.TabIndex = 0;
//            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
//            // 
//            // txtNombre
//            // 
//            this.txtNombre.Location = new System.Drawing.Point(123, 40);
//            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
//            this.txtNombre.Name = "txtNombre";
//            this.txtNombre.Size = new System.Drawing.Size(194, 26);
//            this.txtNombre.TabIndex = 1;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(23, 14);
//            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(225, 29);
//            this.label1.TabIndex = 2;
//            this.label1.Text = "Gestión de clientes ";
//            // 
//            // panel1
//            // 
//            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
//            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.panel1.Controls.Add(this.btnListarBorrados);
//            this.panel1.Controls.Add(this.label6);
//            this.panel1.Controls.Add(this.labelId);
//            this.panel1.Controls.Add(this.btnEliminar);
//            this.panel1.Controls.Add(this.btnModificar);
//            this.panel1.Controls.Add(this.btnLimpiar);
//            this.panel1.Controls.Add(this.btnRegistrar);
//            this.panel1.Controls.Add(this.txtTelefono);
//            this.panel1.Controls.Add(this.label5);
//            this.panel1.Controls.Add(this.txtDireccion);
//            this.panel1.Controls.Add(this.txtEmpresa);
//            this.panel1.Controls.Add(this.label4);
//            this.panel1.Controls.Add(this.label3);
//            this.panel1.Controls.Add(this.label2);
//            this.panel1.Controls.Add(this.txtNombre);
//            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.panel1.Location = new System.Drawing.Point(12, 46);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(705, 281);
//            this.panel1.TabIndex = 3;
//            // 
//            // btnListarBorrados
//            // 
//            this.btnListarBorrados.AutoSize = true;
//            this.btnListarBorrados.Location = new System.Drawing.Point(18, 244);
//            this.btnListarBorrados.Name = "btnListarBorrados";
//            this.btnListarBorrados.Size = new System.Drawing.Size(299, 32);
//            this.btnListarBorrados.TabIndex = 15;
//            this.btnListarBorrados.Text = "Clientes Eliminados";
//            this.btnListarBorrados.UseVisualStyleBackColor = true;
//            this.btnListarBorrados.Click += new System.EventHandler(this.btnListarBorrados_Click);
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Location = new System.Drawing.Point(14, 13);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(34, 20);
//            this.label6.TabIndex = 14;
//            this.label6.Text = "ID: ";
//            // 
//            // labelId
//            // 
//            this.labelId.AutoSize = true;
//            this.labelId.Location = new System.Drawing.Point(54, 13);
//            this.labelId.Name = "labelId";
//            this.labelId.Size = new System.Drawing.Size(0, 20);
//            this.labelId.TabIndex = 13;
//            // 
//            // btnEliminar
//            // 
//            this.btnEliminar.AutoSize = true;
//            this.btnEliminar.Location = new System.Drawing.Point(123, 208);
//            this.btnEliminar.Name = "btnEliminar";
//            this.btnEliminar.Size = new System.Drawing.Size(91, 30);
//            this.btnEliminar.TabIndex = 12;
//            this.btnEliminar.Text = "Eliminar";
//            this.btnEliminar.UseVisualStyleBackColor = true;
//            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
//            // 
//            // btnModificar
//            // 
//            this.btnModificar.AutoSize = true;
//            this.btnModificar.Location = new System.Drawing.Point(17, 208);
//            this.btnModificar.Name = "btnModificar";
//            this.btnModificar.Size = new System.Drawing.Size(101, 30);
//            this.btnModificar.TabIndex = 11;
//            this.btnModificar.Text = "Modificar";
//            this.btnModificar.UseVisualStyleBackColor = true;
//            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
//            // 
//            // btnLimpiar
//            // 
//            this.btnLimpiar.AutoSize = true;
//            this.btnLimpiar.Location = new System.Drawing.Point(227, 208);
//            this.btnLimpiar.Name = "btnLimpiar";
//            this.btnLimpiar.Size = new System.Drawing.Size(90, 30);
//            this.btnLimpiar.TabIndex = 10;
//            this.btnLimpiar.Text = "Limpiar";
//            this.btnLimpiar.UseVisualStyleBackColor = true;
//            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
//            // 
//            // btnRegistrar
//            // 
//            this.btnRegistrar.Location = new System.Drawing.Point(17, 166);
//            this.btnRegistrar.Name = "btnRegistrar";
//            this.btnRegistrar.Size = new System.Drawing.Size(300, 36);
//            this.btnRegistrar.TabIndex = 9;
//            this.btnRegistrar.Text = "Registrar";
//            this.btnRegistrar.UseVisualStyleBackColor = true;
//            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
//            // 
//            // txtTelefono
//            // 
//            this.txtTelefono.Location = new System.Drawing.Point(123, 127);
//            this.txtTelefono.Name = "txtTelefono";
//            this.txtTelefono.Size = new System.Drawing.Size(194, 26);
//            this.txtTelefono.TabIndex = 8;
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(14, 130);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(79, 20);
//            this.label5.TabIndex = 7;
//            this.label5.Text = "Teléfono: ";
//            // 
//            // txtDireccion
//            // 
//            this.txtDireccion.Location = new System.Drawing.Point(123, 98);
//            this.txtDireccion.Name = "txtDireccion";
//            this.txtDireccion.Size = new System.Drawing.Size(194, 26);
//            this.txtDireccion.TabIndex = 6;
//            // 
//            // txtEmpresa
//            // 
//            this.txtEmpresa.Location = new System.Drawing.Point(123, 69);
//            this.txtEmpresa.Name = "txtEmpresa";
//            this.txtEmpresa.Size = new System.Drawing.Size(194, 26);
//            this.txtEmpresa.TabIndex = 5;
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(14, 101);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(83, 20);
//            this.label4.TabIndex = 4;
//            this.label4.Text = "Dirección: ";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(14, 72);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(81, 20);
//            this.label3.TabIndex = 3;
//            this.label3.Text = "Empresa: ";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(14, 43);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(73, 20);
//            this.label2.TabIndex = 2;
//            this.label2.Text = "Nombre: ";
//            // 
//            // UIClientManagement
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(729, 542);
//            this.Controls.Add(this.panel1);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.dgvClientes);
//            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.Margin = new System.Windows.Forms.Padding(4);
//            this.Name = "UIClientManagement";
//            this.Text = "UIClientManagement";
//            this.Load += new System.EventHandler(this.UIClientManagement_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvClientes;
//        private System.Windows.Forms.TextBox txtNombre;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.TextBox txtDireccion;
//        private System.Windows.Forms.TextBox txtEmpresa;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Button btnRegistrar;
//        private System.Windows.Forms.TextBox txtTelefono;
//        private System.Windows.Forms.Button btnEliminar;
//        private System.Windows.Forms.Button btnModificar;
//        private System.Windows.Forms.Button btnLimpiar;
//        private System.Windows.Forms.Label labelId;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Button btnListarBorrados;
//    }
//}

namespace Login
{
    partial class UIClientManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIClientManagement));

            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnListarBorrados = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();

            this.pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Text = "Gestión de Clientes";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIClientManagement";
            this.Load += new System.EventHandler(this.UIClientManagement_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Gestión de Clientes";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL FORMULARIO ────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 56);
            this.pnlFormulario.Size = new System.Drawing.Size(860, 180);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(16);
            this.pnlFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFormulario_Paint);

            // ID (solo lectura, se llena al seleccionar)
            this.lblId.Text = "ID:";
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblId.Location = new System.Drawing.Point(16, 16);
            this.lblId.Size = new System.Drawing.Size(24, 20);
            this.lblId.Name = "lblId";

            this.labelId.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(44, 16);
            this.labelId.Size = new System.Drawing.Size(60, 20);
            this.labelId.Name = "labelId";

            // Fila 1: Nombre + Empresa
            ConfigurarLabel(this.lblNombre, "Nombre", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblEmpresa, "Empresa", new System.Drawing.Point(336, 48));
            ConfigurarTextBox(this.txtNombre, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            ConfigurarTextBox(this.txtEmpresa, new System.Drawing.Point(336, 68), new System.Drawing.Size(300, 32), 1);

            // Fila 2: Dirección + Teléfono
            ConfigurarLabel(this.lblDireccion, "Dirección", new System.Drawing.Point(16, 112));
            ConfigurarLabel(this.lblTelefono, "Teléfono", new System.Drawing.Point(336, 112));
            ConfigurarTextBox(this.txtDireccion, new System.Drawing.Point(16, 132), new System.Drawing.Size(300, 32), 2);
            ConfigurarTextBox(this.txtTelefono, new System.Drawing.Point(336, 132), new System.Drawing.Size(300, 32), 3);

            this.pnlFormulario.Controls.Add(this.lblId);
            this.pnlFormulario.Controls.Add(this.labelId);
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.lblEmpresa);
            this.pnlFormulario.Controls.Add(this.txtEmpresa);
            this.pnlFormulario.Controls.Add(this.lblDireccion);
            this.pnlFormulario.Controls.Add(this.txtDireccion);
            this.pnlFormulario.Controls.Add(this.lblTelefono);
            this.pnlFormulario.Controls.Add(this.txtTelefono);

            // ── BOTONES ─────────────────────────────────────────────
            // Primario: Registrar
            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar",
                new System.Drawing.Point(20, 252), 4);
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // Secundarios: Modificar, Eliminar, Limpiar
            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(176, 252), 5);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(332, 252), 6);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar",
                new System.Drawing.Point(488, 252), 7);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // Botón fantasma: Clientes Eliminados
            ConfigurarBotonFantasma(this.btnListarBorrados, "Ver clientes eliminados",
                new System.Drawing.Point(20, 300), 8);
            this.btnListarBorrados.Click += new System.EventHandler(this.btnListarBorrados_Click);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvClientes.Location = new System.Drawing.Point(20, 344);
            this.dgvClientes.Size = new System.Drawing.Size(860, 252);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.TabIndex = 9;
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.RowTemplate.Height = 35;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // Colores del grid
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvClientes.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvClientes.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvClientes.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvClientes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvClientes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvClientes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnListarBorrados);
            this.Controls.Add(this.dgvClientes);

            this.pnlFormulario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
        }

        // ── HELPERS DE ESTILO ────────────────────────────────────
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(200, 18);
            lbl.AutoSize = false;
        }

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
        {
            txt.Location = ubicacion;
            txt.Size = tamaño;
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            txt.TabIndex = tabIndex;
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
            btn.Name = btn.Text.ToLower();
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
            btn.Name = btn.Text.ToLower();
        }

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(220, 30);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = btn.Text.ToLower();
        }

        // ── BORDE REDONDEADO DEL PANEL ───────────────────────────
        private void pnlFormulario_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var panel = sender as System.Windows.Forms.Panel;
            var g = e.Graphics;
            var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(211, 209, 199), 1f);
            var rect = new System.Drawing.Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            int r = 8;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            g.DrawPath(pen, path);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnListarBorrados;
        private System.Windows.Forms.DataGridView dgvClientes;
    }
}
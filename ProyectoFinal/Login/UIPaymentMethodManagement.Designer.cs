//namespace Login
//{
//    partial class UIPaymentMethodManagement
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
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIPaymentMethodManagement));
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.btnProductosEliminados = new System.Windows.Forms.Button();
//            this.label6 = new System.Windows.Forms.Label();
//            this.labelId = new System.Windows.Forms.Label();
//            this.btnEliminar = new System.Windows.Forms.Button();
//            this.btnModificar = new System.Windows.Forms.Button();
//            this.btnLimpiar = new System.Windows.Forms.Button();
//            this.btnRegistrar = new System.Windows.Forms.Button();
//            this.txtDescripcion = new System.Windows.Forms.TextBox();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.dgvMetodos = new System.Windows.Forms.DataGridView();
//            this.panel1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodos)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // panel1
//            // 
//            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
//            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//            this.panel1.Controls.Add(this.btnProductosEliminados);
//            this.panel1.Controls.Add(this.label6);
//            this.panel1.Controls.Add(this.labelId);
//            this.panel1.Controls.Add(this.btnEliminar);
//            this.panel1.Controls.Add(this.btnModificar);
//            this.panel1.Controls.Add(this.btnLimpiar);
//            this.panel1.Controls.Add(this.btnRegistrar);
//            this.panel1.Controls.Add(this.txtDescripcion);
//            this.panel1.Controls.Add(this.label3);
//            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.panel1.Location = new System.Drawing.Point(12, 49);
//            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(821, 200);
//            this.panel1.TabIndex = 9;
//            // 
//            // btnProductosEliminados
//            // 
//            this.btnProductosEliminados.Location = new System.Drawing.Point(438, 143);
//            this.btnProductosEliminados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnProductosEliminados.Name = "btnProductosEliminados";
//            this.btnProductosEliminados.Size = new System.Drawing.Size(377, 37);
//            this.btnProductosEliminados.TabIndex = 15;
//            this.btnProductosEliminados.Text = "Eliminados";
//            this.btnProductosEliminados.UseVisualStyleBackColor = true;
//            this.btnProductosEliminados.Click += new System.EventHandler(this.btnProductosEliminados_Click);
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Location = new System.Drawing.Point(13, 14);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(42, 25);
//            this.label6.TabIndex = 14;
//            this.label6.Text = "ID: ";
//            // 
//            // labelId
//            // 
//            this.labelId.AutoSize = true;
//            this.labelId.Location = new System.Drawing.Point(53, 14);
//            this.labelId.Name = "labelId";
//            this.labelId.Size = new System.Drawing.Size(0, 25);
//            this.labelId.TabIndex = 13;
//            // 
//            // btnEliminar
//            // 
//            this.btnEliminar.AutoSize = true;
//            this.btnEliminar.Location = new System.Drawing.Point(159, 137);
//            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnEliminar.Name = "btnEliminar";
//            this.btnEliminar.Size = new System.Drawing.Size(135, 43);
//            this.btnEliminar.TabIndex = 12;
//            this.btnEliminar.Text = "Eliminar";
//            this.btnEliminar.UseVisualStyleBackColor = true;
//            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
//            // 
//            // btnModificar
//            // 
//            this.btnModificar.AutoSize = true;
//            this.btnModificar.Location = new System.Drawing.Point(18, 137);
//            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnModificar.Name = "btnModificar";
//            this.btnModificar.Size = new System.Drawing.Size(135, 43);
//            this.btnModificar.TabIndex = 11;
//            this.btnModificar.Text = "Modificar";
//            this.btnModificar.UseVisualStyleBackColor = true;
//            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
//            // 
//            // btnLimpiar
//            // 
//            this.btnLimpiar.Location = new System.Drawing.Point(297, 140);
//            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnLimpiar.Name = "btnLimpiar";
//            this.btnLimpiar.Size = new System.Drawing.Size(135, 37);
//            this.btnLimpiar.TabIndex = 10;
//            this.btnLimpiar.Text = "Limpiar";
//            this.btnLimpiar.UseVisualStyleBackColor = true;
//            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
//            // 
//            // btnRegistrar
//            // 
//            this.btnRegistrar.Location = new System.Drawing.Point(17, 97);
//            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.btnRegistrar.Name = "btnRegistrar";
//            this.btnRegistrar.Size = new System.Drawing.Size(415, 36);
//            this.btnRegistrar.TabIndex = 9;
//            this.btnRegistrar.Text = "Registrar";
//            this.btnRegistrar.UseVisualStyleBackColor = true;
//            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
//            // 
//            // txtDescripcion
//            // 
//            this.txtDescripcion.Location = new System.Drawing.Point(144, 51);
//            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtDescripcion.Name = "txtDescripcion";
//            this.txtDescripcion.Size = new System.Drawing.Size(291, 30);
//            this.txtDescripcion.TabIndex = 5;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(13, 51);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(125, 25);
//            this.label3.TabIndex = 3;
//            this.label3.Text = "Descripcion: ";
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(24, 11);
//            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(249, 36);
//            this.label1.TabIndex = 8;
//            this.label1.Text = "Métodos de Pago";
//            // 
//            // dgvMetodos
//            // 
//            this.dgvMetodos.AllowUserToAddRows = false;
//            this.dgvMetodos.AllowUserToDeleteRows = false;
//            this.dgvMetodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvMetodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvMetodos.Location = new System.Drawing.Point(12, 265);
//            this.dgvMetodos.Margin = new System.Windows.Forms.Padding(4);
//            this.dgvMetodos.Name = "dgvMetodos";
//            this.dgvMetodos.ReadOnly = true;
//            this.dgvMetodos.RowHeadersWidth = 51;
//            this.dgvMetodos.Size = new System.Drawing.Size(820, 247);
//            this.dgvMetodos.TabIndex = 7;
//            this.dgvMetodos.SelectionChanged += new System.EventHandler(this.dgvMetodos_SelectionChanged);
//            // 
//            // UIPaymentMethodManagement
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(845, 609);
//            this.Controls.Add(this.panel1);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.dgvMetodos);
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.Name = "UIPaymentMethodManagement";
//            this.Text = "UIMetodoPagoManagement";
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodos)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label labelId;
//        private System.Windows.Forms.Button btnEliminar;
//        private System.Windows.Forms.Button btnModificar;
//        private System.Windows.Forms.Button btnLimpiar;
//        private System.Windows.Forms.Button btnRegistrar;
//        private System.Windows.Forms.TextBox txtDescripcion;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.DataGridView dgvMetodos;
//        private System.Windows.Forms.Button btnProductosEliminados;
//    }
//}
namespace Login
{
    partial class UIPaymentMethodManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIPaymentMethodManagement));

            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnProductosEliminados = new System.Windows.Forms.Button();
            this.dgvMetodos = new System.Windows.Forms.DataGridView();

            this.pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodos)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Text = "Métodos de Pago";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UIPaymentMethodManagement";

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Métodos de Pago";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL FORMULARIO ────────────────────────────────────
            // Este form es más simple — solo tiene descripción,
            // así que el panel es más bajo que en los otros
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 56);
            this.pnlFormulario.Size = new System.Drawing.Size(860, 100);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(16);
            //this.pnlFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFormulario_Paint);

            // ID
            this.lblId.Text = "ID:";
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblId.Location = new System.Drawing.Point(16, 12);
            this.lblId.Size = new System.Drawing.Size(24, 20);
            this.lblId.Name = "lblId";

            this.labelId.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelId.Location = new System.Drawing.Point(44, 12);
            this.labelId.Size = new System.Drawing.Size(60, 20);
            this.labelId.Name = "labelId";

            // Descripción — ocupa todo el ancho, es el único campo
            ConfigurarLabel(this.lblDescripcion, "Descripción", new System.Drawing.Point(16, 36));
            ConfigurarTextBox(this.txtDescripcion, new System.Drawing.Point(16, 56), new System.Drawing.Size(820, 32), 0);

            this.pnlFormulario.Controls.Add(this.lblId);
            this.pnlFormulario.Controls.Add(this.labelId);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtDescripcion);

            // ── BOTONES ─────────────────────────────────────────────
            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar",
                new System.Drawing.Point(20, 172), 1);
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(176, 172), 2);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(332, 172), 3);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar",
                new System.Drawing.Point(488, 172), 4);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            ConfigurarBotonFantasma(this.btnProductosEliminados, "Ver métodos eliminados",
                new System.Drawing.Point(20, 220), 5);
            this.btnProductosEliminados.Click += new System.EventHandler(this.btnProductosEliminados_Click);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvMetodos.Location = new System.Drawing.Point(20, 264);
            this.dgvMetodos.Size = new System.Drawing.Size(860, 232);
            this.dgvMetodos.Name = "dgvMetodos";
            this.dgvMetodos.TabIndex = 6;
            this.dgvMetodos.AllowUserToAddRows = false;
            this.dgvMetodos.AllowUserToDeleteRows = false;
            this.dgvMetodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMetodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetodos.ReadOnly = true;
            this.dgvMetodos.RowTemplate.Height = 35;
            this.dgvMetodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMetodos.RowHeadersVisible = false;
            this.dgvMetodos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMetodos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMetodos.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvMetodos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMetodos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvMetodos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMetodos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvMetodos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvMetodos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMetodos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvMetodos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvMetodos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            this.dgvMetodos.SelectionChanged += new System.EventHandler(this.dgvMetodos_SelectionChanged);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnProductosEliminados);
            this.Controls.Add(this.dgvMetodos);

            this.pnlFormulario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodos)).EndInit();
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
            btn.Name = texto.ToLower();
        }

        private void pnlFormulario_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
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
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnProductosEliminados;
        private System.Windows.Forms.DataGridView dgvMetodos;
    }
}
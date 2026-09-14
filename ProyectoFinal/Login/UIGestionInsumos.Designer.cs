namespace Login
{
    partial class UIGestionInsumos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvInsumos = new System.Windows.Forms.DataGridView();
            this.grpUnidadMedida = new System.Windows.Forms.GroupBox();
            this.rbKg = new System.Windows.Forms.RadioButton();
            this.rbGr = new System.Windows.Forms.RadioButton();
            this.rbUnidad = new System.Windows.Forms.RadioButton();
            this.rbLts = new System.Windows.Forms.RadioButton();
            this.pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).BeginInit();
            this.grpUnidadMedida.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.grpUnidadMedida);
            this.pnlFormulario.Controls.Add(this.lblId);
            this.pnlFormulario.Controls.Add(this.labelId);
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.lblPrecio);
            this.pnlFormulario.Controls.Add(this.txtPrecio);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtDescripcion);
            this.pnlFormulario.Location = new System.Drawing.Point(20, 56);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(16);
            this.pnlFormulario.Size = new System.Drawing.Size(951, 200);
            this.pnlFormulario.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            this.lblId.Location = new System.Drawing.Point(16, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(24, 20);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // labelId
            // 
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.labelId.Location = new System.Drawing.Point(44, 16);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(60, 20);
            this.labelId.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(0, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(0, 0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 25);
            this.txtNombre.TabIndex = 3;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Location = new System.Drawing.Point(0, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(100, 23);
            this.lblPrecio.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(0, 0);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 25);
            this.txtPrecio.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
            this.lblDescripcion.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(0, 0);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 25);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Insumos";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(0, 0);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 2;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(0, 0);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(0, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(0, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 5;
            // 
            // dgvInsumos
            // 
            this.dgvInsumos.AllowUserToAddRows = false;
            this.dgvInsumos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvInsumos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInsumos.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsumos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInsumos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInsumos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(209)))), ((int)(((byte)(199)))));
            this.dgvInsumos.Location = new System.Drawing.Point(20, 344);
            this.dgvInsumos.Name = "dgvInsumos";
            this.dgvInsumos.ReadOnly = true;
            this.dgvInsumos.RowHeadersVisible = false;
            this.dgvInsumos.RowTemplate.Height = 35;
            this.dgvInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumos.Size = new System.Drawing.Size(860, 452);
            this.dgvInsumos.TabIndex = 7;
            this.dgvInsumos.SelectionChanged += new System.EventHandler(this.dgvInsumos_SelectionChanged);
            // 
            // grpUnidadMedida
            // 
            this.grpUnidadMedida.Controls.Add(this.rbLts);
            this.grpUnidadMedida.Controls.Add(this.rbUnidad);
            this.grpUnidadMedida.Controls.Add(this.rbGr);
            this.grpUnidadMedida.Controls.Add(this.rbKg);
            this.grpUnidadMedida.Location = new System.Drawing.Point(713, 19);
            this.grpUnidadMedida.Name = "grpUnidadMedida";
            this.grpUnidadMedida.Size = new System.Drawing.Size(200, 153);
            this.grpUnidadMedida.TabIndex = 8;
            this.grpUnidadMedida.TabStop = false;
            this.grpUnidadMedida.Text = "Unidad de medida";
            // 
            // rbKg
            // 
            this.rbKg.AutoSize = true;
            this.rbKg.Location = new System.Drawing.Point(6, 24);
            this.rbKg.Name = "rbKg";
            this.rbKg.Size = new System.Drawing.Size(95, 23);
            this.rbKg.TabIndex = 0;
            this.rbKg.TabStop = true;
            this.rbKg.Text = "Kilogramos";
            this.rbKg.UseVisualStyleBackColor = true;
            // 
            // rbGr
            // 
            this.rbGr.AutoSize = true;
            this.rbGr.Location = new System.Drawing.Point(6, 53);
            this.rbGr.Name = "rbGr";
            this.rbGr.Size = new System.Drawing.Size(75, 23);
            this.rbGr.TabIndex = 1;
            this.rbGr.TabStop = true;
            this.rbGr.Text = "Gramos";
            this.rbGr.UseVisualStyleBackColor = true;
            // 
            // rbUnidad
            // 
            this.rbUnidad.AutoSize = true;
            this.rbUnidad.Location = new System.Drawing.Point(6, 82);
            this.rbUnidad.Name = "rbUnidad";
            this.rbUnidad.Size = new System.Drawing.Size(75, 23);
            this.rbUnidad.TabIndex = 2;
            this.rbUnidad.TabStop = true;
            this.rbUnidad.Text = "Unidad ";
            this.rbUnidad.UseVisualStyleBackColor = true;
            // 
            // rbLts
            // 
            this.rbLts.AutoSize = true;
            this.rbLts.Location = new System.Drawing.Point(6, 112);
            this.rbLts.Name = "rbLts";
            this.rbLts.Size = new System.Drawing.Size(61, 23);
            this.rbLts.TabIndex = 3;
            this.rbLts.TabStop = true;
            this.rbLts.Text = "Litros";
            this.rbLts.UseVisualStyleBackColor = true;
            // 
            // UIGestionInsumos
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1198, 620);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvInsumos);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIGestionInsumos";
            this.Text = "Gestión de Insumos";
            this.Load += new System.EventHandler(this.UIInsumoManagement_Load);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).EndInit();
            this.grpUnidadMedida.ResumeLayout(false);
            this.grpUnidadMedida.PerformLayout();
            this.ResumeLayout(false);

        }

        // ── HELPERS DE ESTILO (idénticos a UIClientManagement, mismo look&feel) ──
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

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvInsumos;
        private System.Windows.Forms.GroupBox grpUnidadMedida;
        private System.Windows.Forms.RadioButton rbUnidad;
        private System.Windows.Forms.RadioButton rbGr;
        private System.Windows.Forms.RadioButton rbKg;
        private System.Windows.Forms.RadioButton rbLts;
    }
}

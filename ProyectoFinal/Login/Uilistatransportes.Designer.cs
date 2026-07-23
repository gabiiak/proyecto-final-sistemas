namespace Login
{
    partial class UIListaTransportes
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
            this.dgvTransportes = new System.Windows.Forms.DataGridView();
            this.colIdTransporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoTransporte = new System.Windows.Forms.Button();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnEliminarTransporte = new System.Windows.Forms.Button();
            this.btnEmitirFactura = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportes)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(760, 524);
            this.Text = "Transportes";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIListaTransportes";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Transportes Registrados";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 28);
            this.lblTitulo.Name = "lblTitulo";

            // ── GRILLA ──────────────────────────────────────────────
            this.dgvTransportes.Location = new System.Drawing.Point(20, 56);
            this.dgvTransportes.Size = new System.Drawing.Size(720, 360);
            this.dgvTransportes.Name = "dgvTransportes";
            this.dgvTransportes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTransportes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTransportes.AllowUserToAddRows = false;
            this.dgvTransportes.AllowUserToDeleteRows = false;
            this.dgvTransportes.AllowUserToResizeRows = false;
            this.dgvTransportes.RowHeadersVisible = false;
            this.dgvTransportes.MultiSelect = false;
            this.dgvTransportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransportes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvTransportes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTransportes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvTransportes.EnableHeadersVisualStyles = false;
            this.dgvTransportes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvTransportes.TabIndex = 0;

            // Selección de fila en un celeste suave (no el azul fuerte por default),
            // y el encabezado NO se resalta cuando seleccionás una celda de esa columna.
            this.dgvTransportes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 228, 247);
            this.dgvTransportes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTransportes.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 228, 247);
            this.dgvTransportes.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTransportes.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvTransportes.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);

            // Columnas manuales: la tabla que llega desde el code-behind tiene
            // las mismas columnas (por nombre) que estos DataPropertyName.
            // Solo "Estado" es editable, como un combo, para poder cambiarlo
            // directo en la grilla.
            this.dgvTransportes.AutoGenerateColumns = false;

            this.colIdTransporte.DataPropertyName = "IdTransporte";
            this.colIdTransporte.HeaderText = "N°";
            this.colIdTransporte.Name = "colIdTransporte";
            this.colIdTransporte.ReadOnly = true;
            this.colIdTransporte.FillWeight = 40;

            this.colIdVenta.DataPropertyName = "IdVenta";
            this.colIdVenta.HeaderText = "IdVenta";
            this.colIdVenta.Name = "colIdVenta";
            this.colIdVenta.ReadOnly = true;
            this.colIdVenta.Visible = false; // oculta, solo para uso interno

            this.colVenta.DataPropertyName = "Venta";
            this.colVenta.HeaderText = "Venta";
            this.colVenta.Name = "colVenta";
            this.colVenta.ReadOnly = true;

            this.colCliente.DataPropertyName = "Cliente";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;

            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;

            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;

            this.dgvTransportes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colIdTransporte,
                this.colIdVenta,   // NUEVO
                this.colVenta,
                this.colCliente,
                this.colTotal,
                this.colFecha,
                this.colEstado
            });

            // ── BOTONES ─────────────────────────────────────────────
            this.btnNuevoTransporte.Text = "Nuevo Transporte";
            this.btnNuevoTransporte.Location = new System.Drawing.Point(20, 428);
            this.btnNuevoTransporte.Size = new System.Drawing.Size(170, 36);
            this.btnNuevoTransporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoTransporte.FlatAppearance.BorderSize = 0;
            this.btnNuevoTransporte.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            this.btnNuevoTransporte.ForeColor = System.Drawing.Color.White;
            this.btnNuevoTransporte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTransporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoTransporte.TabIndex = 1;
            this.btnNuevoTransporte.Name = "btnNuevoTransporte";
            this.btnNuevoTransporte.Click += new System.EventHandler(this.btnNuevoTransporte_Click);

            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.Location = new System.Drawing.Point(200, 428);
            this.btnCambiarEstado.Size = new System.Drawing.Size(170, 36);
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstado.FlatAppearance.BorderSize = 1;
            this.btnCambiarEstado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            this.btnCambiarEstado.BackColor = System.Drawing.Color.White;
            this.btnCambiarEstado.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            this.btnCambiarEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.TabIndex = 2;
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);

            this.btnEliminarTransporte.Text = "Eliminar Transporte";
            this.btnEliminarTransporte.Location = new System.Drawing.Point(380, 428);
            this.btnEliminarTransporte.Size = new System.Drawing.Size(170, 36);
            this.btnEliminarTransporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTransporte.FlatAppearance.BorderSize = 1;
            this.btnEliminarTransporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnEliminarTransporte.BackColor = System.Drawing.Color.White;
            this.btnEliminarTransporte.ForeColor = System.Drawing.Color.FromArgb(178, 34, 34);
            this.btnEliminarTransporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminarTransporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTransporte.TabIndex = 3;
            this.btnEliminarTransporte.Name = "btnEliminarTransporte";
            this.btnEliminarTransporte.Click += new System.EventHandler(this.btnEliminarTransporte_Click);



            this.btnEmitirFactura.Text = "Emitir Remito";
            this.btnEmitirFactura.Location = new System.Drawing.Point(20, 472);
            this.btnEmitirFactura.Size = new System.Drawing.Size(220, 36);
            this.btnEmitirFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitirFactura.FlatAppearance.BorderSize = 0;
            this.btnEmitirFactura.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnEmitirFactura.ForeColor = System.Drawing.Color.White;
            this.btnEmitirFactura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEmitirFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmitirFactura.TabIndex = 5;
            this.btnEmitirFactura.Name = "btnEmitirFactura";
            this.btnEmitirFactura.Click += new System.EventHandler(this.btnEmitirRemito_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvTransportes);
            this.Controls.Add(this.btnNuevoTransporte);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.btnEliminarTransporte);
            this.Controls.Add(this.btnEmitirFactura);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportes)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvTransportes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTransporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVenta;
        private System.Windows.Forms.Button btnNuevoTransporte;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnEliminarTransporte;
        private System.Windows.Forms.Button btnEmitirFactura;
    }
}
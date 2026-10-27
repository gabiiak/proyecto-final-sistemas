namespace Login
{
    partial class UIRegistrarSolicitudCotizacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProducto = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colInsumo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblNombreProv = new System.Windows.Forms.Label();
            this.lblEmailProv = new System.Windows.Forms.Label();
            this.lblDireccionProv = new System.Windows.Forms.Label();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(720, 668);
            this.Text = "Emitir solicitud de cotización";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegistrarSolicitudCotizacion";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegistrarSolicitudCotizacion_Load);

            // ── NUMERIC CANTIDAD ─────────────────────────────────────
            this.numCantidad.Minimum = 1;
            this.numCantidad.Maximum = 1000000;
            this.numCantidad.Value = 1;
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCantidad.Name = "numCantidad";

            // ── DATAGRIDVIEW Y COLUMNAS ─────────────────────────────
            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "colInsumo";
            this.colInsumo.DisplayMember = "Nombre";
            this.colInsumo.ValueMember = "Id";
            this.colInsumo.ValueType = typeof(int);
            this.colInsumo.FillWeight = 50;

            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.Name = "colUnidad";
            this.colUnidad.ReadOnly = true;
            this.colUnidad.FillWeight = 25;

            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ValueType = typeof(decimal);
            this.colCantidad.FillWeight = 25;
            this.colCantidad.DefaultCellStyle.Format = "N2";

            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.AllowUserToAddRows = true;
            this.dgvDetalle.AllowUserToDeleteRows = true;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colInsumo, this.colUnidad, this.colCantidad
            });

            // ── LABELS Y CONTROLES ─────────────────────────────────
            this.lblProducto.Name = "lblProducto";
            this.cbProducto.Name = "cbProducto";
            this.lblCantidad.Name = "lblCantidad";
            this.btnCalcular.Name = "btnCalcular";
            this.lblDetalle.Name = "lblDetalle";
            this.lblProveedor.Name = "lblProveedor";
            this.cbProveedor.Name = "cbProveedor";
            this.lblNombreProv.Name = "lblNombreProv";
            this.lblEmailProv.Name = "lblEmailProv";
            this.lblDireccionProv.Name = "lblDireccionProv";
            this.btnEmitir.Name = "btnEmitir";
            this.btnCerrar.Name = "btnCerrar";

            // ── CONTROLS DEL FORM (las posiciones se arman en el constructor) ──
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.lblNombreProv);
            this.Controls.Add(this.lblEmailProv);
            this.Controls.Add(this.lblDireccionProv);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.btnCerrar);

            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label lblNombreProv;
        private System.Windows.Forms.Label lblEmailProv;
        private System.Windows.Forms.Label lblDireccionProv;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Button btnCerrar;
    }
}

namespace Login
{
    partial class UIReporteCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMes = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResumen = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Text = "Reporte mensual de compras";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "UIReporteCompras";

            // ── MES ─────────────────────────────────────────────────
            this.lblMes.Text = "Mes";
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(20, 20);
            this.lblMes.Name = "lblMes";

            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(20, 44);
            this.cbMes.Size = new System.Drawing.Size(150, 29);
            this.cbMes.TabIndex = 0;
            this.cbMes.Name = "cbMes";

            // ── AÑO ─────────────────────────────────────────────────
            this.lblAnio.Text = "Año";
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(190, 20);
            this.lblAnio.Name = "lblAnio";

            this.nudAnio.Location = new System.Drawing.Point(190, 44);
            this.nudAnio.Size = new System.Drawing.Size(90, 29);
            this.nudAnio.Minimum = 2000;
            this.nudAnio.Maximum = 2100;   // se ajusta en el constructor
            this.nudAnio.Value = 2024;     // se ajusta en el constructor
            this.nudAnio.TabIndex = 1;
            this.nudAnio.Name = "nudAnio";

            // ── BOTONES ─────────────────────────────────────────────
            this.btnGenerar.Location = new System.Drawing.Point(310, 40);
            this.btnGenerar.Size = new System.Drawing.Size(160, 34);
            this.btnGenerar.Text = "Generar reporte";
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            this.btnPdf.Location = new System.Drawing.Point(484, 40);
            this.btnPdf.Size = new System.Drawing.Size(150, 34);
            this.btnPdf.Text = "Exportar PDF";
            this.btnPdf.Enabled = false;
            this.btnPdf.TabIndex = 3;
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvCompras.Location = new System.Drawing.Point(20, 96);
            this.dgvCompras.Size = new System.Drawing.Size(860, 360);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.TabIndex = 4;
            this.dgvCompras.AutoGenerateColumns = false;
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowHeadersVisible = false;
            this.dgvCompras.RowTemplate.Height = 32;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompras.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompras.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCompras.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvCompras.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvCompras.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvCompras.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvCompras.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvCompras.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvCompras.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.colId.HeaderText = "Nº";
            this.colId.Name = "Id";
            this.colId.FillWeight = 40;

            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "Proveedor";
            this.colProveedor.FillWeight = 100;

            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "Fecha";
            this.colFecha.FillWeight = 60;
            this.colFecha.ValueType = typeof(System.DateTime);
            this.colFecha.DefaultCellStyle.Format = "dd-MM-yyyy";

            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "Total";
            this.colTotal.FillWeight = 80;
            this.colTotal.ValueType = typeof(double);
            this.colTotal.DefaultCellStyle.Format = "C2";
            this.colTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colPagado.HeaderText = "Pagado";
            this.colPagado.Name = "Pagado";
            this.colPagado.FillWeight = 80;
            this.colPagado.ValueType = typeof(double);
            this.colPagado.DefaultCellStyle.Format = "C2";
            this.colPagado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.FillWeight = 70;

            this.colPago.HeaderText = "Pago";
            this.colPago.Name = "Pago";
            this.colPago.FillWeight = 70;

            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colId, this.colProveedor, this.colFecha,
                this.colTotal, this.colPagado, this.colEstado, this.colPago
            });

            // ── RESUMEN ─────────────────────────────────────────────
            this.lblResumen.Location = new System.Drawing.Point(20, 466);
            this.lblResumen.Size = new System.Drawing.Size(860, 60);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Name = "lblResumen";

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.nudAnio);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.dgvCompras);
            this.Controls.Add(this.lblResumen);

            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPago;
        private System.Windows.Forms.Label lblResumen;

    }
}
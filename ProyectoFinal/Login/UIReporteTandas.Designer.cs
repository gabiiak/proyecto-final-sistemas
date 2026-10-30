namespace Login
{
    partial class UIReporteTandas
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
            this.dgvTandas = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCaducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResumen = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTandas)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Text = "Reporte mensual de tandas de producción";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "UIReporteTandas";

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
            this.dgvTandas.Location = new System.Drawing.Point(20, 96);
            this.dgvTandas.Size = new System.Drawing.Size(860, 360);
            this.dgvTandas.Name = "dgvTandas";
            this.dgvTandas.TabIndex = 4;
            this.dgvTandas.AutoGenerateColumns = false;
            this.dgvTandas.AllowUserToAddRows = false;
            this.dgvTandas.AllowUserToDeleteRows = false;
            this.dgvTandas.ReadOnly = true;
            this.dgvTandas.RowHeadersVisible = false;
            this.dgvTandas.RowTemplate.Height = 32;
            this.dgvTandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTandas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTandas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTandas.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvTandas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTandas.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvTandas.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvTandas.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvTandas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvTandas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTandas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvTandas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvTandas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvTandas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.colId.HeaderText = "Nº";
            this.colId.Name = "Id";
            this.colId.FillWeight = 35;

            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "Producto";
            this.colProducto.FillWeight = 100;

            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "Fecha";
            this.colFecha.FillWeight = 60;
            this.colFecha.ValueType = typeof(System.DateTime);
            this.colFecha.DefaultCellStyle.Format = "dd-MM-yyyy";

            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "Hora";
            this.colHora.FillWeight = 45;

            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "Cantidad";
            this.colCantidad.FillWeight = 55;
            this.colCantidad.ValueType = typeof(int);
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "Estado";
            this.colEstado.FillWeight = 70;

            this.colCaducidad.HeaderText = "Caducidad";
            this.colCaducidad.Name = "Caducidad";
            this.colCaducidad.FillWeight = 60;

            this.dgvTandas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colId, this.colProducto, this.colFecha, this.colHora,
                this.colCantidad, this.colEstado, this.colCaducidad
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
            this.Controls.Add(this.dgvTandas);
            this.Controls.Add(this.lblResumen);

            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTandas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.DataGridView dgvTandas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaducidad;
        private System.Windows.Forms.Label lblResumen;
    }
}
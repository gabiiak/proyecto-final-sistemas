using System.Drawing;

namespace Login
{
    partial class UIRegistrarPresupuesto
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
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.cbSolicitud = new System.Windows.Forms.ComboBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalKey = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(760, 580);
            this.Text = "Registrar presupuesto";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegistrarPresupuesto";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegistrarPresupuesto_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Registrar presupuesto";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(500, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── SOLICITUD ───────────────────────────────────────────
            this.lblSolicitud.Text = "Solicitud de cotización";
            this.lblSolicitud.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSolicitud.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSolicitud.Location = new System.Drawing.Point(20, 60);
            this.lblSolicitud.Size = new System.Drawing.Size(400, 18);
            this.lblSolicitud.Name = "lblSolicitud";

            this.cbSolicitud.Location = new System.Drawing.Point(20, 80);
            this.cbSolicitud.Size = new System.Drawing.Size(400, 30);
            this.cbSolicitud.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSolicitud.FormattingEnabled = true;
            this.cbSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSolicitud.TabIndex = 0;
            this.cbSolicitud.Name = "cbSolicitud";

            // ── DETALLE ─────────────────────────────────────────────
            this.lblDetalle.Text = "Detalle de insumos";
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalle.Location = new System.Drawing.Point(20, 124);
            this.lblDetalle.Size = new System.Drawing.Size(300, 22);
            this.lblDetalle.Name = "lblDetalle";

            this.dgvDetalle.Location = new System.Drawing.Point(20, 150);
            this.dgvDetalle.Size = new System.Drawing.Size(720, 290);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.TabIndex = 1;
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.RowTemplate.Height = 32;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.AutoGenerateColumns = false;

            this.colInsumo.HeaderText = "Insumo";
            this.colInsumo.Name = "Insumo";
            this.colInsumo.FillWeight = 40;
            this.colInsumo.ReadOnly = true;
            this.colInsumo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            this.colUnidad.HeaderText = "Unidad";
            this.colUnidad.Name = "Unidad";
            this.colUnidad.FillWeight = 15;
            this.colUnidad.ReadOnly = true;
            this.colUnidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "Cantidad";
            this.colCantidad.FillWeight = 15;
            this.colCantidad.ReadOnly = true;
            this.colCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCantidad.DefaultCellStyle.Format = "N2";

            this.colPrecioUnitario.HeaderText = "Precio unitario";
            this.colPrecioUnitario.Name = "PrecioUnitario";
            this.colPrecioUnitario.FillWeight = 15;
            this.colPrecioUnitario.ValueType = typeof(decimal);
            this.colPrecioUnitario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPrecioUnitario.DefaultCellStyle.Format = "#,##0.00";
            this.colPrecioUnitario.DefaultCellStyle.BackColor = Color.LightGreen;
            this.colPrecioUnitario.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "Subtotal";
            this.colSubtotal.FillWeight = 15;
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSubtotal.DefaultCellStyle.Format = "$#,##0.00";
            this.colSubtotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colInsumo, this.colUnidad, this.colCantidad, this.colPrecioUnitario, this.colSubtotal
            });

            // ── TOTAL ───────────────────────────────────────────────
            this.lblTotalKey.Text = "TOTAL";
            this.lblTotalKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalKey.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalKey.Location = new System.Drawing.Point(20, 452);
            this.lblTotalKey.Size = new System.Drawing.Size(120, 16);
            this.lblTotalKey.Name = "lblTotalKey";

            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 470);
            this.lblTotal.Size = new System.Drawing.Size(400, 28);
            this.lblTotal.Name = "lblTotal";

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSolicitud);
            this.Controls.Add(this.cbSolicitud);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblTotalKey);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.ComboBox cbSolicitud;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label lblTotalKey;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

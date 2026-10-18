namespace Login
{
    partial class UIEditarFechasCompra
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
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaRecepcion = new System.Windows.Forms.Label();
            this.dtpFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(360, 272);
            this.Text = "Editar fechas de la compra";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIEditarFechasCompra";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIEditarFechasCompra_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Editar fechas de la compra";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(320, 28);
            this.lblTitulo.Name = "lblTitulo";

            // ── FECHA DE COMPRA ─────────────────────────────────────
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(16, 92);
            this.dtpFecha.Size = new System.Drawing.Size(320, 28);
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.Name = "dtpFecha";

            // ── FECHA DE RECEPCIÓN ──────────────────────────────────
            this.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRecepcion.ShowCheckBox = true;
            this.dtpFechaRecepcion.Location = new System.Drawing.Point(16, 164);
            this.dtpFechaRecepcion.Size = new System.Drawing.Size(320, 28);
            this.dtpFechaRecepcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaRecepcion.TabIndex = 2;
            this.dtpFechaRecepcion.Name = "dtpFechaRecepcion";

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFechaRecepcion);
            this.Controls.Add(this.dtpFechaRecepcion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaRecepcion;
        private System.Windows.Forms.DateTimePicker dtpFechaRecepcion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

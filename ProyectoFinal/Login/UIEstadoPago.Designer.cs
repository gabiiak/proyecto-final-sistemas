namespace Login
{
    partial class UIEstadoPago
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
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblDeudaKey = new System.Windows.Forms.Label();
            this.labelDeuda = new System.Windows.Forms.Label();
            this.lblPagoKey = new System.Windows.Forms.Label();
            this.txtDeuda = new System.Windows.Forms.TextBox();
            this.btnPagoJusto = new System.Windows.Forms.Button();
            this.lblEstadoKey = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.bntPagarDeuda = new System.Windows.Forms.Button();
            this.btnAnularPago = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(380, 300);
            this.Text = "Estado de Pago";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIPaymentState";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIPaymentState_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Estado de Pago";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(340, 28);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL ───────────────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 52);
            this.pnlFormulario.Size = new System.Drawing.Size(340, 160);
            this.pnlFormulario.Name = "pnlFormulario";
            //this.pnlFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Deuda total (label key + label valor)
            this.lblDeudaKey.Text = "Deuda total";
            this.lblDeudaKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblDeudaKey.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDeudaKey.Location = new System.Drawing.Point(16, 12);
            this.lblDeudaKey.Size = new System.Drawing.Size(100, 16);
            this.lblDeudaKey.AutoSize = false;
            this.lblDeudaKey.Name = "lblDeudaKey";

            this.labelDeuda.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelDeuda.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.labelDeuda.Location = new System.Drawing.Point(16, 28);
            this.labelDeuda.Size = new System.Drawing.Size(200, 28);
            this.labelDeuda.AutoSize = false;
            this.labelDeuda.Name = "labelDeuda";

            // Pago a registrar + botón pago justo
            this.lblPagoKey.Text = "Pago a registrar ($)";
            this.lblPagoKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblPagoKey.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPagoKey.Location = new System.Drawing.Point(16, 68);
            this.lblPagoKey.Size = new System.Drawing.Size(160, 16);
            this.lblPagoKey.AutoSize = false;
            this.lblPagoKey.Name = "lblPagoKey";

            this.txtDeuda.Location = new System.Drawing.Point(16, 86);
            this.txtDeuda.Size = new System.Drawing.Size(200, 32);
            this.txtDeuda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeuda.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.txtDeuda.TabIndex = 0;
            this.txtDeuda.Name = "txtDeuda";

            this.btnPagoJusto.Text = "Pago justo";
            this.btnPagoJusto.Location = new System.Drawing.Point(228, 86);
            this.btnPagoJusto.Size = new System.Drawing.Size(96, 32);
            this.btnPagoJusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagoJusto.FlatAppearance.BorderSize = 1;
            this.btnPagoJusto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            this.btnPagoJusto.BackColor = System.Drawing.Color.White;
            this.btnPagoJusto.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            this.btnPagoJusto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPagoJusto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagoJusto.TabIndex = 1;
            this.btnPagoJusto.Name = "btnPagoJusto";
            this.btnPagoJusto.Click += new System.EventHandler(this.btnPagoJusto_Click);

            // Estado actual
            this.lblEstadoKey.Text = "Estado actual";
            this.lblEstadoKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblEstadoKey.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEstadoKey.Location = new System.Drawing.Point(16, 128);
            this.lblEstadoKey.Size = new System.Drawing.Size(100, 16);
            this.lblEstadoKey.AutoSize = false;
            this.lblEstadoKey.Name = "lblEstadoKey";

            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelEstado.Location = new System.Drawing.Point(120, 126);
            this.labelEstado.Size = new System.Drawing.Size(200, 22);
            this.labelEstado.AutoSize = false;
            this.labelEstado.Name = "labelEstado";

            this.pnlFormulario.Controls.Add(this.lblDeudaKey);
            this.pnlFormulario.Controls.Add(this.labelDeuda);
            this.pnlFormulario.Controls.Add(this.lblPagoKey);
            this.pnlFormulario.Controls.Add(this.txtDeuda);
            this.pnlFormulario.Controls.Add(this.btnPagoJusto);
            this.pnlFormulario.Controls.Add(this.lblEstadoKey);
            this.pnlFormulario.Controls.Add(this.labelEstado);

            // ── BOTONES ─────────────────────────────────────────────
            this.bntPagarDeuda.Text = "Pagar Deuda";
            this.bntPagarDeuda.Location = new System.Drawing.Point(20, 228);
            this.bntPagarDeuda.Size = new System.Drawing.Size(160, 40);
            this.bntPagarDeuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntPagarDeuda.FlatAppearance.BorderSize = 0;
            this.bntPagarDeuda.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            this.bntPagarDeuda.ForeColor = System.Drawing.Color.White;
            this.bntPagarDeuda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bntPagarDeuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntPagarDeuda.TabIndex = 2;
            this.bntPagarDeuda.Name = "bntPagarDeuda";
            this.bntPagarDeuda.Click += new System.EventHandler(this.bntPagarDeuda_Click);

            this.btnAnularPago.Text = "Anular Pago";
            this.btnAnularPago.Location = new System.Drawing.Point(196, 228);
            this.btnAnularPago.Size = new System.Drawing.Size(164, 40);
            this.btnAnularPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnularPago.FlatAppearance.BorderSize = 1;
            this.btnAnularPago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnAnularPago.BackColor = System.Drawing.Color.White;
            this.btnAnularPago.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnAnularPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAnularPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnularPago.TabIndex = 3;
            this.btnAnularPago.Name = "btnAnularPago";
            this.btnAnularPago.Click += new System.EventHandler(this.btnAnularPago_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.bntPagarDeuda);
            this.Controls.Add(this.btnAnularPago);

            this.pnlFormulario.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblDeudaKey;
        private System.Windows.Forms.Label labelDeuda;
        private System.Windows.Forms.Label lblPagoKey;
        private System.Windows.Forms.TextBox txtDeuda;
        private System.Windows.Forms.Button btnPagoJusto;
        private System.Windows.Forms.Label lblEstadoKey;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Button bntPagarDeuda;
        private System.Windows.Forms.Button btnAnularPago;
    }
}
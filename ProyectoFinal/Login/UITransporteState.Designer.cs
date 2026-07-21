namespace Login
{
    partial class UITransporteState
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
            this.lblSubtulo = new System.Windows.Forms.Label();
            this.btnProgramado = new System.Windows.Forms.Button();
            this.btnEnTransito = new System.Windows.Forms.Button();
            this.btnEntregado = new System.Windows.Forms.Button();
            this.btnCancelado = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.Text = "Estado del Transporte";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UITransporteState";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UITransporteState_Load);

            // ── TÍTULOS ─────────────────────────────────────────────
            this.lblTitulo.Text = "Estado del Transporte";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(260, 28);
            this.lblTitulo.Name = "lblTitulo";

            this.lblSubtulo.Text = "Cambiar estado a:";
            this.lblSubtulo.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSubtulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtulo.Location = new System.Drawing.Point(20, 50);
            this.lblSubtulo.Size = new System.Drawing.Size(260, 18);
            this.lblSubtulo.Name = "lblSubtulo";

            // ── BOTONES DE ESTADO ───────────────────────────────────
            // Mismos 4 estados que maneja colEstado en la grilla de transportes.
            // El estado CANCELADO queda separado visualmente, igual que en
            // UIOrderState, por ser un estado final "negativo".

            // PROGRAMADO
            ConfigurarBotonEstado(this.btnProgramado, "PROGRAMADO",
                new System.Drawing.Point(20, 80),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 0);
            this.btnProgramado.Click += new System.EventHandler(this.btnProgramado_Click);

            // EN TRÁNSITO
            ConfigurarBotonEstado(this.btnEnTransito, "EN TRÁNSITO",
                new System.Drawing.Point(20, 136),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 1);
            this.btnEnTransito.Click += new System.EventHandler(this.btnEnTransito_Click);

            // ENTREGADO — estado final positivo
            ConfigurarBotonEstado(this.btnEntregado, "ENTREGADO",
                new System.Drawing.Point(20, 192),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 2);
            this.btnEntregado.Click += new System.EventHandler(this.btnEntregado_Click);

            // CANCELADO — estado final negativo, separado visualmente
            ConfigurarBotonEstado(this.btnCancelado, "CANCELADO",
                new System.Drawing.Point(20, 264),
                System.Drawing.Color.FromArgb(150, 30, 30),
                System.Drawing.Color.White, 3);
            this.btnCancelado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnCancelado.Click += new System.EventHandler(this.btnCancelado_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtulo);
            this.Controls.Add(this.btnProgramado);
            this.Controls.Add(this.btnEnTransito);
            this.Controls.Add(this.btnEntregado);
            this.Controls.Add(this.btnCancelado);

            this.ResumeLayout(false);
        }

        private void ConfigurarBotonEstado(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, System.Drawing.Color backColor,
            System.Drawing.Color foreColor, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(260, 44);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtulo;
        private System.Windows.Forms.Button btnProgramado;
        private System.Windows.Forms.Button btnEnTransito;
        private System.Windows.Forms.Button btnEntregado;
        private System.Windows.Forms.Button btnCancelado;
    }
}
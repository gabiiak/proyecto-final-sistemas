namespace Login
{
    partial class UIEstadoTransporte
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


            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtulo);
            this.Controls.Add(this.btnProgramado);
            this.Controls.Add(this.btnEnTransito);
            this.Controls.Add(this.btnEntregado);
            this.Controls.Add(this.btnCancelado);

            this.ResumeLayout(false);
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
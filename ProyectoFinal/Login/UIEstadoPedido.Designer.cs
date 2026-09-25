namespace Login
{
    partial class UIEstadoPedido
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Text = "Estado del Pedido";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIOrderState";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIOrderState_Load);

            // ── TÍTULOS ─────────────────────────────────────────────
            this.lblTitulo.Text = "Estado del Pedido";
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
            // Cada estado tiene un color semántico distinto
            // para que de un vistazo se entienda la progresión

            // PREPARACION — azul (estado activo/en curso)
            

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtulo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);

            this.ResumeLayout(false);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}
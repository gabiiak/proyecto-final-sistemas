namespace Login
{
    partial class UIEstadoTanda
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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnPendiente = new System.Windows.Forms.Button();
            this.btnEnProceso = new System.Windows.Forms.Button();
            this.btnTerminada = new System.Windows.Forms.Button();
            this.btnCancelada = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.Text = "Estado de Tanda";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIEstadoTanda_Load);

            // Títulos
            this.lblTitulo.Text = "Estado de Tanda";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(260, 28);

            this.lblSubtitulo.Text = "Cambiar estado a:";
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 50);
            this.lblSubtitulo.Size = new System.Drawing.Size(260, 18);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.btnPendiente);
            this.Controls.Add(this.btnEnProceso);
            this.Controls.Add(this.btnTerminada);
            this.Controls.Add(this.btnCancelada);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnPendiente;
        private System.Windows.Forms.Button btnEnProceso;
        private System.Windows.Forms.Button btnTerminada;
        private System.Windows.Forms.Button btnCancelada;
    }
}
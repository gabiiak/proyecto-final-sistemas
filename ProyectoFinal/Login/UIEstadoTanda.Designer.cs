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

            // Botones
            ConfigurarBotonEstado(this.btnPendiente, "PENDIENTE", new System.Drawing.Point(20, 80), System.Drawing.Color.FromArgb(24, 95, 165), System.Drawing.Color.White, 0);
            this.btnPendiente.Click += new System.EventHandler(this.btnPendiente_Click);

            ConfigurarBotonEstado(this.btnEnProceso, "EN PROCESO", new System.Drawing.Point(20, 136), System.Drawing.Color.FromArgb(24, 95, 165), System.Drawing.Color.White, 1);
            this.btnEnProceso.Click += new System.EventHandler(this.btnEnProceso_Click);

            ConfigurarBotonEstado(this.btnTerminada, "TERMINADA", new System.Drawing.Point(20, 192), System.Drawing.Color.FromArgb(24, 95, 165), System.Drawing.Color.White, 2);
            this.btnTerminada.Click += new System.EventHandler(this.btnTerminada_Click);

            ConfigurarBotonEstado(this.btnCancelada, "CANCELADA", new System.Drawing.Point(20, 260), System.Drawing.Color.FromArgb(150, 30, 30), System.Drawing.Color.White, 3);
            this.btnCancelada.Click += new System.EventHandler(this.btnCancelada_Click);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.btnPendiente);
            this.Controls.Add(this.btnEnProceso);
            this.Controls.Add(this.btnTerminada);
            this.Controls.Add(this.btnCancelada);

            this.ResumeLayout(false);
        }

        private void ConfigurarBotonEstado(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, System.Drawing.Color backColor, System.Drawing.Color foreColor, int tabIndex)
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

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnPendiente;
        private System.Windows.Forms.Button btnEnProceso;
        private System.Windows.Forms.Button btnTerminada;
        private System.Windows.Forms.Button btnCancelada;
    }
}
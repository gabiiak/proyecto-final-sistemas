namespace Login
{
    partial class UIRegistrarDetalleTanda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInsumo = new System.Windows.Forms.Label();
            this.cbInsumo = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcionInsumo = new System.Windows.Forms.TextBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.btnRegistrarDetalle = new System.Windows.Forms.Button();
            this.btnSalirDetalle = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(420, 396);
            this.Text = "Agregar Detalle de Tanda";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegistrarDetalleTanda_Load);

            // Título
            this.lblTitulo.Text = "Agregar Insumo / Detalle";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(380, 28);

            // Panel Formulario
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 52);
            this.pnlFormulario.Size = new System.Drawing.Size(380, 275);

            // Insumo
           
            this.numUpDownCantidad.Location = new System.Drawing.Point(16, 206);
            this.numUpDownCantidad.Size = new System.Drawing.Size(100, 30);
            this.numUpDownCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUpDownCantidad.Maximum = 100000;
            this.numUpDownCantidad.TabIndex = 3;

            this.lblUnidades.Text = "unidades";
            this.lblUnidades.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblUnidades.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblUnidades.Location = new System.Drawing.Point(125, 210);
            this.lblUnidades.Size = new System.Drawing.Size(80, 20);

            this.pnlFormulario.Controls.Add(this.lblInsumo);
            this.pnlFormulario.Controls.Add(this.cbInsumo);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtDescripcionInsumo);
            this.pnlFormulario.Controls.Add(this.lblEmpleado);
            this.pnlFormulario.Controls.Add(this.cbEmpleado);
            this.pnlFormulario.Controls.Add(this.lblCantidad);
            this.pnlFormulario.Controls.Add(this.numUpDownCantidad);
            this.pnlFormulario.Controls.Add(this.lblUnidades);

            // Botones
            

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.btnRegistrarDetalle);
            this.Controls.Add(this.btnSalirDetalle);

            this.pnlFormulario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cbInsumo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcionInsumo;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cbEmpleado;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numUpDownCantidad;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Button btnRegistrarDetalle;
        private System.Windows.Forms.Button btnSalirDetalle;
    }
}
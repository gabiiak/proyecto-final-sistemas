using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;

namespace Login
{
    partial class UIRegistrarTanda
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
            this.txtCantidadTanda = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvTanda_Detalles = new System.Windows.Forms.DataGridView();
            this.Insumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.btnQuitarDetalle = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.labelTotalCantidad = new System.Windows.Forms.Label();
            this.lblEstadoHint = new System.Windows.Forms.Label();
            this.btnRegistrarTanda = new System.Windows.Forms.Button();
            this.lblCantidadProducto = new System.Windows.Forms.Label();
            this.pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanda_Detalles)).BeginInit();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.lblCantidadProducto);
            this.pnlFormulario.Controls.Add(this.txtCantidadTanda);
            this.pnlFormulario.Controls.Add(this.lblProducto);
            this.pnlFormulario.Controls.Add(this.cbProducto);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.txtFecha);
            this.pnlFormulario.Controls.Add(this.lblHora);
            this.pnlFormulario.Controls.Add(this.txtHora);
            this.pnlFormulario.Location = new System.Drawing.Point(20, 56);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(550, 148);
            this.pnlFormulario.TabIndex = 1;
            // 
            // txtCantidadTanda
            // 
            this.txtCantidadTanda.Location = new System.Drawing.Point(332, 31);
            this.txtCantidadTanda.Name = "txtCantidadTanda";
            this.txtCantidadTanda.Size = new System.Drawing.Size(100, 25);
            this.txtCantidadTanda.TabIndex = 6;
            // 
            // lblProducto
            // 
            this.lblProducto.Location = new System.Drawing.Point(-1, 3);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(100, 23);
            this.lblProducto.TabIndex = 0;
            // 
            // cbProducto
            // 
            this.cbProducto.Location = new System.Drawing.Point(5, 31);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(145, 25);
            this.cbProducto.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(0, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 23);
            this.lblFecha.TabIndex = 2;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(0, 0);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 25);
            this.txtFecha.TabIndex = 3;
            // 
            // lblHora
            // 
            this.lblHora.Location = new System.Drawing.Point(0, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(100, 23);
            this.lblHora.TabIndex = 4;
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(0, 0);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(100, 25);
            this.txtHora.TabIndex = 5;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Tanda de Producción";
            // 
            // lblDetalles
            // 
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(300, 24);
            this.lblDetalles.TabIndex = 2;
            this.lblDetalles.Text = "Insumos y Personal Asignado";
            // 
            // dgvTanda_Detalles
            // 
            this.dgvTanda_Detalles.AllowUserToAddRows = false;
            this.dgvTanda_Detalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTanda_Detalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvTanda_Detalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTanda_Detalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Insumo,
            this.Cantidad,
            this.UnidadMedida});
            this.dgvTanda_Detalles.Location = new System.Drawing.Point(20, 248);
            this.dgvTanda_Detalles.Name = "dgvTanda_Detalles";
            this.dgvTanda_Detalles.ReadOnly = true;
            this.dgvTanda_Detalles.RowHeadersVisible = false;
            this.dgvTanda_Detalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTanda_Detalles.Size = new System.Drawing.Size(560, 200);
            this.dgvTanda_Detalles.TabIndex = 3;
            // 
            // Insumo
            // 
            this.Insumo.HeaderText = "Insumo";
            this.Insumo.Name = "Insumo";
            this.Insumo.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // UnidadMedida
            // 
            this.UnidadMedida.HeaderText = "Unidad";
            this.UnidadMedida.Name = "UnidadMedida";
            this.UnidadMedida.ReadOnly = true;
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.Location = new System.Drawing.Point(0, 0);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarDetalle.TabIndex = 4;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // btnQuitarDetalle
            // 
            this.btnQuitarDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnQuitarDetalle.Location = new System.Drawing.Point(0, 0);
            this.btnQuitarDetalle.Name = "btnQuitarDetalle";
            this.btnQuitarDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarDetalle.TabIndex = 5;
            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(251)))));
            this.pnlTotal.Controls.Add(this.lblTotalLabel);
            this.pnlTotal.Controls.Add(this.labelTotalCantidad);
            this.pnlTotal.Location = new System.Drawing.Point(20, 512);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(480, 80);
            this.pnlTotal.TabIndex = 6;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 12);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(250, 16);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "TOTAL UNIDADES PRODUCIDAS";
            // 
            // labelTotalCantidad
            // 
            this.labelTotalCantidad.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTotalCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.labelTotalCantidad.Location = new System.Drawing.Point(16, 32);
            this.labelTotalCantidad.Name = "labelTotalCantidad";
            this.labelTotalCantidad.Size = new System.Drawing.Size(200, 32);
            this.labelTotalCantidad.TabIndex = 1;
            this.labelTotalCantidad.Text = "0";
            // 
            // lblEstadoHint
            // 
            this.lblEstadoHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblEstadoHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            this.lblEstadoHint.Location = new System.Drawing.Point(20, 600);
            this.lblEstadoHint.Name = "lblEstadoHint";
            this.lblEstadoHint.Size = new System.Drawing.Size(480, 18);
            this.lblEstadoHint.TabIndex = 7;
            this.lblEstadoHint.Text = "Las tandas creadas inician automáticamente en estado PENDIENTE.";
            // 
            // btnRegistrarTanda
            // 
            this.btnRegistrarTanda.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarTanda.Location = new System.Drawing.Point(0, 0);
            this.btnRegistrarTanda.Name = "btnRegistrarTanda";
            this.btnRegistrarTanda.Size = new System.Drawing.Size(480, 44);
            this.btnRegistrarTanda.TabIndex = 8;
            this.btnRegistrarTanda.Click += new System.EventHandler(this.btnRegistrarTanda_Click);
            // 
            // lblCantidadProducto
            // 
            this.lblCantidadProducto.AutoSize = true;
            this.lblCantidadProducto.Location = new System.Drawing.Point(262, 12);
            this.lblCantidadProducto.Name = "lblCantidadProducto";
            this.lblCantidadProducto.Size = new System.Drawing.Size(45, 19);
            this.lblCantidadProducto.TabIndex = 7;
            this.lblCantidadProducto.Text = "label1";
            // 
            // UIRegistrarTanda
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(660, 684);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvTanda_Detalles);
            this.Controls.Add(this.btnAgregarDetalle);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.lblEstadoHint);
            this.Controls.Add(this.btnRegistrarTanda);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegistrarTanda";
            this.Text = "Registrar Tanda de Producción";
            this.Load += new System.EventHandler(this.UIRegistrarTanda_Load);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanda_Detalles)).EndInit();
            this.pnlTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvTanda_Detalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadMedida;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Button btnQuitarDetalle;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label labelTotalCantidad;
        private System.Windows.Forms.Label lblEstadoHint;
        private System.Windows.Forms.Button btnRegistrarTanda;
        private System.Windows.Forms.TextBox txtCantidadTanda;
        private System.Windows.Forms.Label lblCantidadProducto;
    }
}
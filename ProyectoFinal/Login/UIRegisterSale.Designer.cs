//namespace Login
//{
//    partial class UIRegisterSale
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.label8 = new System.Windows.Forms.Label();
//            this.btnPagoJusto = new System.Windows.Forms.Button();
//            this.label7 = new System.Windows.Forms.Label();
//            this.txtFecha = new System.Windows.Forms.TextBox();
//            this.label6 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.txtPagoRecibido = new System.Windows.Forms.TextBox();
//            this.btnQuitarDetalle = new System.Windows.Forms.Button();
//            this.btnRegistrarVenta = new System.Windows.Forms.Button();
//            this.btnAgregarDetalle = new System.Windows.Forms.Button();
//            this.labelTotal = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.dgvVenta_DetalleVenta = new System.Windows.Forms.DataGridView();
//            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.cbMetodo = new System.Windows.Forms.ComboBox();
//            this.cbCliente = new System.Windows.Forms.ComboBox();
//            this.panel1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.label8);
//            this.panel1.Controls.Add(this.btnPagoJusto);
//            this.panel1.Controls.Add(this.label7);
//            this.panel1.Controls.Add(this.txtFecha);
//            this.panel1.Controls.Add(this.label6);
//            this.panel1.Controls.Add(this.label5);
//            this.panel1.Controls.Add(this.label4);
//            this.panel1.Controls.Add(this.txtPagoRecibido);
//            this.panel1.Controls.Add(this.btnQuitarDetalle);
//            this.panel1.Controls.Add(this.btnRegistrarVenta);
//            this.panel1.Controls.Add(this.btnAgregarDetalle);
//            this.panel1.Controls.Add(this.labelTotal);
//            this.panel1.Controls.Add(this.label3);
//            this.panel1.Controls.Add(this.dgvVenta_DetalleVenta);
//            this.panel1.Controls.Add(this.label2);
//            this.panel1.Controls.Add(this.label1);
//            this.panel1.Controls.Add(this.cbMetodo);
//            this.panel1.Controls.Add(this.cbCliente);
//            this.panel1.Location = new System.Drawing.Point(12, 12);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(373, 597);
//            this.panel1.TabIndex = 0;
//            // 
//            // label8
//            // 
//            this.label8.AutoSize = true;
//            this.label8.Location = new System.Drawing.Point(75, 367);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(13, 13);
//            this.label8.TabIndex = 21;
//            this.label8.Text = "$";
//            // 
//            // btnPagoJusto
//            // 
//            this.btnPagoJusto.Location = new System.Drawing.Point(253, 410);
//            this.btnPagoJusto.Name = "btnPagoJusto";
//            this.btnPagoJusto.Size = new System.Drawing.Size(104, 23);
//            this.btnPagoJusto.TabIndex = 20;
//            this.btnPagoJusto.Text = "Pago Justo";
//            this.btnPagoJusto.UseVisualStyleBackColor = true;
//            this.btnPagoJusto.Click += new System.EventHandler(this.btnPagoJusto_Click);
//            // 
//            // label7
//            // 
//            this.label7.AutoSize = true;
//            this.label7.Location = new System.Drawing.Point(11, 449);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(98, 13);
//            this.label7.TabIndex = 19;
//            this.label7.Text = "Fecha transacción:";
//            // 
//            // txtFecha
//            // 
//            this.txtFecha.Location = new System.Drawing.Point(121, 446);
//            this.txtFecha.Name = "txtFecha";
//            this.txtFecha.Size = new System.Drawing.Size(236, 20);
//            this.txtFecha.TabIndex = 18;
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label6.Location = new System.Drawing.Point(10, 11);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(136, 20);
//            this.label6.TabIndex = 17;
//            this.label6.Text = "Registrar Venta";
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
//            this.label5.Location = new System.Drawing.Point(11, 487);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(348, 13);
//            this.label5.TabIndex = 16;
//            this.label5.Text = "Estados:  0 o menos del total -> PENDIENTE // pago justo ->  PAGADO";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(11, 415);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(83, 13);
//            this.label4.TabIndex = 15;
//            this.label4.Text = "Pago Recibido: ";
//            // 
//            // txtPagoRecibido
//            // 
//            this.txtPagoRecibido.Location = new System.Drawing.Point(98, 412);
//            this.txtPagoRecibido.Name = "txtPagoRecibido";
//            this.txtPagoRecibido.Size = new System.Drawing.Size(141, 20);
//            this.txtPagoRecibido.TabIndex = 14;
//            // 
//            // btnQuitarDetalle
//            // 
//            this.btnQuitarDetalle.Location = new System.Drawing.Point(187, 305);
//            this.btnQuitarDetalle.Name = "btnQuitarDetalle";
//            this.btnQuitarDetalle.Size = new System.Drawing.Size(170, 23);
//            this.btnQuitarDetalle.TabIndex = 12;
//            this.btnQuitarDetalle.Text = "Quitar detalle";
//            this.btnQuitarDetalle.UseVisualStyleBackColor = true;
//            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);
//            // 
//            // btnRegistrarVenta
//            // 
//            this.btnRegistrarVenta.Location = new System.Drawing.Point(14, 518);
//            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
//            this.btnRegistrarVenta.Size = new System.Drawing.Size(195, 67);
//            this.btnRegistrarVenta.TabIndex = 9;
//            this.btnRegistrarVenta.Text = "Registrar Venta";
//            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
//            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
//            // 
//            // btnAgregarDetalle
//            // 
//            this.btnAgregarDetalle.Location = new System.Drawing.Point(14, 305);
//            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
//            this.btnAgregarDetalle.Size = new System.Drawing.Size(170, 23);
//            this.btnAgregarDetalle.TabIndex = 8;
//            this.btnAgregarDetalle.Text = "Agregar Detalle";
//            this.btnAgregarDetalle.UseVisualStyleBackColor = true;
//            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
//            // 
//            // labelTotal
//            // 
//            this.labelTotal.AutoSize = true;
//            this.labelTotal.Location = new System.Drawing.Point(87, 367);
//            this.labelTotal.Name = "labelTotal";
//            this.labelTotal.Size = new System.Drawing.Size(53, 13);
//            this.labelTotal.TabIndex = 6;
//            this.labelTotal.Text = "labelTotal";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label3.Location = new System.Drawing.Point(10, 362);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(59, 20);
//            this.label3.TabIndex = 5;
//            this.label3.Text = "Total: ";
//            // 
//            // dgvVenta_DetalleVenta
//            // 
//            this.dgvVenta_DetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvVenta_DetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.Producto,
//            this.Cantidad,
//            this.SubTotal});
//            this.dgvVenta_DetalleVenta.Location = new System.Drawing.Point(14, 106);
//            this.dgvVenta_DetalleVenta.Name = "dgvVenta_DetalleVenta";
//            this.dgvVenta_DetalleVenta.Size = new System.Drawing.Size(343, 193);
//            this.dgvVenta_DetalleVenta.TabIndex = 4;
//            // 
//            // Producto
//            // 
//            this.Producto.HeaderText = "Producto";
//            this.Producto.Name = "Producto";
//            // 
//            // Cantidad
//            // 
//            this.Cantidad.HeaderText = "Cantidad";
//            this.Cantidad.Name = "Cantidad";
//            // 
//            // SubTotal
//            // 
//            this.SubTotal.HeaderText = "SubTotal";
//            this.SubTotal.Name = "SubTotal";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(11, 82);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(88, 13);
//            this.label2.TabIndex = 3;
//            this.label2.Text = "Método de pago:";
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(11, 54);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(45, 13);
//            this.label1.TabIndex = 2;
//            this.label1.Text = "Cliente: ";
//            // 
//            // cbMetodo
//            // 
//            this.cbMetodo.FormattingEnabled = true;
//            this.cbMetodo.Location = new System.Drawing.Point(128, 74);
//            this.cbMetodo.Name = "cbMetodo";
//            this.cbMetodo.Size = new System.Drawing.Size(229, 21);
//            this.cbMetodo.TabIndex = 1;
//            // 
//            // cbCliente
//            // 
//            this.cbCliente.FormattingEnabled = true;
//            this.cbCliente.Location = new System.Drawing.Point(128, 46);
//            this.cbCliente.Name = "cbCliente";
//            this.cbCliente.Size = new System.Drawing.Size(229, 21);
//            this.cbCliente.TabIndex = 0;
//            // 
//            // UIRegisterSale
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(398, 620);
//            this.Controls.Add(this.panel1);
//            this.Name = "UIRegisterSale";
//            this.Text = "UIRegisterSale";
//            this.Load += new System.EventHandler(this.UIRegisterSale_Load);
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.ComboBox cbMetodo;
//        private System.Windows.Forms.ComboBox cbCliente;
//        private System.Windows.Forms.Label labelTotal;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.DataGridView dgvVenta_DetalleVenta;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Button btnQuitarDetalle;
//        private System.Windows.Forms.Button btnRegistrarVenta;
//        private System.Windows.Forms.Button btnAgregarDetalle;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.TextBox txtPagoRecibido;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
//        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.TextBox txtFecha;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.Button btnPagoJusto;
//        private System.Windows.Forms.Label label8;
//    }
//}
namespace Login
{
    partial class UIRegisterSale
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.cbMetodo = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvVenta_DetalleVenta = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.btnQuitarDetalle = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalSimbolo = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.lblPagoRecibido = new System.Windows.Forms.Label();
            this.txtPagoRecibido = new System.Windows.Forms.TextBox();
            this.btnPagoJusto = new System.Windows.Forms.Button();
            this.lblEstadoHint = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(520, 680);
            this.Text = "Registrar Venta";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegisterSale";
            this.Load += new System.EventHandler(this.UIRegisterSale_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Registrar Venta";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL FORMULARIO ────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 56);
            this.pnlFormulario.Size = new System.Drawing.Size(480, 148);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Fila 1: Cliente + Método de pago
            ConfigurarLabel(this.lblCliente, "Cliente", new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblMetodo, "Método de pago", new System.Drawing.Point(256, 16));
            ConfigurarCombo(this.cbCliente, new System.Drawing.Point(16, 36), new System.Drawing.Size(220, 32), 0);
            ConfigurarCombo(this.cbMetodo, new System.Drawing.Point(256, 36), new System.Drawing.Size(208, 32), 1);

            // Fila 2: Fecha transacción
            ConfigurarLabel(this.lblFecha, "Fecha de transacción", new System.Drawing.Point(16, 84));
            ConfigurarTextBox(this.txtFecha, new System.Drawing.Point(16, 104), new System.Drawing.Size(448, 32), 2);

            this.pnlFormulario.Controls.Add(this.lblCliente);
            this.pnlFormulario.Controls.Add(this.cbCliente);
            this.pnlFormulario.Controls.Add(this.lblMetodo);
            this.pnlFormulario.Controls.Add(this.cbMetodo);
            this.pnlFormulario.Controls.Add(this.lblFecha);
            this.pnlFormulario.Controls.Add(this.txtFecha);

            // ── LABEL DETALLES ──────────────────────────────────────
            this.lblDetalles.Text = "Detalle de la venta";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Size = new System.Drawing.Size(300, 24);
            this.lblDetalles.Name = "lblDetalles";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvVenta_DetalleVenta.Location = new System.Drawing.Point(20, 248);
            this.dgvVenta_DetalleVenta.Size = new System.Drawing.Size(480, 200);
            this.dgvVenta_DetalleVenta.Name = "dgvVenta_DetalleVenta";
            this.dgvVenta_DetalleVenta.TabIndex = 3;
            this.dgvVenta_DetalleVenta.AllowUserToAddRows = false;
            this.dgvVenta_DetalleVenta.AllowUserToDeleteRows = false;
            this.dgvVenta_DetalleVenta.ReadOnly = true;
            this.dgvVenta_DetalleVenta.RowTemplate.Height = 35;
            this.dgvVenta_DetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenta_DetalleVenta.RowHeadersVisible = false;
            this.dgvVenta_DetalleVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVenta_DetalleVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvVenta_DetalleVenta.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvVenta_DetalleVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVenta_DetalleVenta.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvVenta_DetalleVenta.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvVenta_DetalleVenta.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvVenta_DetalleVenta.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvVenta_DetalleVenta.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvVenta_DetalleVenta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvVenta_DetalleVenta.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvVenta_DetalleVenta.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvVenta_DetalleVenta.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.SubTotal.HeaderText = "Subtotal";
            this.SubTotal.Name = "SubTotal";

            this.dgvVenta_DetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.Producto, this.Cantidad, this.SubTotal
            });

            // ── BOTONES DETALLE ─────────────────────────────────────
            ConfigurarBotonPrimario(this.btnAgregarDetalle, "Agregar detalle",
                new System.Drawing.Point(20, 460), 4);
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);

            ConfigurarBotonSecundario(this.btnQuitarDetalle, "Quitar detalle",
                new System.Drawing.Point(176, 460), 5);
            this.btnQuitarDetalle.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnQuitarDetalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);

            // ── PANEL TOTAL ─────────────────────────────────────────
            // Zona de resumen: total + pago recibido
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 512);
            this.pnlTotal.Size = new System.Drawing.Size(480, 80);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            this.lblTotalLabel.Text = "TOTAL";
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(16, 10);
            this.lblTotalLabel.Size = new System.Drawing.Size(60, 16);
            this.lblTotalLabel.Name = "lblTotalLabel";

            this.lblTotalSimbolo.Text = "$";
            this.lblTotalSimbolo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTotalSimbolo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalSimbolo.Location = new System.Drawing.Point(16, 28);
            this.lblTotalSimbolo.Size = new System.Drawing.Size(24, 32);
            this.lblTotalSimbolo.Name = "lblTotalSimbolo";

            this.labelTotal.Text = "0,00";
            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(44, 28);
            this.labelTotal.Size = new System.Drawing.Size(160, 32);
            this.labelTotal.Name = "labelTotal";

            // Pago recibido — lado derecho del panel total
            ConfigurarLabel(this.lblPagoRecibido, "Pago recibido ($)",
                new System.Drawing.Point(260, 10));
            ConfigurarTextBox(this.txtPagoRecibido,
                new System.Drawing.Point(260, 28), new System.Drawing.Size(120, 32), 6);

            ConfigurarBotonSecundario(this.btnPagoJusto, "Pago justo",
                new System.Drawing.Point(392, 28), 7);
            this.btnPagoJusto.Size = new System.Drawing.Size(72, 32);
            this.btnPagoJusto.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPagoJusto.Click += new System.EventHandler(this.btnPagoJusto_Click);

            this.pnlTotal.Controls.Add(this.lblTotalLabel);
            this.pnlTotal.Controls.Add(this.lblTotalSimbolo);
            this.pnlTotal.Controls.Add(this.labelTotal);
            this.pnlTotal.Controls.Add(this.lblPagoRecibido);
            this.pnlTotal.Controls.Add(this.txtPagoRecibido);
            this.pnlTotal.Controls.Add(this.btnPagoJusto);

            // ── HINT DE ESTADOS ─────────────────────────────────────
            this.lblEstadoHint.Text = "≤ 0 o sin pago → PENDIENTE   |   pago justo → PAGADO";
            this.lblEstadoHint.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblEstadoHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblEstadoHint.Location = new System.Drawing.Point(20, 600);
            this.lblEstadoHint.Size = new System.Drawing.Size(480, 18);
            this.lblEstadoHint.Name = "lblEstadoHint";

            // ── BOTÓN REGISTRAR ─────────────────────────────────────
            ConfigurarBotonPrimario(this.btnRegistrarVenta, "Registrar Venta",
                new System.Drawing.Point(20, 624), 8);
            this.btnRegistrarVenta.Size = new System.Drawing.Size(480, 44);
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvVenta_DetalleVenta);
            this.Controls.Add(this.btnAgregarDetalle);
            this.Controls.Add(this.btnQuitarDetalle);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.lblEstadoHint);
            this.Controls.Add(this.btnRegistrarVenta);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).EndInit();
            this.ResumeLayout(false);
        }

        // ── HELPERS ──────────────────────────────────────────────
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(220, 18);
            lbl.AutoSize = false;
        }

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
        {
            txt.Location = ubicacion;
            txt.Size = tamaño;
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            txt.TabIndex = tabIndex;
        }

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
        {
            cb.Location = ubicacion;
            cb.Size = tamaño;
            cb.Font = new System.Drawing.Font("Segoe UI", 10F);
            cb.FormattingEnabled = true;
            cb.TabIndex = tabIndex;
            cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cb.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
        }

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(140, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(140, 36);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var panel = sender as System.Windows.Forms.Panel;
            var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(211, 209, 199), 1f);
            var rect = new System.Drawing.Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            int r = 8;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
            path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
            path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            e.Graphics.DrawPath(pen, path);
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.ComboBox cbMetodo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvVenta_DetalleVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Button btnQuitarDetalle;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalSimbolo;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label lblPagoRecibido;
        private System.Windows.Forms.TextBox txtPagoRecibido;
        private System.Windows.Forms.Button btnPagoJusto;
        private System.Windows.Forms.Label lblEstadoHint;
        private System.Windows.Forms.Button btnRegistrarVenta;
    }
}
//namespace Login
//{
//    partial class UIConsultSale
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
//            this.dgvConsultaVenta = new System.Windows.Forms.DataGridView();
//            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.labelCliente = new System.Windows.Forms.Label();
//            this.labelMetodo = new System.Windows.Forms.Label();
//            this.labelFecha = new System.Windows.Forms.Label();
//            this.labelEstadoPago = new System.Windows.Forms.Label();
//            this.labelEstadoPedido = new System.Windows.Forms.Label();
//            this.labelTotal = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.label6 = new System.Windows.Forms.Label();
//            this.label7 = new System.Windows.Forms.Label();
//            this.btnEmitirFactura = new System.Windows.Forms.Button();
//            this.btnSalir = new System.Windows.Forms.Button();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVenta)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // dgvConsultaVenta
//            // 
//            this.dgvConsultaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvConsultaVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.Nombre,
//            this.Cantidad,
//            this.SubTotal});
//            this.dgvConsultaVenta.Location = new System.Drawing.Point(26, 195);
//            this.dgvConsultaVenta.Name = "dgvConsultaVenta";
//            this.dgvConsultaVenta.Size = new System.Drawing.Size(343, 230);
//            this.dgvConsultaVenta.TabIndex = 0;
//            // 
//            // Nombre
//            // 
//            this.Nombre.HeaderText = "Nombre";
//            this.Nombre.Name = "Nombre";
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
//            // labelCliente
//            // 
//            this.labelCliente.AutoSize = true;
//            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelCliente.Location = new System.Drawing.Point(175, 44);
//            this.labelCliente.Name = "labelCliente";
//            this.labelCliente.Size = new System.Drawing.Size(51, 20);
//            this.labelCliente.TabIndex = 1;
//            this.labelCliente.Text = "label1";
//            // 
//            // labelMetodo
//            // 
//            this.labelMetodo.AutoSize = true;
//            this.labelMetodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelMetodo.Location = new System.Drawing.Point(175, 75);
//            this.labelMetodo.Name = "labelMetodo";
//            this.labelMetodo.Size = new System.Drawing.Size(51, 20);
//            this.labelMetodo.TabIndex = 2;
//            this.labelMetodo.Text = "label2";
//            // 
//            // labelFecha
//            // 
//            this.labelFecha.AutoSize = true;
//            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelFecha.Location = new System.Drawing.Point(175, 107);
//            this.labelFecha.Name = "labelFecha";
//            this.labelFecha.Size = new System.Drawing.Size(51, 20);
//            this.labelFecha.TabIndex = 3;
//            this.labelFecha.Text = "label3";
//            // 
//            // labelEstadoPago
//            // 
//            this.labelEstadoPago.AutoSize = true;
//            this.labelEstadoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelEstadoPago.Location = new System.Drawing.Point(175, 137);
//            this.labelEstadoPago.Name = "labelEstadoPago";
//            this.labelEstadoPago.Size = new System.Drawing.Size(51, 20);
//            this.labelEstadoPago.TabIndex = 4;
//            this.labelEstadoPago.Text = "label4";
//            // 
//            // labelEstadoPedido
//            // 
//            this.labelEstadoPedido.AutoSize = true;
//            this.labelEstadoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelEstadoPedido.Location = new System.Drawing.Point(175, 170);
//            this.labelEstadoPedido.Name = "labelEstadoPedido";
//            this.labelEstadoPedido.Size = new System.Drawing.Size(51, 20);
//            this.labelEstadoPedido.TabIndex = 5;
//            this.labelEstadoPedido.Text = "label5";
//            // 
//            // labelTotal
//            // 
//            this.labelTotal.AutoSize = true;
//            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.labelTotal.Location = new System.Drawing.Point(175, 438);
//            this.labelTotal.Name = "labelTotal";
//            this.labelTotal.Size = new System.Drawing.Size(51, 20);
//            this.labelTotal.TabIndex = 6;
//            this.labelTotal.Text = "label6";
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(23, 53);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(42, 13);
//            this.label1.TabIndex = 7;
//            this.label1.Text = "Cliente:";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.Location = new System.Drawing.Point(23, 82);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(88, 13);
//            this.label2.TabIndex = 8;
//            this.label2.Text = "Método de pago:";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label3.Location = new System.Drawing.Point(23, 114);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(40, 13);
//            this.label3.TabIndex = 9;
//            this.label3.Text = "Fecha:";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label4.Location = new System.Drawing.Point(23, 144);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(85, 13);
//            this.label4.TabIndex = 10;
//            this.label4.Text = "Estado de pago:";
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label5.Location = new System.Drawing.Point(23, 177);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(95, 13);
//            this.label5.TabIndex = 11;
//            this.label5.Text = "Estado del pedido:";
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label6.Location = new System.Drawing.Point(22, 438);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(147, 20);
//            this.label6.TabIndex = 12;
//            this.label6.Text = "Total de la venta:";
//            // 
//            // label7
//            // 
//            this.label7.AutoSize = true;
//            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label7.Location = new System.Drawing.Point(22, 18);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(139, 20);
//            this.label7.TabIndex = 13;
//            this.label7.Text = "Consultar Venta";
//            // 
//            // btnEmitirFactura
//            // 
//            this.btnEmitirFactura.Location = new System.Drawing.Point(26, 473);
//            this.btnEmitirFactura.Name = "btnEmitirFactura";
//            this.btnEmitirFactura.Size = new System.Drawing.Size(235, 36);
//            this.btnEmitirFactura.TabIndex = 14;
//            this.btnEmitirFactura.Text = "Emitir Factura por PDF";
//            this.btnEmitirFactura.UseVisualStyleBackColor = true;
//            this.btnEmitirFactura.Click += new System.EventHandler(this.btnEmitirFactura_Click);
//            // 
//            // btnSalir
//            // 
//            this.btnSalir.Location = new System.Drawing.Point(267, 473);
//            this.btnSalir.Name = "btnSalir";
//            this.btnSalir.Size = new System.Drawing.Size(102, 36);
//            this.btnSalir.TabIndex = 15;
//            this.btnSalir.Text = "Salir";
//            this.btnSalir.UseVisualStyleBackColor = true;
//            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
//            // 
//            // UIConsultSale
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(407, 521);
//            this.Controls.Add(this.btnSalir);
//            this.Controls.Add(this.btnEmitirFactura);
//            this.Controls.Add(this.label7);
//            this.Controls.Add(this.label6);
//            this.Controls.Add(this.label5);
//            this.Controls.Add(this.label4);
//            this.Controls.Add(this.label3);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.labelTotal);
//            this.Controls.Add(this.labelEstadoPedido);
//            this.Controls.Add(this.labelEstadoPago);
//            this.Controls.Add(this.labelFecha);
//            this.Controls.Add(this.labelMetodo);
//            this.Controls.Add(this.labelCliente);
//            this.Controls.Add(this.dgvConsultaVenta);
//            this.Name = "UIConsultSale";
//            this.Text = "UIConsultSale";
//            this.Load += new System.EventHandler(this.UIConsultSale_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVenta)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.DataGridView dgvConsultaVenta;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
//        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
//        private System.Windows.Forms.Label labelCliente;
//        private System.Windows.Forms.Label labelMetodo;
//        private System.Windows.Forms.Label labelFecha;
//        private System.Windows.Forms.Label labelEstadoPago;
//        private System.Windows.Forms.Label labelEstadoPedido;
//        private System.Windows.Forms.Label labelTotal;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.Button btnEmitirFactura;
//        private System.Windows.Forms.Button btnSalir;
//    }
//}
namespace Login
{
    partial class UIConsultSale
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblClienteKey = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.lblMetodoKey = new System.Windows.Forms.Label();
            this.labelMetodo = new System.Windows.Forms.Label();
            this.lblFechaKey = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.lblEstadoPagoKey = new System.Windows.Forms.Label();
            this.labelEstadoPago = new System.Windows.Forms.Label();
            this.lblEstadoPedidoKey = new System.Windows.Forms.Label();
            this.labelEstadoPedido = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.dgvConsultaVenta = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalKey = new System.Windows.Forms.Label();
            this.lblTotalSimbolo = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.btnEmitirFactura = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            this.pnlInfo.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVenta)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(480, 590);
            this.Text = "Consultar Venta";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIConsultSale";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIConsultSale_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Consultar Venta";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(440, 32);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL INFO ──────────────────────────────────────────
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(20, 56);
            this.pnlInfo.Size = new System.Drawing.Size(440, 148);
            this.pnlInfo.Name = "pnlInfo";
            //this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Fila de datos: label clave (gris) + label valor (azul oscuro)
            // Columna izquierda
            ConfigurarLabelKey(this.lblClienteKey, "Cliente", new System.Drawing.Point(16, 12));
            ConfigurarLabelKey(this.lblFechaKey, "Fecha", new System.Drawing.Point(16, 56));
            ConfigurarLabelKey(this.lblEstadoPagoKey, "Estado de pago", new System.Drawing.Point(240, 12));
            ConfigurarLabelKey(this.lblEstadoPedidoKey, "Estado del pedido", new System.Drawing.Point(240, 76));
            ConfigurarLabelKey(this.lblMetodoKey, "Método de pago", new System.Drawing.Point(16, 96));

            ConfigurarLabelValor(this.labelCliente, new System.Drawing.Point(16, 30));
            ConfigurarLabelValor(this.labelFecha, new System.Drawing.Point(16, 69));
            ConfigurarLabelValor(this.labelEstadoPago, new System.Drawing.Point(240, 30));
            ConfigurarLabelValor(this.labelEstadoPedido, new System.Drawing.Point(240, 94));
            ConfigurarLabelValor(this.labelMetodo, new System.Drawing.Point(16, 109));

            this.pnlInfo.Controls.Add(this.lblClienteKey);
            this.pnlInfo.Controls.Add(this.labelCliente);
            this.pnlInfo.Controls.Add(this.lblFechaKey);
            this.pnlInfo.Controls.Add(this.labelFecha);
            this.pnlInfo.Controls.Add(this.lblEstadoPagoKey);
            this.pnlInfo.Controls.Add(this.labelEstadoPago);
            this.pnlInfo.Controls.Add(this.lblEstadoPedidoKey);
            this.pnlInfo.Controls.Add(this.labelEstadoPedido);
            this.pnlInfo.Controls.Add(this.lblMetodoKey);
            this.pnlInfo.Controls.Add(this.labelMetodo);

            // ── LABEL DETALLES ──────────────────────────────────────
            this.lblDetalles.Text = "Productos";
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.Location = new System.Drawing.Point(20, 220);
            this.lblDetalles.Size = new System.Drawing.Size(200, 24);
            this.lblDetalles.Name = "lblDetalles";

            // ── DATAGRIDVIEW ────────────────────────────────────────
            this.dgvConsultaVenta.Location = new System.Drawing.Point(20, 248);
            this.dgvConsultaVenta.Size = new System.Drawing.Size(440, 196);
            this.dgvConsultaVenta.Name = "dgvConsultaVenta";
            this.dgvConsultaVenta.TabIndex = 0;
            this.dgvConsultaVenta.AllowUserToAddRows = false;
            this.dgvConsultaVenta.AllowUserToDeleteRows = false;
            this.dgvConsultaVenta.ReadOnly = true;
            this.dgvConsultaVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaVenta.RowHeadersVisible = false;
            this.dgvConsultaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsultaVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsultaVenta.GridColor = System.Drawing.Color.FromArgb(211, 209, 199);
            this.dgvConsultaVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsultaVenta.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvConsultaVenta.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 44, 42);
            this.dgvConsultaVenta.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvConsultaVenta.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.dgvConsultaVenta.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvConsultaVenta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvConsultaVenta.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.dgvConsultaVenta.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.dgvConsultaVenta.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);

            this.Nombre.HeaderText = "Producto";
            this.Nombre.Name = "Nombre";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.SubTotal.HeaderText = "Subtotal";
            this.SubTotal.Name = "SubTotal";

            this.dgvConsultaVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.Nombre, this.Cantidad, this.SubTotal
            });

            // ── PANEL TOTAL ─────────────────────────────────────────
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlTotal.Location = new System.Drawing.Point(20, 456);
            this.pnlTotal.Size = new System.Drawing.Size(440, 56);
            this.pnlTotal.Name = "pnlTotal";
            //this.pnlTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            this.lblTotalKey.Text = "TOTAL";
            this.lblTotalKey.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTotalKey.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotalKey.Location = new System.Drawing.Point(16, 8);
            this.lblTotalKey.Size = new System.Drawing.Size(60, 16);
            this.lblTotalKey.Name = "lblTotalKey";

            //this.lblTotalSimbolo.Text = "$";
            this.lblTotalSimbolo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTotalSimbolo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalSimbolo.Location = new System.Drawing.Point(16, 24);
            this.lblTotalSimbolo.Size = new System.Drawing.Size(0, 0);
            this.lblTotalSimbolo.Name = "lblTotalSimbolo";

            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(20, 24);
            this.labelTotal.Size = new System.Drawing.Size(200, 26);
            this.labelTotal.Name = "labelTotal";

            this.pnlTotal.Controls.Add(this.lblTotalKey);
            this.pnlTotal.Controls.Add(this.lblTotalSimbolo);
            this.pnlTotal.Controls.Add(this.labelTotal);

            // ── BOTONES ─────────────────────────────────────────────
            ConfigurarBotonPrimario(this.btnEmitirFactura, "Emitir Factura PDF",
                new System.Drawing.Point(20, 528), 1);
            this.btnEmitirFactura.Size = new System.Drawing.Size(280, 40);
            this.btnEmitirFactura.Click += new System.EventHandler(this.btnEmitirFactura_Click);

            ConfigurarBotonSecundario(this.btnSalir, "Cerrar",
                new System.Drawing.Point(312, 528), 2);
            this.btnSalir.Size = new System.Drawing.Size(148, 40);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvConsultaVenta);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.btnEmitirFactura);
            this.Controls.Add(this.btnSalir);

            this.pnlInfo.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaVenta)).EndInit();
            this.ResumeLayout(false);
        }

        // ── HELPERS ──────────────────────────────────────────────
        private void ConfigurarLabelKey(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
        {
            lbl.Text = texto;
            lbl.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(200, 16);
            lbl.AutoSize = false;
        }

        private void ConfigurarLabelValor(System.Windows.Forms.Label lbl,
            System.Drawing.Point ubicacion)
        {
            lbl.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lbl.Location = ubicacion;
            lbl.Size = new System.Drawing.Size(200, 22);
            lbl.AutoSize = false;
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
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblClienteKey;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label lblMetodoKey;
        private System.Windows.Forms.Label labelMetodo;
        private System.Windows.Forms.Label lblFechaKey;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label lblEstadoPagoKey;
        private System.Windows.Forms.Label labelEstadoPago;
        private System.Windows.Forms.Label lblEstadoPedidoKey;
        private System.Windows.Forms.Label labelEstadoPedido;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.DataGridView dgvConsultaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label lblTotalKey;
        private System.Windows.Forms.Label lblTotalSimbolo;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button btnEmitirFactura;
        private System.Windows.Forms.Button btnSalir;
    }
}
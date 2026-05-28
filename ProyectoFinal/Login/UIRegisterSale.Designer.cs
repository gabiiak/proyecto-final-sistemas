namespace Login
{
    partial class UIRegisterSale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPagoRecibido = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnEmitirFactura = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvVenta_DetalleVenta = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMetodo = new System.Windows.Forms.ComboBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPagoRecibido);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btnEmitirFactura);
            this.panel1.Controls.Add(this.btnRegistrarVenta);
            this.panel1.Controls.Add(this.btnAgregarDetalle);
            this.panel1.Controls.Add(this.labelTotal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgvVenta_DetalleVenta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbMetodo);
            this.panel1.Controls.Add(this.cbCliente);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 553);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(348, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Estados:  0 o menos del total -> PENDIENTE // pago justo ->  PAGADO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pago Recibido: ";
            // 
            // txtPagoRecibido
            // 
            this.txtPagoRecibido.Location = new System.Drawing.Point(106, 363);
            this.txtPagoRecibido.Name = "txtPagoRecibido";
            this.txtPagoRecibido.Size = new System.Drawing.Size(157, 20);
            this.txtPagoRecibido.TabIndex = 14;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(129, 518);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(240, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnEmitirFactura
            // 
            this.btnEmitirFactura.Location = new System.Drawing.Point(129, 489);
            this.btnEmitirFactura.Name = "btnEmitirFactura";
            this.btnEmitirFactura.Size = new System.Drawing.Size(240, 23);
            this.btnEmitirFactura.TabIndex = 10;
            this.btnEmitirFactura.Text = "Emitir Factura por PDF";
            this.btnEmitirFactura.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(19, 460);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(104, 81);
            this.btnRegistrarVenta.TabIndex = 9;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.Location = new System.Drawing.Point(129, 460);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(240, 23);
            this.btnAgregarDetalle.TabIndex = 8;
            this.btnAgregarDetalle.Text = "Agregar Detalle";
            this.btnAgregarDetalle.UseVisualStyleBackColor = true;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(81, 322);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(53, 13);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "labelTotal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total: ";
            // 
            // dgvVenta_DetalleVenta
            // 
            this.dgvVenta_DetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenta_DetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Cantidad,
            this.SubTotal});
            this.dgvVenta_DetalleVenta.Location = new System.Drawing.Point(14, 106);
            this.dgvVenta_DetalleVenta.Name = "dgvVenta_DetalleVenta";
            this.dgvVenta_DetalleVenta.Size = new System.Drawing.Size(343, 193);
            this.dgvVenta_DetalleVenta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Método de pago:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente: ";
            // 
            // cbMetodo
            // 
            this.cbMetodo.FormattingEnabled = true;
            this.cbMetodo.Location = new System.Drawing.Point(140, 74);
            this.cbMetodo.Name = "cbMetodo";
            this.cbMetodo.Size = new System.Drawing.Size(229, 21);
            this.cbMetodo.TabIndex = 1;
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(140, 46);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(229, 21);
            this.cbCliente.TabIndex = 0;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Registrar Venta";
            // 
            // UIRegisterSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 577);
            this.Controls.Add(this.panel1);
            this.Name = "UIRegisterSale";
            this.Text = "UIRegisterSale";
            this.Load += new System.EventHandler(this.UIRegisterSale_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMetodo;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvVenta_DetalleVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnEmitirFactura;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPagoRecibido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label label6;
    }
}
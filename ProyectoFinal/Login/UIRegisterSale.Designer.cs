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
            this.label8 = new System.Windows.Forms.Label();
            this.btnPagoJusto = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPagoRecibido = new System.Windows.Forms.TextBox();
            this.btnQuitarDetalle = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvVenta_DetalleVenta = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMetodo = new System.Windows.Forms.ComboBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta_DetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnPagoJusto);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtFecha);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPagoRecibido);
            this.panel1.Controls.Add(this.btnQuitarDetalle);
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
            this.panel1.Size = new System.Drawing.Size(373, 597);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "$";
            // 
            // btnPagoJusto
            // 
            this.btnPagoJusto.Location = new System.Drawing.Point(253, 410);
            this.btnPagoJusto.Name = "btnPagoJusto";
            this.btnPagoJusto.Size = new System.Drawing.Size(104, 23);
            this.btnPagoJusto.TabIndex = 20;
            this.btnPagoJusto.Text = "Pago Justo";
            this.btnPagoJusto.UseVisualStyleBackColor = true;
            this.btnPagoJusto.Click += new System.EventHandler(this.btnPagoJusto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Fecha transacción:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(121, 446);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(236, 20);
            this.txtFecha.TabIndex = 18;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(11, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(348, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Estados:  0 o menos del total -> PENDIENTE // pago justo ->  PAGADO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Pago Recibido: ";
            // 
            // txtPagoRecibido
            // 
            this.txtPagoRecibido.Location = new System.Drawing.Point(98, 412);
            this.txtPagoRecibido.Name = "txtPagoRecibido";
            this.txtPagoRecibido.Size = new System.Drawing.Size(141, 20);
            this.txtPagoRecibido.TabIndex = 14;
            // 
            // btnQuitarDetalle
            // 
            this.btnQuitarDetalle.Location = new System.Drawing.Point(187, 305);
            this.btnQuitarDetalle.Name = "btnQuitarDetalle";
            this.btnQuitarDetalle.Size = new System.Drawing.Size(170, 23);
            this.btnQuitarDetalle.TabIndex = 12;
            this.btnQuitarDetalle.Text = "Quitar detalle";
            this.btnQuitarDetalle.UseVisualStyleBackColor = true;
            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(14, 518);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(195, 67);
            this.btnRegistrarVenta.TabIndex = 9;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.Location = new System.Drawing.Point(14, 305);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(170, 23);
            this.btnAgregarDetalle.TabIndex = 8;
            this.btnAgregarDetalle.Text = "Agregar Detalle";
            this.btnAgregarDetalle.UseVisualStyleBackColor = true;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(87, 367);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(53, 13);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "labelTotal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 362);
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
            this.cbMetodo.Location = new System.Drawing.Point(128, 74);
            this.cbMetodo.Name = "cbMetodo";
            this.cbMetodo.Size = new System.Drawing.Size(229, 21);
            this.cbMetodo.TabIndex = 1;
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(128, 46);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(229, 21);
            this.cbCliente.TabIndex = 0;
            // 
            // UIRegisterSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 620);
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
        private System.Windows.Forms.Button btnQuitarDetalle;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPagoRecibido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPagoJusto;
        private System.Windows.Forms.Label label8;
    }
}
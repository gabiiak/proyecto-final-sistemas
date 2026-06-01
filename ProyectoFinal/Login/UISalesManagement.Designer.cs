namespace Login
{
    partial class UISalesManagement
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
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTodasLasVentas = new System.Windows.Forms.DataGridView();
            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoDePedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConsultarVenta = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEstadoPedido = new System.Windows.Forms.Button();
            this.btnEstadoPago = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnConsultarVenta);
            this.panel1.Controls.Add(this.labelId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnEstadoPedido);
            this.panel1.Controls.Add(this.btnEstadoPago);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRegistrarVenta);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 519);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(309, 195);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 23);
            this.button5.TabIndex = 20;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(182, 195);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 19;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cliente",
            "MetodoPago",
            "EstadoDePago",
            "EstadoDePedido"});
            this.comboBox1.Location = new System.Drawing.Point(72, 195);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Filtrar por fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Filtrar por";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(556, 150);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(473, 124);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(473, 98);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.Value = new System.DateTime(2021, 10, 1, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTodasLasVentas);
            this.panel2.Location = new System.Drawing.Point(19, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 268);
            this.panel2.TabIndex = 12;
            // 
            // dgvTodasLasVentas
            // 
            this.dgvTodasLasVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodasLasVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVenta,
            this.Cliente,
            this.Fecha,
            this.Total,
            this.MetodoPago,
            this.EstadoDePago,
            this.EstadoDePedido});
            this.dgvTodasLasVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTodasLasVentas.Location = new System.Drawing.Point(0, 0);
            this.dgvTodasLasVentas.Name = "dgvTodasLasVentas";
            this.dgvTodasLasVentas.Size = new System.Drawing.Size(654, 268);
            this.dgvTodasLasVentas.TabIndex = 0;
            this.dgvTodasLasVentas.SelectionChanged += new System.EventHandler(this.dgvTodasLasVentas_SelectionChanged);
            // 
            // IdVenta
            // 
            this.IdVenta.HeaderText = "ID";
            this.IdVenta.Name = "IdVenta";
            this.IdVenta.Width = 40;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // MetodoPago
            // 
            this.MetodoPago.HeaderText = "MetodoPago";
            this.MetodoPago.Name = "MetodoPago";
            // 
            // EstadoDePago
            // 
            this.EstadoDePago.HeaderText = "EstadoDePago";
            this.EstadoDePago.Name = "EstadoDePago";
            // 
            // EstadoDePedido
            // 
            this.EstadoDePedido.HeaderText = "EstadoDePedido";
            this.EstadoDePedido.Name = "EstadoDePedido";
            // 
            // btnConsultarVenta
            // 
            this.btnConsultarVenta.Location = new System.Drawing.Point(15, 150);
            this.btnConsultarVenta.Name = "btnConsultarVenta";
            this.btnConsultarVenta.Size = new System.Drawing.Size(195, 23);
            this.btnConsultarVenta.TabIndex = 7;
            this.btnConsultarVenta.Text = "Consultar Venta";
            this.btnConsultarVenta.UseVisualStyleBackColor = true;
            this.btnConsultarVenta.Click += new System.EventHandler(this.btnConsultarVenta_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(216, 62);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(44, 16);
            this.labelId.TabIndex = 6;
            this.labelId.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "ID de Venta seleccionada: ";
            // 
            // btnEstadoPedido
            // 
            this.btnEstadoPedido.Location = new System.Drawing.Point(216, 136);
            this.btnEstadoPedido.Name = "btnEstadoPedido";
            this.btnEstadoPedido.Size = new System.Drawing.Size(195, 37);
            this.btnEstadoPedido.TabIndex = 4;
            this.btnEstadoPedido.Text = "Cambiar Estado Pedido";
            this.btnEstadoPedido.UseVisualStyleBackColor = true;
            this.btnEstadoPedido.Click += new System.EventHandler(this.btnEstadoPedido_Click);
            // 
            // btnEstadoPago
            // 
            this.btnEstadoPago.Location = new System.Drawing.Point(216, 95);
            this.btnEstadoPago.Name = "btnEstadoPago";
            this.btnEstadoPago.Size = new System.Drawing.Size(195, 35);
            this.btnEstadoPago.TabIndex = 3;
            this.btnEstadoPago.Text = "Cambiar Estado Pago";
            this.btnEstadoPago.UseVisualStyleBackColor = true;
            this.btnEstadoPago.Click += new System.EventHandler(this.btnEstadoPago_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestionar Ventas";
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(15, 95);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(195, 49);
            this.btnRegistrarVenta.TabIndex = 1;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // UISalesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 543);
            this.Controls.Add(this.panel1);
            this.Name = "UISalesManagement";
            this.Text = "UISalesManagement";
            this.Load += new System.EventHandler(this.UISalesManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodasLasVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTodasLasVentas;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEstadoPedido;
        private System.Windows.Forms.Button btnEstadoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultarVenta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDePedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}
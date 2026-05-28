namespace Login
{
    partial class UIRegisterSaleDetail
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
            this.btnSalirDetalle = new System.Windows.Forms.Button();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numUpDownCantidadTandas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarDetalle = new System.Windows.Forms.Button();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnSalirDetalle);
            this.panel1.Controls.Add(this.labelSubtotal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDescripcionProducto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numUpDownCantidadTandas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRegistrarDetalle);
            this.panel1.Controls.Add(this.cbProducto);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 301);
            this.panel1.TabIndex = 0;
            // 
            // btnSalirDetalle
            // 
            this.btnSalirDetalle.Location = new System.Drawing.Point(229, 260);
            this.btnSalirDetalle.Name = "btnSalirDetalle";
            this.btnSalirDetalle.Size = new System.Drawing.Size(82, 23);
            this.btnSalirDetalle.TabIndex = 10;
            this.btnSalirDetalle.Text = "Salir";
            this.btnSalirDetalle.UseVisualStyleBackColor = true;
            this.btnSalirDetalle.Click += new System.EventHandler(this.btnSalirDetalle_Click);
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.AutoSize = true;
            this.labelSubtotal.Location = new System.Drawing.Point(102, 217);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Size = new System.Drawing.Size(72, 13);
            this.labelSubtotal.TabIndex = 9;
            this.labelSubtotal.Text = "labelSubTotal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "SubTotal: ";
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.Location = new System.Drawing.Point(105, 82);
            this.txtDescripcionProducto.MaximumSize = new System.Drawing.Size(300, 200);
            this.txtDescripcionProducto.MinimumSize = new System.Drawing.Size(100, 20);
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(206, 20);
            this.txtDescripcionProducto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "tandas";
            // 
            // numUpDownCantidadTandas
            // 
            this.numUpDownCantidadTandas.Location = new System.Drawing.Point(105, 163);
            this.numUpDownCantidadTandas.Name = "numUpDownCantidadTandas";
            this.numUpDownCantidadTandas.Size = new System.Drawing.Size(45, 20);
            this.numUpDownCantidadTandas.TabIndex = 4;
            this.numUpDownCantidadTandas.ValueChanged += new System.EventHandler(this.numUpDownCantidadTandas_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Producto: ";
            // 
            // btnRegistrarDetalle
            // 
            this.btnRegistrarDetalle.Location = new System.Drawing.Point(17, 260);
            this.btnRegistrarDetalle.Name = "btnRegistrarDetalle";
            this.btnRegistrarDetalle.Size = new System.Drawing.Size(206, 23);
            this.btnRegistrarDetalle.TabIndex = 1;
            this.btnRegistrarDetalle.Text = "Registrar";
            this.btnRegistrarDetalle.UseVisualStyleBackColor = true;
            this.btnRegistrarDetalle.Click += new System.EventHandler(this.btnRegistrarDetalle_Click);
            // 
            // cbProducto
            // 
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(105, 52);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(206, 21);
            this.cbProducto.TabIndex = 0;
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Registrar Detalle de Venta";
            // 
            // UIRegisterSaleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 328);
            this.Controls.Add(this.panel1);
            this.Name = "UIRegisterSaleDetail";
            this.Text = "UIRegisterSaleDetail";
            this.Load += new System.EventHandler(this.UIRegisterSaleDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarDetalle;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUpDownCantidadTandas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Button btnSalirDetalle;
        private System.Windows.Forms.Label label6;
    }
}
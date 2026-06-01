namespace Login
{
    partial class Menu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGestionarVentas = new System.Windows.Forms.Button();
            this.btnMetodos = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.contenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.btnGestionarVentas);
            this.panel1.Controls.Add(this.btnMetodos);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.btnProductos);
            this.panel1.Controls.Add(this.btnClientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 708);
            this.panel1.TabIndex = 0;
            // 
            // btnGestionarVentas
            // 
            this.btnGestionarVentas.AutoSize = true;
            this.btnGestionarVentas.FlatAppearance.BorderSize = 0;
            this.btnGestionarVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarVentas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarVentas.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGestionarVentas.Location = new System.Drawing.Point(12, 200);
            this.btnGestionarVentas.Name = "btnGestionarVentas";
            this.btnGestionarVentas.Size = new System.Drawing.Size(182, 33);
            this.btnGestionarVentas.TabIndex = 5;
            this.btnGestionarVentas.Text = "Gestión de Ventas";
            this.btnGestionarVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarVentas.UseVisualStyleBackColor = true;
            this.btnGestionarVentas.Click += new System.EventHandler(this.btnGestionarVentas_Click);
            // 
            // btnMetodos
            // 
            this.btnMetodos.AutoSize = true;
            this.btnMetodos.FlatAppearance.BorderSize = 0;
            this.btnMetodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMetodos.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMetodos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMetodos.Location = new System.Drawing.Point(12, 153);
            this.btnMetodos.Name = "btnMetodos";
            this.btnMetodos.Size = new System.Drawing.Size(182, 33);
            this.btnMetodos.TabIndex = 4;
            this.btnMetodos.Text = "Metodos de Pago";
            this.btnMetodos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMetodos.UseVisualStyleBackColor = true;
            this.btnMetodos.Click += new System.EventHandler(this.btnMetodos_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.AutoSize = true;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInicio.Location = new System.Drawing.Point(12, 46);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(172, 33);
            this.btnInicio.TabIndex = 3;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.AutoSize = true;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProductos.Location = new System.Drawing.Point(12, 114);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(224, 33);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Gestión de Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.AutoSize = true;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClientes.Location = new System.Drawing.Point(12, 80);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(206, 33);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Gestión de Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bienvenido, admin!";
            // 
            // contenedor
            // 
            this.contenedor.AutoSize = true;
            this.contenedor.Controls.Add(this.label3);
            this.contenedor.Controls.Add(this.label2);
            this.contenedor.Controls.Add(this.progressBar2);
            this.contenedor.Controls.Add(this.progressBar1);
            this.contenedor.Controls.Add(this.monthCalendar1);
            this.contenedor.Controls.Add(this.chart1);
            this.contenedor.Controls.Add(this.label1);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(200, 0);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(961, 708);
            this.contenedor.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad de productos disponibles en stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cantidad de insumos disponibles para producción";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(470, 200);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(369, 23);
            this.progressBar2.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(470, 114);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(369, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.monthCalendar1.Location = new System.Drawing.Point(470, 308);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(21, 80);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Ventas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Estimación de Ventas";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(432, 536);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "estadísticas de ventas";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 708);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "T&G SYSTEM";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnMetodos;
        private System.Windows.Forms.Button btnGestionarVentas;
    }
}
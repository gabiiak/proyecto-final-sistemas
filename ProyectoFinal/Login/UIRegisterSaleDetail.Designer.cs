//namespace Login
//{
//    partial class UIRegisterSaleDetail
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
//            this.btnSalirDetalle = new System.Windows.Forms.Button();
//            this.labelSubtotal = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.numUpDownCantidadTandas = new System.Windows.Forms.NumericUpDown();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.btnRegistrarDetalle = new System.Windows.Forms.Button();
//            this.cbProducto = new System.Windows.Forms.ComboBox();
//            this.label6 = new System.Windows.Forms.Label();
//            this.panel1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.label6);
//            this.panel1.Controls.Add(this.btnSalirDetalle);
//            this.panel1.Controls.Add(this.labelSubtotal);
//            this.panel1.Controls.Add(this.label5);
//            this.panel1.Controls.Add(this.txtDescripcionProducto);
//            this.panel1.Controls.Add(this.label4);
//            this.panel1.Controls.Add(this.label3);
//            this.panel1.Controls.Add(this.numUpDownCantidadTandas);
//            this.panel1.Controls.Add(this.label2);
//            this.panel1.Controls.Add(this.label1);
//            this.panel1.Controls.Add(this.btnRegistrarDetalle);
//            this.panel1.Controls.Add(this.cbProducto);
//            this.panel1.Location = new System.Drawing.Point(12, 12);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(328, 301);
//            this.panel1.TabIndex = 0;
//            // 
//            // btnSalirDetalle
//            // 
//            this.btnSalirDetalle.Location = new System.Drawing.Point(229, 260);
//            this.btnSalirDetalle.Name = "btnSalirDetalle";
//            this.btnSalirDetalle.Size = new System.Drawing.Size(82, 23);
//            this.btnSalirDetalle.TabIndex = 10;
//            this.btnSalirDetalle.Text = "Salir";
//            this.btnSalirDetalle.UseVisualStyleBackColor = true;
//            this.btnSalirDetalle.Click += new System.EventHandler(this.btnSalirDetalle_Click);
//            // 
//            // labelSubtotal
//            // 
//            this.labelSubtotal.AutoSize = true;
//            this.labelSubtotal.Location = new System.Drawing.Point(102, 217);
//            this.labelSubtotal.Name = "labelSubtotal";
//            this.labelSubtotal.Size = new System.Drawing.Size(72, 13);
//            this.labelSubtotal.TabIndex = 9;
//            this.labelSubtotal.Text = "labelSubTotal";
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label5.Location = new System.Drawing.Point(14, 214);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(78, 16);
//            this.label5.TabIndex = 8;
//            this.label5.Text = "SubTotal: ";
//            // 
//            // txtDescripcionProducto
//            // 
//            this.txtDescripcionProducto.Location = new System.Drawing.Point(105, 82);
//            this.txtDescripcionProducto.MaximumSize = new System.Drawing.Size(300, 200);
//            this.txtDescripcionProducto.MinimumSize = new System.Drawing.Size(100, 20);
//            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
//            this.txtDescripcionProducto.Size = new System.Drawing.Size(206, 20);
//            this.txtDescripcionProducto.TabIndex = 7;
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(14, 82);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(66, 13);
//            this.label4.TabIndex = 6;
//            this.label4.Text = "Descripcion:";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(156, 165);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(39, 13);
//            this.label3.TabIndex = 5;
//            this.label3.Text = "tandas";
//            // 
//            // numUpDownCantidadTandas
//            // 
//            this.numUpDownCantidadTandas.Location = new System.Drawing.Point(105, 163);
//            this.numUpDownCantidadTandas.Name = "numUpDownCantidadTandas";
//            this.numUpDownCantidadTandas.Size = new System.Drawing.Size(45, 20);
//            this.numUpDownCantidadTandas.TabIndex = 4;
//            this.numUpDownCantidadTandas.ValueChanged += new System.EventHandler(this.numUpDownCantidadTandas_ValueChanged);
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(14, 165);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(55, 13);
//            this.label2.TabIndex = 3;
//            this.label2.Text = "Cantidad: ";
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(14, 55);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(56, 13);
//            this.label1.TabIndex = 2;
//            this.label1.Text = "Producto: ";
//            // 
//            // btnRegistrarDetalle
//            // 
//            this.btnRegistrarDetalle.Location = new System.Drawing.Point(17, 260);
//            this.btnRegistrarDetalle.Name = "btnRegistrarDetalle";
//            this.btnRegistrarDetalle.Size = new System.Drawing.Size(206, 23);
//            this.btnRegistrarDetalle.TabIndex = 1;
//            this.btnRegistrarDetalle.Text = "Registrar";
//            this.btnRegistrarDetalle.UseVisualStyleBackColor = true;
//            this.btnRegistrarDetalle.Click += new System.EventHandler(this.btnRegistrarDetalle_Click);
//            // 
//            // cbProducto
//            // 
//            this.cbProducto.FormattingEnabled = true;
//            this.cbProducto.Location = new System.Drawing.Point(105, 52);
//            this.cbProducto.Name = "cbProducto";
//            this.cbProducto.Size = new System.Drawing.Size(206, 21);
//            this.cbProducto.TabIndex = 0;
//            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);
//            // 
//            // label6
//            // 
//            this.label6.AutoSize = true;
//            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label6.Location = new System.Drawing.Point(13, 15);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(223, 20);
//            this.label6.TabIndex = 11;
//            this.label6.Text = "Registrar Detalle de Venta";
//            // 
//            // UIRegisterSaleDetail
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(352, 328);
//            this.Controls.Add(this.panel1);
//            this.Name = "UIRegisterSaleDetail";
//            this.Text = "UIRegisterSaleDetail";
//            this.Load += new System.EventHandler(this.UIRegisterSaleDetail_Load);
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Button btnRegistrarDetalle;
//        private System.Windows.Forms.ComboBox cbProducto;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.TextBox txtDescripcionProducto;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.NumericUpDown numUpDownCantidadTandas;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label labelSubtotal;
//        private System.Windows.Forms.Button btnSalirDetalle;
//        private System.Windows.Forms.Label label6;
//    }
//}
namespace Login
{
    partial class UIRegisterSaleDetail
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
            this.lblProducto = new System.Windows.Forms.Label();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numUpDownCantidadTandas = new System.Windows.Forms.NumericUpDown();
            this.lblTandas = new System.Windows.Forms.Label();
            this.pnlSubtotal = new System.Windows.Forms.Panel();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.lblSubtotalSimbolo = new System.Windows.Forms.Label();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.btnRegistrarDetalle = new System.Windows.Forms.Button();
            this.btnSalirDetalle = new System.Windows.Forms.Button();

            this.pnlFormulario.SuspendLayout();
            this.pnlSubtotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(420, 396);
            this.Text = "Agregar Detalle";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIRegisterSaleDetail";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIRegisterSaleDetail_Load);

            // ── TÍTULO ──────────────────────────────────────────────
            this.lblTitulo.Text = "Agregar Detalle de Venta";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(380, 28);
            this.lblTitulo.Name = "lblTitulo";

            // ── PANEL FORMULARIO ────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location = new System.Drawing.Point(20, 52);
            this.pnlFormulario.Size = new System.Drawing.Size(380, 212);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            // Producto
            ConfigurarLabel(this.lblProducto, "Producto",
                new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbProducto,
                new System.Drawing.Point(16, 36), new System.Drawing.Size(348, 32), 0);
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);

            // Descripción (solo lectura — se llena al seleccionar producto)
            ConfigurarLabel(this.lblDescripcion, "Descripción",
                new System.Drawing.Point(16, 80));
            ConfigurarTextBox(this.txtDescripcionProducto,
                new System.Drawing.Point(16, 100), new System.Drawing.Size(348, 32), 1);
            this.txtDescripcionProducto.ReadOnly = true;
            this.txtDescripcionProducto.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.txtDescripcionProducto.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);

            // Cantidad + tandas
            ConfigurarLabel(this.lblCantidad, "Cantidad",
                new System.Drawing.Point(16, 148));

            this.numUpDownCantidadTandas.Location = new System.Drawing.Point(16, 168);
            this.numUpDownCantidadTandas.Size = new System.Drawing.Size(80, 32);
            this.numUpDownCantidadTandas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUpDownCantidadTandas.Minimum = 0;
            this.numUpDownCantidadTandas.TabIndex = 2;
            this.numUpDownCantidadTandas.Name = "numUpDownCantidadTandas";
            this.numUpDownCantidadTandas.ValueChanged += new System.EventHandler(this.numUpDownCantidadTandas_ValueChanged);

            this.lblTandas.Text = "tandas";
            this.lblTandas.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblTandas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblTandas.Location = new System.Drawing.Point(104, 172);
            this.lblTandas.Size = new System.Drawing.Size(60, 20);
            this.lblTandas.Name = "lblTandas";

            this.pnlFormulario.Controls.Add(this.lblProducto);
            this.pnlFormulario.Controls.Add(this.cbProducto);
            this.pnlFormulario.Controls.Add(this.lblDescripcion);
            this.pnlFormulario.Controls.Add(this.txtDescripcionProducto);
            this.pnlFormulario.Controls.Add(this.lblCantidad);
            this.pnlFormulario.Controls.Add(this.numUpDownCantidadTandas);
            this.pnlFormulario.Controls.Add(this.lblTandas);

            // ── PANEL SUBTOTAL ──────────────────────────────────────
            // Mismo estilo que el pnlTotal de UIRegisterSale
            this.pnlSubtotal.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.pnlSubtotal.Location = new System.Drawing.Point(20, 276);
            this.pnlSubtotal.Size = new System.Drawing.Size(380, 56);
            this.pnlSubtotal.Name = "pnlSubtotal";
            this.pnlSubtotal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanel_Paint);

            this.lblSubtotalLabel.Text = "SUBTOTAL";
            this.lblSubtotalLabel.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalLabel.Location = new System.Drawing.Point(16, 8);
            this.lblSubtotalLabel.Size = new System.Drawing.Size(80, 16);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";

            this.lblSubtotalSimbolo.Text = "$";
            this.lblSubtotalSimbolo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblSubtotalSimbolo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalSimbolo.Location = new System.Drawing.Point(16, 24);
            this.lblSubtotalSimbolo.Size = new System.Drawing.Size(0, 0);
            this.lblSubtotalSimbolo.Name = "lblSubtotalSimbolo";

            //this.labelSubtotal.Text = "0,00";
            this.labelSubtotal.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.labelSubtotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelSubtotal.Location = new System.Drawing.Point(20, 24);
            this.labelSubtotal.Size = new System.Drawing.Size(200, 26);
            this.labelSubtotal.Name = "labelSubtotal";

            this.pnlSubtotal.Controls.Add(this.lblSubtotalLabel);
            this.pnlSubtotal.Controls.Add(this.lblSubtotalSimbolo);
            this.pnlSubtotal.Controls.Add(this.labelSubtotal);

            // ── BOTONES ─────────────────────────────────────────────
            ConfigurarBotonPrimario(this.btnRegistrarDetalle, "Registrar",
                new System.Drawing.Point(20, 344), 3);
            this.btnRegistrarDetalle.Size = new System.Drawing.Size(240, 40);
            this.btnRegistrarDetalle.Click += new System.EventHandler(this.btnRegistrarDetalle_Click);

            ConfigurarBotonSecundario(this.btnSalirDetalle, "Cancelar",
                new System.Drawing.Point(272, 344), 4);
            this.btnSalirDetalle.Size = new System.Drawing.Size(128, 40);
            this.btnSalirDetalle.Click += new System.EventHandler(this.btnSalirDetalle_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlSubtotal);
            this.Controls.Add(this.btnRegistrarDetalle);
            this.Controls.Add(this.btnSalirDetalle);

            this.pnlFormulario.ResumeLayout(false);
            this.pnlSubtotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadTandas)).EndInit();
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
            cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cb.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            cb.TabIndex = tabIndex;
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
        private System.Windows.Forms.Panel pnlSubtotal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cbProducto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numUpDownCantidadTandas;
        private System.Windows.Forms.Label lblTandas;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label lblSubtotalSimbolo;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Button btnRegistrarDetalle;
        private System.Windows.Forms.Button btnSalirDetalle;
    }
}
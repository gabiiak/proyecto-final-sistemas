//namespace Login
//{
//    partial class UIOrderState
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
//            this.label1 = new System.Windows.Forms.Label();
//            this.button3 = new System.Windows.Forms.Button();
//            this.button2 = new System.Windows.Forms.Button();
//            this.button1 = new System.Windows.Forms.Button();
//            this.button4 = new System.Windows.Forms.Button();
//            this.button5 = new System.Windows.Forms.Button();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(12, 9);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(142, 13);
//            this.label1.TabIndex = 7;
//            this.label1.Text = "Cambiar estado de pedido a:";
//            // 
//            // button3
//            // 
//            this.button3.Location = new System.Drawing.Point(15, 114);
//            this.button3.Name = "button3";
//            this.button3.Size = new System.Drawing.Size(173, 33);
//            this.button3.TabIndex = 6;
//            this.button3.Text = "CANCELADO";
//            this.button3.UseVisualStyleBackColor = true;
//            this.button3.Click += new System.EventHandler(this.button3_Click);
//            // 
//            // button2
//            // 
//            this.button2.Location = new System.Drawing.Point(15, 75);
//            this.button2.Name = "button2";
//            this.button2.Size = new System.Drawing.Size(173, 33);
//            this.button2.TabIndex = 5;
//            this.button2.Text = "LISTO";
//            this.button2.UseVisualStyleBackColor = true;
//            this.button2.Click += new System.EventHandler(this.button2_Click);
//            // 
//            // button1
//            // 
//            this.button1.Location = new System.Drawing.Point(15, 36);
//            this.button1.Name = "button1";
//            this.button1.Size = new System.Drawing.Size(173, 33);
//            this.button1.TabIndex = 4;
//            this.button1.Text = "PREPARACION";
//            this.button1.UseVisualStyleBackColor = true;
//            this.button1.Click += new System.EventHandler(this.button1_Click);
//            // 
//            // button4
//            // 
//            this.button4.Location = new System.Drawing.Point(15, 153);
//            this.button4.Name = "button4";
//            this.button4.Size = new System.Drawing.Size(173, 33);
//            this.button4.TabIndex = 8;
//            this.button4.Text = "VIAJANDO";
//            this.button4.UseVisualStyleBackColor = true;
//            this.button4.Click += new System.EventHandler(this.button4_Click);
//            // 
//            // button5
//            // 
//            this.button5.Location = new System.Drawing.Point(15, 192);
//            this.button5.Name = "button5";
//            this.button5.Size = new System.Drawing.Size(173, 33);
//            this.button5.TabIndex = 9;
//            this.button5.Text = "ENTREGADO";
//            this.button5.UseVisualStyleBackColor = true;
//            this.button5.Click += new System.EventHandler(this.button5_Click);
//            // 
//            // UIOrderState
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(206, 248);
//            this.Controls.Add(this.button5);
//            this.Controls.Add(this.button4);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.button3);
//            this.Controls.Add(this.button2);
//            this.Controls.Add(this.button1);
//            this.Name = "UIOrderState";
//            this.Text = "UIOrderState";
//            this.Load += new System.EventHandler(this.UIOrderState_Load);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Button button3;
//        private System.Windows.Forms.Button button2;
//        private System.Windows.Forms.Button button1;
//        private System.Windows.Forms.Button button4;
//        private System.Windows.Forms.Button button5;
//    }
//}
namespace Login
{
    partial class UIOrderState
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Text = "Estado del Pedido";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "UIOrderState";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UIOrderState_Load);

            // ── TÍTULOS ─────────────────────────────────────────────
            this.lblTitulo.Text = "Estado del Pedido";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblTitulo.Size = new System.Drawing.Size(260, 28);
            this.lblTitulo.Name = "lblTitulo";

            this.lblSubtulo.Text = "Cambiar estado a:";
            this.lblSubtulo.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblSubtulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtulo.Location = new System.Drawing.Point(20, 50);
            this.lblSubtulo.Size = new System.Drawing.Size(260, 18);
            this.lblSubtulo.Name = "lblSubtulo";

            // ── BOTONES DE ESTADO ───────────────────────────────────
            // Cada estado tiene un color semántico distinto
            // para que de un vistazo se entienda la progresión

            // PREPARACION — azul (estado activo/en curso)
            ConfigurarBotonEstado(this.button1, "PREPARACIÓN",
                new System.Drawing.Point(20, 80),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 0);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // LISTO — verde
            ConfigurarBotonEstado(this.button2, "LISTO",
                new System.Drawing.Point(20, 136),
                //System.Drawing.Color.FromArgb(39, 80, 10),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 1);
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // VIAJANDO — naranja
            ConfigurarBotonEstado(this.button4, "VIAJANDO",
                new System.Drawing.Point(20, 192),
                //System.Drawing.Color.FromArgb(99, 56, 6),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 2);
            this.button4.Click += new System.EventHandler(this.button4_Click);

            // ENTREGADO — verde oscuro (estado final positivo)
            ConfigurarBotonEstado(this.button5, "ENTREGADO",
                new System.Drawing.Point(20, 248),
                //System.Drawing.Color.FromArgb(20, 60, 20),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 3);
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // CANCELADO — rojo (estado final negativo, separado visualmente)
            ConfigurarBotonEstado(this.button3, "CANCELADO",
                new System.Drawing.Point(20, 320),
                System.Drawing.Color.FromArgb(150, 30, 30),
                System.Drawing.Color.White, 4);
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.button3.Click += new System.EventHandler(this.button3_Click);

            // ── CONTROLS DEL FORM ───────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtulo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);

            this.ResumeLayout(false);
        }

        private void ConfigurarBotonEstado(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, System.Drawing.Color backColor,
            System.Drawing.Color foreColor, int tabIndex)
        {
            btn.Text = texto;
            btn.Location = ubicacion;
            btn.Size = new System.Drawing.Size(260, 44);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TabIndex = tabIndex;
            btn.Name = texto.ToLower();
        }

        // ── DECLARACIÓN ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}
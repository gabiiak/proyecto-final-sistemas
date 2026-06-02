namespace Login
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));

            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();

            this.pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlDerecho.SuspendLayout();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(720, 420);
            this.Text = "Iniciar Sesión";
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";

            // ── PANEL IZQUIERDO (azul) ───────────────────────────────
            this.pnlIzquierdo.BackColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierdo.Width = 300;
            this.pnlIzquierdo.Padding = new System.Windows.Forms.Padding(20);

            // PictureBox — logo/ícono centrado
            this.pictureBox1.Image = global::Login.Properties.Resources.user;
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.Location = new System.Drawing.Point(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Name = "pictureBox1";

            // Label bienvenida
            this.lblBienvenida.Text = "T" + "&&" + "G System";
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBienvenida.Size = new System.Drawing.Size(260, 36);
            this.lblBienvenida.Location = new System.Drawing.Point(20, 225);
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Name = "lblBienvenida";

            // Label subtítulo
            this.lblSubtitulo.Text = "Sistema de Gestión";
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(181, 212, 244);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.Size = new System.Drawing.Size(260, 24);
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 262);
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Name = "lblSubtitulo";

            this.pnlIzquierdo.Controls.Add(this.pictureBox1);
            this.pnlIzquierdo.Controls.Add(this.lblBienvenida);
            this.pnlIzquierdo.Controls.Add(this.lblSubtitulo);

            // ── PANEL DERECHO (formulario) ───────────────────────────
            this.pnlDerecho.BackColor = System.Drawing.Color.White;
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecho.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);

            // Título
            this.lblTitulo.Text = "Iniciar Sesión";
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(28, 58, 94);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(40, 40);
            this.lblTitulo.Size = new System.Drawing.Size(280, 36);
            this.lblTitulo.Name = "lblTitulo";

            // Label usuario
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.Location = new System.Drawing.Point(40, 105);
            this.lblUsuario.Size = new System.Drawing.Size(200, 20);
            this.lblUsuario.Name = "lblUsuario";

            // TextBox usuario
            this.txtUser.Location = new System.Drawing.Point(40, 128);
            this.txtUser.Size = new System.Drawing.Size(320, 30);
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.txtUser.Name = "txtUser";
            this.txtUser.TabIndex = 0;

            // Label contraseña
            this.lblPassword.Text = "Contraseña";
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.Location = new System.Drawing.Point(40, 178);
            this.lblPassword.Size = new System.Drawing.Size(200, 20);
            this.lblPassword.Name = "lblPassword";

            // TextBox contraseña
            this.txtPassword.Location = new System.Drawing.Point(40, 201);
            this.txtPassword.Size = new System.Drawing.Size(320, 30);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TabIndex = 1;

            // Label error (oculto por defecto)
            //this.lblError.Text = "Usuario o contraseña incorrectos.";
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.Location = new System.Drawing.Point(40, 245);
            this.lblError.Size = new System.Drawing.Size(320, 20);
            this.lblError.Name = "lblError";
            this.lblError.Visible = false;

            // Botón Ingresar
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.Location = new System.Drawing.Point(40, 278);
            this.btnLogin.Size = new System.Drawing.Size(150, 40);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(24, 95, 165);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Botón Limpiar
            this.btnClean.Text = "Limpiar";
            this.btnClean.Location = new System.Drawing.Point(205, 278);
            this.btnClean.Size = new System.Drawing.Size(150, 40);
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClean.FlatAppearance.BorderSize = 1;
            this.btnClean.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(181, 212, 244);
            this.btnClean.BackColor = System.Drawing.Color.White;
            this.btnClean.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
            this.btnClean.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClean.Name = "btnClean";
            this.btnClean.TabIndex = 3;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);

            this.pnlDerecho.Controls.Add(this.lblTitulo);
            this.pnlDerecho.Controls.Add(this.lblUsuario);
            this.pnlDerecho.Controls.Add(this.txtUser);
            this.pnlDerecho.Controls.Add(this.lblPassword);
            this.pnlDerecho.Controls.Add(this.txtPassword);
            this.pnlDerecho.Controls.Add(this.lblError);
            this.pnlDerecho.Controls.Add(this.btnLogin);
            this.pnlDerecho.Controls.Add(this.btnClean);

            // Orden de agregado al form
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierdo);

            this.pnlIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlDerecho.ResumeLayout(false);
            this.ResumeLayout(false);

            this.Load += new System.EventHandler(this.Login_Load);
        }
        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
        //    this.btnLogin = new System.Windows.Forms.Button();
        //    this.btnClean = new System.Windows.Forms.Button();
        //    this.txtUser = new System.Windows.Forms.TextBox();
        //    this.txtPassword = new System.Windows.Forms.TextBox();
        //    this.pictureBox1 = new System.Windows.Forms.PictureBox();
        //    this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
        //    this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
        //    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        //    this.SuspendLayout();
        //    // 
        //    // btnLogin
        //    // 
        //    this.btnLogin.Location = new System.Drawing.Point(265, 84);
        //    this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        //    this.btnLogin.Name = "btnLogin";
        //    this.btnLogin.Size = new System.Drawing.Size(99, 32);
        //    this.btnLogin.TabIndex = 0;
        //    this.btnLogin.Text = "Ingresar";
        //    this.btnLogin.UseVisualStyleBackColor = true;
        //    this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        //    // 
        //    // btnClean
        //    // 
        //    this.btnClean.Location = new System.Drawing.Point(371, 84);
        //    this.btnClean.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        //    this.btnClean.Name = "btnClean";
        //    this.btnClean.Size = new System.Drawing.Size(99, 32);
        //    this.btnClean.TabIndex = 1;
        //    this.btnClean.Text = "Limpiar";
        //    this.btnClean.UseVisualStyleBackColor = true;
        //    this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
        //    // 
        //    // txtUser
        //    // 
        //    this.txtUser.Location = new System.Drawing.Point(265, 13);
        //    this.txtUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        //    this.txtUser.Name = "txtUser";
        //    this.txtUser.Size = new System.Drawing.Size(205, 26);
        //    this.txtUser.TabIndex = 2;
        //    // 
        //    // txtPassword
        //    // 
        //    this.txtPassword.Location = new System.Drawing.Point(265, 50);
        //    this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        //    this.txtPassword.Name = "txtPassword";
        //    this.txtPassword.PasswordChar = '*';
        //    this.txtPassword.Size = new System.Drawing.Size(205, 26);
        //    this.txtPassword.TabIndex = 3;
        //    // 
        //    // pictureBox1
        //    // 
        //    this.pictureBox1.Image = global::Login.Properties.Resources.user;
        //    this.pictureBox1.Location = new System.Drawing.Point(12, 12);
        //    this.pictureBox1.Name = "pictureBox1";
        //    this.pictureBox1.Size = new System.Drawing.Size(122, 114);
        //    this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        //    this.pictureBox1.TabIndex = 6;
        //    this.pictureBox1.TabStop = false;
        //    // 
        //    // materialLabel1
        //    // 
        //    this.materialLabel1.AutoSize = true;
        //    this.materialLabel1.Depth = 0;
        //    this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
        //    this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //    this.materialLabel1.Location = new System.Drawing.Point(159, 16);
        //    this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
        //    this.materialLabel1.Name = "materialLabel1";
        //    this.materialLabel1.Size = new System.Drawing.Size(65, 19);
        //    this.materialLabel1.TabIndex = 7;
        //    this.materialLabel1.Text = "Usuario:";
        //    // 
        //    // materialLabel2
        //    // 
        //    this.materialLabel2.AutoSize = true;
        //    this.materialLabel2.Depth = 0;
        //    this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
        //    this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //    this.materialLabel2.Location = new System.Drawing.Point(159, 53);
        //    this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
        //    this.materialLabel2.Name = "materialLabel2";
        //    this.materialLabel2.Size = new System.Drawing.Size(94, 19);
        //    this.materialLabel2.TabIndex = 8;
        //    this.materialLabel2.Text = "Contraseña: ";
        //    // 
        //    // Login
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.BackColor = System.Drawing.SystemColors.Control;
        //    this.ClientSize = new System.Drawing.Size(488, 143);
        //    this.Controls.Add(this.materialLabel2);
        //    this.Controls.Add(this.materialLabel1);
        //    this.Controls.Add(this.pictureBox1);
        //    this.Controls.Add(this.txtPassword);
        //    this.Controls.Add(this.txtUser);
        //    this.Controls.Add(this.btnClean);
        //    this.Controls.Add(this.btnLogin);
        //    this.Cursor = System.Windows.Forms.Cursors.Default;
        //    this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        //    this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        //    this.Name = "Login";
        //    this.Text = "Login";
        //    this.Load += new System.EventHandler(this.Login_Load);
        //    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}

        #endregion
        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClean;

        //---
        //private System.Windows.Forms.Button btnLogin;
        //private System.Windows.Forms.Button btnClean;
        //private System.Windows.Forms.TextBox txtUser;
        //private System.Windows.Forms.TextBox txtPassword;
        //private System.Windows.Forms.PictureBox pictureBox1;
        //private MaterialSkin.Controls.MaterialLabel materialLabel1;
        //private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}


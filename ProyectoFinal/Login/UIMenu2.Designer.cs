using System;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    partial class UIMenu2
    {
        private System.ComponentModel.IContainer components = null;

        // Controles principales
        private Panel pnlSidebar;
        private Panel pnlContenedor;
        private Panel pnlHeader;

        // Header
        private Label lblTituloApp;
        private Label lblUsuario;
        private Label lblModuloActivo;
        private Label lblFecha;
        private Panel pnlSeparador;

        // Botones del sidebar
        private Button btnInicio;
        private Button btnClientes;
        private Button btnProveedores;
        private Button btnProductos;
        private Button btnInsumos;
        private Button btnStock;
        private Button btnTandas;
        private Button btnMetodosPago;
        private Button btnVentas;
        private Button btnCompras;
        private Button btnCerrarSesion;
        private Button btnTema;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnAsistenteIA = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnTema = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnMetodosPago = new System.Windows.Forms.Button();
            this.btnTandas = new System.Windows.Forms.Button();
            this.btnInsumos = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.lblTituloApp = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblModuloActivo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.pnlSidebar.Controls.Add(this.btnAsistenteIA);
            this.pnlSidebar.Controls.Add(this.btnCerrarSesion);
            this.pnlSidebar.Controls.Add(this.btnTema);
            this.pnlSidebar.Controls.Add(this.btnCompras);
            this.pnlSidebar.Controls.Add(this.btnVentas);
            this.pnlSidebar.Controls.Add(this.btnMetodosPago);
            this.pnlSidebar.Controls.Add(this.btnTandas);
            this.pnlSidebar.Controls.Add(this.btnInsumos);
            this.pnlSidebar.Controls.Add(this.btnProductos);
            this.pnlSidebar.Controls.Add(this.btnProveedores);
            this.pnlSidebar.Controls.Add(this.btnClientes);
            this.pnlSidebar.Controls.Add(this.btnInicio);
            this.pnlSidebar.Controls.Add(this.lblTituloApp);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.pnlSidebar.Size = new System.Drawing.Size(189, 749);
            this.pnlSidebar.TabIndex = 2;
            // 
            // btnAsistenteIA
            // 
            this.btnAsistenteIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(59)))), ((int)(((byte)(91)))));
            this.btnAsistenteIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistenteIA.ForeColor = System.Drawing.Color.White;
            this.btnAsistenteIA.Location = new System.Drawing.Point(93, 412);
            this.btnAsistenteIA.Name = "btnAsistenteIA";
            this.btnAsistenteIA.Size = new System.Drawing.Size(190, 42);
            this.btnAsistenteIA.TabIndex = 12;
            this.btnAsistenteIA.Text = "Asistente IA";
            this.btnAsistenteIA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsistenteIA.UseVisualStyleBackColor = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 0);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(75, 23);
            this.btnCerrarSesion.TabIndex = 0;
            // 
            // btnTema
            // 
            this.btnTema.Location = new System.Drawing.Point(0, 0);
            this.btnTema.Name = "btnTema";
            this.btnTema.Size = new System.Drawing.Size(75, 23);
            this.btnTema.TabIndex = 1;
            this.btnTema.Text = "  🌙  Tema oscuro";
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(0, 0);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(75, 23);
            this.btnCompras.TabIndex = 11;
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(0, 0);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(75, 23);
            this.btnVentas.TabIndex = 2;
            // 
            // btnMetodosPago
            // 
            this.btnMetodosPago.Location = new System.Drawing.Point(0, 0);
            this.btnMetodosPago.Name = "btnMetodosPago";
            this.btnMetodosPago.Size = new System.Drawing.Size(75, 23);
            this.btnMetodosPago.TabIndex = 3;
            // 
            // btnTandas
            // 
            this.btnTandas.Location = new System.Drawing.Point(0, 0);
            this.btnTandas.Name = "btnTandas";
            this.btnTandas.Size = new System.Drawing.Size(75, 23);
            this.btnTandas.TabIndex = 4;
            // 
            // btnInsumos
            // 
            this.btnInsumos.Location = new System.Drawing.Point(0, 0);
            this.btnInsumos.Name = "btnInsumos";
            this.btnInsumos.Size = new System.Drawing.Size(75, 23);
            this.btnInsumos.TabIndex = 5;
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(0, 0);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(75, 23);
            this.btnProductos.TabIndex = 6;
            // 
            // btnProveedores
            // 
            this.btnProveedores.Location = new System.Drawing.Point(0, 0);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(75, 23);
            this.btnProveedores.TabIndex = 10;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(0, 0);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(75, 23);
            this.btnClientes.TabIndex = 7;
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(0, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(75, 23);
            this.btnInicio.TabIndex = 8;
            // 
            // lblTituloApp
            // 
            this.lblTituloApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloApp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(244)))));
            this.lblTituloApp.Location = new System.Drawing.Point(0, 12);
            this.lblTituloApp.Name = "lblTituloApp";
            this.lblTituloApp.Size = new System.Drawing.Size(189, 60);
            this.lblTituloApp.TabIndex = 9;
            this.lblTituloApp.Text = "T&&G System";
            this.lblTituloApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(189, 50);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(839, 699);
            this.pnlContenedor.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblModuloActivo);
            this.pnlHeader.Controls.Add(this.lblUsuario);
            this.pnlHeader.Controls.Add(this.pnlSeparador);
            this.pnlHeader.Controls.Add(this.lblFecha);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(189, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlHeader.Size = new System.Drawing.Size(839, 50);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblModuloActivo
            // 
            this.lblModuloActivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblModuloActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblModuloActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(94)))));
            this.lblModuloActivo.Location = new System.Drawing.Point(358, 0);
            this.lblModuloActivo.Name = "lblModuloActivo";
            this.lblModuloActivo.Size = new System.Drawing.Size(200, 50);
            this.lblModuloActivo.TabIndex = 1;
            this.lblModuloActivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            this.lblUsuario.Location = new System.Drawing.Point(20, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(220, 50);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(209)))), ((int)(((byte)(199)))));
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSeparador.Location = new System.Drawing.Point(558, 0);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(1, 50);
            this.pnlSeparador.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            this.lblFecha.Location = new System.Drawing.Point(559, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(260, 50);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "martes, 6 de octubre de 2026";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UIMenu2
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1028, 749);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "UIMenu2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion

        private Button btnAsistenteIA;
    }
}
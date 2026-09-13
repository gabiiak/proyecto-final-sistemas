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
        private Button btnProductos;
        private Button btnInsumos;
        private Button btnTandas; // Botón agregado
        private Button btnStock;
        private Button btnMetodosPago;
        private Button btnVentas;
        private Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlContenedor = new Panel();
            pnlHeader = new Panel();
            lblTituloApp = new Label();
            lblUsuario = new Label();
            btnInicio = new Button();
            btnClientes = new Button();
            btnProductos = new Button();
            btnInsumos = new Button();
            btnTandas = new Button(); // Inicialización
            //btnStock = new Button();
            btnMetodosPago = new Button();
            btnVentas = new Button();
            btnCerrarSesion = new Button();
            lblModuloActivo = new Label();
            lblFecha = new Label();
            pnlSeparador = new Panel();

            SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            ClientSize = new Size(1250, 850);
            Text = "Sistema de Gestión";
            MinimumSize = new Size(900, 550);
            BackColor = Color.FromArgb(244, 247, 251);
            this.StartPosition = FormStartPosition.CenterScreen;

            // ── SIDEBAR ─────────────────────────────────────────────
            pnlSidebar.BackColor = Color.FromArgb(28, 58, 94);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 220;
            pnlSidebar.Padding = new Padding(0, 12, 0, 12);

            ConfigurarBotonSidebar(btnInicio, "  🏠  Inicio", 0);
            ConfigurarBotonSidebar(btnClientes, "  👥  Clientes", 1);
            ConfigurarBotonSidebar(btnProductos, "  📦  Productos", 2);
            ConfigurarBotonSidebar(btnInsumos, "  🧰  Insumos", 3);
            ConfigurarBotonSidebar(btnTandas, "  ⚙️  Producción", 4);
            //ConfigurarBotonSidebar(btnStock, "  📊  StockInsumos", 5);
            ConfigurarBotonSidebar(btnMetodosPago, "  💳  Métodos de Pago", 6);
            ConfigurarBotonSidebar(btnVentas, "  🛒  Ventas", 7);
            ConfigurarBotonSidebar(btnCerrarSesion, "  🚪  Cerrar Sesión", 8);

            // Label título en el sidebar
            lblTituloApp.Text = "T" + "&&" + "G System";
            lblTituloApp.ForeColor = Color.FromArgb(181, 212, 244);
            lblTituloApp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloApp.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloApp.Dock = DockStyle.Top;
            lblTituloApp.Height = 60;

            pnlSidebar.Controls.Add(btnCerrarSesion);
            pnlSidebar.Controls.Add(btnVentas);
            pnlSidebar.Controls.Add(btnMetodosPago);
            //pnlSidebar.Controls.Add(btnStock);
            pnlSidebar.Controls.Add(btnTandas);
            pnlSidebar.Controls.Add(btnInsumos);
            pnlSidebar.Controls.Add(btnProductos);
            pnlSidebar.Controls.Add(btnClientes);
            pnlSidebar.Controls.Add(btnInicio);
            pnlSidebar.Controls.Add(lblTituloApp);

            // ── HEADER ──────────────────────────────────────────────
            pnlHeader.BackColor = Color.White;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.Padding = new Padding(20, 0, 20, 0);

            lblUsuario.ForeColor = Color.FromArgb(136, 135, 128);
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.TextAlign = ContentAlignment.MiddleLeft;
            lblUsuario.Dock = DockStyle.Left;
            lblUsuario.Width = 220;

            pnlHeader.Controls.Add(lblUsuario);

            // Label módulo activo
            lblModuloActivo = new Label();
            lblModuloActivo.Text = "";
            lblModuloActivo.ForeColor = Color.FromArgb(28, 58, 94);
            lblModuloActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblModuloActivo.TextAlign = ContentAlignment.MiddleLeft;
            lblModuloActivo.Dock = DockStyle.Right;
            lblModuloActivo.Width = 200;

            // Separador vertical
            pnlSeparador = new Panel();
            pnlSeparador.BackColor = Color.FromArgb(211, 209, 199);
            pnlSeparador.Dock = DockStyle.Right;
            pnlSeparador.Width = 1;

            // Label fecha
            lblFecha = new Label();
            lblFecha.Text = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy",
                new System.Globalization.CultureInfo("es-AR"));
            lblFecha.ForeColor = Color.FromArgb(136, 135, 128);
            lblFecha.Font = new Font("Segoe UI", 9F);
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            lblFecha.Dock = DockStyle.Right;
            lblFecha.Width = 260;

            pnlHeader.Controls.Add(lblModuloActivo);
            pnlHeader.Controls.Add(lblUsuario);
            pnlHeader.Controls.Add(pnlSeparador);
            pnlHeader.Controls.Add(lblFecha);

            // ── CONTENEDOR ──────────────────────────────────────────
            pnlContenedor.BackColor = Color.FromArgb(244, 247, 251);
            pnlContenedor.Dock = DockStyle.Fill;

            Controls.Add(pnlContenedor);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);

            ResumeLayout(false);
        }

        private void ConfigurarBotonSidebar(Button btn, string texto, int indice)
        {
            btn.Text = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 138, 221);
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(181, 212, 244);
            btn.Font = new Font("Segoe UI", 10F);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(16, 0, 0, 0);
            btn.Dock = DockStyle.Top;
            btn.Height = 48;
            btn.Tag = indice;
        }
    }
}
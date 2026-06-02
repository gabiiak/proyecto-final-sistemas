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

        // Botones del sidebar
        private Button btnInicio;
        private Button btnClientes;
        private Button btnProductos;
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
            btnMetodosPago = new Button();
            btnVentas = new Button();
            btnCerrarSesion = new Button();

            SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            ClientSize = new Size(1100, 650);
            Text = "Sistema de Gestión";
            MinimumSize = new Size(900, 550);
            BackColor = Color.FromArgb(244, 247, 251); // Fondo app

            // ── SIDEBAR ─────────────────────────────────────────────
            pnlSidebar.BackColor = Color.FromArgb(28, 58, 94);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 220;
            pnlSidebar.Padding = new Padding(0, 12, 0, 12);

            ConfigurarBotonSidebar(btnInicio, "  🏠  Inicio", 0);
            ConfigurarBotonSidebar(btnClientes, "  👥  Clientes", 1);
            ConfigurarBotonSidebar(btnProductos, "  📦  Productos", 2);
            ConfigurarBotonSidebar(btnMetodosPago, "  💳  Métodos de Pago", 3);
            ConfigurarBotonSidebar(btnVentas, "  🛒  Ventas", 4);
            ConfigurarBotonSidebar(btnCerrarSesion, "  🚪  Cerrar Sesión", 5);

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
            pnlSidebar.Controls.Add(btnProductos);
            pnlSidebar.Controls.Add(btnClientes);
            pnlSidebar.Controls.Add(btnInicio);
            pnlSidebar.Controls.Add(lblTituloApp);

            // ── HEADER ──────────────────────────────────────────────
            //AGREGAR ALGO MÁS AQUI
            pnlHeader.BackColor = Color.White;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.Padding = new Padding(20, 0, 20, 0);

            lblUsuario.Text = "Usuario";
            lblUsuario.ForeColor = Color.FromArgb(136, 135, 128);
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.TextAlign = ContentAlignment.MiddleRight;
            lblUsuario.Dock = DockStyle.Right;
            lblUsuario.Width = 200;

            pnlHeader.Controls.Add(lblUsuario);

            // ── CONTENEDOR ──────────────────────────────────────────
            pnlContenedor.BackColor = Color.FromArgb(244, 247, 251);
            pnlContenedor.Dock = DockStyle.Fill;

            // Orden de agregado al form (importa para el layout)
            Controls.Add(pnlContenedor);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);

            ResumeLayout(false);
        }

        // Configura el estilo base de cada botón del sidebar
        private void ConfigurarBotonSidebar(Button btn, string texto, int indice)
        {
            btn.Text = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 138, 221); // Azul hover
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(181, 212, 244);
            btn.Font = new Font("Segoe UI", 10F);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(16, 0, 0, 0);
            btn.Dock = DockStyle.Top;
            btn.Height = 48;
            btn.Cursor = Cursors.Hand;
            btn.Tag = indice; // Guardamos el índice para saber cuál está activo
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion
    }
}
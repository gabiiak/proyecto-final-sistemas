using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class UIMenu2 : Form
    {
        private Form formularioActivo = null;
        private Button botonActivo = null;

        // Permite recrear el módulo abierto tras cambiar el tema: los forms toman sus
        // colores en el constructor, así que hay que volver a construirlos.
        private Func<Form> fabricaModuloActivo = null;

        public UIMenu2()
        {
            InitializeComponent();

            ConfigurarBotonSidebar(btnInicio, "  🏠  Inicio", 0);
            ConfigurarBotonSidebar(btnClientes, "  👥  Clientes", 1);
            ConfigurarBotonSidebar(btnProductos, "  📦  Productos", 2);
            ConfigurarBotonSidebar(btnInsumos, "  🧰  Insumos", 3);
            ConfigurarBotonSidebar(btnTandas, "  ⚙️  Producción", 4);
            //ConfigurarBotonSidebar(btnStock, "  📊  StockInsumos", 4);
            ConfigurarBotonSidebar(btnMetodosPago, "  💳  Métodos de Pago", 5);
            ConfigurarBotonSidebar(btnVentas, "  🛒  Ventas", 6);
            ConfigurarBotonSidebar(btnCerrarSesion, "  🚪  Cerrar Sesión", 7);

            ConfigurarBotonTema();

            // Conectamos cada botón a su handler
            btnInicio.Click += (s, e) => AbrirModulo(btnInicio, () => new UIInicio1());
            btnClientes.Click += (s, e) => AbrirModulo(btnClientes, () => new UIGestionClientes());
            //btnProductos.Click += (s, e) => AbrirModulo(btnProductos, () => new UIProductManagement());
            btnProductos.Click += (s, e) => AbrirModulo(btnProductos, () => new UIStockProductos());
            btnInsumos.Click += (s, e) => AbrirModulo(btnInsumos, () => new UIStockInsumos());
            btnTandas.Click += (s, e) => AbrirModulo(btnTandas, () => new UIGestionTandas());
            //btnStock.Click += (s, e) => AbrirModulo(btnStock, () => new UIStockInsumos());
            btnMetodosPago.Click += (s, e) => AbrirModulo(btnMetodosPago, () => new UIGestionMetodosPago());
            btnVentas.Click += (s, e) => AbrirModulo(btnVentas, () => new UIGestionVentas());
            btnCerrarSesion.Click += BtnCerrarSesion_Click;

            btnTema.Click += BtnTema_Click;

            AplicarEstiloMenu();

            // Abrimos Inicio por defecto
            AbrirModulo(btnInicio, () => new UIInicio1());
        }

        private void ConfigurarBotonTema()
        {
            btnTema.FlatStyle = FlatStyle.Flat;
            btnTema.FlatAppearance.BorderSize = 1;
            btnTema.FlatAppearance.MouseOverBackColor = UIStyles.HoverSidebar;
            btnTema.Dock = DockStyle.Bottom;
            btnTema.Height = 44;
            btnTema.TextAlign = ContentAlignment.MiddleLeft;
            btnTema.Padding = new Padding(16, 0, 0, 0);
            btnTema.Font = new Font("Segoe UI", 10F);
            btnTema.Cursor = Cursors.Hand;
        }

        // Aplica la paleta actual al chrome del menú (los paneles están seteados en el
        // Designer con colores fijos, así que hay que repintarlos en cada cambio de tema).
        private void AplicarEstiloMenu()
        {
            BackColor = UIStyles.FondoCampo;
            pnlContenedor.BackColor = UIStyles.FondoCampo;
            pnlSidebar.BackColor = UIStyles.AzulOscuro;
            pnlHeader.BackColor = UIStyles.Superficie;
            pnlSeparador.BackColor = UIStyles.BordePanel;

            lblTituloApp.ForeColor = UIStyles.BordeClaro;
            lblUsuario.ForeColor = UIStyles.GrisTexto;
            lblFecha.ForeColor = UIStyles.GrisTexto;
            lblModuloActivo.ForeColor = UIStyles.TextoPrincipal;

            // Los botones del sidebar toman su color del tema salvo el activo.
            foreach (Control c in pnlSidebar.Controls)
                if (c is Button b && b != btnTema && b != botonActivo)
                {
                    b.BackColor = Color.Transparent;
                    b.ForeColor = UIStyles.BordeClaro;
                }

            MarcarBotonActivo(botonActivo);

            btnTema.FlatAppearance.BorderColor = UIStyles.HoverSidebar;
            btnTema.BackColor = UIStyles.AzulOscuro;
            btnTema.ForeColor = UIStyles.BordeClaro;
            btnTema.Text = UIStyles.TemaActual == Tema.Oscuro ? "  ☀  Tema claro" : "  🌙  Tema oscuro";
        }

        private void BtnTema_Click(object sender, EventArgs e)
        {
            UIStyles.AlternarTema();
            AplicarEstiloMenu();

            // Recreamos el módulo abierto para que tome la paleta nueva.
            if (fabricaModuloActivo != null)
                AbrirModulo(botonActivo, fabricaModuloActivo, forzarRecarga: true);
        }

        // Abre un módulo. La fábrica se guarda para poder recrearlo al cambiar de tema.
        private void AbrirModulo(Button boton, Func<Form> fabrica, bool forzarRecarga = false)
        {
            // Si ya está abierto el mismo módulo, no hacemos nada: recargar el form
            // descartaría lo que el usuario haya cargado. El cambio de tema fuerza la
            // recarga porque los colores se fijan en el constructor.
            if (!forzarRecarga && formularioActivo != null && boton == botonActivo)
                return;

            formularioActivo?.Close();
            formularioActivo = null;

            MarcarBotonActivo(boton);
            fabricaModuloActivo = fabrica;

            formularioActivo = fabrica();
            AcotarFormularioHijo(formularioActivo);
        }

        private void AcotarFormularioHijo(Form formHijo)
        {
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            formHijo.BackColor = UIStyles.FondoCampo;

            // Los .Designer traen colores light fijos: los traducimos al tema activo.
            UIStyles.AplicarTemaAForm(formHijo);

            pnlContenedor.Controls.Clear();
            pnlContenedor.Controls.Add(formHijo);
            formHijo.BringToFront();
            formHijo.Show();
        }

        public void SetUsuario(string nombreUsuario)
        {
            lblUsuario.Text = $"Sesión activa:   👤  {nombreUsuario}";
        }

        private void MarcarBotonActivo(Button boton)
        {
            // Resetear el botón anterior
            if (botonActivo != null && botonActivo != boton)
            {
                botonActivo.BackColor = Color.Transparent;
                botonActivo.ForeColor = UIStyles.BordeClaro;
            }

            if (boton == null) return;

            // Marcar el nuevo botón como activo
            botonActivo = boton;
            botonActivo.BackColor = UIStyles.HoverSidebar;
            botonActivo.ForeColor = UIStyles.Blanco;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
        "¿Cerrar sesión?",
        "Confirmar",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (confirmacion == DialogResult.Yes)
            {
                formularioActivo?.Close();
                this.Close();
                //Application.Exit();
                //if (Owner != null)
                //{
                //    // Flujo normal: hay un Login que nos abrió
                //    this.Hide();
                //    Owner.Show();
                //}
                //else
                //{
                //    // Estás debuggeando directo desde el Menú, cerramos todo

                //}
            }
        }
        private void UIMenu2_Load(object sender, EventArgs e)
        {

        }

        // Configura el estilo base de cada botón del sidebar
        private void ConfigurarBotonSidebar(Button btn, string texto, int indice)
            => UIStyles.ConfigurarBotonSidebar(btn, texto, indice);
    }
}

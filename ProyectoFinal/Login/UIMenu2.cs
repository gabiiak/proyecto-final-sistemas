using Negocio;
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

        private Label lblBreadcrumb = null;

        private Label lblVentas = null;
        private Label lblProduccion = null;
        private Label lblCompras = null;
        private Label lblNegocio = null;

        private Panel sepVentas = null;
        private Panel sepProduccion = null;
        private Panel sepCompras = null;

        private readonly List<Label> etiquetasSidebar = new List<Label>();
        private readonly List<Panel> separadoresSidebar = new List<Panel>();

        public UIMenu2()
        {
            InitializeComponent();

            lblBreadcrumb = new Label();
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Height = 28;
            lblBreadcrumb.Padding = new Padding(20, 4, 20, 4);
            lblBreadcrumb.TextAlign = ContentAlignment.MiddleLeft;
            lblBreadcrumb.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBreadcrumb.BackColor = UIStyles.Superficie;
            lblBreadcrumb.ForeColor = UIStyles.GrisTexto;
            lblBreadcrumb.Visible = false;

            ConfigurarBotonSidebar(btnInicio, "  🏠  Inicio", 0);
            ConfigurarBotonSidebar(btnClientes, "  👥  Clientes", 1);
            ConfigurarBotonSidebar(btnProveedores, "  🏭  Proveedores", 2);
            ConfigurarBotonSidebar(btnProductos, "  📦  Productos", 3);
            ConfigurarBotonSidebar(btnInsumos, "  🧰  Insumos", 4);
            ConfigurarBotonSidebar(btnTandas, "  ⚙️  Producción", 5);
            ConfigurarBotonSidebar(btnMetodosPago, "  💳  Métodos de Pago", 6);
            ConfigurarBotonSidebar(btnVentas, "  🛒  Ventas", 7);
            ConfigurarBotonSidebar(btnCompras, "  🧾  Compras", 8);
            ConfigurarBotonSidebar(btnAsistenteIA, "  ✨  Asistente IA", 9);
            ConfigurarBotonSidebar(btnCerrarSesion, "  🚪  Cerrar Sesión", 10);

            // El botón de cerrar sesión debe quedar anclado abajo, junto al de tema.
            btnCerrarSesion.Dock = DockStyle.Bottom;

            ConfigurarBotonTema();

            CrearEtiquetasYSeparadores();
            ReordenarSidebar();

            // Conectamos cada botón a su handler
            btnInicio.Click += (s, e) => AbrirModulo(btnInicio, () => new UIInicio1());
            btnClientes.Click += (s, e) => AbrirModulo(btnClientes, () => new UIGestionClientes());
            btnProveedores.Click += (s, e) => AbrirModulo(btnProveedores, () => new UIGestionProveedores());
            //btnProductos.Click += (s, e) => AbrirModulo(btnProductos, () => new UIProductManagement());
            btnProductos.Click += (s, e) => AbrirModulo(btnProductos, () => new UIStockProductos());
            btnInsumos.Click += (s, e) => AbrirModulo(btnInsumos, () => new UIStockInsumos());
            btnTandas.Click += (s, e) => AbrirModulo(btnTandas, () => new UIGestionTandas());
            //btnStock.Click += (s, e) => AbrirModulo(btnStock, () => new UIStockInsumos());
            btnMetodosPago.Click += (s, e) => AbrirModulo(btnMetodosPago, () => new UIGestionMetodosPago());
            btnVentas.Click += (s, e) => AbrirModulo(btnVentas, () => new UIGestionVentas());
            btnCompras.Click += (s, e) => AbrirModulo(btnCompras, () => new UIGestionCompras());
            btnAsistenteIA.Click += (s, e) =>
                AbrirModulo(btnAsistenteIA, () => new UIEvaluacionProveedor());

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

            if (lblBreadcrumb != null)
            {
                lblBreadcrumb.BackColor = UIStyles.Superficie;
                lblBreadcrumb.ForeColor = UIStyles.GrisTexto;
            }

            foreach (Label lbl in etiquetasSidebar)
                lbl.ForeColor = UIStyles.GrisTexto;

            foreach (Panel sep in separadoresSidebar)
                sep.BackColor = UIStyles.BordePanel;

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

        private readonly Stack<Form> pilaFormularios = new Stack<Form>();

        public void AbrirSubFormulario(Form hijo)
        {
            if (formularioActivo != null)
                pilaFormularios.Push(formularioActivo);   // se conserva vivo, no se cierra

            formularioActivo = hijo;
            AcotarFormularioHijo(hijo);   // su Controls.Clear() solo lo quita del panel, no lo destruye

            btnTema.Enabled = false;
            ActualizarBreadcrumb();
        }

        public void Volver()
        {
            if (pilaFormularios.Count == 0) return;

            var hijo = formularioActivo;
            formularioActivo = pilaFormularios.Pop();

            pnlContenedor.Controls.Clear();
            hijo.Close();                                  // ahora sí se destruye el sub-form
            pnlContenedor.Controls.Add(formularioActivo);
            formularioActivo.Show();
            MontarBreadcrumb();
            (formularioActivo as IRecargable)?.Recargar();

            if (pilaFormularios.Count == 0)
                btnTema.Enabled = true;
            ActualizarBreadcrumb();
        }

        private void ActualizarBreadcrumb()
        {
            if (lblBreadcrumb == null) return;

            if (pilaFormularios.Count == 0)
            {
                lblBreadcrumb.Visible = false;
                return;
            }

            List<string> partes = new List<string>();
            foreach (Form f in pilaFormularios.Reverse())
                partes.Add(f.Text);
            partes.Add(formularioActivo.Text);

            lblBreadcrumb.Text = string.Join(" > ", partes.ToArray());
            lblBreadcrumb.Visible = true;
        }

        // El breadcrumb vive dentro de pnlContenedor y siempre se deja al final del
        // z-order, después del formulario hijo con Dock=Fill, para no taparlo.
        private void MontarBreadcrumb()
        {
            if (lblBreadcrumb == null || pnlContenedor == null) return;
            if (lblBreadcrumb.Parent != pnlContenedor)
                pnlContenedor.Controls.Add(lblBreadcrumb);
            pnlContenedor.Controls.SetChildIndex(lblBreadcrumb, pnlContenedor.Controls.Count - 1);
        }

        // Abre un módulo. La fábrica se guarda para poder recrearlo al cambiar de tema.
        private void AbrirModulo(Button boton, Func<Form> fabrica, bool forzarRecarga = false)
        {
            // Si ya está abierto el mismo módulo, no hacemos nada: recargar el form
            // descartaría lo que el usuario haya cargado. El cambio de tema fuerza la
            // recarga porque los colores se fijan en el constructor.
            // Excepción: si hay sub-forms abiertos, volvemos al root de ese módulo.
            if (!forzarRecarga && formularioActivo != null && boton == botonActivo)
            {
                if (pilaFormularios.Count > 0)
                {
                    while (pilaFormularios.Count > 1)
                    {
                        Form sub = pilaFormularios.Pop();
                        sub.Close();
                    }

                    Form root = pilaFormularios.Pop();
                    Form hijoActual = formularioActivo;
                    formularioActivo = root;

                    pnlContenedor.Controls.Clear();
                    hijoActual.Close();

                    if (formularioActivo != null)
                    {
                        pnlContenedor.Controls.Add(formularioActivo);
                        formularioActivo.Show();
                        MontarBreadcrumb();
                        (formularioActivo as IRecargable)?.Recargar();
                    }

                    btnTema.Enabled = true;
                    ActualizarBreadcrumb();
                }
                return;
            }

            while (pilaFormularios.Count > 0)
                pilaFormularios.Pop().Close();
            formularioActivo?.Close();
            formularioActivo = null;

            btnTema.Enabled = true;
            MarcarBotonActivo(boton);
            fabricaModuloActivo = fabrica;

            formularioActivo = fabrica();
            AcotarFormularioHijo(formularioActivo);
            ActualizarBreadcrumb();
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
            MontarBreadcrumb();
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

        private void CrearEtiquetasYSeparadores()
        {
            lblVentas = CrearEtiquetaSidebar("Módulo de ventas");
            lblProduccion = CrearEtiquetaSidebar("Módulo de Producción");
            lblCompras = CrearEtiquetaSidebar("Módulo de compras");
            lblNegocio = CrearEtiquetaSidebar("Negocio");

            sepVentas = CrearSeparadorSidebar();
            sepProduccion = CrearSeparadorSidebar();
            sepCompras = CrearSeparadorSidebar();

            etiquetasSidebar.Add(lblVentas);
            etiquetasSidebar.Add(lblProduccion);
            etiquetasSidebar.Add(lblCompras);
            etiquetasSidebar.Add(lblNegocio);

            separadoresSidebar.Add(sepVentas);
            separadoresSidebar.Add(sepProduccion);
            separadoresSidebar.Add(sepCompras);
        }

        private Label CrearEtiquetaSidebar(string texto)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.Dock = DockStyle.Top;
            lbl.Height = 22;
            lbl.Padding = new Padding(16, 4, 0, 2);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = UIStyles.GrisTexto;
            return lbl;
        }

        private Panel CrearSeparadorSidebar()
        {
            Panel sep = new Panel();
            sep.Dock = DockStyle.Top;
            sep.Height = 1;
            sep.BackColor = UIStyles.BordePanel;
            return sep;
        }

        private void ReordenarSidebar()
        {
            Control[] controles = new Control[pnlSidebar.Controls.Count];
            pnlSidebar.Controls.CopyTo(controles, 0);
            pnlSidebar.Controls.Clear();

            List<Control> orden = new List<Control>
            {
                btnCerrarSesion,
                btnTema,
                btnAsistenteIA,
                btnMetodosPago,
                lblNegocio,
                sepCompras,
                btnProveedores,
                btnCompras,
                lblCompras,
                sepProduccion,
                btnInsumos,
                btnProductos,
                btnTandas,
                lblProduccion,
                sepVentas,
                btnClientes,
                btnVentas,
                lblVentas,
                btnInicio,
                lblTituloApp
            };

            foreach (Control c in orden)
            {
                if (c != null)
                    pnlSidebar.Controls.Add(c);
            }
        }
    }
}
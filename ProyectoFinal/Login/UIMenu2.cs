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

        // Colores de la paleta
        private readonly Color ColorSidebar = Color.FromArgb(28, 58, 94);
        private readonly Color ColorItemActivo = Color.FromArgb(55, 138, 221);
        private readonly Color ColorTextoNormal = Color.FromArgb(181, 212, 244);
        private readonly Color ColorTextoActivo = Color.White;

        public UIMenu2()
        {
            InitializeComponent();

            // Conectamos cada botón a su handler
            btnInicio.Click += (s, e) => AbrirFormularioHijo(new UIInicio1(), btnInicio);
            btnClientes.Click += (s, e) => AbrirFormularioHijo(new UIClientManagement(), btnClientes);
            btnProductos.Click += (s, e) => AbrirFormularioHijo(new UIProductManagement(), btnProductos);
            btnMetodosPago.Click += (s, e) => AbrirFormularioHijo(new UIPaymentMethodManagement(), btnMetodosPago);
            btnVentas.Click += (s, e) => AbrirFormularioHijo(new UISalesManagement(), btnVentas);
            btnCerrarSesion.Click += BtnCerrarSesion_Click;

            // Abrimos Inicio por defecto
            btnInicio.PerformClick();
        }

        public void SetUsuario(string nombreUsuario)
        {
            lblUsuario.Text = $"👤  {nombreUsuario}";
        }

        private void AbrirFormularioHijo(Form formHijo, Button botonOrigen)
        {
            // Si ya está abierto el mismo módulo, no hacemos nada
            if (formularioActivo?.GetType() == formHijo.GetType())
            {
                formHijo.Dispose(); // Descartamos la instancia nueva que creamos
                return;
            }

            // Cerramos el form anterior
            formularioActivo?.Close();
            formularioActivo = formHijo;

            // Actualizamos el estado visual del sidebar
            MarcarBotonActivo(botonOrigen);

            // Configuramos el form hijo para que viva dentro del panel
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            formHijo.BackColor = Color.FromArgb(244, 247, 251);

            pnlContenedor.Controls.Clear();
            pnlContenedor.Controls.Add(formHijo);
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void MarcarBotonActivo(Button boton)
        {
            // Resetear el botón anterior
            if (botonActivo != null)
            {
                botonActivo.BackColor = Color.Transparent;
                botonActivo.ForeColor = ColorTextoNormal;
            }

            // Marcar el nuevo botón como activo
            botonActivo = boton;
            botonActivo.BackColor = ColorItemActivo;
            botonActivo.ForeColor = ColorTextoActivo;
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
    }
}

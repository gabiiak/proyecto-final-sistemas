using System;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class UIMenu2 : Form
    {
        private Form formularioActivo = null;
        private Button botonActivo = null;

        private readonly Color ColorSidebar = Color.FromArgb(28, 58, 94);
        private readonly Color ColorItemActivo = Color.FromArgb(55, 138, 221);
        private readonly Color ColorTextoNormal = Color.FromArgb(181, 212, 244);
        private readonly Color ColorTextoActivo = Color.White;

        public UIMenu2()
        {
            InitializeComponent();
            AbrirFormularioHijo(new UIInicio1(), btnInicio);

            // Handlers de los botones
            btnInicio.Click += (s, e) => AbrirFormularioHijo(new UIInicio1(), btnInicio);
            btnClientes.Click += (s, e) => AbrirFormularioHijo(new UIClientManagement(), btnClientes);
            btnProductos.Click += (s, e) => AbrirFormularioHijo(new UIStockProductos(), btnProductos);
            btnInsumos.Click += (s, e) => AbrirFormularioHijo(new UIStockInsumos(), btnInsumos);
            btnTandas.Click += (s, e) => AbrirFormularioHijo(new UITandasManagement(), btnTandas); // Enlace agregado
            //btnStock.Click += (s, e) => AbrirFormularioHijo(new UIStockInsumos(), btnStock);
            btnMetodosPago.Click += (s, e) => AbrirFormularioHijo(new UIPaymentMethodManagement(), btnMetodosPago);
            btnVentas.Click += (s, e) => AbrirFormularioHijo(new UISalesManagement(), btnVentas);
            btnCerrarSesion.Click += BtnCerrarSesion_Click;
        }

        public void SetUsuario(string nombreUsuario)
        {
            lblUsuario.Text = $"Sesión activa:   👤  {nombreUsuario}";
        }

        private void AbrirFormularioHijo(Form formHijo, Button botonOrigen)
        {
            if (formularioActivo?.GetType() == formHijo.GetType())
            {
                formHijo.Dispose();
                return;
            }

            MarcarBotonActivo(botonOrigen);

            formularioActivo?.Close();
            formularioActivo = formHijo;

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
            if (botonActivo != null)
            {
                botonActivo.BackColor = Color.Transparent;
                botonActivo.ForeColor = ColorTextoNormal;
            }

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
            }
        }

        private void UIMenu2_Load(object sender, EventArgs e)
        {
        }
    }
}
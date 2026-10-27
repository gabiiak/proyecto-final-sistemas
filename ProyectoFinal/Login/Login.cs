using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Login
{
    public partial class Login : Form
    {
        public string usuarioLogueado { get; set; }
        private bool isChecked = false;
        
        public Login()
        {
            InitializeComponent();
            this.VisibleChanged += Login_VisibleChanged;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            AplicarTemaLogin();
            txtUser.Clear();
            txtPassword.Clear();
        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
            // Al cerrar sesión el form se vuelve a mostrar y el tema pudo cambiar en el menú.
            if (this.Visible) AplicarTemaLogin();
        }

        private void AplicarTemaLogin()
        {
            this.BackColor = UIStyles.FondoCampo;
            pnlDerecho.BackColor = UIStyles.Superficie;
            pnlIzquierdo.BackColor = UIStyles.AzulOscuro;

            lblTitulo.ForeColor = UIStyles.TextoPrincipal;
            lblUsuario.ForeColor = UIStyles.GrisTexto;
            lblPassword.ForeColor = UIStyles.GrisTexto;
            lblBienvenida.ForeColor = UIStyles.Blanco;
            lblSubtitulo.ForeColor = UIStyles.BordeClaro;

            txtUser.BackColor = UIStyles.FondoCampo;
            txtUser.ForeColor = UIStyles.TextoCampo;
            txtPassword.BackColor = UIStyles.FondoCampo;
            txtPassword.ForeColor = UIStyles.TextoCampo;

            btnLogin.BackColor = UIStyles.Primario;
            btnLogin.ForeColor = UIStyles.Blanco;

            btnClean.BackColor = UIStyles.Superficie;
            btnClean.ForeColor = UIStyles.PrimarioClaro;
            btnClean.FlatAppearance.BorderColor = UIStyles.BordeClaro;

            btnMostrarContraseña.BackColor = UIStyles.Superficie;
            btnMostrarContraseña.ForeColor = UIStyles.PrimarioClaro;
            btnMostrarContraseña.FlatAppearance.BorderColor = UIStyles.BordeClaro;

            btnTemaLogin.BackColor = UIStyles.Superficie;
            btnTemaLogin.ForeColor = UIStyles.PrimarioClaro;
            btnTemaLogin.FlatAppearance.BorderColor = UIStyles.BordeClaro;
            btnTemaLogin.Text = UIStyles.TemaActual == Tema.Oscuro
                ? "☀  Tema claro"
                : "🌙  Tema oscuro";
        }

        private void btnTemaLogin_Click(object sender, EventArgs e)
        {
            UIStyles.AlternarTema();
            AplicarTemaLogin();
        }

        private bool ValidateLogin(string user, string password)
        {
            if (txtUser.Text == user && txtPassword.Text == password) return true;
            else return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = true;
            string usuario = "administrador";
            string contraseña = "1"; //cambiar
            //string usuario = "1";
            //string contraseña = "1";
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                
                lblError.Text = "Hay campos vacíos.";
                //MessageBox.Show("Hay campos vacíos", "Alerta", MessageBoxButtons.OK);
                return;
            }
            if (ValidateLogin(usuario,contraseña) == true)
            {
                lblError.Visible = false;
                usuarioLogueado = usuario;
                this.DialogResult = DialogResult.OK;
                this.Hide();
                UIMenu2 Menu = new UIMenu2();
                Menu.FormClosed += (s, args) => this.Show(); //<- para escuchar el evento "cerrar"
                //this.Hide();
                //Menu.Show();
                
            }
            else
            {
                if (txtUser.Text != usuario)
                {
                    lblError.Text = "Usuario incorrecto.";
                    //MessageBox.Show("Usuario incorrecto", "Acceso denegado", MessageBoxButtons.OK);
                    return;
                }
                if (txtPassword.Text != contraseña)
                {
                    lblError.Text = "Contraseña incorrecta.";
                    //  MessageBox.Show("Contraseña incorrecta", "Acceso denegado", MessageBoxButtons.OK);
                    return;
                }

            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassword.Clear();
            lblError.Visible = false; // También limpia el error
            txtUser.Focus();
        }

        private void btnMostrarConstraseña_Click(object sender, EventArgs e)
        {
            isChecked = !isChecked; // de false a tru y viceversa
            txtPassword.PasswordChar = isChecked ? '\0' : '*'; //operador ternario
        }
    }
}

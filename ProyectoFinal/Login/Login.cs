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
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassword.Clear();
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
            string contraseña = "administrador91218";
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
                //Menu
                //UIMenu2 Menu = new UIMenu2();
                //Menu.FormClosed += (s, args) => this.Show(); //<- para escuchar el evento "cerrar"
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

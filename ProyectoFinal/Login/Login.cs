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
    public partial class Login : Form
    {
        private string usuario = "admin";
        private string contraseña = "admin";
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassword.Clear();
        }

        private bool ValidateLogin()
        {
            if (txtUser.Text == usuario && txtPassword.Text == contraseña) return true;
            else return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Hay campos vacíos", "Alerta", MessageBoxButtons.OK);
                return;
            }
            if (ValidateLogin() == true)
            {
                Menu Menu = new Menu();
                Menu.Show();
            }
            else
            {
                if (txtUser.Text != usuario)
                {
                    MessageBox.Show("Usuario incorrecto", "Acceso denegado", MessageBoxButtons.OK);
                    return;
                }
                if (txtPassword.Text != contraseña)
                {
                    MessageBox.Show("Contraseña incorrecta", "Acceso denegado", MessageBoxButtons.OK);
                    return;
                }

            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassword.Clear();
        }
    }
}

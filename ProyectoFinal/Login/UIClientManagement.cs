using Modelos;
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
    public partial class UIClientManagement : Form
    {
        public List<Cliente> dtoClientes = new List<Cliente>();
        public UIClientManagement()
        {
            InitializeComponent();
            
        }

        private void UIClientManagement_Load(object sender, EventArgs e)
        {
            dtoClientes = NClientes.GetAll();
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = dtoClientes;
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //*pendiente para mañana
        }
    }
}

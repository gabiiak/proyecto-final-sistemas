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
    public partial class UIDeletedClients : Form
    {
        public List<Cliente> listaClientesEliminados = new List<Cliente>();
        public UIDeletedClients()
        {
            InitializeComponent();
        }

        private void UIDeletedClients_Load(object sender, EventArgs e)
        {
            UpdateDeletedClientsDataGrid();
        }

        
        private void UpdateDeletedClientsDataGrid()
        {
            listaClientesEliminados = NClientes.GetDeleted();
            dgvClientesEliminados.DataSource = null;
            dgvClientesEliminados.DataSource = listaClientesEliminados;
        }
        private void dgvClientesEliminados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnDevolverCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente eliminado");
                return;
            }
            int id = int.Parse(labelId.Text);
            Cliente cli = new Cliente
            {
                Id = id
            };
            NClientes.ShowDeletedClients(cli);
            UpdateDeletedClientsDataGrid();
        }

        private void dgvClientesEliminados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientesEliminados.CurrentRow == null) return;
            labelId.Text = dgvClientesEliminados.CurrentRow.Cells["Id"].Value?.ToString();
        }
    }
}

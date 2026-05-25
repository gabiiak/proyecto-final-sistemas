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
    public partial class UIDeletedPaymentMethod : Form
    {
        public List<MetodoPago> listaMetodosEliminados = new List<MetodoPago>();
        public UIDeletedPaymentMethod()
        {
            InitializeComponent();
            UpdateDeletedMetodosDataGrid();


        }
        private void UpdateDeletedMetodosDataGrid()
        {
            listaMetodosEliminados = NMetodosPago.GetAllDeleted();
            dgvMetodosEliminados.DataSource = null;
            dgvMetodosEliminados.DataSource = listaMetodosEliminados;
            if (dgvMetodosEliminados.Columns.Contains("Activo"))
            {
                dgvMetodosEliminados.Columns["Activo"].Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente eliminado");
                return;
            }
            int id = int.Parse(labelId.Text);
            MetodoPago mp = new MetodoPago
            {
                IdMetodoPago = id
            };
            NMetodosPago.ShowDeletedMetodosPago(mp);
            UpdateDeletedMetodosDataGrid();
        }
        private void UIDeletedMetodos_Load(object sender, EventArgs e)
        {
            UpdateDeletedMetodosDataGrid();
        }

        private void dgvMetodosEliminados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMetodosEliminados.CurrentRow == null) return;
            labelId.Text = dgvMetodosEliminados.CurrentRow.Cells["IdMetodoPago"].Value?.ToString();
        }
    }
}

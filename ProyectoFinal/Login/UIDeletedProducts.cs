using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class UIDeletedProducts : Form
    {
        public List<Producto> listaProductosEliminados = new List<Producto>();
        public UIDeletedProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente eliminado");
                return;
            }
            int id = int.Parse(labelId.Text);
            Producto prod = new Producto
            {
                IdProducto = id
            };
            NProductos.ShowDeletedProducts(prod);
            UpdateDeletedProductsDataGrid();
        }

        private void UpdateDeletedProductsDataGrid()
        {
            listaProductosEliminados = NProductos.GetAllDeleted();
            dgvProductosEliminados.DataSource = null;
            dgvProductosEliminados.DataSource = listaProductosEliminados;
        }
        private void UIDeletedProducts_Load(object sender, EventArgs e)
        {
            UpdateDeletedProductsDataGrid();
        }

        private void dgvProductosEliminados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductosEliminados.CurrentRow == null) return;
            labelId.Text = dgvProductosEliminados.CurrentRow.Cells["IdProducto"].Value?.ToString();
        }
    }
}

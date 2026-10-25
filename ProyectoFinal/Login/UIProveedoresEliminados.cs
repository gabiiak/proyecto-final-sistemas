using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIProveedoresEliminados : Form
    {
        public List<Proveedor> listaProveedoresEliminados = new List<Proveedor>();

        public UIProveedoresEliminados()
        {
            InitializeComponent();
            UIStyles.AplicarTemaAForm(this);
        }

        private void UIProveedoresEliminados_Load(object sender, EventArgs e)
        {
            UpdateDeletedProveedoresDataGrid();
        }

        private void UpdateDeletedProveedoresDataGrid()
        {
            listaProveedoresEliminados = NProveedores.GetAllDeleted();
            dgvProveedoresEliminados.DataSource = null;
            dgvProveedoresEliminados.DataSource = listaProveedoresEliminados;
            if (dgvProveedoresEliminados.Columns.Contains("activo"))
            {
                dgvProveedoresEliminados.Columns["activo"].Visible = false;
            }
            if (dgvProveedoresEliminados.Rows.Count == 0)
            {
                labelId.Text = "";
            }
        }

        private void dgvProveedoresEliminados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedoresEliminados.CurrentRow == null) return;
            labelId.Text = dgvProveedoresEliminados.CurrentRow.Cells["IdProveedor"].Value?.ToString();
        }

        private void btnDevolverProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un proveedor eliminado");
                return;
            }
            int id = int.Parse(labelId.Text);
            Proveedor prov = new Proveedor
            {
                IdProveedor = id
            };
            NProveedores.ShowDeletedProveedores(prov);
            UpdateDeletedProveedoresDataGrid();
        }
    }
}
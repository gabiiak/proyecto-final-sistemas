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
        public List<Cliente> listaClientes = new List<Cliente>();
        public UIClientManagement()
        {
            InitializeComponent();
            
        }

        private void UIClientManagement_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
            Clean();
        }

        private void UpdateDataGrid()
        {
            listaClientes = NClientes.GetAll();
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes;
        }
        private void Clean()
        {
            labelId.Text = "";
            txtNombre.Clear();
            txtEmpresa.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmpresa.Text)
                || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                    return;
                }
                string nombre = txtNombre.Text;
                string empresa = txtEmpresa.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                Cliente cli = new Cliente
                {
                    Nombre = nombre,
                    Empresa = empresa,
                    Direccion = direccion,
                    Telefono = telefono
                };
                listaClientes.Add(cli);
                NClientes.Create(cli);
                MessageBox.Show("Registro completado", "Exito", MessageBoxButtons.OK);
                UpdateDataGrid();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(labelId.Text)) 
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Alerta", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmpresa.Text)
                || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                    return;
                }
                int id = int.Parse(labelId.Text);
                DialogResult result = MessageBox.Show("Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Cliente cli = new Cliente
                    {
                        Id = id,
                        Nombre = txtNombre.Text,
                        Empresa = txtEmpresa.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text
                    };
                    NClientes.Update(cli);
                    MessageBox.Show("¡Registro modificado con muchisimo éxito!", "Exito", MessageBoxButtons.OK);
                    UpdateDataGrid();
                    Clean();
                }
                else return;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Alerta", MessageBoxButtons.OK);
                return;
            }
            int id = int.Parse(labelId.Text);
            DialogResult result = MessageBox.Show("Desea borrar el registro?", "Alerta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Cliente cli = new Cliente
                {
                    Id = id,
                    Nombre = txtNombre.Text,
                    Empresa = txtEmpresa.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text
                };
                NClientes.Delete(cli);
                MessageBox.Show("¡Registro eliminado con muchisimo éxito!", "Exito", MessageBoxButtons.OK);
                UpdateDataGrid();
                Clean();
            }
            else return;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;
            labelId.Text = dgvClientes.CurrentRow.Cells["Id"].Value?.ToString();
            txtNombre.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value?.ToString();
            txtEmpresa.Text = dgvClientes.CurrentRow.Cells["Empresa"].Value?.ToString();
            txtDireccion.Text = dgvClientes.CurrentRow.Cells["Direccion"].Value?.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value?.ToString();
        }

        private void btnListarBorrados_Click(object sender, EventArgs e)
        {
            UIDeletedClients deleted = new UIDeletedClients();
            deleted.Show();
        }
    }
}

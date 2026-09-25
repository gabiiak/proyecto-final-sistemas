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
    public partial class UIGestionClientes : Form
    {
        public List<Cliente> listaClientes = new List<Cliente>();
        public UIGestionClientes()
        {
            InitializeComponent();
            // Fila 1: Nombre + Empresa
            ConfigurarLabel(this.lblNombre, "Nombre", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblEmpresa, "Empresa", new System.Drawing.Point(336, 48));
            ConfigurarTextBox(this.txtNombre, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            ConfigurarTextBox(this.txtEmpresa, new System.Drawing.Point(336, 68), new System.Drawing.Size(300, 32), 1);

            // Fila 2: Dirección + Teléfono
            ConfigurarLabel(this.lblDireccion, "Dirección", new System.Drawing.Point(16, 112));
            ConfigurarLabel(this.lblTelefono, "Teléfono", new System.Drawing.Point(336, 112));
            ConfigurarTextBox(this.txtDireccion, new System.Drawing.Point(16, 132), new System.Drawing.Size(300, 32), 2);
            ConfigurarTextBox(this.txtTelefono, new System.Drawing.Point(336, 132), new System.Drawing.Size(300, 32), 3);

            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar",
                new System.Drawing.Point(20, 252), 4);
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            // Secundarios: Modificar, Eliminar, Limpiar
            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(176, 252), 5);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(332, 252), 6);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar",
                new System.Drawing.Point(488, 252), 7);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // Botón fantasma: Clientes Eliminados
            ConfigurarBotonFantasma(this.btnListarBorrados, "Ver clientes eliminados",
                new System.Drawing.Point(20, 300), 8);
            this.btnListarBorrados.Click += new System.EventHandler(this.btnListarBorrados_Click);
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
            if (dgvClientes.Columns.Contains("Activo"))
            {
                dgvClientes.Columns["Activo"].Visible = false;
            }
            if (dgvClientes.Rows.Count > 0)
            {
                dgvClientes.ClearSelection();
                dgvClientes.Rows[0].Selected = true;
            }
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
                /*if (NClientes.ExisteCliente(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un cliente con ese nombre.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/
                if (NClientes.ExisteTelefono(txtTelefono.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un cliente con ese telefono.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Clean();
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
                    MessageBox.Show("Registro Modificado.", "Exito", MessageBoxButtons.OK);
                    Clean();
                    UpdateDataGrid();                   
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
                MessageBox.Show("Registro eliminado.", "Exito", MessageBoxButtons.OK);
                Clean();
                UpdateDataGrid();
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
            UIClientesEliminados deleted = new UIClientesEliminados();
            deleted.Show();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(200, 18));

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonFantasma(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(220, 30));

        private void pnlFormulario_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => UIStyles.PintarPanelRedondeado(sender, e);
    }
}

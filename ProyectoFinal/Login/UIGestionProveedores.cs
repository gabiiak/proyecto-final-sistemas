using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Login
{
    public partial class UIGestionProveedores : Form
    {
        public List<Proveedor> listaProveedores = new List<Proveedor>();

        public UIGestionProveedores()
        {
            InitializeComponent();

            // Fila 1: Nombre + Email
            ConfigurarLabel(this.lblNombre, "Nombre", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblEmail, "Email", new System.Drawing.Point(336, 48));
            ConfigurarTextBox(this.txtNombre, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            ConfigurarTextBox(this.txtEmail, new System.Drawing.Point(336, 68), new System.Drawing.Size(300, 32), 1);

            // Fila 2: Dirección + Teléfono
            ConfigurarLabel(this.lblDireccion, "Dirección", new System.Drawing.Point(16, 112));
            ConfigurarLabel(this.lblTelefono, "Teléfono", new System.Drawing.Point(336, 112));
            ConfigurarTextBox(this.txtDireccion, new System.Drawing.Point(16, 132), new System.Drawing.Size(300, 32), 2);
            ConfigurarTextBox(this.txtTelefono, new System.Drawing.Point(336, 132), new System.Drawing.Size(300, 32), 3);

            // Primario: Registrar
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

            // Fantasma: Proveedores eliminados
            ConfigurarBotonFantasma(this.btnListarBorrados, "Ver proveedores eliminados",
                new System.Drawing.Point(20, 300), 8);
            this.btnListarBorrados.Click += new System.EventHandler(this.btnListarBorrados_Click);
        }

        private void UIGestionProveedores_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
            Clean();
        }

        private void UpdateDataGrid()
        {
            listaProveedores = NProveedores.GetAll();
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = listaProveedores;
            if (dgvProveedores.Columns.Contains("activo"))
            {
                dgvProveedores.Columns["activo"].Visible = false;
            }
            if (dgvProveedores.Rows.Count > 0)
            {
                dgvProveedores.ClearSelection();
                dgvProveedores.Rows[0].Selected = true;
            }
        }

        private void Clean()
        {
            labelId.Text = "";
            txtNombre.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private bool HayCamposVacios()
        {
            return string.IsNullOrWhiteSpace(txtNombre.Text)
                || string.IsNullOrWhiteSpace(txtEmail.Text)
                || string.IsNullOrWhiteSpace(txtDireccion.Text)
                || string.IsNullOrWhiteSpace(txtTelefono.Text);
        }

        private bool EmailValido(string email)
        {
            try
            {
                var addr = new MailAddress(email.Trim());
                return addr.Address == email.Trim();
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (HayCamposVacios())
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!EmailValido(txtEmail.Text))
                {
                    MessageBox.Show("El email no tiene un formato válido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (NProveedores.ExisteProveedorNombre(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un proveedor con ese nombre.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Proveedor prov = new Proveedor
                {
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    activo = 1
                };
                NProveedores.Create(prov);
                MessageBox.Show("Proveedor registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
                UpdateDataGrid();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(labelId.Text))
                {
                    MessageBox.Show("Debe seleccionar un proveedor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (HayCamposVacios())
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!EmailValido(txtEmail.Text))
                {
                    MessageBox.Show("El email no tiene un formato válido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(labelId.Text);

                // Nombre duplicado en OTRO proveedor (el propio no cuenta)
                string nombre = txtNombre.Text.Trim();
                bool duplicado = listaProveedores.Exists(p =>
                    p.IdProveedor != id &&
                    p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (duplicado)
                {
                    MessageBox.Show("Ya existe otro proveedor con ese nombre.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) return;

                Proveedor prov = new Proveedor
                {
                    IdProveedor = id,
                    Nombre = nombre,
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    activo = 1
                };
                NProveedores.Update(prov);
                MessageBox.Show("Registro modificado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
                UpdateDataGrid();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(labelId.Text))
                {
                    MessageBox.Show("Debe seleccionar un proveedor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int id = int.Parse(labelId.Text);
                DialogResult result = MessageBox.Show("¿Desea borrar el registro?", "Alerta", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) return;

                NProveedores.Delete(id);
                MessageBox.Show("Registro eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
                UpdateDataGrid();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null) return;
            labelId.Text = dgvProveedores.CurrentRow.Cells["IdProveedor"].Value?.ToString();
            txtNombre.Text = dgvProveedores.CurrentRow.Cells["Nombre"].Value?.ToString();
            txtEmail.Text = dgvProveedores.CurrentRow.Cells["Email"].Value?.ToString();
            txtDireccion.Text = dgvProveedores.CurrentRow.Cells["Direccion"].Value?.ToString();
            txtTelefono.Text = dgvProveedores.CurrentRow.Cells["Telefono"].Value?.ToString();
        }

        private void btnListarBorrados_Click(object sender, EventArgs e)
        {
            UIProveedoresEliminados deleted = new UIProveedoresEliminados();
            deleted.FormClosed += (s, args) => UpdateDataGrid(); // refresca por si se restauró alguno
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
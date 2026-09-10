using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class UIInsumoManagement : Form
    {
        public List<Insumo> listaInsumos = new List<Insumo>();

        public UIInsumoManagement()
        {
            InitializeComponent();
        }

        private void UIInsumoManagement_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
            Clean();
        }

        private void UpdateDataGrid()
        {
            listaInsumos = NInsumos.GetAllInsumos();
            dgvInsumos.DataSource = null;
            dgvInsumos.DataSource = listaInsumos;
            if (dgvInsumos.Columns.Contains("Activo"))
            {
                dgvInsumos.Columns["Activo"].Visible = false;
            }
            if (dgvInsumos.Rows.Count > 0)
            {
                dgvInsumos.ClearSelection();
                dgvInsumos.Rows[0].Selected = true;
            }
        }

        private void Clean()
        {
            labelId.Text = "";
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private bool ValidarCampos(out double precio)
        {
            precio = 0;
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text)
                || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                return false;
            }
            if (!double.TryParse(txtPrecio.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out precio)
                && !double.TryParse(txtPrecio.Text.Trim(), out precio))
            {
                MessageBox.Show("El precio ingresado no es válido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(out double precio)) return;

                Insumo insumo = new Insumo
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = precio
                };
                NInsumos.createInsumo(insumo);
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
                    MessageBox.Show("Debe seleccionar un insumo.", "Alerta", MessageBoxButtons.OK);
                    return;
                }
                if (!ValidarCampos(out double precio)) return;

                int id = int.Parse(labelId.Text);
                DialogResult result = MessageBox.Show("Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Insumo insumo = new Insumo
                    {
                        Id = id,
                        Nombre = txtNombre.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim(),
                        Precio = precio
                    };
                    NInsumos.updateInsumo(insumo);
                    MessageBox.Show("Registro modificado.", "Éxito", MessageBoxButtons.OK);
                    Clean();
                    UpdateDataGrid();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un insumo.", "Alerta", MessageBoxButtons.OK);
                return;
            }
            int id = int.Parse(labelId.Text);
            DialogResult result = MessageBox.Show("Desea borrar el registro?", "Alerta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    NInsumos.deleteInsumo(id);
                    MessageBox.Show("Registro eliminado.", "Éxito", MessageBoxButtons.OK);
                    Clean();
                    UpdateDataGrid();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void dgvInsumos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInsumos.CurrentRow == null) return;
            labelId.Text = dgvInsumos.CurrentRow.Cells["Id"].Value?.ToString();
            txtNombre.Text = dgvInsumos.CurrentRow.Cells["Nombre"].Value?.ToString();
            txtDescripcion.Text = dgvInsumos.CurrentRow.Cells["Descripcion"].Value?.ToString();
            txtPrecio.Text = dgvInsumos.CurrentRow.Cells["Precio"].Value?.ToString();
        }

        // NOTA: cuando se agregue StockInsumo (Insumo + CantidadDisponible), este formulario
        // no necesita cambios: seguirá gestionando el catálogo de Insumo tal cual.
        // El manejo de stock (alta de cantidad, ajustes, listado con CantidadDisponible)
        // conviene resolverlo en un formulario/UI aparte (p.ej. UIStockInsumos) que consuma
        // NStock (o similar) y muestre StockInsumo, sin duplicar el CRUD de Insumo de aquí.
    }
}

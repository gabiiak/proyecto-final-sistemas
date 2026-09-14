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
    public partial class UIGestionInsumos : Form
    {
        public List<Insumo> listaInsumos = new List<Insumo>();

        public UIGestionInsumos()
        {
            InitializeComponent();
            // Fila 1: Nombre + Precio
            ConfigurarLabel(this.lblNombre, "Nombre", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblPrecio, "Precio", new System.Drawing.Point(336, 48));
            ConfigurarTextBox(this.txtNombre, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            ConfigurarTextBox(this.txtPrecio, new System.Drawing.Point(336, 68), new System.Drawing.Size(300, 32), 1);

            // Fila 2: Descripción (ancho completo)
            ConfigurarLabel(this.lblDescripcion, "Descripción", new System.Drawing.Point(16, 112));
            ConfigurarTextBox(this.txtDescripcion, new System.Drawing.Point(16, 132), new System.Drawing.Size(620, 32), 2);


            // ── BOTONES ─────────────────────────────────────────────
            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar",
                new System.Drawing.Point(20, 272), 3);
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(176, 272), 4);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(332, 272), 5);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar",
                new System.Drawing.Point(488, 272), 6);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
            grpUnidadMedida.Refresh();
            rbKg.Checked = false;
            rbGr.Checked = false;
            rbUnidad.Checked = false;
            rbLts.Checked = false;
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
            if (!rbKg.Checked && !rbGr.Checked && !rbLts.Checked && !rbUnidad.Checked)
            {
                MessageBox.Show("Seleccione una unidad de medida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(out double precio)) return;
                string unidadSeleccionada = rbGr.Checked ? "Gr" : rbKg.Checked ? "Kg" : rbLts.Checked ? "Lts" : rbUnidad.Checked ? "Unidad" : null; 
                Insumo insumo = new Insumo
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = precio,
                    UnidadMedida = unidadSeleccionada
                };
                NInsumos.Create(insumo);
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
                string unidadSeleccionada = rbGr.Checked ? "Gr" : rbKg.Checked ? "Kg" : rbLts.Checked ? "Lts" : rbUnidad.Checked ? "Unidad" : null;
                int id = int.Parse(labelId.Text);
                DialogResult result = MessageBox.Show("Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Insumo insumo = new Insumo
                    {
                        Id = id,
                        Nombre = txtNombre.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim(),
                        Precio = precio,
                        UnidadMedida = unidadSeleccionada

                    };
                    NInsumos.Update(insumo);
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
                    NInsumos.Delete(id);
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
            string unidadSeleccionada = dgvInsumos.CurrentRow.Cells["UnidadMedida"].Value?.ToString();
            SeleccionarUnidadMedida(unidadSeleccionada);
        }
        private void SeleccionarUnidadMedida(string unidadMedida)
        {
            rbKg.Checked = unidadMedida == "Kg";
            rbGr.Checked = unidadMedida == "Gr";
            rbLts.Checked = unidadMedida == "Lts";
            rbUnidad.Checked = unidadMedida == "Unidad";
        }
        // NOTA: cuando se agregue StockInsumo (Insumo + CantidadDisponible), este formulario
        // no necesita cambios: seguirá gestionando el catálogo de Insumo tal cual.
        // El manejo de stock (alta de cantidad, ajustes, listado con CantidadDisponible)
        // conviene resolverlo en un formulario/UI aparte (p.ej. UIStockInsumos) que consuma
        // NStock (o similar) y muestre StockInsumo, sin duplicar el CRUD de Insumo de aquí.
    }
}

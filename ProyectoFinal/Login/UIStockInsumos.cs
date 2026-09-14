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
    public partial class UIStockInsumos : Form
    {
        public List<StockInsumo> listaStock = new List<StockInsumo>();
        public List<Insumo> listaInsumos = new List<Insumo>();

        public UIStockInsumos()
        {
            InitializeComponent();
            StyleHelper();
        }

        private void StyleHelper()
        {
            ConfigurarLabel(this.lblInsumo, "Insumo", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblCantidad, "Cantidad", new System.Drawing.Point(336, 48));

            ConfigurarComboBox(this.cmbInsumos, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            ConfigurarTextBox(this.txtCantidad, new System.Drawing.Point(336, 68), new System.Drawing.Size(300, 32), 1);

            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar", new System.Drawing.Point(20, 272), 2);
            ConfigurarBotonSecundario(this.btnModificar, "Modificar", new System.Drawing.Point(176, 272), 3);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar", new System.Drawing.Point(332, 272), 4);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar", new System.Drawing.Point(488, 272), 5);
            ConfigurarBotonPrimario(this.btnInsumos, "Gestión de Insumos", new System.Drawing.Point(20, 120), 5);
            this.btnInsumos.Size = new System.Drawing.Size(180, 36);
        }
        private void UIStockInsumos_Load(object sender, EventArgs e)
        {
            CargarInsumosEnCombo();
            UpdateDataGrid();
            Clean();
        }

        private void CargarInsumosEnCombo()
        {
            listaInsumos = NInsumos.GetAllInsumos();
            cmbInsumos.DataSource = null;
            cmbInsumos.DataSource = listaInsumos;
            cmbInsumos.DisplayMember = "Nombre";
            cmbInsumos.ValueMember = "Id";
            cmbInsumos.SelectedIndex = -1;
        }

        private void UpdateDataGrid()
        {
            listaStock = NStockInsumo.GetAllStock();
            dgvStock.DataSource = null;
            dgvStock.DataSource = listaStock;
            if (dgvStock.Columns.Contains("InsumoId"))
            {
                dgvStock.Columns["InsumoId"].Visible = false;
            }
            if (dgvStock.Columns.Contains("NombreInsumo"))
            {
                dgvStock.Columns["NombreInsumo"].HeaderText = "Insumo";
            }
            if (dgvStock.Columns.Contains("CantidadDisponible"))
            {
                dgvStock.Columns["CantidadDisponible"].HeaderText = "Cantidad disponible";
            }
            if (dgvStock.Rows.Count > 0)
            {
                dgvStock.ClearSelection();
                dgvStock.Rows[0].Selected = true;
            }
        }

        private void Clean()
        {
            labelId.Text = "";
            cmbInsumos.SelectedIndex = -1;
            txtCantidad.Clear();
        }

        private bool ValidarCampos(out double cantidad)
        {
            cantidad = 0;
            if (cmbInsumos.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un insumo.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                return false;
            }
            if (!double.TryParse(txtCantidad.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out cantidad)
                && !double.TryParse(txtCantidad.Text.Trim(), out cantidad))
            {
                MessageBox.Show("La cantidad ingresada no es válida.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cantidad < 0)
            {
                MessageBox.Show("La cantidad no puede ser negativa.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(out double cantidad)) return;

                StockInsumo stock = new StockInsumo
                {
                    InsumoId = (int)cmbInsumos.SelectedValue,
                    CantidadDisponible = cantidad
                };
                NStockInsumo.createStock(stock);
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
                    MessageBox.Show("Debe seleccionar un registro de stock.", "Alerta", MessageBoxButtons.OK);
                    return;
                }
                if (!ValidarCampos(out double cantidad)) return;

                int id = int.Parse(labelId.Text);
                DialogResult result = MessageBox.Show("Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    StockInsumo stock = new StockInsumo
                    {
                        Id = id,
                        InsumoId = (int)cmbInsumos.SelectedValue,
                        CantidadDisponible = cantidad
                    };
                    NStockInsumo.updateStock(stock);
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

        private void btnEliminar_Click(object sender, EventArgs e) //sirve eliminar estos registros de la base de datos? 🤔🤔🤔🤔🤔
        {
            if (string.IsNullOrWhiteSpace(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un registro de stock.", "Alerta", MessageBoxButtons.OK);
                return;
            }
            int id = int.Parse(labelId.Text);
            DialogResult result = MessageBox.Show("Desea borrar el registro?", "Alerta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    NStockInsumo.deleteStock(id);
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

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStock.CurrentRow == null) return;
            labelId.Text = dgvStock.CurrentRow.Cells["Id"].Value?.ToString();
            object insumoIdValor = dgvStock.CurrentRow.Cells["InsumoId"].Value;
            if (insumoIdValor != null)
            {
                cmbInsumos.SelectedValue = (int)insumoIdValor;
            }
            txtCantidad.Text = dgvStock.CurrentRow.Cells["CantidadDisponible"].Value?.ToString();
        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            UIGestionInsumos insumo = new UIGestionInsumos();
            insumo.Show();
        }
    }
}

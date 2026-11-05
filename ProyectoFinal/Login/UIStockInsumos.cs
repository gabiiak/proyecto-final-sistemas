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
            dgvStock.CellFormatting += dgvStock_CellFormatting;
        }

        private void StyleHelper()
        {
            ConfigurarLabel(this.lblInsumo, "Insumo", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblCantidad, "Cantidad", new System.Drawing.Point(336, 48));

            ConfigurarComboBox(this.cmbInsumos, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            this.cmbInsumos.SelectedIndexChanged += new System.EventHandler(this.cmbInsumos_SelectedIndexChanged);
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
            dgvStock.DataSource = listaStock.Select(st => new
            {
                st.Id,
                st.InsumoId,
                st.NombreInsumo,
                CantidadDisponible = FormatearNumero(st.CantidadDisponible),
                UnidadMedidaInsumo = NInsumos.UnidadStock(st.UnidadMedidaInsumo)
            }).ToList();
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
                // "0.####": hasta 4 decimales, sin ceros sobrantes (123,5600 -> 123,56 | 123,0000 -> 123)
                // El separador que se muestra (coma/punto) lo define la cultura. Solo afecta la vista.
                dgvStock.Columns["CantidadDisponible"].DefaultCellStyle.Format = "0.####";
                dgvStock.Columns["CantidadDisponible"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR");
            }
            if (dgvStock.Columns.Contains("UnidadMedidaInsumo"))
            {
                dgvStock.Columns["UnidadMedidaInsumo"].HeaderText = "Unidad";
            }
            if (dgvStock.Columns.Contains("UnidadMedida"))
            {
                dgvStock.Columns["UnidadMedida"].HeaderText = "Unidad";
            }
            if (dgvStock.Rows.Count > 0)
            {
                dgvStock.ClearSelection();
                dgvStock.Rows[0].Selected = true;
            }
            
        }

        private static readonly CultureInfo CulturaAR = new CultureInfo("es-AR");

        // 2940,0000 -> 2940 | 104,2300 -> 104,23 | 123,0500 -> 123,05  (solo texto para la vista)
        private static string FormatearNumero(object valor)
        {
            if (valor == null) return "";
            if (valor is decimal d) return d.ToString("0.####", CulturaAR);
            if (decimal.TryParse(valor.ToString(), NumberStyles.Number, CulturaAR, out decimal parsed))
                return parsed.ToString("0.####", CulturaAR);
            return valor.ToString();
        }

        private void Clean()
        {
            labelId.Text = "";
            cmbInsumos.SelectedIndex = -1;
            txtCantidad.Clear();
            ActualizarLabelCantidad(null);
        }

        private void ActualizarLabelCantidad(Insumo insumo)
        {
            if (insumo == null || string.IsNullOrWhiteSpace(insumo.UnidadMedida))
            {
                lblCantidad.Text = "Cantidad";
                return;
            }
            lblCantidad.Text = "Cantidad (" + NInsumos.UnidadStock(insumo.UnidadMedida) + ")";
        }

        private void cmbInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarLabelCantidad(cmbInsumos.SelectedItem as Insumo);
        }

        private bool ValidarCampos(out decimal cantidad)
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
            // Se parsea con la cultura actual (es-AR: coma decimal) para que "123,5" no se lea como 1235.
            if (!decimal.TryParse(txtCantidad.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out cantidad))
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
                if (!ValidarCampos(out decimal cantidad)) return;

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
                if (!ValidarCampos(out decimal cantidad)) return;

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
            Insumo insumo = null;
            if (insumoIdValor != null)
            {
                int idInsumo = (int)insumoIdValor;
                cmbInsumos.SelectedValue = idInsumo;
                insumo = listaInsumos.FirstOrDefault(i => i.Id == idInsumo);
            }
            ActualizarLabelCantidad(insumo);
            object cantValor = dgvStock.CurrentRow.Cells["CantidadDisponible"].Value;
            if (cantValor is decimal cant)
                txtCantidad.Text = cant.ToString("0.####", CultureInfo.CurrentCulture);
            else if (cantValor != null &&
                     decimal.TryParse(cantValor.ToString(), NumberStyles.Number, CulturaAR, out decimal cant2))
                txtCantidad.Text = cant2.ToString("0.####", CulturaAR);
            else
                txtCantidad.Text = cantValor?.ToString();
        }

        // Quita los ceros sobrantes solo en la vista, aunque el valor llegue como string o decimal.
        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvStock.Columns[e.ColumnIndex].Name != "CantidadDisponible") return;

            if (e.Value is decimal dec)
            {
                e.Value = dec.ToString("0.####", CultureInfo.CurrentCulture);
                e.FormattingApplied = true;
            }
            else if (e.Value is string str &&
                     decimal.TryParse(str, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal d))
            {
                e.Value = d.ToString("0.####", CultureInfo.CurrentCulture);
                e.FormattingApplied = true;
            }
        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            UIGestionInsumos insumo = new UIGestionInsumos();
            insumo.Show();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(200, 18));

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt, System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

        private void ConfigurarComboBox(System.Windows.Forms.ComboBox cmb, System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cmb, ubicacion, tamaño, tabIndex, System.Windows.Forms.ComboBoxStyle.DropDownList);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));
    }
}
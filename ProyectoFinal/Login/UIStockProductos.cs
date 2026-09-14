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
    public partial class UIStockProductos : Form
    {
        public List<StockProducto> listaStock = new List<StockProducto>();
        public List<Producto> listaProductos = new List<Producto>();
        public UIStockProductos()
        {
            InitializeComponent();
            StyleHelper();
        }
        private void StyleHelper()
        {
            ConfigurarLabel(this.lblProductos, "Productos", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblCantidad, "Cantidad", new System.Drawing.Point(336, 48));

            ConfigurarComboBox(this.cmbProductos, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            ConfigurarTextBox(this.txtCantidad, new System.Drawing.Point(336, 68), new System.Drawing.Size(300, 32), 1);

            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar", new System.Drawing.Point(20, 272), 2);
            ConfigurarBotonSecundario(this.btnModificar, "Modificar", new System.Drawing.Point(176, 272), 3);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar", new System.Drawing.Point(332, 272), 4);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar", new System.Drawing.Point(488, 272), 5);
            ConfigurarBotonPrimario(this.btnProductos, "Gestión de Productos", new System.Drawing.Point(20, 120), 5);
            this.btnProductos.Size = new System.Drawing.Size(180, 36);
        }

        private void UIStockProductos_Load(object sender, EventArgs e)
        {
            CargarProductosCombo();
            UpdateDataGrid();
            Clean();
        }
        private void CargarProductosCombo()
        {
            listaProductos = NProductos.GetAll();
            cmbProductos.DataSource = null;
            cmbProductos.DataSource = listaProductos;
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "IdProducto";
            cmbProductos.SelectedIndex = -1;
        }

        private void UpdateDataGrid()
        {
            listaStock = NStockProducto.GetAll();
            dgvStock.DataSource = null;
            dgvStock.DataSource = listaStock;
        }
        private void Clean()
        {
            labelId.Text = "";
            cmbProductos.SelectedIndex = -1;
            txtCantidad.Clear();
        }
        private bool ValidarCampos(out double cantidad)
        {
            cantidad = 0;
            if (cmbProductos.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                StockProducto stock = new StockProducto
                {
                    ProductoId = (int)cmbProductos.SelectedValue,
                    CantidadDisponible = cantidad
                };
                NStockProducto.CreateStock(stock);
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
                    StockProducto stock = new StockProducto
                    {
                        Id = id,
                        ProductoId = (int)cmbProductos.SelectedValue,
                        CantidadDisponible = cantidad
                    };
                    NStockProducto.UpdateStock(stock);
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
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clean();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //sirve borrar registros????
        }
        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStock.CurrentRow == null) return;
            labelId.Text = dgvStock.CurrentRow.Cells["Id"].Value?.ToString();
            object productoIdValor = dgvStock.CurrentRow.Cells["ProductoId"].Value;
            if (productoIdValor != null)
            {
                cmbProductos.SelectedValue = (int)productoIdValor;
            }
            txtCantidad.Text = dgvStock.CurrentRow.Cells["CantidadDisponible"].Value?.ToString();
        }
        private void btnProductos_Click (object sender, EventArgs e)
        {
            UIGestionProductos productos = new UIGestionProductos();
            productos.Show();
        }
    }
}

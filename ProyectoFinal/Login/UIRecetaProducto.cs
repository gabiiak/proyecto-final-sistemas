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
    public partial class UIRecetaProducto : Form
    {
        private List<Insumo> listaInsumos = NInsumos.GetAllInsumos();
        private List<Producto> listaProductos = NProductos.GetAll();
        public UIRecetaProducto()
        {
            InitializeComponent();
        }

        
        private void UIRecetaProducto_Load(object sender, EventArgs e)
        {
            cmbInsumo.DisplayMember = "nombre";
            cmbInsumo.ValueMember = "id";
            cmbInsumo.DataSource = null;
            cmbInsumo.DataSource = listaInsumos;

            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
            cmbProducto.DataSource = null;
            cmbProducto.DataSource = listaProductos;

        }

        private List<RecetaProducto> GetInsumosGrid(int idProducto)
        {
            List<RecetaProducto> receta = new List<RecetaProducto>();
            foreach (DataGridViewRow fila in dgvRecetaProducto.Rows)
            {
                if (fila.IsNewRow) continue;

                // El id del insumo vive en la columna combo (ValueMember = "id"), no en "idInsumo"
                if (fila.Cells["cmbInsumo"].Value == null || fila.Cells["cmbInsumo"].Value == DBNull.Value)
                    continue;

                if (fila.Cells["cantidad"].Value == null || fila.Cells["cantidad"].Value == DBNull.Value)
                    continue;

                int idInsumo = Convert.ToInt32(fila.Cells["cmbInsumo"].Value);
                double cantidad = Convert.ToDouble(fila.Cells["cantidad"].Value);

                receta.Add(new RecetaProducto
                {
                    IdProducto = idProducto,
                    IdInsumo = idInsumo,
                    CantidadPorUnidad = cantidad
                });
            }

            return receta;
        }
        private void btnRegistrarReceta_Click(object sender, EventArgs e)
        {
            try
            {
                var productoSeleccionado = (Producto)cmbProducto.SelectedItem;
                List<RecetaProducto> receta = GetInsumosGrid(productoSeleccionado.IdProducto);
                NRecetaProducto.ReemplazarReceta(productoSeleccionado.IdProducto, receta);
                MessageBox.Show("todo debió salir bien, creo...");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"error: {ex.Message}");
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvRecetaProducto.Rows.Clear();

            var productoSeleccionado = (Producto)cmbProducto.SelectedItem;
            if (productoSeleccionado == null) return;

            List<RecetaProducto> recetaExistente = NRecetaProducto.ObtenerPorProducto(productoSeleccionado.IdProducto);

            foreach (RecetaProducto item in recetaExistente)
            {
                int filaIndex = dgvRecetaProducto.Rows.Add();
                DataGridViewRow fila = dgvRecetaProducto.Rows[filaIndex];

                fila.Cells["cmbInsumo"].Value = item.IdInsumo;
                fila.Cells["cantidad"].Value = item.CantidadPorUnidad;
            }
        }

        private void dgvRecetaProducto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecetaProducto.Columns[e.ColumnIndex].Name == "cmbInsumo" && e.RowIndex >= 0)
            {
                var celdaInsumo = dgvRecetaProducto.Rows[e.RowIndex].Cells["cmbInsumo"].Value;

                if (celdaInsumo != null && celdaInsumo != DBNull.Value)
                {
                    int idInsumo = Convert.ToInt32(celdaInsumo);
                    Insumo insumo = listaInsumos.FirstOrDefault(i => i.Id == idInsumo);

                    dgvRecetaProducto.Rows[e.RowIndex].Cells["colUnidadMedida"].Value =
                        insumo != null ? insumo.UnidadMedida : string.Empty;
                }
            }
        }

        private void dgvRecetaProducto_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRecetaProducto.CurrentCell is DataGridViewComboBoxCell &&
                dgvRecetaProducto.IsCurrentCellDirty)
            {
                dgvRecetaProducto.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}

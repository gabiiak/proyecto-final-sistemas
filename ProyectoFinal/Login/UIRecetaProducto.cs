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
                if (fila.IsNewRow) continue; // la fila fantasma de "agregar" al final del grid

                int idInsumo = Convert.ToInt32(fila.Cells["idInsumo"].Value);
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
    }
}

using Modelos;
using Negocio; // Asegúrate de tener este using para llamar a NProductos
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
    public partial class UIProductManagement : Form
    {
        public List<Producto> listaProductos = new List<Producto>();

        public UIProductManagement()
        {
            InitializeComponent();
        }

        private void UIProductManagement_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
            Clean();
        }

        // Método extraído igual que en el ejemplo para refrescar la grilla
        private void UpdateDataGrid()
        {
            listaProductos = NProductos.GetAll();
            dgvProductos.DataSource = null;

            // ¡Faltaba esta línea! Apaga la generación automática de columnas <- gemini
            //dgvProductos.AutoGenerateColumns = false;

            dgvProductos.DataSource = listaProductos;
        }

        // Método para limpiar los campos
        private void Clean()
        {
            labelId.Text = "";
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                    return;
                }

                // Validación de que el precio sea numérico
                if (!double.TryParse(txtPrecio.Text, out double precioConvertido))
                {
                    MessageBox.Show("El precio debe ser un número válido.", "Alerta", MessageBoxButtons.OK);
                    return;
                }

                Producto prod = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precioConvertido
                };

                listaProductos.Add(prod);
                NProductos.Create(prod);
                UpdateDataGrid();
                Clean();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(labelId.Text))
                {
                    MessageBox.Show("Debe seleccionar un producto.", "Alerta", MessageBoxButtons.OK);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                    return;
                }

                if (!double.TryParse(txtPrecio.Text, out double precioConvertido)) // este va a capa de negocio
                {
                    MessageBox.Show("El precio debe ser un número válido.", "Alerta", MessageBoxButtons.OK);
                    return;
                }

                int id = int.Parse(labelId.Text);
                DialogResult result = MessageBox.Show("¿Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Producto prod = new Producto
                    {
                        IdProducto = id, // Propiedad de tu modelo Producto
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Precio = precioConvertido
                    };

                    NProductos.Update(prod);
                    MessageBox.Show("Registro modificado.", "Exito", MessageBoxButtons.OK);

                    UpdateDataGrid();
                    Clean();
                }
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
                MessageBox.Show("Debe seleccionar un producto.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            int id = int.Parse(labelId.Text);
            DialogResult result = MessageBox.Show("¿Desea borrar el registro?", "Alerta", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Parseo básico para llenar el objeto antes de borrar
                double.TryParse(txtPrecio.Text, out double precioConvertido);

                Producto prod = new Producto
                {
                    IdProducto = id,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precioConvertido
                };

                NProductos.Delete(prod);
                MessageBox.Show("Registro eliminado.", "Exito", MessageBoxButtons.OK);
                UpdateDataGrid();
                Clean();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clean();
        }

        // ¡IMPORTANTE! Tienes que enlazar este evento en tu DataGridView desde el diseñador
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            // Usamos los nombres (Name) que le dimos a las columnas en el diseñador
            labelId.Text = dgvProductos.CurrentRow.Cells["IdProducto"].Value?.ToString();
            txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value?.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value?.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value?.ToString();
        }

        private void btnProductosEliminados_Click(object sender, EventArgs e)
        {
            UIDeletedProducts elim = new UIDeletedProducts();
            elim.Show();
        }
    }
}
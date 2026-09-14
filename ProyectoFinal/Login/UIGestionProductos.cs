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
    public partial class UIGestionProductos : Form
    {
        public List<Producto> listaProductos = new List<Producto>();

        public UIGestionProductos()
        {
            InitializeComponent();
            // Fila 1: Nombre + Descripción
            ConfigurarLabel(this.lblNombre, "Nombre", new System.Drawing.Point(16, 48));
            ConfigurarLabel(this.lblDescripcion, "Descripción", new System.Drawing.Point(336, 48));
            ConfigurarTextBox(this.txtNombre, new System.Drawing.Point(16, 68), new System.Drawing.Size(300, 32), 0);
            ConfigurarTextBox(this.txtDescripcion, new System.Drawing.Point(336, 68), new System.Drawing.Size(460, 32), 1);

            // Fila 2: Precio (solo ocupa la mitad, precio es un campo corto)
            ConfigurarLabel(this.lblPrecio, "Precio ($)", new System.Drawing.Point(16, 112));
            ConfigurarTextBox(this.txtPrecio, new System.Drawing.Point(16, 132), new System.Drawing.Size(180, 32), 2);

            //Fila 3: fecha de caducidad
            ConfigurarLabel(this.lblFechaCaducidad, "Fecha de caducidad", new System.Drawing.Point(336, 112));
            ConfigurarTextBox(this.txtFechaCaducidad, new System.Drawing.Point(336, 132), new System.Drawing.Size(230, 32), 2);
            
            // ── BOTONES ─────────────────────────────────────────────
            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar",
                new System.Drawing.Point(20, 240), 3);
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(176, 240), 4);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(332, 240), 5);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar",
                new System.Drawing.Point(488, 240), 6);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            ConfigurarBotonFantasma(this.btnProductosEliminados, "Ver productos eliminados",
                new System.Drawing.Point(20, 284), 7);
            this.btnProductosEliminados.Click += new System.EventHandler(this.btnProductosEliminados_Click);


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
            /*dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaProductos;
            */
            //dgvProductos.Rows.Clear();
            foreach (Producto p in listaProductos)
            {
                dgvProductos.Rows.Add(
                    p.IdProducto,
                    p.Nombre,
                    p.Descripcion,
                    p.Precio,
                    p.Activo,
                    p.FechaCaducidad.ToString("dd-MM-yyyy")
                    );
            }
            if (dgvProductos.Columns.Contains("Activo"))
            {
                dgvProductos.Columns["Activo"].Visible = false;
            }
            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.ClearSelection();
                dgvProductos.Rows[0].Selected = true;
            }
        }

        // Método para limpiar los campos
        private void Clean()
        {
            labelId.Text = "";
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtFechaCaducidad.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaCaducidad.Text))
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                    return;
                }
                if (NProductos.ExisteProductoNombre(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un producto con ese nombre.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (NProductos.ExisteProductoDescripcion(txtDescripcion.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un producto con esa descripción.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación de que el precio sea numérico
                if (!double.TryParse(txtPrecio.Text, out double precioConvertido))
                {
                    MessageBox.Show("El precio debe ser un número válido.", "Alerta", MessageBoxButtons.OK);
                    return;
                }
                DateTime fechaCaducidad = DateTime.Parse(txtFechaCaducidad.Text); 
                Producto prod = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precioConvertido,
                    FechaCaducidad = fechaCaducidad
                };

                listaProductos.Add(prod);
                NProductos.Create(prod);
                Clean();
                UpdateDataGrid();
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
                    string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtFechaCaducidad.Text))
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
                DateTime fechaCaducidad = DateTime.Parse(txtFechaCaducidad.Text);
                DialogResult result = MessageBox.Show("¿Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Producto prod = new Producto
                    {
                        IdProducto = id, // Propiedad de tu modelo Producto
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Precio = precioConvertido,
                        FechaCaducidad = fechaCaducidad
                    };

                    NProductos.Update(prod);
                    MessageBox.Show("Registro modificado.", "Exito", MessageBoxButtons.OK);
                    Clean();
                    UpdateDataGrid();
                    
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
            DateTime fechaCaducidad = DateTime.Parse(txtFechaCaducidad.Text);
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
                    Precio = precioConvertido,
                    FechaCaducidad = fechaCaducidad
                };

                NProductos.Delete(prod);
                MessageBox.Show("Registro eliminado.", "Exito", MessageBoxButtons.OK);
                Clean();
                UpdateDataGrid();
                
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
            txtFechaCaducidad.Text = dgvProductos.CurrentRow.Cells["FechaCaducidad"].Value?.ToString();
        }

        private void btnProductosEliminados_Click(object sender, EventArgs e)
        {
            UIProductosEliminados elim = new UIProductosEliminados();
            elim.Show();
        }

        private void btnGestionRecetas_Click(object sender, EventArgs e)
        {
            UIRecetaProducto recetita = new UIRecetaProducto();
            recetita.Show();
        }
    }
}
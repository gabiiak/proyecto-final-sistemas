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
    public partial class UIPaymentMethodManagement : Form
    {
        public List<MetodoPago> listaMetodos = new List<MetodoPago>();
        public UIPaymentMethodManagement()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            listaMetodos = NMetodosPago.GetAll();
            dgvMetodos.DataSource = null;

            // ¡Faltaba esta línea! Apaga la generación automática de columnas <- gemini
            //dgvMetodos.AutoGenerateColumns = false;
            dgvMetodos.DataSource = listaMetodos;
            if (dgvMetodos.Columns.Contains("Activo"))
            {
                dgvMetodos.Columns["Activo"].Visible = false;
            }
        }

        // Método para limpiar los campos
        private void Clean()
        {
            labelId.Text = "";
          
            txtDescripcion.Clear();
            
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos vacíos
                if (
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) )
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                    return;
                }




                MetodoPago mp = new MetodoPago
                {

                    Descripcion = txtDescripcion.Text
                };

                listaMetodos.Add(mp);
                NMetodosPago.Create(mp);
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

                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Hay campos vacíos.", "Alerta", MessageBoxButtons.OK);
                    return;
                }

               

                int id = int.Parse(labelId.Text);
                DialogResult result = MessageBox.Show("¿Desea modificar el registro?", "Alerta", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    MetodoPago mp = new MetodoPago
                    {
                        IdMetodoPago = id, // Propiedad de tu modelo MetodoPago
                        Descripcion = txtDescripcion.Text,
                        Activo = 1
                    };

                    NMetodosPago.Update(mp);
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

                MetodoPago mp = new MetodoPago
                {
                    IdMetodoPago = id,
                    Descripcion = txtDescripcion.Text
                };
              

                NMetodosPago.Delete(mp);
                MessageBox.Show("Registro eliminado.", "Exito", MessageBoxButtons.OK);
                UpdateDataGrid();
                Clean();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnProductosEliminados_Click(object sender, EventArgs e)
        {
            UIDeletedPaymentMethod elim = new UIDeletedPaymentMethod();
            elim.Show();
        }

        private void dgvMetodos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMetodos.CurrentRow == null) return;

            // Usamos los nombres (Name) que le dimos a las columnas en el diseñador
            labelId.Text = dgvMetodos.CurrentRow.Cells["IdMetodoPago"].Value?.ToString();
            txtDescripcion.Text = dgvMetodos.CurrentRow.Cells["Descripcion"].Value?.ToString();
        }
    }
}

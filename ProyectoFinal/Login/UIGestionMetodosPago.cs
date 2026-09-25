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
    public partial class UIGestionMetodosPago : Form
    {
        public List<MetodoPago> listaMetodos = new List<MetodoPago>();
        public UIGestionMetodosPago()
        {
            InitializeComponent();
            UpdateDataGrid();

            ConfigurarLabel(this.lblDescripcion, "Descripción", new System.Drawing.Point(16, 36));
            ConfigurarTextBox(this.txtDescripcion, new System.Drawing.Point(16, 56), new System.Drawing.Size(820, 32), 0);

            ConfigurarBotonPrimario(this.btnRegistrar, "Registrar",
                new System.Drawing.Point(20, 172), 1);
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(176, 172), 2);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(332, 172), 3);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnLimpiar, "Limpiar",
                new System.Drawing.Point(488, 172), 4);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            ConfigurarBotonFantasma(this.btnProductosEliminados, "Ver métodos eliminados",
                new System.Drawing.Point(20, 220), 5);
            this.btnProductosEliminados.Click += new System.EventHandler(this.btnProductosEliminados_Click);
        }
        private void UpdateDataGrid()
        {
            listaMetodos = NMetodosPago.GetAll();
            dgvMetodos.DataSource = null;

            // ¡Faltaba esta línea! Apaga la generación automática de columnas <- gemini botón
            //dgvMetodos.AutoGenerateColumns = false;
            dgvMetodos.DataSource = listaMetodos;
            if (dgvMetodos.Columns.Contains("Activo"))
            {
                dgvMetodos.Columns["Activo"].Visible = false;
            }
            if (dgvMetodos.Rows.Count > 0)
            {
                dgvMetodos.ClearSelection();
                dgvMetodos.Rows[0].Selected = true;
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
                if (NMetodosPago.ExisteMetodo(txtDescripcion.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un método con esa descripción.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MetodoPago mp = new MetodoPago
                {

                    Descripcion = txtDescripcion.Text
                };

                listaMetodos.Add(mp);
                NMetodosPago.Create(mp);
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
                Clean();
                UpdateDataGrid();
                
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void btnProductosEliminados_Click(object sender, EventArgs e)
        {
            UIMetodosPagoEliminados elim = new UIMetodosPagoEliminados();
            elim.Show();
        }

        private void dgvMetodos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMetodos.CurrentRow == null) return;

            // Usamos los nombres (Name) que le dimos a las columnas en el diseñador
            labelId.Text = dgvMetodos.CurrentRow.Cells["IdMetodoPago"].Value?.ToString();
            txtDescripcion.Text = dgvMetodos.CurrentRow.Cells["Descripcion"].Value?.ToString();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(200, 18));

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonFantasma(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(220, 30));

        private void pnlFormulario_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => UIStyles.PintarPanelRedondeado(sender, e);
    }
}

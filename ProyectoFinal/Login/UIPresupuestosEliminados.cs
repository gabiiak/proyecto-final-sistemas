using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIPresupuestosEliminados : Form
    {
        private List<Presupuesto> listaPresupuestosEliminados = new List<Presupuesto>();

        public UIPresupuestosEliminados()
        {
            InitializeComponent();
            dgvPresupuestosEliminados.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvPresupuestosEliminados);

            ConfigurarBotonPrimario(this.btnReactivar, "Reactivar",
                new System.Drawing.Point(20, 444), 0);
            this.btnReactivar.Size = new System.Drawing.Size(200, 40);
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click);

            ConfigurarBotonSecundario(this.btnCerrar, "Cerrar",
                new System.Drawing.Point(240, 444), 1);
            this.btnCerrar.Size = new System.Drawing.Size(150, 40);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
        }

        private void UIPresupuestosEliminados_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            try
            {
                listaPresupuestosEliminados = NPresupuesto.GetDeleted();
                dgvPresupuestosEliminados.DataSource = null;
                dgvPresupuestosEliminados.DataSource = listaPresupuestosEliminados;
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPresupuestosEliminados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPresupuestosEliminados.CurrentRow == null) return;
            labelId.Text = dgvPresupuestosEliminados.CurrentRow.Cells["IdPresupuesto"].Value?.ToString();
        }

        private void dgvPresupuestosEliminados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvPresupuestosEliminados.Columns[e.ColumnIndex].Name != "Total") return;
            if (e.Value == null) return;

            e.Value = "$" + e.Value;
            e.FormattingApplied = true;
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar un presupuesto eliminado.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            int id;
            if (!int.TryParse(labelId.Text, out id))
            {
                MessageBox.Show("No se pudo identificar el presupuesto seleccionado.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                NPresupuesto.ReactivarPresupuesto(id);
                MessageBox.Show("Presupuesto reactivado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelId.Text = "";
                ActualizarDataGridView();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ---------- Estilos ----------
        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));
    }
}

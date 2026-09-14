using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Login
{
    public partial class UIGestionTandas : Form
    {
        private List<TandaProduccion> listadoTandasTotales = new List<TandaProduccion>();
        private List<TandaProduccion> listadoTandasFiltradas = new List<TandaProduccion>();
        public int idTandaSeleccionada = 0;

        public UIGestionTandas()
        {
            InitializeComponent();
            dgvTodasLasTandas.AllowUserToAddRows = false;
            CargarFiltroProductos();
        }

        private void UIGestionTandas_Load(object sender, EventArgs e)
        {
            labelId.Text = "";
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            listadoTandasTotales = NTandaProduccion.ListarTandas();
            listadoTandasFiltradas = listadoTandasTotales;

            dgvTodasLasTandas.Rows.Clear();
            foreach (var tanda in listadoTandasTotales)
            {
                dgvTodasLasTandas.Rows.Add(
                    tanda.IdTanda,
                    tanda.Producto?.Nombre ?? "N/A",
                    tanda.Fecha.ToString("dd-MM-yyyy"),
                    tanda.Hora.ToString("HH:mm:ss"),
                    GetDescripcionEstado(tanda.EstadoTanda)
                );
            }
        }

        private string GetDescripcionEstado(int estado)
        {
            switch (estado)
            {
                case EstadoTanda.Pendiente: return "PENDIENTE";
                case EstadoTanda.EnProceso: return "EN PROCESO";
                case EstadoTanda.Terminada: return "TERMINADA";
                case EstadoTanda.Cancelada: return "CANCELADA";
                default: return "DESCONOCIDO";
            }
        }

        private void dgvTodasLasTandas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTodasLasTandas.CurrentRow == null) return;
            labelId.Text = dgvTodasLasTandas.CurrentRow.Cells["IdTanda"].Value?.ToString();
            int.TryParse(labelId.Text, out idTandaSeleccionada);
        }

        private void btnRegistrarTanda_Click(object sender, EventArgs e)
        {
            UIRegistrarTanda registrar = new UIRegistrarTanda();
            if (registrar.ShowDialog() == DialogResult.OK)
            {
                ActualizarDataGridView();
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (idTandaSeleccionada <= 0)
            {
                MessageBox.Show("Debe seleccionar una tanda de la lista.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UIEstadoTanda estadoForm = new UIEstadoTanda();
            if (estadoForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    NTandaProduccion.CambiarEstado(idTandaSeleccionada, estadoForm.RetornarEstado());
                    ActualizarDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al cambiar estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarFiltroProductos()
        {
            try
            {
                var productos = NProductos.GetAll();
                productos.Insert(0, new Producto { IdProducto = 0, Nombre = "Todos" });
                cbProductoFiltro.DataSource = productos;
                cbProductoFiltro.DisplayMember = "Nombre";
                cbProductoFiltro.ValueMember = "IdProducto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFiltrarPorFecha_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a 'Hasta'.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var listaFiltrada = listadoTandasTotales.Where(t => t.Fecha.Date >= desde && t.Fecha.Date <= hasta).ToList();
            if (listaFiltrada.Count == 0)
            {
                MessageBox.Show("No se encontraron tandas en el rango especificado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listadoTandasFiltradas = listaFiltrada;
            dgvTodasLasTandas.Rows.Clear();
            foreach (var tanda in listaFiltrada)
            {
                dgvTodasLasTandas.Rows.Add(
                    tanda.IdTanda,
                    tanda.Producto?.Nombre ?? "N/A",
                    tanda.Fecha.ToString("dd-MM-yyyy"),
                    tanda.Hora.ToString("HH:mm:ss"),
                    GetDescripcionEstado(tanda.EstadoTanda)
                );
            }
        }
        private void btnConsultarTanda_Click(object sender, EventArgs e)
        {
            if (idTandaSeleccionada <= 0)
            {
                MessageBox.Show("Debe seleccionar una tanda de la lista.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UIConsultarTanda consulta = new UIConsultarTanda(idTandaSeleccionada);
            consulta.ShowDialog();
        }

        private void btnFiltroProducto_Click(object sender, EventArgs e)
        {
            int idProd = ((Producto)cbProductoFiltro.SelectedItem).IdProducto;
            var listaFiltrada = listadoTandasTotales
                .Where(t => idProd == 0 || (t.Producto != null && t.Producto.IdProducto == idProd))
                .ToList();

            listadoTandasFiltradas = listaFiltrada;
            dgvTodasLasTandas.Rows.Clear();
            foreach (var tanda in listaFiltrada)
            {
                dgvTodasLasTandas.Rows.Add(
                    tanda.IdTanda,
                    tanda.Producto?.Nombre ?? "N/A",
                    tanda.Fecha.ToString("dd-MM-yyyy"),
                    tanda.Hora.ToString("HH:mm:ss"),
                    GetDescripcionEstado(tanda.EstadoTanda)
                );
            }
        }

        private void btnDesfiltrar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            if (cbProductoFiltro.Items.Count > 0) cbProductoFiltro.SelectedIndex = 0;
            ActualizarDataGridView();
        }
    }
}
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

            ConfigurarBotonPrimario(this.btnRegistrarTanda, "Nueva Tanda", new System.Drawing.Point(16, 16), 0);
            this.btnRegistrarTanda.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarTanda.Click += new System.EventHandler(this.btnRegistrarTanda_Click);

            // Botones secundarios en fila
            ConfigurarBotonSecundario(this.btnCambiarEstado, "Cambiar Estado", new System.Drawing.Point(16, 68), 1);
            this.btnCambiarEstado.Size = new System.Drawing.Size(138, 36);
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);

            ConfigurarBotonSecundario(this.btnConsultarTanda, "Ver Detalle", new System.Drawing.Point(166, 68), 2);
            this.btnConsultarTanda.Size = new System.Drawing.Size(138, 36);
            this.btnConsultarTanda.Click += new System.EventHandler(this.btnConsultarTanda_Click);

            ConfigurarLabel(this.lblDesde, "Desde", new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblHasta, "Hasta", new System.Drawing.Point(16, 68));

            ConfigurarBotonPrimario(this.btnFiltrarPorFecha, "Filtrar por fecha", new System.Drawing.Point(16, 145), 3);
            this.btnFiltrarPorFecha.Size = new System.Drawing.Size(180, 36);
            this.btnFiltrarPorFecha.Click += new System.EventHandler(this.btnFiltrarPorFecha_Click);

            ConfigurarLabel(this.lblFiltroProducto, "Filtrar por producto", new System.Drawing.Point(246, 16));
            this.cbProductoFiltro.Location = new System.Drawing.Point(246, 36);
            this.cbProductoFiltro.Size = new System.Drawing.Size(196, 28);

            ConfigurarBotonPrimario(this.btnFiltroProducto, "Filtrar", new System.Drawing.Point(246, 76), 4);
            this.btnFiltroProducto.Size = new System.Drawing.Size(120, 36);
            this.btnFiltroProducto.Click += new System.EventHandler(this.btnFiltroProducto_Click);

            ConfigurarBotonFantasma(this.btnDesfiltrar, "Quitar filtros", new System.Drawing.Point(246, 124), 5);
            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);
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
                    GetDescripcionEstado(tanda.EstadoTanda),
                    tanda.FechaCaducidad.ToString("dd-MM-yyyy")
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
                    int nuevoEstado = estadoForm.RetornarEstado();

                    if (nuevoEstado == EstadoTanda.Terminada)
                    {
                        NTandaProduccion.FinalizarTanda(idTandaSeleccionada);
                        MessageBox.Show("Tanda finalizada y stock actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (nuevoEstado == EstadoTanda.Cancelada)
                    {
                        NTandaProduccion.CancelarTanda(idTandaSeleccionada);
                        MessageBox.Show("Tanda cancelada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Para EnProceso / Pendiente, si esos cambios de estado no mueven stock,
                        // ahí sí alcanza con el cambio de estado simple
                        NTandaProduccion.CambiarEstado(idTandaSeleccionada, nuevoEstado);
                    }

                    ActualizarDataGridView();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    GetDescripcionEstado(tanda.EstadoTanda),
                    tanda.FechaCaducidad.ToString("dd-MM-yyyy")
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
                    GetDescripcionEstado(tanda.EstadoTanda),
                    tanda.FechaCaducidad.ToString("dd-MM-yyyy")
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

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(200, 18));

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex);

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex);

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonFantasma(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(200, 30));
    }
}
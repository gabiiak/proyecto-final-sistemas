using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegistrarPresupuesto : Form
    {
        private int idPresupuesto;
        private bool cargando;
        private SolicitudCotizacion solicitudActual;
        private List<SolicitudCotizacion> solicitudesPendientes = new List<SolicitudCotizacion>();
        private List<DetallePresupuesto> filasBase = new List<DetallePresupuesto>();
        private Dictionary<int, string> nombresProveedores = new Dictionary<int, string>();

        public UIRegistrarPresupuesto()
        {
            InitializeComponent();
            dgvDetalle.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvDetalle);

            ConfigurarBotonPrimario(this.btnGuardar, "Guardar",
                new System.Drawing.Point(20, 516), 2);
            this.btnGuardar.Size = new System.Drawing.Size(220, 44);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            ConfigurarBotonSecundario(this.btnCancelar, "Cancelar",
                new System.Drawing.Point(260, 516), 3);
            this.btnCancelar.Size = new System.Drawing.Size(150, 44);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.cbSolicitud.SelectedIndexChanged +=
                new System.EventHandler(this.cbSolicitud_SelectedIndexChanged);
            this.dgvDetalle.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellValueChanged);
            this.dgvDetalle.CellValidating +=
                new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetalle_CellValidating);
            this.dgvDetalle.DataError +=
                new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalle_DataError);
            UIStyles.AplicarTemaAForm(this);
        }

        public UIRegistrarPresupuesto(int idPresupuesto) : this()
        {
            this.idPresupuesto = idPresupuesto;
            this.Text = "Modificar presupuesto";
            this.lblTitulo.Text = "Modificar presupuesto";
        }

        private void UIRegistrarPresupuesto_Load(object sender, EventArgs e)
        {
            try
            {
                if (idPresupuesto > 0) CargarModificacion();
                else CargarSolicitudesPendientes();
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

        // ---------- Carga ----------
        private void CargarSolicitudesPendientes()
        {
            nombresProveedores = new Dictionary<int, string>();
            foreach (Proveedor proveedor in NProveedores.GetAll())
                nombresProveedores[proveedor.IdProveedor] = proveedor.Nombre;

            solicitudesPendientes = NPresupuesto.GetSolicitudesPendientes();

            cargando = true;
            cbSolicitud.DataSource = null;
            cbSolicitud.Items.Clear();
            foreach (SolicitudCotizacion solicitud in solicitudesPendientes)
            {
                cbSolicitud.Items.Add("N° " + solicitud.IdSolicitud + " - " +
                    GetNombreProveedor(solicitud.IdProveedor) + " - " +
                    solicitud.Fecha.ToString("dd-MM-yyyy"));
            }
            cargando = false;

            if (solicitudesPendientes.Count == 0)
            {
                MessageBox.Show("No hay solicitudes pendientes de presupuesto.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cbSolicitud.SelectedIndex = 0;
        }

        private void CargarModificacion()
        {
            Presupuesto presupuesto = NPresupuesto.GetById(idPresupuesto);
            if (presupuesto == null)
            {
                MessageBox.Show("No se encontró el presupuesto seleccionado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            solicitudActual = NSolicitudCotizacion.GetById(presupuesto.IdSolicitud);

            cargando = true;
            cbSolicitud.DataSource = null;
            cbSolicitud.Items.Clear();
            cbSolicitud.Items.Add("N° " + presupuesto.IdSolicitud + " - " +
                presupuesto.NombreProveedor + " - " + presupuesto.Fecha.ToString("dd-MM-yyyy"));
            cbSolicitud.SelectedIndex = 0;
            cbSolicitud.Enabled = false;
            cargando = false;

            List<DetallePresupuesto> detalles = NPresupuesto.GetDetalles(idPresupuesto);

            cargando = true;
            filasBase = new List<DetallePresupuesto>();
            dgvDetalle.Rows.Clear();
            foreach (DetallePresupuesto detalle in detalles)
            {
                filasBase.Add(new DetallePresupuesto
                {
                    IdInsumo = detalle.IdInsumo,
                    Cantidad = detalle.Cantidad,
                    NombreInsumo = detalle.NombreInsumo,
                    UnidadMedidaInsumo = detalle.UnidadMedidaInsumo
                });
                int indiceFila = dgvDetalle.Rows.Add(
                    detalle.NombreInsumo,
                    detalle.UnidadMedidaInsumo,
                    Math.Round(detalle.Cantidad, 4),
                    detalle.PrecioUnitario,
                    detalle.Subtotal);
                dgvDetalle.Rows[indiceFila].Tag = detalle.IdInsumo;
            }
            cargando = false;

            RecalcularTotal();
        }

        private string GetNombreProveedor(int id)
        {
            string nombre;
            return nombresProveedores.TryGetValue(id, out nombre) ? nombre : "Desconocido";
        }

        private void cbSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;

            int indice = cbSolicitud.SelectedIndex;
            if (indice < 0 || indice >= solicitudesPendientes.Count) return;

            try
            {
                solicitudActual = solicitudesPendientes[indice];
                CargarDetalleDesdeSolicitud(solicitudActual);
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

        private void CargarDetalleDesdeSolicitud(SolicitudCotizacion solicitud)
        {
            List<DetalleSolicitudCotizacion> detalles = NSolicitudCotizacion.GetDetalles(solicitud.IdSolicitud);
            Dictionary<int, decimal> precios = NPresupuesto.GetPreciosProveedor(solicitud.IdProveedor);
            Dictionary<int, decimal> preciosBase = NInsumos.GetAllInsumos()
                .ToDictionary(i => i.Id, i => i.Precio);

            cargando = true;
            filasBase = new List<DetallePresupuesto>();
            dgvDetalle.Rows.Clear();
            foreach (DetalleSolicitudCotizacion detalle in detalles)
            {
                decimal precio;
                if (!precios.TryGetValue(detalle.IdInsumo, out precio))
                {
                    decimal baseInsumo;
                    precio = preciosBase.TryGetValue(detalle.IdInsumo, out baseInsumo) && baseInsumo > 0
                        ? baseInsumo
                        : 100m;
                }

                decimal subtotal = Math.Round(precio * detalle.Cantidad, 2);
                filasBase.Add(new DetallePresupuesto
                {
                    IdInsumo = detalle.IdInsumo,
                    Cantidad = detalle.Cantidad,
                    NombreInsumo = detalle.NombreInsumo,
                    UnidadMedidaInsumo = detalle.UnidadMedidaInsumo
                });
                int indiceFila = dgvDetalle.Rows.Add(
                    detalle.NombreInsumo,
                    detalle.UnidadMedidaInsumo,
                    Math.Round(detalle.Cantidad, 4),
                    precio,
                    subtotal);
                dgvDetalle.Rows[indiceFila].Tag = detalle.IdInsumo;
            }
            cargando = false;

            RecalcularTotal();
        }

        // ---------- Cálculos ----------
        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cargando) return;
            if (e.RowIndex < 0 || e.ColumnIndex != colPrecioUnitario.Index) return;

            RecalcularFila(e.RowIndex);
            RecalcularTotal();
        }

        private void RecalcularFila(int indiceFila)
        {
            DataGridViewRow fila = dgvDetalle.Rows[indiceFila];

            decimal cantidad;
            decimal.TryParse(Convert.ToString(fila.Cells["Cantidad"].Value), out cantidad);

            decimal precio;
            decimal.TryParse(Convert.ToString(fila.Cells["PrecioUnitario"].Value), out precio);

            fila.Cells["Subtotal"].Value = Math.Round(precio * cantidad, 2);
        }

        private void RecalcularTotal()
        {
            decimal total = 0m;
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (fila.IsNewRow) continue;

                decimal subtotal;
                if (decimal.TryParse(Convert.ToString(fila.Cells["Subtotal"].Value), out subtotal))
                    total += subtotal;
            }

            lblTotal.Text = "$" + total.ToString();
        }

        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colPrecioUnitario.Index) return;

            DataGridViewRow fila = dgvDetalle.Rows[e.RowIndex];
            if (fila.IsNewRow) return;

            string texto = Convert.ToString(e.FormattedValue);
            if (string.IsNullOrWhiteSpace(texto)) return;

            decimal precio;
            if (!decimal.TryParse(texto, out precio) || precio <= 0)
            {
                fila.ErrorText = "Ingrese un precio numérico mayor a cero.";
                MessageBox.Show("El precio unitario debe ser numérico y mayor a cero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            fila.ErrorText = string.Empty;
        }

        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show("El valor ingresado en el detalle no es válido.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ---------- Guardar ----------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPresupuesto > 0) GuardarModificacion();
                else GuardarRegistro();

                MessageBox.Show("Presupuesto guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void GuardarRegistro()
        {
            if (solicitudActual == null)
                throw new ArgumentException("Debe seleccionar una solicitud de cotización.");

            List<DetallePresupuesto> detalles = ObtenerDetallesDesdeGrilla();

            Presupuesto presupuesto = new Presupuesto
            {
                IdSolicitud = solicitudActual.IdSolicitud,
                Fecha = DateTime.Now.Date
            };

            NPresupuesto.RegistrarPresupuesto(presupuesto, detalles);
        }

        private void GuardarModificacion()
        {
            Presupuesto original = NPresupuesto.GetById(idPresupuesto);
            if (original == null)
                throw new ArgumentException("El presupuesto no existe.");

            List<DetallePresupuesto> detalles = ObtenerDetallesDesdeGrilla();

            Presupuesto presupuesto = new Presupuesto
            {
                IdPresupuesto = idPresupuesto,
                IdSolicitud = original.IdSolicitud,
                Fecha = DateTime.Now.Date
            };

            NPresupuesto.ModificarPresupuesto(presupuesto, detalles);
        }

        private List<DetallePresupuesto> ObtenerDetallesDesdeGrilla()
        {
            List<DetallePresupuesto> detalles = new List<DetallePresupuesto>();
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                DataGridViewRow fila = dgvDetalle.Rows[i];
                if (fila.IsNewRow) continue;

                int idInsumo = Convert.ToInt32(fila.Tag);
                DetallePresupuesto baseFila = filasBase.Find(f => f.IdInsumo == idInsumo);
                if (baseFila == null)
                    throw new ArgumentException("No se pudo identificar el insumo de una fila del detalle.");

                decimal precio;
                if (!decimal.TryParse(Convert.ToString(fila.Cells["PrecioUnitario"].Value), out precio))
                    throw new ArgumentException("El precio unitario del insumo " +
                        baseFila.NombreInsumo + " debe ser numérico.");

                detalles.Add(new DetallePresupuesto
                {
                    IdInsumo = baseFila.IdInsumo,
                    Cantidad = baseFila.Cantidad,
                    PrecioUnitario = precio
                });
            }

            return detalles;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class UIGestionSolicitudesCotizacion : Form
    {
        private Dictionary<int, string> nombresProveedores = new Dictionary<int, string>();
        private List<Proveedor> proveedores = new List<Proveedor>();

        public UIGestionSolicitudesCotizacion()
        {
            InitializeComponent();
            dgvSolicitudes.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvSolicitudes);

            ConfigurarBotonPrimario(this.btnNuevaSolicitud, "Nueva solicitud",
                new System.Drawing.Point(16, 36), 0);
            this.btnNuevaSolicitud.Size = new System.Drawing.Size(288, 40);
            this.btnNuevaSolicitud.Click += new System.EventHandler(this.btnNuevaSolicitud_Click);

            ConfigurarBotonSecundario(this.btnVerPdf, "Ver PDF",
                new System.Drawing.Point(16, 92), 1);
            this.btnVerPdf.Size = new System.Drawing.Size(138, 36);
            this.btnVerPdf.Click += new System.EventHandler(this.btnVerPdf_Click);

            ConfigurarBotonSecundario(this.btnCerrar, "Cerrar",
                new System.Drawing.Point(166, 92), 2);
            this.btnCerrar.Size = new System.Drawing.Size(138, 36);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            UIStyles.AplicarTemaAForm(this);
        }

        private void UIGestionSolicitudesCotizacion_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            try
            {
                proveedores = NProveedores.GetAll();
                nombresProveedores = proveedores.ToDictionary(p => p.IdProveedor, p => p.Nombre);

                List<SolicitudCotizacion> solicitudes = NSolicitudCotizacion.GetAll();

                dgvSolicitudes.Rows.Clear();
                foreach (SolicitudCotizacion solicitud in solicitudes)
                {
                    dgvSolicitudes.Rows.Add(
                        solicitud.IdSolicitud,
                        GetNombreProveedor(solicitud.IdProveedor),
                        solicitud.Fecha,
                        UIRegistrarSolicitudCotizacion.GetDescripcionEstado(solicitud.Estado)
                    );
                }
                dgvSolicitudes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar las solicitudes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetNombreProveedor(int id)
        {
            string nombre;
            return nombresProveedores.TryGetValue(id, out nombre) ? nombre : "Desconocido";
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvSolicitudes.CurrentRow == null) return 0;

            int id;
            if (!int.TryParse(Convert.ToString(dgvSolicitudes.CurrentRow.Cells["IdSolicitud"].Value), out id))
                return 0;

            return id;
        }

        private void btnNuevaSolicitud_Click(object sender, EventArgs e)
        {
            UIRegistrarSolicitudCotizacion registrar = new UIRegistrarSolicitudCotizacion();
            registrar.ShowDialog();
            ActualizarDataGridView();
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            int id = ObtenerIdSeleccionado();
            if (id <= 0)
            {
                MessageBox.Show("Debe seleccionar una solicitud.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                SolicitudCotizacion solicitud = NSolicitudCotizacion.GetById(id);
                if (solicitud == null)
                {
                    MessageBox.Show("La solicitud no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Proveedor proveedor = proveedores.FirstOrDefault(p => p.IdProveedor == solicitud.IdProveedor);
                List<DetalleSolicitudCotizacion> detalles = NSolicitudCotizacion.GetDetalles(id);

                bool guardado = UIRegistrarSolicitudCotizacion.GenerarPdfSolicitud(
                    solicitud.IdSolicitud, proveedor, solicitud.Fecha, solicitud.Estado, detalles);

                if (guardado)
                {
                    MessageBox.Show("PDF generado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // ── Estilos (wrappers locales sobre UIStyles) ──────────────
        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));
    }
}

using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIConsultarTanda : Form
    {
        private int idTanda;

        public UIConsultarTanda(int idTanda)
        {
            InitializeComponent();
            this.idTanda = idTanda;
            dgvDetallesTanda.AllowUserToAddRows = false;

            ConfigurarLabelHeader(this.lblIdLabel, "ID Tanda:", new System.Drawing.Point(16, 12));
            ConfigurarLabelHeaderValor(this.lblValorId, "-", new System.Drawing.Point(90, 12));

            ConfigurarLabelHeader(this.lblProductoLabel, "Producto:", new System.Drawing.Point(16, 40));
            ConfigurarLabelHeaderValor(this.lblValorProducto, "-", new System.Drawing.Point(90, 40));

            ConfigurarLabelHeader(this.lblEstadoLabel, "Estado:", new System.Drawing.Point(16, 70));
            ConfigurarLabelHeaderValor(this.lblValorEstado, "-", new System.Drawing.Point(90, 70));

            ConfigurarLabelHeader(this.lblFechaLabel, "Fecha:", new System.Drawing.Point(340, 12));
            ConfigurarLabelHeaderValor(this.lblValorFecha, "-", new System.Drawing.Point(400, 12));

            ConfigurarLabelHeader(this.lblHoraLabel, "Hora:", new System.Drawing.Point(340, 40));
            ConfigurarLabelHeaderValor(this.lblValorHora, "-", new System.Drawing.Point(400, 40));
        }

        private void UIEstadoTanda_Load(object sender, EventArgs e)
        {
            try
            {
                TandaProduccion tanda = NTandaProduccion.ObtenerPorId(idTanda);
                if (tanda != null)
                {
                    lblValorId.Text = tanda.IdTanda.ToString();
                    lblValorProducto.Text = tanda.Producto?.Nombre ?? "N/A";
                    lblValorFecha.Text = tanda.Fecha.ToString("dd-MM-yyyy");
                    lblValorHora.Text = tanda.Hora.ToString("HH:mm:ss");
                    lblValorEstado.Text = GetDescripcionEstado(tanda.EstadoTanda);
                }

                List<DetalleTandaProduccion> detalles = NDetalleTandaProduccion.ObtenerDetallesPorTanda(idTanda);
                dgvDetallesTanda.Rows.Clear();
                double totalCantidad = 0;

                foreach (var det in detalles)
                {
                    dgvDetallesTanda.Rows.Add(
                        det.IdDetalleTanda,
                        det.Insumo?.Nombre ?? "N/A",
                        det.CantidadUtilizada,
                        det.Insumo.UnidadMedida
                        //$"{det.Empleado?.Nombre} {det.Empleado?.Apellido}" ?? "N/A",
                        //det.Empleado?.Cargo ?? "N/A"
                    );
                }

                lblTotalCantidad.Text = tanda.CantidadProducida.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la tanda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarLabelHeader(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabelHeader(lbl, texto, ubicacion);

        private void ConfigurarLabelHeaderValor(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabelHeaderValor(lbl, texto, ubicacion);
    }
}
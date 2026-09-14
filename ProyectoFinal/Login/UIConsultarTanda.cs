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
                int totalCantidad = 0;

                foreach (var det in detalles)
                {
                    dgvDetallesTanda.Rows.Add(
                        det.IdDetalleTanda,
                        det.Insumo?.Nombre ?? "N/A",
                        $"{det.Empleado?.Nombre} {det.Empleado?.Apellido}",
                        det.Empleado?.Cargo ?? "N/A",
                        det.CantidadProducida
                    );
                    totalCantidad += det.CantidadProducida;
                }

                lblTotalCantidad.Text = totalCantidad.ToString();
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
    }
}
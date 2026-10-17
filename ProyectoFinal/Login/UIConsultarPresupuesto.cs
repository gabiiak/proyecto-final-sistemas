using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIConsultarPresupuesto : Form
    {
        private int idPresupuesto;

        public UIConsultarPresupuesto(int idPresupuesto)
        {
            InitializeComponent();
            dgvDetalle.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvDetalle);
            this.idPresupuesto = idPresupuesto;

            ConfigurarLabelKey(this.lblCotizacionKey, "N° Cotización", new System.Drawing.Point(16, 12));
            ConfigurarLabelKey(this.lblProveedorKey, "Proveedor", new System.Drawing.Point(16, 56));
            ConfigurarLabelKey(this.lblFechaKey, "Fecha", new System.Drawing.Point(16, 100));
            ConfigurarLabelKey(this.lblEstadoKey, "Estado", new System.Drawing.Point(250, 12));
            ConfigurarLabelKey(this.lblTotalKey, "Total", new System.Drawing.Point(250, 56));

            ConfigurarLabelValor(this.labelCotizacion, new System.Drawing.Point(16, 30));
            ConfigurarLabelValor(this.labelProveedor, new System.Drawing.Point(16, 74));
            ConfigurarLabelValor(this.labelFecha, new System.Drawing.Point(16, 118));
            ConfigurarLabelValor(this.labelEstado, new System.Drawing.Point(250, 30));
            ConfigurarLabelValor(this.labelTotal, new System.Drawing.Point(250, 74));

            ConfigurarBotonSecundario(this.btnCerrar, "Cerrar",
                new System.Drawing.Point(20, 468), 1);
            this.btnCerrar.Size = new System.Drawing.Size(150, 40);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
        }

        private void UIConsultarPresupuesto_Load(object sender, EventArgs e)
        {
            try
            {
                Presupuesto presupuesto = NPresupuesto.GetById(idPresupuesto);
                if (presupuesto == null)
                {
                    MessageBox.Show("No se encontró el presupuesto seleccionado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                labelCotizacion.Text = presupuesto.IdSolicitud.ToString();
                labelProveedor.Text = presupuesto.NombreProveedor;
                labelFecha.Text = presupuesto.Fecha.ToString("dd-MM-yyyy");
                labelEstado.Text = UIRegistrarSolicitudCotizacion.GetDescripcionEstado(presupuesto.EstadoSolicitud);
                labelTotal.Text = "$" + presupuesto.Total;

                List<DetallePresupuesto> detalles = NPresupuesto.GetDetalles(idPresupuesto);

                dgvDetalle.Rows.Clear();
                foreach (DetallePresupuesto detalle in detalles)
                {
                    dgvDetalle.Rows.Add(
                        detalle.NombreInsumo,
                        detalle.UnidadMedidaInsumo,
                        Math.Round(detalle.Cantidad, 4),
                        "$" + detalle.PrecioUnitario,
                        "$" + detalle.Subtotal);
                }
                dgvDetalle.Refresh();
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
        private void ConfigurarLabelKey(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabelKey(lbl, texto, ubicacion);

        private void ConfigurarLabelValor(System.Windows.Forms.Label lbl,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabelValor(lbl, ubicacion);

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));
    }
}

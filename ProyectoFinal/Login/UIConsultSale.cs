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
using System.Windows.Forms.VisualStyles;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Login
{
    public partial class UIConsultSale : Form
    {
        private List<DetalleVenta> detalles = new List<DetalleVenta>();
        private int idVenta;
        public UIConsultSale(int idVenta)
        {
            InitializeComponent();
            dgvConsultaVenta.AllowUserToAddRows = false;
            this.idVenta = idVenta; //para recibir el id del label y asignarlo con constructor
        }

        private void UIConsultSale_Load(object sender, EventArgs e)
        {
            CargarVenta();
            CargarDetalles();
        }
        private void CargarVenta()
        {
            Venta venta = NVentas.GetVentaById(idVenta);
            labelCliente.Text = venta.Cliente.Nombre;
            labelMetodo.Text = venta.Metodo.Descripcion;
            labelFecha.Text = venta.Fecha;
            labelEstadoPago.Text = GetDescripcionEstadoPago(venta.Estado_Pago);
            labelEstadoPedido.Text = GetEstadoPedido(venta.Estado_Pedido);
            labelTotal.Text = venta.Total.ToString("C2");
        }

        private void CargarDetalles()
        {
            var detalles = NDetalleVentas.GetDetalleByIdVenta(idVenta);
            dgvConsultaVenta.Rows.Clear();
            foreach (DetalleVenta detalle in detalles)
            {
                dgvConsultaVenta.Rows.Add(
                    detalle.Producto.Nombre,
                    detalle.Cantidad,
                    detalle.SubTotal.ToString("C2")
                );
            }
        }
        private string GetEstadoPedido(int estado)
        {
            switch (estado)
            {
                case EstadoPedido.Cancelado: return "CANCELADO";
                case EstadoPedido.Preparacion: return "PREPARANDO";
                case EstadoPedido.Listo: return "LISTO";
                case EstadoPedido.EnViaje: return "VIAJANDO";
                case EstadoPedido.Entregado: return "ENTREGADO";
                default: return "DESCONOCIDO";
            }
        }
        private string GetDescripcionEstadoPago(int estado)
        {
            switch (estado)
            {
                case EstadoPago.Anulado: return "ANULADO";
                case EstadoPago.Pendiente: return "PENDIENTE";
                case EstadoPago.Pagado: return "PAGADO";
                default: return "DESCONOCIDO";
            }
        }

        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PDF|*.pdf";
            dialog.FileName = $"Factura_Venta_{idVenta}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (PdfWriter writer = new PdfWriter(dialog.FileName))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document doc = new Document(pdf))
                {
                    doc.Add(new Paragraph("T&G System - Factura")
                        .SetFontSize(18));
                    doc.Add(new Paragraph($"Cliente: {labelCliente.Text}"));
                    doc.Add(new Paragraph($"Fecha: {labelFecha.Text}"));
                    doc.Add(new Paragraph($"Método de pago: {labelMetodo.Text}"));
                    doc.Add(new Paragraph($"Estado pago: {labelEstadoPago.Text}"));
                    doc.Add(new Paragraph(" ")); // espacio

                    // tabla de detalles
                    Table tabla = new Table(3);
                    tabla.AddHeaderCell("Producto");
                    tabla.AddHeaderCell("Cantidad");
                    tabla.AddHeaderCell("SubTotal");

                    foreach (DataGridViewRow fila in dgvConsultaVenta.Rows)
                    {
                        tabla.AddCell(fila.Cells[0].Value.ToString());
                        tabla.AddCell(fila.Cells[1].Value.ToString());
                        tabla.AddCell(fila.Cells[2].Value.ToString());
                    }
                    doc.Add(tabla);
                    doc.Add(new Paragraph($"Total: {labelTotal.Text}"));
                }
                MessageBox.Show("Factura emitida con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;

namespace Login
{
    public partial class UIReporteCompras : Form
    {
        private readonly string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        private static readonly CultureInfo Es = new CultureInfo("es-AR");

        private List<Compra> comprasPeriodo = new List<Compra>();
        private Dictionary<int, string> proveedores;
        private int mesReporte, anioReporte;

        public UIReporteCompras()
        {
            InitializeComponent();

            proveedores = NProveedores.GetAll().ToDictionary(p => p.IdProveedor, p => p.Nombre);

            cbMes.Items.AddRange(meses);
            cbMes.SelectedIndex = DateTime.Today.Month - 1;

            nudAnio.Maximum = DateTime.Today.Year + 1;
            nudAnio.Value = DateTime.Today.Year;

            UIStyles.ConfigurarBotonPrimario(btnGenerar, "Generar reporte",
                new System.Drawing.Point(310, 40), 2, new System.Drawing.Size(160, 34));
            UIStyles.ConfigurarBotonSecundario(btnPdf, "Exportar PDF",
                new System.Drawing.Point(484, 40), 3, new System.Drawing.Size(150, 34));
            btnPdf.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                mesReporte = cbMes.SelectedIndex + 1;
                anioReporte = (int)nudAnio.Value;
                comprasPeriodo = NCompras.GetComprasPorPeriodo(anioReporte, mesReporte);

                dgvCompras.Rows.Clear();
                if (comprasPeriodo.Count == 0)
                {
                    lblResumen.Text = "";
                    btnPdf.Enabled = false;
                    MessageBox.Show("No se registraron compras en " + meses[mesReporte - 1] + " de " + anioReporte + ".",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (Compra c in comprasPeriodo)
                    dgvCompras.Rows.Add(c.IdCompra, NombreProveedor(c.IdProveedor), c.Fecha, c.TotalCompra,
                                        c.montoPagado, DescEstado(c.Estado), DescPago(c.EstadoPago));

                var validas = comprasPeriodo.Where(c => c.Estado != EstadoCompra.Cancelada).ToList();
                double total = validas.Sum(c => c.TotalCompra);
                double pagado = validas.Sum(c => c.montoPagado);
                lblResumen.Text = "Compras: " + validas.Count +
                    "   |   Total: " + total.ToString("C2", Es) +
                    "   |   Pagado: " + pagado.ToString("C2", Es) +
                    "   |   Deuda: " + (total - pagado).ToString("C2", Es) +
                    "\n(las compras canceladas se listan pero no suman)";
                btnPdf.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (comprasPeriodo.Count == 0) return;
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    dlg.FileName = "ReporteCompras_" + anioReporte + "_" + mesReporte.ToString("00") + ".pdf";
                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    GenerarPdf(dlg.FileName);
                    MessageBox.Show("PDF generado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- PDF ----------
        private void GenerarPdf(string ruta)
        {
            string periodo = Es.TextInfo.ToTitleCase(
                new DateTime(anioReporte, mesReporte, 1).ToString("MMMM yyyy", Es));

            PdfFont fNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont fBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            Color azul = new DeviceRgb(28, 58, 94);

            using (PdfWriter writer = new PdfWriter(ruta))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (iText.Layout.Document doc = new iText.Layout.Document(pdf, PageSize.A4.Rotate()))
            {
                doc.SetMargins(30, 30, 30, 30);

                doc.Add(new Paragraph("Reporte mensual de compras de insumos")
                    .SetFont(fBold).SetFontSize(16));
                doc.Add(new Paragraph("Período: " + periodo + "   |   Emitido: " +
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                    .SetFont(fNormal).SetFontSize(10).SetFontColor(ColorConstants.GRAY));
                doc.Add(new Paragraph(" "));

                Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 8, 24, 12, 14, 14, 14, 14 }))
                    .UseAllAvailableWidth();

                foreach (string h in new[] { "Nº", "Proveedor", "Fecha", "Total", "Pagado", "Estado", "Pago" })
                    tabla.AddHeaderCell(new Cell()
                        .Add(new Paragraph(h).SetFont(fBold).SetFontSize(9).SetFontColor(ColorConstants.WHITE))
                        .SetBackgroundColor(azul).SetPadding(5));

                foreach (Compra c in comprasPeriodo)
                {
                    tabla.AddCell(Celda(c.IdCompra.ToString(), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(NombreProveedor(c.IdProveedor), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(c.Fecha.ToString("dd/MM/yyyy"), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(c.TotalCompra.ToString("C2", Es), fNormal, TextAlignment.RIGHT));
                    tabla.AddCell(Celda(c.montoPagado.ToString("C2", Es), fNormal, TextAlignment.RIGHT));
                    tabla.AddCell(Celda(DescEstado(c.Estado), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(DescPago(c.EstadoPago), fNormal, TextAlignment.LEFT));
                }
                doc.Add(tabla);

                var validas = comprasPeriodo.Where(c => c.Estado != EstadoCompra.Cancelada).ToList();
                double total = validas.Sum(c => c.TotalCompra);
                double pagado = validas.Sum(c => c.montoPagado);
                double promedio = validas.Count > 0 ? total / validas.Count : 0;

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph("Resumen (sin compras canceladas)").SetFont(fBold).SetFontSize(10));
                doc.Add(new Paragraph("Cantidad de compras: " + validas.Count).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Total comprado: " + total.ToString("C2", Es)).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Total pagado: " + pagado.ToString("C2", Es)).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Deuda pendiente: " + (total - pagado).ToString("C2", Es)).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Promedio por compra: " + promedio.ToString("C2", Es)).SetFont(fNormal).SetFontSize(9));
            }
        }

        private static Cell Celda(string texto, PdfFont fuente, TextAlignment alineacion)
            => new Cell()
                .Add(new Paragraph(texto).SetFont(fuente).SetFontSize(9).SetTextAlignment(alineacion))
                .SetPadding(4);
        // ---------- Auxiliares ----------
        private string NombreProveedor(int id)
            => proveedores.TryGetValue(id, out string n) ? n : "Desconocido";

        private string DescEstado(int estado)
        {
            switch (estado)
            {
                case EstadoCompra.Emitida: return "EMITIDA";
                case EstadoCompra.Aceptada: return "ACEPTADA";
                case EstadoCompra.Enviada: return "ENVIADA";
                case EstadoCompra.Recibida: return "RECIBIDA";
                case EstadoCompra.Cancelada: return "CANCELADA";
                default: return "DESCONOCIDO";
            }
        }

        private string DescPago(int estadoPago)
        {
            switch (estadoPago)
            {
                case EstadoPago.Pendiente: return "PENDIENTE";
                case EstadoPago.Pagado: return "PAGADA";
                default: return "DESCONOCIDO";
            }
        }
    }
}
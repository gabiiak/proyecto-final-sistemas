using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class UIReporteTandas : Form
    {
        private readonly string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        private static readonly CultureInfo Es = new CultureInfo("es-AR");

        private List<TandaProduccion> tandasPeriodo = new List<TandaProduccion>();
        private int mesReporte, anioReporte;

        public UIReporteTandas()
        {
            InitializeComponent();

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
                tandasPeriodo = NTandaProduccion.GetTandasPorPeriodo(anioReporte, mesReporte);

                dgvTandas.Rows.Clear();
                if (tandasPeriodo.Count == 0)
                {
                    lblResumen.Text = "";
                    btnPdf.Enabled = false;
                    MessageBox.Show("No se registraron tandas de producción en " + meses[mesReporte - 1] + " de " + anioReporte + ".",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (TandaProduccion t in tandasPeriodo)
                    dgvTandas.Rows.Add(t.IdTanda, t.Producto?.Nombre ?? "N/A", t.Fecha,
                                       t.Hora.ToString("HH:mm"), t.CantidadProducida,
                                       DescEstado(t.EstadoTanda), TextoCaducidad(t));

                int terminadas = tandasPeriodo.Count(t => t.EstadoTanda == EstadoTanda.Terminada);
                int canceladas = tandasPeriodo.Count(t => t.EstadoTanda == EstadoTanda.Cancelada);
                int unidades = tandasPeriodo.Where(t => t.EstadoTanda == EstadoTanda.Terminada)
                                            .Sum(t => t.CantidadProducida);

                lblResumen.Text = "Tandas: " + tandasPeriodo.Count +
                    "   |   Terminadas: " + terminadas +
                    "   |   Canceladas: " + canceladas +
                    "   |   Unidades producidas (terminadas): " + unidades +
                    "\n(solo las tandas terminadas suman unidades producidas)";
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
            if (tandasPeriodo.Count == 0) return;
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    dlg.FileName = "ReporteTandas_" + anioReporte + "_" + mesReporte.ToString("00") + ".pdf";
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

        // ---------- PDF (iText 9) ----------
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

                doc.Add(new Paragraph("Reporte mensual de tandas de producción")
                    .SetFont(fBold).SetFontSize(16));
                doc.Add(new Paragraph("Período: " + periodo + "   |   Emitido: " +
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                    .SetFont(fNormal).SetFontSize(10).SetFontColor(ColorConstants.GRAY));
                doc.Add(new Paragraph(" "));

                Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 7, 25, 12, 9, 12, 15, 14 }))
                    .UseAllAvailableWidth();

                foreach (string h in new[] { "Nº", "Producto", "Fecha", "Hora", "Cantidad", "Estado", "Caducidad" })
                    tabla.AddHeaderCell(new Cell()
                        .Add(new Paragraph(h).SetFont(fBold).SetFontSize(9).SetFontColor(ColorConstants.WHITE))
                        .SetBackgroundColor(azul).SetPadding(5));

                foreach (TandaProduccion t in tandasPeriodo)
                {
                    tabla.AddCell(Celda(t.IdTanda.ToString(), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(t.Producto?.Nombre ?? "N/A", fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(t.Fecha.ToString("dd/MM/yyyy"), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(t.Hora.ToString("HH:mm"), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(t.CantidadProducida.ToString(), fNormal, TextAlignment.RIGHT));
                    tabla.AddCell(Celda(DescEstado(t.EstadoTanda), fNormal, TextAlignment.LEFT));
                    tabla.AddCell(Celda(TextoCaducidad(t), fNormal, TextAlignment.LEFT));
                }
                doc.Add(tabla);

                int terminadas = tandasPeriodo.Count(t => t.EstadoTanda == EstadoTanda.Terminada);
                int canceladas = tandasPeriodo.Count(t => t.EstadoTanda == EstadoTanda.Cancelada);
                int enCurso = tandasPeriodo.Count - terminadas - canceladas;
                int unidades = tandasPeriodo.Where(t => t.EstadoTanda == EstadoTanda.Terminada)
                                            .Sum(t => t.CantidadProducida);

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph("Resumen del período").SetFont(fBold).SetFontSize(10));
                doc.Add(new Paragraph("Cantidad de tandas: " + tandasPeriodo.Count).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Terminadas: " + terminadas).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Pendientes / en proceso: " + enCurso).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Canceladas: " + canceladas).SetFont(fNormal).SetFontSize(9));
                doc.Add(new Paragraph("Unidades producidas (tandas terminadas): " + unidades).SetFont(fNormal).SetFontSize(9));

                // Unidades por producto (solo terminadas)
                var porProducto = tandasPeriodo
                    .Where(t => t.EstadoTanda == EstadoTanda.Terminada)
                    .GroupBy(t => t.Producto?.Nombre ?? "N/A")
                    .Select(g => new { Producto = g.Key, Tandas = g.Count(), Unidades = g.Sum(t => t.CantidadProducida) })
                    .OrderByDescending(x => x.Unidades)
                    .ToList();

                if (porProducto.Count > 0)
                {
                    doc.Add(new Paragraph(" "));
                    doc.Add(new Paragraph("Producción por producto (tandas terminadas)").SetFont(fBold).SetFontSize(10));

                    Table t2 = new Table(UnitValue.CreatePercentArray(new float[] { 50, 20, 30 })).UseAllAvailableWidth();
                    foreach (string h in new[] { "Producto", "Tandas", "Unidades" })
                        t2.AddHeaderCell(new Cell()
                            .Add(new Paragraph(h).SetFont(fBold).SetFontSize(9).SetFontColor(ColorConstants.WHITE))
                            .SetBackgroundColor(azul).SetPadding(5));
                    foreach (var x in porProducto)
                    {
                        t2.AddCell(Celda(x.Producto, fNormal, TextAlignment.LEFT));
                        t2.AddCell(Celda(x.Tandas.ToString(), fNormal, TextAlignment.RIGHT));
                        t2.AddCell(Celda(x.Unidades.ToString(), fNormal, TextAlignment.RIGHT));
                    }
                    doc.Add(t2);
                }
            }
        }

        private static Cell Celda(string texto, PdfFont fuente, TextAlignment alineacion)
            => new Cell()
                .Add(new Paragraph(texto).SetFont(fuente).SetFontSize(9).SetTextAlignment(alineacion))
                .SetPadding(4);

        // ---------- Auxiliares ----------
        private string TextoCaducidad(TandaProduccion t)
            => t.FechaCaducidad == DateTime.MinValue ? "-" : t.FechaCaducidad.ToString("dd-MM-yyyy");

        private string DescEstado(int estado)
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
    }
}
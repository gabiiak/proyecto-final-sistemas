using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Image = iText.Layout.Element.Image;

namespace Login
{
    public partial class UIConsultarCompra : Form
    {
        private int idCompra;
        private Compra compra;

        public UIConsultarCompra(int idCompra)
        {
            InitializeComponent();
            dgvConsultaCompra.AllowUserToAddRows = false;
            this.idCompra = idCompra; // recibe el id de la compra seleccionada en Gestión

            // Columna izquierda
            ConfigurarLabelKey(this.lblProveedorKey, "Proveedor", new System.Drawing.Point(16, 12));
            ConfigurarLabelKey(this.lblFechaKey, "Fecha", new System.Drawing.Point(16, 56));
            ConfigurarLabelKey(this.lblFechaRecepcionKey, "Fecha de recepción", new System.Drawing.Point(16, 100));
            ConfigurarLabelKey(this.lblDeudaKey, "Deuda pendiente", new System.Drawing.Point(16, 144));

            ConfigurarLabelValor(this.labelProveedor, new System.Drawing.Point(16, 30));
            ConfigurarLabelValor(this.labelFecha, new System.Drawing.Point(16, 74));
            ConfigurarLabelValor(this.labelFechaRecepcion, new System.Drawing.Point(16, 118));
            ConfigurarLabelValor(this.labelDeuda, new System.Drawing.Point(16, 162));

            // Columna derecha
            ConfigurarLabelKey(this.lblEstadoKey, "Estado de la compra", new System.Drawing.Point(240, 12));
            ConfigurarLabelKey(this.lblEstadoPagoKey, "Estado de pago", new System.Drawing.Point(240, 56));
            ConfigurarLabelKey(this.lblPagadoKey, "Monto pagado", new System.Drawing.Point(240, 100));

            ConfigurarLabelValor(this.labelEstado, new System.Drawing.Point(240, 30));
            ConfigurarLabelValor(this.labelEstadoPago, new System.Drawing.Point(240, 74));
            ConfigurarLabelValor(this.labelPagado, new System.Drawing.Point(240, 118));

            ConfigurarBotonPrimario(this.btnEmitirOrden, "Emitir Orden de Compra PDF",
                new System.Drawing.Point(20, 548), 1);
            this.btnEmitirOrden.Size = new System.Drawing.Size(280, 40);
            this.btnEmitirOrden.Click += new System.EventHandler(this.btnEmitirOrden_Click);

            ConfigurarBotonSecundario(this.btnSalir, "Cerrar",
                new System.Drawing.Point(312, 548), 2);
            this.btnSalir.Size = new System.Drawing.Size(148, 40);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            ConfigurarBotonSecundario(this.btnEditarFechas, "Editar fechas",
                new System.Drawing.Point(20, 596), 3);
            this.btnEditarFechas.Size = new System.Drawing.Size(200, 36);
            this.btnEditarFechas.Click += new System.EventHandler(this.btnEditarFechas_Click);
        }

        private void UIConsultarCompra_Load(object sender, EventArgs e)
        {
            CargarCompra();
            CargarDetalles();
        }

        private void CargarCompra()
        {
            compra = NCompras.GetCompraById(idCompra);
            if (compra == null)
            {
                MessageBox.Show("No se encontró la compra seleccionada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Proveedor proveedor = NProveedores.GetAll().FirstOrDefault(p => p.IdProveedor == compra.IdProveedor);

            labelProveedor.Text = proveedor != null ? proveedor.Nombre : "Desconocido";
            labelFecha.Text = compra.Fecha.ToString("dd-MM-yyyy");
            labelFechaRecepcion.Text = compra.FechaRecepcion.HasValue
                ? compra.FechaRecepcion.Value.ToString("dd-MM-yyyy")
                : "-";
            labelEstado.Text = GetDescripcionEstado(compra.Estado);
            labelEstadoPago.Text = GetDescripcionEstadoPago(compra.EstadoPago);
            labelPagado.Text = compra.montoPagado.ToString("C2");
            labelDeuda.Text = (compra.TotalCompra - compra.montoPagado).ToString("C2");
            labelTotal.Text = compra.TotalCompra.ToString("C2");
        }

        private void CargarDetalles()
        {
            Dictionary<int, string> nombresInsumos = NInsumos.GetAllInsumos().ToDictionary(i => i.Id, i => i.Nombre);
            List<DetalleCompra> detalles = NDetalleCompras.GetDetalleByIdCompra(idCompra);

            dgvConsultaCompra.Rows.Clear();
            foreach (DetalleCompra detalle in detalles)
            {
                string nombre = nombresInsumos.TryGetValue(detalle.IdInsumo, out string n) ? n : "Desconocido";
                dgvConsultaCompra.Rows.Add(
                    nombre,
                    detalle.Cantidad,
                    detalle.Subtotal.ToString("C2")
                );
            }
        }

        private string GetDescripcionEstado(int estado)
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

        private string GetDescripcionEstadoPago(int estadoPago)
        {
            switch (estadoPago)
            {
                case EstadoPago.Pendiente: return "PENDIENTE";
                case EstadoPago.Pagado: return "PAGADA";
                default: return "DESCONOCIDO";
            }
        }

        private void btnEditarFechas_Click(object sender, EventArgs e)
        {
            UIEditarFechasCompra editar = new UIEditarFechasCompra(idCompra);
            editar.ShowDialog();
            CargarCompra();
        }

        private void btnEmitirOrden_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PDF|*.pdf";
            dialog.FileName = $"OrdenCompra_{idCompra}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (PdfWriter writer = new PdfWriter(dialog.FileName))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document doc = new Document(pdf))
                {
                    // paleta de colores
                    iText.Kernel.Colors.Color colorPrimario = new DeviceRgb(230, 126, 34);
                    iText.Kernel.Colors.Color colorTextoOscuro = new DeviceRgb(44, 62, 80);
                    iText.Kernel.Colors.Color colorGrisClaro = new DeviceRgb(245, 247, 250);

                    // --- CABECERA (Logo + Info Empresa) ---
                    Table cabecera = new Table(UnitValue.CreatePercentArray(new float[] { 30f, 70f })).SetWidth(UnitValue.CreatePercentValue(100));
                    cabecera.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                    string rutaLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "logoEmpresa.png");
                    if (File.Exists(rutaLogo))
                    {
                        ImageData data = ImageDataFactory.Create(rutaLogo);
                        Image img = new Image(data).SetWidth(100).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                        Cell cellLogo = new Cell().Add(img).SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                        cabecera.AddCell(cellLogo);
                    }
                    else
                    {
                        // Fallback explícito: si falta el logo, se muestra el nombre de la empresa.
                        Cell cellLogo = new Cell()
                            .Add(new Paragraph("F&G Hamburguesas").SetFontSize(11).SetFontColor(colorPrimario))
                            .SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                        cabecera.AddCell(cellLogo);
                    }

                    Paragraph infoEmpresa = new Paragraph()
                        .Add(new Text("F&G Hamburguesas\n").SetFontSize(20).SetFontColor(colorPrimario))
                        .Add(new Text("24950 Deldotto Fernando\n").SetFontSize(9))
                        .Add(new Text("Dirección: Sánchez de Bustamante 5168, B° Dean funes, Córdoba\nTeléfono: +54 9 351 123 4567\nEmail: contacto@fghamburguesas.com").SetFontSize(9).SetFontColor(ColorConstants.GRAY))
                        .SetTextAlignment(TextAlignment.RIGHT);

                    Cell cellInfo = new Cell().Add(infoEmpresa).SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    cabecera.AddCell(cellInfo);
                    doc.Add(cabecera);

                    // divisora
                    LineSeparator lineaDivisoria = new LineSeparator(new SolidLine(1f));
                    lineaDivisoria.SetMarginTop(15f);
                    lineaDivisoria.SetMarginBottom(15f);
                    doc.Add(lineaDivisoria);

                    // --- PROVEEDOR Y DATOS DE LA ORDEN ---
                    Table infoCompra = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 50f })).SetWidth(UnitValue.CreatePercentValue(100));
                    infoCompra.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    infoCompra.SetMarginBottom(20f);

                    Paragraph datosProveedor = new Paragraph()
                        .Add(new Text("DATOS DEL PROVEEDOR\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text($"Proveedor: {labelProveedor.Text}\n").SetFontSize(10))
                        .SetFontColor(colorTextoOscuro);
                    infoCompra.AddCell(new Cell().Add(datosProveedor).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    Paragraph datosOrden = new Paragraph()
                        .Add(new Text("ORDEN DE COMPRA\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text($"N° Orden: {idCompra.ToString().PadLeft(8, '0')}\n").SetFontSize(10))
                        .Add(new Text($"Fecha: {labelFecha.Text}\n").SetFontSize(10))
                        .Add(new Text($"Fecha de recepción: {labelFechaRecepcion.Text}\n").SetFontSize(10))
                        .Add(new Text($"Estado: {labelEstado.Text}\n").SetFontSize(10))
                        .Add(new Text($"Estado de pago: {labelEstadoPago.Text}\n").SetFontSize(10))
                        .Add(new Text($"Monto pagado: {labelPagado.Text}\n").SetFontSize(10))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetFontColor(colorTextoOscuro);
                    infoCompra.AddCell(new Cell().Add(datosOrden).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    doc.Add(infoCompra);

                    // --- TABLA DE DETALLES ---
                    doc.Add(new Paragraph("DETALLE DE COMPRA").SetFontSize(12).SetFontColor(colorTextoOscuro).SetMarginBottom(8f));

                    Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 20f, 30f })).SetWidth(UnitValue.CreatePercentValue(100));

                    string[] encabezados = { "Insumo", "Cantidad", "SubTotal" };
                    foreach (var nomHeader in encabezados)
                    {
                        Cell headerCell = new Cell().Add(new Paragraph(nomHeader).SetFontColor(ColorConstants.WHITE).SetFontSize(10));
                        headerCell.SetBackgroundColor(colorTextoOscuro);
                        headerCell.SetPadding(6f);
                        headerCell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                        if (nomHeader == "SubTotal") headerCell.SetTextAlignment(TextAlignment.RIGHT);
                        else if (nomHeader == "Cantidad") headerCell.SetTextAlignment(TextAlignment.CENTER);

                        tabla.AddHeaderCell(headerCell);
                    }

                    bool filaAlterna = false;
                    foreach (DataGridViewRow fila in dgvConsultaCompra.Rows)
                    {
                        if (fila.Cells[0].Value == null) continue;

                        Cell cInsumo = new Cell().Add(new Paragraph(fila.Cells[0].Value.ToString()).SetFontSize(10));
                        Cell cCantidad = new Cell().Add(new Paragraph(fila.Cells[1].Value.ToString()).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
                        Cell cSubtotal = new Cell().Add(new Paragraph(fila.Cells[2].Value.ToString()).SetFontSize(10).SetTextAlignment(TextAlignment.RIGHT));

                        Cell[] celdas = { cInsumo, cCantidad, cSubtotal };
                        foreach (var celda in celdas)
                        {
                            celda.SetPadding(6f);
                            celda.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                            celda.SetBorderBottom(new iText.Layout.Borders.SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f));

                            if (filaAlterna) celda.SetBackgroundColor(colorGrisClaro);
                        }

                        tabla.AddCell(cInsumo);
                        tabla.AddCell(cCantidad);
                        tabla.AddCell(cSubtotal);

                        filaAlterna = !filaAlterna;
                    }
                    doc.Add(tabla);

                    // --- TOTALES ---
                    Paragraph totalBlock = new Paragraph()
                        .Add(new Text("TOTAL: ").SetFontSize(14).SetFontColor(colorTextoOscuro))
                        .Add(new Text(labelTotal.Text).SetFontSize(16).SetFontColor(colorPrimario))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginTop(15f);
                    doc.Add(totalBlock);

                    Paragraph saldoBlock = new Paragraph()
                        .Add(new Text($"Pagado: {labelPagado.Text}    |    Saldo pendiente: {labelDeuda.Text}").SetFontSize(10).SetFontColor(ColorConstants.GRAY))
                        .SetTextAlignment(TextAlignment.RIGHT);
                    doc.Add(saldoBlock);
                }
                MessageBox.Show("Orden de compra emitida con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarLabelKey(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabelKey(lbl, texto, ubicacion);

        private void ConfigurarLabelValor(System.Windows.Forms.Label lbl,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabelValor(lbl, ubicacion);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => UIStyles.PintarPanelRedondeado(sender, e);
    }
}
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LiveChartsCore.Kernel.Providers;
using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Image = iText.Layout.Element.Image;

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
            labelFecha.Text = venta.Fecha.ToString("dd-MM-yyyy");
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
                    // paleta de coloresss
                    iText.Kernel.Colors.Color colorPrimario = new DeviceRgb(230, 126, 34); // Naranja sutil gastronómico
                    iText.Kernel.Colors.Color colorTextoOscuro = new DeviceRgb(44, 62, 80); // Gris oscuro profesional
                    iText.Kernel.Colors.Color colorGrisClaro = new DeviceRgb(245, 247, 250); // Fondo para encabezados

                    Table tablaTipoDoc = new Table(1).SetWidth(UnitValue.CreatePercentValue(14));
                    tablaTipoDoc.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    tablaTipoDoc.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                    Cell celdaTipoDoc = new Cell()
                        .Add(new Paragraph("A")
                            .SetFontSize(18)
                            .SetFontColor(colorTextoOscuro)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetMargin(0));
                    celdaTipoDoc.SetBorder(new iText.Layout.Borders.SolidBorder(colorTextoOscuro, 1f));
                    celdaTipoDoc.SetWidth(24f);
                    celdaTipoDoc.SetHeight(24f);
                    celdaTipoDoc.SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);
                    celdaTipoDoc.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);

                    tablaTipoDoc.AddCell(celdaTipoDoc);
                    doc.Add(tablaTipoDoc);

                    // --- CABECERA DE LA FACTURA (Logo + Info Empresa) ---
                    // Tabla de 2 columnas para organizar el tope del documento sin bordes
                    Table cabecera = new Table(UnitValue.CreatePercentArray(new float[] { 30f, 70f })).SetWidth(UnitValue.CreatePercentValue(100));
                    cabecera.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                    // Celda del Logo
                    try
                    {
                        string rutaLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "logoEmpresa.png");
                        ImageData data = ImageDataFactory.Create(rutaLogo);
                        Image img = new Image(data).SetWidth(100).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                        Cell cellLogo = new Cell().Add(img).SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                        cabecera.AddCell(cellLogo);
                    }
                    catch (Exception)
                    {
                        // Si no encuentra el logo, añade una celda vacía para no romper el diseño
                        cabecera.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                    }

                    // Celda de Datos de la Empresa (Lorem Ipsum solicitado)
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

                    // --- INFORMACIÓN DEL CLIENTE Y COMPROBANTE ---
                    // Creamos una estructura de dos columnas para los datos del cliente y de la venta
                    Table infoVenta = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 50f })).SetWidth(UnitValue.CreatePercentValue(100));
                    infoVenta.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    infoVenta.SetMarginBottom(20f);

                    // Columna Izquierda: Cliente
                    Paragraph datosCliente = new Paragraph()
                        .Add(new Text("DATOS DEL CLIENTE\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text($"Cliente: {labelCliente.Text}\n").SetFontSize(10))
                        .Add(new Text($"Método de pago: {labelMetodo.Text}\n").SetFontSize(10))
                        .SetFontColor(colorTextoOscuro);
                    infoVenta.AddCell(new Cell().Add(datosCliente).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    // Columna Derecha: Datos Factura
                    Paragraph datosFactura = new Paragraph()
                        .Add(new Text($"FACTURA ELECTRÓNICA\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text($"N° Comprobante: {idVenta.ToString().PadLeft(8, '0')}\n").SetFontSize(10))
                        .Add(new Text($"Fecha: {labelFecha.Text}\n").SetFontSize(10))
                        .Add(new Text($"Estado del pago: {labelEstadoPago.Text}\n").SetFontSize(10))
                        .Add(new Text($"Estado del pedido: {labelEstadoPedido.Text}\n").SetFontSize(10))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetFontColor(colorTextoOscuro);
                    infoVenta.AddCell(new Cell().Add(datosFactura).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    doc.Add(infoVenta);

                    // --- TABLA DE DETALLES DEL PEDIDO ---
                    doc.Add(new Paragraph("DETALLE DE VENTA").SetFontSize(12).SetFontColor(colorTextoOscuro).SetMarginBottom(8f));

                    // Definimos anchos proporcionales para Producto (50%), Cantidad (20%) y Subtotal (30%)
                    Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 20f, 30f })).SetWidth(UnitValue.CreatePercentValue(100));

                    // Estilizado del Encabezado de la Tabla
                    string[] encabezados = { "Producto", "Cantidad", "SubTotal" };
                    foreach (var nomHeader in encabezados)
                    {
                        Cell headerCell = new Cell().Add(new Paragraph(nomHeader).SetFontColor(ColorConstants.WHITE).SetFontSize(10));
                        headerCell.SetBackgroundColor(colorTextoOscuro);
                        headerCell.SetPadding(6f);
                        headerCell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                        // Alinear a la derecha el encabezado del SubTotal
                        if (nomHeader == "SubTotal") headerCell.SetTextAlignment(TextAlignment.RIGHT);
                        else if (nomHeader == "Cantidad") headerCell.SetTextAlignment(TextAlignment.CENTER);

                        tabla.AddHeaderCell(headerCell);
                    }

                    // Llenado de filas del DataGridView
                    bool filaAlterna = false;
                    foreach (DataGridViewRow fila in dgvConsultaVenta.Rows)
                    {
                        if (fila.Cells[0].Value == null) continue; // Previene filas vacías al final del grid

                        // Celda Producto
                        Cell cProducto = new Cell().Add(new Paragraph(fila.Cells[0].Value.ToString()).SetFontSize(10));
                        // Celda Cantidad
                        Cell cCantidad = new Cell().Add(new Paragraph(fila.Cells[1].Value.ToString()).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
                        // Celda Subtotal
                        Cell cSubtotal = new Cell().Add(new Paragraph(fila.Cells[2].Value.ToString()).SetFontSize(10).SetTextAlignment(TextAlignment.RIGHT));

                        // Aplicamos padding y removemos bordes toscos laterales
                        Cell[] celdas = { cProducto, cCantidad, cSubtotal };
                        foreach (var celda in celdas)
                        {
                            celda.SetPadding(6f);
                            celda.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                            celda.SetBorderBottom(new iText.Layout.Borders.SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f));

                            // Efecto cebra para mejorar la lectura de las filas
                            if (filaAlterna) celda.SetBackgroundColor(colorGrisClaro);
                        }

                        tabla.AddCell(cProducto);
                        tabla.AddCell(cCantidad);
                        tabla.AddCell(cSubtotal);

                        filaAlterna = !filaAlterna;
                    }
                    doc.Add(tabla);

                    // --- SECCIÓN TOTAL ---
                    Paragraph totalBlock = new Paragraph()
                        .Add(new Text($"TOTAL: ").SetFontSize(14).SetFontColor(colorTextoOscuro))
                        .Add(new Text(labelTotal.Text).SetFontSize(16).SetFontColor(colorPrimario))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginTop(15f);

                    doc.Add(totalBlock);
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
/*using (PdfWriter writer = new PdfWriter(dialog.FileName))

        using (PdfDocument pdf = new PdfDocument(writer))

        using (Document doc = new Document(pdf))

        {

            ImageData data = ImageDataFactory.Create("C:/Codigo/C#/ProyectoFinal/ProyectoFinal/Assets/logoEmpresa.png");

            Image img = new Image(data);

            img.SetHeight(120);

            img.SetAutoScale(false);

            doc.Add(img);

            doc.Add(new Paragraph("F&G Hamburguesas - Factura Electrónica")

                .SetFontSize(22));

            //agregar datos de la empresa: 



            //agregar linea 


            //parte del cliente

            doc.Add(new Paragraph($"Cliente: {labelCliente.Text}"));

            doc.Add(new Paragraph($"Fecha: {labelFecha.Text}"));

            doc.Add(new Paragraph($"Método de pago: {labelMetodo.Text}"));

            doc.Add(new Paragraph($"Estado pago: {labelEstadoPago.Text}"));

            doc.Add(new Paragraph(" ")); // espacio


            // tabla de detalles

            Table tabla = new Table(3);

            doc.Add(new Paragraph("Lista de detalles: "));

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

            doc.Add(new Paragraph($"Total: {labelTotal.Text}").SetFontSize(18)); */

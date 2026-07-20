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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Image = iText.Layout.Element.Image;

namespace Login
{
    public partial class UIListaTransportes : Form
    {
        // Mismos textos que usa cbEstado en UITransporte, para mostrar el estado como texto.
        private static readonly string[] NombresEstado = new string[]
        {
            "Programado",
            "En Tránsito",
            "Entregado",
            "Cancelado"
        };

        // Guardamos el estado (int) con el que se cargó cada transporte, para saber
        // si ya está Entregado/Cancelado y por lo tanto no se puede volver a modificar.
        private Dictionary<int, int> estadosOriginales = new Dictionary<int, int>();

        private static bool EsEstadoFinal(int estado)
        {
            return estado == EstadoTransporte.Entregado || estado == EstadoTransporte.cancelado;
        }

        public UIListaTransportes()
        {
            InitializeComponent();
            this.Load += UIListaTransportes_Load;
            // CellFormatting se dispara cada vez que se dibuja una celda (incluso después
            // de ordenar por columna), así que ahí es donde hay que pintar las filas para
            // que el color no se pierda al hacer clic en un encabezado para ordenar.
            dgvTransportes.CellFormatting += DgvTransportes_CellFormatting;
            // CellBeginEdit cancela la edición si corresponde, sin depender de la
            // propiedad ReadOnly de la celda (que también se resetea al ordenar).
            dgvTransportes.CellBeginEdit += DgvTransportes_CellBeginEdit;
        }

        private void UIListaTransportes_Load(object sender, EventArgs e)
        {
            CargarTransportes();
        }

        private void CargarTransportes()
        {
            try
            {
                // NOTA: asumimos que existe NTransporte.GetAllTransportes() devolviendo
                // List<Transporte> con la Venta (y el Cliente) ya cargados.
                // Si en tu capa Negocio el método se llama distinto, cambiá esta línea.
                List<Transporte> transportes = NTransporte.GetAllTransportes() ?? new List<Transporte>();

                DataTable tabla = new DataTable();
                tabla.Columns.Add("IdTransporte", typeof(int));
                tabla.Columns.Add("Venta", typeof(string));
                tabla.Columns.Add("Cliente", typeof(string));
                tabla.Columns.Add("Total", typeof(string));
                tabla.Columns.Add("Fecha", typeof(string));
                tabla.Columns.Add("Estado", typeof(string));

                estadosOriginales.Clear();

                foreach (Transporte t in transportes)
                {
                    string venta = t.Venta != null ? $"Venta #{t.Venta.IdVenta}" : "-";
                    string cliente = (t.Venta != null && t.Venta.Cliente != null)
                        ? t.Venta.Cliente.Nombre
                        : "Consumidor Final";
                    string total = t.Venta != null ? t.Venta.Total.ToString("C2") : "-";
                    string estado = (t.Estado >= 0 && t.Estado < NombresEstado.Length)
                        ? NombresEstado[t.Estado]
                        : t.Estado.ToString();

                    tabla.Rows.Add(t.IdTransporte, venta, cliente, total,
                        t.Fecha.ToString("dd/MM/yyyy HH:mm"), estado);

                    estadosOriginales[t.IdTransporte] = t.Estado;
                }

                dgvTransportes.DataSource = tabla;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cargar los transportes: " + error.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTransportes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTransportes.Rows[e.RowIndex];
            object idValue = row.Cells["colIdTransporte"].Value;
            if (idValue == null) return;

            int id = Convert.ToInt32(idValue);
            if (!estadosOriginales.TryGetValue(id, out int estadoOriginal)) return;

            if (estadoOriginal == EstadoTransporte.Entregado)
            {
                e.CellStyle.BackColor = Color.FromArgb(224, 246, 230);
                e.CellStyle.ForeColor = Color.FromArgb(24, 120, 68);
                e.CellStyle.SelectionBackColor = Color.FromArgb(150, 210, 172);
                e.CellStyle.SelectionForeColor = Color.FromArgb(14, 84, 47);
            }
            else if (estadoOriginal == EstadoTransporte.cancelado)
            {
                e.CellStyle.BackColor = Color.FromArgb(252, 227, 227);
                e.CellStyle.ForeColor = Color.FromArgb(178, 34, 34);
                e.CellStyle.SelectionBackColor = Color.FromArgb(237, 155, 155);
                e.CellStyle.SelectionForeColor = Color.FromArgb(120, 20, 20);
            }
            else if (estadoOriginal == EstadoTransporte.EnTransito)
            {
                e.CellStyle.BackColor = Color.FromArgb(222, 235, 250);
                e.CellStyle.ForeColor = Color.FromArgb(24, 95, 165);
                e.CellStyle.SelectionBackColor = Color.FromArgb(140, 182, 226);
                e.CellStyle.SelectionForeColor = Color.FromArgb(14, 58, 110);
            }
            else
            {
                // Programado: sin color de fondo especial, pero igual con una
                // selección más marcada que el celeste tenue por defecto.
                e.CellStyle.SelectionBackColor = Color.FromArgb(178, 205, 235);
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 45, 80);
            }
        }

        private void DgvTransportes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvTransportes.Columns[e.ColumnIndex].Name != "colEstado") return;

            DataGridViewRow row = dgvTransportes.Rows[e.RowIndex];
            object idValue = row.Cells["colIdTransporte"].Value;
            if (idValue == null) return;

            int id = Convert.ToInt32(idValue);
            if (estadosOriginales.TryGetValue(id, out int estadoOriginal) && EsEstadoFinal(estadoOriginal))
            {
                e.Cancel = true;
                MessageBox.Show("Este transporte ya fue entregado o cancelado y no se puede modificar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevoTransporte_Click(object sender, EventArgs e)
        {
            using (UITransporte frmNuevo = new UITransporte())
            {
                DialogResult resultado = frmNuevo.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    // Se registró (uno o más) transporte(s): refrescamos el listado.
                    CargarTransportes();
                }
            }
        }

        private void btnGuardarEstado_Click(object sender, EventArgs e)
        {
            if (dgvTransportes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un transporte de la lista.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirma la edición del combo (si el usuario recién lo cambió y no salió de la celda).
            dgvTransportes.EndEdit();

            try
            {
                int idTransporte = Convert.ToInt32(dgvTransportes.CurrentRow.Cells["colIdTransporte"].Value);

                if (estadosOriginales.TryGetValue(idTransporte, out int estadoOriginal) && EsEstadoFinal(estadoOriginal))
                {
                    MessageBox.Show("Este transporte ya fue entregado o cancelado y no se puede modificar.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string estadoTexto = dgvTransportes.CurrentRow.Cells["colEstado"].Value?.ToString();
                int nuevoEstado = Array.IndexOf(NombresEstado, estadoTexto);

                if (nuevoEstado < 0)
                {
                    MessageBox.Show("Elegí un estado válido para el transporte.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // NTransporte.CambiarEstado también valida esto (y el rango del estado)
                // por si se llama desde otro lado que no sea esta pantalla.
                NTransporte.CambiarEstado(idTransporte, nuevoEstado);

                MessageBox.Show("Estado actualizado con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTransportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarTransporte_Click(object sender, EventArgs e)
        {
            if (dgvTransportes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un transporte de la lista.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTransporte = Convert.ToInt32(dgvTransportes.CurrentRow.Cells["colIdTransporte"].Value);

            DialogResult confirmacion = MessageBox.Show(
                $"¿Seguro que querés eliminar el transporte N° {idTransporte}? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                NTransporte.EliminarTransporte(idTransporte);
                MessageBox.Show("Transporte eliminado con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTransportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            if (dgvTransportes.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un transporte de la lista.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTransporte = Convert.ToInt32(dgvTransportes.CurrentRow.Cells["colIdTransporte"].Value);
            string venta = dgvTransportes.CurrentRow.Cells["colVenta"].Value?.ToString() ?? "-";
            string cliente = dgvTransportes.CurrentRow.Cells["colCliente"].Value?.ToString() ?? "Consumidor Final";
            string total = dgvTransportes.CurrentRow.Cells["colTotal"].Value?.ToString() ?? "-";
            string fecha = dgvTransportes.CurrentRow.Cells["colFecha"].Value?.ToString() ?? "-";
            string estado = dgvTransportes.CurrentRow.Cells["colEstado"].Value?.ToString() ?? "-";

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PDF|*.pdf";
            dialog.FileName = $"Factura_Transporte_{idTransporte}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (PdfWriter writer = new PdfWriter(dialog.FileName))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document doc = new Document(pdf))
                {
                    // paleta de colores (misma línea visual que el resto del sistema)
                    iText.Kernel.Colors.Color colorPrimario = new DeviceRgb(24, 95, 165); // Azul institucional (coincide con la grilla)
                    iText.Kernel.Colors.Color colorTextoOscuro = new DeviceRgb(44, 62, 80); // Gris oscuro profesional
                    iText.Kernel.Colors.Color colorGrisClaro = new DeviceRgb(245, 247, 250); // Fondo para filas alternadas

                    // --- CABECERA DE LA FACTURA (Logo + Info Empresa) ---
                    Table cabecera = new Table(UnitValue.CreatePercentArray(new float[] { 30f, 70f })).SetWidth(UnitValue.CreatePercentValue(100));
                    cabecera.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                    // Celda del Logo
                    try
                    {
                        string rutaLogo = "C:/Codigo/C#/ProyectoFinal/ProyectoFinal/Assets/logoEmpresa.png";
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

                    // Celda de Datos de la Empresa
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
                    Table infoTransporte = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 50f })).SetWidth(UnitValue.CreatePercentValue(100));
                    infoTransporte.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    infoTransporte.SetMarginBottom(20f);

                    // Columna Izquierda: Cliente
                    Paragraph datosCliente = new Paragraph()
                        .Add(new Text("DATOS DEL CLIENTE\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text($"Cliente: {cliente}\n").SetFontSize(10))
                        .Add(new Text($"Venta asociada: {venta}\n").SetFontSize(10))
                        .SetFontColor(colorTextoOscuro);
                    infoTransporte.AddCell(new Cell().Add(datosCliente).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    // Columna Derecha: Datos del Transporte
                    Paragraph datosFactura = new Paragraph()
                        .Add(new Text("FACTURA DE TRANSPORTE\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text($"N° Comprobante: {idTransporte.ToString().PadLeft(8, '0')}\n").SetFontSize(10))
                        .Add(new Text($"Fecha: {fecha}\n").SetFontSize(10))
                        .Add(new Text($"Estado: {estado}\n").SetFontSize(10))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetFontColor(colorTextoOscuro);
                    infoTransporte.AddCell(new Cell().Add(datosFactura).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    doc.Add(infoTransporte);

                    // --- TABLA DE DETALLE DEL TRANSPORTE ---
                    doc.Add(new Paragraph("DETALLE DEL TRANSPORTE").SetFontSize(12).SetFontColor(colorTextoOscuro).SetMarginBottom(8f));

                    // Al no haber una lista de ítems (como en la venta), mostramos el
                    // detalle como pares Concepto/Valor con los datos del transporte.
                    Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 50f })).SetWidth(UnitValue.CreatePercentValue(100));

                    // Estilizado del Encabezado de la Tabla
                    string[] encabezados = { "Concepto", "Detalle" };
                    foreach (var nomHeader in encabezados)
                    {
                        Cell headerCell = new Cell().Add(new Paragraph(nomHeader).SetFontColor(ColorConstants.WHITE).SetFontSize(10));
                        headerCell.SetBackgroundColor(colorTextoOscuro);
                        headerCell.SetPadding(6f);
                        headerCell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                        tabla.AddHeaderCell(headerCell);
                    }

                    // Filas con los datos del transporte seleccionado
                    (string Concepto, string Detalle)[] filas = new (string, string)[]
                    {
                        ("N° Transporte", idTransporte.ToString()),
                        ("Venta asociada", venta),
                        ("Cliente", cliente),
                        ("Fecha", fecha),
                        ("Estado", estado),
                    };

                    bool filaAlterna = false;
                    foreach (var fila in filas)
                    {
                        Cell cConcepto = new Cell().Add(new Paragraph(fila.Concepto).SetFontSize(10));
                        Cell cDetalle = new Cell().Add(new Paragraph(fila.Detalle).SetFontSize(10));

                        Cell[] celdas = { cConcepto, cDetalle };
                        foreach (var celda in celdas)
                        {
                            celda.SetPadding(6f);
                            celda.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                            celda.SetBorderBottom(new iText.Layout.Borders.SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f));

                            // Efecto cebra para mejorar la lectura de las filas
                            if (filaAlterna) celda.SetBackgroundColor(colorGrisClaro);
                        }

                        tabla.AddCell(cConcepto);
                        tabla.AddCell(cDetalle);

                        filaAlterna = !filaAlterna;
                    }
                    doc.Add(tabla);

                    // --- SECCIÓN TOTAL ---
                    Paragraph totalBlock = new Paragraph()
                        .Add(new Text("TOTAL: ").SetFontSize(14).SetFontColor(colorTextoOscuro))
                        .Add(new Text(total).SetFontSize(16).SetFontColor(colorPrimario))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginTop(15f);

                    doc.Add(totalBlock);
                }
                MessageBox.Show("Factura emitida con éxito.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
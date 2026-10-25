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
    public partial class UIRegistrarPedidoCompra : Form
    {
        private Presupuesto presupuestoSeleccionado;
        private Dictionary<int, string> nombresInsumos = new Dictionary<int, string>();
        private Dictionary<int, string> unidadesInsumos = new Dictionary<int, string>();
        private Dictionary<int, decimal> preciosDelPresupuesto = new Dictionary<int, decimal>();
        private readonly bool esModificacion;
        private readonly int idCompra;

        // Alta desde un presupuesto aceptado.
        public UIRegistrarPedidoCompra()
        {
            InitializeComponent();
            ConfigurarPantalla("Emitir Pedido de Compra");
            UIStyles.AplicarTemaAForm(this);
        }

        // Modificación de un pedido emitido.
        public UIRegistrarPedidoCompra(int idCompra)
        {
            InitializeComponent();
            this.esModificacion = true;
            this.idCompra = idCompra;
            ConfigurarPantalla("Modificar Pedido de Compra");
            UIStyles.AplicarTemaAForm(this);
        }

        private void ConfigurarPantalla(string titulo)
        {
            lblTitulo.Text = titulo;
            this.Text = titulo;
            dgvDetalle.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvDetalle);

            ConfigurarLabel(this.lblPresupuesto, "Presupuesto", new System.Drawing.Point(20, 56));
            ConfigurarCombo(this.cbPresupuesto, new System.Drawing.Point(20, 76),
                new System.Drawing.Size(400, 32), 0);

            ConfigurarLabel(this.lblDetalle, "Detalles del pedido", new System.Drawing.Point(20, 122));

            ConfigurarBotonSecundario(this.btnAgregarInsumo, "Agregar insumo",
                new System.Drawing.Point(20, 450), 1);
            this.btnAgregarInsumo.Size = new System.Drawing.Size(160, 36);
            this.btnAgregarInsumo.Click += new System.EventHandler(this.btnAgregarInsumo_Click);

            ConfigurarBotonSecundario(this.btnQuitar, "Quitar",
                new System.Drawing.Point(188, 450), 2);
            this.btnQuitar.Size = new System.Drawing.Size(120, 36);
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);

            ConfigurarLabel(this.lblTotalKey, "TOTAL", new System.Drawing.Point(500, 452));
            ConfigurarLabelValor(this.labelTotal, new System.Drawing.Point(560, 450));

            ConfigurarBotonPrimario(this.btnGuardar, "Guardar pedido",
                new System.Drawing.Point(20, 500), 3);
            this.btnGuardar.Size = new System.Drawing.Size(340, 44);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            ConfigurarBotonSecundario(this.btnCancelar, "Cancelar",
                new System.Drawing.Point(374, 500), 4);
            this.btnCancelar.Size = new System.Drawing.Size(160, 44);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        }

        private void UIRegistrarPedidoCompra_Load(object sender, EventArgs e)
        {
            try
            {
                List<Insumo> insumos = NInsumos.GetAllInsumos();
                nombresInsumos = insumos.ToDictionary(i => i.Id, i => i.Nombre);
                unidadesInsumos = insumos.ToDictionary(i => i.Id, i => i.UnidadMedida);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los insumos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (esModificacion)
                CargarModificacion();
            else
                CargarAlta();
        }

        private void CargarAlta()
        {
            List<Presupuesto> aceptados = NPresupuesto.GetAll()
                .Where(p => p.EstadoSolicitud == EstadoSolicitudCotizacion.Aceptada)
                .ToList();

            cbPresupuesto.DataSource = aceptados;
            cbPresupuesto.SelectedIndex = -1;
            ActualizarTotal();

            if (aceptados.Count == 0)
            {
                MessageBox.Show("No hay presupuestos aceptados para emitir un pedido.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarModificacion()
        {
            Compra compra = NCompras.GetCompraById(idCompra);
            if (compra == null || compra.Estado != EstadoCompra.Emitida || compra.IdPresupuesto == null)
            {
                MessageBox.Show("Solo se pueden modificar pedidos que estén emitidos.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            Presupuesto presupuesto = NPresupuesto.GetById(compra.IdPresupuesto.Value);
            if (presupuesto == null)
            {
                MessageBox.Show("No se encontró el presupuesto de origen del pedido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            List<Presupuesto> lista = new List<Presupuesto> { presupuesto };
            cbPresupuesto.DataSource = lista;
            cbPresupuesto.SelectedIndex = 0;
            cbPresupuesto.Enabled = false;

            // Precarga las cantidades reales del pedido sobre las del presupuesto.
            List<DetalleCompra> detallesPedido = NDetalleCompras.GetDetalleByIdCompra(idCompra);
            Dictionary<int, decimal> cantidades = new Dictionary<int, decimal>();
            foreach (DetalleCompra detalle in detallesPedido)
                cantidades[detalle.IdInsumo] = detalle.Cantidad;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Tag == null) continue;
                decimal cantidad;
                if (cantidades.TryGetValue((int)row.Tag, out cantidad))
                    row.Cells["Cantidad"].Value = cantidad;
                RecalcularFila(row);
            }
            ActualizarTotal();
        }

        // ---------- Presupuesto ----------
        private void cbPresupuesto_Format(object sender, ListControlConvertEventArgs e)
        {
            Presupuesto p = e.ListItem as Presupuesto;
            if (p != null)
                e.Value = "N° " + p.IdPresupuesto + " - " + p.NombreProveedor + " - " + p.Fecha.ToString("dd-MM-yyyy");
        }

        private void cbPresupuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            presupuestoSeleccionado = cbPresupuesto.SelectedItem as Presupuesto;
            if (presupuestoSeleccionado == null)
            {
                dgvDetalle.Rows.Clear();
                preciosDelPresupuesto = new Dictionary<int, decimal>();
                ActualizarTotal();
                return;
            }

            try
            {
                CargarDetallePresupuesto(presupuestoSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el presupuesto: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetallePresupuesto(Presupuesto presupuesto)
        {
            List<DetallePresupuesto> detalles = NPresupuesto.GetDetalles(presupuesto.IdPresupuesto);
            preciosDelPresupuesto = new Dictionary<int, decimal>();
            dgvDetalle.Rows.Clear();

            foreach (DetallePresupuesto detalle in detalles)
            {
                preciosDelPresupuesto[detalle.IdInsumo] = detalle.PrecioUnitario;
                decimal subtotal = Math.Round(detalle.PrecioUnitario * detalle.Cantidad, 2);
                int indice = dgvDetalle.Rows.Add(
                    detalle.NombreInsumo,
                    detalle.UnidadMedidaInsumo,
                    detalle.Cantidad,
                    detalle.PrecioUnitario,
                    subtotal);
                dgvDetalle.Rows[indice].Tag = detalle.IdInsumo;
            }
            ActualizarTotal();
        }

        // ---------- Grid ----------
        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            if (presupuestoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un presupuesto.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            List<int> yaCargados = new List<int>();
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Tag != null) yaCargados.Add((int)row.Tag);
            }

            using (UIInsumoPedidoCompra dialogo = new UIInsumoPedidoCompra(preciosDelPresupuesto, yaCargados))
            {
                if (dialogo.ShowDialog() != DialogResult.OK || dialogo.Detalle == null) return;

                DetalleCompra detalle = dialogo.Detalle;
                string nombre = nombresInsumos.ContainsKey(detalle.IdInsumo)
                    ? nombresInsumos[detalle.IdInsumo] : detalle.IdInsumo.ToString();
                string unidad = unidadesInsumos.ContainsKey(detalle.IdInsumo)
                    ? unidadesInsumos[detalle.IdInsumo] : "";
                decimal precio = preciosDelPresupuesto.ContainsKey(detalle.IdInsumo)
                    ? preciosDelPresupuesto[detalle.IdInsumo] : 0;

                int indice = dgvDetalle.Rows.Add(nombre, unidad, detalle.Cantidad, precio, (decimal)detalle.Subtotal);
                dgvDetalle.Rows[indice].Tag = detalle.IdInsumo;
                ActualizarTotal();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para quitar.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            dgvDetalle.Rows.RemoveAt(dgvDetalle.SelectedRows[0].Index);
            ActualizarTotal();
        }

        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDetalle.Columns[e.ColumnIndex].Name != "Cantidad") return;

            decimal cantidad;
            string valor = e.FormattedValue == null ? "" : e.FormattedValue.ToString();
            if (!decimal.TryParse(valor, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a 0.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            if (cantidad > 50000m)
            {
                MessageBox.Show("La cantidad no puede superar las 50.000 unidades.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDetalle.Columns[e.ColumnIndex].Name != "Cantidad") return;
            RecalcularFila(dgvDetalle.Rows[e.RowIndex]);
            ActualizarTotal();
        }

        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ingrese un valor numérico válido.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        private void RecalcularFila(DataGridViewRow row)
        {
            if (row == null || row.Tag == null) return;
            int idInsumo = (int)row.Tag;
            decimal precio = preciosDelPresupuesto.ContainsKey(idInsumo) ? preciosDelPresupuesto[idInsumo] : 0;
            decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value ?? 0m);
            row.Cells["PrecioUnitario"].Value = precio;
            row.Cells["Subtotal"].Value = Math.Round(precio * cantidad, 2);
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            labelTotal.Text = "$" + total.ToString("N2");
        }

        // ---------- Guardar ----------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (presupuestoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un presupuesto.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DetalleCompra> detalles = LeerDetallesDeGrilla();
            if (detalles.Count == 0)
            {
                MessageBox.Show("El pedido debe tener al menos un insumo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (esModificacion)
                {
                    NCompras.ModificarPedidoCompra(idCompra, detalles);
                    MessageBox.Show("Pedido modificado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Compra compra = new Compra
                    {
                        IdProveedor = presupuestoSeleccionado.IdProveedor,
                        IdPresupuesto = presupuestoSeleccionado.IdPresupuesto,
                        Fecha = DateTime.Now.Date
                    };
                    NCompras.RegistrarPedidoCompra(compra, detalles);
                    MessageBox.Show("Pedido registrado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
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

        private List<DetalleCompra> LeerDetallesDeGrilla()
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Tag == null) continue;
                decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value ?? 0m);
                if (cantidad <= 0) continue;

                lista.Add(new DetalleCompra
                {
                    IdInsumo = (int)row.Tag,
                    Cantidad = cantidad,
                    Subtotal = (double)Convert.ToDecimal(row.Cells["Subtotal"].Value ?? 0m)
                });
            }
            return lista;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ---------- PDF ----------
        public static void GenerarPdfPedidoCompra(Compra compra, List<DetalleCompra> detalles,
            string nombreProveedor, Dictionary<int, string> nombresInsumos)
        {
            if (compra == null) throw new ArgumentException("La compra no puede ser nula.");
            if (detalles == null) detalles = new List<DetalleCompra>();
            if (nombresInsumos == null) nombresInsumos = new Dictionary<int, string>();

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PDF|*.pdf";
            dialog.FileName = "PedidoCompra_" + compra.IdCompra;
            if (dialog.ShowDialog() != DialogResult.OK) return;

            using (PdfWriter writer = new PdfWriter(dialog.FileName))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document doc = new Document(pdf))
            {
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
                    cabecera.AddCell(new Cell().Add(img).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                }
                else
                {
                    // Fallback explícito: si falta el logo, se muestra el nombre de la empresa.
                    cabecera.AddCell(new Cell()
                        .Add(new Paragraph("F&G Hamburguesas").SetFontSize(11).SetFontColor(colorPrimario))
                        .SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                }

                Paragraph infoEmpresa = new Paragraph()
                    .Add(new Text("F&G Hamburguesas\n").SetFontSize(20).SetFontColor(colorPrimario))
                    .Add(new Text("24950 Deldotto Fernando\n").SetFontSize(9))
                    .Add(new Text("Dirección: Sánchez de Bustamante 5168, B° Dean funes, Córdoba\nTeléfono: +54 9 351 123 4567\nEmail: contacto@fghamburguesas.com").SetFontSize(9).SetFontColor(ColorConstants.GRAY))
                    .SetTextAlignment(TextAlignment.RIGHT);
                cabecera.AddCell(new Cell().Add(infoEmpresa).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                doc.Add(cabecera);

                LineSeparator lineaDivisoria = new LineSeparator(new SolidLine(1f));
                lineaDivisoria.SetMarginTop(15f);
                lineaDivisoria.SetMarginBottom(15f);
                doc.Add(lineaDivisoria);

                // --- PROVEEDOR Y DATOS DEL PEDIDO ---
                Table infoCompra = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 50f })).SetWidth(UnitValue.CreatePercentValue(100));
                infoCompra.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                infoCompra.SetMarginBottom(20f);

                Paragraph datosProveedor = new Paragraph()
                    .Add(new Text("DATOS DEL PROVEEDOR\n").SetFontSize(11).SetFontColor(colorPrimario))
                    .Add(new Text("Proveedor: " + (nombreProveedor ?? "Desconocido") + "\n").SetFontSize(10))
                    .SetFontColor(colorTextoOscuro);
                infoCompra.AddCell(new Cell().Add(datosProveedor).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                Paragraph datosPedido = new Paragraph()
                    .Add(new Text("PEDIDO DE COMPRA\n").SetFontSize(11).SetFontColor(colorPrimario))
                    .Add(new Text("N° Pedido: " + compra.IdCompra.ToString().PadLeft(8, '0') + "\n").SetFontSize(10))
                    .Add(new Text("Fecha: " + compra.Fecha.ToString("dd-MM-yyyy") + "\n").SetFontSize(10))
                    .Add(new Text("Estado: " + GetDescripcionEstado(compra.Estado) + "\n").SetFontSize(10))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(colorTextoOscuro);
                infoCompra.AddCell(new Cell().Add(datosPedido).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                doc.Add(infoCompra);

                // --- TABLA DE DETALLES ---
                doc.Add(new Paragraph("DETALLE DEL PEDIDO").SetFontSize(12).SetFontColor(colorTextoOscuro).SetMarginBottom(8f));
                Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 55f, 20f, 25f })).SetWidth(UnitValue.CreatePercentValue(100));

                string[] encabezados = { "Insumo", "Cantidad", "SubTotal" };
                foreach (string nomHeader in encabezados)
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
                foreach (DetalleCompra detalle in detalles)
                {
                    string nombre = nombresInsumos.ContainsKey(detalle.IdInsumo)
                        ? nombresInsumos[detalle.IdInsumo] : detalle.IdInsumo.ToString();

                    Cell cInsumo = new Cell().Add(new Paragraph(nombre).SetFontSize(10));
                    Cell cCantidad = new Cell().Add(new Paragraph(detalle.Cantidad.ToString("N2")).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
                    Cell cSubtotal = new Cell().Add(new Paragraph("$" + detalle.Subtotal.ToString("N2")).SetFontSize(10).SetTextAlignment(TextAlignment.RIGHT));

                    Cell[] celdas = { cInsumo, cCantidad, cSubtotal };
                    foreach (Cell celda in celdas)
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

                // --- TOTAL ---
                Paragraph totalBlock = new Paragraph()
                    .Add(new Text("TOTAL: ").SetFontSize(14).SetFontColor(colorTextoOscuro))
                    .Add(new Text("$" + compra.TotalCompra.ToString("N2")).SetFontSize(16).SetFontColor(colorPrimario))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetMarginTop(15f);
                doc.Add(totalBlock);
            }

            MessageBox.Show("PDF generado con éxito.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string GetDescripcionEstado(int estado)
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

        // ---------- Estilos ----------
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarLabelValor(System.Windows.Forms.Label lbl, System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabelValor(lbl, ubicacion);

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex, ComboBoxStyle.DropDownList);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));
    }
}

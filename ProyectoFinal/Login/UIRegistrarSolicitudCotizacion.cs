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
using System.Windows.Forms;
using Image = iText.Layout.Element.Image;

namespace Login
{
    public partial class UIRegistrarSolicitudCotizacion : Form
    {
        private int? idProductoInicial;
        private int? cantidadProducidaInicial;

        public UIRegistrarSolicitudCotizacion()
        {
            InitializeComponent();

            ConfigurarLabel(this.lblProducto, "Producto", new System.Drawing.Point(20, 20));
            ConfigurarCombo(this.cbProducto, new System.Drawing.Point(20, 40),
                new System.Drawing.Size(320, 30), 0);

            ConfigurarLabel(this.lblCantidad, "Cantidad a producir", new System.Drawing.Point(360, 20));
            this.numCantidad.Location = new System.Drawing.Point(360, 40);
            this.numCantidad.Size = new System.Drawing.Size(120, 30);
            this.numCantidad.TabIndex = 1;

            ConfigurarBotonPrimario(this.btnCalcular, "Calcular faltante",
                new System.Drawing.Point(500, 40), 2);
            this.btnCalcular.Size = new System.Drawing.Size(180, 32);
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);

            ConfigurarLabel(this.lblDetalle, "Insumos a cotizar", new System.Drawing.Point(20, 90));
            ConfigurarDataGridView(this.dgvDetalle, new System.Drawing.Point(20, 112),
                new System.Drawing.Size(680, 280), 3);

            ConfigurarLabel(this.lblProveedor, "Proveedor", new System.Drawing.Point(20, 410));
            ConfigurarCombo(this.cbProveedor, new System.Drawing.Point(20, 430),
                new System.Drawing.Size(320, 30), 4);

            ConfigurarLabel(this.lblNombreProv, string.Empty, new System.Drawing.Point(360, 412));
            this.lblNombreProv.Size = new System.Drawing.Size(340, 18);
            ConfigurarLabel(this.lblEmailProv, string.Empty, new System.Drawing.Point(360, 438));
            this.lblEmailProv.Size = new System.Drawing.Size(340, 18);
            ConfigurarLabel(this.lblDireccionProv, string.Empty, new System.Drawing.Point(360, 464));
            this.lblDireccionProv.Size = new System.Drawing.Size(340, 18);

            ConfigurarBotonPrimario(this.btnEmitir, "Emitir solicitud",
                new System.Drawing.Point(20, 600), 5);
            this.btnEmitir.Size = new System.Drawing.Size(300, 44);
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);

            ConfigurarBotonSecundario(this.btnCerrar, "Cerrar",
                new System.Drawing.Point(340, 600), 6);
            this.btnCerrar.Size = new System.Drawing.Size(150, 44);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.cbProveedor.SelectedIndexChanged +=
                new System.EventHandler(this.cbProveedor_SelectedIndexChanged);
            this.dgvDetalle.CellValidating +=
                new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetalle_CellValidating);
            this.dgvDetalle.DataError +=
                new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDetalle_DataError);
        }

        public UIRegistrarSolicitudCotizacion(int idProducto, int cantidadProducida) : this()
        {
            this.idProductoInicial = idProducto;
            this.cantidadProducidaInicial = cantidadProducida;
        }

        private void UIRegistrarSolicitudCotizacion_Load(object sender, EventArgs e)
        {
            try
            {
                var productos = NProductos.GetAll();
                cbProducto.DataSource = null;
                cbProducto.DataSource = productos;
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "IdProducto";

                var proveedores = NProveedores.GetAll();
                cbProveedor.DataSource = null;
                cbProveedor.DataSource = proveedores;
                cbProveedor.DisplayMember = "Nombre";
                cbProveedor.ValueMember = "IdProveedor";

                colInsumo.DataSource = NInsumos.GetAllInsumos();
                colInsumo.DisplayMember = "Nombre";
                colInsumo.ValueMember = "Id";

                RefrescarDatosProveedor();

                if (idProductoInicial.HasValue && cantidadProducidaInicial.HasValue)
                {
                    cbProducto.SelectedValue = idProductoInicial.Value;
                    numCantidad.Value = Math.Min(cantidadProducidaInicial.Value, numCantidad.Maximum);
                    CalcularYPrecargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarDatosProveedor();
        }

        private void RefrescarDatosProveedor()
        {
            Proveedor proveedor = cbProveedor.SelectedItem as Proveedor;
            if (proveedor == null)
            {
                lblNombreProv.Text = string.Empty;
                lblEmailProv.Text = string.Empty;
                lblDireccionProv.Text = string.Empty;
                return;
            }

            lblNombreProv.Text = "Nombre: " + proveedor.Nombre;
            lblEmailProv.Text = "Email: " +
                (string.IsNullOrEmpty(proveedor.Email) ? "-" : proveedor.Email);
            lblDireccionProv.Text = "Dirección: " +
                (string.IsNullOrEmpty(proveedor.Direccion) ? "-" : proveedor.Direccion);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularYPrecargar();
        }

        private void CalcularYPrecargar()
        {
            try
            {
                Producto producto = cbProducto.SelectedItem as Producto;
                if (producto == null)
                {
                    MessageBox.Show("Debe seleccionar un producto.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<RecetaProducto> receta = NRecetaProducto.ObtenerPorProducto(producto.IdProducto);
                if (receta == null || receta.Count == 0)
                {
                    MessageBox.Show("Este producto no tiene una receta definida. Cargue la receta en Productos -> Gestionar Productos -> Gestionar Recetas antes de emitir una solicitud.",
                        "Receta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cantidad = (int)numCantidad.Value;
                List<DetalleSolicitudCotizacion> faltantes =
                    NSolicitudCotizacion.CalcularFaltante(producto.IdProducto, cantidad);

                dgvDetalle.Rows.Clear();
                foreach (DetalleSolicitudCotizacion faltante in faltantes)
                {
                    dgvDetalle.Rows.Add(
                        faltante.IdInsumo,
                        faltante.UnidadMedidaInsumo,
                        Math.Round(faltante.Cantidad, 4));
                }

                if (faltantes.Count == 0)
                {
                    MessageBox.Show("No hay faltantes de insumos para esa producción.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colCantidad.Index) return;

            DataGridViewRow fila = dgvDetalle.Rows[e.RowIndex];
            if (fila.IsNewRow) return;

            string texto = Convert.ToString(e.FormattedValue);
            if (string.IsNullOrWhiteSpace(texto)) return;

            decimal cantidad;
            if (!decimal.TryParse(texto, out cantidad) || cantidad < 0)
            {
                fila.ErrorText = "Ingrese una cantidad numérica mayor o igual a cero.";
                MessageBox.Show("La cantidad debe ser numérica y no negativa.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            fila.ErrorText = string.Empty;
        }

        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show("El valor ingresado en el detalle no es válido.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = cbProveedor.SelectedItem as Proveedor;
            if (proveedor == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DetalleSolicitudCotizacion> detalles = new List<DetalleSolicitudCotizacion>();
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (fila.IsNewRow) continue;

                object valorInsumo = fila.Cells[colInsumo.Index].Value;
                if (valorInsumo == null) continue;

                int idInsumo;
                if (!int.TryParse(Convert.ToString(valorInsumo), out idInsumo) || idInsumo <= 0) continue;

                decimal cantidad;
                if (!decimal.TryParse(Convert.ToString(fila.Cells[colCantidad.Index].Value), out cantidad)) continue;
                if (cantidad <= 0) continue;

                detalles.Add(new DetalleSolicitudCotizacion
                {
                    IdInsumo = idInsumo,
                    Cantidad = cantidad,
                    NombreInsumo = Convert.ToString(fila.Cells[colInsumo.Index].FormattedValue),
                    UnidadMedidaInsumo = Convert.ToString(fila.Cells[colUnidad.Index].Value)
                });
            }

            if (detalles.Count == 0)
            {
                MessageBox.Show("Debe indicar al menos un insumo para cotizar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "Se emitirá la solicitud de cotización al proveedor " + proveedor.Nombre +
                ". ¿Confirma la operación?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes) return;

            try
            {
                SolicitudCotizacion solicitud = new SolicitudCotizacion
                {
                    IdProveedor = proveedor.IdProveedor,
                    Fecha = DateTime.Now.Date,
                    Estado = EstadoSolicitudCotizacion.Emitida
                };

                NSolicitudCotizacion.RegistrarSolicitud(solicitud, detalles);

                MessageBox.Show("Solicitud de cotización generada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        public static string GetDescripcionEstado(int estado)
        {
            switch (estado)
            {
                case EstadoSolicitudCotizacion.Emitida: return "EMITIDA";
                case EstadoSolicitudCotizacion.Recibida: return "RECIBIDA";
                case EstadoSolicitudCotizacion.Aceptada: return "ACEPTADA";
                case EstadoSolicitudCotizacion.Cancelada: return "CANCELADA";
                default: return "DESCONOCIDO";
            }
        }

        // Genera y guarda el PDF de una solicitud de cotización. Es estático para poder
        // reutilizarlo desde el listado ("Ver PDF") sin duplicar el código.
        public static bool GenerarPdfSolicitud(int idSolicitud, Proveedor proveedor, DateTime fecha,
            int estado, List<DetalleSolicitudCotizacion> detalles)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "PDF|*.pdf";
                dialog.FileName = "SolicitudCotizacion_" + idSolicitud;

                if (dialog.ShowDialog() != DialogResult.OK) return false;

                using (PdfWriter writer = new PdfWriter(dialog.FileName))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document doc = new Document(pdf))
                {
                    // paleta de colores
                    iText.Kernel.Colors.Color colorPrimario = new DeviceRgb(230, 126, 34);
                    iText.Kernel.Colors.Color colorTextoOscuro = new DeviceRgb(44, 62, 80);
                    iText.Kernel.Colors.Color colorGrisClaro = new DeviceRgb(245, 247, 250);

                    // --- CABECERA (Logo + Info Empresa) ---
                    Table cabecera = new Table(UnitValue.CreatePercentArray(new float[] { 30f, 70f }))
                        .SetWidth(UnitValue.CreatePercentValue(100));
                    cabecera.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                    try
                    {
                        string rutaLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "logoEmpresa.png");
                        ImageData data = ImageDataFactory.Create(rutaLogo);
                        Image img = new Image(data).SetWidth(100)
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                        Cell cellLogo = new Cell().Add(img).SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                        cabecera.AddCell(cellLogo);
                    }
                    catch (Exception)
                    {
                        // Si no encuentra el logo, celda vacía para no romper el diseño
                        cabecera.AddCell(new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                    }

                    Paragraph infoEmpresa = new Paragraph()
                        .Add(new Text("F&G Hamburguesas\n").SetFontSize(20).SetFontColor(colorPrimario))
                        .Add(new Text("24950 Deldotto Fernando\n").SetFontSize(9))
                        .Add(new Text("Dirección: Sánchez de Bustamante 5168, B° Dean funes, Córdoba\nTeléfono: +54 9 351 123 4567\nEmail: contacto@fghamburguesas.com")
                            .SetFontSize(9).SetFontColor(ColorConstants.GRAY))
                        .SetTextAlignment(TextAlignment.RIGHT);

                    Cell cellInfo = new Cell().Add(infoEmpresa).SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    cabecera.AddCell(cellInfo);
                    doc.Add(cabecera);

                    // divisora
                    LineSeparator lineaDivisoria = new LineSeparator(new SolidLine(1f));
                    lineaDivisoria.SetMarginTop(15f);
                    lineaDivisoria.SetMarginBottom(15f);
                    doc.Add(lineaDivisoria);

                    // --- PROVEEDOR Y DATOS DE LA SOLICITUD ---
                    Table infoSolicitud = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 50f }))
                        .SetWidth(UnitValue.CreatePercentValue(100));
                    infoSolicitud.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    infoSolicitud.SetMarginBottom(20f);

                    string nombreProveedor = proveedor != null ? proveedor.Nombre : "Desconocido";
                    string emailProveedor = proveedor != null && !string.IsNullOrEmpty(proveedor.Email)
                        ? proveedor.Email : "-";
                    string direccionProveedor = proveedor != null && !string.IsNullOrEmpty(proveedor.Direccion)
                        ? proveedor.Direccion : "-";

                    Paragraph datosProveedor = new Paragraph()
                        .Add(new Text("DATOS DEL PROVEEDOR\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text("Nombre: " + nombreProveedor + "\n").SetFontSize(10))
                        .Add(new Text("Email: " + emailProveedor + "\n").SetFontSize(10))
                        .Add(new Text("Dirección: " + direccionProveedor + "\n").SetFontSize(10))
                        .SetFontColor(colorTextoOscuro);
                    infoSolicitud.AddCell(new Cell().Add(datosProveedor).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    Paragraph datosSolicitud = new Paragraph()
                        .Add(new Text("SOLICITUD DE COTIZACIÓN\n").SetFontSize(11).SetFontColor(colorPrimario))
                        .Add(new Text("N°: " + idSolicitud.ToString().PadLeft(8, '0') + "\n").SetFontSize(10))
                        .Add(new Text("Fecha: " + fecha.ToString("dd-MM-yyyy") + "\n").SetFontSize(10))
                        .Add(new Text("Estado: " + GetDescripcionEstado(estado) + "\n").SetFontSize(10))
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetFontColor(colorTextoOscuro);
                    infoSolicitud.AddCell(new Cell().Add(datosSolicitud).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    doc.Add(infoSolicitud);

                    // --- TABLA DE DETALLES ---
                    doc.Add(new Paragraph("DETALLE DE INSUMOS").SetFontSize(12)
                        .SetFontColor(colorTextoOscuro).SetMarginBottom(8f));

                    Table tabla = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 20f, 30f }))
                        .SetWidth(UnitValue.CreatePercentValue(100));

                    string[] encabezados = { "Insumo", "Unidad", "Cantidad" };
                    foreach (string nomHeader in encabezados)
                    {
                        Cell headerCell = new Cell().Add(new Paragraph(nomHeader)
                            .SetFontColor(ColorConstants.WHITE).SetFontSize(10));
                        headerCell.SetBackgroundColor(colorTextoOscuro);
                        headerCell.SetPadding(6f);
                        headerCell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

                        if (nomHeader == "Cantidad") headerCell.SetTextAlignment(TextAlignment.RIGHT);

                        tabla.AddHeaderCell(headerCell);
                    }

                    bool filaAlterna = false;
                    if (detalles != null)
                    {
                        foreach (DetalleSolicitudCotizacion detalle in detalles)
                        {
                            if (detalle == null) continue;

                            Cell cInsumo = new Cell().Add(new Paragraph(
                                detalle.NombreInsumo ?? string.Empty).SetFontSize(10));
                            Cell cUnidad = new Cell().Add(new Paragraph(
                                detalle.UnidadMedidaInsumo ?? string.Empty).SetFontSize(10)
                                .SetTextAlignment(TextAlignment.CENTER));
                            Cell cCantidad = new Cell().Add(new Paragraph(
                                detalle.Cantidad.ToString("0.####")).SetFontSize(10)
                                .SetTextAlignment(TextAlignment.RIGHT));

                            Cell[] celdas = { cInsumo, cUnidad, cCantidad };
                            foreach (Cell celda in celdas)
                            {
                                celda.SetPadding(6f);
                                celda.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                                celda.SetBorderBottom(new iText.Layout.Borders.SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f));

                                if (filaAlterna) celda.SetBackgroundColor(colorGrisClaro);
                            }

                            tabla.AddCell(cInsumo);
                            tabla.AddCell(cUnidad);
                            tabla.AddCell(cCantidad);

                            filaAlterna = !filaAlterna;
                        }
                    }
                    doc.Add(tabla);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ── Estilos (wrappers locales sobre UIStyles) ──────────────
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarDataGridView(System.Windows.Forms.DataGridView dgv,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
        {
            dgv.Location = ubicacion;
            dgv.Size = tamaño;
            dgv.TabIndex = tabIndex;
            UIStyles.ConfigurarDataGrid(dgv);
        }
    }
}

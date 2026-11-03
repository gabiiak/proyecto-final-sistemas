using ClosedXML.Excel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Modelos;
using Negocio;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class UIGestionCompras : Form, IRecargable
    {
        private List<Compra> listadoComprasTotales = new List<Compra>();
        private List<Compra> listadoComprasFiltradas = new List<Compra>();
        private Dictionary<int, string> nombresProveedores = new Dictionary<int, string>();
        private bool mostrarCanceladas = false;
        private DateTime? filtroDesde = null;
        private DateTime? filtroHasta = null;
        private int filtroProveedor = 0;
        public int idCompra;

        public void Recargar()
        {
            this.AutoScrollPosition = new System.Drawing.Point(0, 0); // reset de scroll al volver de sub-forms para no quedar en scroll raro
            ActualizarDataGridView();
        }
        public UIGestionCompras()
        {
            InitializeComponent();
            this.AutoScroll = true; // scrollbars H/V cuando la pantalla (ej. 1366x768) no alcanza
            dgvTodasLasCompras.AllowUserToAddRows = false;
            CargarFiltroProveedores();

            ConfigurarBotonPrimario(this.btnRegistrarCompra, "Pedidos de Compra",
                new System.Drawing.Point(16, 16), 0);
            this.btnRegistrarCompra.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarCompra.Click += new System.EventHandler(this.btnRegistrarCompra_Click);

            ConfigurarBotonSecundario(this.btnCambiarEstado, "Cambiar estado",
                new System.Drawing.Point(16, 72), 1);
            this.btnCambiarEstado.Size = new System.Drawing.Size(138, 36);
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);

            ConfigurarBotonSecundario(this.btnRegistrarPago, "Registrar pago",
                new System.Drawing.Point(166, 72), 2);
            this.btnRegistrarPago.Size = new System.Drawing.Size(138, 36);
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);

            ConfigurarBotonSecundario(this.btnConsultarCompra, "Ver detalle",
                new System.Drawing.Point(16, 156), 3);
            this.btnConsultarCompra.Size = new System.Drawing.Size(138, 32);
            this.btnConsultarCompra.Click += new System.EventHandler(this.btnConsultarCompra_Click);

            ConfigurarBotonSecundario(this.btnExportarExcel, "Exportar Excel",
                new System.Drawing.Point(166, 156), 4);
            this.btnExportarExcel.Size = new System.Drawing.Size(138, 32);
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

            ConfigurarBotonSecundario(this.btnSolicitudesCotizacion, "Solicitudes de cotización",
                new System.Drawing.Point(16, 200), 5);
            this.btnSolicitudesCotizacion.Size = new System.Drawing.Size(288, 32);
            this.btnSolicitudesCotizacion.Click += new System.EventHandler(this.btnSolicitudesCotizacion_Click);

            ConfigurarBotonSecundario(this.btnPresupuestos, "Presupuestos",
                new System.Drawing.Point(16, 240), 7);
            this.btnPresupuestos.Size = new System.Drawing.Size(288, 32);
            this.btnPresupuestos.Click += new System.EventHandler(this.btnPresupuestos_Click);

            ConfigurarLabel(this.lblDesde, "Desde", new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblHasta, "Hasta", new System.Drawing.Point(16, 68));

            ConfigurarBotonPrimario(this.btnFiltrarPorFecha, "Filtrar por fecha",
                new System.Drawing.Point(16, 145), 6);
            this.btnFiltrarPorFecha.Size = new System.Drawing.Size(180, 36);
            this.btnFiltrarPorFecha.Click += new System.EventHandler(this.btnFiltrarPorFecha_Click);

            ConfigurarLabel(this.lblFiltroProveedor, "Filtrar por proveedor",
                new System.Drawing.Point(246, 16));

            ConfigurarBotonPrimario(this.btnFiltroProveedor, "Filtrar",
                new System.Drawing.Point(246, 76), 8);
            this.btnFiltroProveedor.Size = new System.Drawing.Size(120, 36);
            this.btnFiltroProveedor.Click += new System.EventHandler(this.btnFiltroProveedor_Click);

            ConfigurarBotonFantasma(this.btnDesfiltrar, "Quitar filtros",
                new System.Drawing.Point(246, 124), 9);
            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);

            ConfigurarBotonSecundario(this.btnVerCanceladas, "Ver canceladas",
                new System.Drawing.Point(16, 186), 11);
            this.btnVerCanceladas.Size = new System.Drawing.Size(180, 32);
            this.btnVerCanceladas.Click += new System.EventHandler(this.btnVerCanceladas_Click);

            ConfigurarBotonSecundario(this.btnReporteMensual, "Reporte mensual (PDF)",
                new System.Drawing.Point(246, 180), 10);
            this.btnReporteMensual.Size = new System.Drawing.Size(196, 32);
            this.btnReporteMensual.Click += (s, ev) => new UIReporteCompras().ShowDialog();

            try
            {
                ConstruirPanelReportes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los reportes gráficos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UIGestionCompras_Load(object sender, EventArgs e)
        {
            labelId.Text = "";
            ActualizarDataGridView();
        }

        // ---------- Reportes gráficos ----------
        private void ConstruirPanelReportes()
        {
            int anchoChart = this.pnlDerecha.Width - 32;
            int altoChart1 = 250;
            int altoChart2 = this.pnlDerecha.Height - 318 - 16;
            if (altoChart2 < 100)
                altoChart2 = 100;

            Label lblGasto = new Label();
            lblGasto.Text = "Gasto por mes";
            lblGasto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGasto.ForeColor = UIStyles.TextoPrincipal;
            lblGasto.AutoSize = true;
            lblGasto.Location = new Point(16, 10);
            this.pnlDerecha.Controls.Add(lblGasto);

            CartesianChart chartGasto = CrearChartGastoPorMes();
            chartGasto.Location = new Point(16, 32);
            chartGasto.Size = new Size(anchoChart, altoChart1);
            this.pnlDerecha.Controls.Add(chartGasto);

            Label lblStock = new Label();
            lblStock.Text = "Stock de insumos";
            lblStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStock.ForeColor = UIStyles.TextoPrincipal;
            lblStock.AutoSize = true;
            lblStock.Location = new Point(16, 296);
            this.pnlDerecha.Controls.Add(lblStock);

            CartesianChart chartStock = CrearChartStockInsumos();
            chartStock.Location = new Point(16, 318);
            chartStock.Size = new Size(anchoChart, altoChart2);
            this.pnlDerecha.Controls.Add(chartStock);
        }

        private CartesianChart CrearChartGastoPorMes()
        {
            Dictionary<int, double> datos = NCompras.GetGastoPorMesAnio();
            string[] nombresMeses = { "", "Ene", "Feb", "Mar", "Abr", "May", "Jun",
                                      "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };
            string[] meses = datos.Keys.OrderBy(m => m).Select(m => nombresMeses[m]).ToArray();
            double[] valores = datos.Keys.OrderBy(m => m).Select(m => datos[m]).ToArray();

            SKColor colorLinea = new SKColor(UIStyles.HoverSidebar.R, UIStyles.HoverSidebar.G, UIStyles.HoverSidebar.B);
            SKColor colorTexto = new SKColor(UIStyles.GrisTexto.R, UIStyles.GrisTexto.G, UIStyles.GrisTexto.B);
            SKColor colorBorde = new SKColor(UIStyles.BordePanel.R, UIStyles.BordePanel.G, UIStyles.BordePanel.B);

            CartesianChart chart = new CartesianChart
            {
                BackColor = this.pnlDerecha.BackColor,
                Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = valores,
                        Name = "Gasto",
                        Stroke = new SolidColorPaint(colorLinea, 3),
                        Fill = new SolidColorPaint(new SKColor(colorLinea.Red, colorLinea.Green, colorLinea.Blue, 40)),
                        GeometrySize = 8,
                        GeometryStroke = new SolidColorPaint(colorLinea, 2),
                        GeometryFill = new SolidColorPaint(SKColors.White)
                    }
                },
                XAxes = new[]
                {
                    new Axis
                    {
                        Labels = meses,
                        LabelsPaint = new SolidColorPaint(colorTexto),
                        TicksPaint = new SolidColorPaint(colorBorde)
                    }
                },
                YAxes = new[]
                {
                    new Axis
                    {
                        LabelsPaint = new SolidColorPaint(colorTexto),
                        Labeler = val => "$" + val.ToString("N0"),
                        TicksPaint = new SolidColorPaint(colorBorde)
                    }
                }
            };

            return chart;
        }

        private CartesianChart CrearChartStockInsumos()
        {
            List<(string NombreInsumo, decimal Cantidad)> pares = ObtenerStockOrdenado();
            string[] nombres;
            double[] valores;
            if (pares.Count > 0)
            {
                nombres = pares.Select(p => p.NombreInsumo).ToArray();
                valores = pares.Select(p => (double)p.Cantidad).ToArray();
            }
            else
            {
                nombres = new string[] { "Sin datos" };
                valores = new double[] { 0 };
            }

            SKColor colorColumna = new SKColor(UIStyles.Primario.R, UIStyles.Primario.G, UIStyles.Primario.B);
            SKColor colorTexto = new SKColor(UIStyles.GrisTexto.R, UIStyles.GrisTexto.G, UIStyles.GrisTexto.B);
            SKColor colorBorde = new SKColor(UIStyles.BordePanel.R, UIStyles.BordePanel.G, UIStyles.BordePanel.B);

            CartesianChart chart = new CartesianChart
            {
                BackColor = this.pnlDerecha.BackColor,
                Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Values = valores,
                        Name = "Cantidad",
                        Fill = new SolidColorPaint(colorColumna),
                        Rx = 4,
                        Ry = 4
                    }
                },
                XAxes = new[]
                {
                    new Axis
                    {
                        Labels = nombres,
                        LabelsPaint = new SolidColorPaint(colorTexto),
                        TicksPaint = new SolidColorPaint(colorBorde),
                        MinStep = 1,
                        ForceStepToMin = true,
                        LabelsRotation = -35,
                        TextSize = 11
                    }
                },
                YAxes = new[]
                {
                    new Axis
                    {
                        LabelsPaint = new SolidColorPaint(colorTexto),
                        Labeler = val => val.ToString("N0"),
                        TicksPaint = new SolidColorPaint(colorBorde)
                    }
                }
            };

            return chart;
        }

        // Helper: devuelve los pares (insumo, cantidad) ordenados descendente, listo para reemplazar el gráfico por una tabla.
        private List<(string NombreInsumo, decimal Cantidad)> ObtenerStockOrdenado()
        {
            List<StockInsumo> stock = NStockInsumo.GetAllStock();
            return stock
                .OrderByDescending(s => s.CantidadDisponible)
                .Select(s => (s.NombreInsumo, s.CantidadDisponible))
                .ToList();
        }

        // ---------- Carga de datos ----------
        private void CargarFiltroProveedores()
        {
            var proveedores = NProveedores.GetAll();
            nombresProveedores = proveedores.ToDictionary(p => p.IdProveedor, p => p.Nombre);

            var listaCombo = new List<Proveedor>(proveedores);
            listaCombo.Insert(0, new Proveedor { IdProveedor = 0, Nombre = "Todos" });
            cbProveedorFiltro.DataSource = listaCombo;
            cbProveedorFiltro.DisplayMember = "Nombre";
            cbProveedorFiltro.ValueMember = "IdProveedor";
        }

        private string GetNombreProveedor(int id)
        {
            return nombresProveedores.TryGetValue(id, out string nombre) ? nombre : "Desconocido";
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

        private void ActualizarDataGridView()
        {
            listadoComprasTotales = NCompras.GetAllCompras();
            AplicarFiltros();
        }

        // Compras que corresponden a la vista activa (activas o canceladas).
        private List<Compra> ObtenerComprasVista()
        {
            return listadoComprasTotales
                .Where(c => mostrarCanceladas
                    ? c.Estado == EstadoCompra.Cancelada
                    : (c.Estado == EstadoCompra.Aceptada ||
                       c.Estado == EstadoCompra.Enviada ||
                       c.Estado == EstadoCompra.Recibida))
                .ToList();
        }

        private void AplicarFiltros()
        {
            IEnumerable<Compra> compras = ObtenerComprasVista();

            if (filtroDesde.HasValue && filtroHasta.HasValue)
            {
                compras = compras.Where(c => c.Fecha.Date >= filtroDesde.Value.Date &&
                                             c.Fecha.Date <= filtroHasta.Value.Date);
            }

            if (filtroProveedor != 0)
            {
                compras = compras.Where(c => c.IdProveedor == filtroProveedor);
            }

            listadoComprasFiltradas = compras.ToList();
            MostrarEnGrilla(listadoComprasFiltradas);
        }

        // CAMBIO: se cargan valores reales (DateTime / número) en lugar de texto,
        // así el ordenamiento por columna es correcto. El formato lo aplica la columna.
        private void MostrarEnGrilla(List<Compra> lista)
        {
            dgvTodasLasCompras.Rows.Clear();
            foreach (Compra compra in lista)
            {
                dgvTodasLasCompras.Rows.Add(
                    compra.IdCompra,
                    GetNombreProveedor(compra.IdProveedor),
                    compra.Fecha,
                    compra.TotalCompra,
                    compra.montoPagado,
                    GetDescripcionEstado(compra.Estado),
                    GetDescripcionEstadoPago(compra.EstadoPago)
                );
            }
            dgvTodasLasCompras.Refresh();
        }

        private void dgvTodasLasCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTodasLasCompras.CurrentRow == null) return;
            labelId.Text = dgvTodasLasCompras.CurrentRow.Cells["IdCompra"].Value?.ToString();
            if (int.TryParse(labelId.Text, out int id))
                idCompra = id;
        }

        private bool TryGetSeleccion(out int id)
        {
            id = 0;
            if (string.IsNullOrEmpty(labelId.Text) || !int.TryParse(labelId.Text, out id))
            {
                MessageBox.Show("Debe seleccionar una compra.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }

        // ---------- Acciones ----------
        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            UIGestionPedidosCompra gestion = new UIGestionPedidosCompra();
            gestion.ShowDialog();
            ActualizarDataGridView();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            Compra compra = NCompras.GetCompraById(id);
            if (compra == null)
            {
                MessageBox.Show("La compra no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool hayTransiciones = false;
            for (int est = EstadoCompra.Emitida; est <= EstadoCompra.Cancelada; est++)
            {
                if (NCompras.EsTransicionValida(compra.Estado, est))
                    hayTransiciones = true;
            }
            if (!hayTransiciones)
            {
                MessageBox.Show("La compra está en un estado final y no se puede cambiar.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UIEstadoCompra dialogoEstado = new UIEstadoCompra(compra.Estado);
            if (dialogoEstado.ShowDialog() != DialogResult.OK) return;
            int nuevoEstado = dialogoEstado.estado;

            try
            {
                if (nuevoEstado == EstadoCompra.Recibida)
                {
                    NCompras.MarcarCompraRecibida(id);
                    MessageBox.Show("Compra marcada como recibida. Stock de insumos actualizado.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NCompras.CambiarEstado(id, nuevoEstado);
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarDataGridView();
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            try
            {
                decimal deuda = NCompras.CalcularDeuda(id);
                if (deuda <= 0.01m)
                {
                    MessageBox.Show("La compra no tiene deuda pendiente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal? monto = PedirMonto(deuda);
                if (monto == null) return;

                NCompras.RegistrarPago(id, monto.Value);

                decimal deudaRestante = NCompras.CalcularDeuda(id);
                if (deudaRestante > 0.01m)
                {
                    MessageBox.Show("Pago registrado. Deuda restante: " + deudaRestante.ToString("C2") + ".", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Compra pagada.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarDataGridView();
        }


        private void btnConsultarCompra_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            UIConsultarCompra consulta = new UIConsultarCompra(id);
            consulta.Show();
        }

        private void btnSolicitudesCotizacion_Click(object sender, EventArgs e)
        {
            UIGestionSolicitudesCotizacion gestion = new UIGestionSolicitudesCotizacion();
            gestion.ShowDialog();
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            UIGestionPresupuestos gestion = new UIGestionPresupuestos();
            UIMenu2 menu = this.TopLevelControl as UIMenu2;
            if (menu != null)
                menu.AbrirSubFormulario(gestion);
            else
                gestion.ShowDialog();
        }

        // ---------- Diálogos simples armados por código ----------
        private decimal? PedirMonto(decimal deuda)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = "Registrar pago";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ClientSize = new System.Drawing.Size(320, 150);
                dlg.Font = new System.Drawing.Font("Segoe UI", 10F);
                dlg.BackColor = System.Drawing.Color.FromArgb(244, 247, 251);

                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                ConfigurarLabel(lbl, "Monto a pagar (deuda: " + deuda.ToString("C2") + ")",
                    new System.Drawing.Point(16, 16));
                lbl.Size = new System.Drawing.Size(288, 18);

                NumericUpDown num = new NumericUpDown();
                num.DecimalPlaces = 2;
                num.Minimum = 0.01m;
                num.Maximum = Math.Max(deuda, 0.01m);
                num.Value = Math.Max(deuda, 0.01m);
                num.Location = new System.Drawing.Point(16, 40);
                num.Size = new System.Drawing.Size(288, 28);

                Button ok = new Button();
                ConfigurarBotonPrimario(ok, "Aceptar", new System.Drawing.Point(16, 98), 1);
                ok.DialogResult = DialogResult.OK;

                Button cancelar = new Button();
                ConfigurarBotonSecundario(cancelar, "Cancelar", new System.Drawing.Point(164, 98), 2);
                cancelar.DialogResult = DialogResult.Cancel;

                dlg.AcceptButton = ok;
                dlg.CancelButton = cancelar;
                dlg.Controls.AddRange(new Control[] { lbl, num, ok, cancelar });
                UIStyles.AplicarTemaAForm(dlg);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                    return num.Value;
                return null;
            }
        }

        // ---------- Filtros ----------
        private void btnFiltrarPorFecha_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("Las fechas son incorrectas. La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Alerta", MessageBoxButtons.OK);
                return;
            }

            filtroDesde = desde;
            filtroHasta = hasta;
            AplicarFiltros();

            if (listadoComprasFiltradas.Count == 0)
            {
                MessageBox.Show("No se encontraron compras por esas fechas...", "Alerta", MessageBoxButtons.OK);
            }
        }

        private void btnFiltroProveedor_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = cbProveedorFiltro.SelectedItem as Proveedor;
            if (proveedor == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            filtroProveedor = proveedor.IdProveedor;
            AplicarFiltros();
        }

        private void btnVerCanceladas_Click(object sender, EventArgs e)
        {
            mostrarCanceladas = !mostrarCanceladas;
            btnVerCanceladas.Text = mostrarCanceladas ? "Ver activas" : "Ver canceladas";
            AplicarFiltros();
        }

        private void btnDesfiltrar_Click(object sender, EventArgs e)
        {
            mostrarCanceladas = false;
            btnVerCanceladas.Text = "Ver canceladas";
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            filtroDesde = null;
            filtroHasta = null;
            filtroProveedor = 0;
            if (cbProveedorFiltro.Items.Count > 0)
                cbProveedorFiltro.SelectedIndex = 0;
            ActualizarDataGridView();
        }

        // ---------- Excel ----------
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                saveDialog.FileName = "ResumenCompras_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ResumenCompras resumen = NCompras.CalcularResumenCompras(listadoComprasFiltradas);

                    int anioActual = DateTime.Now.Year;
                    Dictionary<int, double> comprasPrimerSemestre = NCompras.GetComprasPorMesSemestre(anioActual, 1);
                    Dictionary<int, double> comprasSegundoSemestre = NCompras.GetComprasPorMesSemestre(anioActual, 2);

                    GenerarExcelResumen(resumen, comprasPrimerSemestre, comprasSegundoSemestre, saveDialog.FileName);

                    MessageBox.Show("Excel generado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el Excel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarExcelResumen(ResumenCompras resumen,
            Dictionary<int, double> comprasPrimerSemestre,
            Dictionary<int, double> comprasSegundoSemestre,
            string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Resumen Compras");

                hoja.Cell(1, 1).Value = "Resumen de Compras";
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 14;

                hoja.Cell(3, 1).Value = "Cantidad de compras";
                hoja.Cell(3, 2).Value = resumen.CantidadCompras;

                hoja.Cell(4, 1).Value = "Total comprado";
                hoja.Cell(4, 2).Value = resumen.TotalCompras;
                hoja.Cell(4, 2).Style.NumberFormat.Format = "$#,##0.00";

                hoja.Cell(5, 1).Value = "Total pagado";
                hoja.Cell(5, 2).Value = resumen.TotalPagado;
                hoja.Cell(5, 2).Style.NumberFormat.Format = "$#,##0.00";

                hoja.Cell(6, 1).Value = "Total en deuda";
                hoja.Cell(6, 2).Value = resumen.TotalDeuda;
                hoja.Cell(6, 2).Style.NumberFormat.Format = "$#,##0.00";

                hoja.Cell(7, 1).Value = "Promedio de compra";
                hoja.Cell(7, 2).Value = resumen.PromedioCompra;
                hoja.Cell(7, 2).Style.NumberFormat.Format = "$#,##0.00";

                int fila = 9;
                hoja.Cell(fila, 1).Value = "Período";
                hoja.Cell(fila, 2).Value = "Total comprado";
                hoja.Range(fila, 1, fila, 2).Style.Font.Bold = true;
                fila++;

                foreach (KeyValuePair<string, decimal> item in resumen.TotalesPorPeriodo)
                {
                    hoja.Cell(fila, 1).Value = item.Key;
                    hoja.Cell(fila, 2).Value = item.Value;
                    hoja.Cell(fila, 2).Style.NumberFormat.Format = "$#,##0.00";
                    fila++;
                }

                int anioActual = DateTime.Now.Year;

                fila += 2;
                fila = EscribirTablaSemestre(hoja, fila, "1er Semestre " + anioActual, comprasPrimerSemestre);

                fila += 2;
                fila = EscribirTablaSemestre(hoja, fila, "2do Semestre " + anioActual, comprasSegundoSemestre);

                hoja.Columns().AdjustToContents();
                libro.SaveAs(rutaArchivo);
            }
        }

        private int EscribirTablaSemestre(IXLWorksheet hoja, int fila, string titulo, Dictionary<int, double> comprasPorMes)
        {
            hoja.Cell(fila, 1).Value = "Compras por mes - " + titulo;
            hoja.Cell(fila, 1).Style.Font.Bold = true;
            hoja.Cell(fila, 1).Style.Font.FontSize = 12;
            fila += 2;

            hoja.Cell(fila, 1).Value = "Mes";
            hoja.Cell(fila, 2).Value = "Total comprado";
            hoja.Range(fila, 1, fila, 2).Style.Font.Bold = true;
            fila++;

            foreach (KeyValuePair<int, double> item in comprasPorMes)
            {
                hoja.Cell(fila, 1).Value = ObtenerNombreMes(item.Key);
                hoja.Cell(fila, 2).Value = item.Value;
                hoja.Cell(fila, 2).Style.NumberFormat.Format = "$#,##0.00";
                fila++;
            }

            return fila;
        }

        private string ObtenerNombreMes(int mes)
        {
            switch (mes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default: return "Desconocido";
            }
        }

        // ---------- Estilos ----------
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(200, 18));

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonFantasma(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(200, 30));

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => UIStyles.PintarPanelRedondeado(sender, e);
    }
}
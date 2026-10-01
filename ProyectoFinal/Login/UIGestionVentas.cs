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
using ClosedXML.Excel;

namespace Login
{
    public partial class UIGestionVentas : Form
    {
        private List<Venta> listadoVentasTotales = new List<Venta>();
        private List<Venta> listadoVentasFiltradas = new List<Venta>();
        public int idVenta;
        public UIGestionVentas()
        {
            InitializeComponent();
            dgvTodasLasVentas.AllowUserToAddRows = false;
            CargarFiltroClientes();

            ConfigurarBotonPrimario(this.btnRegistrarVenta, "Registrar Venta",
                new System.Drawing.Point(16, 16), 0);
            this.btnRegistrarVenta.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);

            // Botones de estado — lado a lado
            ConfigurarBotonSecundario(this.btnEstadoPago, "Estado de Pago",
                new System.Drawing.Point(16, 72), 1);
            this.btnEstadoPago.Size = new System.Drawing.Size(138, 36);
            this.btnEstadoPago.Click += new System.EventHandler(this.btnEstadoPago_Click);

            ConfigurarBotonSecundario(this.btnEstadoPedido, "Estado de Pedido",
                new System.Drawing.Point(166, 72), 2);
            this.btnEstadoPedido.Size = new System.Drawing.Size(138, 36);
            this.btnEstadoPedido.Click += new System.EventHandler(this.btnEstadoPedido_Click);

            ConfigurarBotonSecundario(this.btnConsultarVenta, "Ver detalle",
                new System.Drawing.Point(16, 156), 3);
            this.btnConsultarVenta.Size = new System.Drawing.Size(138, 32);
            this.btnConsultarVenta.Click += new System.EventHandler(this.btnConsultarVenta_Click);

            ConfigurarBotonSecundario(this.btnExportarExcel, "Exportar Excel",
                new System.Drawing.Point(166, 156), 4);
            this.btnExportarExcel.Size = new System.Drawing.Size(138, 32);  // ancho completo, texto largo
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);

            ConfigurarBotonSecundario(this.btnTransporte, "Gestionar transporte",
                new System.Drawing.Point(16, 196), 4);
            this.btnTransporte.Size = new System.Drawing.Size(288, 32);  // ancho completo, texto largo
            this.btnTransporte.Click += new System.EventHandler(this.btnTransporte_Click);

            ConfigurarLabel(this.lblDesde, "Desde",
                new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblHasta, "Hasta",
                new System.Drawing.Point(16, 68));

            ConfigurarBotonPrimario(this.btnFiltrarPorFecha, "Filtrar por fecha",
                new System.Drawing.Point(16, 145), 6);
            this.btnFiltrarPorFecha.Size = new System.Drawing.Size(180, 36);
            this.btnFiltrarPorFecha.Click += new System.EventHandler(this.btnFiltrarPorFecha_Click);

            ConfigurarLabel(this.lblFiltroCliente, "Filtrar por cliente",
                new System.Drawing.Point(246, 16));

            ConfigurarBotonPrimario(this.btnFiltroCliente, "Filtrar",
                new System.Drawing.Point(246, 76), 8);
            this.btnFiltroCliente.Size = new System.Drawing.Size(120, 36);
            this.btnFiltroCliente.Click += new System.EventHandler(this.btnFiltroCliente_Click);

            ConfigurarBotonFantasma(this.btnDesfiltrar, "Quitar filtros",
                new System.Drawing.Point(246, 124), 9);
            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);
        }

        private void UISalesManagement_Load(object sender, EventArgs e)
        {
            labelId.Text = "";
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            listadoVentasTotales = NVentas.GetAllVentas();
            listadoVentasFiltradas = listadoVentasTotales;
            //dgvTodasLasVentas.DataSource = null;
            //dgvTodasLasVentas.DataSource = listadoVentasTotalesAÑA;
            dgvTodasLasVentas.Rows.Clear();
            foreach (Venta venta in listadoVentasTotales)
            {
                dgvTodasLasVentas.Rows.Add(
                    venta.IdVenta,
                    venta.Cliente.Nombre,
                    venta.Fecha.ToString("dd-MM-yyyy"),
                    venta.Total.ToString("C2"),
                    venta.Metodo.Descripcion,
                    GetDescripcionEstadoPago(venta.Estado_Pago),
                    GetEstadoPedido(venta.Estado_Pedido)
                    
                    );
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            UIRegistrarVenta registrar = new UIRegistrarVenta();
            if(registrar.ShowDialog() == DialogResult.OK)
            {
                listadoVentasTotales.Add(registrar.ventaEnMemoria);
            }
            ActualizarDataGridView();
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

        private void dgvTodasLasVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTodasLasVentas.CurrentRow == null) return;
            labelId.Text = dgvTodasLasVentas.CurrentRow.Cells["IdVenta"].Value?.ToString();
            idVenta = int.Parse(labelId.Text);
        }

        private void btnEstadoPago_Click(object sender, EventArgs e) //me la mandé // solucionado
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar una venta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            int idVenta = int.Parse(labelId.Text);
            UIEstadoPago estado = new UIEstadoPago(idVenta);
            if (estado.ShowDialog() == DialogResult.OK)
            {
                int nuevoEstado = estado.estado;
                NVentas.CambiarEstadoPago(idVenta, estado.estado);
            }
            ActualizarDataGridView();
        }

        private void btnEstadoPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar una venta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            UIEstadoPedido pedido = new UIEstadoPedido();
            if (pedido.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (pedido.estado == EstadoPedido.Listo)
                    {
                        NVentas.MarcarPedidoListo(idVenta);
                        MessageBox.Show("Pedido marcado como listo. Stock actualizado.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        NVentas.CambiarEstadoPedido(idVenta, pedido.estado);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ActualizarDataGridView();
        }
        private void btnConsultarVenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar una venta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            int idVenta = int.Parse(labelId.Text);
            UIConsultarVenta consulta = new UIConsultarVenta(idVenta);
            consulta.Show();
        }

        private void btnFiltrarPorFecha_Click(object sender, EventArgs e)
        {
            //string desde = dtpDesde.Value.Date.ToString();
            //string hasta = dtpHasta.Value.Date.ToString();

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("Las fechas son incorrectas. La fecha 'Desde' no puede ser mayor que 'Hasta' (Error temporal)","Alerta", MessageBoxButtons.OK);
                return;
            }

            var listaFiltrada = listadoVentasTotales.Where(c => c.Fecha.Date >= desde && c.Fecha.Date <= hasta).ToList();
            if (listaFiltrada.Count == 0)
            {
                MessageBox.Show("No se encontraron ventas por esas fechas...", "Alerta", MessageBoxButtons.OK);
                return;
            }
            listadoVentasFiltradas = listaFiltrada;
            dgvTodasLasVentas.Rows.Clear();
            foreach (Venta venta in listaFiltrada)
            {
                dgvTodasLasVentas.Rows.Add(
                    venta.IdVenta,
                    venta.Cliente.Nombre,
                    venta.Fecha.ToString("dd-MM-yyyy"),
                    venta.Total.ToString("C2"),
                    venta.Metodo.Descripcion,
                    GetDescripcionEstadoPago(venta.Estado_Pago),
                    GetEstadoPedido(venta.Estado_Pedido)
                    );
            }
            dgvTodasLasVentas.Refresh();
        }
        private void CargarFiltroClientes()
        {
            var clientes = NClientes.GetAll();
            clientes.Insert(0, new Cliente { Id = 0, Nombre = "Todos" });
            cbClienteFiltro.DataSource = clientes;
            cbClienteFiltro.DisplayMember = "Nombre";
            cbClienteFiltro.ValueMember = "Id";
        }

        private void btnDesfiltrar_Click(object sender, EventArgs e)
        {
            ActualizarDataGridView();
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
        }

        private void btnFiltroCliente_Click(object sender, EventArgs e)
        {
            int idClienteSeleccionado = ((Cliente)cbClienteFiltro.SelectedItem).Id;
            var listaFiltrada = listadoVentasTotales
                .Where(v => idClienteSeleccionado == 0 || v.Cliente.Id == idClienteSeleccionado)
                .ToList();
            //para debuggear
            //MessageBox.Show($"Id seleccionado: {idClienteSeleccionado}\n" +
            //string.Join("\n", listadoVentasTotales.Select(v => $"Venta {v.IdVenta} - Cliente id: {v.Cliente.Id} - Nombre: {v.Cliente.Nombre}")));
            listadoVentasFiltradas = listaFiltrada;
            dgvTodasLasVentas.Rows.Clear();
            foreach (Venta venta in listaFiltrada)
            {
                dgvTodasLasVentas.Rows.Add(
                    venta.IdVenta,
                    venta.Cliente.Nombre,
                    venta.Fecha.ToString("dd-MM-yyyy"),
                    venta.Total.ToString("C2"),
                    venta.Metodo.Descripcion,
                    GetDescripcionEstadoPago(venta.Estado_Pago),
                    GetEstadoPedido(venta.Estado_Pedido)
                    );
            }
            dgvTodasLasVentas.Refresh();
        }

        private void btnTransporte_Click(object sender, EventArgs e)
        {
            var trans = new UIListaTransportes();
            trans.ShowDialog();
            ActualizarDataGridView();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                saveDialog.FileName = "ResumenVentas_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ResumenVentas resumen = NVentas.CalcularResumenVentas(listadoVentasFiltradas);

                    int anioActual = DateTime.Now.Year;
                    Dictionary<int, double> ventasPrimerSemestre = NVentas.GetVentasPorMesSemestre(anioActual, 1);
                    Dictionary<int, double> ventasSegundoSemestre = NVentas.GetVentasPorMesSemestre(anioActual, 2);

                    GenerarExcelResumen(resumen, ventasPrimerSemestre, ventasSegundoSemestre, saveDialog.FileName);

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

        private void GenerarExcelResumen(ResumenVentas resumen,
    Dictionary<int, double> ventasPrimerSemestre,
    Dictionary<int, double> ventasSegundoSemestre,
    string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Resumen Ventas");

                hoja.Cell(1, 1).Value = "Resumen de Ventas";
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 14;

                hoja.Cell(3, 1).Value = "Cantidad de ventas";
                hoja.Cell(3, 2).Value = resumen.CantidadVentas;

                hoja.Cell(4, 1).Value = "Total vendido";
                hoja.Cell(4, 2).Value = resumen.TotalVentas;
                hoja.Cell(4, 2).Style.NumberFormat.Format = "$#,##0.00";

                hoja.Cell(5, 1).Value = "Total cobrado";
                hoja.Cell(5, 2).Value = resumen.TotalCobrado;
                hoja.Cell(5, 2).Style.NumberFormat.Format = "$#,##0.00";

                hoja.Cell(6, 1).Value = "Total en deuda";
                hoja.Cell(6, 2).Value = resumen.TotalDeuda;
                hoja.Cell(6, 2).Style.NumberFormat.Format = "$#,##0.00";

                hoja.Cell(7, 1).Value = "Promedio de venta";
                hoja.Cell(7, 2).Value = resumen.TicketPromedio;
                hoja.Cell(7, 2).Style.NumberFormat.Format = "$#,##0.00";

                int fila = 9;
                hoja.Cell(fila, 1).Value = "Período";
                hoja.Cell(fila, 2).Value = "Total vendido";
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
                fila = EscribirTablaSemestre(hoja, fila, "1er Semestre " + anioActual, ventasPrimerSemestre);

                fila += 2;
                fila = EscribirTablaSemestre(hoja, fila, "2do Semestre " + anioActual, ventasSegundoSemestre);

                hoja.Columns().AdjustToContents();
                libro.SaveAs(rutaArchivo);
            }
        }

        private int EscribirTablaSemestre(IXLWorksheet hoja, int fila, string titulo, Dictionary<int, double> ventasPorMes)
        {
            hoja.Cell(fila, 1).Value = "Ventas por mes - " + titulo;
            hoja.Cell(fila, 1).Style.Font.Bold = true;
            hoja.Cell(fila, 1).Style.Font.FontSize = 12;
            fila++;
            fila++;

            hoja.Cell(fila, 1).Value = "Mes";
            hoja.Cell(fila, 2).Value = "Total vendido";
            hoja.Range(fila, 1, fila, 2).Style.Font.Bold = true;
            fila++;

            foreach (KeyValuePair<int, double> item in ventasPorMes)
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




        //mañana agregar lógica de modificacion de venta y cambio de estados
    }
}

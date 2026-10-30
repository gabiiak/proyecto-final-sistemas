using ClosedXML.Excel;
using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class UIGestionPresupuestos : Form
    {
        private static readonly string[] ColoresProveedor =
        {
            "#FCE4D6", "#DDEBF7", "#FFF2CC", "#E4DFEC", "#F8CBAD",
            "#BDD7EE", "#FFE699", "#D9E1F2", "#F4B6C2", "#D0CECE"
        };

        private List<Presupuesto> listadoPresupuestosTotales = new List<Presupuesto>();

        public UIGestionPresupuestos()
        {
            InitializeComponent();
            dgvPresupuestos.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvPresupuestos);

            ConfigurarBotonPrimario(this.btnRegistrarSolicitud, "Registrar solicitud",
                new System.Drawing.Point(16, 36), 0);
            this.btnRegistrarSolicitud.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarSolicitud.Click += new System.EventHandler(this.btnRegistrarSolicitud_Click);

            ConfigurarBotonPrimario(this.btnRegistrarPresupuesto, "Registrar presupuesto",
                new System.Drawing.Point(16, 84), 1);
            this.btnRegistrarPresupuesto.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarPresupuesto.Click += new System.EventHandler(this.btnRegistrarPresupuesto_Click);

            ConfigurarBotonSecundario(this.btnVerDetalle, "Ver detalle",
                new System.Drawing.Point(16, 136), 2);
            this.btnVerDetalle.Size = new System.Drawing.Size(138, 32);
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);

            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(166, 136), 3);
            this.btnModificar.Size = new System.Drawing.Size(138, 32);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(16, 176), 4);
            this.btnEliminar.Size = new System.Drawing.Size(138, 32);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnAceptar, "Aceptar",
                new System.Drawing.Point(166, 176), 5);
            this.btnAceptar.Size = new System.Drawing.Size(138, 32);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            ConfigurarBotonSecundario(this.btnRechazar, "Rechazar",
                new System.Drawing.Point(16, 216), 6);
            this.btnRechazar.Size = new System.Drawing.Size(138, 32);
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);

            ConfigurarBotonFantasma(this.btnPresupuestosEliminados, "Ver presupuestos eliminados",
                new System.Drawing.Point(16, 264), 7);
            this.btnPresupuestosEliminados.Size = new System.Drawing.Size(288, 30);
            this.btnPresupuestosEliminados.Click += new System.EventHandler(this.btnPresupuestosEliminados_Click);

            ConfigurarLabel(this.lblFiltroProveedor, "Proveedor", new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbProveedorFiltro, new System.Drawing.Point(16, 38),
                new System.Drawing.Size(250, 28), 8);

            ConfigurarLabel(this.lblNumeroCotizacion, "N° de cotización", new System.Drawing.Point(300, 16));
            ConfigurarTextBox(this.txtNumeroCotizacion, new System.Drawing.Point(300, 38),
                new System.Drawing.Size(160, 28), 9);

            ConfigurarBotonPrimario(this.btnFiltrar, "Filtrar",
                new System.Drawing.Point(490, 36), 10);
            this.btnFiltrar.Size = new System.Drawing.Size(120, 32);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            ConfigurarBotonFantasma(this.btnDesfiltrar, "Quitar filtros",
                new System.Drawing.Point(490, 80), 11);
            this.btnDesfiltrar.Size = new System.Drawing.Size(120, 28);
            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);

            ConfigurarLabel(this.lblPeriodo, "Mes / año", new System.Drawing.Point(300, 72));
            this.lblPeriodo.Size = new System.Drawing.Size(180, 18);

            ConfigurarCombo(this.cbMes, new System.Drawing.Point(300, 94),
                new System.Drawing.Size(110, 28), 12, ComboBoxStyle.DropDownList);

            this.numAnio.Location = new System.Drawing.Point(420, 94);
            this.numAnio.Size = new System.Drawing.Size(70, 28);
            this.numAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numAnio.Minimum = 2000;
            this.numAnio.Maximum = 2100;
            this.numAnio.Value = DateTime.Today.Year;
            this.numAnio.TabIndex = 13;

            ConfigurarBotonPrimario(this.btnGenerarReporte, "Generar reporte",
                new System.Drawing.Point(490, 112), 14);
            this.btnGenerarReporte.Size = new System.Drawing.Size(120, 28);
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            UIStyles.AplicarTemaAForm(this);
        }

        private void UIGestionPresupuestos_Load(object sender, EventArgs e)
        {
            labelId.Text = "";
            CargarFiltroProveedores();
            CargarPeriodo();
            ActualizarDataGridView();
        }

        // ---------- Carga de datos ----------
        private void CargarFiltroProveedores()
        {
            var proveedores = NProveedores.GetAll();
            var listaCombo = new List<Proveedor>(proveedores);
            listaCombo.Insert(0, new Proveedor { IdProveedor = 0, Nombre = "Todos" });
            cbProveedorFiltro.DataSource = listaCombo;
            cbProveedorFiltro.DisplayMember = "Nombre";
            cbProveedorFiltro.ValueMember = "IdProveedor";
        }

        private void CargarPeriodo()
        {
            cbMes.Items.Clear();
            cbMes.Items.AddRange(new object[]
            {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            });
            cbMes.SelectedIndex = DateTime.Today.Month - 1;
            numAnio.Value = DateTime.Today.Year;
        }

        private void ActualizarDataGridView()
        {
            try
            {
                listadoPresupuestosTotales = NPresupuesto.GetAll();
                MostrarEnGrilla(listadoPresupuestosTotales);
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

        private void MostrarEnGrilla(List<Presupuesto> lista)
        {
            dgvPresupuestos.Rows.Clear();
            foreach (Presupuesto presupuesto in lista)
            {
                dgvPresupuestos.Rows.Add(
                    presupuesto.IdPresupuesto,
                    presupuesto.IdSolicitud,
                    presupuesto.NombreProveedor,
                    presupuesto.Fecha,
                    presupuesto.Total,
                    UIRegistrarSolicitudCotizacion.GetDescripcionEstado(presupuesto.EstadoSolicitud)
                );
            }
            dgvPresupuestos.Refresh();
        }

        private void dgvPresupuestos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPresupuestos.CurrentRow == null) return;
            labelId.Text = dgvPresupuestos.CurrentRow.Cells["IdPresupuesto"].Value?.ToString();
        }

        private bool TryGetSeleccion(out int id)
        {
            id = 0;
            if (string.IsNullOrEmpty(labelId.Text) || !int.TryParse(labelId.Text, out id))
            {
                MessageBox.Show("Debe seleccionar un presupuesto.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }

        // ---------- Acciones ----------
        private void btnRegistrarSolicitud_Click(object sender, EventArgs e)
        {
            UIRegistrarSolicitudCotizacion registrar = new UIRegistrarSolicitudCotizacion();
            registrar.ShowDialog();
            ActualizarDataGridView();
        }

        private void btnRegistrarPresupuesto_Click(object sender, EventArgs e)
        {
            UIRegistrarPresupuesto registrar = new UIRegistrarPresupuesto();
            registrar.ShowDialog();
            ActualizarDataGridView();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            UIConsultarPresupuesto consulta = new UIConsultarPresupuesto(id);
            consulta.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            try
            {
                Presupuesto presupuesto = NPresupuesto.GetById(id);
                if (presupuesto == null)
                {
                    MessageBox.Show("El presupuesto no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (presupuesto.EstadoSolicitud != EstadoSolicitudCotizacion.Recibida)
                {
                    MessageBox.Show("Solo se puede modificar un presupuesto mientras la solicitud está recibida.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                UIRegistrarPresupuesto modificar = new UIRegistrarPresupuesto(id);
                modificar.ShowDialog();
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
            ActualizarDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            if (MessageBox.Show("¿Desea eliminar el presupuesto seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                NPresupuesto.EliminarPresupuesto(id);
                MessageBox.Show("Presupuesto eliminado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarDataGridView();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            try
            {
                NPresupuesto.AceptarPresupuesto(id);
                MessageBox.Show("La solicitud quedó ACEPTADA.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarDataGridView();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            if (MessageBox.Show("¿Desea rechazar el presupuesto seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                NPresupuesto.RechazarPresupuesto(id);
                MessageBox.Show("La solicitud quedó CANCELADA.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarDataGridView();
        }

        private void btnPresupuestosEliminados_Click(object sender, EventArgs e)
        {
            UIPresupuestosEliminados eliminados = new UIPresupuestosEliminados();
            eliminados.Show();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMes.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un mes para generar el reporte.", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int mes = cbMes.SelectedIndex + 1;
                int anio = (int)numAnio.Value;
                List<Presupuesto> presupuestos = NPresupuesto.GetReporteMensual(anio, mes);

                if (presupuestos == null || presupuestos.Count == 0)
                {
                    MessageBox.Show("No hay presupuestos activos para el período seleccionado.", "Sin datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                    saveDialog.FileName = string.Format("ReportePresupuestos_{0}{1:00}.xlsx", anio, mes);

                    if (saveDialog.ShowDialog() != DialogResult.OK) return;

                    GenerarExcelReporte(presupuestos, anio, mes, saveDialog.FileName);
                }

                MessageBox.Show("Reporte generado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Filtros ----------
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int idProveedor = 0;
            Proveedor proveedor = cbProveedorFiltro.SelectedItem as Proveedor;
            if (proveedor != null) idProveedor = proveedor.IdProveedor;

            string texto = txtNumeroCotizacion.Text.Trim();
            bool filtrarNumero = texto.Length > 0;
            int numero = 0;
            if (filtrarNumero && !int.TryParse(texto, out numero))
            {
                MessageBox.Show("El N° de cotización debe ser numérico.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Presupuesto> filtrados = new List<Presupuesto>();
            foreach (Presupuesto presupuesto in listadoPresupuestosTotales)
            {
                if (idProveedor != 0 && presupuesto.IdProveedor != idProveedor) continue;
                if (filtrarNumero && presupuesto.IdSolicitud != numero) continue;
                filtrados.Add(presupuesto);
            }

            MostrarEnGrilla(filtrados);
        }

        private void btnDesfiltrar_Click(object sender, EventArgs e)
        {
            txtNumeroCotizacion.Clear();
            if (cbProveedorFiltro.Items.Count > 0) cbProveedorFiltro.SelectedIndex = 0;
            ActualizarDataGridView();
        }

        // ---------- Reporte de presupuestos ----------
        private void GenerarExcelReporte(List<Presupuesto> presupuestos, int anio, int mes,
            string rutaArchivo)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hojaGeneral = libro.Worksheets.Add("Presupuestos");
                IXLWorksheet hojaComparativo = libro.Worksheets.Add("Comparativo");

                GenerarHojaGeneral(hojaGeneral, presupuestos, anio, mes);
                GenerarHojaComparativo(hojaComparativo, presupuestos, anio, mes);

                libro.SaveAs(rutaArchivo);
            }
        }

        private void GenerarHojaGeneral(IXLWorksheet hoja, List<Presupuesto> presupuestos,
            int anio, int mes)
        {
            hoja.Cell(1, 1).Value = "Reporte de presupuestos";
            hoja.Cell(1, 1).Style.Font.Bold = true;
            hoja.Cell(1, 1).Style.Font.FontSize = 14;

            hoja.Cell(2, 1).Value = "Período: " + GetNombreMes(mes) + " " + anio;
            hoja.Cell(3, 1).Value = "Cantidad de presupuestos: " + presupuestos.Count;
            hoja.Cell(4, 1).Value = "Total general:";

            decimal totalGeneral = 0m;
            foreach (Presupuesto presupuesto in presupuestos)
            {
                totalGeneral += presupuesto.Total;
            }

            hoja.Cell(4, 2).Value = totalGeneral;
            hoja.Cell(4, 2).Style.NumberFormat.Format = "$#,##0.00";

            int fila = 6;
            hoja.Cell(fila, 1).Value = "N° Presupuesto";
            hoja.Cell(fila, 2).Value = "N° Cotización";
            hoja.Cell(fila, 3).Value = "Proveedor";
            hoja.Cell(fila, 4).Value = "Fecha";
            hoja.Cell(fila, 5).Value = "Estado";
            hoja.Cell(fila, 6).Value = "Total";
            hoja.Range(fila, 1, fila, 6).Style.Font.Bold = true;
            fila++;

            foreach (Presupuesto presupuesto in presupuestos)
            {
                hoja.Cell(fila, 1).Value = presupuesto.IdPresupuesto;
                hoja.Cell(fila, 2).Value = presupuesto.IdSolicitud;
                hoja.Cell(fila, 3).Value = presupuesto.NombreProveedor;
                hoja.Cell(fila, 4).Value = presupuesto.Fecha;
                hoja.Cell(fila, 4).Style.NumberFormat.Format = "dd-MM-yyyy";
                hoja.Cell(fila, 5).Value =
                    UIRegistrarSolicitudCotizacion.GetDescripcionEstado(presupuesto.EstadoSolicitud);
                hoja.Cell(fila, 6).Value = presupuesto.Total;
                hoja.Cell(fila, 6).Style.NumberFormat.Format = "$#,##0.00";
                fila++;
            }

            fila++;
            hoja.Cell(fila, 1).Value = "Detalle de insumos";
            hoja.Cell(fila, 1).Style.Font.Bold = true;
            fila++;

            hoja.Cell(fila, 1).Value = "N° Presupuesto";
            hoja.Cell(fila, 2).Value = "Proveedor";
            hoja.Cell(fila, 3).Value = "Insumo";
            hoja.Cell(fila, 4).Value = "Unidad";
            hoja.Cell(fila, 5).Value = "Cantidad";
            hoja.Cell(fila, 6).Value = "Precio unitario";
            hoja.Cell(fila, 7).Value = "Subtotal";
            hoja.Range(fila, 1, fila, 7).Style.Font.Bold = true;
            fila++;

            foreach (Presupuesto presupuesto in presupuestos)
            {
                foreach (DetallePresupuesto detalle in presupuesto.Detalles)
                {
                    hoja.Cell(fila, 1).Value = presupuesto.IdPresupuesto;
                    hoja.Cell(fila, 2).Value = presupuesto.NombreProveedor;
                    hoja.Cell(fila, 3).Value = detalle.NombreInsumo;
                    hoja.Cell(fila, 4).Value = detalle.UnidadMedidaInsumo;
                    hoja.Cell(fila, 5).Value = detalle.Cantidad;
                    hoja.Cell(fila, 5).Style.NumberFormat.Format = "#,##0.####";
                    hoja.Cell(fila, 6).Value = detalle.PrecioUnitario;
                    hoja.Cell(fila, 6).Style.NumberFormat.Format = "$#,##0.00";
                    hoja.Cell(fila, 7).Value = detalle.Subtotal;
                    hoja.Cell(fila, 7).Style.NumberFormat.Format = "$#,##0.00";
                    fila++;
                }
            }

            hoja.Columns().AdjustToContents();
        }

        private void GenerarHojaComparativo(IXLWorksheet hoja, List<Presupuesto> presupuestos,
            int anio, int mes)
        {
            hoja.Cell(1, 1).Value = "Cuadro comparativo de precios";
            hoja.Cell(1, 1).Style.Font.Bold = true;
            hoja.Cell(1, 1).Style.Font.FontSize = 14;

            hoja.Cell(2, 1).Value = "Período: " + GetNombreMes(mes) + " " + anio;

            List<Proveedor> proveedores = NProveedores.GetAll()
                .OrderBy(p => p.Nombre).ToList();

            Dictionary<int, int> columnasProveedor = new Dictionary<int, int>();
            for (int i = 0; i < proveedores.Count; i++)
            {
                columnasProveedor[proveedores[i].IdProveedor] = 3 + i;
            }

            hoja.Cell(4, 1).Value = "Insumo";
            hoja.Cell(4, 2).Value = "Unidad";
            hoja.Range(4, 1, 4, 2).Style.Font.Bold = true;

            for (int i = 0; i < proveedores.Count; i++)
            {
                IXLCell celdaEncabezado = hoja.Cell(4, 3 + i);
                celdaEncabezado.Value = proveedores[i].Nombre;
                celdaEncabezado.Style.Font.Bold = true;
                celdaEncabezado.Style.Fill.BackgroundColor = GetColorProveedor(i);
            }

            Dictionary<int, DetallePresupuesto> insumos = new Dictionary<int, DetallePresupuesto>();
            Dictionary<int, Dictionary<int, decimal>> precios =
                new Dictionary<int, Dictionary<int, decimal>>();

            // Los presupuestos vienen ordenados por fecha ascendente: la última asignación
            // para un insumo/proveedor deja el presupuesto más reciente.
            foreach (Presupuesto presupuesto in presupuestos)
            {
                if (!columnasProveedor.ContainsKey(presupuesto.IdProveedor)) continue;

                foreach (DetallePresupuesto detalle in presupuesto.Detalles)
                {
                    insumos[detalle.IdInsumo] = detalle;

                    Dictionary<int, decimal> preciosInsumo;
                    if (!precios.TryGetValue(detalle.IdInsumo, out preciosInsumo))
                    {
                        preciosInsumo = new Dictionary<int, decimal>();
                        precios[detalle.IdInsumo] = preciosInsumo;
                    }
                    preciosInsumo[presupuesto.IdProveedor] = detalle.PrecioUnitario;
                }
            }

            if (insumos.Count == 0)
            {
                hoja.Cell(5, 1).Value = "Sin detalle de insumos para el período.";
                hoja.Columns().AdjustToContents();
                return;
            }

            List<int> idsInsumos = insumos.Keys.ToList();
            idsInsumos.Sort((a, b) => string.Compare(insumos[a].NombreInsumo,
                insumos[b].NombreInsumo, StringComparison.CurrentCultureIgnoreCase));

            int fila = 5;
            foreach (int idInsumo in idsInsumos)
            {
                DetallePresupuesto detalleReferencia = insumos[idInsumo];
                hoja.Cell(fila, 1).Value = detalleReferencia.NombreInsumo;
                hoja.Cell(fila, 2).Value = detalleReferencia.UnidadMedidaInsumo;

                Dictionary<int, decimal> preciosInsumo;
                bool tienePrecios = precios.TryGetValue(idInsumo, out preciosInsumo);

                decimal minimo = 0m;
                bool hayMinimo = false;
                if (tienePrecios)
                {
                    foreach (decimal precio in preciosInsumo.Values)
                    {
                        if (!hayMinimo || precio < minimo)
                        {
                            minimo = precio;
                            hayMinimo = true;
                        }
                    }
                }

                for (int i = 0; i < proveedores.Count; i++)
                {
                    int idProveedor = proveedores[i].IdProveedor;
                    IXLCell celda = hoja.Cell(fila, 3 + i);

                    decimal precio;
                    if (!tienePrecios || !preciosInsumo.TryGetValue(idProveedor, out precio)) continue;

                    celda.Value = precio;
                    celda.Style.NumberFormat.Format = "$#,##0.00";
                    celda.Style.Fill.BackgroundColor = GetColorProveedor(i);

                    if (hayMinimo && precio == minimo)
                    {
                        celda.Style.Fill.BackgroundColor = XLColor.FromHtml("#C6EFCE");
                        celda.Style.Font.FontColor = XLColor.FromHtml("#006100");
                        celda.Style.Font.Bold = true;
                    }
                }

                fila++;
            }

            hoja.Columns().AdjustToContents();
        }

        private XLColor GetColorProveedor(int indice)
        {
            return XLColor.FromHtml(ColoresProveedor[indice % ColoresProveedor.Length]);
        }

        private string GetNombreMes(int mes)
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

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex,
            System.Windows.Forms.ComboBoxStyle estilo = System.Windows.Forms.ComboBoxStyle.DropDown)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex, estilo);

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonFantasma(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(200, 30));
    }
}

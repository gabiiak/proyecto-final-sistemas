using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class UIJornadaLaboral : Form
    {
        private List<TandaProduccion> tandasJornada = new List<TandaProduccion>();
        private List<ResumenInsumoJornada> insumosJornada = new List<ResumenInsumoJornada>();
        private int idTandaSeleccionada = 0;
        private bool cargandoInicial = false;

        public UIJornadaLaboral()
        {
            InitializeComponent();

            ConfigurarLabel(this.lblTitulo, "Informe diario de producción", new Point(20, 16), new Size(500, 32));
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = UIStyles.TextoPrincipal;

            ConfigurarLabel(this.lblFecha, "Fecha de jornada", new Point(20, 62), new Size(180, 18));
            ConfigurarLabel(this.lblMensaje, "", new Point(360, 78), new Size(640, 54));

            ConfigurarBotonPrimario(this.btnFiltrar, "Filtrar", new Point(220, 78), 0);
            this.btnFiltrar.Size = new Size(120, 34);

            ConfigurarLabel(this.lblTandasTitulo, "Tandas terminadas", new Point(20, 145), new Size(300, 22));
            this.lblTandasTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTandasTitulo.ForeColor = UIStyles.TextoPrincipal;

            ConfigurarLabel(this.lblInsumosTitulo, "Insumos consumidos en la jornada", new Point(20, 395), new Size(400, 22));
            this.lblInsumosTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblInsumosTitulo.ForeColor = UIStyles.TextoPrincipal;

            ConfigurarLabel(this.lblTandasKey, "Tandas:", new Point(16, 20), new Size(180, 18));
            ConfigurarLabelValor(this.lblTandasValor, new Point(16, 40));
            this.lblTandasValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTandasValor.Size = new Size(120, 30);

            ConfigurarLabel(this.lblProductosKey, "Productos fabricados:", new Point(16, 84), new Size(200, 18));
            ConfigurarLabelValor(this.lblProductosValor, new Point(16, 104));
            this.lblProductosValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblProductosValor.Size = new Size(120, 30);

            ConfigurarLabel(this.lblEmpleadoKey, "Empleado a cargo", new Point(16, 150), new Size(268, 18));
            ConfigurarTextBox(this.txtEmpleadoACargo, new Point(16, 170), new Size(268, 28), 1);

            ConfigurarBotonSecundario(this.btnVerDetalle, "Ver detalle", new Point(16, 230), 2);
            this.btnVerDetalle.Size = new Size(268, 36);

            ConfigurarBotonPrimario(this.btnGenerarPdf, "Generar PDF", new Point(16, 276), 3);
            this.btnGenerarPdf.Size = new Size(268, 36);

            ConfigurarBotonSecundario(this.btnCerrar, "Cerrar", new Point(16, 322), 4);
            this.btnCerrar.Size = new Size(268, 36);

            UIStyles.AplicarTemaAForm(this);
        }

        private void UIJornadaLaboral_Load(object sender, EventArgs e)
        {
            this.cargandoInicial = true;
            try
            {
                this.dtpFecha.Value = DateTime.Today;
            }
            finally
            {
                this.cargandoInicial = false;
            }

            this.txtEmpleadoACargo.Text = string.Empty;
            LimpiarJornada();
            MostrarMensaje("Seleccione una fecha y presione Filtrar.", false);
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (this.cargandoInicial)
            {
                return;
            }

            LimpiarJornada();
            MostrarMensaje("Seleccione una fecha y presione Filtrar.", false);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fecha = this.dtpFecha.Value.Date;

            try
            {
                List<TandaProduccion> tandas = NTandaProduccion.ObtenerTandasTerminadasPorFecha(fecha);
                List<ResumenInsumoJornada> insumos = NTandaProduccion.ObtenerInsumosAgregadosPorFecha(fecha);

                if (tandas.Count == 0)
                {
                    LimpiarJornada();
                    MostrarMensaje("No hay información disponible para la fecha seleccionada.", true);
                    return;
                }

                this.tandasJornada = tandas;
                this.insumosJornada = insumos;

                CargarGrillas();
                ActualizarTotales();
                MostrarMensaje(string.Empty, false);
                this.btnGenerarPdf.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                LimpiarJornada();
                MostrarMensaje(ex.Message, true);
            }
            catch (Exception ex)
            {
                LimpiarJornada();
                MostrarMensaje(string.Empty, false);
                MessageBox.Show("Error al consultar la jornada: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillas()
        {
            this.dgvTandas.Rows.Clear();
            foreach (TandaProduccion tanda in this.tandasJornada)
            {
                string caducidad = tanda.FechaCaducidad == DateTime.MinValue
                    ? "-"
                    : tanda.FechaCaducidad.ToString("dd-MM-yyyy");

                this.dgvTandas.Rows.Add(
                    tanda.IdTanda,
                    tanda.Hora.ToString("HH:mm:ss"),
                    tanda.Producto != null ? tanda.Producto.Nombre : "N/A",
                    tanda.CantidadProducida,
                    caducidad);
            }

            this.dgvInsumos.Rows.Clear();
            foreach (ResumenInsumoJornada insumo in this.insumosJornada)
            {
                this.dgvInsumos.Rows.Add(
                    insumo.NombreInsumo,
                    insumo.UnidadMedida,
                    insumo.CantidadTotal.ToString("N2"));
            }
        }

        private void ActualizarTotales()
        {
            int totalProductos = this.tandasJornada.Sum(t => t.CantidadProducida);
            this.lblTandasValor.Text = this.tandasJornada.Count.ToString();
            this.lblProductosValor.Text = totalProductos.ToString();
        }

        private void LimpiarJornada()
        {
            this.tandasJornada = new List<TandaProduccion>();
            this.insumosJornada = new List<ResumenInsumoJornada>();
            this.idTandaSeleccionada = 0;
            this.dgvTandas.Rows.Clear();
            this.dgvInsumos.Rows.Clear();
            this.lblTandasValor.Text = "0";
            this.lblProductosValor.Text = "0";
            this.btnGenerarPdf.Enabled = false;
        }

        private void MostrarMensaje(string mensaje, bool esError)
        {
            this.lblMensaje.Text = mensaje;
            this.lblMensaje.ForeColor = esError
                ? System.Drawing.Color.FromArgb(192, 0, 0)
                : UIStyles.GrisTexto;
        }

        private void dgvTandas_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvTandas.CurrentRow == null)
            {
                this.idTandaSeleccionada = 0;
                return;
            }

            object valor = this.dgvTandas.CurrentRow.Cells["IdTanda"].Value;
            int id;
            this.idTandaSeleccionada = valor != null && int.TryParse(valor.ToString(), out id) ? id : 0;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (this.idTandaSeleccionada <= 0)
            {
                MessageBox.Show("Debe seleccionar una tanda de la lista.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UIConsultarTanda consulta = new UIConsultarTanda(this.idTandaSeleccionada);
            consulta.ShowDialog(this);
        }

        private void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            GenerarPdfJornada();
        }

        private void GenerarPdfJornada()
        {
            if (this.tandasJornada.Count == 0)
            {
                MessageBox.Show("No hay información para exportar.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PDF|*.pdf";
            dialog.FileName = "InformeProduccion_" + this.dtpFecha.Value.ToString("yyyy-MM-dd") + ".pdf";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                string empleado = string.IsNullOrWhiteSpace(this.txtEmpleadoACargo.Text)
                    ? "Sin asignar"
                    : this.txtEmpleadoACargo.Text.Trim();
                int totalProductos = this.tandasJornada.Sum(t => t.CantidadProducida);

                using (PdfWriter writer = new PdfWriter(dialog.FileName))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document doc = new Document(pdf))
                {
                    doc.Add(new Paragraph("INFORME DIARIO DE PRODUCCIÓN")
                        .SetFontSize(16)
                        .SetFontColor(ColorConstants.BLACK));

                    doc.Add(new Paragraph("Fecha: " + this.dtpFecha.Value.ToString("dd-MM-yyyy"))
                        .SetFontSize(10)
                        .SetFontColor(ColorConstants.BLACK));
                    doc.Add(new Paragraph("Empleado a cargo: " + empleado)
                        .SetFontSize(10)
                        .SetFontColor(ColorConstants.BLACK));
                    doc.Add(new Paragraph("Cantidad de tandas: " + this.tandasJornada.Count)
                        .SetFontSize(10)
                        .SetFontColor(ColorConstants.BLACK));
                    doc.Add(new Paragraph("Total de productos fabricados: " + totalProductos)
                        .SetFontSize(10)
                        .SetFontColor(ColorConstants.BLACK));

                    doc.Add(new Paragraph("TANDAS")
                        .SetFontSize(12)
                        .SetFontColor(ColorConstants.BLACK)
                        .SetMarginTop(15f));

                    Table tablaTandas = new Table(UnitValue.CreatePercentArray(new float[] { 10f, 15f, 40f, 15f, 20f }))
                        .SetWidth(UnitValue.CreatePercentValue(100));

                    AgregarEncabezado(tablaTandas, "ID");
                    AgregarEncabezado(tablaTandas, "Hora");
                    AgregarEncabezado(tablaTandas, "Producto");
                    AgregarEncabezado(tablaTandas, "Cantidad");
                    AgregarEncabezado(tablaTandas, "Caducidad");

                    foreach (TandaProduccion tanda in this.tandasJornada)
                    {
                        string caducidad = tanda.FechaCaducidad == DateTime.MinValue
                            ? "-"
                            : tanda.FechaCaducidad.ToString("dd-MM-yyyy");

                        AgregarCelda(tablaTandas, tanda.IdTanda.ToString());
                        AgregarCelda(tablaTandas, tanda.Hora.ToString("HH:mm:ss"));
                        AgregarCelda(tablaTandas, tanda.Producto != null ? tanda.Producto.Nombre : "N/A");
                        AgregarCelda(tablaTandas, tanda.CantidadProducida.ToString());
                        AgregarCelda(tablaTandas, caducidad);
                    }

                    doc.Add(tablaTandas);

                    doc.Add(new Paragraph("INSUMOS UTILIZADOS")
                        .SetFontSize(12)
                        .SetFontColor(ColorConstants.BLACK)
                        .SetMarginTop(15f));

                    if (this.insumosJornada.Count == 0)
                    {
                        doc.Add(new Paragraph("Sin insumos registrados.")
                            .SetFontSize(10)
                            .SetFontColor(ColorConstants.BLACK));
                    }
                    else
                    {
                        Table tablaInsumos = new Table(UnitValue.CreatePercentArray(new float[] { 50f, 25f, 25f }))
                            .SetWidth(UnitValue.CreatePercentValue(100));

                        AgregarEncabezado(tablaInsumos, "Insumo");
                        AgregarEncabezado(tablaInsumos, "Unidad de medida");
                        AgregarEncabezado(tablaInsumos, "Cantidad total");

                        foreach (ResumenInsumoJornada insumo in this.insumosJornada)
                        {
                            AgregarCelda(tablaInsumos, insumo.NombreInsumo);
                            AgregarCelda(tablaInsumos, insumo.UnidadMedida);
                            AgregarCelda(tablaInsumos, insumo.CantidadTotal.ToString("N2"));
                        }

                        doc.Add(tablaInsumos);
                    }
                }

                MessageBox.Show("Informe PDF generado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void AgregarEncabezado(Table tabla, string texto)
        {
            Cell celda = new Cell()
                .Add(new Paragraph(texto).SetFontSize(9).SetFontColor(ColorConstants.BLACK))
                .SetPadding(4f)
                .SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f));
            tabla.AddHeaderCell(celda);
        }

        private static void AgregarCelda(Table tabla, string texto)
        {
            Cell celda = new Cell()
                .Add(new Paragraph(texto).SetFontSize(9).SetFontColor(ColorConstants.BLACK))
                .SetPadding(4f)
                .SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f));
            tabla.AddCell(celda);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto, Point ubicacion, Size tamanio)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, tamanio);

        private void ConfigurarLabelValor(System.Windows.Forms.Label lbl, Point ubicacion)
            => UIStyles.ConfigurarLabelValor(lbl, ubicacion);

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt, Point ubicacion, Size tamanio, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamanio, tabIndex);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto, Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex);

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto, Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex);
    }
}

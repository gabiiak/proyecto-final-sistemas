using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using Negocio;

namespace Login
{
    public partial class UIRecomendacionIA : Form
    {
        private CartesianChart graficoRecomendacionIA;
        public UIRecomendacionIA()
        {
            InitializeComponent();

            this.Load += UIRecomendacionIA_Load;
        }

        private void CrearGraficoRecomendacion(
            List<ResultadoRecomendacionIA> resultados)
        {
            bool oscuro = UIStyles.TemaActual == Tema.Oscuro;

            Color fondo = oscuro
                ? Color.FromArgb(40, 47, 59)
                : Color.White;

            SKColor colorTexto = oscuro
                ? new SKColor(226, 232, 240)
                : new SKColor(90, 100, 115);

            string[] nombres = resultados
                .Select(p => p.NombreProveedor)
                .ToArray();

            double[] estimaciones = resultados
                .Select(p => p.EstimacionCumplimiento)
                .ToArray();
            double maximoEstimado = estimaciones.Length > 0
                ? estimaciones.Max()
                : 0;

            // dejamos un margen superior del 20 %
            double limiteSuperior = maximoEstimado > 0
                ? maximoEstimado * 1.20
                : 1;

            graficoRecomendacionIA = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = fondo,

                Series = new ISeries[]
                {
            new ColumnSeries<double>
            {
                Name = "Estimación experimental",
                Values = estimaciones,

                Fill = new SolidColorPaint(
                    new SKColor(55, 138, 221)),

                Rx = 6,
                Ry = 6,
                DataLabelsFormatter = punto =>
                    punto.Coordinate.PrimaryValue.ToString("F2") + "%",
            }
                },

                XAxes = new[]
                {
            new Axis
            {
                Labels = nombres,
                LabelsPaint =
                    new SolidColorPaint(colorTexto)
            }
        },



                YAxes = new[]
                {
                    new Axis
                    {
                        MinLimit = 0,
                        MaxLimit = limiteSuperior,
                        Labeler = valor =>
                            valor.ToString("F2") + "%",
                        LabelsPaint =
                            new SolidColorPaint(colorTexto)
                    }
                }

            };

            pnlGraficoRecomendacionIA.Controls.Clear();
            pnlGraficoRecomendacionIA.Controls.Add(graficoRecomendacionIA);
        }

        private void AplicarTemaRecomendacion()
        {
            bool oscuro = UIStyles.TemaActual == Tema.Oscuro;

            Color fondo = oscuro
                ? Color.FromArgb(32, 38, 48)
                : Color.FromArgb(244, 247, 251);

            Color tarjeta = oscuro
                ? Color.FromArgb(40, 47, 59)
                : Color.White;

            Color texto = oscuro
                ? Color.FromArgb(226, 232, 240)
                : Color.FromArgb(28, 58, 94);

            Color secundario = oscuro
                ? Color.FromArgb(180, 190, 205)
                : Color.FromArgb(90, 100, 115);

            this.BackColor = fondo;

            lblTituloRecomendacion.ForeColor = texto;
            lblProveedorSugerido.ForeColor = texto;
            lblDetalleRecomendacion.ForeColor = secundario;
            lblAvisoIA.ForeColor = secundario;

            pnlGraficoRecomendacionIA.BackColor = tarjeta;

            // Aplicamos los colores de la tabla utilizando
            // el método que ya tiene Gabriel.
            UIStyles.ConfigurarDataGrid(dgvRecomendacionesIA);

            if (graficoRecomendacionIA != null)
            {
                graficoRecomendacionIA.BackColor = tarjeta;

                SKColor colorTexto = oscuro
                    ? new SKColor(226, 232, 240)
                    : new SKColor(90, 100, 115);

                graficoRecomendacionIA.XAxes = new[]
                {
            new Axis
            {
                Labels = dgvRecomendacionesIA.Rows
                    .Cast<DataGridViewRow>()
                    .Where(fila => !fila.IsNewRow)
                    .Select(fila =>
                        Convert.ToString(
                            fila.Cells["Proveedor"].Value))
                    .ToArray(),

                LabelsPaint =
                    new SolidColorPaint(colorTexto)
            }
        };
            }
        }

        private void UIStyles_TemaCambiado(object sender, EventArgs e)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            BeginInvoke(new Action(() =>
            {
                if (!IsDisposed)
                    AplicarTemaRecomendacion();
            }));
        }



        private void UIRecomendacionIA_Load(
            object sender, EventArgs e)
        {
            try
            {

                
                // consultamos SQL Server y ejecutamos ML.NET
                //el numero indica los dias de plazo que se quieren evaluar, en este caso 5 dias
                var resultados =
                    NRecomendacionIA.RecomendarProveedores(5);


                if (resultados.Count == 0)
                {
                    lblProveedorSugerido.Text =
                        "Proveedor sugerido: Sin datos suficientes";

                    lblDetalleRecomendacion.Text =
                        "No hay proveedores con al menos " +
                        "3 entregas evaluables para generar una comparación.";

                    lblAvisoIA.Text =
                        "No se generó ninguna predicción. " +
                        "Se necesitan más datos históricos.";

                    return;
                }


                // la lista ya viene ordenada por estimación
                var mejor = resultados.First();

                lblProveedorSugerido.Text =
                    "Mayor estimación experimental: " +
                    mejor.NombreProveedor;


                lblDetalleRecomendacion.Text =
                    "Estimación experimental: " +
                    mejor.EstimacionCumplimiento.ToString("F1") +
                    "% | Entregas evaluadas: " +
                    mejor.EntregasEvaluadas +
                    " | Cumplimiento histórico: " +
                    mejor.CumplimientoHistorico.ToString("F1") +
                    "% | Predicción no concluyente.";


                // mostramos todos los proveedores evaluables
                dgvRecomendacionesIA.DataSource = null;

                dgvRecomendacionesIA.DataSource =
                    resultados.Select(p => new
                    {
                        Proveedor = p.NombreProveedor,

                        Estimacion =
                            p.EstimacionCumplimiento.ToString("F1")
                            + "%",

                        Entregas = p.EntregasEvaluadas,

                        Historial =
                            p.CumplimientoHistorico.ToString("F1")
                            + "%",

                        Calidad = p.CalidadPromedio.HasValue
                            ? p.CalidadPromedio.Value.ToString("F1")
                                + "/5"
                            : "Sin evaluar"
                    }).ToList();

                dgvRecomendacionesIA.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvRecomendacionesIA.ReadOnly = true;
                dgvRecomendacionesIA.AllowUserToAddRows = false;
                CrearGraficoRecomendacion(resultados);
                AplicarTemaRecomendacion();

                lblAvisoIA.Text =
                    "Predicción experimental con datos históricos. " +
                    "El modelo aún no está validado para decisiones comerciales.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo generar la recomendación: " +
                    ex.Message,
                    "Recomendación IA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}


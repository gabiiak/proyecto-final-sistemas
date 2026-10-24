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



namespace Login
{
    public partial class UIResultadosIA : Form
    {
        private CartesianChart graficoComparacionIA;

        public UIResultadosIA(Negocio.ResultadoPruebaIA resultado,bool datosReales = false)

        {
            InitializeComponent();
            AplicarTemaResultados();
            CrearGraficoComparacion(resultado);

            lblEntrenamiento.Text =
                "Registros usados para entrenar: " +
                resultado.RegistrosEntrenamiento;

            lblPrueba.Text =
                "Registros usados para probar: " +
                resultado.RegistrosPrueba;

            lblAciertos.Text =
                "Porcentaje de aciertos: " +
                resultado.PorcentajeAciertos.ToString("P2");

            lblDistincion.Text =
                "Capacidad para distinguir entregas puntuales: " +
                resultado.CapacidadDistincion.ToString("F3");

            lblEquilibrio.Text =
                "Equilibrio entre precisión y detección: " +
                resultado.EquilibrioGeneral.ToString("F3");

            lblReferencia.Text =
                "Referencia básica de comparación: " +
                resultado.ReferenciaBasica.ToString("P2");

            lblConclusion.Text =
                "Conclusión: " + resultado.Conclusion;

            lblNota.Text = datosReales? "Evaluación experimental con datos reales. " + "Muestra pequeña: resultados no concluyentes.": "Resultados obtenidos con datos simulados.";

            btnCerrar.Click += (s, e) => this.Close();

            UIStyles.TemaCambiado += UIStyles_TemaCambiado;

            this.FormClosed += (s, e) =>
            {
                UIStyles.TemaCambiado -= UIStyles_TemaCambiado;
            };

        }

        private void CrearGraficoComparacion(
            Negocio.ResultadoPruebaIA resultado)
        {
            // convertimos los resultados a porcentajes.
            double exactitudIA = resultado.PorcentajeAciertos * 100;
            double referencia = resultado.ReferenciaBasica * 100;

            bool oscuro = UIStyles.TemaActual == Tema.Oscuro;

            Color fondo = oscuro
                ? Color.FromArgb(40, 47, 59)
                : Color.White;

            SKColor colorTexto = oscuro
                ? new SKColor(226, 232, 240)
                : new SKColor(90, 100, 115);

            graficoComparacionIA = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = fondo,

                Series = new ISeries[]
                {
            new ColumnSeries<double>
            {
                Name = "Porcentaje de aciertos",

                Values = new double[]
                {
                    referencia,
                    exactitudIA
                },

                Fill = new SolidColorPaint(
                    new SKColor(55, 138, 221)),

                Rx = 8,
                Ry = 8
            }
                },

                XAxes = new[]
                {
            new Axis
            {
                Labels = new[]
                {
                    "Referencia básica",
                    "Modelo ML.NET"
                },

                LabelsPaint =
                    new SolidColorPaint(colorTexto)
            }
        },

                YAxes = new[]
                {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 100,

                Labeler = valor =>
                    valor.ToString("F0") + "%",

                LabelsPaint =
                    new SolidColorPaint(colorTexto)
            }
        }
            };

            
            Panel contenedor = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15, 55, 15, 15),
                BackColor = fondo
            };

            contenedor.Controls.Add(graficoComparacionIA);

            pnlGraficoResultadosIA.Controls.Add(contenedor);

            lblTituloGraficoResultadosIA.BringToFront();
        }



        private void AplicarTemaResultados()
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

            AplicarTemaAControles(this, tarjeta, texto, secundario);

            
            if (graficoComparacionIA != null)
            {
                SKColor colorEjes = oscuro
                    ? new SKColor(226, 232, 240)
                    : new SKColor(90, 100, 115);

                graficoComparacionIA.BackColor = tarjeta;

                if (graficoComparacionIA.Parent != null)
                    graficoComparacionIA.Parent.BackColor = tarjeta;

                graficoComparacionIA.XAxes = new[]
                {
            new Axis
            {
                Labels = new[]
                {
                    "Referencia básica",
                    "Modelo ML.NET"
                },
                LabelsPaint = new SolidColorPaint(colorEjes)
            }
        };

                graficoComparacionIA.YAxes = new[]
                {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 100,
                Labeler = valor => valor.ToString("F0") + "%",
                LabelsPaint = new SolidColorPaint(colorEjes)
            }
        };
            }
        }


        private void AplicarTemaAControles(
            Control contenedor,
            Color tarjeta,
            Color texto,
            Color secundario)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is Panel panel)
                {
                    panel.BackColor = tarjeta;
                }

                if (control is Label etiqueta)
                {
                    etiqueta.ForeColor = etiqueta.Font.Bold
                        ? texto
                        : secundario;
                }

                if (control.HasChildren)
                {
                    AplicarTemaAControles(
                        control, tarjeta, texto, secundario);
                }
            }
        }

        private void UIStyles_TemaCambiado(object sender, EventArgs e)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            BeginInvoke(new Action(() =>
            {
                if (!IsDisposed)
                    AplicarTemaResultados();
            }));
        }

    }

}


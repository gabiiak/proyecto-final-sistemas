using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Negocio;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class UIInicio1 : Form
    {
        // ── PALETA ──────────────────────────────────────────
        private readonly Color ColorFondo = Color.FromArgb(244, 247, 251);
        private readonly Color ColorCard = Color.White;
        private readonly Color ColorBorde = Color.FromArgb(211, 209, 199);
        private readonly Color ColorTitulo = Color.FromArgb(28, 58, 94);
        private readonly Color ColorMuted = Color.FromArgb(136, 135, 128);
        private readonly Color ColorAzulPrimary = Color.FromArgb(55, 138, 221);
        public UIInicio1()
        {
            InitializeComponent();
            this.BackColor = ColorFondo;
            this.Padding = new Padding(20);
            ConstruirDashboard();
        }

        private void ConstruirDashboard()
        {
            // ── LAYOUT PRINCIPAL ────────────────────────────
            // Fila superior: cartesiano ocupa todo el ancho
            // Fila inferior: torta a la izquierda, barras a la derecha

            var layoutPrincipal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent,
                Padding = new Padding(0),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            var layoutInferior = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };
            layoutInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // ── CARDS ────────────────────────────────────────
            //var cardCartesiano = CrearCard("Ventas por semestre");
            var cardCartesiano = CrearCard("Ventas Mensuales");
            var cardTorta = CrearCard("Productos más vendidos");
            var cardBarras = CrearCard("Ventas por cliente");

            // ── GRÁFICOS ─────────────────────────────────────
            AgregarGraficoACard(cardCartesiano, CrearCartesiano());
            AgregarGraficoACard(cardTorta, CrearTorta());
            AgregarGraficoACard(cardBarras, CrearBarras());

            // ── ENSAMBLADO ───────────────────────────────────
            layoutInferior.Controls.Add(cardTorta, 0, 0);
            layoutInferior.Controls.Add(cardBarras, 1, 0);

            layoutPrincipal.Controls.Add(cardCartesiano, 0, 0);
            layoutPrincipal.Controls.Add(layoutInferior, 0, 1);

            this.Controls.Add(layoutPrincipal);
        }

        // ── FACTORY DE CARDS ────────────────────────────────
        private Panel CrearCard(string titulo)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ColorCard,
                Margin = new Padding(8),
                Padding = new Padding(16)
            };

            // Borde redondeado simulado con Paint
            //card.Paint += (s, e) =>
            //{
            //    var g = e.Graphics;
            //    var pen = new Pen(ColorBorde, 1f);
            //    var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
            //    int r = 8;
            //    var path = new System.Drawing.Drawing2D.GraphicsPath();
            //    path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
            //    path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
            //    path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
            //    path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
            //    path.CloseFigure();
            //    g.DrawPath(pen, path);
            //};

            var lblTitulo = new Label
            {
                Text = titulo,
                ForeColor = ColorTitulo,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30
            };

            var pnlGrafico = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            pnlGrafico.Name = "pnlGrafico";

            card.Controls.Add(pnlGrafico);
            card.Controls.Add(lblTitulo);

            return card;
        }

        // Helper para obtener el panel del gráfico dentro de la card
        private void AgregarGraficoACard(Panel card, Control grafico)
        {
            var pnl = card.Controls["pnlGrafico"] as Panel;
            if (pnl == null) return;
            grafico.Dock = DockStyle.Fill;
            pnl.Controls.Add(grafico); //aprender que hace controls.
        }

        // ── GRÁFICO DE LÍNEA — Ventas por mes ───────────────
        private CartesianChart CrearCartesiano()
        {
            //para usar datos de ventas por semestres
            //var datos = NVentas.GetVentasPorMesSemestre();
            var datos = NVentas.GetVentasPorMesAnio();
            string[] nombresMeses = { "", "Ene", "Feb", "Mar", "Abr", "May", "Jun",
                                   "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

            var meses = datos.Keys.OrderBy(m => m).Select(m => nombresMeses[m]).ToArray();
            var valores = datos.Keys.OrderBy(m => m).Select(m => datos[m]).ToArray();

            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = ColorCard,
                Series = new ISeries[]
                {
            new LineSeries<double>
            {
                Values         = valores,
                Name           = "Ventas",
                Stroke         = new SolidColorPaint(new SKColor(55, 138, 221), 3),
                Fill           = new SolidColorPaint(new SKColor(55, 138, 221, 40)),
                GeometrySize   = 8,
                GeometryStroke = new SolidColorPaint(new SKColor(55, 138, 221), 2),
                GeometryFill   = new SolidColorPaint(SKColors.White),
            }
                },
                XAxes = new[]
                {
            new Axis
            {
                Labels      = meses,
                LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
                TicksPaint  = new SolidColorPaint(new SKColor(211, 209, 199)),
            }
        },
                YAxes = new[]
                {
            new Axis
            {
                LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
                Labeler     = val => $"${val:N0}",
                TicksPaint  = new SolidColorPaint(new SKColor(211, 209, 199)),
            }
        }
            };


            return chart;
        }

        // ── GRÁFICO DE TORTA — Productos más vendidos ───────
        private PieChart CrearTorta()
        {
            var datos = NDetalleVentas.GetProductosMasVendidos();

            // paleta azul consistente con el resto del dashboard
            var colores = new[]
            {
        new SKColor(55, 138, 221),
        new SKColor(24, 95, 165),
        new SKColor(181, 212, 244),
        new SKColor(211, 209, 199)
    };

            var series = new List<ISeries>();
            for (int i = 0; i < datos.Count; i++)
            {
                series.Add(new PieSeries<double>
                {
                    Values = new double[] { datos[i].Cantidad },
                    Name = datos[i].Nombre,
                    Fill = new SolidColorPaint(colores[i % colores.Length])
                });
            }

            // si no hay datos, mostrar un placeholder
            if (series.Count == 0)
            {
                series.Add(new PieSeries<double>
                {
                    Values = new double[] { 1 },
                    Name = "Sin datos",
                    Fill = new SolidColorPaint(new SKColor(211, 209, 199))
                });
            }

            var chart = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = ColorCard,
                Series = series
            };

            return chart;
        }

        // ── GRÁFICO DE BARRAS — top de clientes jijiji ───────────
        private CartesianChart CrearBarras()
        {
            var datos = NVentas.GetTopClientesPorMonto();

            string[] nombres = datos.Select(d => d.Nombre).ToArray();
            double[] montos = datos.Select(d => d.Total).ToArray();

            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = ColorCard,
                Series = new ISeries[]
                {
            new ColumnSeries<double>
            {
                Values = montos.Length > 0 ? montos : new double[] { 0 },
                Name   = "Facturado",
                Fill   = new SolidColorPaint(new SKColor(55, 138, 221)),
                Rx     = 4,
                Ry     = 4,
            }
                },
                XAxes = new[]
                {
            new Axis
            {
                Labels      = nombres.Length > 0 ? nombres : new[] { "Sin datos" },
                LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
                TicksPaint  = new SolidColorPaint(new SKColor(211, 209, 199)),
            }
        },
                YAxes = new[]
                {
            new Axis
            {
                LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
                Labeler     = val => $"${val:N0}",
                TicksPaint  = new SolidColorPaint(new SKColor(211, 209, 199)),
            }
        }
            };

            return chart; 
        }
        private void UIInicio1_Load(object sender, EventArgs e)
        {

        }
    }
}

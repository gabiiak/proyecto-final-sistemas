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
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

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
            var cardCartesiano = CrearCard("Ventas por mes");
            var cardTorta = CrearCard("Productos más vendidos");
            var cardBarras = CrearCard("Estado de pedidos");

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
            card.Paint += (s, e) =>
            {
                var g = e.Graphics;
                var pen = new Pen(ColorBorde, 1f);
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                int r = 8;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
                path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
                path.CloseFigure();
                g.DrawPath(pen, path);
            };

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
            var meses = new[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun" };

            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = ColorCard,
                Series = new ISeries[]
                {
                new LineSeries<double>
                {
                    Values        = new double[] { 12500, 18200, 15800, 22400, 19600, 27300 },
                    Name          = "Ventas",
                    Stroke        = new SolidColorPaint(new SKColor(55, 138, 221), 3),
                    Fill          = new SolidColorPaint(new SKColor(55, 138, 221, 40)),
                    GeometrySize  = 8,
                    GeometryStroke = new SolidColorPaint(new SKColor(55, 138, 221), 2),
                    GeometryFill  = new SolidColorPaint(SKColors.White),
                }
                },
                XAxes = new[]
                {
                new Axis
                {
                    Labels     = meses,
                    LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
                    TicksPaint  = new SolidColorPaint(new SKColor(211, 209, 199)),
                }
            },
                YAxes = new[]
                {
                new Axis
                {
                    LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
                    Labeler     = val => $"${val:N0}", //aprender esto
                    TicksPaint  = new SolidColorPaint(new SKColor(211, 209, 199)),
                }
            }
            };

            return chart;
        }

        // ── GRÁFICO DE TORTA — Productos más vendidos ───────
        private PieChart CrearTorta()
        {
            var chart = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = ColorCard,
                Series = new ISeries[]
                {
                new PieSeries<double>
                {
                    Values = new double[] { 40 },
                    Name   = "Insertar",
                    Fill   = new SolidColorPaint(new SKColor(55, 138, 221)),
                },
                new PieSeries<double>
                {
                    Values = new double[] { 30 },
                    Name   = "Insertar",
                    Fill   = new SolidColorPaint(new SKColor(24, 95, 165)),
                },
                new PieSeries<double>
                {
                    Values = new double[] { 20 },
                    Name   = "Insertar",
                    Fill   = new SolidColorPaint(new SKColor(181, 212, 244)),
                },
                new PieSeries<double>
                {
                    Values = new double[] { 10 },
                    Name   = "Insertar",
                    Fill   = new SolidColorPaint(new SKColor(211, 209, 199)),
                },
                }
            };

            return chart;
        }

        // ── GRÁFICO DE BARRAS — Estado de pedidos ───────────
        private CartesianChart CrearBarras()
        {
            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = ColorCard,
                Series = new ISeries[]
                {
                new ColumnSeries<double>
                {
                    Values = new double[] { 14, 8, 23 },
                    Name   = "Pedidos",
                    Fill   = new SolidColorPaint(new SKColor(55, 138, 221)),
                    Rx     = 4,
                    Ry     = 4,
                }
                },
                XAxes = new[]
                {
                new Axis
                {
                    Labels      = new[] { "Pendiente", "En proceso", "Completado" },
                    LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
                    TicksPaint  = new SolidColorPaint(new SKColor(211, 209, 199)),
                }
            },
                YAxes = new[]
                {
                new Axis
                {
                    LabelsPaint = new SolidColorPaint(new SKColor(136, 135, 128)),
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

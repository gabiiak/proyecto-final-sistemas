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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace Login
{
    public partial class UIEvaluacionProveedor : Form
    {
        private List<Compra> listaCompras = new List<Compra>();
        private List<Proveedor> listaProveedores = new List<Proveedor>();
        private PieChart graficoPuntualidad;


        public UIEvaluacionProveedor()
        {
            InitializeComponent();
            CrearGraficoPuntualidad();
            UIStyles.TemaCambiado += UIStyles_TemaCambiado;

            this.FormClosed += (s, e) =>
            {
                UIStyles.TemaCambiado -= UIStyles_TemaCambiado;
            };

            cmbCalidad.Items.Clear();
            cmbCalidad.Items.Add("Sin evaluar");
            cmbCalidad.Items.Add("1 - Muy mala");
            cmbCalidad.Items.Add("2 - Mala");
            cmbCalidad.Items.Add("3 - Regular");
            cmbCalidad.Items.Add("4 - Buena");
            cmbCalidad.Items.Add("5 - Excelente");
            cmbCalidad.SelectedIndex = 0;

            this.Load += UIEvaluacionProveedor_Load;
            cmbCompras.SelectedIndexChanged += cmbCompras_SelectedIndexChanged;
            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnProbarIA.Click += btnProbarIA_Click;
            btnAnalizarProveedores.Click += btnAnalizarProveedores_Click;
            dgvEvaluaciones.CellClick += dgvEvaluaciones_CellClick;
            btnRecomendacionIA.Click += btnRecomendacionIA_Click;

        }


        private void ActualizarGraficoPuntualidad()
        {
            var proveedores = NAnalisisProveedores.ObtenerResumenes();

            int puntuales = proveedores.Sum(p => p.EntregasPuntuales);
            int tardias = proveedores.Sum(p => p.EntregasTardias);

            bool oscuro = UIStyles.TemaActual == Tema.Oscuro;

            Color fondo = oscuro
                ? Color.FromArgb(40, 47, 59)
                : Color.White;

            graficoPuntualidad.BackColor = fondo;

            // Mismos azules utilizados en el dashboard de Inicio.
            var azulPrincipal = new SKColor(55, 138, 221);
            var azulSecundario = new SKColor(24, 95, 165);

            var series = new List<ISeries>();

            if (puntuales + tardias > 0)
            {
                if (puntuales > 0)
                {
                    series.Add(new PieSeries<double>
                    {
                        Name = "Puntuales",
                        Values = new double[] { puntuales },
                        Fill = new SolidColorPaint(azulPrincipal)
                    });
                }

                if (tardias > 0)
                {
                    series.Add(new PieSeries<double>
                    {
                        Name = "Tardías",
                        Values = new double[] { tardias },
                        Fill = new SolidColorPaint(azulSecundario)
                    });
                }
            }
            else
            {
                series.Add(new PieSeries<double>
                {
                    Name = "Sin datos evaluables",
                    Values = new double[] { 1 },
                    Fill = new SolidColorPaint(
                        new SKColor(211, 209, 199))
                });
            }

            graficoPuntualidad.Series = series;
        }




        private void UIEvaluacionProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCompras();
                CargarEvaluaciones();
                LimpiarCampos();
                AplicarColoresAsistenteIA();
                ActualizarGraficoPuntualidad();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }





        private void CargarCompras()
        {
            listaCompras = NCompras.GetAllCompras();
            listaProveedores = NProveedores.GetAll();

            var comprasParaMostrar = listaCompras.Select(c => new
            {
                Compra = c,
                Descripcion = "#" + c.IdCompra + " - " +
                    (listaProveedores.FirstOrDefault(
                        p => p.IdProveedor == c.IdProveedor)?.Nombre
                        ?? "Proveedor desconocido") +
                    " - " + c.Fecha.ToString("dd/MM/yyyy") +
                    " - " + ObtenerEstadoCompra(c.Estado)
            }).ToList();

            cmbCompras.DataSource = null;
            cmbCompras.DisplayMember = "Descripcion";
            cmbCompras.ValueMember = null;
            cmbCompras.DataSource = comprasParaMostrar;

            cmbCompras.SelectedIndex = -1;
        }


        private string ObtenerEstadoCompra(int estado)
        {
            switch (estado)
            {
                case EstadoCompra.Emitida:
                    return "EMITIDA";

                case EstadoCompra.Aceptada:
                    return "ACEPTADA";

                case EstadoCompra.Enviada:
                    return "ENVIADA";

                case EstadoCompra.Recibida:
                    return "RECIBIDA";

                case EstadoCompra.Cancelada:
                    return "CANCELADA";

                default:
                    return "DESCONOCIDO";
            }
        }





        private void cmbCompras_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            txtProveedor.Clear();
            txtObservaciones.Clear();
            cmbCalidad.SelectedIndex = 0;
            dtpFechaPrometida.Enabled = true;

            int indice = cmbCompras.SelectedIndex;

            if (indice < 0 || indice >= listaCompras.Count)
                return;

            Compra compra = listaCompras[indice];

            Proveedor proveedor = listaProveedores
                .FirstOrDefault(p => p.IdProveedor == compra.IdProveedor);

            if (proveedor != null)
                txtProveedor.Text = proveedor.Nombre;


            EvaluacionProveedor anterior =
                NEvaluacionProveedor.ObtenerEvaluaciones()
                .FirstOrDefault(ev => ev.IdCompra == compra.IdCompra);


            if (anterior != null)
            {
                dtpFechaPrometida.Value = anterior.FechaPrometida;
                dtpFechaPrometida.Enabled = false;

                cmbCalidad.SelectedIndex = anterior.Calidad ?? 0;

                txtObservaciones.Text = anterior.Observaciones ?? "";
            }

            cmbCalidad.Enabled = compra.Estado == EstadoCompra.Recibida;
        }



        private void CargarEvaluaciones()
        {
            var evaluaciones = NEvaluacionProveedor.ObtenerEvaluaciones();

            dgvEvaluaciones.DataSource = null;

            dgvEvaluaciones.DataSource = evaluaciones.Select(e => new
            {
                Compra = e.IdCompra,
                FechaPrometida = e.FechaPrometida,
                Calidad = e.Calidad,
                Observaciones = e.Observaciones
            }).ToList();
        }

        private void LimpiarCampos()
        {
            cmbCompras.SelectedIndex = -1;
            txtProveedor.Clear();

            dtpFechaPrometida.Enabled = true;
            dtpFechaPrometida.Value = DateTime.Today;

            cmbCalidad.SelectedIndex = 0;
            cmbCalidad.Enabled = false;

            txtObservaciones.Clear();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = cmbCompras.SelectedIndex;

                Compra compra = indice >= 0 && indice < listaCompras.Count
                    ? listaCompras[indice]
                    : null;

                if (compra == null)
                {
                    MessageBox.Show("Debe seleccionar una compra.");
                    return;
                }

                EvaluacionProveedor anterior =
                    NEvaluacionProveedor.ObtenerEvaluaciones()
                    .FirstOrDefault(x => x.IdCompra == compra.IdCompra);

                int? calidad = cmbCalidad.SelectedIndex > 0
                    ? (int?)cmbCalidad.SelectedIndex
                    : null;

                EvaluacionProveedor evaluacion = new EvaluacionProveedor
                {
                    IdCompra = compra.IdCompra,
                    FechaPrometida = anterior != null
                        ? anterior.FechaPrometida
                        : dtpFechaPrometida.Value.Date,
                    Calidad = calidad,
                    Observaciones = txtObservaciones.Text.Trim()
                };

                if (anterior == null)
                {
                    NEvaluacionProveedor.GuardarEvaluacion(evaluacion);
                }
                else
                {
                    NEvaluacionProveedor.ActualizarEvaluacion(evaluacion);
                }

                MessageBox.Show(
                    "Evaluación guardada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarEvaluaciones();
                LimpiarCampos();
                ActualizarGraficoPuntualidad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }




        private void btnProbarIA_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtenemos los registros reales de SQL Server.
                var datosReales = NDatosEntrenamientoReal.Obtener();

                if (datosReales.Count < 10)
                {
                    MessageBox.Show(
                        "Hay " + datosReales.Count +
                        " entregas evaluables.\n\n" +
                        "Se necesitan al menos 30 para comenzar " +
                        "la evaluación experimental.",
                        "Datos insuficientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                ModeloPredictivoProveedor modelo =
                    new ModeloPredictivoProveedor();

                ResultadoPruebaIA resultado =
                    modelo.EvaluarDatosReales(datosReales);

                using (UIResultadosIA ventana =
                    new UIResultadosIA(resultado, true))
                {
                    ventana.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Evaluación experimental con datos reales",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }






        private void btnAnalizarProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                var proveedores = NAnalisisProveedores.ObtenerResumenes();

                // solo consideramos proveedores con al menos
                // 3 entregas chekeables (pueden modificarlo a 1 para que sea mas facil chekear)
                var evaluables = proveedores
                    .Where(p => p.TotalEntregas >= 3)
                    .OrderByDescending(p => p.PorcentajeCumplimiento)
                    .ThenByDescending(p => p.PromedioCalidad ?? 0)
                    .ThenByDescending(p => p.TotalEntregas)
                    .ToList();

                if (evaluables.Count == 0)
                //este trocito de codigo sirve para que no aparezcan
                //datos viejos si el sistema no encuntra proveedores con suficientes datos
                {
                    lblValorEntregasIA.Text = "--";
                    lblValorPuntualidadIA.Text = "--";
                    lblValorCalidadIA.Text = "--";
                    lblProveedorRecomendado.Text =
                        "Proveedor recomendado: Sin datos suficientes";

                    lblProbabilidadIA.Text =
                        "Cumplimiento histórico: --";

                    lblExplicacionIA.Text =
                        "Todavía no hay proveedores con al menos " +
                        "3 entregas evaluables. Registrá más entregas " +
                        "y evaluaciones para realizar una comparación.";

                    return;
                }

                var mejor = evaluables.First();

                // actualizamos las tarjetas del proveedor destacado je

                lblValorEntregasIA.Text =
                    mejor.TotalEntregas.ToString();

                lblValorPuntualidadIA.Text =
                    mejor.PorcentajeCumplimiento.ToString("F1") + "%";

                lblValorCalidadIA.Text =
                    mejor.PromedioCalidad.HasValue
                        ? mejor.PromedioCalidad.Value.ToString("F1") + "/5"
                        : "Sin datos";


                lblProveedorRecomendado.Text =
                    "Proveedor destacado: " + mejor.NombreProveedor;

                lblProbabilidadIA.Text =
                    "Cumplimiento histórico: " +
                    mejor.PorcentajeCumplimiento.ToString("F2") + "%";

                string calidad = mejor.PromedioCalidad.HasValue
                    ? mejor.PromedioCalidad.Value.ToString("F1") + "/5"
                    : "Sin calificaciones";

                lblExplicacionIA.Text =
                    "Entregas evaluadas: " + mejor.TotalEntregas +
                    " | Puntuales: " + mejor.EntregasPuntuales +
                    " | Tardías: " + mejor.EntregasTardias +
                    " | Calidad promedio: " + calidad +
                    ". Resultado basado en el historial registrado.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al analizar proveedores: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvEvaluaciones_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvEvaluaciones.Rows[e.RowIndex];

            if (fila.Cells["Compra"].Value == null)
                return;

            int idCompra = Convert.ToInt32(
                fila.Cells["Compra"].Value);


            int indice = listaCompras.FindIndex(
                c => c.IdCompra == idCompra);

            if (indice < 0)
            {
                MessageBox.Show(
                    "No se encontró la compra seleccionada.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // seleccionamos la compra en el combobox
            cmbCompras.SelectedIndex = indice;
        }

        private void AplicarColoresAsistenteIA()
        {
            bool temaOscuro = UIStyles.TemaActual == Tema.Oscuro;

            Color colorTexto = temaOscuro
                ? Color.FromArgb(226, 232, 240)
                : Color.FromArgb(28, 58, 94);

            Color colorSecundario = temaOscuro
                ? Color.FromArgb(180, 190, 205)
                : Color.FromArgb(90, 100, 115);


            AplicarColoresLabels(this, colorTexto, colorSecundario);

            if (graficoPuntualidad != null)
                ActualizarGraficoPuntualidad();

        }

        private void AplicarColoresLabels(
            Control contenedor,
            Color colorTexto,
            Color colorSecundario)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is Label etiqueta)
                {
                    etiqueta.ForeColor = etiqueta.Font.Bold
                        ? colorTexto
                        : colorSecundario;
                }

                if (control.HasChildren)
                {
                    AplicarColoresLabels(
                        control,
                        colorTexto,
                        colorSecundario);
                }
            }
        }
        private void UIStyles_TemaCambiado(object sender, EventArgs e)
        {
            if (!IsDisposed)
            {
                BeginInvoke(new Action(() =>
                {
                    if (!IsDisposed)
                        AplicarColoresAsistenteIA();
                }));
            }
        }

        private void CrearGraficoPuntualidad()
        {
            graficoPuntualidad = new PieChart
            {
                Name = "graficoPuntualidad",
                Dock = DockStyle.Fill,
                BackColor = UIStyles.Superficie
            };


            Panel contenedor = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12, 45, 12, 10),
                BackColor = Color.Transparent
            };

            contenedor.Controls.Add(graficoPuntualidad);

            pnlGraficoIA.Controls.Add(contenedor);

            lblTituloGraficoIA.BringToFront();
        }

        private void btnRecomendacionIA_Click(object sender, EventArgs e)
        {
            try
            {
                using (UIRecomendacionIA ventana = new UIRecomendacionIA())
                {
                    ventana.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo abrir la recomendación IA: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }








        private void cmbCalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

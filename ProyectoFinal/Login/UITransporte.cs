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

namespace Login
{
    public partial class UITransporte : Form
    {
        // Guardamos las ventas cargadas en el mismo orden que los items de clbVentas,
        // para poder recuperar el objeto Venta real a partir del índice tildado.
        private List<Venta> ventasDisponibles = new List<Venta>();

        public UITransporte()
        {
            InitializeComponent();
            // Por las dudas el Designer no lo tenga enlazado:
            this.Load += UITransporte_Load;
            ConfigurarLabel(this.lblVentas, "Ventas a incluir en el transporte",
                new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblFecha, "Fecha y Hora Programada",
                new System.Drawing.Point(16, 152));
            ConfigurarLabel(this.lblEstado, "Estado del Transporte",
                new System.Drawing.Point(16, 205));
            ConfigurarBotonPrimario(this.btnRegistrarTransporte, "Registrar",
                new System.Drawing.Point(20, 384), 3);
            this.btnRegistrarTransporte.Size = new System.Drawing.Size(240, 40);
            this.btnRegistrarTransporte.Click += new System.EventHandler(this.btnRegistrarTransporte_Click);

            ConfigurarBotonSecundario(this.btnSalirTransporte, "Cancelar",
                new System.Drawing.Point(272, 384), 4);
            this.btnSalirTransporte.Size = new System.Drawing.Size(128, 40);
            this.btnSalirTransporte.Click += new System.EventHandler(this.btnSalirTransporte_Click);
        }

        private void UITransporte_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Cargamos las ventas disponibles.
                // Idealmente, en tu capa NVentas deberías tener un método que traiga 
                // solo las ventas que necesitan envío (ej: NVentas.GetVentasParaTransporte()).
                // Si no lo tenés, usamos GetAll() por ahora.
                ventasDisponibles = NVentas.GetAllVentas() ?? new List<Venta>();

                clbVentas.Items.Clear();
                foreach (Venta venta in ventasDisponibles)
                {
                    string nombreCliente = venta.Cliente != null ? venta.Cliente.Nombre : "Consumidor Final";
                    string texto = $"Venta #{venta.IdVenta} - {nombreCliente} - {venta.Total:C2}";
                    clbVentas.Items.Add(texto);
                }

                // 2. Configuramos el DateTimePicker para que no permita fechas pasadas
                dtpFecha.MinDate = DateTime.Today;

                // 3. Estado inicial del combo (Programado)
                cbEstado.SelectedIndex = 0;

                ActualizarTotal();

                if (ventasDisponibles.Count == 0)
                {
                    MessageBox.Show("No hay ventas disponibles para asignar a un transporte.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRegistrarTransporte.Enabled = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cargar los datos: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ItemCheck se dispara ANTES de que se aplique el nuevo estado del check,
        // por eso postergamos el recálculo con BeginInvoke hasta que el check ya se aplicó.
        private void clbVentas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { ActualizarTotal(); });
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            for (int i = 0; i < clbVentas.Items.Count && i < ventasDisponibles.Count; i++)
            {
                if (clbVentas.GetItemChecked(i))
                    total += ventasDisponibles[i].Total;
            }
            labelTotalCobrar.Text = total.ToString("C2");
        }

        private void btnRegistrarTransporte_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Recuperamos las ventas tildadas
                List<Venta> ventasSeleccionadas = new List<Venta>();
                for (int i = 0; i < clbVentas.Items.Count && i < ventasDisponibles.Count; i++)
                {
                    if (clbVentas.GetItemChecked(i))
                        ventasSeleccionadas.Add(ventasDisponibles[i]);
                }

                if (ventasSeleccionadas.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione al menos una Venta para asignar al transporte.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaSeleccionada = dtpFecha.Value; // conserva la hora elegida
                if (fechaSeleccionada < DateTime.Now)
                {
                    MessageBox.Show("No se puede programar un transporte para una fecha y hora en el pasado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbEstado.SelectedIndex < 0)
                {
                    MessageBox.Show("Por favor, seleccione un estado para el transporte.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // El índice seleccionado coincide con las constantes de EstadoTransporte
                // (0 = programado, 1 = EnTransito, 2 = Entregado, 3 = cancelado)
                int estadoSeleccionado = cbEstado.SelectedIndex;

                // 2. Como un transporte tiene una sola venta, creamos un Transporte
                // por cada venta tildada, todos con la misma fecha y estado.
                List<int> idsCreados = new List<int>();
                foreach (Venta venta in ventasSeleccionadas)
                {
                    Transporte transporteEnMemoria = new Transporte
                    {
                        Venta = venta,
                        Fecha = fechaSeleccionada,
                        Estado = estadoSeleccionado
                    };

                    // NTransporte.CreateTransporte ya tiene tus validaciones lógicas incorporadas
                    int idNuevoTransporte = NTransporte.CreateTransporte(transporteEnMemoria);
                    idsCreados.Add(idNuevoTransporte);
                }

                // 3. Avisamos y cerramos el formulario con OK
                string mensaje = idsCreados.Count == 1
                    ? $"Transporte N° {idsCreados[0]} registrado con éxito."
                    : $"Se registraron {idsCreados.Count} transportes (N° {string.Join(", ", idsCreados)}) con éxito.";

                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Atrapamos las validaciones que lanzaste con "throw new ArgumentException" desde NTransporte
                MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalirTransporte_Click(object sender, EventArgs e)
        {
            // Cerramos el formulario devolviendo un Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(280, 18));

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => UIStyles.PintarPanelRedondeado(sender, e);
    }
}
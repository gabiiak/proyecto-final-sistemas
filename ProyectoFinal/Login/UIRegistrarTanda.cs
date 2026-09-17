using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegistrarTanda : Form
    {
        private List<DetalleTandaProduccion> listaDetalles = new List<DetalleTandaProduccion>();
        public TandaProduccion tandaEnMemoria = new TandaProduccion();

        public UIRegistrarTanda()
        {
            InitializeComponent();
            dgvTanda_Detalles.AllowUserToAddRows = false;
            ConfigurarLabel(this.lblProducto, "Producto a elaborar", new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbProducto, new System.Drawing.Point(16, 36), new System.Drawing.Size(228, 32), 0);
            ConfigurarLabel(this.lblCantidadProducto, "Cantidad de producto", new System.Drawing.Point(255, 16));

            ConfigurarTextBox(this.txtCantidadTanda, new System.Drawing.Point(255, 36), new System.Drawing.Size(168, 32), 0);
            ConfigurarLabel(this.lblFecha, "Fecha", new System.Drawing.Point(16, 84));
            ConfigurarTextBox(this.txtFecha, new System.Drawing.Point(16, 104), new System.Drawing.Size(210, 32), 1);

            ConfigurarLabel(this.lblHora, "Hora", new System.Drawing.Point(240, 84));
            ConfigurarTextBox(this.txtHora, new System.Drawing.Point(240, 104), new System.Drawing.Size(224, 32), 2);

            //ConfigurarBotonSecundario(this.btnQuitarDetalle, "Quitar detalle", new System.Drawing.Point(176, 460), 5);
            ConfigurarBotonPrimario(this.btnAgregarDetalle, "Calcular Insumos", new System.Drawing.Point(20, 460), 4);
            ConfigurarBotonPrimario(this.btnRegistrarTanda, "Registrar Tanda", new System.Drawing.Point(20, 624), 6);
        }

        private void CalcularDetalleReceta()
        {
            if (cbProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidadTanda.Text, out int cantidadAProducir) || cantidadAProducir <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad numérica mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = (Producto)cbProducto.SelectedItem;
            
            List<RecetaProducto> receta = NRecetaProducto.ObtenerPorProducto(productoSeleccionado.IdProducto);

            if (receta == null || receta.Count == 0)
            {
                MessageBox.Show("Este producto no tiene una receta definida. Cargue la receta antes de registrar una tanda.",
                    "Receta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listaDetalles = new List<DetalleTandaProduccion>();

            foreach (RecetaProducto item in receta)
            {
                listaDetalles.Add(new DetalleTandaProduccion
                {
                    Insumo = new Insumo { Id = item.IdInsumo, Nombre = item.NombreInsumo, UnidadMedida = item.UnidadMedidaInsumo},
                    CantidadUtilizada = item.CantidadPorUnidad * cantidadAProducir
                });
            }

            ActualizarDataGridView();
        }

        private void UIRegistrarTanda_Load(object sender, EventArgs e)
        {
            try
            {
                var productos = NProductos.GetAll();
                cbProducto.DataSource = null;
                cbProducto.DataSource = productos;
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "IdProducto";

                txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarDataGridView();
        }

        public void ActualizarDataGridView()
        {
            dgvTanda_Detalles.Rows.Clear();
            foreach (var det in listaDetalles)
            {
                dgvTanda_Detalles.Rows.Add(
                    det.Insumo.Nombre,
                    det.CantidadUtilizada,
                    det.Insumo.UnidadMedida
                    //det.Empleado.Nombre + " " + det.Empleado.Apellido,
                    
                );
            }    
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            CalcularDetalleReceta();
            if (!int.TryParse(txtCantidadTanda.Text, out int cantProducida) || cantProducida <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad numérica mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            labelTotalCantidad.Text = cantProducida.ToString();
            /*UIRegistrarDetalleTanda regDetalle = new UIRegistrarDetalleTanda();
            if (regDetalle.ShowDialog() == DialogResult.OK)
            {
                listaDetalles.AddRange(regDetalle.DetallesTanda);
                ActualizarDataGridView();
            }*/
        }

        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvTanda_Detalles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un detalle para quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int indice = dgvTanda_Detalles.SelectedRows[0].Index;
            listaDetalles.RemoveAt(indice);
            ActualizarDataGridView();
        }

        private void btnRegistrarTanda_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParseExact(txtFecha.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                MessageBox.Show("Formato de fecha inválido. Use dd-MM-yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(txtHora.Text, out DateTime hora))
            {
                hora = DateTime.Now;
            }

            if (listaDetalles.Count == 0)
            {
                MessageBox.Show("Debe registrar al menos un detalle de insumo/empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                var prodSeleccionado = (Producto)cbProducto.SelectedItem;
                tandaEnMemoria = new TandaProduccion
                {
                    Producto = prodSeleccionado,
                    Fecha = fecha,
                    Hora = hora,
                    EstadoTanda = EstadoTanda.Pendiente,
                    CantidadProducida = int.Parse(txtCantidadTanda.Text),
                    FechaCaducidad = fecha.AddDays(prodSeleccionado.VidaUtilDias)
                };

                int idNuevaTanda = NTandaProduccion.RegistrarTanda(tandaEnMemoria);
                MessageBox.Show("Tanda de producción registrada correctamente con estado PENDIENTE.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la tanda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
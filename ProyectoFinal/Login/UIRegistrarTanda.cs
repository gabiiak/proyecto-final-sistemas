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
        private int totalCantidadProducida = 0;

        public UIRegistrarTanda()
        {
            InitializeComponent();
            dgvTanda_Detalles.AllowUserToAddRows = false;
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
            totalCantidadProducida = 0;
            foreach (var det in listaDetalles)
            {
                dgvTanda_Detalles.Rows.Add(
                    det.Insumo.Nombre,
                    det.Empleado.Nombre + " " + det.Empleado.Apellido,
                    det.CantidadProducida
                );
                totalCantidadProducida += det.CantidadProducida;
            }
            labelTotalCantidad.Text = totalCantidadProducida.ToString();
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            UIRegistrarDetalleTanda regDetalle = new UIRegistrarDetalleTanda();
            if (regDetalle.ShowDialog() == DialogResult.OK)
            {
                listaDetalles.AddRange(regDetalle.DetallesTanda);
                ActualizarDataGridView();
            }
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
                    EstadoTanda = EstadoTanda.Pendiente
                };

                int idNuevaTanda = NTandaProduccion.RegistrarTanda(tandaEnMemoria);
                tandaEnMemoria.IdTanda = idNuevaTanda;

                foreach (var detalle in listaDetalles)
                {
                    detalle.TandaProduccion = tandaEnMemoria;
                    NDetalleTandaProduccion.RegistrarDetalle(detalle);
                }

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
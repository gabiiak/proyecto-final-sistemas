using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegisterTandaDetail : Form
    {
        private List<DetalleTandaProduccion> detallesTanda = new List<DetalleTandaProduccion>();
        public List<DetalleTandaProduccion> DetallesTanda => detallesTanda;

        public UIRegisterTandaDetail()
        {
            InitializeComponent();
        }

        private void UIRegisterTandaDetail_Load(object sender, EventArgs e)
        {
            try
            {
                var insumos = NInsumos.GetAllInsumos();
                cbInsumo.DataSource = null;
                cbInsumo.DataSource = insumos;
                cbInsumo.DisplayMember = "Nombre";
                cbInsumo.ValueMember = "Id";

                var empleados = NEmpleado.ListarEmpleados(true);
                cbEmpleado.DataSource = null;
                cbEmpleado.DataSource = empleados;
                cbEmpleado.DisplayMember = "Nombre";
                cbEmpleado.ValueMember = "IdEmpleado";

                txtDescripcionInsumo.ReadOnly = true;
                Clean();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInsumo.SelectedItem is Insumo insumo)
            {
                txtDescripcionInsumo.Text = insumo.Descripcion;
            }
        }

        private void btnRegistrarDetalle_Click(object sender, EventArgs e)
        {
            if (cbInsumo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un insumo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Debe asignar un empleado responsable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numUpDownCantidad.Value <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad producida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var insumoSeleccionado = (Insumo)cbInsumo.SelectedItem;
            var empleadoSeleccionado = (Empleado)cbEmpleado.SelectedItem;
            int cantidad = (int)numUpDownCantidad.Value;

            DetalleTandaProduccion detalle = new DetalleTandaProduccion
            {
                Insumo = insumoSeleccionado,
                Empleado = empleadoSeleccionado,
                CantidadProducida = cantidad
            };

            detallesTanda.Add(detalle);
            MessageBox.Show("Detalle agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            Clean();
        }

        private void Clean()
        {
            numUpDownCantidad.Value = 0;
            if (cbInsumo.Items.Count > 0) cbInsumo.SelectedIndex = 0;
            if (cbEmpleado.Items.Count > 0) cbEmpleado.SelectedIndex = 0;
        }

        private void btnSalirDetalle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
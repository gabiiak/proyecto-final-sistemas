using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegistrarDetalleTanda : Form
    {
        private List<DetalleTandaProduccion> detallesTanda = new List<DetalleTandaProduccion>();
        public List<DetalleTandaProduccion> DetallesTanda => detallesTanda;

        public UIRegistrarDetalleTanda()
        {
            InitializeComponent();
            ConfigurarLabel(this.lblInsumo, "Insumo", new System.Drawing.Point(16, 12));
            ConfigurarCombo(this.cbInsumo, new System.Drawing.Point(16, 30), new System.Drawing.Size(348, 30), 0);
            this.cbInsumo.SelectedIndexChanged += new System.EventHandler(this.cbInsumo_SelectedIndexChanged);

            // Descripción Insumo
            ConfigurarLabel(this.lblDescripcion, "Descripción del Insumo", new System.Drawing.Point(16, 68));
            ConfigurarTextBox(this.txtDescripcionInsumo, new System.Drawing.Point(16, 86), new System.Drawing.Size(348, 30), 1);
            this.txtDescripcionInsumo.ReadOnly = true;
            this.txtDescripcionInsumo.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);

            // Empleado Responsable
            ConfigurarLabel(this.lblEmpleado, "Empleado Responsable", new System.Drawing.Point(16, 126));
            ConfigurarCombo(this.cbEmpleado, new System.Drawing.Point(16, 144), new System.Drawing.Size(348, 30), 2);

            // Cantidad Producida
            ConfigurarLabel(this.lblCantidad, "Cantidad Producida", new System.Drawing.Point(16, 186));
            ConfigurarBotonPrimario(this.btnRegistrarDetalle, "Registrar", new System.Drawing.Point(20, 340), 4);
            this.btnRegistrarDetalle.Size = new System.Drawing.Size(240, 40);
            this.btnRegistrarDetalle.Click += new System.EventHandler(this.btnRegistrarDetalle_Click);

            ConfigurarBotonSecundario(this.btnSalirDetalle, "Cancelar", new System.Drawing.Point(272, 340), 5);
            this.btnSalirDetalle.Size = new System.Drawing.Size(128, 40);
            this.btnSalirDetalle.Click += new System.EventHandler(this.btnSalirDetalle_Click);
        }

        private void UIRegistrarDetalleTanda_Load(object sender, EventArgs e)
        {
            try
            {
                var insumos = NInsumos.GetAllInsumos();
                cbInsumo.DataSource = null;
                cbInsumo.DataSource = insumos;
                cbInsumo.DisplayMember = "Nombre";
                cbInsumo.ValueMember = "Id";

                //var empleados = NEmpleado.ListarEmpleados(true);
                cbEmpleado.DataSource = null;
                //cbEmpleado.DataSource = empleados;
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
        private List<DetalleTandaProduccion> CalcularDetalleDesdeReceta(int idProducto, int cantidadProducida)
        {
            List<RecetaProducto> receta = NRecetaProducto.ObtenerPorProducto(idProducto);

            if (receta == null || receta.Count == 0)
            {
                MessageBox.Show("Este producto no tiene una receta definida. Cargue la receta antes de registrar una tanda.",
                    "Receta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<DetalleTandaProduccion>();
            }

            List<DetalleTandaProduccion> detalles = new List<DetalleTandaProduccion>();

            foreach (RecetaProducto item in receta)
            {
                detalles.Add(new DetalleTandaProduccion
                {
                    Insumo = new Insumo { Id = item.IdInsumo, Nombre = item.NombreInsumo },
                    CantidadUtilizada = (item.CantidadPorUnidad * cantidadProducida),
                    Empleado = null // diferido
                });
            }

            return detalles;
        }
        private void btnRegistrarDetalle_Click(object sender, EventArgs e)
        {
            if (cbInsumo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un insumo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*if (cbEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Debe asignar un empleado responsable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
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
                CantidadUtilizada = cantidad
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

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto, System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt, System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb, System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex);

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex);
    }
}
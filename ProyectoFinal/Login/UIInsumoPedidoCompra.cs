using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIInsumoPedidoCompra : Form
    {
        private readonly Dictionary<int, decimal> preciosDelPresupuesto;
        private readonly List<int> yaCargados;
        private decimal precioSeleccionado;

        public DetalleCompra Detalle { get; private set; }

        public UIInsumoPedidoCompra(Dictionary<int, decimal> preciosDelPresupuesto, List<int> yaCargados)
        {
            InitializeComponent();
            this.preciosDelPresupuesto = preciosDelPresupuesto ?? new Dictionary<int, decimal>();
            this.yaCargados = yaCargados ?? new List<int>();

            ConfigurarLabel(this.lblInsumo, "Insumo", new System.Drawing.Point(16, 60));
            ConfigurarCombo(this.cbInsumo, new System.Drawing.Point(16, 80),
                new System.Drawing.Size(380, 32), 0);

            ConfigurarLabel(this.lblPrecio, "Precio unitario ($)", new System.Drawing.Point(16, 124));
            ConfigurarTextBox(this.txtPrecio, new System.Drawing.Point(16, 144),
                new System.Drawing.Size(180, 32), 1);
            this.txtPrecio.ReadOnly = true;

            ConfigurarLabel(this.lblCantidad, "Cantidad", new System.Drawing.Point(216, 124));
            this.numUpDownCantidad.Location = new System.Drawing.Point(216, 144);
            this.numUpDownCantidad.Size = new System.Drawing.Size(120, 32);
            this.numUpDownCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numUpDownCantidad.TabIndex = 2;

            ConfigurarBotonPrimario(this.btnAceptar, "Aceptar",
                new System.Drawing.Point(20, 248), 3);
            this.btnAceptar.Size = new System.Drawing.Size(200, 40);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            ConfigurarBotonSecundario(this.btnCancelar, "Cancelar",
                new System.Drawing.Point(232, 248), 4);
            this.btnCancelar.Size = new System.Drawing.Size(150, 40);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            UIStyles.AplicarTemaAForm(this);
        }

        private void UIInsumoPedidoCompra_Load(object sender, EventArgs e)
        {
            try
            {
                List<Insumo> insumos = NInsumos.GetAllInsumos();
                cbInsumo.DataSource = insumos;
                cbInsumo.DisplayMember = "Nombre";
                cbInsumo.ValueMember = "Id";
                cbInsumo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los insumos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarEstado(null);
        }

        private void cbInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstado(cbInsumo.SelectedItem as Insumo);
        }

        private void ActualizarEstado(Insumo insumo)
        {
            if (insumo == null)
            {
                Bloquear("Seleccione un insumo.");
                return;
            }

            if (yaCargados.Contains(insumo.Id))
            {
                Bloquear("Ese insumo ya está en el pedido.");
                return;
            }

            decimal precio;
            if (preciosDelPresupuesto.TryGetValue(insumo.Id, out precio))
            {
                precioSeleccionado = precio;
                txtPrecio.Text = precio.ToString("N2");
                lblAviso.Visible = false;
                numUpDownCantidad.Enabled = true;
                btnAceptar.Enabled = true;
            }
            else
            {
                Bloquear("El insumo " + insumo.Nombre + " no está en el presupuesto del proveedor.");
            }
        }

        private void Bloquear(string mensaje)
        {
            precioSeleccionado = 0;
            txtPrecio.Text = "";
            lblAviso.Text = mensaje;
            lblAviso.Visible = true;
            numUpDownCantidad.Enabled = false;
            btnAceptar.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Insumo insumo = cbInsumo.SelectedItem as Insumo;
            if (insumo == null)
            {
                MessageBox.Show("Debe seleccionar un insumo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal cantidad = numUpDownCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a 0.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cantidad > 50000m)
            {
                MessageBox.Show("La cantidad no puede superar las 50.000 unidades.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Detalle = new DetalleCompra
            {
                IdInsumo = insumo.Id,
                Cantidad = cantidad,
                Subtotal = (double)Math.Round(precioSeleccionado * cantidad, 2)
            };
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex, ComboBoxStyle.DropDownList);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));
    }
}

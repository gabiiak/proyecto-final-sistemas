using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegistrarDetalleCompra : Form
    {
        private List<DetalleCompra> detalleCompras = new List<DetalleCompra>();
        public List<DetalleCompra> DetalleCompras => detalleCompras; // lista de lectura
        decimal subTotal = 0;

        public UIRegistrarDetalleCompra()
        {
            InitializeComponent();
            ConfigurarLabel(this.lblInsumo, "Insumo",
                new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbInsumo,
                new System.Drawing.Point(16, 36), new System.Drawing.Size(348, 32), 0);

            ConfigurarLabel(this.lblPrecio, "Precio unitario ($)",
                new System.Drawing.Point(16, 80));

            ConfigurarLabel(this.lblCantidad, "Cantidad",
                new System.Drawing.Point(16, 148));

            ConfigurarBotonPrimario(this.btnRegistrarDetalle, "Registrar",
                new System.Drawing.Point(20, 344), 3);
            this.btnRegistrarDetalle.Size = new System.Drawing.Size(240, 40);
            this.btnRegistrarDetalle.Click += new System.EventHandler(this.btnRegistrarDetalle_Click);

            ConfigurarBotonSecundario(this.btnSalirDetalle, "Cancelar",
                new System.Drawing.Point(272, 344), 4);
            this.btnSalirDetalle.Size = new System.Drawing.Size(128, 40);
            this.btnSalirDetalle.Click += new System.EventHandler(this.btnSalirDetalle_Click);
        }

        private void UIRegistrarDetalleCompra_Load(object sender, EventArgs e)
        {
            try
            {
                var insumos = NInsumos.GetAllInsumos();
                cbInsumo.DataSource = null;
                cbInsumo.DataSource = insumos;
                cbInsumo.DisplayMember = "Nombre";
                cbInsumo.ValueMember = "Id";
                Clean();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        // En una compra el precio lo define el proveedor, por eso se ingresa a mano
        private void ActualizarSubTotal()
        {
            decimal precio = numUpDownPrecio.Value;
            int cantidad = (int)numUpDownCantidad.Value;

            subTotal = (cantidad > 0)
                ? NDetalleCompras.CalcularSubTotal(precio, cantidad)
                : 0;
            labelSubtotal.Text = subTotal.ToString("C2");
        }

        private void numUpDownPrecio_ValueChanged(object sender, EventArgs e)
        {
            ActualizarSubTotal();
        }

        private void numUpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarSubTotal();
        }

        private void btnRegistrarDetalle_Click(object sender, EventArgs e)
        {
            if (cbInsumo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un insumo registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numUpDownPrecio.Value <= 0)
            {
                MessageBox.Show("Debe ingresar un precio unitario mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numUpDownCantidad.Value <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Insumo insumoSeleccionado = (Insumo)cbInsumo.SelectedItem;
            int cantidad = (int)numUpDownCantidad.Value;

            DetalleCompra detalle = new DetalleCompra
            {
                IdInsumo = insumoSeleccionado.Id,
                Cantidad = cantidad,
                Subtotal = (double)subTotal
            };
            detalleCompras.Add(detalle);
            MessageBox.Show("Se registró el detalle con éxito.", "Éxito", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;
            Clean();
        }

        private void Clean()
        {
            numUpDownPrecio.Value = 0;
            numUpDownCantidad.Value = 0;
            subTotal = 0;
            labelSubtotal.Text = subTotal.ToString("C2");
        }

        private void btnSalirDetalle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex);

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
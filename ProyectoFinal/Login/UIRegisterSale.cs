using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegisterSale : Form
    {
        private List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
        private double total = 0;
        public UIRegisterSale()
        {
            InitializeComponent();
        }

        private void UIRegisterSale_Load(object sender, EventArgs e)
        {
            try
            {
                var clientes = NClientes.GetAll();
                cbCliente.DataSource = null; // <- cb = COMBOBOX
                cbCliente.DataSource = clientes;
                cbCliente.DisplayMember = "Nombre";
                cbCliente.ValueMember = "Id";

                var metodos = NMetodosPago.GetAll();
                cbMetodo.DataSource = null;
                cbMetodo.DataSource = metodos;
                cbMetodo.DisplayMember = "Descripcion";
                cbMetodo.ValueMember = "IdMetodoPago";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            ActualizarDataGridView();
            labelTotal.Text = total.ToString("C2");
        }

        public void ActualizarDataGridView()
        {
            //detalleVentas = NDetalleVentas.GetAllDetalleVentas();
            //dgvVenta_DetalleVenta.DataSource = null;
            //dgvVenta_DetalleVenta.DataSource = detalleVentas;

            //este foreach se usa para llenar el datagrid manualmente
            //no es el mejor método, pero lo estoy usando para no mostrar el IdDetalleVenta, y la venta correspondiente
            // (estos IdDetalleVenta y Venta se van a mostrar en Gestionar Ventas)
            dgvVenta_DetalleVenta.Rows.Clear();
            foreach (DetalleVenta detalle in detalleVentas)
            {
                dgvVenta_DetalleVenta.Rows.Add(
                    detalle.Producto.Nombre,
                    detalle.Cantidad,
                    detalle.SubTotal.ToString("C2") // (C2) para mostrar en formato moneda owo
                );
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            UIRegisterSaleDetail registrarDetalle = new UIRegisterSaleDetail();
            if(registrarDetalle.ShowDialog() == DialogResult.OK)
            {
                foreach (DetalleVenta detalle in registrarDetalle.DetalleVentas)
                {
                    detalleVentas.Add(detalle);
                }
                ActualizarDataGridView();
                total = NVentas.CalcularTotal(detalleVentas);
                labelTotal.Text = total.ToString("C2"); // convierte un valor numérico a una cadena de texto con formato de moneda
            }

        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPagoRecibido.Text))
            {
                MessageBox.Show("Ingresó un monto nulo, con valor 0 o con un valor menor al total. Está seguro que quiere registrar una venta con estado PENDIENTE?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return; //aqui va la lógica con estado pendiente

            }
            else
            {
                double recibido = double.Parse(txtPagoRecibido.Text);
                if (recibido == total)
                {
                    MessageBox.Show("Ingresó un monto igual al total. Registar venta como PAGADO?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    return;
                }
                if (recibido > total)
                {
                    MessageBox.Show("Ingresó un monto mayor. Si la venta es concretada en efectivo, debe devolver un vuelto de X(cacular)", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    return; //podría implementar una mini lógica de cálculo de vuelto
                }
            }
            
        }
    }
}

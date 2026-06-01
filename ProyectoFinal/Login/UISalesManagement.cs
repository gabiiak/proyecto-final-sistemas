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
    public partial class UISalesManagement : Form
    {
        private List<Venta> listadoVentasTotales = new List<Venta>();
        public int idVenta;
        public UISalesManagement()
        {
            InitializeComponent();
        }

        private void UISalesManagement_Load(object sender, EventArgs e)
        {
            labelId.Text = "";
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            listadoVentasTotales = NVentas.GetAllVentas();
            //dgvTodasLasVentas.DataSource = null;
            //dgvTodasLasVentas.DataSource = listadoVentasTotalesAÑA;
            dgvTodasLasVentas.Rows.Clear();
            foreach (Venta venta in listadoVentasTotales)
            {
                dgvTodasLasVentas.Rows.Add(
                    venta.IdVenta,
                    venta.Cliente.Nombre,
                    venta.Fecha,
                    venta.Total.ToString("C2"),
                    venta.Metodo.Descripcion,
                    GetDescripcionEstadoPago(venta.Estado_Pago),
                    GetEstadoPedido(venta.Estado_Pedido)
                    //AGREGAR ATRIBUTO TOTAL AL MODELO Y A LA BD TMB
                    );
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            UIRegisterSale registrar = new UIRegisterSale();
            if(registrar.ShowDialog() == DialogResult.OK)
            {
                listadoVentasTotales.Add(registrar.ventaEnMemoria);
            }
            ActualizarDataGridView();
        }
        private string GetEstadoPedido(int estado)
        {
            switch (estado)
            {
                case EstadoPedido.Cancelado: return "CANCELADO";
                case EstadoPedido.Preparacion: return "PREPARANDO";
                case EstadoPedido.Listo: return "LISTO";
                case EstadoPedido.EnViaje: return "VIAJANDO";
                case EstadoPedido.Entregado: return "ENTREGADO";
                default: return "DESCONOCIDO";
            }
        }
        private string GetDescripcionEstadoPago(int estado)
        {
            switch (estado)
            {
                case EstadoPago.Anulado: return "ANULADO";
                case EstadoPago.Pendiente: return "PENDIENTE";
                case EstadoPago.Pagado: return "PAGADO";
                default: return "DESCONOCIDO";
            }
        }

        private void dgvTodasLasVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTodasLasVentas.CurrentRow == null) return;
            labelId.Text = dgvTodasLasVentas.CurrentRow.Cells["IdVenta"].Value?.ToString();
            idVenta = int.Parse(labelId.Text);
        }

        private void btnEstadoPago_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar una venta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            UIPaymentState estado = new UIPaymentState();
            if (estado.ShowDialog() == DialogResult.OK)
            {
                Venta venta = new Venta
                {
                    IdVenta = int.Parse(labelId.Text),
                    Estado_Pago = estado.estado
                };
                NVentas.CambiarEstadoPago(venta);
                ActualizarDataGridView();
            }
            ActualizarDataGridView();
        }

        private void btnEstadoPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar una venta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            UIOrderState pedido = new UIOrderState();
            if (pedido.ShowDialog() == DialogResult.OK)
            {
                Venta venta = new Venta
                {
                    IdVenta = int.Parse(labelId.Text),
                    Estado_Pago = pedido.estado
                };
                NVentas.CambiarEstadoPedido(venta);
                ActualizarDataGridView();
            }
            ActualizarDataGridView();
        }
        private void btnConsultarVenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar una venta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            int idVenta = int.Parse(labelId.Text);
            UIConsultSale consulta = new UIConsultSale(idVenta);
            consulta.Show();
        }



        //mañana agregar lógica de modificacion de venta y cambio de estados
    }
}

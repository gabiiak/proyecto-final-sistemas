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
            dgvTodasLasVentas.AllowUserToAddRows = false;
            CargarFiltroClientes();
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
                    venta.Fecha.ToString("dd-MM-yyyy"),
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

        private void btnEstadoPago_Click(object sender, EventArgs e) //me la mandé // solucionado
        {
            if (string.IsNullOrEmpty(labelId.Text))
            {
                MessageBox.Show("Debe seleccionar una venta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            int idVenta = int.Parse(labelId.Text);
            UIPaymentState estado = new UIPaymentState(idVenta);
            if (estado.ShowDialog() == DialogResult.OK)
            {
                int nuevoEstado = estado.estado;
                NVentas.CambiarEstadoPago(idVenta, estado.estado);
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
                NVentas.CambiarEstadoPedido(idVenta, pedido.estado);
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

        private void btnFiltrarPorFecha_Click(object sender, EventArgs e)
        {
            //string desde = dtpDesde.Value.Date.ToString();
            //string hasta = dtpHasta.Value.Date.ToString();

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("Las fechas son incorrectas. La fecha 'Desde' no puede ser mayor que 'Hasta' (Error temporal)","Alerta", MessageBoxButtons.OK);
                return;
            }

            var listaFiltrada = listadoVentasTotales.Where(c => c.Fecha.Date >= desde && c.Fecha.Date <= hasta).ToList();
            if (listaFiltrada.Count == 0)
            {
                MessageBox.Show("No se encontraron ventas por esas fechas...", "Alerta", MessageBoxButtons.OK);
                return;
            }
            dgvTodasLasVentas.Rows.Clear();
            foreach (Venta venta in listaFiltrada)
            {
                dgvTodasLasVentas.Rows.Add(
                    venta.IdVenta,
                    venta.Cliente.Nombre,
                    venta.Fecha.ToString("dd-MM-yyyy"),
                    venta.Total.ToString("C2"),
                    venta.Metodo.Descripcion,
                    GetDescripcionEstadoPago(venta.Estado_Pago),
                    GetEstadoPedido(venta.Estado_Pedido)
                    );
            }
            dgvTodasLasVentas.Refresh();
        }
        private void CargarFiltroClientes()
        {
            var clientes = NClientes.GetAll();
            clientes.Insert(0, new Cliente { Id = 0, Nombre = "Todos" });
            cbClienteFiltro.DataSource = clientes;
            cbClienteFiltro.DisplayMember = "Nombre";
            cbClienteFiltro.ValueMember = "Id";
        }

        private void btnDesfiltrar_Click(object sender, EventArgs e)
        {
            ActualizarDataGridView();
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
        }

        private void btnFiltroCliente_Click(object sender, EventArgs e)
        {
            int idClienteSeleccionado = ((Cliente)cbClienteFiltro.SelectedItem).Id;
            var listaFiltrada = listadoVentasTotales
                .Where(v => idClienteSeleccionado == 0 || v.Cliente.Id == idClienteSeleccionado)
                .ToList();
            //para debuggear
            //MessageBox.Show($"Id seleccionado: {idClienteSeleccionado}\n" +
            //string.Join("\n", listadoVentasTotales.Select(v => $"Venta {v.IdVenta} - Cliente id: {v.Cliente.Id} - Nombre: {v.Cliente.Nombre}")));
            dgvTodasLasVentas.Rows.Clear();
            foreach (Venta venta in listaFiltrada)
            {
                dgvTodasLasVentas.Rows.Add(
                    venta.IdVenta,
                    venta.Cliente.Nombre,
                    venta.Fecha.ToString("dd-MM-yyyy"),
                    venta.Total.ToString("C2"),
                    venta.Metodo.Descripcion,
                    GetDescripcionEstadoPago(venta.Estado_Pago),
                    GetEstadoPedido(venta.Estado_Pedido)
                    );
            }
            dgvTodasLasVentas.Refresh();
        }




        //mañana agregar lógica de modificacion de venta y cambio de estados
    }
}

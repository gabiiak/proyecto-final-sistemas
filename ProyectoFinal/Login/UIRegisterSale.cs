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
        public Venta ventaEnMemoria = new Venta();
        private double total;
        public UIRegisterSale()
        {
            InitializeComponent();
            dgvVenta_DetalleVenta.AllowUserToAddRows = false;
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
            labelTotal.Text = total.ToString("");
            txtFecha.ReadOnly = false; //<- true para que no se pueda editar
            txtFecha.BorderStyle = BorderStyle.FixedSingle;
            txtFecha.Text = GetFecha().ToString("dd-MM-yyyy");
            txtPagoRecibido.Text = 0.ToString();
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
                labelTotal.Text = total.ToString();
                //labelTotal.Text = total.ToString("C2"); // convierte un valor numérico a una cadena de texto con formato de moneda
                //estado actual: tengo que programar la lógica en la capa de negocios. la capa de UI solo crea el objeto y lo manda :P
            }

        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            if (!DateTime.TryParseExact(txtFecha.Text, "dd-MM-yyyy", null,
                System.Globalization.DateTimeStyles.None, out fecha))
            {
                MessageBox.Show("Formato de fecha inválido. Use dd-MM-yyyy.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fecha.Date > DateTime.Now.Date)
            {
                MessageBox.Show("No se puede registrar una venta con fecha futura.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPagoRecibido.Text))
            {
                MessageBox.Show("No se puede registrar una venta con un valor nulo.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //double recibido = double.Parse(txtPagoRecibido.Text);
            double.TryParse(txtPagoRecibido.Text, out double recibido);
            if (recibido < total)
            {
                DialogResult resultado = MessageBox.Show("Ingresó un monto con valor de 0 o con un valor menor al total. " +
                    "Está seguro que quiere registrar una venta con estado PENDIENTE?", "Alerta", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resultado == DialogResult.Yes)
                {
                    var clienteSeleccionado = (Cliente)cbCliente.SelectedItem;
                    var metodoSeleccionado = (MetodoPago)cbMetodo.SelectedItem;
                    fecha = DateTime.Parse(txtFecha.Text);
                    ventaEnMemoria = new Venta
                    {
                        Cliente = clienteSeleccionado,
                        Fecha = fecha,
                        Total = total,
                        Metodo = metodoSeleccionado,
                        Estado_Pago = NVentas.DeterminarEstadoPago(total, recibido),
                        Estado_Pedido = EstadoPedido.Preparacion
                    };
                    int idVenta = NVentas.CreateVenta(ventaEnMemoria);
                    ventaEnMemoria.IdVenta = idVenta;
                    foreach (DetalleVenta detalle in detalleVentas)
                    {
                        detalle.Venta = new Venta { IdVenta = idVenta };
                        NDetalleVentas.CreateDetalleVenta(detalle);
                    }
                    this.DialogResult = DialogResult.OK;
                } 

            }
            else
            {
                if (recibido > total)
                {
                    MetodoPago metodoSeleccionado = (MetodoPago)cbMetodo.SelectedItem;
                    if (metodoSeleccionado.Descripcion.Equals("Efectivo") || metodoSeleccionado.Descripcion.Equals("EFECTIVO"))
                    {
                        double vuelto = CalcularVuelto(total, recibido);
                        DialogResult result = MessageBox.Show("Ingresó un monto mayor. Debe devolver un vuelto de " + vuelto.ToString("C2"), "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                         if (result == DialogResult.Yes)
                        {
                            var clienteSeleccionado = (Cliente)cbCliente.SelectedItem;
                            metodoSeleccionado = (MetodoPago)cbMetodo.SelectedItem;
                            fecha = DateTime.Parse(txtFecha.Text);
                            ventaEnMemoria = new Venta
                            {
                                Cliente = clienteSeleccionado,
                                Fecha = fecha,
                                Total = total,
                                Metodo = metodoSeleccionado,
                                Estado_Pago = NVentas.DeterminarEstadoPago(total, recibido),
                                Estado_Pedido = EstadoPedido.Preparacion
                            };
                            int idVenta = NVentas.CreateVenta(ventaEnMemoria);
                            ventaEnMemoria.IdVenta = idVenta;
                            foreach (DetalleVenta detalle in detalleVentas)
                            {
                                detalle.Venta = new Venta { IdVenta = idVenta };
                                NDetalleVentas.CreateDetalleVenta(detalle);
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("Puede ingresar un monto mayor SOLO si el método de pago de la transacción es 'Efectivo'. De otra forma, no se puede registrar más del monto total de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
                else
                {
                    DialogResult result = MessageBox.Show("Se concretará una venta con el monto justo pagado y la venta estará PAGADA.", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var clienteSeleccionado = (Cliente)cbCliente.SelectedItem;
                        var metodoSeleccionado = (MetodoPago)cbMetodo.SelectedItem;
                        fecha = DateTime.Parse(txtFecha.Text);
                        ventaEnMemoria = new Venta
                        {
                            Cliente = clienteSeleccionado,
                            Fecha = fecha,
                            Total = total,
                            Metodo = metodoSeleccionado,
                            Estado_Pago = NVentas.DeterminarEstadoPago(total, recibido),
                            Estado_Pedido = EstadoPedido.Preparacion
                        };
                        int idVenta = NVentas.CreateVenta(ventaEnMemoria);
                        ventaEnMemoria.IdVenta = idVenta;
                        foreach (DetalleVenta detalle in detalleVentas)
                        {
                            detalle.Venta = new Venta { IdVenta = idVenta };
                            NDetalleVentas.CreateDetalleVenta(detalle);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            
        }
        private double CalcularVuelto(double total, double recibido)
        {
            return recibido - total;
        }
        private void btnPagoJusto_Click(object sender, EventArgs e)
        {
            double recibido = total;
            txtPagoRecibido.Text = recibido.ToString("");
        }
        
        private DateTime GetFecha() //aqui puedo retornar un string como fecha
        {
            return DateTime.Now.Date;
        }

        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVenta_DetalleVenta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un detalle para quitar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int indice = dgvVenta_DetalleVenta.SelectedRows[0].Index;
            detalleVentas.RemoveAt(indice);
            total = NVentas.CalcularTotal(detalleVentas);
            labelTotal.Text = total.ToString();
            ActualizarDataGridView();
        }

    }
}

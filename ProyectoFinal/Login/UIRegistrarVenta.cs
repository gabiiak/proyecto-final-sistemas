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
    public partial class UIRegistrarVenta : Form
    {
        private List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
        public Venta ventaEnMemoria = new Venta();
        private double total;
        public double deuda = 0.00;
        public UIRegistrarVenta()
        {
            InitializeComponent();
            dgvVenta_DetalleVenta.AllowUserToAddRows = false;
            ConfigurarLabel(this.lblCliente, "Cliente", new System.Drawing.Point(16, 16));
            ConfigurarLabel(this.lblMetodo, "Método de pago", new System.Drawing.Point(256, 16));
            ConfigurarCombo(this.cbCliente, new System.Drawing.Point(16, 36), new System.Drawing.Size(220, 32), 0);
            ConfigurarCombo(this.cbMetodo, new System.Drawing.Point(256, 36), new System.Drawing.Size(208, 32), 1);

            // Fila 2: Fecha transacción
            ConfigurarLabel(this.lblFecha, "Fecha de transacción", new System.Drawing.Point(16, 84));
            ConfigurarTextBox(this.txtFecha, new System.Drawing.Point(16, 104), new System.Drawing.Size(448, 32), 2);
            ConfigurarBotonPrimario(this.btnAgregarDetalle, "Agregar detalle",
                new System.Drawing.Point(20, 460), 4);
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);

            ConfigurarBotonSecundario(this.btnQuitarDetalle, "Quitar detalle",
                new System.Drawing.Point(176, 460), 5);
            this.btnQuitarDetalle.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnQuitarDetalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);
            ConfigurarLabel(this.lblPagoRecibido, "Pago recibido ($)",
                new System.Drawing.Point(260, 10));
            ConfigurarTextBox(this.txtPagoRecibido,
                new System.Drawing.Point(260, 28), new System.Drawing.Size(120, 32), 6);

            ConfigurarBotonSecundario(this.btnPagoJusto, "Pago justo",
                new System.Drawing.Point(392, 28), 7);
            this.btnPagoJusto.Size = new System.Drawing.Size(72, 32);
            this.btnPagoJusto.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPagoJusto.Click += new System.EventHandler(this.btnPagoJusto_Click);
            ConfigurarBotonPrimario(this.btnRegistrarVenta, "Registrar Venta",
                new System.Drawing.Point(20, 624), 8);
            this.btnRegistrarVenta.Size = new System.Drawing.Size(480, 44);
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
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
            UIRegistrarDetalleVenta registrarDetalle = new UIRegistrarDetalleVenta();
            var metodoSeleccionado = (MetodoPago)cbMetodo.SelectedItem;
            string metodoDescripcion = metodoSeleccionado.Descripcion;
            if (registrarDetalle.ShowDialog() == DialogResult.OK)
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

        private void RegistrarVentaEnBaseDeDatos(int estado, double recibido)
        {
            var clienteSeleccionado = (Cliente)cbCliente.SelectedItem;
            var metodoSeleccionado = (MetodoPago)cbMetodo.SelectedItem;
            DateTime fecha = DateTime.Parse(txtFecha.Text);
            recibido = Math.Round(recibido, 2);
            total = Math.Round(total, 2);

            ventaEnMemoria = new Venta
            {
                Cliente = clienteSeleccionado,
                Fecha = fecha,
                Total = total,
                Metodo = metodoSeleccionado,
                Estado_Pago = estado,
                Estado_Pedido = EstadoPedido.Preparacion,
                MontoRecibido = (total - recibido <= 0.01) ? total : recibido
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

            try
            {
                NVentas.ValidarFechaVenta(fecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (string.IsNullOrEmpty(txtPagoRecibido.Text))
            {
                MessageBox.Show("No se puede registrar una venta con un valor nulo.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(detalleVentas.Count == 0)
            {
                MessageBox.Show("Debe registrar al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //double recibido = double.Parse(txtPagoRecibido.Text);
            //double.TryParse(txtPagoRecibido.Text, out double recibido);
            if (!double.TryParse(txtPagoRecibido.Text, out double recibido) || recibido < 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string avisoStock = NVentas.VerificarStockDisponible(detalleVentas);
            if (avisoStock != null)
            {
                MessageBox.Show(avisoStock, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // seguís adelante igual, es solo informativo — no hay return acá
            }
            int estado = NVentas.DeterminarEstadoPago(total, recibido);
            if (total - recibido > 0.01)
            {
                double deudaACobrar = total - recibido;
                DialogResult resultado = MessageBox.Show("Ingresó un monto con valor de 0 o con un valor menor al total. " +
                    "Se registrará una venta con estado PENDIENTE y tendrá que cobrar " + deudaACobrar.ToString("C2"), "Alerta", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resultado == DialogResult.Yes)
                {
                    RegistrarVentaEnBaseDeDatos(estado, recibido);
                } 

            }
            else
            {
                if (recibido > total)
                {
                    MetodoPago metodoSeleccionado = (MetodoPago)cbMetodo.SelectedItem;
                    if (metodoSeleccionado.Descripcion.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
                    {
                        string descripcionMetodo = metodoSeleccionado.Descripcion;
                        double totalDescuento = NVentas.DescuentoPorEfectivo(total, descripcionMetodo);
                        double vuelto = NVentas.CalcularVuelto(total,recibido,metodoSeleccionado.Descripcion);
                        DialogResult result = MessageBox.Show("Ingresó un monto mayor. Debe devolver un vuelto de " + vuelto.ToString("C2"), "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                         if (result == DialogResult.Yes)
                        {
                            RegistrarVentaEnBaseDeDatos(estado, recibido);
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
                        RegistrarVentaEnBaseDeDatos(estado, recibido);
                    }
                }
            }
            
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

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

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

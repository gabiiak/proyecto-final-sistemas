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
    public partial class UIPaymentState : Form
    {
        public int estado;
        private int idVenta;
        public UIPaymentState(int idVenta)
        {
            InitializeComponent();
            this.idVenta = idVenta;
            Venta venta = NVentas.GetVentaById(idVenta);
            int estadoVenta = venta.Estado_Pago;
            double deuda = NVentas.CalcularDeuda(idVenta);
            labelDeuda.Text = deuda.ToString("C2");
            labelEstado.Text = GetDescripcionEstadoPago(estadoVenta);
            if (labelEstado.Text.Equals("PAGADO", StringComparison.OrdinalIgnoreCase))
            {
                txtDeuda.ReadOnly = true;
                labelDeuda.Text = "DEUDA PAGADA";
            }
            if (labelEstado.Text.Equals("ANULADO", StringComparison.OrdinalIgnoreCase))
            {
                labelDeuda.Text = "PAGO ANULADO";
                txtDeuda.ReadOnly = true;
            }
        }
        private void UIPaymentState_Load(object sender, EventArgs e)
        {
            
        }

        private void bntPagarDeuda_Click(object sender, EventArgs e)
        {
            if (labelEstado.Text.Equals("PAGADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue pagada y no puede cambiarse su estado.");
                return;
            }
            if (labelEstado.Text.Equals("ANULADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue anulada y no puede cambiarse su estado. Intente registrando otra venta.");
                return;
            }
            double deuda = NVentas.CalcularDeuda(idVenta);
            //double ingresado = double.Parse(txtDeuda.Text);
            //try parse se fija que no ingrese otra cosa que no sea un num.
            if (!double.TryParse(txtDeuda.Text, out double ingresado) || ingresado <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }
            double aux = deuda - ingresado;
            if (ingresado >= deuda || aux < 0.1)
            {
                double vuelto = ingresado - deuda;
                NVentas.CambiarMontoRecibido(idVenta, deuda); // acumula solo lo que faltaba
                estado = EstadoPago.Pagado;
                //if (vuelto > 0)MessageBox.Show($"Vuelto: {vuelto:C2}");
            }
            else
            {
                DialogResult resultado = MessageBox.Show($"Con el monto está cancelando parte de la deuda. El monto final a pagar será {aux.ToString("C2")}", "Alerta",MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    NVentas.CambiarMontoRecibido(idVenta, ingresado); // pago parcial
                    estado = EstadoPago.Pendiente;
                } else { return; }
                
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {
            if (labelEstado.Text.Equals("PAGADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue pagada y no puede cambiarse su estado.");
                return;
            }
            if (labelEstado.Text.Equals("ANULADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue anulada y no puede cambiarse su estado. Intente registrando otra venta.");
                return;
            }
            DialogResult result = MessageBox.Show("Seguro que quiere anular el pago?","Alerta",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                estado = EstadoPago.Anulado;
                MessageBox.Show("Se anuló el pago.");
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnPagoJusto_Click(object sender, EventArgs e)
        {
            double deuda = NVentas.CalcularDeuda(idVenta);
            txtDeuda.Text = deuda.ToString();
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
    }
}

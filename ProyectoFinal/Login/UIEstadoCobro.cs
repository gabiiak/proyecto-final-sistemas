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
    public partial class UIEstadoCobro : Form
    {
        public int estado;
        private int idVenta;
        public UIEstadoCobro(int idVenta)
        {
            InitializeComponent();
            this.idVenta = idVenta;
            Venta venta = NVentas.GetVentaById(idVenta);
            int estadoVenta = venta.Estado_Cobro;
            decimal deuda = NVentas.CalcularDeuda(idVenta);
            labelDeuda.Text = deuda.ToString("C2");
            labelEstado.Text = GetDescripcionEstadoCobro(estadoVenta);
            if (labelEstado.Text.Equals("COBRADO", StringComparison.OrdinalIgnoreCase))
            {
                txtDeuda.ReadOnly = true;
                labelDeuda.Text = "DEUDA COBRADA";
            }
            if (labelEstado.Text.Equals("ANULADO", StringComparison.OrdinalIgnoreCase))
            {
                labelDeuda.Text = "COBRO ANULADO";
                txtDeuda.ReadOnly = true;
            }
            UIStyles.AplicarTemaAForm(this);
        }
        private void UIEstadoCobro_Load(object sender, EventArgs e)
        {
            
        }

        private void bntPagarDeuda_Click(object sender, EventArgs e)
        {
            if (labelEstado.Text.Equals("COBRADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue cobrada y no puede cambiarse su estado.");
                return;
            }
            if (labelEstado.Text.Equals("ANULADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue anulada y no puede cambiarse su estado. Intente registrando otra venta.");
                return;
            }
            decimal deuda = NVentas.CalcularDeuda(idVenta);
            //decimal ingresado = decimal.Parse(txtDeuda.Text);
            //try parse se fija que no ingrese otra cosa que no sea un num.
            if (!decimal.TryParse(txtDeuda.Text, out decimal ingresado) || ingresado <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }
            decimal aux = deuda - ingresado;
            if (ingresado >= deuda || aux < 0.1m)
            {
                decimal vuelto = ingresado - deuda;
                NVentas.CambiarMontoRecibido(idVenta, deuda); // acumula solo lo que faltaba
                estado = EstadoCobro.Cobrado;
                //if (vuelto > 0)MessageBox.Show($"Vuelto: {vuelto:C2}");
            }
            else
            {
                DialogResult resultado = MessageBox.Show($"Con el monto está cancelando parte de la deuda. El monto final a cobrar será {aux.ToString("C2")}", "Alerta",MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    NVentas.CambiarMontoRecibido(idVenta, ingresado); // cobro parcial
                    estado = EstadoCobro.Pendiente;
                } else { return; }
                
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {
            if (labelEstado.Text.Equals("COBRADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue cobrada y no puede cambiarse su estado.");
                return;
            }
            if (labelEstado.Text.Equals("ANULADO", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La deuda ya fue anulada y no puede cambiarse su estado. Intente registrando otra venta.");
                return;
            }
            DialogResult result = MessageBox.Show("Seguro que quiere anular el cobro?","Alerta",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                estado = EstadoCobro.Anulado;
                MessageBox.Show("Se anuló el cobro.");
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnPagoJusto_Click(object sender, EventArgs e)
        {
            decimal deuda = NVentas.CalcularDeuda(idVenta);
            txtDeuda.Text = deuda.ToString();
        }
        private string GetDescripcionEstadoCobro(int estado)
        {
            switch (estado)
            {
                case EstadoCobro.Anulado: return "ANULADO";
                case EstadoCobro.Pendiente: return "PENDIENTE";
                case EstadoCobro.Cobrado: return "COBRADO";
                default: return "DESCONOCIDO";
            }
        }

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => UIStyles.PintarPanelRedondeado(sender, e);
    }
}

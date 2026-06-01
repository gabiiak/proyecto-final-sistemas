using Modelos;
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
    public partial class UIOrderState : Form
    {
        public int estado = EstadoPedido.Preparacion;
        public UIOrderState()
        {
            InitializeComponent();
        }
        public int retornarEstado() { return estado; }

        private void UIOrderState_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estado = EstadoPedido.Preparacion;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            estado = EstadoPedido.Listo;
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            estado = EstadoPedido.Cancelado;
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            estado = EstadoPedido.EnViaje;
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            estado = EstadoPedido.Entregado;
            this.DialogResult = DialogResult.OK;
        }
    }
}

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
    public partial class UIEstadoPedido : Form
    {
        public int estado = EstadoPedido.Preparacion;
        public UIEstadoPedido()
        {
            InitializeComponent();

            ConfigurarBotonEstado(this.button1, "PREPARACIÓN",
                new System.Drawing.Point(20, 80),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 0);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // LISTO — verde
            ConfigurarBotonEstado(this.button2, "LISTO",
                new System.Drawing.Point(20, 136),
                //System.Drawing.Color.FromArgb(39, 80, 10),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 1);
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // VIAJANDO — naranja
            ConfigurarBotonEstado(this.button4, "VIAJANDO",
                new System.Drawing.Point(20, 192),
                //System.Drawing.Color.FromArgb(99, 56, 6),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 2);
            this.button4.Click += new System.EventHandler(this.button4_Click);

            // ENTREGADO — verde oscuro (estado final positivo)
            ConfigurarBotonEstado(this.button5, "ENTREGADO",
                new System.Drawing.Point(20, 248),
                //System.Drawing.Color.FromArgb(20, 60, 20),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 3);
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // CANCELADO — rojo (estado final negativo, separado visualmente)
            ConfigurarBotonEstado(this.button3, "CANCELADO",
                new System.Drawing.Point(20, 320),
                System.Drawing.Color.FromArgb(150, 30, 30),
                System.Drawing.Color.White, 4);
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.button3.Click += new System.EventHandler(this.button3_Click);
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

        private void ConfigurarBotonEstado(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, System.Drawing.Color backColor,
            System.Drawing.Color foreColor, int tabIndex)
            => UIStyles.ConfigurarBotonEstado(btn, texto, ubicacion, backColor, foreColor, tabIndex);
    }
}

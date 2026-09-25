using Modelos;
using System;
using System.Windows.Forms;

namespace Login
{
    public partial class UIEstadoTransporte : Form
    {
        // Estado con el que se abrió la pantalla (el que ya tenía el transporte).
        private readonly int estadoActual;

        // Estado elegido por el usuario (lo que se retorna a UIListaTransportes).
        public int estado;

        public UIEstadoTransporte(int estadoActual)
        {
            InitializeComponent();
            this.estadoActual = estadoActual;
            this.estado = estadoActual;

            ConfigurarBotonEstado(this.btnProgramado, "PROGRAMADO",
                new System.Drawing.Point(20, 80),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 0);
            this.btnProgramado.Click += new System.EventHandler(this.btnProgramado_Click);

            // EN TRÁNSITO
            ConfigurarBotonEstado(this.btnEnTransito, "EN TRÁNSITO",
                new System.Drawing.Point(20, 136),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 1);
            this.btnEnTransito.Click += new System.EventHandler(this.btnEnTransito_Click);

            // ENTREGADO — estado final positivo
            ConfigurarBotonEstado(this.btnEntregado, "ENTREGADO",
                new System.Drawing.Point(20, 192),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 2);
            this.btnEntregado.Click += new System.EventHandler(this.btnEntregado_Click);

            // CANCELADO — estado final negativo, separado visualmente
            ConfigurarBotonEstado(this.btnCancelado, "CANCELADO",
                new System.Drawing.Point(20, 264),
                System.Drawing.Color.FromArgb(150, 30, 30),
                System.Drawing.Color.White, 3);
            this.btnCancelado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnCancelado.Click += new System.EventHandler(this.btnCancelado_Click);
        }

        public int retornarEstado() { return estado; }

        private void UITransporteState_Load(object sender, EventArgs e)
        {
            // Deshabilitamos el botón del estado con el que ya está el transporte,
            // para que quede claro cuál es el estado actual y no se pueda "elegir" el mismo.
            Button btnActual = ObtenerBotonDeEstado(estadoActual);
            if (btnActual != null)
            {
                btnActual.Enabled = false;
                btnActual.Text += " (ACTUAL)";
            }
        }

        private Button ObtenerBotonDeEstado(int estadoBuscado)
        {
            if (estadoBuscado == EstadoTransporte.programado) return btnProgramado;
            if (estadoBuscado == EstadoTransporte.EnTransito) return btnEnTransito;
            if (estadoBuscado == EstadoTransporte.Entregado) return btnEntregado;
            if (estadoBuscado == EstadoTransporte.cancelado) return btnCancelado;
            return null;
        }

        private void btnProgramado_Click(object sender, EventArgs e)
        {
            estado = EstadoTransporte.programado;
            this.DialogResult = DialogResult.OK;
        }

        private void btnEnTransito_Click(object sender, EventArgs e)
        {
            estado = EstadoTransporte.EnTransito;
            this.DialogResult = DialogResult.OK;
        }

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            estado = EstadoTransporte.Entregado;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelado_Click(object sender, EventArgs e)
        {
            estado = EstadoTransporte.cancelado;
            this.DialogResult = DialogResult.OK;
        }

        private void ConfigurarBotonEstado(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, System.Drawing.Color backColor,
            System.Drawing.Color foreColor, int tabIndex)
            => UIStyles.ConfigurarBotonEstado(btn, texto, ubicacion, backColor, foreColor, tabIndex);
    }
}
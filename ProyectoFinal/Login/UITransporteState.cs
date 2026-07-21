using Modelos;
using System;
using System.Windows.Forms;

namespace Login
{
    public partial class UITransporteState : Form
    {
        // Estado con el que se abrió la pantalla (el que ya tenía el transporte).
        private readonly int estadoActual;

        // Estado elegido por el usuario (lo que se retorna a UIListaTransportes).
        public int estado;

        public UITransporteState(int estadoActual)
        {
            InitializeComponent();
            this.estadoActual = estadoActual;
            this.estado = estadoActual;
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
    }
}
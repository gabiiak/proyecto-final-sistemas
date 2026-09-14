using Modelos;
using System;
using System.Windows.Forms;

namespace Login
{
    public partial class UIEstadoTanda : Form
    {
        public int estado = EstadoTanda.Pendiente;

        public UIEstadoTanda()
        {
            InitializeComponent();
        }

        public UIEstadoTanda(int estadoActual) : this()
        {
            estado = estadoActual;
        }

        public int RetornarEstado() => estado;

        private void UIEstadoTanda_Load(object sender, EventArgs e) { }

        private void btnPendiente_Click(object sender, EventArgs e)
        {
            estado = EstadoTanda.Pendiente;
            this.DialogResult = DialogResult.OK;
        }

        private void btnEnProceso_Click(object sender, EventArgs e)
        {
            estado = EstadoTanda.EnProceso;
            this.DialogResult = DialogResult.OK;
        }

        private void btnTerminada_Click(object sender, EventArgs e)
        {
            estado = EstadoTanda.Terminada;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelada_Click(object sender, EventArgs e)
        {
            estado = EstadoTanda.Cancelada;
            this.DialogResult = DialogResult.OK;
        }
    }
}
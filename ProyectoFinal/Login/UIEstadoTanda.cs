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

            ConfigurarBotonEstado(this.btnPendiente, "PENDIENTE", new System.Drawing.Point(20, 80), System.Drawing.Color.FromArgb(24, 95, 165), System.Drawing.Color.White, 0);
            this.btnPendiente.Click += new System.EventHandler(this.btnPendiente_Click);

            ConfigurarBotonEstado(this.btnEnProceso, "EN PROCESO", new System.Drawing.Point(20, 136), System.Drawing.Color.FromArgb(24, 95, 165), System.Drawing.Color.White, 1);
            this.btnEnProceso.Click += new System.EventHandler(this.btnEnProceso_Click);

            ConfigurarBotonEstado(this.btnTerminada, "TERMINADA", new System.Drawing.Point(20, 192), System.Drawing.Color.FromArgb(24, 95, 165), System.Drawing.Color.White, 2);
            this.btnTerminada.Click += new System.EventHandler(this.btnTerminada_Click);

            ConfigurarBotonEstado(this.btnCancelada, "CANCELADA", new System.Drawing.Point(20, 260), System.Drawing.Color.FromArgb(150, 30, 30), System.Drawing.Color.White, 3);
            this.btnCancelada.Click += new System.EventHandler(this.btnCancelada_Click);
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

        private void ConfigurarBotonEstado(System.Windows.Forms.Button btn, string texto, System.Drawing.Point ubicacion, System.Drawing.Color backColor, System.Drawing.Color foreColor, int tabIndex)
            => UIStyles.ConfigurarBotonEstado(btn, texto, ubicacion, backColor, foreColor, tabIndex);
    }
}
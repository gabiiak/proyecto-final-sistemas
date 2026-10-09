using Modelos;
using Negocio;
using System;
using System.Windows.Forms;

namespace Login
{
    public partial class UIEstadoCompra : Form
    {
        public int estado;
        private int estadoActual;

        public UIEstadoCompra(int estadoActual)
        {
            InitializeComponent();
            this.estadoActual = estadoActual;
            this.estado = estadoActual;

            lblSubtulo.Text = "Estado actual: " + GetDescripcionEstado(estadoActual) + "  →  cambiar a:";

            // ACEPTADA — azul
            ConfigurarBotonEstado(this.btnAceptada, "ACEPTADA",
                new System.Drawing.Point(20, 80),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 0);
            this.btnAceptada.Click += new System.EventHandler(this.btnAceptada_Click);

            // PAGADA — azul
            ConfigurarBotonEstado(this.btnPagada, "PAGADA",
                new System.Drawing.Point(20, 136),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 1);
            this.btnPagada.Click += new System.EventHandler(this.btnPagada_Click);

            // ENVIADA — azul
            ConfigurarBotonEstado(this.btnEnviada, "ENVIADA",
                new System.Drawing.Point(20, 192),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 2);
            this.btnEnviada.Click += new System.EventHandler(this.btnEnviada_Click);

            // ENTREGADA — azul (estado final positivo, suma stock de insumos)
            ConfigurarBotonEstado(this.btnEntregada, "ENTREGADA",
                new System.Drawing.Point(20, 248),
                System.Drawing.Color.FromArgb(24, 95, 165),
                System.Drawing.Color.White, 3);
            this.btnEntregada.Click += new System.EventHandler(this.btnEntregada_Click);

            // CANCELADA — rojo (estado final negativo, separado visualmente)
            ConfigurarBotonEstado(this.btnCancelada, "CANCELADA",
                new System.Drawing.Point(20, 320),
                System.Drawing.Color.FromArgb(150, 30, 30),
                System.Drawing.Color.White, 4);
            this.btnCancelada.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnCancelada.Click += new System.EventHandler(this.btnCancelada_Click);

            // Solo quedan habilitadas las transiciones válidas desde el estado actual
            HabilitarSiEsValido(this.btnAceptada, EstadoCompra.Aceptada);
            HabilitarSiEsValido(this.btnPagada, EstadoCompra.Pagado);
            HabilitarSiEsValido(this.btnEnviada, EstadoCompra.Enviada);
            HabilitarSiEsValido(this.btnEntregada, EstadoCompra.Entregada);
            HabilitarSiEsValido(this.btnCancelada, EstadoCompra.Cancelada);
        }

        public int retornarEstado() { return estado; }

        private void UIEstadoCompra_Load(object sender, EventArgs e)
        {

        }

        private void HabilitarSiEsValido(System.Windows.Forms.Button btn, int nuevoEstado)
        {
            if (NCompras.EsTransicionValida(estadoActual, nuevoEstado)) return;

            btn.Enabled = false;
            btn.BackColor = System.Drawing.Color.FromArgb(214, 218, 224);
            btn.ForeColor = System.Drawing.Color.FromArgb(150, 154, 160);
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 204, 210);
            btn.Cursor = Cursors.Default;
        }

        private string GetDescripcionEstado(int e)
        {
            switch (e)
            {
                case EstadoCompra.Emitida: return "EMITIDA";
                case EstadoCompra.Aceptada: return "ACEPTADA";
                case EstadoCompra.Pagado: return "PAGADA";
                case EstadoCompra.Enviada: return "ENVIADA";
                case EstadoCompra.Entregada: return "ENTREGADA";
                case EstadoCompra.Cancelada: return "CANCELADA";
                default: return "DESCONOCIDO";
            }
        }

        private void btnAceptada_Click(object sender, EventArgs e)
        {
            estado = EstadoCompra.Aceptada;
            this.DialogResult = DialogResult.OK;
        }

        private void btnPagada_Click(object sender, EventArgs e)
        {
            estado = EstadoCompra.Pagado;
            this.DialogResult = DialogResult.OK;
        }

        private void btnEnviada_Click(object sender, EventArgs e)
        {
            estado = EstadoCompra.Enviada;
            this.DialogResult = DialogResult.OK;
        }

        private void btnEntregada_Click(object sender, EventArgs e)
        {
            estado = EstadoCompra.Entregada;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelada_Click(object sender, EventArgs e)
        {
            estado = EstadoCompra.Cancelada;
            this.DialogResult = DialogResult.OK;
        }

        private void ConfigurarBotonEstado(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, System.Drawing.Color backColor,
            System.Drawing.Color foreColor, int tabIndex)
            => UIStyles.ConfigurarBotonEstado(btn, texto, ubicacion, backColor, foreColor, tabIndex);
    }
}
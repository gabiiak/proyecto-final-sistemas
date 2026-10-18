using Modelos;
using Negocio;
using System;
using System.Windows.Forms;

namespace Login
{
    public partial class UIEditarFechasCompra : Form
    {
        private int idCompra;

        public UIEditarFechasCompra(int idCompra)
        {
            InitializeComponent();
            this.idCompra = idCompra;

            ConfigurarLabel(this.lblFecha, "Fecha de compra",
                new System.Drawing.Point(16, 72));
            ConfigurarLabel(this.lblFechaRecepcion, "Fecha de recepción",
                new System.Drawing.Point(16, 144));

            ConfigurarBotonPrimario(this.btnGuardar, "Guardar",
                new System.Drawing.Point(20, 216), 3);
            this.btnGuardar.Size = new System.Drawing.Size(200, 40);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            ConfigurarBotonSecundario(this.btnCancelar, "Cancelar",
                new System.Drawing.Point(232, 216), 4);
            this.btnCancelar.Size = new System.Drawing.Size(108, 40);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        }

        private void UIEditarFechasCompra_Load(object sender, EventArgs e)
        {
            Compra compra = NCompras.GetCompraById(idCompra);
            if (compra == null)
            {
                MessageBox.Show("No se encontró la compra seleccionada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            dtpFecha.Value = compra.Fecha.Date;
            if (compra.FechaRecepcion.HasValue)
            {
                dtpFechaRecepcion.Value = compra.FechaRecepcion.Value.Date;
                dtpFechaRecepcion.Checked = true;
            }
            else
            {
                dtpFechaRecepcion.Checked = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;
            DateTime? fechaRecepcion = dtpFechaRecepcion.Checked
                ? (DateTime?)dtpFechaRecepcion.Value.Date
                : null;

            try
            {
                NCompras.ActualizarFechas(idCompra, fecha, fechaRecepcion);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));
    }
}

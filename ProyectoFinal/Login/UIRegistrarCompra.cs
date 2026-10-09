using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegistrarCompra : Form
    {
        private List<DetalleCompra> detalleCompras = new List<DetalleCompra>();
        private Dictionary<int, string> nombresInsumos = new Dictionary<int, string>();
        public Compra compraEnMemoria = new Compra();
        private decimal total;

        public UIRegistrarCompra()
        {
            InitializeComponent();
            dgvCompra_DetalleCompra.AllowUserToAddRows = false;

            ConfigurarLabel(this.lblProveedor, "Proveedor", new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbProveedor, new System.Drawing.Point(16, 36), new System.Drawing.Size(448, 32), 0);

            ConfigurarLabel(this.lblFecha, "Fecha de compra", new System.Drawing.Point(16, 84));
            ConfigurarTextBox(this.txtFecha, new System.Drawing.Point(16, 104), new System.Drawing.Size(448, 32), 1);

            ConfigurarBotonPrimario(this.btnAgregarDetalle, "Agregar detalle",
                new System.Drawing.Point(20, 460), 2);
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);

            ConfigurarBotonSecundario(this.btnQuitarDetalle, "Quitar detalle",
                new System.Drawing.Point(176, 460), 3);
            this.btnQuitarDetalle.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnQuitarDetalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnQuitarDetalle.Click += new System.EventHandler(this.btnQuitarDetalle_Click);

            ConfigurarLabel(this.lblPagoRealizado, "Pago realizado ($)",
                new System.Drawing.Point(260, 10));
            ConfigurarTextBox(this.txtPagoRealizado,
                new System.Drawing.Point(260, 28), new System.Drawing.Size(120, 32), 4);

            ConfigurarBotonSecundario(this.btnPagoTotal, "Pago total",
                new System.Drawing.Point(392, 28), 5);
            this.btnPagoTotal.Size = new System.Drawing.Size(72, 32);
            this.btnPagoTotal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnPagoTotal.Click += new System.EventHandler(this.btnPagoTotal_Click);

            ConfigurarBotonPrimario(this.btnRegistrarCompra, "Registrar Compra",
                new System.Drawing.Point(20, 624), 6);
            this.btnRegistrarCompra.Size = new System.Drawing.Size(480, 44);
            this.btnRegistrarCompra.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarCompra.Click += new System.EventHandler(this.btnRegistrarCompra_Click);
        }

        private void UIRegistrarCompra_Load(object sender, EventArgs e)
        {
            try
            {
                var proveedores = NProveedores.GetAll();
                cbProveedor.DataSource = null;
                cbProveedor.DataSource = proveedores;
                cbProveedor.DisplayMember = "Nombre";
                cbProveedor.ValueMember = "IdProveedor";

                nombresInsumos = NInsumos.GetAllInsumos().ToDictionary(i => i.Id, i => i.Nombre);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            ActualizarDataGridView();
            labelTotal.Text = total.ToString("N2");
            txtFecha.ReadOnly = false;
            txtFecha.BorderStyle = BorderStyle.FixedSingle;
            txtFecha.Text = GetFecha().ToString("dd-MM-yyyy");
            txtPagoRealizado.Text = "0";
        }

        private string GetNombreInsumo(int id)
        {
            return nombresInsumos.TryGetValue(id, out string nombre) ? nombre : "Desconocido";
        }

        public void ActualizarDataGridView()
        {
            dgvCompra_DetalleCompra.Rows.Clear();
            foreach (DetalleCompra detalle in detalleCompras)
            {
                dgvCompra_DetalleCompra.Rows.Add(
                    GetNombreInsumo(detalle.IdInsumo),
                    detalle.Cantidad,
                    detalle.Subtotal.ToString("C2")
                );
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            UIRegistrarDetalleCompra registrarDetalle = new UIRegistrarDetalleCompra();
            if (registrarDetalle.ShowDialog() == DialogResult.OK)
            {
                foreach (DetalleCompra detalle in registrarDetalle.DetalleCompras)
                {
                    detalleCompras.Add(detalle);
                }
                ActualizarDataGridView();
                total = NCompras.CalcularTotal(detalleCompras);
                labelTotal.Text = total.ToString("N2");
            }
        }

        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvCompra_DetalleCompra.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un detalle para quitar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int indice = dgvCompra_DetalleCompra.SelectedRows[0].Index;
            detalleCompras.RemoveAt(indice);
            total = NCompras.CalcularTotal(detalleCompras);
            labelTotal.Text = total.ToString("N2");
            ActualizarDataGridView();
        }

        private void btnPagoTotal_Click(object sender, EventArgs e)
        {
            txtPagoRealizado.Text = total.ToString("F2");
        }

        private DateTime GetFecha()
        {
            return DateTime.Now.Date;
        }

        private void RegistrarCompraEnBaseDeDatos(decimal pagado)
        {
            try
            {
                var proveedorSeleccionado = (Proveedor)cbProveedor.SelectedItem;
                DateTime fecha = DateTime.ParseExact(txtFecha.Text, "dd-MM-yyyy", null);
                pagado = Math.Round(pagado, 2);
                total = Math.Round(total, 2);
                decimal montoPagado = (total - pagado <= 0.01m) ? total : pagado;

                compraEnMemoria = new Compra
                {
                    IdProveedor = proveedorSeleccionado.IdProveedor,
                    Fecha = fecha,
                    Estado = EstadoCompra.Emitida,
                    TotalCompra = (double)total,
                    montoPagado = (double)montoPagado
                };

                int idCompra = NCompras.CreateCompra(compraEnMemoria);
                compraEnMemoria.IdCompra = idCompra;

                foreach (DetalleCompra detalle in detalleCompras)
                {
                    detalle.IdCompra = idCompra;
                    NDetalleCompras.CreateDetalleCompra(detalle);
                }

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

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(txtFecha.Text, "dd-MM-yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                MessageBox.Show("Formato de fecha inválido. Use dd-MM-yyyy.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                NCompras.ValidarFechaCompra(fecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbProveedor.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (detalleCompras.Count == 0)
            {
                MessageBox.Show("Debe registrar al menos un insumo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPagoRealizado.Text))
            {
                MessageBox.Show("Ingrese el monto pagado (puede ser 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPagoRealizado.Text, out decimal pagado) || pagado < 0)
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pagado - total > 0.01m)
            {
                MessageBox.Show("El pago no puede superar el total de la compra.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (total - pagado > 0.01m)
            {
                decimal deuda = total - pagado;
                DialogResult resultado = MessageBox.Show(
                    "Se registrará la compra como EMITIDA con un pago de " + pagado.ToString("C2") +
                    ". Quedará una deuda de " + deuda.ToString("C2") + " con el proveedor.",
                    "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resultado == DialogResult.Yes)
                    RegistrarCompraEnBaseDeDatos(pagado);
            }
            else
            {
                DialogResult resultado = MessageBox.Show(
                    "Se registrará la compra como EMITIDA con el pago completo. " +
                    "Una vez aceptada por el proveedor podrá pasar a PAGADA.",
                    "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                    RegistrarCompraEnBaseDeDatos(pagado);
            }
        }

        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(220, 18));

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex);

        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void pnlPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => UIStyles.PintarPanelRedondeado(sender, e);
    }
}
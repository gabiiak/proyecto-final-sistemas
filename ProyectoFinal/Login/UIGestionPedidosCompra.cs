using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Login
{
    public partial class UIGestionPedidosCompra : Form
    {
        private int idCompra;

        public UIGestionPedidosCompra()
        {
            InitializeComponent();
            dgvPedidos.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvPedidos);

            ConfigurarBotonPrimario(this.btnEmitirPedido, "Emitir pedido",
                new System.Drawing.Point(20, 480), 0);
            this.btnEmitirPedido.Size = new System.Drawing.Size(160, 36);
            this.btnEmitirPedido.Click += new System.EventHandler(this.btnEmitirPedido_Click);

            ConfigurarBotonSecundario(this.btnAceptar, "Aceptar",
                new System.Drawing.Point(190, 480), 1);
            this.btnAceptar.Size = new System.Drawing.Size(140, 36);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            ConfigurarBotonSecundario(this.btnCancelar, "Cancelar",
                new System.Drawing.Point(340, 480), 2);
            this.btnCancelar.Size = new System.Drawing.Size(140, 36);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(150, 30, 30);
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 180, 180);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(490, 480), 3);
            this.btnModificar.Size = new System.Drawing.Size(140, 36);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnVerPdf, "Ver PDF",
                new System.Drawing.Point(20, 524), 4);
            this.btnVerPdf.Size = new System.Drawing.Size(160, 36);
            this.btnVerPdf.Click += new System.EventHandler(this.btnVerPdf_Click);

            ConfigurarBotonSecundario(this.btnRegistrarManual, "Registrar compra manual",
                new System.Drawing.Point(190, 524), 5);
            this.btnRegistrarManual.Size = new System.Drawing.Size(230, 36);
            this.btnRegistrarManual.Click += new System.EventHandler(this.btnRegistrarManual_Click);

            ConfigurarBotonFantasma(this.btnCerrar, "Cerrar",
                new System.Drawing.Point(720, 524), 6);
            this.btnCerrar.Size = new System.Drawing.Size(160, 36);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
        }

        private void UIGestionPedidosCompra_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            idCompra = 0;
            try
            {
                List<Compra> pedidos = NCompras.GetAllCompras()
                    .Where(c => c.IdPresupuesto != null &&
                        (c.Estado == EstadoCompra.Emitida ||
                         c.Estado == EstadoCompra.Aceptada ||
                         c.Estado == EstadoCompra.Cancelada))
                    .ToList();

                Dictionary<int, string> nombresProveedores = NProveedores.GetAll()
                    .ToDictionary(p => p.IdProveedor, p => p.Nombre);

                dgvPedidos.Rows.Clear();
                foreach (Compra compra in pedidos)
                {
                    string proveedor = nombresProveedores.ContainsKey(compra.IdProveedor)
                        ? nombresProveedores[compra.IdProveedor] : "Desconocido";

                    int indice = dgvPedidos.Rows.Add(
                        compra.IdCompra,
                        proveedor,
                        compra.Fecha,
                        compra.TotalCompra,
                        GetDescripcionEstado(compra.Estado));
                    dgvPedidos.Rows[indice].Tag = compra;
                }
                dgvPedidos.Refresh();
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

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;
            object valor = dgvPedidos.CurrentRow.Cells["Numero"].Value;
            int id;
            if (valor != null && int.TryParse(valor.ToString(), out id))
                idCompra = id;
        }

        private void dgvPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            Compra compra = dgvPedidos.Rows[e.RowIndex].Tag as Compra;
            if (compra == null) return;

            if (compra.Estado == EstadoCompra.Aceptada)
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(198, 239, 206);
                e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 70, 32);
            }
            else
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 199, 206);
                e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(155, 0, 0);
            }

            if (dgvPedidos.Columns[e.ColumnIndex].Name == "Total" && e.Value != null)
            {
                e.Value = "$" + e.Value;
                e.FormattingApplied = true;
            }
        }

        private bool TryGetSeleccion(out int id)
        {
            id = idCompra;
            if (id <= 0)
            {
                MessageBox.Show("Debe seleccionar un pedido.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }

        private void btnEmitirPedido_Click(object sender, EventArgs e)
        {
            UIRegistrarPedidoCompra registrar = new UIRegistrarPedidoCompra();
            registrar.ShowDialog();
            ActualizarGrilla();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            try
            {
                NCompras.CambiarEstado(id, EstadoCompra.Aceptada);
                MessageBox.Show("Pedido aceptado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            DialogResult confirmacion = MessageBox.Show("¿Confirma cancelar el pedido seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) return;

            try
            {
                NCompras.CambiarEstado(id, EstadoCompra.Cancelada);
                MessageBox.Show("Pedido cancelado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            UIRegistrarPedidoCompra registrar = new UIRegistrarPedidoCompra(id);
            registrar.ShowDialog();
            ActualizarGrilla();
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            try
            {
                Compra compra = NCompras.GetCompraById(id);
                if (compra == null)
                {
                    MessageBox.Show("No se encontró el pedido seleccionado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<DetalleCompra> detalles = NDetalleCompras.GetDetalleByIdCompra(id);
                Dictionary<int, string> nombresInsumos = NInsumos.GetAllInsumos()
                    .ToDictionary(i => i.Id, i => i.Nombre);

                string proveedor = NProveedores.GetAll()
                    .Where(p => p.IdProveedor == compra.IdProveedor)
                    .Select(p => p.Nombre)
                    .FirstOrDefault() ?? "Desconocido";

                UIRegistrarPedidoCompra.GenerarPdfPedidoCompra(compra, detalles, proveedor, nombresInsumos);
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

        private void btnRegistrarManual_Click(object sender, EventArgs e)
        {
            UIRegistrarCompra registrar = new UIRegistrarCompra();
            registrar.ShowDialog();
            ActualizarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetDescripcionEstado(int estado)
        {
            switch (estado)
            {
                case EstadoCompra.Emitida: return "EMITIDA";
                case EstadoCompra.Aceptada: return "ACEPTADA";
                case EstadoCompra.Enviada: return "ENVIADA";
                case EstadoCompra.Recibida: return "RECIBIDA";
                case EstadoCompra.Cancelada: return "CANCELADA";
                default: return "DESCONOCIDO";
            }
        }

        // ---------- Estilos ----------
        private void ConfigurarBotonPrimario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonPrimario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonSecundario(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonSecundario(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(140, 36));

        private void ConfigurarBotonFantasma(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point ubicacion, int tabIndex)
            => UIStyles.ConfigurarBotonFantasma(btn, texto, ubicacion, tabIndex, new System.Drawing.Size(200, 30));
    }
}

using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    public partial class UIGestionPresupuestos : Form
    {
        private List<Presupuesto> listadoPresupuestosTotales = new List<Presupuesto>();

        public UIGestionPresupuestos()
        {
            InitializeComponent();
            dgvPresupuestos.AllowUserToAddRows = false;
            UIStyles.ConfigurarDataGrid(dgvPresupuestos);

            ConfigurarBotonPrimario(this.btnRegistrarSolicitud, "Registrar solicitud",
                new System.Drawing.Point(16, 36), 0);
            this.btnRegistrarSolicitud.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarSolicitud.Click += new System.EventHandler(this.btnRegistrarSolicitud_Click);

            ConfigurarBotonPrimario(this.btnRegistrarPresupuesto, "Registrar presupuesto",
                new System.Drawing.Point(16, 84), 1);
            this.btnRegistrarPresupuesto.Size = new System.Drawing.Size(288, 40);
            this.btnRegistrarPresupuesto.Click += new System.EventHandler(this.btnRegistrarPresupuesto_Click);

            ConfigurarBotonSecundario(this.btnVerDetalle, "Ver detalle",
                new System.Drawing.Point(16, 136), 2);
            this.btnVerDetalle.Size = new System.Drawing.Size(138, 32);
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);

            ConfigurarBotonSecundario(this.btnModificar, "Modificar",
                new System.Drawing.Point(166, 136), 3);
            this.btnModificar.Size = new System.Drawing.Size(138, 32);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);

            ConfigurarBotonSecundario(this.btnEliminar, "Eliminar",
                new System.Drawing.Point(16, 176), 4);
            this.btnEliminar.Size = new System.Drawing.Size(138, 32);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            ConfigurarBotonSecundario(this.btnAceptar, "Aceptar",
                new System.Drawing.Point(166, 176), 5);
            this.btnAceptar.Size = new System.Drawing.Size(138, 32);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            ConfigurarBotonSecundario(this.btnRechazar, "Rechazar",
                new System.Drawing.Point(16, 216), 6);
            this.btnRechazar.Size = new System.Drawing.Size(138, 32);
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);

            ConfigurarBotonFantasma(this.btnPresupuestosEliminados, "Ver presupuestos eliminados",
                new System.Drawing.Point(16, 264), 7);
            this.btnPresupuestosEliminados.Size = new System.Drawing.Size(288, 30);
            this.btnPresupuestosEliminados.Click += new System.EventHandler(this.btnPresupuestosEliminados_Click);

            ConfigurarLabel(this.lblFiltroProveedor, "Proveedor", new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbProveedorFiltro, new System.Drawing.Point(16, 38),
                new System.Drawing.Size(250, 28), 8);

            ConfigurarLabel(this.lblNumeroCotizacion, "N° de cotización", new System.Drawing.Point(300, 16));
            ConfigurarTextBox(this.txtNumeroCotizacion, new System.Drawing.Point(300, 38),
                new System.Drawing.Size(160, 28), 9);

            ConfigurarBotonPrimario(this.btnFiltrar, "Filtrar",
                new System.Drawing.Point(490, 36), 10);
            this.btnFiltrar.Size = new System.Drawing.Size(120, 32);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            ConfigurarBotonFantasma(this.btnDesfiltrar, "Quitar filtros",
                new System.Drawing.Point(490, 80), 11);
            this.btnDesfiltrar.Size = new System.Drawing.Size(120, 28);
            this.btnDesfiltrar.Click += new System.EventHandler(this.btnDesfiltrar_Click);
            UIStyles.AplicarTemaAForm(this);
        }

        private void UIGestionPresupuestos_Load(object sender, EventArgs e)
        {
            labelId.Text = "";
            CargarFiltroProveedores();
            ActualizarDataGridView();
        }

        // ---------- Carga de datos ----------
        private void CargarFiltroProveedores()
        {
            var proveedores = NProveedores.GetAll();
            var listaCombo = new List<Proveedor>(proveedores);
            listaCombo.Insert(0, new Proveedor { IdProveedor = 0, Nombre = "Todos" });
            cbProveedorFiltro.DataSource = listaCombo;
            cbProveedorFiltro.DisplayMember = "Nombre";
            cbProveedorFiltro.ValueMember = "IdProveedor";
        }

        private void ActualizarDataGridView()
        {
            try
            {
                listadoPresupuestosTotales = NPresupuesto.GetAll();
                MostrarEnGrilla(listadoPresupuestosTotales);
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

        private void MostrarEnGrilla(List<Presupuesto> lista)
        {
            dgvPresupuestos.Rows.Clear();
            foreach (Presupuesto presupuesto in lista)
            {
                dgvPresupuestos.Rows.Add(
                    presupuesto.IdPresupuesto,
                    presupuesto.IdSolicitud,
                    presupuesto.NombreProveedor,
                    presupuesto.Fecha,
                    presupuesto.Total,
                    UIRegistrarSolicitudCotizacion.GetDescripcionEstado(presupuesto.EstadoSolicitud)
                );
            }
            dgvPresupuestos.Refresh();
        }

        private void dgvPresupuestos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPresupuestos.CurrentRow == null) return;
            labelId.Text = dgvPresupuestos.CurrentRow.Cells["IdPresupuesto"].Value?.ToString();
        }

        private bool TryGetSeleccion(out int id)
        {
            id = 0;
            if (string.IsNullOrEmpty(labelId.Text) || !int.TryParse(labelId.Text, out id))
            {
                MessageBox.Show("Debe seleccionar un presupuesto.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }

        // ---------- Acciones ----------
        private void btnRegistrarSolicitud_Click(object sender, EventArgs e)
        {
            UIRegistrarSolicitudCotizacion registrar = new UIRegistrarSolicitudCotizacion();
            registrar.ShowDialog();
            ActualizarDataGridView();
        }

        private void btnRegistrarPresupuesto_Click(object sender, EventArgs e)
        {
            UIRegistrarPresupuesto registrar = new UIRegistrarPresupuesto();
            registrar.ShowDialog();
            ActualizarDataGridView();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            UIConsultarPresupuesto consulta = new UIConsultarPresupuesto(id);
            consulta.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            try
            {
                Presupuesto presupuesto = NPresupuesto.GetById(id);
                if (presupuesto == null)
                {
                    MessageBox.Show("El presupuesto no existe.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (presupuesto.EstadoSolicitud != EstadoSolicitudCotizacion.Recibida)
                {
                    MessageBox.Show("Solo se puede modificar un presupuesto mientras la solicitud está recibida.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                UIRegistrarPresupuesto modificar = new UIRegistrarPresupuesto(id);
                modificar.ShowDialog();
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
            ActualizarDataGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            if (MessageBox.Show("¿Desea eliminar el presupuesto seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                NPresupuesto.EliminarPresupuesto(id);
                MessageBox.Show("Presupuesto eliminado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarDataGridView();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            try
            {
                NPresupuesto.AceptarPresupuesto(id);
                MessageBox.Show("La solicitud quedó ACEPTADA.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarDataGridView();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (!TryGetSeleccion(out int id)) return;

            if (MessageBox.Show("¿Desea rechazar el presupuesto seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                NPresupuesto.RechazarPresupuesto(id);
                MessageBox.Show("La solicitud quedó CANCELADA.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ActualizarDataGridView();
        }

        private void btnPresupuestosEliminados_Click(object sender, EventArgs e)
        {
            UIPresupuestosEliminados eliminados = new UIPresupuestosEliminados();
            eliminados.Show();
        }

        // ---------- Filtros ----------
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int idProveedor = 0;
            Proveedor proveedor = cbProveedorFiltro.SelectedItem as Proveedor;
            if (proveedor != null) idProveedor = proveedor.IdProveedor;

            string texto = txtNumeroCotizacion.Text.Trim();
            bool filtrarNumero = texto.Length > 0;
            int numero = 0;
            if (filtrarNumero && !int.TryParse(texto, out numero))
            {
                MessageBox.Show("El N° de cotización debe ser numérico.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Presupuesto> filtrados = new List<Presupuesto>();
            foreach (Presupuesto presupuesto in listadoPresupuestosTotales)
            {
                if (idProveedor != 0 && presupuesto.IdProveedor != idProveedor) continue;
                if (filtrarNumero && presupuesto.IdSolicitud != numero) continue;
                filtrados.Add(presupuesto);
            }

            MostrarEnGrilla(filtrados);
        }

        private void btnDesfiltrar_Click(object sender, EventArgs e)
        {
            txtNumeroCotizacion.Clear();
            if (cbProveedorFiltro.Items.Count > 0) cbProveedorFiltro.SelectedIndex = 0;
            ActualizarDataGridView();
        }

        // ---------- Estilos ----------
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto,
            System.Drawing.Point ubicacion)
            => UIStyles.ConfigurarLabel(lbl, texto, ubicacion, new System.Drawing.Size(200, 18));

        private void ConfigurarCombo(System.Windows.Forms.ComboBox cb,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarComboBox(cb, ubicacion, tamaño, tabIndex);

        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt,
            System.Drawing.Point ubicacion, System.Drawing.Size tamaño, int tabIndex)
            => UIStyles.ConfigurarTextBox(txt, ubicacion, tamaño, tabIndex);

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

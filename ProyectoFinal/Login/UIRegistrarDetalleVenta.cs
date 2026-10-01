using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Login
{
    public partial class UIRegistrarDetalleVenta : Form
    {
        private List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
        public List<DetalleVenta> DetalleVentas => detalleVentas; //lista de lectura
        decimal subTotal = 0;
        public UIRegistrarDetalleVenta()
        {
            InitializeComponent();
            ConfigurarLabel(this.lblProducto, "Producto",
                new System.Drawing.Point(16, 16));
            ConfigurarCombo(this.cbProducto,
                new System.Drawing.Point(16, 36), new System.Drawing.Size(348, 32), 0);
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);

            // Descripción (solo lectura — se llena al seleccionar producto)
            ConfigurarLabel(this.lblDescripcion, "Descripción",
                new System.Drawing.Point(16, 80));
            ConfigurarTextBox(this.txtDescripcionProducto,
                new System.Drawing.Point(16, 100), new System.Drawing.Size(348, 32), 1);
            this.txtDescripcionProducto.ReadOnly = true;
            this.txtDescripcionProducto.BackColor = System.Drawing.Color.FromArgb(230, 241, 251);
            this.txtDescripcionProducto.ForeColor = System.Drawing.Color.FromArgb(136, 135, 128);

            // Cantidad + tandas
            ConfigurarLabel(this.lblCantidad, "Cantidad",
                new System.Drawing.Point(16, 148));
            ConfigurarBotonPrimario(this.btnRegistrarDetalle, "Registrar",
                new System.Drawing.Point(20, 344), 3);
            this.btnRegistrarDetalle.Size = new System.Drawing.Size(240, 40);
            this.btnRegistrarDetalle.Click += new System.EventHandler(this.btnRegistrarDetalle_Click);

            ConfigurarBotonSecundario(this.btnSalirDetalle, "Cancelar",
                new System.Drawing.Point(272, 344), 4);
            this.btnSalirDetalle.Size = new System.Drawing.Size(128, 40);
            this.btnSalirDetalle.Click += new System.EventHandler(this.btnSalirDetalle_Click);
        }
        
        private void UIRegisterSaleDetail_Load(object sender, EventArgs e)
        {
            try
            {
                var productos = NProductos.GetAll();
                cbProducto.DataSource = null;
                cbProducto.DataSource = productos;
                cbProducto.DisplayMember = "Nombre";
                cbProducto.ValueMember = "IdProducto";
                txtDescripcionProducto.ReadOnly = true; // no permite modificar al usuario
                txtDescripcionProducto.Multiline = true; // para la descripcion
                txtDescripcionProducto.BorderStyle = BorderStyle.FixedSingle; // un poquito de diseño
                txtDescripcionProducto.Width = 205; // en el diseñador no me deja cambiar el height, es más comodo por código
                txtDescripcionProducto.Height = 60;
                Clean();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e) // para que el combobox actualice la descripcion del producto
        {
            Producto tipoProductoSeleccionado = (Producto)cbProducto.SelectedItem;
            txtDescripcionProducto.Text = tipoProductoSeleccionado.Descripcion;
            ActualizarSubTotal();
        }

        private void ActualizarSubTotal() // logica para el subtotal. todos tenían el mismo precio, por lo tanto no veía cambios...
        {
            if (cbProducto.SelectedItem != null)
            {
                Producto tipoProductoSeleccionado = (Producto)cbProducto.SelectedItem;
                int cantidadDeTandas = (int)numUpDownCantidadTandas.Value;
                subTotal = tipoProductoSeleccionado.Precio * cantidadDeTandas;
                labelSubtotal.Text = subTotal.ToString("C2");
            }
        }
        private void numUpDownCantidadTandas_ValueChanged(object sender, EventArgs e) 
        {
            ActualizarSubTotal();
        }
        private void btnRegistrarDetalle_Click(object sender, EventArgs e)
        {
            if(cbProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numUpDownCantidadTandas.Value == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Producto productoSeleccionado = (Producto)cbProducto.SelectedItem;
            
            int cantidadDeTandas = (int)numUpDownCantidadTandas.Value;
            DetalleVenta detalle = new DetalleVenta
            {
                Producto = productoSeleccionado,
                Cantidad = cantidadDeTandas,
                SubTotal = subTotal
            };
            detalleVentas.Add(detalle);
            MessageBox.Show("Se registró el detalle con éxito.", "Éxito", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;
            Clean();
        }
        private void Clean()
        {
            numUpDownCantidadTandas.Value = 0;
            subTotal = 0;
            labelSubtotal.Text = subTotal.ToString("C2");
        }

        private void btnSalirDetalle_Click(object sender, EventArgs e)
        {
            this.Close();
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

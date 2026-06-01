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
    public partial class UIRegisterSaleDetail : Form
    {
        private List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
        public List<DetalleVenta> DetalleVentas => detalleVentas; //lista de lectura
        double subTotal = 0;
        public UIRegisterSaleDetail()
        {
            InitializeComponent();
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
    }
}

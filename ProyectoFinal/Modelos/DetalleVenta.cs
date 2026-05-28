using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
        public double SubTotal { get; set; }
        public int Cantidad { get; set; }
    }
}

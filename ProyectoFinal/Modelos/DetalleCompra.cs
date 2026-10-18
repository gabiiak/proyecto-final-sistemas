using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdInsumo { get; set; }
        public decimal Cantidad { get; set; }
        public double Subtotal { get; set; }
    }
}

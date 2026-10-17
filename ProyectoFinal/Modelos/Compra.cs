using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; } //= EstadoCompra.Emitida;
        public double TotalCompra { get; set; }
        public double montoPagado { get; set; }
    }
}

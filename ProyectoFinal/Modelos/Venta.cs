using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente Cliente { get; set; }
        public MetodoPago Metodo { get; set; }
        public DateTime Fecha { get; set; } 
        public int Estado_Pedido { get; set; } //= EstadoPedido.Preparacion;
        public int Estado_Pago { get; set; } //= EstadoPago.Pendiente;
        public double Total { get; set; }

    }
}

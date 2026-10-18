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
        public int? IdPresupuesto { get; set; }        // origen (pedido); null = carga manual
        public DateTime Fecha { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public int Estado { get; set; } //= EstadoCompra.Emitida;
        public int EstadoPago { get; set; }            //= EstadoPago.Pendiente;
        public double TotalCompra { get; set; }
        public double montoPagado { get; set; }
    }
}

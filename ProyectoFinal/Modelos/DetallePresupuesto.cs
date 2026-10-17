using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetallePresupuesto
    {
        public int IdDetallePresupuesto { get; set; }
        public int IdPresupuesto { get; set; }
        public int IdInsumo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        // Solo lectura (join a Insumos).
        public string NombreInsumo { get; set; }
        public string UnidadMedidaInsumo { get; set; }
    }
}

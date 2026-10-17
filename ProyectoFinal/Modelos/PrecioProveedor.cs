using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PrecioProveedor
    {
        public int IdPrecioProveedor { get; set; }
        public int IdProveedor { get; set; }
        public int IdInsumo { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleTandaProduccion
    {
        public int IdDetalleTanda { get; set; }
        public TandaProduccion TandaProduccion { get; set; }
        public Insumo Insumo { get; set; }
        public Empleado Empleado { get; set; }
        public int CantidadProducida { get; set; }
    }
}

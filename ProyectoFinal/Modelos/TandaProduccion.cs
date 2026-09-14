using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class TandaProduccion
    {
        public int IdTanda { get; set; }
        public Producto Producto { get; set; }
        public int EstadoTanda { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
    }
}
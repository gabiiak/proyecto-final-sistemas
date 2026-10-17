using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleSolicitudCotizacion
    {
        public int IdDetalleSolicitud { get; set; }
        public int IdSolicitud { get; set; }
        public int IdInsumo { get; set; }
        public decimal Cantidad { get; set; }

        // Denormalizados para la UI y el PDF (no son columnas de la tabla).
        public string NombreInsumo { get; set; }
        public string UnidadMedidaInsumo { get; set; }
    }
}

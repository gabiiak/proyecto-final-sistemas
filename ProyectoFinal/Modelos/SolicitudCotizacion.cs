using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class SolicitudCotizacion
    {
        public int IdSolicitud { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public List<DetalleSolicitudCotizacion> Detalles { get; set; } = new List<DetalleSolicitudCotizacion>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Presupuesto
    {
        public int IdPresupuesto { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int Activo { get; set; } // 1 activo | 0 inactivo (baja lógica)

        // Solo lectura: se completan en los listados (join a SolicitudCotizacion/Proveedores).
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public int EstadoSolicitud { get; set; }

        public List<DetallePresupuesto> Detalles { get; set; } = new List<DetallePresupuesto>();
    }
}

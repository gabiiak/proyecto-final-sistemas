using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; } // <- 1 - activo | 0 - inactivo se usa al Eliminar MetodoPago
    }
}
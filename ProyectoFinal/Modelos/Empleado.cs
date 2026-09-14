using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public int Activo { get; set; }
        public int NumCuenta { get; set; }
        public DateTime FechaIngreso { get; set; }
        public double Sueldo { get; set; }
    }
}
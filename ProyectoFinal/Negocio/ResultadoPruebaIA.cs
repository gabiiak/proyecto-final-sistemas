using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class ResultadoPruebaIA
    {
        public int RegistrosEntrenamiento { get; set; }
        public int RegistrosPrueba { get; set; }

        public double PorcentajeAciertos { get; set; }
        public double CapacidadDistincion { get; set; }
        public double EquilibrioGeneral { get; set; }
        public double ReferenciaBasica { get; set; }

        public string Conclusion { get; set; }
    }
}

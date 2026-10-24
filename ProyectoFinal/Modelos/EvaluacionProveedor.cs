using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class EvaluacionProveedor
    {
        public int IdEvaluacion { get; set; }
        public int IdCompra { get; set; }
        public DateTime FechaPrometida { get; set; }
        public int? Calidad { get; set; }
        public string Observaciones { get; set; }
    }
}

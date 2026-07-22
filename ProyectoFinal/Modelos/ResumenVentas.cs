using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ResumenVentas
    {
        public int CantidadVentas { get; set; }
        public double TotalVentas { get; set; }
        public double TotalCobrado { get; set; }
        public double TotalDeuda { get; set; }
        public double TicketPromedio { get; set; }
        public SortedDictionary<string, double> TotalesPorPeriodo { get; set; }
    }
}

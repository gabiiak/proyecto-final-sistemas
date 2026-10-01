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
        public decimal TotalVentas { get; set; }
        public decimal TotalCobrado { get; set; }
        public decimal TotalDeuda { get; set; }
        public decimal TicketPromedio { get; set; }
        public SortedDictionary<string, decimal> TotalesPorPeriodo { get; set; }
    }
}

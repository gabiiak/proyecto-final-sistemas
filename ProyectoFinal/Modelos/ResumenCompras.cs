using System.Collections.Generic;

namespace Modelos
{
    public class ResumenCompras
    {
        public int CantidadCompras { get; set; }
        public decimal TotalCompras { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal TotalDeuda { get; set; }
        public decimal PromedioCompra { get; set; }
        public SortedDictionary<string, decimal> TotalesPorPeriodo { get; set; }
    }
}
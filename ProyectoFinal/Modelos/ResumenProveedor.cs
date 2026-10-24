using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelos
{
    public class ResumenProveedor
    {
        public int IdProveedor { get; set; }

        public string NombreProveedor { get; set; }

        public int TotalEntregas { get; set; }

        public int EntregasPuntuales { get; set; }

        public int EntregasTardias { get; set; }

        public double PorcentajeCumplimiento { get; set; }

        public double? PromedioCalidad { get; set; }
    }
}

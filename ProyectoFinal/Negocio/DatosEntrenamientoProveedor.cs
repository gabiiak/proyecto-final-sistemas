using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace Negocio
{
    public class DatosEntrenamientoProveedor
    {
        public float IdProveedor { get; set; }

        public float MontoCompra { get; set; }

        public float CantidadComprasPrevias { get; set; }

        public float PorcentajeCumplimientoPrevio { get; set; }

        public float DiasPlazoEntrega { get; set; }

        [ColumnName("Label")]
        public bool EntregaPuntual { get; set; }
    }
}


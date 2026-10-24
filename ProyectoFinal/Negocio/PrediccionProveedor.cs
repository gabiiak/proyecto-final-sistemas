using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace Negocio
{
    public class PrediccionProveedor
    {
        [ColumnName("PredictedLabel")]
        public bool EntregaPuntual { get; set; }

        [ColumnName("Probability")]
        public float Probabilidad { get; set; }

        [ColumnName("Score")]
        public float Score { get; set; }
    }
}



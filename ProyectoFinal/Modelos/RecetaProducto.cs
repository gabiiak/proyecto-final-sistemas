using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Modelos
{
    public class RecetaProducto
    {
        public int IdReceta { get; set; }
        public int IdProducto { get; set; }
        public int IdInsumo { get; set; }
        public double CantidadPorUnidad { get; set; }

        public string NombreInsumo { get; set; }
        public string DescripcionInsumo { get; set; }

    }
}

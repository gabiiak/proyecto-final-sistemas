using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Modelos
    {
        public class Transporte
        {
            public int IdTransporte { get; set; }
            public Venta Venta { get; set; }
            public DateTime Fecha { get; set; }
            public int Estado { get; set; } 
        }
    }

   
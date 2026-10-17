using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class EstadoCompra
    {
        public const int Emitida = 0;
        public const int Aceptada = 1;
        public const int Pagado = 2;
        public const int Enviada = 3;
        public const int Entregada = 4;
        public const int Cancelada = 5;
    }
}

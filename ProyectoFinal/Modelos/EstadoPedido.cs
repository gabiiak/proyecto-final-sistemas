using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public static class EstadoPedido
    {
        public const int Cancelado = 0;
        public const int Preparacion = 1;
        public const int Listo = 2;
        public const int EnViaje = 3;
        public const int Entregado = 4;
    }
}

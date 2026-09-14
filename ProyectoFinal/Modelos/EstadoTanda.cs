using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class EstadoTanda
    {
        public const int EnProceso = 0;
        public const int Terminada = 1;
        public const int Pendiente = 2;
        public const int Cancelada = 3;
    }
}
using System;

namespace Modelos
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string UnidadMedida { get; set; }
        public int Activo { get; set; } // 1 - activo | 0 - inactivo (se usa al eliminar insumos)
    }
}

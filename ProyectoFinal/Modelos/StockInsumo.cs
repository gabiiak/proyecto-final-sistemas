using System;

namespace Modelos
{
    // Representa el stock disponible de un Insumo.
    // Id = Id de la fila en la tabla Stock (0 si el insumo todavía no tiene
    //      una fila propia en Stock, es decir, nunca se le registró un ingreso).
    // InsumoId = FK al Insumo dueño de este stock.
    // NombreInsumo = dato denormalizado del Insumo,
    //      para poder mostrarlo directo en la grilla sin joins adicionales en la UI.
    public class StockInsumo
    {
        public int Id { get; set; }
        public int InsumoId { get; set; }
        public string NombreInsumo { get; set; }
        public double CantidadDisponible { get; set; }
    }
}

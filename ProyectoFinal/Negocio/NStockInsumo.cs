using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Negocio
{
    public class NStockInsumo
    {
        public static List<Modelos.StockInsumo> GetAllStock()
        {
            return Datos.DataStockInsumo.GetAllStock();
        }

        public static int createStock(Modelos.StockInsumo stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock), "El stock no puede ser nulo.");

            if (stock.InsumoId <= 0)
                throw new ArgumentException("Debe seleccionar un insumo válido.", nameof(stock.InsumoId));

            if (stock.CantidadDisponible < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.", nameof(stock.CantidadDisponible));

            return Datos.DataStockInsumo.createStock(stock);
        }

        public static int updateStock(Modelos.StockInsumo stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock), "El stock no puede ser nulo.");

            if (stock.Id <= 0)
                throw new ArgumentException("El id del stock debe ser mayor a 0.", nameof(stock.Id));

            if (stock.CantidadDisponible < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.", nameof(stock.CantidadDisponible));

            return Datos.DataStockInsumo.updateStock(stock);
        }

        public static int deleteStock(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor a 0.", nameof(id));

            return Datos.DataStockInsumo.deleteStock(id);
        }

        public static Modelos.StockInsumo GetStockById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor a 0.", nameof(id));

            return Datos.DataStockInsumo.GetStockById(id);
        }
    }
}

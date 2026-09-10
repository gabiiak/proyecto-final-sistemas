using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Modelos;

namespace Negocio
{
    public class NStockProducto
    {
        public static int CreateStock(StockProducto stock) //la capa de negocios también hace estas validaciones. refactorizar toda la capa de negocios (algún día) puede reforzar
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock), "El stock no puede ser nulo.");
            if (stock.ProductoId <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido.", nameof(stock));
            if (stock.CantidadDisponible < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.", nameof(stock));
            return DataStockProducto.CrearStock(stock);
        }

        public static List<StockProducto> GetAll()
        {
            return DataStockProducto.GetAllStock();
        }

        public static int UpdateStock(StockProducto stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock), "El stock no puede ser nulo.");
            if (stock.Id <= 0)
                throw new ArgumentException("Debe indicar un stock válido.", nameof(stock));
            if (stock.CantidadDisponible < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.", nameof(stock));

            return DataStockProducto.UpdateStock(stock);
        }

        public static StockProducto GetStockById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Debe indicar un id válido.", nameof(id));

            return DataStockProducto.GetStockById(id);
        }
    }
}

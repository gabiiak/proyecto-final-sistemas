using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class NRecetaProducto
    {
        public static int Create(RecetaProducto receta)
        {
            if (receta == null)
                throw new ArgumentNullException(nameof(receta), "La receta no puede ser nula.");

            if (receta.IdProducto <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido.");

            if (receta.IdInsumo <= 0)
                throw new ArgumentException("Debe seleccionar un insumo válido.");

            if (receta.CantidadPorUnidad <= 0)
                throw new ArgumentException("La cantidad por unidad debe ser mayor a cero.");

            if (DataRecetaProducto.ExisteInsumoEnReceta(receta.IdProducto, receta.IdInsumo))
                throw new ArgumentException("Este insumo ya forma parte de la receta de este producto. Modifique la cantidad existente en lugar de agregarlo de nuevo.");

            return DataRecetaProducto.Create(receta);
        }

        public static void Update(RecetaProducto receta)
        {
            if (receta == null)
                throw new ArgumentNullException(nameof(receta), "La receta no puede ser nula.");

            if (receta.IdReceta <= 0)
                throw new ArgumentException("Id de receta inválido.");

            if (receta.CantidadPorUnidad <= 0)
                throw new ArgumentException("La cantidad por unidad debe ser mayor a cero.");

            DataRecetaProducto.Update(receta);
        }

        public static void Delete(int idReceta)
        {
            if (idReceta <= 0)
                throw new ArgumentException("Id de receta inválido.");

            DataRecetaProducto.Delete(idReceta);
        }

        public static List<RecetaProducto> ObtenerPorProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido.");

            return DataRecetaProducto.ObtenerPorProducto(idProducto);
        }
        private static bool CantidadRazonable(double cantidad, string unidadMedida)
        {
            switch (unidadMedida?.ToLower())
            {
                case "kg":
                    return cantidad <= 10; // más de 10 Kg por unidad de producto es sospechoso
                case "gr":
                    return cantidad <= 1000; // más de 1000 gr (=1kg) por unidad de producto es sospechoso
                case "unidad":
                    return cantidad <= 50; // más de 50 unidades (ej. huevos) por producto es sospechoso
                default:
                    return true; // unidad desconocida, no bloqueamos por las dudas
            }
        }
        public static void ReemplazarReceta(int idProducto, List<RecetaProducto> receta)
        {
            if (idProducto <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido.");

            if (receta == null || receta.Count == 0)
                throw new ArgumentException("La receta debe tener al menos un insumo.");

            // Chequeo de duplicados dentro de la misma lista (antes de tocar la BD)
            var idsInsumo = receta.Select(r => r.IdInsumo).ToList();
            if (idsInsumo.Distinct().Count() != idsInsumo.Count)
                throw new ArgumentException("Hay insumos repetidos en la receta. Cada insumo debe aparecer una sola vez.");

            foreach (RecetaProducto item in receta)
            {
                if (item.IdInsumo <= 0)
                    throw new ArgumentException("Hay una fila con insumo inválido.");

                if (item.CantidadPorUnidad <= 0)
                    throw new ArgumentException("Todas las cantidades deben ser mayores a cero.");

                if (!CantidadRazonable(item.CantidadPorUnidad, item.UnidadMedidaInsumo))
                    throw new ArgumentException(
                        $"La cantidad '{item.CantidadPorUnidad}' parece muy alta para el insumo '{item.NombreInsumo}' " +
                        $"(medido en {item.UnidadMedidaInsumo}). Verifique que esté expresada correctamente.");
            }

            DataRecetaProducto.ReemplazarReceta(idProducto, receta);
        }
    }
}

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

            if (DRecetaProducto.ExisteInsumoEnReceta(receta.IdProducto, receta.IdInsumo))
                throw new ArgumentException("Este insumo ya forma parte de la receta de este producto. Modifique la cantidad existente en lugar de agregarlo de nuevo.");

            return DRecetaProducto.Create(receta);
        }

        public static void Update(RecetaProducto receta)
        {
            if (receta == null)
                throw new ArgumentNullException(nameof(receta), "La receta no puede ser nula.");

            if (receta.IdReceta <= 0)
                throw new ArgumentException("Id de receta inválido.");

            if (receta.CantidadPorUnidad <= 0)
                throw new ArgumentException("La cantidad por unidad debe ser mayor a cero.");

            DRecetaProducto.Update(receta);
        }

        public static void Delete(int idReceta)
        {
            if (idReceta <= 0)
                throw new ArgumentException("Id de receta inválido.");

            DRecetaProducto.Delete(idReceta);
        }

        public static List<RecetaProducto> ObtenerPorProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido.");

            return DRecetaProducto.ObtenerPorProducto(idProducto);
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
            }

            DRecetaProducto.ReemplazarReceta(idProducto, receta);
        }
    }
}

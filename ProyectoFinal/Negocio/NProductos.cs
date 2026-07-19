using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NProductos
    {
        public static bool ExisteProductoDescripcion(string descripcion)
        {
            return GetAll().Any(p => p.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase));
        }
        public static bool ExisteProductoNombre(string nombre)
        {
            return GetAll().Any(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
        public static List<Producto> GetAll()
        {
            try
            {
                return DataProductos.GetAllProductos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Producto> GetAllDeleted()
        {
            try
            {
                return DataProductos.GetAllDeletedProductos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Create(Producto prod)
        {
            try
            {
                DataProductos.Create(prod);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Update(Producto prod)
        {
            try
            {
                DataProductos.Update(prod);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Delete(Producto prod)
        {
            try
            {
                DataProductos.Delete(prod);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ShowDeletedProducts(Producto prod)
        {
            try
            {
                DataProductos.ShowDeletedProducts(prod);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

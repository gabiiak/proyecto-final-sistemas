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
    }
}

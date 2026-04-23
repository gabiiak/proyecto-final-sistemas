using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    /*
     try
            {

            }
            catch (Exception)
            {
                throw;
            }
     */
    public class NClientes
    {
        public static List<Cliente> GetAll()
        {
            try
            {
                return DataClientes.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Create(Cliente cliente)
        {
            try
            {
                DataClientes.Create(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

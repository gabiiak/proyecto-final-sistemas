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
        public static List<Cliente> GetDeleted()
        {
            try
            {
                return DataClientes.GetDeleted();
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
        public static void Update(Cliente cliente)
        {
            try
            {
                DataClientes.Update(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void Delete(Cliente cliente)
        {
            try
            {
                DataClientes.Delete(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ShowDeletedClients(Cliente cliente)
        {
            try
            {
                DataClientes.ShowDeletedClients(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

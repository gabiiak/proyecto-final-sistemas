using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NProveedores
    {
        public static bool ExisteProveedorNombre(string nombre)
        {
            return GetAll().Any(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public static List<Proveedor> GetAll()
        {
            try
            {
                return DataProveedores.GetAllProveedores();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Proveedor GetById(int idProveedor)
        {
            if (idProveedor <= 0)
                throw new ArgumentException("El identificador del proveedor no es válido.");

            return DataProveedores.GetById(idProveedor);
        }

        public static List<Proveedor> GetAllDeleted()
        {
            try
            {
                return DataProveedores.GetDeletedProveedores();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Create(Proveedor prov)
        {
            try
            {
                ValidarDuplicados(prov);
                DataProveedores.Create(prov);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Update(Proveedor prov)
        {
            try
            {
                ValidarDuplicados(prov);
                DataProveedores.Update(prov);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Delete(int idProveedor)
        {
            try
            {
                DataProveedores.Delete(idProveedor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ShowDeletedProveedores(Proveedor prov)
        {
            try
            {
                DataProveedores.ShowDeletedProveedores(prov);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ── VALIDACIONES ────────────────────────────────────────

        // Lanza InvalidOperationException con el mensaje para el usuario.
        // En Create el IdProveedor es 0, así que no excluye a nadie;
        // en Update excluye al propio proveedor.
        private static void ValidarDuplicados(Proveedor prov)
        {
            string email = (prov.Email ?? "").Trim();
            string telefono = SoloDigitos(prov.Telefono);

            // Teléfono y email se comparan contra activos Y eliminados,
            // para que restaurar un proveedor no genere duplicados.
            List<Proveedor> todos = GetAll();
            todos.AddRange(GetAllDeleted());

            bool telefonoRepetido = todos.Any(p =>
                p.IdProveedor != prov.IdProveedor &&
                SoloDigitos(p.Telefono) == telefono);
            if (telefonoRepetido)
                throw new InvalidOperationException("Ya existe un proveedor con ese teléfono (puede estar entre los eliminados).");

            bool emailRepetido = todos.Any(p =>
                p.IdProveedor != prov.IdProveedor &&
                p.Email.Trim().Equals(email, StringComparison.OrdinalIgnoreCase));
            if (emailRepetido)
                throw new InvalidOperationException("Ya existe un proveedor con ese email (puede estar entre los eliminados).");
        }

        private static string SoloDigitos(string s)
        {
            return new string((s ?? "").Where(char.IsDigit).ToArray());
        }
    }
}
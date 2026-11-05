using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class NInsumos
    {
        private static readonly string[] UnidadesValidas = { "Kg", "Gr", "Unidad", "Lts" };

        // Unidad en la que se guarda el stock según la unidad de compra del insumo.
        public static string UnidadStock(string unidadMedida)
        {
            if (unidadMedida == "Kg") return "Gr";
            if (unidadMedida == "Lts") return "Ml";
            return unidadMedida;
        }

        // Convierte una cantidad en unidad de compra a la unidad de stock.
        public static decimal CantidadAStock(string unidadMedida, decimal cantidad)
        {
            if (unidadMedida == "Kg" || unidadMedida == "Lts") return cantidad * 1000;
            return cantidad;
        }

        // Convierte una cantidad en unidad de stock a la unidad de compra.
        public static decimal CantidadDesdeStock(string unidadMedida, decimal cantidadStock)
        {
            if (unidadMedida == "Kg" || unidadMedida == "Lts") return cantidadStock / 1000;
            return cantidadStock;
        }

        public static List<Modelos.Insumo> GetAllInsumos()
        {
            return Datos.DataInsumos.GetAllInsumos();
        }
        public static int Create(Modelos.Insumo insumo)
        {
            if (insumo == null)
                throw new ArgumentNullException(nameof(insumo), "El insumo no puede ser nulo.");
            
            if (string.IsNullOrWhiteSpace(insumo.Nombre))
                throw new ArgumentException("El nombre del insumo es requerido.", nameof(insumo.Nombre));
            
            if (insumo.Nombre.Length > 100)
                throw new ArgumentException("El nombre del insumo no puede exceder 100 caracteres.", nameof(insumo.Nombre));

            if (!UnidadesValidas.Contains(insumo.UnidadMedida))
                throw new ArgumentException("Unidad de medida inválida.");

            return Datos.DataInsumos.Create(insumo);
        }
        public static int Update(Modelos.Insumo insumo)
        {
            if (insumo == null)
                throw new ArgumentNullException(nameof(insumo), "El insumo no puede ser nulo.");
            
            if (insumo.Id <= 0)
                throw new ArgumentException("El id del insumo debe ser mayor a 0.", nameof(insumo.Id));
            
            if (string.IsNullOrWhiteSpace(insumo.Nombre))
                throw new ArgumentException("El nombre del insumo es requerido.", nameof(insumo.Nombre));
            
            if (insumo.Nombre.Length > 100)
                throw new ArgumentException("El nombre del insumo no puede exceder 100 caracteres.", nameof(insumo.Nombre));

            if (!UnidadesValidas.Contains(insumo.UnidadMedida))
                throw new ArgumentException("Unidad de medida inválida.");

            return Datos.DataInsumos.Update(insumo);
        }
        public static int Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor a 0.", nameof(id));
            
            return Datos.DataInsumos.Delete(id);
        }
        public static Modelos.Insumo GetInsumoById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor a 0.", nameof(id));
            
            return Datos.DataInsumos.GetInsumoById(id);
        }
          
    }
}

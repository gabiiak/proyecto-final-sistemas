using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class NInsumos
    {
        public static List<Modelos.Insumo> GetAllInsumos()
        {
            return Datos.DataInsumos.GetAllInsumos();
        }
        public static int createInsumo(Modelos.Insumo insumo)
        {
            if (insumo == null)
                throw new ArgumentNullException(nameof(insumo), "El insumo no puede ser nulo.");
            
            if (string.IsNullOrWhiteSpace(insumo.Nombre))
                throw new ArgumentException("El nombre del insumo es requerido.", nameof(insumo.Nombre));
            
            if (insumo.Nombre.Length > 100)
                throw new ArgumentException("El nombre del insumo no puede exceder 100 caracteres.", nameof(insumo.Nombre));
            
            return Datos.DataInsumos.createInsumo(insumo);
        }
        public static int updateInsumo(Modelos.Insumo insumo)
        {
            if (insumo == null)
                throw new ArgumentNullException(nameof(insumo), "El insumo no puede ser nulo.");
            
            if (insumo.Id <= 0)
                throw new ArgumentException("El id del insumo debe ser mayor a 0.", nameof(insumo.Id));
            
            if (string.IsNullOrWhiteSpace(insumo.Nombre))
                throw new ArgumentException("El nombre del insumo es requerido.", nameof(insumo.Nombre));
            
            if (insumo.Nombre.Length > 100)
                throw new ArgumentException("El nombre del insumo no puede exceder 100 caracteres.", nameof(insumo.Nombre));
            
            return Datos.DataInsumos.updateInsumo(insumo);
        }
        public static int deleteInsumo(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor a 0.", nameof(id));
            
            return Datos.DataInsumos.cambiarEstadoInsumo(id);
        }
        public static Modelos.Insumo GetInsumoById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id debe ser mayor a 0.", nameof(id));
            
            return Datos.DataInsumos.GetInsumoById(id);
        }
          
    }
}

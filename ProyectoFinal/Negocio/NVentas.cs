using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NVentas
    {
        /* SOLO USAR TRY - CATCH PARA MÉTODOS ROBUSTOS. MEJOR USARLOS EN LA CAPA DE PRESENTACIÓN
         * try
         * {
         * 
         * }
         catch (Exception e)
            {
                throw e;
            }
         */
        public List<Venta> GetAllVentas(){return DataVentas.GetAllVentas();}
        
        public int CreateVenta(Venta venta) { return DataVentas.CreateVenta(venta); }

        public static double CalcularTotal(List<DetalleVenta> detalles)
        {
            double total = 0;
            foreach (DetalleVenta detalle in detalles)
            {
                total += NDetalleVentas.CalcularSubTotal(detalle);
            }
            return total;
        }
    }
}

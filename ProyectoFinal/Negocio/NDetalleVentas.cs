using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NDetalleVentas
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
        public static List<DetalleVenta> GetAllDetalleVentas() { return DataDetalleVentas.GetAllDetalleVentas(); }

        public void CreateDetalleVenta(DetalleVenta detalle) { DataDetalleVentas.CreateDetalleVenta(detalle); }

        public static double CalcularSubTotal(DetalleVenta detalle)
        {
            double subTotal = detalle.Producto.Precio * detalle.Cantidad;
            return subTotal;
        }
    }
}

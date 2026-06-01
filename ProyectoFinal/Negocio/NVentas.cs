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
        public static List<Venta> GetAllVentas() { return DataVentas.GetAllVentas(); }
        
        public static int CreateVenta(Venta venta) { return DataVentas.CreateVenta(venta); }

        public static double CalcularTotal(List<DetalleVenta> detalles)
        {
            double total = 0;
            foreach (DetalleVenta detalle in detalles)
            {
                total += NDetalleVentas.CalcularSubTotal(detalle);
            }
            return total;
        }
        public static int DeterminarEstadoPago(double total, double recibido)
        {
            if (recibido == total) return EstadoPago.Pagado;
            if (recibido > total) return EstadoPago.Pagado;
            return EstadoPago.Pendiente;
        }
        public static void CambiarEstadoPago(Venta venta) { DataVentas.CambiarEstadoPago(venta); }
        public static void CambiarEstadoPedido(Venta venta) { DataVentas.CambiarEstadoPedido(venta); }
        public static Venta GetVentaById(int idVenta) { return DataVentas.GetVentaById(idVenta); }
        
    }
}

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


        //HACER DTO Y HACER CALCULOS AQUI
        public static List<Venta> GetAllVentas() { return DataVentas.GetAllVentas(); }
        
        public static int CreateVenta(Venta venta) { return DataVentas.CreateVenta(venta); }
        
        public static double CalcularVuelto(double total, double recibido, string metodo)
        {
            if (metodo.Equals("Efectivo", StringComparison.OrdinalIgnoreCase) && recibido > total)
            {
                return recibido - total;
            } else return 0;
        }
        public static double DescuentoPorEfectivo(double total,string metodo)
        {
            if (metodo.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
            {
                return total * 0.10;
            }
            else return 1;
        }
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
            if (recibido >= total) return EstadoPago.Pagado;
            return EstadoPago.Pendiente;
        }
        public static void CambiarEstadoPago(int idVenta, int estadoPago) 
        {
            DataVentas.CambiarEstadoPago(idVenta, estadoPago); 
        }
        public static void CambiarEstadoPedido(int idVenta, int estadoPedido) { DataVentas.CambiarEstadoPedido(idVenta, estadoPedido); }
        public static Venta GetVentaById(int idVenta) { return DataVentas.GetVentaById(idVenta); }
        public static Venta GetMontoRecibido(int idVenta) { return DataVentas.GetMontoRecibido(idVenta); }
        public static void CambiarMontoRecibido (int idVenta, double ingresado)
        {
            Venta venta = GetMontoRecibido(idVenta);
            double nuevoMonto = venta.MontoRecibido + ingresado;
            DataVentas.CambiarMontoRecibido(idVenta, nuevoMonto);
        }
        public static double CalcularDeuda(int idVenta)
        {
            Venta venta = GetMontoRecibido(idVenta);
            return venta.Total - venta.MontoRecibido;
        }

    }
}

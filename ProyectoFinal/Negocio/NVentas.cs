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
        public static Dictionary<int, double> GetVentasPorMesAnio()
        {
            int anio = DateTime.Now.Year;
            return DataVentas.GetVentasPorMesAnio(anio);
        }
        public static List<(string Nombre, double Total)> GetTopClientesPorMonto()
        {
            return DataVentas.GetTopClientesPorMonto();
        }
        public static Dictionary<int, double> GetVentasPorMesSemestre(int anio, int semestre)
        {
            return DataVentas.GetVentasPorMesSemestre(anio, semestre);
        }
        public static Dictionary<int, double> GetVentasPorMesSemestre()
        {
            int anio = DateTime.Now.Year;
            int semestre = DateTime.Now.Month <= 6 ? 1 : 2;
            return DataVentas.GetVentasPorMesSemestre(anio, semestre);
        }
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
                total = total * 0.90;
            }
            return total;
        }
        public static double CalcularTotal(List<DetalleVenta> detalles)
        {
            double total = 0;
            foreach (DetalleVenta detalle in detalles)
            {
                total += NDetalleVentas.CalcularSubTotal(detalle);
            }
            return Math.Round(total, 2);
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

        public static ResumenVentas CalcularResumenVentas(List<Venta> ventas)
        {
            ResumenVentas resumen = new ResumenVentas();
            resumen.TotalesPorPeriodo = new SortedDictionary<string, double>();

            double totalVentas = 0;
            double totalCobrado = 0;
            int cantidadVentas = 0;

            foreach (Venta v in ventas)
            {
                if (v.Estado_Pago == EstadoPago.Anulado)
                    continue; // no cuenta para nada del resumen

                cantidadVentas++;
                totalVentas += v.Total;

                if (v.Estado_Pago == EstadoPago.Pagado)
                {
                    totalCobrado += v.Total;
                }
                else if (v.Estado_Pago == EstadoPago.Pendiente)
                {
                    totalCobrado += v.MontoRecibido;
                }

                string periodo = v.Fecha.ToString("yyyy-MM");

                if (resumen.TotalesPorPeriodo.ContainsKey(periodo))
                    resumen.TotalesPorPeriodo[periodo] += v.Total;
                else
                    resumen.TotalesPorPeriodo[periodo] = v.Total;
            }

            resumen.CantidadVentas = cantidadVentas;
            resumen.TotalVentas = Math.Round(totalVentas, 2);
            resumen.TotalCobrado = Math.Round(totalCobrado, 2);
            resumen.TotalDeuda = Math.Round(totalVentas - totalCobrado, 2);
            resumen.TicketPromedio = resumen.CantidadVentas > 0
                ? Math.Round(totalVentas / resumen.CantidadVentas, 2)
                : 0;

            return resumen;
        }



    }
}

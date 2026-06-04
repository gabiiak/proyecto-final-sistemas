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


        public static Dictionary<string, double> GetVentasUltimas4Semanas()
        {
            // diccionario fijo
            Dictionary<string, double> ventasSemanas = new Dictionary<string, double>
    {
        { "Semana 1", 0 },
        { "Semana 2", 0 },
        { "Semana 3", 0 },
        { "Semana 4", 0 }
    };

           
            var listaVentas = DataVentas.GetAllVentas();

            
            DateTime hoy = DateTime.Today;

            // DayOfWeek asigna Domingo=0, Lunes=1, etc. Esta fórmula matemática siempre encuentra el Lunes de esta semana.
            int diasDesdeElLunes = (7 + (hoy.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime inicioSemana4 = hoy.AddDays(-1 * diasDesdeElLunes).Date; // Lunes actual a las 00:00:00

            // resto de las semanas restando de a 7 días
            DateTime inicioSemana3 = inicioSemana4.AddDays(-7);
            DateTime inicioSemana2 = inicioSemana4.AddDays(-14);
            DateTime inicioSemana1 = inicioSemana4.AddDays(-21);

            // El fin de la Semana 4 es el domingo a las 23:59:59
            DateTime finSemana4 = inicioSemana4.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);

            //  Clasificamos cada venta en su "cajón" de calendario correspondiente
            foreach (var venta in listaVentas)
            {
              
                DateTime fecha = venta.Fecha;
                double monto = venta.Total;

                if (fecha >= inicioSemana1 && fecha < inicioSemana2)
                {
                    ventasSemanas["Semana 1"] += monto;
                }
                else if (fecha >= inicioSemana2 && fecha < inicioSemana3)
                {
                    ventasSemanas["Semana 2"] += monto;
                }
                else if (fecha >= inicioSemana3 && fecha < inicioSemana4)
                {
                    ventasSemanas["Semana 3"] += monto;
                }
                else if (fecha >= inicioSemana4 && fecha <= finSemana4)
                {
                    ventasSemanas["Semana 4"] += monto; // La semana en curso
                }
            }

            return ventasSemanas;
        }
        public static int GetCantidadVentasUltimos30Dias()
        {
            
            var todasLasVentas = DataVentas.GetAllVentas();
            DateTime fechaLimite = DateTime.Now.Date.AddDays(-30);
            return todasLasVentas.Count(v => v.Fecha.Date >= fechaLimite);
        }

        public static Dictionary<string, int> GetClientesMasFrecuentes(int top = 3)
        {
            
            var todasLasVentas = DataVentas.GetAllVentas();

            //  Calculamos la fecha exacta de hace 3 meses, aca se puede cambiar a 6 meses, 1 año, etc. dependiendo de lo que se quiera analizar
            DateTime fechaLimite = DateTime.Now.Date.AddMonths(-3);

            
            var topClientes = todasLasVentas
               
                .Where(v => v.Cliente != null && v.Fecha.Date >= fechaLimite)
                .GroupBy(v => v.Cliente.Nombre) 
                .Select(grupo => new
                {
                    NombreCliente = grupo.Key,
                    CantidadCompras = grupo.Count() 
                })
                .OrderByDescending(x => x.CantidadCompras) 
                .Take(top) // Nos quedamos solo con los 3 mejores
                .ToDictionary(x => x.NombreCliente, x => x.CantidadCompras);

            return topClientes;
        }


        public static void CambiarEstadoPago(Venta venta) { DataVentas.CambiarEstadoPago(venta); }
        public static void CambiarEstadoPedido(Venta venta) { DataVentas.CambiarEstadoPedido(venta); }
        public static Venta GetVentaById(int idVenta) { return DataVentas.GetVentaById(idVenta); }
        
    }
}

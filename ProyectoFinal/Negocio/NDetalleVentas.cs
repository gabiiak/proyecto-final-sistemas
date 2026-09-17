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
        public static List<(string Nombre, int Cantidad)> GetProductosMasVendidos()
        {
            return DataDetalleVentas.GetProductosMasVendidos();
        }
        public static List<DetalleVenta> GetAllDetalleVentas() { return DataDetalleVentas.GetAllDetalleVentas(); }
        public static List<DetalleVenta> GetDetalleByIdVenta(int idVenta) { return DataDetalleVentas.GetDetallesByIdVenta(idVenta); }

        public static void CreateDetalleVenta(DetalleVenta detalle) { DataDetalleVentas.CreateDetalleVenta(detalle); }

        public static double CalcularSubTotal(DetalleVenta detalle)
        {
            double subTotal = detalle.Producto.Precio * detalle.Cantidad;
            return subTotal;
        }
        public static void ValidarStockSuficiente(List<DetalleVenta> detalles)
        {
            foreach (DetalleVenta detalle in detalles)
            {
                StockProducto stockActual = DataStockProducto.GetStockByProductoId(detalle.Producto.IdProducto);

                if (stockActual == null)
                    throw new ArgumentException($"No existe stock cargado para el producto '{detalle.Producto.Nombre}'.");

                if (stockActual.CantidadDisponible < detalle.Cantidad)
                    throw new ArgumentException(
                        $"Stock insuficiente de '{detalle.Producto.Nombre}'. Disponible: {stockActual.CantidadDisponible}, necesario: {detalle.Cantidad}.");
            }
        }
    }
}

using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NDetalleCompras
    {
        /* SOLO USAR TRY - CATCH PARA MÉTODOS ROBUSTOS. MEJOR USARLOS EN LA CAPA DE PRESENTACIÓN */

        public static List<(string Nombre, decimal Cantidad)> GetInsumosMasComprados()
        {
            return DataDetalleCompras.GetInsumosMasComprados();
        }

        public static List<DetalleCompra> GetAllDetalleCompras() { return DataDetalleCompras.GetAllDetalleCompras(); }

        public static List<DetalleCompra> GetDetalleByIdCompra(int idCompra) { return DataDetalleCompras.GetDetallesByIdCompra(idCompra); }

        public static int CreateDetalleCompra(DetalleCompra detalle)
        {
            ValidarDetalle(detalle);
            return DataDetalleCompras.CreateDetalleCompra(detalle);
        }

        // DetalleCompra no tiene objeto Insumo con precio, por eso el precio unitario se recibe por parámetro
        public static decimal CalcularSubTotal(decimal precioUnitario, decimal cantidad)
        {
            if (precioUnitario < 0)
                throw new ArgumentException("El precio unitario no puede ser negativo.", nameof(precioUnitario));
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.", nameof(cantidad));

            return Math.Round(precioUnitario * cantidad, 2);
        }

        // En una compra no se valida stock disponible (el stock aumenta al recibir),
        // se validan los datos de cada línea.
        public static void ValidarDetalle(DetalleCompra detalle)
        {
            const decimal CantidadMaxima = 50000m;

            if (detalle == null)
                throw new ArgumentException("El detalle no puede ser nulo.");
            if (detalle.IdInsumo <= 0)
                throw new ArgumentException("Debe indicar un insumo válido.");
            if (detalle.Cantidad <= 0)
                throw new ArgumentException($"La cantidad del insumo {detalle.IdInsumo} debe ser mayor a cero.");
            if (detalle.Cantidad > CantidadMaxima)
                throw new ArgumentException("La cantidad no puede superar las 50.000 unidades.");
            if (detalle.Subtotal < 0)
                throw new ArgumentException($"El subtotal del insumo {detalle.IdInsumo} no puede ser negativo.");
        }

        public static void ValidarDetalles(List<DetalleCompra> detalles)
        {
            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("La compra debe tener al menos un insumo.");

            foreach (DetalleCompra detalle in detalles)
            {
                ValidarDetalle(detalle);
            }
        }
    }
}
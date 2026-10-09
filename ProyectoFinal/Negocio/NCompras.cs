using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NCompras
    {
        /* SOLO USAR TRY - CATCH PARA MÉTODOS ROBUSTOS. MEJOR USARLOS EN LA CAPA DE PRESENTACIÓN */

        // ---------- Gráficos ----------
        public static Dictionary<int, double> GetComprasPorMesAnio()
        {
            int anio = DateTime.Now.Year;
            return DataCompras.GetComprasPorMesAnio(anio);
        }

        public static Dictionary<int, double> GetComprasPorMesSemestre(int anio, int semestre)
        {
            return DataCompras.GetComprasPorMesSemestre(anio, semestre);
        }

        public static Dictionary<int, double> GetComprasPorMesSemestre()
        {
            int anio = DateTime.Now.Year;
            int semestre = DateTime.Now.Month <= 6 ? 1 : 2;
            return DataCompras.GetComprasPorMesSemestre(anio, semestre);
        }

        public static List<(string Nombre, double Total)> GetTopProveedoresPorMonto()
        {
            return DataCompras.GetTopProveedoresPorMonto();
        }

        // ---------- Consultas ----------
        public static List<Compra> GetAllCompras() { return DataCompras.GetAllCompras(); }
        public static Compra GetCompraById(int idCompra) { return DataCompras.GetCompraById(idCompra); }
        public static Compra GetMontoPagado(int idCompra) { return DataCompras.GetMontoPagado(idCompra); }

        // ---------- Alta ----------
        public static int CreateCompra(Compra compra)
        {
            if (compra == null)
                throw new ArgumentException("La compra no puede ser nula.");
            if (compra.IdProveedor <= 0)
                throw new ArgumentException("Debe indicar un proveedor válido.");

            ValidarFechaCompra(compra.Fecha);

            compra.Estado = EstadoCompra.Emitida;
            return DataCompras.CreateCompra(compra);
        }

        public static void ValidarFechaCompra(DateTime fecha)
        {
            if (fecha.Date > DateTime.Now.Date)
                throw new ArgumentException("No se puede registrar una compra con fecha futura.");
        }

        public static decimal CalcularTotal(List<DetalleCompra> detalles)
        {
            decimal total = 0;
            foreach (DetalleCompra detalle in detalles)
            {
                total += (decimal)detalle.Subtotal;
            }
            return Math.Round(total, 2);
        }

        // ---------- Estados ----------
        // Emitida -> Aceptada -> Pagado -> Enviada -> Entregada
        // Cancelada solo desde Emitida o Aceptada.
        public static bool EsTransicionValida(int actual, int nuevo)
        {
            switch (actual)
            {
                case EstadoCompra.Emitida:
                    return nuevo == EstadoCompra.Aceptada || nuevo == EstadoCompra.Cancelada;
                case EstadoCompra.Aceptada:
                    return nuevo == EstadoCompra.Pagado || nuevo == EstadoCompra.Cancelada;
                case EstadoCompra.Pagado:
                    return nuevo == EstadoCompra.Enviada;
                case EstadoCompra.Enviada:
                    return nuevo == EstadoCompra.Entregada;
                default:
                    return false; // Entregada y Cancelada son finales
            }
        }

        public static void CambiarEstado(int idCompra, int nuevoEstado)
        {
            Compra compra = DataCompras.GetCompraById(idCompra);
            if (compra == null)
                throw new ArgumentException("La compra no existe.");

            // Entregada solo por MarcarCompraEntregada, que suma el stock
            if (nuevoEstado == EstadoCompra.Entregada)
                throw new InvalidOperationException("Use MarcarCompraEntregada para registrar la entrega.");

            if (!EsTransicionValida(compra.Estado, nuevoEstado))
                throw new InvalidOperationException("La transición de estado no es válida.");

            if (nuevoEstado == EstadoCompra.Pagado && compra.montoPagado < compra.TotalCompra)
                throw new InvalidOperationException("No se puede marcar como pagada: el monto pagado no cubre el total.");

            DataCompras.CambiarEstado(idCompra, nuevoEstado);
        }

        public static void MarcarCompraEntregada(int idCompra)
        {
            Compra compra = DataCompras.GetCompraById(idCompra);

            if (compra == null)
                throw new ArgumentException("La compra no existe.");

            if (compra.Estado != EstadoCompra.Enviada)
                throw new ArgumentException("Solo se puede marcar como entregada una compra que fue enviada.");

            List<DetalleCompra> detalles = DataDetalleCompras.GetDetallesByIdCompra(idCompra);

            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("La compra no tiene detalle de insumos.");

            NDetalleCompras.ValidarDetalles(detalles);

            DataCompras.MarcarCompraEntregadaConIncrementoStock(idCompra, detalles);
        }

        // ---------- Detalle ----------
        public static decimal ModificarCantidad(int detalleCompraId, int nuevaCantidad, string motivo)
        {
            if (detalleCompraId <= 0)
                throw new ArgumentException("Debe indicar un detalle de compra válido.", nameof(detalleCompraId));
            if (nuevaCantidad <= 0)
                throw new ArgumentException("La cantidad debe ser un entero positivo mayor a cero.", nameof(nuevaCantidad));
            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("Debe indicar un motivo para la modificación.", nameof(motivo));

            DetalleCompra detalle = DataDetalleCompras.GetById(detalleCompraId);
            if (detalle == null)
                throw new ArgumentException("No existe un detalle de compra con ese id.", nameof(detalleCompraId));

            Compra compra = DataCompras.GetCompraById(detalle.IdCompra);
            if (compra == null)
                throw new InvalidOperationException("No se encontró la compra asociada a este detalle.");
            if (compra.Estado != EstadoCompra.Emitida)
                throw new InvalidOperationException("Solo se puede modificar la cantidad si la compra está emitida.");

            decimal precioUnitarioOriginal = (decimal)detalle.Subtotal / detalle.Cantidad;
            decimal nuevoSubTotal = Math.Round(precioUnitarioOriginal * nuevaCantidad, 2);

            DataDetalleCompras.UpdateCantidad(detalleCompraId, nuevaCantidad, nuevoSubTotal, motivo);

            decimal nuevoTotal = Math.Round(DataDetalleCompras.GetTotalCompraById(detalle.IdCompra), 2);
            DataCompras.UpdateTotal(detalle.IdCompra, nuevoTotal);

            return nuevoTotal;
        }

        // ---------- Pagos ----------
        public static void RegistrarPago(int idCompra, decimal ingresado)
        {
            if (ingresado <= 0)
                throw new ArgumentException("El monto a pagar debe ser mayor a cero.");

            Compra compra = DataCompras.GetCompraById(idCompra);
            if (compra == null)
                throw new ArgumentException("La compra no existe.");
            if (compra.Estado == EstadoCompra.Cancelada)
                throw new InvalidOperationException("No se puede pagar una compra cancelada.");

            decimal deuda = (decimal)compra.TotalCompra - (decimal)compra.montoPagado;
            if (ingresado > deuda)
                throw new ArgumentException($"El monto supera la deuda pendiente ({deuda:N2}).");

            decimal nuevoMonto = (decimal)compra.montoPagado + ingresado;
            DataCompras.CambiarMontoPagado(idCompra, nuevoMonto);

            // Si ya fue aceptada y quedó saldada, pasa a Pagado
            if (compra.Estado == EstadoCompra.Aceptada && nuevoMonto >= (decimal)compra.TotalCompra)
                DataCompras.CambiarEstado(idCompra, EstadoCompra.Pagado);
        }

        public static decimal CalcularDeuda(int idCompra)
        {
            Compra compra = GetMontoPagado(idCompra);
            if (compra == null)
                throw new ArgumentException("La compra no existe.");
            return (decimal)compra.TotalCompra - (decimal)compra.montoPagado;
        }
        public static ResumenCompras CalcularResumenCompras(List<Compra> compras)
        {
            ResumenCompras resumen = new ResumenCompras();
            resumen.TotalesPorPeriodo = new SortedDictionary<string, decimal>();

            decimal totalCompras = 0;
            decimal totalPagado = 0;
            int cantidadCompras = 0;

            foreach (Compra c in compras)
            {
                if (c.Estado == EstadoCompra.Cancelada)
                    continue; // no cuenta para el resumen

                cantidadCompras++;
                decimal total = (decimal)c.TotalCompra;
                totalCompras += total;

                // Pagado, Enviada y Entregada ya están saldadas
                if (c.Estado >= EstadoCompra.Pagado)
                    totalPagado += total;
                else
                    totalPagado += (decimal)c.montoPagado;

                string periodo = c.Fecha.ToString("yyyy-MM");

                if (resumen.TotalesPorPeriodo.ContainsKey(periodo))
                    resumen.TotalesPorPeriodo[periodo] += total;
                else
                    resumen.TotalesPorPeriodo[periodo] = total;
            }

            resumen.CantidadCompras = cantidadCompras;
            resumen.TotalCompras = Math.Round(totalCompras, 2);
            resumen.TotalPagado = Math.Round(totalPagado, 2);
            resumen.TotalDeuda = Math.Round(totalCompras - totalPagado, 2);
            resumen.PromedioCompra = cantidadCompras > 0
                ? Math.Round(totalCompras / cantidadCompras, 2)
                : 0;

            return resumen;
        }
    }
}
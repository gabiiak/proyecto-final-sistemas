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
        public static List<Compra> GetComprasPorPeriodo(int anio, int mes)
        {
            if (mes < 1 || mes > 12)
                throw new ArgumentException("El mes debe estar entre 1 y 12.");
            if (anio < 2000 || anio > DateTime.Now.Year + 1)
                throw new ArgumentException("El año seleccionado no es válido.");
            return DataCompras.GetComprasPorPeriodo(anio, mes);
        }

        // ---------- Alta ----------
        public static int RegistrarPedidoCompra(Compra compra, List<DetalleCompra> detalles)
        {
            if (compra == null)
                throw new ArgumentException("La compra no puede ser nula.");
            if (compra.IdProveedor <= 0)
                throw new ArgumentException("Debe indicar un proveedor válido.");
            if (compra.IdPresupuesto == null || compra.IdPresupuesto <= 0)
                throw new ArgumentException("Debe indicar un presupuesto válido.");

            Presupuesto presupuesto = NPresupuesto.GetById(compra.IdPresupuesto.Value);
            if (presupuesto == null || presupuesto.Activo != 1)
                throw new ArgumentException("El presupuesto no existe o está eliminado.");
            if (presupuesto.EstadoSolicitud != EstadoSolicitudCotizacion.Aceptada)
                throw new ArgumentException("El presupuesto no pertenece a una solicitud aceptada.");
            if (presupuesto.IdProveedor != compra.IdProveedor)
                throw new ArgumentException("El proveedor de la compra no coincide con el del presupuesto.");

            NDetalleCompras.ValidarDetalles(detalles);

            // El pedido solo puede incluir insumos cotizados en el presupuesto del proveedor.
            List<DetallePresupuesto> detallesPresupuesto = NPresupuesto.GetDetalles(compra.IdPresupuesto.Value);
            foreach (DetalleCompra detalle in detalles)
            {
                if (!detallesPresupuesto.Exists(d => d.IdInsumo == detalle.IdInsumo))
                {
                    Insumo insumo = NInsumos.GetInsumoById(detalle.IdInsumo);
                    string nombre = insumo != null ? insumo.Nombre : detalle.IdInsumo.ToString();
                    throw new ArgumentException($"El insumo {nombre} no está en el presupuesto del proveedor.");
                }
            }

            compra.Estado = EstadoCompra.Emitida;
            compra.EstadoPago = EstadoPago.Pendiente;
            compra.Fecha = compra.Fecha == default(DateTime) ? DateTime.Now.Date : compra.Fecha.Date;
            ValidarFechaCompra(compra.Fecha);
            compra.TotalCompra = (double)CalcularTotal(detalles);

            return DataCompras.CrearCompraConDetalle(compra, detalles);
        }

        public static int RegistrarCompraManual(Compra compra, List<DetalleCompra> detalles)
        {
            if (compra == null)
                throw new ArgumentException("La compra no puede ser nula.");
            if (compra.IdProveedor <= 0)
                throw new ArgumentException("Debe indicar un proveedor válido.");

            NDetalleCompras.ValidarDetalles(detalles);

            compra.IdPresupuesto = null;
            compra.Estado = EstadoCompra.Aceptada;
            compra.Fecha = compra.Fecha == default(DateTime) ? DateTime.Now.Date : compra.Fecha.Date;
            ValidarFechaCompra(compra.Fecha);
            compra.TotalCompra = (double)CalcularTotal(detalles);
            compra.EstadoPago = DeterminarEstadoPago((decimal)compra.TotalCompra, (decimal)compra.montoPagado);

            return DataCompras.CrearCompraConDetalle(compra, detalles);
        }

        public static void ModificarPedidoCompra(int idCompra, List<DetalleCompra> detalles)
        {
            Compra compra = DataCompras.GetCompraById(idCompra);
            if (compra == null)
                throw new ArgumentException("La compra no existe.");
            if (compra.Estado != EstadoCompra.Emitida)
                throw new InvalidOperationException("Solo se puede modificar un pedido emitido.");

            NDetalleCompras.ValidarDetalles(detalles);

            compra.TotalCompra = (double)CalcularTotal(detalles);
            DataCompras.ModificarCompraConDetalle(compra, detalles);
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
        // Emitida -> Aceptada -> Enviada -> Recibida
        // Cancelada solo desde Emitida o Aceptada.
        public static bool EsTransicionValida(int actual, int nuevo)
        {
            switch (actual)
            {
                case EstadoCompra.Emitida:
                    return nuevo == EstadoCompra.Aceptada || nuevo == EstadoCompra.Cancelada;
                case EstadoCompra.Aceptada:
                    return nuevo == EstadoCompra.Enviada || nuevo == EstadoCompra.Cancelada;
                case EstadoCompra.Enviada:
                    return nuevo == EstadoCompra.Recibida;
                default:
                    return false; // Recibida y Cancelada son finales
            }
        }

        public static void CambiarEstado(int idCompra, int nuevoEstado)
        {
            Compra compra = DataCompras.GetCompraById(idCompra);
            if (compra == null)
                throw new ArgumentException("La compra no existe.");

            // Recibida solo por MarcarCompraRecibida, que suma el stock
            if (nuevoEstado == EstadoCompra.Recibida)
                throw new InvalidOperationException("Use MarcarCompraRecibida para registrar la recepción.");

            if (!EsTransicionValida(compra.Estado, nuevoEstado))
                throw new InvalidOperationException("La transición de estado no es válida.");

            DataCompras.CambiarEstado(idCompra, nuevoEstado);
        }

        public static void MarcarCompraRecibida(int idCompra)
        {
            Compra compra = DataCompras.GetCompraById(idCompra);

            if (compra == null)
                throw new ArgumentException("La compra no existe.");

            if (compra.Estado != EstadoCompra.Enviada)
                throw new ArgumentException("Solo se puede marcar como recibida una compra que fue enviada.");

            List<DetalleCompra> detalles = DataDetalleCompras.GetDetallesByIdCompra(idCompra);

            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("La compra no tiene detalle de insumos.");

            NDetalleCompras.ValidarDetalles(detalles);

            DataCompras.MarcarCompraRecibidaConIncrementoStock(idCompra, detalles);
        }

        // ---------- Pagos ----------
        public static int DeterminarEstadoPago(decimal total, decimal pagado)
        {
            if (pagado >= total) return EstadoPago.Pagado;
            return EstadoPago.Pendiente;
        }

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

            // El pago no cambia el estado de la compra, solo el estado de pago.
            if (nuevoMonto >= (decimal)compra.TotalCompra)
                DataCompras.CambiarEstadoPago(idCompra, EstadoPago.Pagado);
        }

        public static void ActualizarFechas(int idCompra, DateTime fecha, DateTime? fechaRecepcion)
        {
            ValidarFechaCompra(fecha);
            if (fechaRecepcion.HasValue && fechaRecepcion.Value.Date < fecha.Date)
                throw new ArgumentException("La fecha de recepción no puede ser anterior a la fecha de la compra.");

            DataCompras.ActualizarFechas(idCompra, fecha, fechaRecepcion);
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

                // Pagado => saldada; si no, se usa el monto pagado acumulado
                if (c.EstadoPago == EstadoPago.Pagado)
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
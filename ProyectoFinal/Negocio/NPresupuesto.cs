using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class NPresupuesto
    {
        public static int RegistrarPresupuesto(Presupuesto presupuesto, List<DetallePresupuesto> detalles)
        {
            if (presupuesto == null)
                throw new ArgumentNullException(nameof(presupuesto), "El presupuesto no puede ser nulo.");

            if (presupuesto.IdSolicitud <= 0)
                throw new ArgumentException("Debe seleccionar una solicitud de cotización válida.");

            SolicitudCotizacion solicitud = NSolicitudCotizacion.GetById(presupuesto.IdSolicitud);
            if (solicitud == null)
                throw new ArgumentException("La solicitud de cotización no existe.");

            if (solicitud.Estado == EstadoSolicitudCotizacion.Aceptada || solicitud.Estado == EstadoSolicitudCotizacion.Cancelada)
                throw new ArgumentException("La solicitud ya está cerrada.");

            if (DataPresupuesto.ExisteActivoPorSolicitud(presupuesto.IdSolicitud))
                throw new ArgumentException("Ya existe un presupuesto activo para esa solicitud.");

            presupuesto.Total = ValidarDetallesYCalcularTotal(detalles);
            presupuesto.Fecha = presupuesto.Fecha == default(DateTime) ? DateTime.Now.Date : presupuesto.Fecha.Date;

            int idPresupuesto = DataPresupuesto.CrearPresupuestoConDetalle(presupuesto, detalles);

            foreach (DetallePresupuesto detalle in detalles)
            {
                DataPrecioProveedor.Upsert(solicitud.IdProveedor, detalle.IdInsumo, detalle.PrecioUnitario, presupuesto.Fecha);
            }

            if (solicitud.Estado == EstadoSolicitudCotizacion.Emitida)
            {
                NSolicitudCotizacion.CambiarEstado(presupuesto.IdSolicitud, EstadoSolicitudCotizacion.Recibida);
            }

            return idPresupuesto;
        }

        public static void ModificarPresupuesto(Presupuesto presupuesto, List<DetallePresupuesto> detalles)
        {
            if (presupuesto == null)
                throw new ArgumentNullException(nameof(presupuesto), "El presupuesto no puede ser nulo.");

            if (presupuesto.IdPresupuesto <= 0)
                throw new ArgumentException("El identificador del presupuesto no es válido.");

            Presupuesto existente = DataPresupuesto.GetById(presupuesto.IdPresupuesto);
            if (existente == null || existente.Activo != 1)
                throw new ArgumentException("El presupuesto no existe o está eliminado.");

            SolicitudCotizacion solicitud = NSolicitudCotizacion.GetById(presupuesto.IdSolicitud);
            if (solicitud == null)
                throw new ArgumentException("La solicitud de cotización no existe.");

            if (solicitud.Estado != EstadoSolicitudCotizacion.Recibida)
                throw new ArgumentException("Solo se puede modificar un presupuesto mientras la solicitud está recibida.");

            presupuesto.Total = ValidarDetallesYCalcularTotal(detalles);
            presupuesto.Fecha = presupuesto.Fecha == default(DateTime) ? DateTime.Now.Date : presupuesto.Fecha.Date;

            DataPresupuesto.ModificarPresupuestoConDetalle(presupuesto, detalles);

            foreach (DetallePresupuesto detalle in detalles)
            {
                DataPrecioProveedor.Upsert(solicitud.IdProveedor, detalle.IdInsumo, detalle.PrecioUnitario, presupuesto.Fecha);
            }
        }

        public static void EliminarPresupuesto(int idPresupuesto)
        {
            if (idPresupuesto <= 0)
                throw new ArgumentException("El identificador del presupuesto no es válido.");

            if (DataPresupuesto.GetById(idPresupuesto) == null)
                throw new ArgumentException("El presupuesto no existe.");

            DataPresupuesto.Eliminar(idPresupuesto);
        }

        public static void ReactivarPresupuesto(int idPresupuesto)
        {
            if (idPresupuesto <= 0)
                throw new ArgumentException("El identificador del presupuesto no es válido.");

            Presupuesto presupuesto = DataPresupuesto.GetById(idPresupuesto);
            if (presupuesto == null)
                throw new ArgumentException("El presupuesto no existe.");

            if (DataPresupuesto.ExisteActivoPorSolicitud(presupuesto.IdSolicitud))
                throw new ArgumentException("Ya existe un presupuesto activo para esa solicitud.");

            DataPresupuesto.Reactivar(idPresupuesto);
        }

        public static void AceptarPresupuesto(int idPresupuesto)
        {
            Presupuesto presupuesto = CargarPresupuesto(idPresupuesto);
            NSolicitudCotizacion.CambiarEstado(presupuesto.IdSolicitud, EstadoSolicitudCotizacion.Aceptada);
        }

        public static void RechazarPresupuesto(int idPresupuesto)
        {
            Presupuesto presupuesto = CargarPresupuesto(idPresupuesto);
            NSolicitudCotizacion.CambiarEstado(presupuesto.IdSolicitud, EstadoSolicitudCotizacion.Cancelada);
        }

        public static List<Presupuesto> GetAll()
        {
            return DataPresupuesto.GetAll();
        }

        public static List<Presupuesto> GetDeleted()
        {
            return DataPresupuesto.GetDeleted();
        }

        public static Presupuesto GetById(int idPresupuesto)
        {
            if (idPresupuesto <= 0)
                throw new ArgumentException("El identificador del presupuesto no es válido.");

            return DataPresupuesto.GetById(idPresupuesto);
        }

        public static List<DetallePresupuesto> GetDetalles(int idPresupuesto)
        {
            if (idPresupuesto <= 0)
                throw new ArgumentException("El identificador del presupuesto no es válido.");

            return DataPresupuesto.GetDetallesByPresupuesto(idPresupuesto);
        }

        public static List<SolicitudCotizacion> GetSolicitudesPendientes()
        {
            return DataPresupuesto.GetSolicitudesPendientes();
        }

        public static Dictionary<int, decimal> GetPreciosProveedor(int idProveedor)
        {
            return DataPrecioProveedor.GetByProveedorId(idProveedor).ToDictionary(p => p.IdInsumo, p => p.Precio);
        }

        private static Presupuesto CargarPresupuesto(int idPresupuesto)
        {
            if (idPresupuesto <= 0)
                throw new ArgumentException("El identificador del presupuesto no es válido.");

            Presupuesto presupuesto = DataPresupuesto.GetById(idPresupuesto);
            if (presupuesto == null || presupuesto.Activo != 1)
                throw new ArgumentException("El presupuesto no existe o está eliminado.");

            return presupuesto;
        }

        private static decimal ValidarDetallesYCalcularTotal(List<DetallePresupuesto> detalles)
        {
            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("Debe indicar al menos un insumo para el presupuesto.");

            decimal total = 0m;
            foreach (DetallePresupuesto detalle in detalles)
            {
                if (detalle == null)
                    throw new ArgumentException("Hay una fila de detalle inválida.");

                if (detalle.IdInsumo <= 0)
                    throw new ArgumentException("Debe seleccionar un insumo válido.");

                if (detalle.Cantidad <= 0)
                    throw new ArgumentException("La cantidad debe ser mayor a cero.");

                if (detalle.PrecioUnitario <= 0)
                    throw new ArgumentException("El precio unitario debe ser mayor a cero.");

                detalle.Subtotal = Math.Round(detalle.PrecioUnitario * detalle.Cantidad, 2);
                total += detalle.Subtotal;
            }

            return total;
        }
    }
}

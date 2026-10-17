using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NSolicitudCotizacion
    {
        public static List<DetalleSolicitudCotizacion> CalcularFaltante(int idProducto, int cantidadProducida)
        {
            if (idProducto <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido.");

            if (cantidadProducida <= 0)
                throw new ArgumentException("La cantidad a producir debe ser mayor a cero.");

            List<RecetaProducto> receta = NRecetaProducto.ObtenerPorProducto(idProducto);

            // Ignoramos los ítems de la receta cuyo insumo esté inactivo (1 sola query).
            HashSet<int> activos = new HashSet<int>(NInsumos.GetAllInsumos().ConvertAll(i => i.Id));

            List<DetalleSolicitudCotizacion> faltantes = new List<DetalleSolicitudCotizacion>();

            foreach (RecetaProducto item in receta)
            {
                if (!activos.Contains(item.IdInsumo)) continue;

                decimal necesidad = item.CantidadPorUnidad * cantidadProducida;

                StockInsumo stock = DataStockInsumo.GetStockByInsumoId(item.IdInsumo);
                decimal disponible = stock != null ? stock.CantidadDisponible : 0m;

                decimal faltante = necesidad - disponible;

                if (faltante > 0)
                {
                    faltantes.Add(new DetalleSolicitudCotizacion
                    {
                        IdInsumo = item.IdInsumo,
                        Cantidad = faltante,
                        NombreInsumo = item.NombreInsumo,
                        UnidadMedidaInsumo = item.UnidadMedidaInsumo
                    });
                }
            }

            return faltantes;
        }

        public static int RegistrarSolicitud(SolicitudCotizacion solicitud, List<DetalleSolicitudCotizacion> detalles)
        {
            if (solicitud == null)
                throw new ArgumentNullException(nameof(solicitud), "La solicitud no puede ser nula.");

            Proveedor prov = NProveedores.GetById(solicitud.IdProveedor);
            if (prov == null || prov.activo == 0)
                throw new ArgumentException("El proveedor seleccionado no existe.");

            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("Debe indicar al menos un insumo para cotizar.");

            foreach (DetalleSolicitudCotizacion detalle in detalles)
            {
                if (detalle == null)
                    throw new ArgumentException("Hay una fila de detalle inválida.");

                if (detalle.IdInsumo <= 0)
                    throw new ArgumentException("Debe seleccionar un insumo válido.");

                if (detalle.Cantidad <= 0)
                    throw new ArgumentException("La cantidad debe ser mayor a cero.");

                Insumo insumo = NInsumos.GetInsumoById(detalle.IdInsumo);
                if (insumo == null || insumo.Activo == 0)
                    throw new ArgumentException("El insumo seleccionado no existe o está inactivo.");
            }

            solicitud.Estado = EstadoSolicitudCotizacion.Emitida;
            solicitud.Fecha = solicitud.Fecha == default(DateTime) ? DateTime.Now.Date : solicitud.Fecha.Date;

            return DataSolicitudCotizacion.CrearSolicitudConDetalle(solicitud, detalles);
        }

        public static List<SolicitudCotizacion> GetAll()
        {
            return DataSolicitudCotizacion.GetAll();
        }

        public static SolicitudCotizacion GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El identificador de la solicitud no es válido.");

            return DataSolicitudCotizacion.GetById(id);
        }

        public static List<DetalleSolicitudCotizacion> GetDetalles(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El identificador de la solicitud no es válido.");

            return DataSolicitudCotizacion.GetDetallesBySolicitud(id);
        }

        public static bool EsTransicionValida(int actual, int nuevo)
        {
            return (actual == EstadoSolicitudCotizacion.Emitida && nuevo == EstadoSolicitudCotizacion.Recibida)
                || (actual == EstadoSolicitudCotizacion.Recibida && nuevo == EstadoSolicitudCotizacion.Aceptada)
                || (actual == EstadoSolicitudCotizacion.Recibida && nuevo == EstadoSolicitudCotizacion.Cancelada);
        }

        public static void CambiarEstado(int idSolicitud, int nuevoEstado)
        {
            if (idSolicitud <= 0)
                throw new ArgumentException("El identificador de la solicitud no es válido.");

            SolicitudCotizacion solicitud = GetById(idSolicitud);
            if (solicitud == null)
                throw new ArgumentException("La solicitud de cotización no existe.");

            if (!EsTransicionValida(solicitud.Estado, nuevoEstado))
                throw new ArgumentException("Transición de estado no permitida.");

            DataSolicitudCotizacion.ActualizarEstado(idSolicitud, nuevoEstado);
        }
    }
}

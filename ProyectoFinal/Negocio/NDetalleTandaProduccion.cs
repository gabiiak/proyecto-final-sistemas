using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NDetalleTandaProduccion
    {
        public static int RegistrarDetalle(DetalleTandaProduccion detalle)
        {
            if (detalle == null)
                throw new ArgumentNullException(nameof(detalle), "El detalle de la tanda no puede ser nulo.");

            if (detalle.TandaProduccion == null || detalle.TandaProduccion.IdTanda <= 0)
                throw new ArgumentException("El detalle debe estar asociado a una tanda válida.");

            if (detalle.Insumo == null || detalle.Insumo.Id <= 0)
                throw new ArgumentException("Debe seleccionar un insumo válido.");

            if (detalle.Empleado == null || detalle.Empleado.IdEmpleado <= 0)
                throw new ArgumentException("Debe asignar un empleado responsable válido.");

            if (detalle.CantidadProducida <= 0)
                throw new ArgumentException("La cantidad producida debe ser mayor a cero.");

            // Valida que la tanda no esté cerrada ni cancelada
            int? estadoTanda = DataTandaProduccion.GetEstadoActual(detalle.TandaProduccion.IdTanda);
            if (estadoTanda == null)
                throw new InvalidOperationException("La tanda asociada no existe.");

            if (estadoTanda == EstadoTanda.Terminada || estadoTanda == EstadoTanda.Cancelada)
                throw new InvalidOperationException("No se pueden agregar insumos o detalles a una tanda terminada o cancelada.");

            return DataDetalleTandaProduccion.CreateDetalleTanda(detalle);
        }

        public static List<DetalleTandaProduccion> ObtenerDetallesPorTanda(int idTanda)
        {
            if (idTanda <= 0)
                throw new ArgumentException("El identificador de la tanda no es válido.");

            return DataDetalleTandaProduccion.GetDetallesByTanda(idTanda);
        }

        public static void EliminarDetalle(int idDetalleTanda)
        {
            if (idDetalleTanda <= 0)
                throw new ArgumentException("El identificador del detalle no es válido.");

            DataDetalleTandaProduccion.EliminarDetalle(idDetalleTanda);
        }
    }
}
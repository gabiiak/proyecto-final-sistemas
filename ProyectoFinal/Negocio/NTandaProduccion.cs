using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NTandaProduccion
    {
        public static int RegistrarTanda(TandaProduccion tanda)
        {
            if (tanda == null)
                throw new ArgumentNullException(nameof(tanda), "La tanda no puede ser nula.");

            if (tanda.Producto == null || tanda.Producto.IdProducto <= 0)
                throw new ArgumentException("Debe seleccionar un producto válido para la tanda.");

            if (tanda.Fecha == DateTime.MinValue)
                tanda.Fecha = DateTime.Today;

            if (tanda.Hora == DateTime.MinValue)
                tanda.Hora = DateTime.Now;

            // Si no se asignó estado, arranca por defecto en Pendiente
            if (tanda.EstadoTanda < EstadoTanda.EnProceso || tanda.EstadoTanda > EstadoTanda.Cancelada)
                tanda.EstadoTanda = EstadoTanda.Pendiente;

            return DataTandaProduccion.CreateTanda(tanda);
        }

        public static List<TandaProduccion> ListarTandas()
        {
            return DataTandaProduccion.GetAllTandas();
        }

        public static TandaProduccion ObtenerPorId(int idTanda)
        {
            if (idTanda <= 0)
                throw new ArgumentException("El identificador de la tanda no es válido.");

            return DataTandaProduccion.GetTandaById(idTanda);
        }

        public static void CambiarEstado(int idTanda, int nuevoEstado)
        {
            if (idTanda <= 0)
                throw new ArgumentException("El identificador de la tanda no es válido.");

            int? estadoActual = DataTandaProduccion.GetEstadoActual(idTanda);
            if (estadoActual == null)
                throw new InvalidOperationException("La tanda especificada no existe.");

            // Reglas de negocio para el flujo de estados
            if (estadoActual == EstadoTanda.Cancelada)
                throw new InvalidOperationException("No se puede modificar una tanda que ya está cancelada.");

            if (estadoActual == EstadoTanda.Terminada && nuevoEstado != EstadoTanda.Terminada)
                throw new InvalidOperationException("No se puede modificar una tanda que ya fue terminada.");

            DataTandaProduccion.CambiarEstado(idTanda, nuevoEstado);
        }

        public static void EliminarTanda(int idTanda)
        {
            if (idTanda <= 0)
                throw new ArgumentException("El identificador de la tanda no es válido.");

            int? estadoActual = DataTandaProduccion.GetEstadoActual(idTanda);
            if (estadoActual == null)
                throw new InvalidOperationException("La tanda a eliminar no existe.");

            if (estadoActual == EstadoTanda.EnProceso)
                throw new InvalidOperationException("No se puede eliminar una tanda en proceso. Debe cancelarse primero.");

            // Elimina en cascada los detalles asociados antes de la cabecera
            DataDetalleTandaProduccion.EliminarDetallesPorTanda(idTanda);
            DataTandaProduccion.EliminarTanda(idTanda);
        }
    }
}
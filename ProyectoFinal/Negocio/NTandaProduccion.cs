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

            if (tanda.CantidadProducida <= 0)
                throw new ArgumentException("La cantidad producida debe ser mayor a cero.");

            if (tanda.Fecha == DateTime.MinValue)
                tanda.Fecha = DateTime.Today;

            if (tanda.Hora == DateTime.MinValue)
                tanda.Hora = DateTime.Now;

            if (tanda.EstadoTanda < EstadoTanda.EnProceso || tanda.EstadoTanda > EstadoTanda.Cancelada)
                tanda.EstadoTanda = EstadoTanda.Pendiente;

            List<RecetaProducto> receta = NRecetaProducto.ObtenerPorProducto(tanda.Producto.IdProducto);

            if (receta == null || receta.Count == 0)
                throw new ArgumentException("Este producto no tiene una receta definida. Cargue la receta antes de registrar una tanda.");

            NDetalleTandaProduccion.ValidarStockSuficiente(receta, tanda.CantidadProducida);

            List<DetalleTandaProduccion> detalles = new List<DetalleTandaProduccion>();

            foreach (RecetaProducto item in receta)
            {
                detalles.Add(new DetalleTandaProduccion
                {
                    Insumo = new Insumo { Id = item.IdInsumo, Nombre = item.NombreInsumo },
                    CantidadUtilizada = item.CantidadPorUnidad * tanda.CantidadProducida,
                    Empleado = null
                });
            }

            return DataTandaProduccion.CrearTandaConDetalle(tanda, detalles);
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
        // En Negocio, NTandaProduccion
        public static void CancelarTanda(int idTanda)
        {
            TandaProduccion tanda = DataTandaProduccion.GetTandaById(idTanda);

            if (tanda == null)
                throw new ArgumentException("La tanda no existe.");

            if (tanda.EstadoTanda == EstadoTanda.Terminada)
                throw new ArgumentException("No se puede cancelar una tanda que ya fue finalizada.");

            if (tanda.EstadoTanda == EstadoTanda.Cancelada)
                throw new ArgumentException("La tanda ya se encuentra cancelada.");

            DataTandaProduccion.CambiarEstado(idTanda, EstadoTanda.Cancelada);
        }
        public static void FinalizarTanda(int idTanda)
        {
            TandaProduccion tanda = DataTandaProduccion.GetTandaById(idTanda);

            if (tanda == null)
                throw new ArgumentException("La tanda no existe.");

            if (tanda.EstadoTanda != EstadoTanda.Pendiente && tanda.EstadoTanda != EstadoTanda.EnProceso)
                throw new ArgumentException("Solo se pueden finalizar tandas pendientes o en proceso.");

            List<DetalleTandaProduccion> detalles = DataDetalleTandaProduccion.GetDetallesByTanda(idTanda);

            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("La tanda no tiene detalle de insumos registrado.");
            
            if (tanda.Producto.VidaUtilDias <= 0)
                throw new ArgumentException($"El producto '{tanda.Producto.Nombre}' no tiene definida su vida útil en días.");

            DateTime fechaCaducidadCalculada = tanda.Fecha.AddDays(tanda.Producto.VidaUtilDias);
            // Revalidar stock (puede haber cambiado desde que se creó la tanda)
            foreach (DetalleTandaProduccion detalle in detalles)
            {
                StockInsumo stockActual = DataStockInsumo.GetStockByInsumoId(detalle.Insumo.Id);

                if (stockActual == null)
                    throw new ArgumentException($"No existe stock cargado para el insumo '{detalle.Insumo.Nombre}'.");

                if (stockActual.CantidadDisponible < detalle.CantidadUtilizada)
                    throw new ArgumentException(
                        $"Stock insuficiente de '{detalle.Insumo.Nombre}' al momento de finalizar. Disponible: {stockActual.CantidadDisponible}, necesario: {detalle.CantidadUtilizada}.");
            }
            Console.WriteLine($"DEBUG - idProducto: {tanda.Producto.IdProducto}, cantidadProducida: {tanda.CantidadProducida}");
            DataTandaProduccion.FinalizarTandaConMovimientoStock(idTanda, tanda.Producto.IdProducto, tanda.CantidadProducida, detalles, fechaCaducidadCalculada);
        }
    }
}
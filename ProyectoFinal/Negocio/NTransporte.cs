using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NTransporte
    {
        public static int CreateTransporte(Transporte transporte)
        {
            if (transporte == null)
                throw new ArgumentException("El transporte no puede ser nulo.");

            if (transporte.Venta == null)
                throw new ArgumentException("Debe indicar la venta asociada al transporte.");

            if (transporte.Fecha < DateTime.Now)
                throw new ArgumentException("No se puede programar un transporte para una fecha y hora en el pasado.");

            if (transporte.Estado < EstadoTransporte.programado || transporte.Estado > EstadoTransporte.cancelado)
                throw new ArgumentException("El estado del transporte no es válido.");

            return DataTransporte.CreateTransporte(transporte);
        }

        public static List<Transporte> GetAllTransportes()
        {
            return DataTransporte.GetAllTransportes();
        }

        public static void EliminarTransporte(int idTransporte)
        {
            int? estadoActual = DataTransporte.GetEstadoActual(idTransporte);

            if (estadoActual == null)
                throw new ArgumentException("El transporte no existe.");

            DataTransporte.EliminarTransporte(idTransporte);
        }

        public static void CambiarEstado(int idTransporte, int estado)
        {
            if (estado < EstadoTransporte.programado || estado > EstadoTransporte.cancelado)
                throw new ArgumentException("El estado del transporte no es válido.");

            int? estadoActual = DataTransporte.GetEstadoActual(idTransporte);

            if (estadoActual == null)
                throw new ArgumentException("El transporte no existe.");

            if (estadoActual == EstadoTransporte.Entregado || estadoActual == EstadoTransporte.cancelado)
                throw new ArgumentException("Este transporte ya fue entregado o cancelado y no se puede modificar.");

            DataTransporte.CambiarEstado(idTransporte, estado);
        }
    }
}
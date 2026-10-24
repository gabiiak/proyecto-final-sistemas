using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEvaluacionProveedor
    {
        public static void GuardarEvaluacion(EvaluacionProveedor evaluacion)
        {
            if (evaluacion == null)
                throw new Exception("La evaluación no puede estar vacía");

            Compra compra = DataCompras.GetCompraById(evaluacion.IdCompra);

            if (compra == null)
                throw new Exception("La compra seleccionada no existe");

            if (compra.Estado == EstadoCompra.Cancelada)
                throw new Exception("No se puede evaluar una compra cancelada");

            if (evaluacion.Calidad.HasValue &&
                (evaluacion.Calidad.Value < 1 || evaluacion.Calidad.Value > 5))
                throw new Exception("La calidad debe estar entre 1 y 5");

            if (compra.Estado != EstadoCompra.Recibida &&
                evaluacion.Calidad.HasValue)
                throw new Exception("Solo se puede calificar la calidad de una compra recibida");

            if (compra.Estado == EstadoCompra.Recibida)
                throw new InvalidOperationException(
                    "La fecha prometida debe registrarse antes de recibir la compra");

            if (evaluacion.FechaPrometida.Date < compra.Fecha.Date)
                throw new ArgumentException(
                    "La fecha prometida no puede ser anterior a la fecha de compra");

            if (DataEvaluacionProveedor.ObtenerTodas()
                .Any(e => e.IdCompra == evaluacion.IdCompra))
                throw new InvalidOperationException(
                    "Esta compra ya tiene una evaluación registrada");

            DataEvaluacionProveedor.Guardar(evaluacion);
        }

        public static void ActualizarEvaluacion(EvaluacionProveedor evaluacion)
        {
            if (evaluacion == null)
                throw new ArgumentException("La evaluación no puede estar vacía");

            Compra compra = DataCompras.GetCompraById(evaluacion.IdCompra);

            if (compra == null)
                throw new InvalidOperationException("La compra no existe");

            if (compra.Estado == EstadoCompra.Cancelada)
                throw new InvalidOperationException(
                    "No se puede evaluar una compra cancelada");

            if (evaluacion.Calidad.HasValue &&
                (evaluacion.Calidad.Value < 1 || evaluacion.Calidad.Value > 5))
                throw new ArgumentException(
                    "La calidad debe estar entre 1 y 5");

            if (compra.Estado != EstadoCompra.Recibida &&
                evaluacion.Calidad.HasValue)
                throw new InvalidOperationException(
                    "Solo se puede evaluar la calidad de una compra recibida");

            EvaluacionProveedor anterior =
                DataEvaluacionProveedor.ObtenerTodas()
                .Find(e => e.IdCompra == evaluacion.IdCompra);

            if (anterior == null)
                throw new InvalidOperationException(
                    "La compra todavía no tiene una evaluación registrada");


            if (evaluacion.FechaPrometida.Date != anterior.FechaPrometida.Date)
                throw new InvalidOperationException(
                    "No se puede modificar la fecha prometida una vez registrada.");


            DataEvaluacionProveedor.Actualizar(evaluacion);
        }


        public static List<EvaluacionProveedor> ObtenerEvaluaciones()
        {
            return DataEvaluacionProveedor.ObtenerTodas();
        }
    }
}

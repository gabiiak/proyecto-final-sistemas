using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Modelos;

namespace Negocio
{
    public static class NDatosEntrenamientoReal
    {
        public static List<DatosEntrenamientoProveedor> Obtener()
        {
            var compras = DataCompras.GetAllCompras();
            var evaluaciones = DataEvaluacionProveedor.ObtenerTodas();

            // solo utilizamos compras recibidas con fecha real.
            var registros = (
                from compra in compras
                join evaluacion in evaluaciones
                    on compra.IdCompra equals evaluacion.IdCompra
                where compra.Estado == EstadoCompra.Recibida
                    && compra.FechaRecepcion.HasValue
                    && evaluacion.FechaPrometida.Date
                        >= compra.Fecha.Date
                orderby compra.FechaRecepcion.Value,
                        compra.IdCompra
                select new
                {
                    Compra = compra,
                    Evaluacion = evaluacion
                }).ToList();

            var resultado =
                new List<DatosEntrenamientoProveedor>();

            // guardamos los antecedentes de cada proveedor.
            var historial =
                new Dictionary<int, List<bool>>();

            foreach (var registro in registros)
            {
                var compra = registro.Compra;
                var evaluacion = registro.Evaluacion;

                if (!historial.ContainsKey(compra.IdProveedor))
                {
                    historial[compra.IdProveedor] =
                        new List<bool>();
                }

                var anteriores = historial[compra.IdProveedor];

                // se calcula con entregas anteriores,
                // nunca con la entrega que queremos predecir.
                float cumplimientoPrevio = anteriores.Count > 0
                    ? (float)anteriores.Count(x => x) /
                        anteriores.Count
                    : 0.5f;

                bool puntual =
                    compra.FechaRecepcion.Value.Date <=
                    evaluacion.FechaPrometida.Date;

                int plazo = (int)(
                    evaluacion.FechaPrometida.Date -
                    compra.Fecha.Date).TotalDays;

                resultado.Add(new DatosEntrenamientoProveedor
                {
                    IdProveedor = compra.IdProveedor,

                    // pendiente: incorporar el importe real
                    // cuando verifiquemos su propiedad en Compra.
                    MontoCompra = 0f,

                    CantidadComprasPrevias = anteriores.Count,

                    PorcentajeCumplimientoPrevio =
                        cumplimientoPrevio,

                    DiasPlazoEntrega = plazo,

                    EntregaPuntual = puntual
                });

                // actualizamos el historial recién después
                // de preparar este registro.
                anteriores.Add(puntual);
            }

            return resultado;
        }

        public static string VerificarDatosDisponibles()
        {
            var datos = Obtener();

            int puntuales =
                datos.Count(x => x.EntregaPuntual);

            int tardias = datos.Count - puntuales;

            if (datos.Count < 30)
            {
                return "Todavía no hay suficientes datos " +
                    "para entrenar y evaluar la IA real.\n\n" +
                    "Entregas evaluables: " + datos.Count +
                    "\nPuntuales: " + puntuales +
                    "\nTardías: " + tardias +
                    "\n\nSe necesitan al menos 30 registros " +
                    "como mínimo inicial de prueba.";
            }

            if (puntuales == 0 || tardias == 0)
            {
                return "No se puede entrenar todavía.\n\n" +
                    "El modelo necesita ejemplos de entregas " +
                    "puntuales y tardías.";
            }

            return "Hay " + datos.Count +
                " registros históricos disponibles.\n" +
                "Puntuales: " + puntuales +
                "\nTardías: " + tardias +
                "\n\nLos datos están listos para comprobar " +
                "si permiten entrenar y validar el modelo.";
        }
    }
}

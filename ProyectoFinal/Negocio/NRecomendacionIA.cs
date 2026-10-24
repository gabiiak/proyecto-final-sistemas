using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.Linq;
using Modelos;

namespace Negocio
{
    // Resultado de la predicción de un proveedor.
    public class ResultadoRecomendacionIA
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public double EstimacionCumplimiento { get; set; }
        public int EntregasEvaluadas { get; set; }
        public double CumplimientoHistorico { get; set; }
        public double? CalidadPromedio { get; set; }
    }

    public class NRecomendacionIA
    {
        public static List<ResultadoRecomendacionIA>
            RecomendarProveedores(int diasPlazo = 5)
        {
            if (diasPlazo <= 0)
                throw new InvalidOperationException(
                    "El plazo de entrega debe ser mayor a cero.");

            // 1. recuperamos los datos reales de SQL Server.
            var datosReales = NDatosEntrenamientoReal.Obtener();

            if (datosReales.Count < 30)
                throw new InvalidOperationException(
                    "Todavía no hay suficientes entregas " +
                    "históricas para generar predicciones.");

            if (!datosReales.Any(d => d.EntregaPuntual) ||
                !datosReales.Any(d => !d.EntregaPuntual))
                throw new InvalidOperationException(
                    "Se necesitan entregas puntuales y tardías " +
                    "para entrenar el modelo.");

            // 2. entrenamos ML.NET con el historial disponible
            var predictor = new ModeloPredictivoProveedor();

            var modelo = predictor.Entrenar(datosReales);

            // 3. obtenemos los antecedentes de cada proveedor
            var proveedores =
                NAnalisisProveedores.ObtenerResumenes();

            var resultados =
                new List<ResultadoRecomendacionIA>();

            foreach (var proveedor in proveedores)
            {
                // evitamos recomendar proveedores sin historial
                if (proveedor.TotalEntregas < 3)
                    continue;

                // 4. preparamos una compra futura hipotética.
                var nuevaCompra =
                    new DatosEntrenamientoProveedor
                    {
                        IdProveedor = proveedor.IdProveedor,

                        // por ahora el importe real todavía
                        // no está conectado al modelo
                        MontoCompra = 0f,

                        CantidadComprasPrevias =
                            proveedor.TotalEntregas,

                        PorcentajeCumplimientoPrevio =
                            (float)(
                                proveedor.PorcentajeCumplimiento
                                / 100.0),

                        DiasPlazoEntrega = diasPlazo
                    };

                // 5. ml.net genera una predicción
                var prediccion =
                    predictor.Predecir(modelo, nuevaCompra);

                resultados.Add(
                    new ResultadoRecomendacionIA
                    {
                        IdProveedor = proveedor.IdProveedor,

                        NombreProveedor =
                            proveedor.NombreProveedor,

                        EstimacionCumplimiento =
                            prediccion.Probabilidad * 100.0,

                        EntregasEvaluadas =
                            proveedor.TotalEntregas,

                        CumplimientoHistorico =
                            proveedor.PorcentajeCumplimiento,

                        CalidadPromedio =
                            proveedor.PromedioCalidad
                    });
            }

            // 6. ordenamos según la estimación del modelo
            return resultados
                .OrderByDescending(
                    p => p.EstimacionCumplimiento)
                .ThenByDescending(
                    p => p.CumplimientoHistorico)
                .ToList();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;

namespace Negocio
{
    public class ModeloPredictivoProveedor
    {
        private readonly MLContext mlContext;

        public ModeloPredictivoProveedor()
        {
            mlContext = new MLContext(seed: 42);
        }

        public ITransformer Entrenar(
            List<DatosEntrenamientoProveedor> datos,
            int minimoRegistros = 30)
        {
            if (datos == null || datos.Count < minimoRegistros)
                throw new InvalidOperationException(
                    "Se necesitan al menos " + minimoRegistros +
                    " entregas para este entrenamiento.");


            if (!datos.Any(d => d.EntregaPuntual) ||
                !datos.Any(d => !d.EntregaPuntual))
                throw new InvalidOperationException(
                    "Se necesitan ejemplos de entregas puntuales y tardías.");

            var datosML = mlContext.Data.LoadFromEnumerable(datos);

            var proceso = mlContext.Transforms.Concatenate(
                "Features",
                nameof(DatosEntrenamientoProveedor.MontoCompra),
                nameof(DatosEntrenamientoProveedor.CantidadComprasPrevias),
                nameof(DatosEntrenamientoProveedor.PorcentajeCumplimientoPrevio),
                nameof(DatosEntrenamientoProveedor.DiasPlazoEntrega)
            )

                .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                .Append(mlContext.BinaryClassification.Trainers
                    .SdcaLogisticRegression(
                        labelColumnName: "Label",
                        featureColumnName: "Features"));


            return proceso.Fit(datosML);

        }

        public ResultadoPruebaIA EvaluarPrueba()
        {
            var datos = DatosPruebaIA.Generar();

            Random random = new Random(42);

            var mezclados = datos
                .OrderBy(x => random.Next())
                .ToList();

            int cantidadEntrenamiento =
                (int)(mezclados.Count * 0.80);

            var entrenamiento = mezclados
                .Take(cantidadEntrenamiento)
                .ToList();

            var prueba = mezclados
                .Skip(cantidadEntrenamiento)
                .ToList();

            ITransformer modelo = Entrenar(entrenamiento);

            var datosPrueba =
                mlContext.Data.LoadFromEnumerable(prueba);

            var predicciones = modelo.Transform(datosPrueba);

            var metricas = mlContext.BinaryClassification
                .Evaluate(predicciones, labelColumnName: "Label");

            int puntualesEntrenamiento =
                entrenamiento.Count(x => x.EntregaPuntual);

            bool claseMayoritaria =
                puntualesEntrenamiento >= entrenamiento.Count -
                puntualesEntrenamiento;

            int aciertosBasicos =
                prueba.Count(x => x.EntregaPuntual == claseMayoritaria);

            double exactitudBasica =
                (double)aciertosBasicos / prueba.Count;

            return new ResultadoPruebaIA
            {
                RegistrosEntrenamiento = entrenamiento.Count,
                RegistrosPrueba = prueba.Count,
                PorcentajeAciertos = metricas.Accuracy,
                CapacidadDistincion = metricas.AreaUnderRocCurve,
                EquilibrioGeneral = metricas.F1Score,
                ReferenciaBasica = exactitudBasica,
                Conclusion = metricas.Accuracy > exactitudBasica
                    ? "La IA supera la referencia básica."
                    : "La IA no supera la referencia básica."
            };
        }

        public ResultadoPruebaIA EvaluarDatosReales(
            List<DatosEntrenamientoProveedor> datos)
        {
            if (datos == null || datos.Count < 30)
                throw new InvalidOperationException(
                    "Se necesitan al menos 30 entregas históricas.");

            // Los datos llegan ordenados cronológicamente
            // desde NDatosEntrenamientoReal.
            int cantidadEntrenamiento =
                (int)(datos.Count * 0.80);

            var entrenamiento = datos
                .Take(cantidadEntrenamiento)
                .ToList();

            var prueba = datos
                .Skip(cantidadEntrenamiento)
                .ToList();

            // Comprobamos que existan las dos clases.
            bool entrenamientoValido =
                entrenamiento.Any(x => x.EntregaPuntual) &&
                entrenamiento.Any(x => !x.EntregaPuntual);

            bool pruebaValida =
                prueba.Any(x => x.EntregaPuntual) &&
                prueba.Any(x => !x.EntregaPuntual);

            if (!entrenamientoValido || !pruebaValida)
            {
                throw new InvalidOperationException(
                    "Los datos se recuperaron correctamente, " +
                    "pero la división cronológica no contiene " +
                    "entregas puntuales y tardías en ambos conjuntos. " +
                    "Todavía no se puede evaluar el modelo " +
                    "con estas métricas de forma adecuada.");
            }

            // entrenamos solo con los registros anteriores
            ITransformer modelo = Entrenar(entrenamiento, 20);

            var datosPrueba =
                mlContext.Data.LoadFromEnumerable(prueba);

            var predicciones = modelo.Transform(datosPrueba);

            var metricas = mlContext.BinaryClassification
                .Evaluate(predicciones, labelColumnName: "Label");

            // referencia: predecir siempre la clase mayoritaria
            int puntualesEntrenamiento =
                entrenamiento.Count(x => x.EntregaPuntual);

            bool claseMayoritaria =
                puntualesEntrenamiento >=
                entrenamiento.Count - puntualesEntrenamiento;

            int aciertosBasicos =
                prueba.Count(x =>
                    x.EntregaPuntual == claseMayoritaria);

            double exactitudBasica =
                (double)aciertosBasicos / prueba.Count;

            return new ResultadoPruebaIA
            {
                RegistrosEntrenamiento = entrenamiento.Count,
                RegistrosPrueba = prueba.Count,

                PorcentajeAciertos = metricas.Accuracy,
                CapacidadDistincion = metricas.AreaUnderRocCurve,
                EquilibrioGeneral = metricas.F1Score,
                ReferenciaBasica = exactitudBasica,

                Conclusion = metricas.Accuracy > exactitudBasica
                    ? "La IA supera la referencia básica en esta prueba experimental."
                    : "La IA no supera la referencia básica en esta prueba experimental."
            };
        }


        public PrediccionProveedor Predecir(
            ITransformer modelo,
            DatosEntrenamientoProveedor datosProveedor)
        {
            if (modelo == null)
                throw new ArgumentNullException(nameof(modelo));

            if (datosProveedor == null)
                throw new ArgumentNullException(nameof(datosProveedor));

            var motor = mlContext.Model
                .CreatePredictionEngine<
                    DatosEntrenamientoProveedor,
                    PrediccionProveedor>(modelo);

            return motor.Predict(datosProveedor);
        }


        public string CompararProveedoresPrueba()
        {
            // generamos los datos ficticios
            var datos = DatosPruebaIA.Generar();

            // entrenamos un modelo para esta demostración owo
            ITransformer modelo = Entrenar(datos);

            // proveedores de mentirita que vamos a comparar
            var proveedores = new List<DatosEntrenamientoProveedor>
    {
        new DatosEntrenamientoProveedor
        {
            IdProveedor = 1,
            MontoCompra = 10000,
            CantidadComprasPrevias = 50,
            PorcentajeCumplimientoPrevio = 0.95f,
            DiasPlazoEntrega = 5
        },
        new DatosEntrenamientoProveedor
        {
            IdProveedor = 2,
            MontoCompra = 10000,
            CantidadComprasPrevias = 50,
            PorcentajeCumplimientoPrevio = 0.75f,
            DiasPlazoEntrega = 5
        },
        new DatosEntrenamientoProveedor
        {
            IdProveedor = 3,
            MontoCompra = 10000,
            CantidadComprasPrevias = 50,
            PorcentajeCumplimientoPrevio = 0.55f,
            DiasPlazoEntrega = 5
        },
        new DatosEntrenamientoProveedor
        {
            IdProveedor = 4,
            MontoCompra = 10000,
            CantidadComprasPrevias = 50,
            PorcentajeCumplimientoPrevio = 0.35f,
            DiasPlazoEntrega = 5
        }
    };

            int mejorProveedor = 0;
            float mejorProbabilidad = -1;

            foreach (var proveedor in proveedores)
            {
                PrediccionProveedor prediccion =
                    Predecir(modelo, proveedor);

                if (prediccion.Probabilidad > mejorProbabilidad)
                {
                    mejorProbabilidad = prediccion.Probabilidad;
                    mejorProveedor = (int)proveedor.IdProveedor;
                }
            }

            return "Proveedor de prueba " + mejorProveedor +
                   " | Probabilidad estimada: " +
                   mejorProbabilidad.ToString("P2");
        }





    }
}
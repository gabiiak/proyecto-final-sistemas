using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Modelos;

namespace Negocio
{
    public class NAnalisisProveedores
    {
        public static List<ResumenProveedor> ObtenerResumenes()
        {
            var proveedores = DataProveedores.GetAllProveedores();
            var compras = DataCompras.GetAllCompras();
            var evaluaciones =
                DataEvaluacionProveedor.ObtenerTodas();

            var resultados = new List<ResumenProveedor>();

            foreach (Proveedor proveedor in proveedores)
            {
                var comprasRecibidas = compras
                    .Where(c =>
                        c.IdProveedor == proveedor.IdProveedor &&
                        c.Estado == EstadoCompra.Recibida &&
                        c.FechaRecepcion.HasValue)
                    .ToList();

                var entregas = (
                    from compra in comprasRecibidas
                    join evaluacion in evaluaciones
                        on compra.IdCompra equals evaluacion.IdCompra
                    select new
                    {
                        FechaPrometida = evaluacion.FechaPrometida,
                        FechaRecepcion = compra.FechaRecepcion.Value,
                        Calidad = evaluacion.Calidad
                    }
                ).ToList();

                int total = entregas.Count;

                int puntuales = entregas.Count(e =>
                    e.FechaRecepcion.Date <=
                    e.FechaPrometida.Date);

                int tardias = total - puntuales;

                var calificaciones = entregas
                    .Where(e => e.Calidad.HasValue)
                    .Select(e => (double)e.Calidad.Value)
                    .ToList();

                resultados.Add(new ResumenProveedor
                {
                    IdProveedor = proveedor.IdProveedor,
                    NombreProveedor = proveedor.Nombre,
                    TotalEntregas = total,
                    EntregasPuntuales = puntuales,
                    EntregasTardias = tardias,

                    PorcentajeCumplimiento = total > 0
                        ? (double)puntuales / total * 100
                        : 0,

                    PromedioCalidad = calificaciones.Count > 0
                        ? (double?)calificaciones.Average()
                        : null
                });
            }

            return resultados;
        }
    }
}


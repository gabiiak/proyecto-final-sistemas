using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public static class DatosPruebaIA
    {
        public static List<DatosEntrenamientoProveedor> Generar()
        {
            var datos = new List<DatosEntrenamientoProveedor>();

            Random random = new Random(42);

            for (int i = 0; i < 200; i++)
            {
                int proveedor = (i % 4) + 1;

                float cumplimientoPrevio =
                    proveedor == 1 ? 0.95f :
                    proveedor == 2 ? 0.75f :
                    proveedor == 3 ? 0.55f : 0.35f;

                float plazo = random.Next(2, 11);
                float monto = random.Next(1000, 50001);
                float comprasPrevias = random.Next(5, 101);

                float probabilidad = cumplimientoPrevio;

                if (plazo <= 3)
                    probabilidad -= 0.10f;

                bool puntual =
                    random.NextDouble() < probabilidad;

                datos.Add(new DatosEntrenamientoProveedor
                {
                    IdProveedor = proveedor,
                    MontoCompra = monto,
                    CantidadComprasPrevias = comprasPrevias,
                    PorcentajeCumplimientoPrevio = cumplimientoPrevio,
                    DiasPlazoEntrega = plazo,
                    EntregaPuntual = puntual
                });
            }

            return datos;
        }
    }
}


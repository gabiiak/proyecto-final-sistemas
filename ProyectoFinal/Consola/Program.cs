using Datos;
using Modelos;
using Negocio;
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int idProductoPrueba = 1; // ajustá según tu BD, un producto con receta y VidaUtilDias cargados

            // 1. Ver el producto y su vida útil configurada
            var producto = DataTandaProduccion.GetTandaById(1)?.Producto; // o el método que uses para traer Producto directo
            Console.WriteLine("=== Datos del producto ===");
            // Si tenés un NProducto.GetById, mejor usarlo acá en vez de sacarlo de una tanda vieja
            // var producto = NProducto.GetById(idProductoPrueba);
            // Console.WriteLine($"Producto: {producto.Nombre}, VidaUtilDias: {producto.VidaUtilDias}");

            // 2. Crear la tanda
            var tanda = new TandaProduccion
            {
                Producto = new Producto { IdProducto = idProductoPrueba },
                CantidadProducida = 20,
                Fecha = DateTime.Today,
                Hora = DateTime.Now,
                EstadoTanda = EstadoTanda.Pendiente
            };

            int idTanda = NTandaProduccion.RegistrarTanda(tanda);
            Console.WriteLine($"\nTanda creada con id: {idTanda}, fecha producción: {tanda.Fecha:yyyy-MM-dd}");

            // 3. Finalizar la tanda (acá se calcula y guarda la fecha de caducidad)
            NTandaProduccion.FinalizarTanda(idTanda);
            Console.WriteLine("Tanda finalizada.");

            // 4. Releer la tanda desde la base para confirmar que la fecha quedó grabada
            TandaProduccion tandaFinalizada = DataTandaProduccion.GetTandaById(idTanda);

            Console.WriteLine("\n=== Verificación ===");
            Console.WriteLine($"Fecha de producción: {tandaFinalizada.Fecha:yyyy-MM-dd}");
            Console.WriteLine($"Fecha de caducidad guardada: {tandaFinalizada.FechaCaducidad:yyyy-MM-dd}");
            Console.WriteLine($"Vida útil del producto: {tandaFinalizada.Producto.VidaUtilDias} días");

            int diasCalculados = (tandaFinalizada.FechaCaducidad - tandaFinalizada.Fecha).Days;
            Console.WriteLine($"Diferencia real en días: {diasCalculados}");

            if (diasCalculados == tandaFinalizada.Producto.VidaUtilDias)
                Console.WriteLine("✔ La fecha de caducidad se calculó y guardó correctamente.");
            else
                Console.WriteLine("✘ La diferencia de días NO coincide con VidaUtilDias. Revisar el cálculo o el mapeo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
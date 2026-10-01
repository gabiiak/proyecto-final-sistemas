namespace Modelos
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Activo { get; set; }

        /// <summary>
        /// Días de vida útil desde que se termina de producir un lote.
        /// La fecha de caducidad concreta no se guarda acá: se calcula al finalizar
        /// la tanda como TandaProduccion.Fecha + VidaUtilDias.
        /// </summary>
        public int VidaUtilDias { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

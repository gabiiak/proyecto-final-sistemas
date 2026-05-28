using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataDetalleVentas
    {
        public static List<DetalleVenta> GetAllDetalleVentas() //para mostrar en la venta todos los detalles
        {
            List<DetalleVenta> listaDetalleVentas = new List<DetalleVenta>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT dv.idDetalleVenta AS NúmeroDetalle, dv.cantidad AS Cantidad, p.Nombre, p.Precio 
                                    FROM DetalleVentas dv INNER JOIN Productos p on dv.idProducto = p.IdProducto";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetalleVenta detalle = new DetalleVenta
                            {
                                IdDetalleVenta = reader.GetInt32(0),
                                Cantidad = reader.GetInt32(1),
                                Producto = new Producto
                                {
                                    //IdProducto = reader.GetInt32(2),
                                    Nombre = reader.GetString(2),
                                    Precio = reader.GetDouble(3)
                                }
                            };
                            listaDetalleVentas.Add(detalle);
                        }
                    }
                }
            }
            return listaDetalleVentas;
        }
        public static int CreateDetalleVenta(DetalleVenta detalle) // int para devolver el id venta
        {
            string sqlQuery = @"INSERT INTO DetalleVentas(idVenta, idProducto, cantidad) VALUES (@IdVenta, @IdProducto, @Cantidad);
                               SELECT last_insert_rowid();";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdVenta", (SqliteType)System.Data.SqlDbType.Int).Value = detalle.Venta.IdVenta;
                    cmd.Parameters.Add("@IdProducto", (SqliteType)System.Data.SqlDbType.Int).Value = detalle.Producto.IdProducto;
                    cmd.Parameters.Add("@Cantidad", (SqliteType)System.Data.SqlDbType.Int).Value = detalle.Cantidad;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}

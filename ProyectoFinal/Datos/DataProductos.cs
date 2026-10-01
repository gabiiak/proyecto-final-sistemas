using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using System.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Datos
{
    public class DataProductos
    {
        public static List<Producto> GetAllProductos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT IdProducto, Nombre, Descripcion, Precio, vidaUtilDias, Activo FROM Productos WHERE Activo != 0";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto prod = new Producto
                            {
                                IdProducto = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                // reader.IsDBNull(2) ? "" : <- en la DB la descripción ya no puede ser null 
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                VidaUtilDias = reader.GetInt32(4),
                                Activo = reader.IsDBNull(5) ? 1 : (reader.GetBoolean(5) ? 1 : 0)
                                /*FechaCaducidad = DateTime.ParseExact(
                                    reader.GetString(5),
                                    new[] { "yyyy-MM-dd", "dd-MM-yyyy" },
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None)*/
                            };
                            lista.Add(prod);
                        }
                    }
                }
            }
            return lista;
        }
        public static List<Producto> GetAllDeletedProductos() //<- para mostrar los registros con activo -> 0
        {
            List<Producto> listaDeleted = new List<Producto>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT IdProducto, Nombre, Descripcion, Precio, vidaUtilDias, Activo FROM Productos WHERE Activo = 0";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto prod = new Producto
                            {
                                IdProducto = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                VidaUtilDias = reader.GetInt32(4),
                                /*FechaCaducidad = DateTime.ParseExact(
                                    reader.GetString(5),
                                    new[] { "yyyy-MM-dd", "dd-MM-yyyy" },
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None)*/
                                Activo = reader.IsDBNull(5) ? 1 : (reader.GetBoolean(5) ? 1 : 0)
                            };
                            listaDeleted.Add(prod);
                        }
                    }
                }
            }
            return listaDeleted;
        }

        public static void Create(Producto producto)
        {
            string sqlQuery = @"INSERT INTO Productos (Nombre, Descripcion, Precio, vidaUtilDias) VALUES 
            (@Nombre, @Descripcion, @Precio, @VidaUtil)";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    // Si producto.Descripcion es null, mandamos un DBNull a SQLite
                    //string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : <- esto manda un null a sqlite
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@VidaUtil", producto.VidaUtilDias);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Producto producto)
        {
            // Nombres de parámetros exactos
            string sqlQuery = @"UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, vidaUtilDias = @VidaUtil WHERE IdProducto = @IdProducto";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre); // Corregido a mayúscula
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio); // Corregido a mayúscula
                    cmd.Parameters.AddWithValue("@VidaUtil", producto.VidaUtilDias);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(Producto producto)
        {
            string sqlQuery = @"UPDATE Productos SET Activo = 0 WHERE IdProducto = @IdProducto"; //baja lógica. no deleteamos directamente de la base de datos
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void ShowDeletedProducts(Producto producto)
        {
            string sqlQuery = @"UPDATE Productos SET Activo = 1 WHERE IdProducto = @IdProducto"; 
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataProductos
    {
        public static List<Producto> GetAllProductos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT IdProducto, Nombre, Descripcion, Precio, Activo FROM Productos WHERE Activo != 0";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto prod = new Producto
                            {
                                IdProducto = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                // reader.IsDBNull(2) ? "" : <- en la DB la descripción ya no puede ser null 
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDouble(3),
                                Activo = reader.GetInt32(4)
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT IdProducto, Nombre, Descripcion, Precio, Activo FROM Productos WHERE Activo = 0";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto prod = new Producto
                            {
                                IdProducto = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDouble(3),
                                Activo = reader.GetInt32(4)
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
            string sqlQuery = @"INSERT INTO Productos (Nombre, Descripcion, Precio) VALUES 
            (@Nombre, @Descripcion, @Precio)";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    // Si producto.Descripcion es null, mandamos un DBNull a SQLite
                    //string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : <- esto manda un null a sqlite
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Producto producto)
        {
            // Nombres de parámetros exactos
            string sqlQuery = @"UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio WHERE IdProducto = @IdProducto";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre); // Corregido a mayúscula
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio); // Corregido a mayúscula
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(Producto producto)
        {
            string sqlQuery = @"UPDATE Productos SET Activo = 0 WHERE IdProducto = @IdProducto"; //baja lógica. no deleteamos directamente de la base de datos
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
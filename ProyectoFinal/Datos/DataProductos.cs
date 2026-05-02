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
                string sqlQuery = @"SELECT IdProducto, Nombre, Descripcion, Precio FROM Productos";
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
                                // Verificamos si la descripción es nula en la BD para evitar un "Crash"
                                Descripcion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Precio = reader.GetDouble(3)
                            };
                            lista.Add(prod);
                        }
                    }
                }
            }
            return lista;
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
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
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
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion); // Corregido a mayúscula
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio); // Corregido a mayúscula
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(Producto producto)
        {
            string sqlQuery = @"DELETE FROM Productos WHERE IdProducto = @IdProducto";
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
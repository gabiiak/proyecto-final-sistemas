using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataTandaProduccion
    {
        public static int CreateTanda(TandaProduccion tanda)
        {
            string sqlQuery = @"INSERT INTO TandaProduccion(idProducto, fecha, hora, estado)
                                VALUES (@IdProducto, @Fecha, @Hora, @Estado);
                                SELECT last_insert_rowid();";

            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProducto", tanda.Producto.IdProducto);
                    cmd.Parameters.AddWithValue("@Fecha", tanda.Fecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Hora", tanda.Hora.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Estado", tanda.EstadoTanda);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<TandaProduccion> GetAllTandas()
        {
            List<TandaProduccion> lista = new List<TandaProduccion>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT t.idTanda, t.fecha, t.hora, t.estado,
                                           p.idProducto, p.nombre, p.descripcion, p.precio, p.activo, p.fechaCaducidad
                                    FROM TandaProduccion t
                                    INNER JOIN Productos p ON t.idProducto = p.idProducto
                                    ORDER BY t.idTanda ASC";

                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TandaProduccion tanda = new TandaProduccion
                            {
                                IdTanda = reader.GetInt32(0),
                                Fecha = DateTime.Parse(reader.GetString(1)),
                                Hora = DateTime.Parse(reader.GetString(2)),
                                EstadoTanda = reader.GetInt32(3),
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(4),
                                    Nombre = reader.GetString(5),
                                    Descripcion = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                    Precio = reader.GetDouble(7),
                                    Activo = reader.GetInt32(8),
                                    FechaCaducidad = reader.IsDBNull(9) ? DateTime.MinValue : DateTime.Parse(reader.GetString(9))
                                }
                            };
                            lista.Add(tanda);
                        }
                    }
                }
            }
            return lista;
        }

        public static TandaProduccion GetTandaById(int idTanda)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT t.idTanda, t.fecha, t.hora, t.estado,
                                           p.idProducto, p.nombre, p.descripcion, p.precio, p.activo, p.fechaCaducidad
                                    FROM TandaProduccion t
                                    INNER JOIN Productos p ON t.idProducto = p.idProducto
                                    WHERE t.idTanda = @IdTanda";

                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTanda", idTanda);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TandaProduccion
                            {
                                IdTanda = reader.GetInt32(0),
                                Fecha = DateTime.Parse(reader.GetString(1)),
                                Hora = DateTime.Parse(reader.GetString(2)),
                                EstadoTanda = reader.GetInt32(3),
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(4),
                                    Nombre = reader.GetString(5),
                                    Descripcion = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                    Precio = reader.GetDouble(7),
                                    Activo = reader.GetInt32(8),
                                    FechaCaducidad = reader.IsDBNull(9) ? DateTime.MinValue : DateTime.Parse(reader.GetString(9))
                                }
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void CambiarEstado(int idTanda, int estadoTanda)
        {
            string sqlQuery = @"UPDATE TandaProduccion SET estado = @Estado WHERE idTanda = @IdTanda";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTanda", idTanda);
                    cmd.Parameters.AddWithValue("@Estado", estadoTanda);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int? GetEstadoActual(int idTanda)
        {
            string sqlQuery = @"SELECT estado FROM TandaProduccion WHERE idTanda = @IdTanda";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTanda", idTanda);
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : (int?)null;
                }
            }
        }

        public static void EliminarTanda(int idTanda)
        {
            string sqlQuery = @"DELETE FROM TandaProduccion WHERE idTanda = @IdTanda";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTanda", idTanda);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetIdProductoByTanda(int idTanda)
        {
            string sqlQuery = @"SELECT idProducto FROM TandaProduccion WHERE idTanda = @IdTanda";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTanda", idTanda);
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
            }
        }
    }
}
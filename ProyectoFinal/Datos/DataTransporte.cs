using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataTransporte
    {
        public static int CreateTransporte(Transporte transporte) // devuelve el id nuevo
        {
            string sqlQuery = @"INSERT INTO Transportes(idVenta, fecha, estado)
                                VALUES (@IdVenta, @Fecha, @Estado);
                                SELECT last_insert_rowid();";

            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", transporte.Venta.IdVenta);
                    cmd.Parameters.AddWithValue("@Fecha", transporte.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Estado", transporte.Estado);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<Transporte> GetAllTransportes()
        {
            List<Transporte> lista = new List<Transporte>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT t.idTransporte, t.fecha, t.estado,
                                   v.idVenta, v.totalVenta,
                                   c.id, c.nombre
                            FROM Transportes t
                            INNER JOIN Ventas v ON t.idVenta = v.idVenta
                            INNER JOIN Clientes c ON v.idCliente = c.id
                            ORDER BY t.idTransporte ASC";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transporte transporte = new Transporte
                            {
                                IdTransporte = reader.GetInt32(0),
                                Fecha = DateTime.Parse(reader.GetString(1)),
                                Estado = reader.GetInt32(2),
                                Venta = new Venta
                                {
                                    IdVenta = reader.GetInt32(3),
                                    Total = reader.GetDouble(4),
                                    Cliente = new Cliente
                                    {
                                        Id = reader.GetInt32(5),
                                        Nombre = reader.GetString(6)
                                    }
                                }
                            };
                            lista.Add(transporte);
                        }
                    }
                }
            }
            return lista;
        }

        public static int? GetEstadoActual(int idTransporte)
        {
            string sqlQuery = @"SELECT estado FROM Transportes WHERE idTransporte = @IdTransporte";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTransporte", idTransporte);
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : (int?)null;
                }
            }
        }

        public static void EliminarTransporte(int idTransporte)
        {
            string sqlQuery = @"DELETE FROM Transportes WHERE idTransporte = @IdTransporte";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTransporte", idTransporte);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CambiarEstado(int idTransporte, int estado)
        {
            string sqlQuery = @"UPDATE Transportes SET estado = @Estado WHERE idTransporte = @IdTransporte";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTransporte", idTransporte);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
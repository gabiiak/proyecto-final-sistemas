using System.Data;
using System.Data.SqlClient;
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
                                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = transporte.Venta.IdVenta;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = transporte.Fecha;
                    cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = transporte.Estado;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<Transporte> GetAllTransportes()
        {
            List<Transporte> lista = new List<Transporte>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT t.idTransporte, t.fecha, t.estado,
                                   v.idVenta, v.totalVenta,
                                   c.id, c.nombre
                            FROM Transportes t
                            INNER JOIN Ventas v ON t.idVenta = v.idVenta
                            INNER JOIN Clientes c ON v.idCliente = c.id
                            ORDER BY t.idTransporte ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transporte transporte = new Transporte
                            {
                                IdTransporte = reader.GetInt32(0),
                                Fecha = reader.GetDateTime(1),
                                Estado = (int)reader.GetByte(2),
                                Venta = new Venta
                                {
                                    IdVenta = reader.GetInt32(3),
                                    Total = (double)reader.GetDecimal(4),
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTransporte", idTransporte);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
        public static int GetIdVentaByTransporte(int idTransporte)
        {
            string sqlQuery = @"SELECT idVenta FROM Transportes WHERE idTransporte = @IdTransporte";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTransporte", idTransporte);
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
            }
        }
    }
}
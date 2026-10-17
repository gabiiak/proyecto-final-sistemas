using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class DataDetalleCompras
    {
        // Gráfico de torta: insumos más comprados
        public static List<(string Nombre, int Cantidad)> GetInsumosMasComprados(int top = 4)
        {
            var resultado = new List<(string, int)>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT TOP (@Top) i.nombre, SUM(dc.cantidad) as totalCantidad
                                    FROM DetalleCompras dc
                                    INNER JOIN Insumos i ON dc.idInsumo = i.id
                                    INNER JOIN Compras c ON dc.idCompra = c.idCompra
                                    WHERE c.estado != @Cancelada
                                    GROUP BY i.id, i.nombre
                                    ORDER BY totalCantidad DESC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Cancelada", SqlDbType.Int).Value = EstadoCompra.Cancelada;
                    cmd.Parameters.Add("@Top", SqlDbType.Int).Value = top;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add((reader.GetString(0), reader.GetInt32(1)));
                        }
                    }
                }
            }
            return resultado;
        }

        public static List<DetalleCompra> GetDetallesByIdCompra(int idCompra)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idDetalleCompra, idCompra, idInsumo, cantidad, subTotal
                                    FROM DetalleCompras
                                    WHERE idCompra = @IdCompra";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(MapDetalle(reader));
                    }
                }
            }
            return lista;
        }

        public static List<DetalleCompra> GetAllDetalleCompras()
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idDetalleCompra, idCompra, idInsumo, cantidad, subTotal
                                    FROM DetalleCompras";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(MapDetalle(reader));
                    }
                }
            }
            return lista;
        }

        public static int CreateDetalleCompra(DetalleCompra detalle) // devuelve el id del detalle
        {
            string sqlQuery = @"INSERT INTO DetalleCompras(idCompra, idInsumo, cantidad, subTotal)
                                VALUES (@IdCompra, @IdInsumo, @Cantidad, @SubTotal);
                                SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = detalle.IdCompra;
                    cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = detalle.IdInsumo;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                    cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = (decimal)detalle.Subtotal;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static DetalleCompra GetById(int id)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idDetalleCompra, idCompra, idInsumo, cantidad, subTotal
                                    FROM DetalleCompras WHERE idDetalleCompra = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapDetalle(reader);
                        return null;
                    }
                }
            }
        }

        public static int UpdateCantidad(int id, int cantidad, decimal nuevoSubTotal, string motivo)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE DetalleCompras
                                    SET cantidad = @cantidad, subTotal = @subTotal, motivoModificacion = @motivo
                                    WHERE idDetalleCompra = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                    cmd.Parameters.Add("@subTotal", SqlDbType.Decimal).Value = nuevoSubTotal;
                    cmd.Parameters.Add("@motivo", SqlDbType.NVarChar).Value = (object)motivo ?? DBNull.Value;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static decimal GetTotalCompraById(int idCompra)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT SUM(subTotal) FROM DetalleCompras WHERE idCompra = @idCompra";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = idCompra;
                    connection.Open();
                    object resultado = cmd.ExecuteScalar();
                    return resultado == DBNull.Value || resultado == null ? 0 : Convert.ToDecimal(resultado);
                }
            }
        }

        private static DetalleCompra MapDetalle(SqlDataReader reader)
        {
            return new DetalleCompra
            {
                IdDetalleCompra = reader.GetInt32(0),
                IdCompra = reader.GetInt32(1),
                IdInsumo = reader.GetInt32(2),
                Cantidad = reader.GetInt32(3),
                Subtotal = (double)reader.GetDecimal(4)
            };
        }
    }
}
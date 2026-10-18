using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class DataCompras
    {
        // Gráfico de línea, año completo
        public static Dictionary<int, double> GetComprasPorMesAnio(int anio)
        {
            var resultado = new Dictionary<int, double>();
            for (int m = 1; m <= 12; m++)
                resultado[m] = 0;

            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT MONTH(fecha) as mes, SUM(totalCompra) as total
                                    FROM Compras
                                    WHERE YEAR(fecha) = @Anio
                                      AND estado != @Cancelada
                                    GROUP BY MONTH(fecha)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
                    cmd.Parameters.Add("@Cancelada", SqlDbType.Int).Value = EstadoCompra.Cancelada;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = reader.GetInt32(0);
                            double total = (double)reader.GetDecimal(1);
                            resultado[mes] = total;
                        }
                    }
                }
            }
            return resultado;
        }

        // Gráfico de línea, por semestre
        public static Dictionary<int, double> GetComprasPorMesSemestre(int anio, int semestre)
        {
            int mesInicio = semestre == 1 ? 1 : 7;
            int mesFin = semestre == 1 ? 6 : 12;

            var resultado = new Dictionary<int, double>();
            for (int m = mesInicio; m <= mesFin; m++)
                resultado[m] = 0;

            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT MONTH(fecha) as mes, SUM(totalCompra) as total
                                    FROM Compras
                                    WHERE YEAR(fecha) = @Anio
                                      AND MONTH(fecha) BETWEEN @MesInicio AND @MesFin
                                      AND estado != @Cancelada
                                    GROUP BY MONTH(fecha)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
                    cmd.Parameters.Add("@MesInicio", SqlDbType.Int).Value = mesInicio;
                    cmd.Parameters.Add("@MesFin", SqlDbType.Int).Value = mesFin;
                    cmd.Parameters.Add("@Cancelada", SqlDbType.Int).Value = EstadoCompra.Cancelada;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = reader.GetInt32(0);
                            double total = (double)reader.GetDecimal(1);
                            resultado[mes] = total;
                        }
                    }
                }
            }
            return resultado;
        }

        // Gráfico de barras: proveedores a los que más se les compró
        public static List<(string Nombre, double Total)> GetTopProveedoresPorMonto(int top = 5)
        {
            var resultado = new List<(string, double)>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT TOP (@Top) p.nombre, SUM(c.totalCompra) as totalComprado
                                    FROM Compras c
                                    INNER JOIN Proveedores p ON c.idProveedor = p.idProveedor
                                    WHERE c.estado != @Cancelada
                                    GROUP BY p.idProveedor, p.nombre
                                    ORDER BY totalComprado DESC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Cancelada", SqlDbType.Int).Value = EstadoCompra.Cancelada;
                    cmd.Parameters.Add("@Top", SqlDbType.Int).Value = top;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add((reader.GetString(0), (double)reader.GetDecimal(1)));
                        }
                    }
                }
            }
            return resultado;
        }

        public static int UpdateTotal(int idCompra, decimal total)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Compras SET totalCompra = @total WHERE idCompra = @idCompra";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = total;
                    cmd.Parameters.Add("@idCompra", SqlDbType.Int).Value = idCompra;
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static Compra GetCompraById(int idCompra)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idCompra, idProveedor, idPresupuesto, fecha, fechaRecepcion, estado, estadoPago, totalCompra, montoPagado
                                    FROM Compras
                                    WHERE idCompra = @IdCompra";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapCompra(reader);
                        return null;
                    }
                }
            }
        }

        // Devuelve solo total y monto pagado
        public static Compra GetMontoPagado(int idCompra)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT totalCompra, montoPagado FROM Compras WHERE idCompra = @IdCompra";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Compra
                            {
                                TotalCompra = (double)reader.GetDecimal(0),
                                montoPagado = (double)reader.GetDecimal(1)
                            };
                        }
                    }
                    return null;
                }
            }
        }

        public static void CambiarMontoPagado(int idCompra, decimal monto)
        {
            string sqlQuery = @"UPDATE Compras SET montoPagado = @MontoPagado WHERE idCompra = @IdCompra";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                    cmd.Parameters.Add("@MontoPagado", SqlDbType.Decimal).Value = monto;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Compra> GetAllCompras()
        {
            List<Compra> lista = new List<Compra>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idCompra, idProveedor, idPresupuesto, fecha, fechaRecepcion, estado, estadoPago, totalCompra, montoPagado
                                    FROM Compras";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(MapCompra(reader));
                    }
                }
            }
            return lista;
        }

        public static int CrearCompraConDetalle(Compra compra, List<DetalleCompra> detalles) // devuelve el id de la compra
        {
            string sqlCabecera = @"INSERT INTO Compras(idProveedor, idPresupuesto, fecha, fechaRecepcion, estado, estadoPago, totalCompra, montoPagado)
                                   VALUES (@IdProveedor, @IdPresupuesto, @Fecha, @FechaRecepcion, @Estado, @EstadoPago, @Total, @MontoPagado);
                                   SELECT SCOPE_IDENTITY();";
            string sqlDetalle = @"INSERT INTO DetalleCompras(idCompra, idInsumo, cantidad, subTotal)
                                  VALUES (@IdCompra, @IdInsumo, @Cantidad, @SubTotal);";

            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    int idCompra;
                    using (SqlCommand cmd = new SqlCommand(sqlCabecera, connection, transaction))
                    {
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = compra.IdProveedor;
                        cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = (object)compra.IdPresupuesto ?? DBNull.Value;
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = compra.Fecha;
                        cmd.Parameters.Add("@FechaRecepcion", SqlDbType.Date).Value = (object)compra.FechaRecepcion ?? DBNull.Value;
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = compra.Estado;
                        cmd.Parameters.Add("@EstadoPago", SqlDbType.Int).Value = compra.EstadoPago;
                        cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = (decimal)compra.TotalCompra;
                        cmd.Parameters.Add("@MontoPagado", SqlDbType.Decimal).Value = (decimal)compra.montoPagado;
                        idCompra = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    foreach (DetalleCompra detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlDetalle, connection, transaction))
                        {
                            cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                            cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = detalle.IdInsumo;
                            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = detalle.Cantidad;
                            cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = (decimal)detalle.Subtotal;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return idCompra;
                }
            }
        }

        public static void ModificarCompraConDetalle(Compra compra, List<DetalleCompra> detalles)
        {
            string sqlCabecera = @"UPDATE Compras SET fecha = @Fecha, totalCompra = @Total WHERE idCompra = @IdCompra;";
            string sqlEliminarDetalle = @"DELETE FROM DetalleCompras WHERE idCompra = @IdCompra;";
            string sqlDetalle = @"INSERT INTO DetalleCompras(idCompra, idInsumo, cantidad, subTotal)
                                  VALUES (@IdCompra, @IdInsumo, @Cantidad, @SubTotal);";

            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(sqlCabecera, connection, transaction))
                    {
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = compra.Fecha;
                        cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = (decimal)compra.TotalCompra;
                        cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = compra.IdCompra;
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlEliminarDetalle, connection, transaction))
                    {
                        cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = compra.IdCompra;
                        cmd.ExecuteNonQuery();
                    }

                    foreach (DetalleCompra detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlDetalle, connection, transaction))
                        {
                            cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = compra.IdCompra;
                            cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = detalle.IdInsumo;
                            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = detalle.Cantidad;
                            cmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = (decimal)detalle.Subtotal;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        public static void CambiarEstadoPago(int idCompra, int estadoPago)
        {
            string sqlQuery = @"UPDATE Compras SET estadoPago = @EstadoPago WHERE idCompra = @IdCompra";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                    cmd.Parameters.Add("@EstadoPago", SqlDbType.Int).Value = estadoPago;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarFechas(int idCompra, DateTime fecha, DateTime? fechaRecepcion)
        {
            string sqlQuery = @"UPDATE Compras SET fecha = @Fecha, fechaRecepcion = @FechaRecepcion WHERE idCompra = @IdCompra";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha;
                    cmd.Parameters.Add("@FechaRecepcion", SqlDbType.Date).Value = (object)fechaRecepcion ?? DBNull.Value;
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CambiarEstado(int idCompra, int estado)
        {
            string sqlQuery = @"UPDATE Compras SET estado = @Estado WHERE idCompra = @IdCompra";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                    cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = estado;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Equivalente a "pedido listo con descuento de stock", pero al revés:
        // al recibirse la compra, el stock de insumos AUMENTA.
        public static void MarcarCompraRecibidaConIncrementoStock(int idCompra, List<DetalleCompra> detalles)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    string updateEstado = @"UPDATE Compras SET estado = @Estado, fechaRecepcion = @FechaRecepcion
                                            WHERE idCompra = @IdCompra;";
                    using (SqlCommand cmd = new SqlCommand(updateEstado, connection, transaction))
                    {
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = EstadoCompra.Recibida;
                        cmd.Parameters.Add("@FechaRecepcion", SqlDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.Add("@IdCompra", SqlDbType.Int).Value = idCompra;
                        cmd.ExecuteNonQuery();
                    }

                    string updateStock = @"UPDATE StockInsumo SET cantidad = cantidad + @cantidadComprada
                                           WHERE insumo_id = @insumoId;";
                    foreach (DetalleCompra detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(updateStock, connection, transaction))
                        {
                            cmd.Parameters.Add("@cantidadComprada", SqlDbType.Decimal).Value = detalle.Cantidad;
                            cmd.Parameters.Add("@insumoId", SqlDbType.Int).Value = detalle.IdInsumo;
                            int filas = cmd.ExecuteNonQuery();

                            if (filas == 0)
                                throw new InvalidOperationException($"No existe stock cargado para el insumo con id {detalle.IdInsumo}.");
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private static Compra MapCompra(SqlDataReader reader)
        {
            return new Compra
            {
                IdCompra = reader.GetInt32(0),
                IdProveedor = reader.GetInt32(1),
                IdPresupuesto = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                Fecha = reader.GetDateTime(3),
                FechaRecepcion = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                Estado = (int)reader.GetByte(5),
                EstadoPago = (int)reader.GetByte(6),
                TotalCompra = (double)reader.GetDecimal(7),
                montoPagado = (double)reader.GetDecimal(8)
            };
        }
    }
}
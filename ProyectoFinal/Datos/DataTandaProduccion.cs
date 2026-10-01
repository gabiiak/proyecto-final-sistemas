using System.Data;
using System.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataTandaProduccion
    {
        public static int CreateTanda(TandaProduccion tanda)
        {
            string sqlQuery = @"INSERT INTO TandaProduccion(idProducto, fecha, estado, cantidadProducida)
                                VALUES (@IdProducto, @Fecha, @Estado, @Cantidad);
                                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = tanda.Producto.IdProducto;
                    // fecha y hora van unidas en un solo DATETIME2
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = tanda.Fecha.Date.Add(tanda.Hora.TimeOfDay);
                    cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = tanda.EstadoTanda;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = tanda.CantidadProducida;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<TandaProduccion> GetAllTandas()
        {
            List<TandaProduccion> lista = new List<TandaProduccion>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT t.idTanda, t.fecha, t.estado,t.cantidadProducida, t.fechaCaducidad,
                                           p.idProducto, p.nombre, p.descripcion, p.precio, p.activo, p.vidaUtilDias
                                    FROM TandaProduccion t
                                    INNER JOIN Productos p ON t.idProducto = p.idProducto
                                    ORDER BY t.idTanda ASC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TandaProduccion tanda = new TandaProduccion
                            {
                                IdTanda = reader.GetInt32(0),
                                Fecha = reader.GetDateTime(1),
                                Hora = reader.GetDateTime(1), // la hora se lee del mismo DATETIME2
                                EstadoTanda = (int)reader.GetByte(2),
                                CantidadProducida = reader.GetInt32(3),
                                FechaCaducidad = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Descripcion = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                    Precio = (double)reader.GetDecimal(8),
                                    Activo = reader.IsDBNull(9) ? 1 : (reader.GetBoolean(9) ? 1 : 0),
                                    VidaUtilDias = reader.IsDBNull(10) ? 0 : reader.GetInt32(10)
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
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT t.idTanda, t.fecha, t.estado,t.cantidadProducida, t.fechaCaducidad,
                                           p.idProducto, p.nombre, p.descripcion, p.precio, p.activo, p.vidaUtilDias
                                    FROM TandaProduccion t
                                    INNER JOIN Productos p ON t.idProducto = p.idProducto
                                    WHERE t.idTanda = @IdTanda";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTanda", idTanda);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TandaProduccion
                            {
                                IdTanda = reader.GetInt32(0),
                                Fecha = reader.GetDateTime(1),
                                Hora = reader.GetDateTime(1), // la hora se lee del mismo DATETIME2
                                EstadoTanda = (int)reader.GetByte(2),
                                CantidadProducida = reader.GetInt32(3),
                                FechaCaducidad = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Descripcion = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                    Precio = (double)reader.GetDecimal(8),
                                    Activo = reader.IsDBNull(9) ? 1 : (reader.GetBoolean(9) ? 1 : 0),
                                    VidaUtilDias = reader.IsDBNull(10) ? 0 : reader.GetInt32(10)
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTanda", idTanda);
                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? Convert.ToInt32(resultado) : 0;
                }
            }
        }
        public static int CrearTandaConDetalle(TandaProduccion tanda, List<DetalleTandaProduccion> detalles) //aquí aprendí transacciones SQL owo
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    // 1. Insertar cabecera de tanda
                    string insertTanda = @"INSERT INTO TandaProduccion(idProducto, fecha, cantidadProducida, estado)
                                    VALUES (@IdProducto, @Fecha, @CantidadProducida, @Estado);
                                    SELECT SCOPE_IDENTITY();";

                    int idTanda;
                    using (SqlCommand cmd = new SqlCommand(insertTanda, connection, transaction))
                    {
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = tanda.Producto.IdProducto;
                        // fecha y hora van unidas en un solo DATETIME2
                        cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = tanda.Fecha.Date.Add(tanda.Hora.TimeOfDay);
                        cmd.Parameters.Add("@CantidadProducida", SqlDbType.Int).Value = tanda.CantidadProducida;
                        //cmd.Parameters.AddWithValue("@FechaCaducidad", tanda.FechaCaducidad.ToString("yyyy-MM-dd"));
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = tanda.EstadoTanda;
                        idTanda = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Insertar cada fila de detalle, ya calculada desde la receta
                    string insertDetalle = @"INSERT INTO DetalleTanda(idTandaProd, idInsumo, idEmpleado, cantidadUtilizada)
                                      VALUES (@IdTandaProd, @IdInsumo, @IdEmpleado, @CantidadUtilizada);";

                    foreach (DetalleTandaProduccion detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertDetalle, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdTandaProd", idTanda);
                            cmd.Parameters.AddWithValue("@IdInsumo", detalle.Insumo.Id);
                            cmd.Parameters.AddWithValue("@IdEmpleado",
                                detalle.Empleado != null ? (object)detalle.Empleado.IdEmpleado : DBNull.Value);
                            cmd.Parameters.AddWithValue("@CantidadUtilizada", detalle.CantidadUtilizada);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return idTanda;
                }
            }
        }
        public static void FinalizarTandaConMovimientoStock(int idTanda, int idProducto, double cantidadProducida, List<DetalleTandaProduccion> detalles, DateTime fechaCaducidadCalculada)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    // 1. Cambiar estado de la tanda
                    string updateEstado = "UPDATE TandaProduccion SET estado = @Estado, fechaCaducidad = @FechaCaducidad WHERE idTanda = @IdTanda;";
                    using (SqlCommand cmd = new SqlCommand(updateEstado, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Estado", EstadoTanda.Terminada);
                        cmd.Parameters.Add("@FechaCaducidad", SqlDbType.Date).Value = fechaCaducidadCalculada;
                        cmd.Parameters.AddWithValue("@IdTanda", idTanda);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Descontar stock de cada insumo consumido
                    string updateStockInsumo = @"UPDATE StockInsumo SET cantidad = cantidad - @cantidadUsada
                                          WHERE insumo_id = @insumoId;";
                    foreach (DetalleTandaProduccion detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(updateStockInsumo, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@cantidadUsada", detalle.CantidadUtilizada);
                            cmd.Parameters.AddWithValue("@insumoId", detalle.Insumo.Id);
                            int filas = cmd.ExecuteNonQuery();

                            if (filas == 0)
                                throw new InvalidOperationException($"No existe stock cargado para el insumo '{detalle.Insumo.Nombre}'.");
                        }
                    }

                    // 3. Sumar stock del producto terminado
                    string updateStockProducto = @"UPDATE StockProducto SET cantidad = cantidad + @cantidadProducida
                                            WHERE producto_id = @productoId;";
                    using (SqlCommand cmd = new SqlCommand(updateStockProducto, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@cantidadProducida", cantidadProducida);
                        cmd.Parameters.AddWithValue("@productoId", idProducto);
                        int filas = cmd.ExecuteNonQuery();

                        if (filas == 0)
                            throw new InvalidOperationException($"No existe stock cargado para el producto.");
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
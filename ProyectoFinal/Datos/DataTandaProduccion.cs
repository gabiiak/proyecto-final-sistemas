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
            string sqlQuery = @"INSERT INTO TandaProduccion(idProducto, fecha, hora, estado, cantidadProducida)
                                VALUES (@IdProducto, @Fecha, @Hora, @Estado, @Cantidad);
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
                    cmd.Parameters.AddWithValue("@Cantidad", tanda.CantidadProducida);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<TandaProduccion> GetAllTandas()
        {
            List<TandaProduccion> lista = new List<TandaProduccion>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT t.idTanda, t.fecha, t.hora, t.estado,t.cantidadProducida, t.fechaCaducidad,
                                           p.idProducto, p.nombre, p.descripcion, p.precio, p.activo, p.vidaUtilDias
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
                                CantidadProducida = reader.GetInt32(4),
                                FechaCaducidad = reader.IsDBNull(5) ? DateTime.MinValue : DateTime.Parse(reader.GetString(5)),
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(6),
                                    Nombre = reader.GetString(7),
                                    Descripcion = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                    Precio = reader.GetDouble(9),
                                    Activo = reader.GetInt32(10),
                                    VidaUtilDias = reader.GetInt32(11)
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
                string sqlQuery = @"SELECT t.idTanda, t.fecha, t.hora, t.estado,t.cantidadProducida, t.fechaCaducidad,
                                           p.idProducto, p.nombre, p.descripcion, p.precio, p.activo, p.vidaUtilDias
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
                                CantidadProducida = reader.GetInt32(4),
                                FechaCaducidad = reader.IsDBNull(5) ? DateTime.MinValue : DateTime.Parse(reader.GetString(5)),
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(6),
                                    Nombre = reader.GetString(7),
                                    Descripcion = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                    Precio = reader.GetDouble(9),
                                    Activo = reader.GetInt32(10),
                                    VidaUtilDias = reader.GetInt32(11)
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
        public static int CrearTandaConDetalle(TandaProduccion tanda, List<DetalleTandaProduccion> detalles) //aquí aprendí transacciones SQL owo
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    // 1. Insertar cabecera de tanda
                    string insertTanda = @"INSERT INTO TandaProduccion(idProducto, fecha, hora, cantidadProducida, estado)
                                    VALUES (@IdProducto, @Fecha, @Hora, @CantidadProducida, @Estado);
                                    SELECT last_insert_rowid();";

                    int idTanda;
                    using (SqliteCommand cmd = new SqliteCommand(insertTanda, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", tanda.Producto.IdProducto);
                        cmd.Parameters.AddWithValue("@Fecha", tanda.Fecha.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Hora", tanda.Hora.ToString("HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@CantidadProducida", tanda.CantidadProducida);
                        //cmd.Parameters.AddWithValue("@FechaCaducidad", tanda.FechaCaducidad.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Estado", tanda.EstadoTanda);
                        idTanda = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Insertar cada fila de detalle, ya calculada desde la receta
                    string insertDetalle = @"INSERT INTO DetalleTanda(idTandaProd, idInsumo, idEmpleado, cantidadUtilizada)
                                      VALUES (@IdTandaProd, @IdInsumo, @IdEmpleado, @CantidadUtilizada);";

                    foreach (DetalleTandaProduccion detalle in detalles)
                    {
                        using (SqliteCommand cmd = new SqliteCommand(insertDetalle, connection, transaction))
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    // 1. Cambiar estado de la tanda
                    string updateEstado = "UPDATE TandaProduccion SET estado = @Estado, fechaCaducidad = @FechaCaducidad WHERE idTanda = @IdTanda;";
                    using (SqliteCommand cmd = new SqliteCommand(updateEstado, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Estado", EstadoTanda.Terminada);
                        cmd.Parameters.AddWithValue("@FechaCaducidad", fechaCaducidadCalculada.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@IdTanda", idTanda);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Descontar stock de cada insumo consumido
                    string updateStockInsumo = @"UPDATE StockInsumo SET cantidad = cantidad - @cantidadUsada
                                          WHERE insumo_id = @insumoId;";
                    foreach (DetalleTandaProduccion detalle in detalles)
                    {
                        using (SqliteCommand cmd = new SqliteCommand(updateStockInsumo, connection, transaction))
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
                    using (SqliteCommand cmd = new SqliteCommand(updateStockProducto, connection, transaction))
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
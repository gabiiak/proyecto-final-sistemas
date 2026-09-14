using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataDetalleTandaProduccion
    {
        public static int CreateDetalleTanda(DetalleTandaProduccion detalle)
        {
            string sqlQuery = @"INSERT INTO DetalleTanda(idTandaProd, idInsumo, idEmpleado, cantidadUtilizada)
                                VALUES (@IdTandaProd, @IdInsumo, @IdEmpleado, @CantidadUtilizada);
                                SELECT last_insert_rowid();";

            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTandaProd", detalle.TandaProduccion.IdTanda);
                    cmd.Parameters.AddWithValue("@IdInsumo", detalle.Insumo.Id);
                    cmd.Parameters.AddWithValue("@IdEmpleado", detalle.Empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("@CantidadUtilizada", detalle.CantidadProducida);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<DetalleTandaProduccion> GetDetallesByTanda(int idTanda)
        {
            List<DetalleTandaProduccion> lista = new List<DetalleTandaProduccion>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT dt.idDetalleTanda, dt.cantidadUtilizada,
                                           t.idTanda, t.fecha, t.hora, t.estado,
                                           i.id, i.nombre, i.descripcion, i.precio, i.activo,
                                           e.idEmpleado, e.nombre, e.apellido, e.telefono, e.cargo, e.activo, e.numCuenta, e.fechaIngreso, e.sueldo
                                    FROM DetalleTanda dt
                                    INNER JOIN TandaProduccion t ON dt.idTandaProd = t.idTanda
                                    INNER JOIN Insumos i ON dt.idInsumo = i.id
                                    INNER JOIN Empleados e ON dt.idEmpleado = e.idEmpleado
                                    WHERE dt.idTandaProd = @IdTandaProd
                                    ORDER BY dt.idDetalleTanda ASC";

                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTandaProd", idTanda);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetalleTandaProduccion detalle = new DetalleTandaProduccion
                            {
                                IdDetalleTanda = reader.GetInt32(0),
                                CantidadProducida = reader.GetInt32(1),
                                TandaProduccion = new TandaProduccion
                                {
                                    IdTanda = reader.GetInt32(2),
                                    Fecha = DateTime.Parse(reader.GetString(3)),
                                    Hora = DateTime.Parse(reader.GetString(4)),
                                    EstadoTanda = reader.GetInt32(5)
                                },
                                Insumo = new Insumo
                                {
                                    Id = reader.GetInt32(6),
                                    Nombre = reader.GetString(7),
                                    Descripcion = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                    Precio = reader.GetDouble(9),
                                    Activo = reader.GetInt32(10)
                                },
                                Empleado = new Empleado
                                {
                                    IdEmpleado = reader.GetInt32(11),
                                    Nombre = reader.GetString(12),
                                    Apellido = reader.GetString(13),
                                    Telefono = reader.IsDBNull(14) ? string.Empty : reader.GetString(14),
                                    Cargo = reader.GetString(15),
                                    Activo = reader.GetInt32(16),
                                    NumCuenta = reader.GetInt32(17),
                                    FechaIngreso = DateTime.Parse(reader.GetString(18)),
                                    Sueldo = reader.GetDouble(19)
                                }
                            };
                            lista.Add(detalle);
                        }
                    }
                }
            }
            return lista;
        }

        public static void EliminarDetalle(int idDetalleTanda)
        {
            string sqlQuery = @"DELETE FROM DetalleTanda WHERE idDetalleTanda = @IdDetalleTanda";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdDetalleTanda", idDetalleTanda);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarDetallesPorTanda(int idTanda)
        {
            string sqlQuery = @"DELETE FROM DetalleTanda WHERE idTandaProd = @IdTandaProd";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTandaProd", idTanda);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
using System.Data.SqlClient;
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
                                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTandaProd", detalle.TandaProduccion.IdTanda);
                    cmd.Parameters.AddWithValue("@IdInsumo", detalle.Insumo.Id);
                    cmd.Parameters.AddWithValue("@IdEmpleado", detalle.Empleado != null ? (object)detalle.Empleado.IdEmpleado : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CantidadUtilizada", detalle.CantidadUtilizada);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<DetalleTandaProduccion> GetDetallesByTanda(int idTanda)
        {
            List<DetalleTandaProduccion> lista = new List<DetalleTandaProduccion>();
            using (SqlConnection connection = Db.GetConnection())
            {
                /*LEFT JOIN Empleados e ON dt.idEmpleado = e.idEmpleado
                 * Empleado = new Empleado
                                {
                                    IdEmpleado = reader.GetInt32(11),
                                    Nombre = reader.GetString(12),
                                    Apellido = reader.GetString(13),
                                    Telefono = reader.IsDBNull(14) ? string.Empty : reader.GetString(14),
                                    Cargo = reader.GetString(15),
                                    Activo = reader.IsDBNull(16) ? 1 : (reader.GetBoolean(16) ? 1 : 0),
                                    NumCuenta = reader.GetInt32(17),
                                    FechaIngreso = reader.GetDateTime(18),
                                    Sueldo = (double)reader.GetDecimal(19)
                                }
                                e.idEmpleado, e.nombre, e.apellido, e.telefono, e.cargo, e.activo, e.numCuenta, e.fechaIngreso, e.sueldo
                */
                string sqlQuery = @"SELECT dt.idDetalleTanda, dt.cantidadUtilizada,
                                           t.idTanda, t.fecha, t.estado,
                                           i.id, i.nombre, i.descripcion, i.precio, i.activo, i.unidadMedida       
                                    FROM DetalleTanda dt
                                    INNER JOIN TandaProduccion t ON dt.idTandaProd = t.idTanda
                                    INNER JOIN Insumos i ON dt.idInsumo = i.id
                                    WHERE dt.idTandaProd = @IdTandaProd
                                    ORDER BY dt.idDetalleTanda ASC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTandaProd", idTanda);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetalleTandaProduccion detalle = new DetalleTandaProduccion
                            {
                                IdDetalleTanda = reader.GetInt32(0),
                                CantidadUtilizada = (double)reader.GetDecimal(1),
                                TandaProduccion = new TandaProduccion
                                {
                                    IdTanda = reader.GetInt32(2),
                                    Fecha = reader.GetDateTime(3),
                                    Hora = reader.GetDateTime(3), // la hora se lee del mismo DATETIME2
                                    EstadoTanda = (int)reader.GetByte(4)
                                },
                                Insumo = new Insumo
                                {
                                    Id = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Descripcion = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                    Precio = (double)reader.GetDecimal(8),
                                    Activo = reader.IsDBNull(9) ? 1 : (reader.GetBoolean(9) ? 1 : 0),
                                    UnidadMedida = reader.IsDBNull(10) ? string.Empty : reader.GetString(10)
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdTandaProd", idTanda);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
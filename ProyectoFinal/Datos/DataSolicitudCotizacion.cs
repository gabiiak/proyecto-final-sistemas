using System.Data;
using System.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataSolicitudCotizacion
    {
        public static int CrearSolicitudConDetalle(SolicitudCotizacion solicitud, List<DetalleSolicitudCotizacion> detalles)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    // 1. Insertar la cabecera de la solicitud
                    string insertSolicitud = @"INSERT INTO SolicitudCotizacion(idProveedor, fecha, estado)
                                               VALUES (@IdProveedor, @Fecha, @Estado);
                                               SELECT SCOPE_IDENTITY();";

                    int idSolicitud;
                    using (SqlCommand cmd = new SqlCommand(insertSolicitud, connection, transaction))
                    {
                        cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = solicitud.IdProveedor;
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = solicitud.Fecha.Date;
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = solicitud.Estado;
                        idSolicitud = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Insertar cada fila de detalle
                    string insertDetalle = @"INSERT INTO DetalleSolicitudCotizacion(idSolicitud, idInsumo, cantidad)
                                             VALUES (@IdSolicitud, @IdInsumo, @Cantidad);";

                    foreach (DetalleSolicitudCotizacion detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertDetalle, connection, transaction))
                        {
                            cmd.Parameters.Add("@IdSolicitud", SqlDbType.Int).Value = idSolicitud;
                            cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = detalle.IdInsumo;
                            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = detalle.Cantidad;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return idSolicitud;
                }
            }
        }

        public static List<SolicitudCotizacion> GetAll()
        {
            List<SolicitudCotizacion> lista = new List<SolicitudCotizacion>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idSolicitud, idProveedor, fecha, estado
                                    FROM SolicitudCotizacion
                                    ORDER BY fecha DESC, idSolicitud DESC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SolicitudCotizacion
                            {
                                IdSolicitud = reader.GetInt32(0),
                                IdProveedor = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2),
                                Estado = (int)reader.GetByte(3)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static SolicitudCotizacion GetById(int idSolicitud)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idSolicitud, idProveedor, fecha, estado
                                    FROM SolicitudCotizacion
                                    WHERE idSolicitud = @IdSolicitud";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdSolicitud", SqlDbType.Int).Value = idSolicitud;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new SolicitudCotizacion
                            {
                                IdSolicitud = reader.GetInt32(0),
                                IdProveedor = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2),
                                Estado = (int)reader.GetByte(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void ActualizarEstado(int idSolicitud, int estado)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE SolicitudCotizacion
                                    SET estado = @Estado
                                    WHERE idSolicitud = @IdSolicitud";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = estado;
                    cmd.Parameters.Add("@IdSolicitud", SqlDbType.Int).Value = idSolicitud;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<DetalleSolicitudCotizacion> GetDetallesBySolicitud(int idSolicitud)
        {
            List<DetalleSolicitudCotizacion> lista = new List<DetalleSolicitudCotizacion>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT d.idDetalleSolicitud, d.idSolicitud, d.idInsumo, d.cantidad,
                                           i.nombre, i.unidadMedida
                                    FROM DetalleSolicitudCotizacion d
                                    INNER JOIN Insumos i ON i.id = d.idInsumo
                                    WHERE d.idSolicitud = @IdSolicitud
                                    ORDER BY d.idDetalleSolicitud";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdSolicitud", SqlDbType.Int).Value = idSolicitud;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DetalleSolicitudCotizacion
                            {
                                IdDetalleSolicitud = reader.GetInt32(0),
                                IdSolicitud = reader.GetInt32(1),
                                IdInsumo = reader.GetInt32(2),
                                Cantidad = reader.GetDecimal(3),
                                NombreInsumo = reader.GetString(4),
                                UnidadMedidaInsumo = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}

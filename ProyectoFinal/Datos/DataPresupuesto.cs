using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class DataPresupuesto
    {
        public static int CrearPresupuestoConDetalle(Presupuesto presupuesto, List<DetallePresupuesto> detalles)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    // 1. Insertar la cabecera del presupuesto
                    string insertPresupuesto = @"INSERT INTO Presupuesto(idSolicitud, fecha, total, activo)
                                                 VALUES (@IdSolicitud, @Fecha, @Total, 1);
                                                 SELECT SCOPE_IDENTITY();";

                    int idPresupuesto;
                    using (SqlCommand cmd = new SqlCommand(insertPresupuesto, connection, transaction))
                    {
                        cmd.Parameters.Add("@IdSolicitud", SqlDbType.Int).Value = presupuesto.IdSolicitud;
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = presupuesto.Fecha.Date;
                        cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = presupuesto.Total;
                        idPresupuesto = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Insertar cada fila de detalle
                    string insertDetalle = @"INSERT INTO DetallePresupuesto(idPresupuesto, idInsumo, cantidad, precioUnitario, subtotal)
                                             VALUES (@IdPresupuesto, @IdInsumo, @Cantidad, @PrecioUnitario, @Subtotal);";

                    foreach (DetallePresupuesto detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertDetalle, connection, transaction))
                        {
                            cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                            cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = detalle.IdInsumo;
                            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = detalle.Cantidad;
                            cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = detalle.PrecioUnitario;
                            cmd.Parameters.Add("@Subtotal", SqlDbType.Decimal).Value = detalle.Subtotal;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return idPresupuesto;
                }
            }
        }

        public static void ModificarPresupuestoConDetalle(Presupuesto presupuesto, List<DetallePresupuesto> detalles)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    // 1. Actualizar la cabecera
                    string updatePresupuesto = @"UPDATE Presupuesto
                                                 SET fecha = @Fecha, total = @Total
                                                 WHERE idPresupuesto = @IdPresupuesto;";

                    using (SqlCommand cmd = new SqlCommand(updatePresupuesto, connection, transaction))
                    {
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = presupuesto.Fecha.Date;
                        cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = presupuesto.Total;
                        cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = presupuesto.IdPresupuesto;
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Borrar el detalle anterior
                    string deleteDetalle = @"DELETE FROM DetallePresupuesto WHERE idPresupuesto = @IdPresupuesto;";

                    using (SqlCommand cmd = new SqlCommand(deleteDetalle, connection, transaction))
                    {
                        cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = presupuesto.IdPresupuesto;
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Re-insertar el detalle
                    string insertDetalle = @"INSERT INTO DetallePresupuesto(idPresupuesto, idInsumo, cantidad, precioUnitario, subtotal)
                                             VALUES (@IdPresupuesto, @IdInsumo, @Cantidad, @PrecioUnitario, @Subtotal);";

                    foreach (DetallePresupuesto detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertDetalle, connection, transaction))
                        {
                            cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = presupuesto.IdPresupuesto;
                            cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = detalle.IdInsumo;
                            cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = detalle.Cantidad;
                            cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = detalle.PrecioUnitario;
                            cmd.Parameters.Add("@Subtotal", SqlDbType.Decimal).Value = detalle.Subtotal;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        public static List<Presupuesto> GetAll()
        {
            return GetByActivo(1);
        }

        public static List<Presupuesto> GetDeleted()
        {
            return GetByActivo(0);
        }

        private static List<Presupuesto> GetByActivo(int activo)
        {
            List<Presupuesto> lista = new List<Presupuesto>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT p.idPresupuesto, p.idSolicitud, p.fecha, p.total, p.activo,
                                           s.idProveedor, s.estado, pr.Nombre
                                    FROM Presupuesto p
                                    INNER JOIN SolicitudCotizacion s ON s.idSolicitud = p.idSolicitud
                                    INNER JOIN Proveedores pr ON pr.IdProveedor = s.idProveedor
                                    WHERE p.activo = @Activo
                                    ORDER BY p.fecha DESC, p.idPresupuesto DESC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = activo == 1;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearPresupuesto(reader));
                        }
                    }
                }
            }
            return lista;
        }

        public static Presupuesto GetById(int idPresupuesto)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT p.idPresupuesto, p.idSolicitud, p.fecha, p.total, p.activo,
                                           s.idProveedor, s.estado, pr.Nombre
                                    FROM Presupuesto p
                                    INNER JOIN SolicitudCotizacion s ON s.idSolicitud = p.idSolicitud
                                    INNER JOIN Proveedores pr ON pr.IdProveedor = s.idProveedor
                                    WHERE p.idPresupuesto = @IdPresupuesto";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapearPresupuesto(reader);
                        }
                    }
                }
            }
            return null;
        }

        private static Presupuesto MapearPresupuesto(SqlDataReader reader)
        {
            return new Presupuesto
            {
                IdPresupuesto = reader.GetInt32(0),
                IdSolicitud = reader.GetInt32(1),
                Fecha = reader.GetDateTime(2),
                Total = reader.GetDecimal(3),
                Activo = reader.GetBoolean(4) ? 1 : 0,
                IdProveedor = reader.GetInt32(5),
                EstadoSolicitud = (int)reader.GetByte(6),
                NombreProveedor = reader.GetString(7)
            };
        }

        public static List<DetallePresupuesto> GetDetallesByPresupuesto(int idPresupuesto)
        {
            List<DetallePresupuesto> lista = new List<DetallePresupuesto>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT d.idDetallePresupuesto, d.idPresupuesto, d.idInsumo, d.cantidad,
                                           d.precioUnitario, d.subtotal, i.nombre, i.unidadMedida
                                    FROM DetallePresupuesto d
                                    INNER JOIN Insumos i ON i.id = d.idInsumo
                                    WHERE d.idPresupuesto = @IdPresupuesto
                                    ORDER BY d.idDetallePresupuesto";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DetallePresupuesto
                            {
                                IdDetallePresupuesto = reader.GetInt32(0),
                                IdPresupuesto = reader.GetInt32(1),
                                IdInsumo = reader.GetInt32(2),
                                Cantidad = reader.GetDecimal(3),
                                PrecioUnitario = reader.GetDecimal(4),
                                Subtotal = reader.GetDecimal(5),
                                NombreInsumo = reader.GetString(6),
                                UnidadMedidaInsumo = reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static void Eliminar(int idPresupuesto)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Presupuesto SET activo = 0 WHERE idPresupuesto = @IdPresupuesto;";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Reactivar(int idPresupuesto)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Presupuesto SET activo = 1 WHERE idPresupuesto = @IdPresupuesto;";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdPresupuesto", SqlDbType.Int).Value = idPresupuesto;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool ExisteActivoPorSolicitud(int idSolicitud)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT COUNT(*) FROM Presupuesto WHERE idSolicitud = @IdSolicitud AND activo = 1;";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdSolicitud", SqlDbType.Int).Value = idSolicitud;
                    connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static List<SolicitudCotizacion> GetSolicitudesPendientes()
        {
            List<SolicitudCotizacion> lista = new List<SolicitudCotizacion>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT s.idSolicitud, s.idProveedor, s.fecha, s.estado
                                    FROM SolicitudCotizacion s
                                    WHERE s.estado IN (0, 1)
                                      AND NOT EXISTS (SELECT 1 FROM Presupuesto p
                                                      WHERE p.idSolicitud = s.idSolicitud AND p.activo = 1)
                                    ORDER BY s.fecha DESC, s.idSolicitud DESC";

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
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class DataPrecioProveedor
    {
        public static void Upsert(int idProveedor, int idInsumo, decimal precio, DateTime fechaActualizacion)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"IF EXISTS (SELECT 1 FROM PrecioProveedor WHERE idProveedor = @IdProveedor AND idInsumo = @IdInsumo)
                                        UPDATE PrecioProveedor
                                           SET precio = @Precio, fechaActualizacion = @Fecha
                                         WHERE idProveedor = @IdProveedor AND idInsumo = @IdInsumo;
                                    ELSE
                                        INSERT INTO PrecioProveedor (idProveedor, idInsumo, precio, fechaActualizacion)
                                        VALUES (@IdProveedor, @IdInsumo, @Precio, @Fecha);";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = idProveedor;
                    cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = idInsumo;
                    cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio;
                    cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fechaActualizacion.Date;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<PrecioProveedor> GetByProveedorId(int idProveedor)
        {
            List<PrecioProveedor> lista = new List<PrecioProveedor>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idPrecioProveedor, idProveedor, idInsumo, precio, fechaActualizacion
                                    FROM PrecioProveedor
                                    WHERE idProveedor = @IdProveedor
                                    ORDER BY idInsumo";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = idProveedor;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PrecioProveedor
                            {
                                IdPrecioProveedor = reader.GetInt32(0),
                                IdProveedor = reader.GetInt32(1),
                                IdInsumo = reader.GetInt32(2),
                                Precio = reader.GetDecimal(3),
                                FechaActualizacion = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}

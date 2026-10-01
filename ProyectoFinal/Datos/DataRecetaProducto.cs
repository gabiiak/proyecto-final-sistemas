using System.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataRecetaProducto
    {
        public static int Create(RecetaProducto receta)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                string sqlQuery = @"INSERT INTO RecetaProducto (idProducto, idInsumo, cantidadPorUnidad)
                                 VALUES (@idProducto, @idInsumo, @cantidadPorUnidad);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idProducto", receta.IdProducto);
                    cmd.Parameters.AddWithValue("@idInsumo", receta.IdInsumo);
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", receta.CantidadPorUnidad);

                    long nuevoId = (long)cmd.ExecuteScalar();
                    return Convert.ToInt32(nuevoId);
                }
            }
        }

        public static void Update(RecetaProducto receta)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                string sqlQuery = @"UPDATE RecetaProducto
                                 SET cantidadPorUnidad = @cantidadPorUnidad
                                 WHERE idReceta = @idReceta;";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", receta.CantidadPorUnidad);
                    cmd.Parameters.AddWithValue("@idReceta", receta.IdReceta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int idReceta)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                string consulta = "DELETE FROM RecetaProducto WHERE idReceta = @idReceta;";

                using (SqlCommand cmd = new SqlCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@idReceta", idReceta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<RecetaProducto> ObtenerPorProducto(int idProducto)
        {
            List<RecetaProducto> listado = new List<RecetaProducto>();

            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                string consulta = @"SELECT r.idReceta, r.idProducto, r.idInsumo, r.cantidadPorUnidad,
                                        i.nombre, i.descripcion, i.unidadMedida
                                 FROM RecetaProducto r
                                 INNER JOIN Insumos i ON r.idInsumo = i.id
                                 WHERE r.idProducto = @idProducto;";

                using (SqlCommand cmd = new SqlCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listado.Add(new RecetaProducto
                            {
                                IdReceta = reader.GetInt32(0),
                                IdProducto = reader.GetInt32(1),
                                IdInsumo = reader.GetInt32(2),
                                CantidadPorUnidad = reader.GetDecimal(3),
                                NombreInsumo = reader.GetString(4),
                                DescripcionInsumo = reader.GetString(5),
                                UnidadMedidaInsumo= reader.GetString(6)
                            });
                        }
                    }
                }
            }

            return listado;
        }

        public static bool ExisteInsumoEnReceta(int idProducto, int idInsumo)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                string consulta = @"SELECT COUNT(*) FROM RecetaProducto
                                 WHERE idProducto = @idProducto AND idInsumo = @idInsumo;";

                using (SqlCommand cmd = new SqlCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@idInsumo", idInsumo);

                    long cantidad = (long)cmd.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }
        public static void ReemplazarReceta(int idProducto, List<RecetaProducto> receta)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    string deleteQuery = "DELETE FROM RecetaProducto WHERE idProducto = @idProducto;";
                    using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("@idProducto", idProducto);
                        cmdDelete.ExecuteNonQuery();
                    }

                    string insertQuery = @"INSERT INTO RecetaProducto (idProducto, idInsumo, cantidadPorUnidad)
                                    VALUES (@idProducto, @idInsumo, @cantidadPorUnidad);";

                    foreach (RecetaProducto item in receta)
                    {
                        using (SqlCommand cmdInsert = new SqlCommand(insertQuery, connection, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@idProducto", idProducto);
                            cmdInsert.Parameters.AddWithValue("@idInsumo", item.IdInsumo);
                            cmdInsert.Parameters.AddWithValue("@cantidadPorUnidad", item.CantidadPorUnidad);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }
    }
}

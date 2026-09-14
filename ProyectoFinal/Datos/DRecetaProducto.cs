using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DRecetaProducto
    {
        public static int Create(RecetaProducto receta)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                string sqlQuery = @"INSERT INTO RecetaProducto (idProducto, idInsumo, cantidadPorUnidad)
                                 VALUES (@idProducto, @idInsumo, @cantidadPorUnidad);
                                 SELECT last_insert_rowid();";

                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                string sqlQuery = @"UPDATE RecetaProducto
                                 SET cantidadPorUnidad = @cantidadPorUnidad
                                 WHERE idReceta = @idReceta;";

                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", receta.CantidadPorUnidad);
                    cmd.Parameters.AddWithValue("@idReceta", receta.IdReceta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int idReceta)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                string consulta = "DELETE FROM RecetaProducto WHERE idReceta = @idReceta;";

                using (SqliteCommand cmd = new SqliteCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@idReceta", idReceta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<RecetaProducto> ObtenerPorProducto(int idProducto)
        {
            List<RecetaProducto> listado = new List<RecetaProducto>();

            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                string consulta = @"SELECT r.idReceta, r.idProducto, r.idInsumo, r.cantidadPorUnidad,
                                        i.nombre, i.descripcion
                                 FROM RecetaProducto r
                                 INNER JOIN Insumos i ON r.idInsumo = i.id
                                 WHERE r.idProducto = @idProducto;";

                using (SqliteCommand cmd = new SqliteCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listado.Add(new RecetaProducto
                            {
                                IdReceta = reader.GetInt32(0),
                                IdProducto = reader.GetInt32(1),
                                IdInsumo = reader.GetInt32(2),
                                CantidadPorUnidad = reader.GetDouble(3),
                                NombreInsumo = reader.GetString(4),
                                DescripcionInsumo = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return listado;
        }

        public static bool ExisteInsumoEnReceta(int idProducto, int idInsumo)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                string consulta = @"SELECT COUNT(*) FROM RecetaProducto
                                 WHERE idProducto = @idProducto AND idInsumo = @idInsumo;";

                using (SqliteCommand cmd = new SqliteCommand(consulta, connection))
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    string deleteQuery = "DELETE FROM RecetaProducto WHERE idProducto = @idProducto;";
                    using (SqliteCommand cmdDelete = new SqliteCommand(deleteQuery, connection, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("@idProducto", idProducto);
                        cmdDelete.ExecuteNonQuery();
                    }

                    string insertQuery = @"INSERT INTO RecetaProducto (idProducto, idInsumo, cantidadPorUnidad)
                                    VALUES (@idProducto, @idInsumo, @cantidadPorUnidad);";

                    foreach (RecetaProducto item in receta)
                    {
                        using (SqliteCommand cmdInsert = new SqliteCommand(insertQuery, connection, transaction))
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

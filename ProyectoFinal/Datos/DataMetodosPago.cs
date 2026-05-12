using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataMetodosPago
    {
        public static List<MetodoPago> GetAll()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT * FROM MetodosPago WHERE activo != 0";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MetodoPago mp = new MetodoPago
                            {
                                IdMetodoPago = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Activo = reader.GetInt32(2)
                            };
                            lista.Add(mp);
                        }
                    }
                }
            }
            return lista;
        }

        public static List<MetodoPago> GetAllDeletedMetodos()
        {
            List<MetodoPago> listaDeleted = new List<MetodoPago>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT * FROM MetodosPago WHERE activo = 0";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MetodoPago mp = new MetodoPago
                            {
                                IdMetodoPago = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Activo = reader.GetInt32(2)
                            };
                            listaDeleted.Add(mp);
                        }
                    }
                }
            }
            return listaDeleted;
        }

        public static void Create(MetodoPago metodoPago)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"INSERT INTO MetodosPago (Descripcion, Activo) VALUES (@Descripcion, @Activo)";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Descripcion", metodoPago.Descripcion);
                    cmd.Parameters.AddWithValue("@Activo", 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(MetodoPago metodoPago)
        {
            string sqlQuery = @"UPDATE MetodosPago SET Descripcion = @Descripcion, Activo = @Activo WHERE IdMetodoPago = @IdMetodoPago";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdMetodoPago", metodoPago.IdMetodoPago);
                    cmd.Parameters.AddWithValue("@Descripcion", metodoPago.Descripcion);
                    cmd.Parameters.AddWithValue("@Activo", metodoPago.Activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(MetodoPago metodoPago)
        {
            string sqlQuery = @"UPDATE MetodosPago SET Activo = 0 WHERE IdMetodoPago = @IdMetodoPago";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdMetodoPago", metodoPago.IdMetodoPago);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Renombrado para que coincida con la acción real y los acuerdos del Sprint 0
        public static void RestoreMetodoPago(MetodoPago metodoPago)
        {
            string sqlQuery = @"UPDATE MetodosPago SET Activo = 1 WHERE IdMetodoPago = @IdMetodoPago";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdMetodoPago", metodoPago.IdMetodoPago);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataInsumos
    {

        public static List<Insumo> GetAllInsumos()
        {
            List<Insumo> listaInsumos = new List<Insumo>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT i.id, i.nombre, i.descripcion, i.precio, i.activo
                                    FROM Insumos i
                                    WHERE i.activo = 1";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Insumo insumo = new Insumo
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDouble(3),
                                Activo = reader.GetInt32(4)

                            };
                            listaInsumos.Add(insumo);
                        }
                    }
                }
            }
            return listaInsumos;
        }
        public static int createInsumo(Insumo insumo)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"INSERT INTO Insumos (nombre, descripcion, precio, activo) 
                                    VALUES (@nombre, @descripcion, @precio, 1)";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", insumo.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", insumo.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", insumo.Precio);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static int updateInsumo(Insumo insumo)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Insumos 
                                    SET nombre = @nombre, descripcion = @descripcion, precio = @precio
                                    WHERE id = @id";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", insumo.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", insumo.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", insumo.Precio);
                    cmd.Parameters.AddWithValue("@id", insumo.Id);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static int cambiarEstadoInsumo(int id)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Insumos 
                                        SET activo = 0
                                        WHERE id = @id";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static Insumo GetInsumoById(int id)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT i.id, i.nombre, i.descripcion, i.precio, i.activo
                                    FROM Insumos i
                                    WHERE i.id = @id";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Insumo insumo = new Insumo
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDouble(3),
                                Activo = reader.GetInt32(4)
                            };
                            return insumo;
                        }
                        else
                        {
                            return null; // No se encontró el insumo con el ID proporcionado
                        }
                    }
                }
            }
        }
    }
}

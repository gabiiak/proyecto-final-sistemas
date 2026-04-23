using Modelos;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataClientes
    {
        public static List<Cliente> GetAll()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT * FROM Clientes";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cli = new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Empresa = reader.GetString(2),
                                Direccion = reader.GetString(3),
                                Activo = reader.GetInt32(4),
                                Telefono = reader.GetString(5)
                            };
                            lista.Add(cli);
                        }
                    }
                }
            }
            return lista;
        }

        public static void Create (Cliente cliente)
        {
            string sqlQuery = @"INSERT INTO Clientes (nombre,empresa,direccion,telefono) VALUES 
            (@nombre,@empresa,@direccion,@telefono)";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@nombre", (SqliteType) System.Data.SqlDbType.Text).Value = cliente.Nombre;
                    cmd.Parameters.Add("@empresa", (SqliteType)System.Data.SqlDbType.Text).Value = cliente.Empresa;
                    cmd.Parameters.Add("@direccion", (SqliteType)System.Data.SqlDbType.Text).Value = cliente.Direccion;
                    cmd.Parameters.Add("@telefono", (SqliteType)System.Data.SqlDbType.Text).Value = cliente.Telefono;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

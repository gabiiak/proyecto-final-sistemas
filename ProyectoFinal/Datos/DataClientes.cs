using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT id AS Id, nombre AS Nombre, empresa AS Empresa, direccion AS Direccion, activo as Activo, telefono AS Telefono from Clientes WHERE activo != 0";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cli = new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Empresa = reader.GetString(2),
                                Direccion = reader.GetString(3),
                                Activo = reader.IsDBNull(4) ? 1 : (reader.GetBoolean(4) ? 1 : 0),
                                Telefono = reader.GetString(5)
                            };
                            lista.Add(cli);
                        }
                    }
                }
            }
            return lista;
        }
        public static List<Cliente> GetDeleted()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT * FROM Clientes WHERE activo = 0";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cli = new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Empresa = reader.GetString(2),
                                Direccion = reader.GetString(3),
                                Activo = reader.IsDBNull(4) ? 1 : (reader.GetBoolean(4) ? 1 : 0),
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@nombre", (SqlDbType) System.Data.SqlDbType.Text).Value = cliente.Nombre;
                    cmd.Parameters.Add("@empresa", SqlDbType.Text).Value = cliente.Empresa;
                    cmd.Parameters.Add("@direccion", SqlDbType.Text).Value = cliente.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.Text).Value = cliente.Telefono;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Cliente cliente)
        {
            string sqlQuery = @"UPDATE Clientes SET nombre = @nombre, empresa = @empresa, direccion = @direccion, telefono = @telefono WHERE id = @id";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@id",SqlDbType.Int).Value = cliente.Id;
                    cmd.Parameters.Add("@nombre", SqlDbType.Text).Value = cliente.Nombre;
                    cmd.Parameters.Add("@empresa", SqlDbType.Text).Value = cliente.Empresa;
                    cmd.Parameters.Add("@direccion", SqlDbType.Text).Value = cliente.Direccion;
                    cmd.Parameters.Add("@telefono", SqlDbType.Text).Value = cliente.Telefono;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Delete(Cliente cliente) // baja lógica
        {
            string sqlQuery = @"UPDATE Clientes SET activo = 0 WHERE id = @id";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = cliente.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ShowDeletedClients(Cliente cliente) //devolver clientes eliminados
        {
            string sqlQuery = @"UPDATE Clientes SET activo = 1 WHERE id = @id";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = cliente.Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

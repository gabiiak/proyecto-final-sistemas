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
    public class DataProveedores
    {
        public static List<Proveedor> GetAllProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT IdProveedor, Nombre, Direccion, Telefono, Email, activo FROM Proveedores WHERE activo != 0";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor prov = new Proveedor
                            {
                                IdProveedor = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Email = reader.GetString(4),
                                activo = reader.IsDBNull(5) ? 1 : (reader.GetBoolean(5) ? 1 : 0)
                            };
                            lista.Add(prov);
                        }
                    }
                }
            }
            return lista;
        }

        public  static void Create(Proveedor proveedor)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"INSERT INTO Proveedores (Nombre, Direccion, Telefono, Email, activo) VALUES (@Nombre, @Direccion, @Telefono, @Email, @activo)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                    cmd.Parameters.AddWithValue("@activo", proveedor.activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Update(Proveedor proveedor)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Proveedores SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, activo = @activo WHERE IdProveedor = @IdProveedor";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                    cmd.Parameters.AddWithValue("@activo", proveedor.activo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Delete(int idProveedor)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Proveedores SET activo = 0 WHERE IdProveedor = @IdProveedor";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Proveedor> GetDeletedProveedores()
        {
            List<Proveedor> listaDeleted = new List<Proveedor>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT IdProveedor, Nombre, Direccion, Telefono, Email, activo FROM Proveedores WHERE activo = 0";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor prov = new Proveedor
                            {
                                IdProveedor = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Email = reader.GetString(4),
                                activo = reader.IsDBNull(5) ? 1 : (reader.GetBoolean(5) ? 1 : 0)
                            };
                            listaDeleted.Add(prov);
                        }
                    }
                }
            }
            return listaDeleted;
        }

        public static void ShowDeletedProveedores(Proveedor proveedor)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Proveedores SET activo = 1 WHERE IdProveedor = @IdProveedor";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = proveedor.IdProveedor;
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
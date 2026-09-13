using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;

namespace Datos
{
    public class DataEmpleado
    {
        public static int CreateEmpleado(Empleado empleado)
        {
            string sqlQuery = @"INSERT INTO Empleados(nombre, apellido, telefono, cargo, activo, numCuenta, fechaIngreso, sueldo)
                                VALUES (@Nombre, @Apellido, @Telefono, @Cargo, @Activo, @NumCuenta, @FechaIngreso, @Sueldo);
                                SELECT last_insert_rowid();";

            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(empleado.Telefono) ? (object)DBNull.Value : empleado.Telefono);
                    cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                    cmd.Parameters.AddWithValue("@Activo", empleado.Activo);
                    cmd.Parameters.AddWithValue("@NumCuenta", empleado.NumCuenta);
                    cmd.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static List<Empleado> GetAllEmpleados(bool soloActivos = false)
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idEmpleado, nombre, apellido, telefono, cargo, activo, numCuenta, fechaIngreso, sueldo
                                    FROM Empleados";

                if (soloActivos)
                {
                    sqlQuery += " WHERE activo = 1";
                }

                sqlQuery += " ORDER BY apellido, nombre ASC";

                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado
                            {
                                IdEmpleado = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Telefono = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Cargo = reader.GetString(4),
                                Activo = reader.GetInt32(5),
                                NumCuenta = reader.GetInt32(6),
                                FechaIngreso = DateTime.Parse(reader.GetString(7)),
                                Sueldo = reader.GetDouble(8)
                            };
                            lista.Add(empleado);
                        }
                    }
                }
            }
            return lista;
        }

        public static Empleado GetEmpleadoById(int idEmpleado)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idEmpleado, nombre, apellido, telefono, cargo, activo, numCuenta, fechaIngreso, sueldo
                                    FROM Empleados
                                    WHERE idEmpleado = @IdEmpleado";

                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Empleado
                            {
                                IdEmpleado = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Telefono = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Cargo = reader.GetString(4),
                                Activo = reader.GetInt32(5),
                                NumCuenta = reader.GetInt32(6),
                                FechaIngreso = DateTime.Parse(reader.GetString(7)),
                                Sueldo = reader.GetDouble(8)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void UpdateEmpleado(Empleado empleado)
        {
            string sqlQuery = @"UPDATE Empleados 
                                SET nombre = @Nombre,
                                    apellido = @Apellido,
                                    telefono = @Telefono,
                                    cargo = @Cargo,
                                    activo = @Activo,
                                    numCuenta = @NumCuenta,
                                    fechaIngreso = @FechaIngreso,
                                    sueldo = @Sueldo
                                WHERE idEmpleado = @IdEmpleado";

            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(empleado.Telefono) ? (object)DBNull.Value : empleado.Telefono);
                    cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                    cmd.Parameters.AddWithValue("@Activo", empleado.Activo);
                    cmd.Parameters.AddWithValue("@NumCuenta", empleado.NumCuenta);
                    cmd.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Baja lógica: cambia el estado activo a 0
        public static void DesactivarEmpleado(int idEmpleado)
        {
            string sqlQuery = @"UPDATE Empleados SET activo = 0 WHERE idEmpleado = @IdEmpleado";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Baja física: elimina el registro directo de la tabla
        public static void EliminarEmpleado(int idEmpleado)
        {
            string sqlQuery = @"DELETE FROM Empleados WHERE idEmpleado = @IdEmpleado";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
using Microsoft.Data.Sqlite;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataVentas
    {
        public static Dictionary<int, double> GetVentasPorMesAnio(int anio) // gráfico de línea, año completo
        {
            var resultado = new Dictionary<int, double>();
            // inicializar los 12 meses en 0
            for (int m = 1; m <= 12; m++)
                resultado[m] = 0;

            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT strftime('%m', fecha) as mes, SUM(totalVenta) as total
                    FROM Ventas
                    WHERE strftime('%Y', fecha) = @Anio
                      AND estadoPago != @Anulado
                    GROUP BY mes";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Anio", anio.ToString());
                    cmd.Parameters.AddWithValue("@Anulado", EstadoPago.Anulado);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = int.Parse(reader.GetString(0));
                            double total = reader.GetDouble(1);
                            resultado[mes] = total;
                        }
                    }
                }
            }
            return resultado;
        }
        public static List<(string Nombre, double Total)> GetTopClientesPorMonto(int top = 5)// gráfico de barras
        {
            var resultado = new List<(string, double)>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT c.nombre, SUM(v.totalVenta) as totalFacturado
                            FROM Ventas v
                            INNER JOIN Clientes c ON v.idCliente = c.id
                            WHERE v.estadoPago != @Anulado
                            GROUP BY c.id, c.nombre
                            ORDER BY totalFacturado DESC
                            LIMIT @Top";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Anulado", EstadoPago.Anulado);
                    cmd.Parameters.AddWithValue("@Top", top);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add((reader.GetString(0), reader.GetDouble(1)));
                        }
                    }
                }
            }
            return resultado;
        }
        public static Dictionary<int, double> GetVentasPorMesSemestre(int anio, int semestre)// grafico de linea
        {
            // semestre 1 = meses 1-6, semestre 2 = meses 7-12
            int mesInicio = semestre == 1 ? 1 : 7;
            int mesFin = semestre == 1 ? 6 : 12;

            var resultado = new Dictionary<int, double>();
            // inicializar todos los meses en 0
            for (int m = mesInicio; m <= mesFin; m++)
                resultado[m] = 0;

            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT strftime('%m', fecha) as mes, SUM(totalVenta) as total
                            FROM Ventas
                            WHERE strftime('%Y', fecha) = @Anio
                              AND CAST(strftime('%m', fecha) AS INTEGER) BETWEEN @MesInicio AND @MesFin
                              AND estadoPago != @Anulado
                            GROUP BY mes";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Anio", anio.ToString());
                    cmd.Parameters.AddWithValue("@MesInicio", mesInicio);
                    cmd.Parameters.AddWithValue("@MesFin", mesFin);
                    cmd.Parameters.AddWithValue("@Anulado", EstadoPago.Anulado);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = int.Parse(reader.GetString(0));
                            double total = reader.GetDouble(1);
                            resultado[mes] = total;
                        }
                    }
                }
            }
            return resultado;
        }
        public static Venta GetVentaById(int idVenta)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT v.idVenta, v.fecha, v.estadoPago, v.estadoPedido, v.totalVenta,
                                   c.id, c.nombre,
                                   mp.idMetodoPago, mp.descripcion
                            FROM Ventas v
                            INNER JOIN Clientes c ON v.idCliente = c.id
                            INNER JOIN MetodosPago mp ON v.idMetodoPago = mp.idMetodoPago
                            WHERE v.idVenta = @IdVenta";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Venta
                            {
                                IdVenta = reader.GetInt32(0),
                                Fecha = DateTime.ParseExact(
                                    reader.GetString(1),
                                    new string[] { "yyyy-MM-dd", "dd-MM-yyyy" }, // prueba ambos formatos
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None
                                ),
                                //Fecha = reader.GetDateTime(1),
                                Estado_Pago = reader.GetInt32(2),
                                Estado_Pedido = reader.GetInt32(3),
                                Total = reader.GetDouble(4),
                                Cliente = new Cliente
                                {
                                    Id = reader.GetInt32(5),
                                    Nombre = reader.GetString(6)
                                },
                                Metodo = new MetodoPago
                                {
                                    IdMetodoPago = reader.GetInt32(7),
                                    Descripcion = reader.GetString(8)
                                }
                            };
                        }
                        return null;
                    }
                }
            }
        }
        
        public static Venta GetMontoRecibido(int idVenta)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT totalVenta, montoRecibido FROM Ventas WHERE idVenta = @IdVenta";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Venta
                            {
                                Total = reader.GetDouble(0),
                                MontoRecibido = reader.GetDouble(1)
                            };
                        }
                    }
                    return null;
                }
            }
        }
        public static void CambiarMontoRecibido(int idVenta, double total)
        {
            string sqlQuery = @"UPDATE Ventas SET montoRecibido = @MontoRecibido WHERE idVenta = @IdVenta";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmd.Parameters.AddWithValue("@MontoRecibido", total);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Venta> GetAllVentas()
        {
            List<Venta> listaVentas = new List<Venta>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT v.idVenta, c.id, c.nombre, v.fecha, v.totalVenta, mp.descripcion, v.estadoPago, v.estadoPedido
                                    FROM Ventas v
                                    INNER JOIN Clientes c ON v.idCliente = c.id
                                    INNER JOIN MetodosPago mp ON v.idMetodoPago = mp.idMetodoPago";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta
                            {
                                IdVenta = reader.GetInt32(0),
                                Cliente = new Cliente
                                {
                                    Id = reader.GetInt32(1),
                                    Nombre = reader.GetString(2)
                                },
                                Fecha = DateTime.ParseExact(
                                    reader.GetString(3),
                                    new string[] { "yyyy-MM-dd", "dd-MM-yyyy" }, // prueba ambos formatos
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None
                                ),
                                //Fecha = reader.GetDateTime(3),
                                Total = reader.GetDouble(4),
                                Metodo = new MetodoPago
                                {
                                    Descripcion = reader.GetString(5)
                                },
                                Estado_Pago = reader.GetInt32(6),
                                Estado_Pedido = reader.GetInt32(7)
                            };
                            listaVentas.Add(venta);
                        }
                    }
                }
            }
            return listaVentas;
        }
        public static int CreateVenta(Venta venta) // int para devolver el id venta
        {
            string sqlQuery = @"INSERT INTO Ventas(idCliente, idMetodoPago, fecha, estadoPedido, estadoPago, totalVenta, montoRecibido) 
                                VALUES (@Id, @IdMetodoPago, @Fecha, @EstadoPedido, @EstadoPago, @Total, @MontoRecibido);
                                SELECT last_insert_rowid();";

            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Id", (SqliteType)System.Data.SqlDbType.Int).Value = venta.Cliente.Id;
                    cmd.Parameters.Add("@IdMetodoPago", (SqliteType)System.Data.SqlDbType.Int).Value = venta.Metodo.IdMetodoPago;
                    cmd.Parameters.Add("@Fecha", (SqliteType)System.Data.SqlDbType.Text).Value = venta.Fecha.ToString("yyyy-MM-dd"); // <- cambiar a datetime para SQLServer
                    cmd.Parameters.AddWithValue("@EstadoPedido", venta.Estado_Pedido);
                    cmd.Parameters.AddWithValue("@EstadoPago", venta.Estado_Pago);
                    cmd.Parameters.AddWithValue("@Total", venta.Total);
                    cmd.Parameters.AddWithValue("@MontoRecibido", venta.MontoRecibido);
                    //cmd.ExecuteNonQuery(); <- esto llama ejecutar 2 veces. mejor usar execute scalar
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public static void CambiarEstadoPago(int idVenta, int estadoPago)
        {
            string sqlQuery = @"UPDATE Ventas SET estadoPago = @EstadoPago WHERE idVenta = @IdVenta";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmd.Parameters.AddWithValue("@EstadoPago", estadoPago);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void CambiarEstadoPedido(int idVenta, int estadoPedido)
        {
            string sqlQuery = @"UPDATE Ventas SET estadoPedido = @EstadoPedido WHERE idVenta = @IdVenta";
            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmd.Parameters.AddWithValue("@EstadoPedido", estadoPedido);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*using (SqliteConnection connection = Db.GetConnection())
                {
                    string sqlQuery = @"";
                    using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                    {
                        connection.Open();
                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                            }
                        }
                    }
                }*/
    }
}

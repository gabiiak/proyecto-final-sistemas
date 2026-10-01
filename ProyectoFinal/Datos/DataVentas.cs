using System.Data;
using System.Data.SqlClient;
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

            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT MONTH(fecha) as mes, SUM(totalVenta) as total
                    FROM Ventas
                    WHERE YEAR(fecha) = @Anio
                      AND estadoPago != @Anulado
                    GROUP BY MONTH(fecha)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
                    cmd.Parameters.AddWithValue("@Anulado", EstadoPago.Anulado);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = reader.GetInt32(0);
                            double total = (double)reader.GetDecimal(1);
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
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT TOP (@Top) c.nombre, SUM(v.totalVenta) as totalFacturado
                            FROM Ventas v
                            INNER JOIN Clientes c ON v.idCliente = c.id
                            WHERE v.estadoPago != @Anulado
                            GROUP BY c.id, c.nombre
                            ORDER BY totalFacturado DESC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Anulado", EstadoPago.Anulado);
                    cmd.Parameters.AddWithValue("@Top", top);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add((reader.GetString(0), (double)reader.GetDecimal(1)));
                        }
                    }
                }
            }
            return resultado;
        }
        public static int UpdateTotal(int idVenta, double total)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE Ventas SET total = @total WHERE idVenta = @idVenta";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
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

            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT MONTH(fecha) as mes, SUM(totalVenta) as total
                            FROM Ventas
                            WHERE YEAR(fecha) = @Anio
                              AND MONTH(fecha) BETWEEN @MesInicio AND @MesFin
                              AND estadoPago != @Anulado
                            GROUP BY MONTH(fecha)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
                    cmd.Parameters.Add("@MesInicio", SqlDbType.Int).Value = mesInicio;
                    cmd.Parameters.Add("@MesFin", SqlDbType.Int).Value = mesFin;
                    cmd.Parameters.AddWithValue("@Anulado", EstadoPago.Anulado);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = reader.GetInt32(0);
                            double total = (double)reader.GetDecimal(1);
                            resultado[mes] = total;
                        }
                    }
                }
            }
            return resultado;
        }
        public static Venta GetVentaById(int idVenta)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT v.idVenta, v.fecha, v.estadoPago, v.estadoPedido, v.totalVenta,
                                   c.id, c.nombre,
                                   mp.idMetodoPago, mp.descripcion
                            FROM Ventas v
                            INNER JOIN Clientes c ON v.idCliente = c.id
                            INNER JOIN MetodosPago mp ON v.idMetodoPago = mp.idMetodoPago
                            WHERE v.idVenta = @IdVenta";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Venta
                            {
                                IdVenta = reader.GetInt32(0),
                                Fecha = reader.GetDateTime(1),
                                //Fecha = reader.GetDateTime(1),
                                Estado_Pago = (int)reader.GetByte(2),
                                Estado_Pedido = (int)reader.GetByte(3),
                                Total = (double)reader.GetDecimal(4),
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
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT totalVenta, montoRecibido FROM Ventas WHERE idVenta = @IdVenta";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Venta
                            {
                                Total = (double)reader.GetDecimal(0),
                                MontoRecibido = (double)reader.GetDecimal(1)
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT v.idVenta, c.id, c.nombre, v.fecha, v.totalVenta, mp.descripcion, v.estadoPago, v.estadoPedido
                                    FROM Ventas v
                                    INNER JOIN Clientes c ON v.idCliente = c.id
                                    INNER JOIN MetodosPago mp ON v.idMetodoPago = mp.idMetodoPago";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
                                Fecha = reader.GetDateTime(3),
                                Total = (double)reader.GetDecimal(4),
                                Metodo = new MetodoPago
                                {
                                    Descripcion = reader.GetString(5)
                                },
                                Estado_Pago = (int)reader.GetByte(6),
                                Estado_Pedido = (int)reader.GetByte(7)
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
                                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = venta.Cliente.Id;
                    cmd.Parameters.Add("@IdMetodoPago", SqlDbType.Int).Value = venta.Metodo.IdMetodoPago;
                    cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = venta.Fecha;
                    cmd.Parameters.Add("@EstadoPedido", SqlDbType.Int).Value = venta.Estado_Pedido;
                    cmd.Parameters.Add("@EstadoPago", SqlDbType.Int).Value = venta.Estado_Pago;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = (decimal)venta.Total;
                    cmd.Parameters.Add("@MontoRecibido", SqlDbType.Decimal).Value = (decimal)venta.MontoRecibido;
                    //cmd.ExecuteNonQuery(); <- esto llama ejecutar 2 veces. mejor usar execute scalar
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public static void CambiarEstadoPago(int idVenta, int estadoPago)
        {
            string sqlQuery = @"UPDATE Ventas SET estadoPago = @EstadoPago WHERE idVenta = @IdVenta";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
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
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cmd.Parameters.AddWithValue("@EstadoPedido", estadoPedido);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void MarcarPedidoListoConDescuentoStock(int idVenta, List<DetalleVenta> detalles)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    string updateEstado = "UPDATE Ventas SET estadoPedido = @Estado WHERE idVenta = @IdVenta;";
                    using (SqlCommand cmd = new SqlCommand(updateEstado, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Estado", EstadoPedido.Listo);
                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                        cmd.ExecuteNonQuery();
                    }

                    string updateStock = @"UPDATE StockProducto SET cantidad = cantidad - @cantidadVendida
                                    WHERE producto_id = @productoId;";
                    foreach (DetalleVenta detalle in detalles)
                    {
                        using (SqlCommand cmd = new SqlCommand(updateStock, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@cantidadVendida", detalle.Cantidad);
                            cmd.Parameters.AddWithValue("@productoId", detalle.Producto.IdProducto);
                            int filas = cmd.ExecuteNonQuery();

                            if (filas == 0)
                                throw new InvalidOperationException($"No existe stock cargado para el producto '{detalle.Producto.Nombre}'.");
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        /*using (SqlConnection connection = Db.GetConnection())
                {
                    string sqlQuery = @"";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                            }
                        }
                    }
                }*/
    }
}

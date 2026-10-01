using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataDetalleVentas
    {
        public static List<(string Nombre, int Cantidad)> GetProductosMasVendidos(int top = 4) //torta
        {
            var resultado = new List<(string, int)>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT TOP (@Top) p.Nombre, SUM(dv.cantidad) as totalCantidad
                            FROM DetalleVentas dv
                            INNER JOIN Productos p ON dv.idProducto = p.idProducto
                            INNER JOIN Ventas v ON dv.idVenta = v.idVenta
                            WHERE v.estadoPago != @Anulado
                            GROUP BY p.idProducto, p.Nombre
                            ORDER BY totalCantidad DESC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Anulado", EstadoPago.Anulado);
                    cmd.Parameters.AddWithValue("@Top", top);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultado.Add((reader.GetString(0), reader.GetInt32(1)));
                        }
                    }
                }
            }
            return resultado;
        }
        public static List<DetalleVenta> GetDetallesByIdVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT dv.idDetalleVenta, dv.cantidad, dv.subTotal,
                                   p.idProducto, p.nombre
                            FROM DetalleVentas dv
                            INNER JOIN Productos p ON dv.idProducto = p.idProducto
                            WHERE dv.idVenta = @IdVenta";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DetalleVenta
                            {
                                IdDetalleVenta = reader.GetInt32(0),
                                Cantidad = reader.GetInt32(1),
                                SubTotal = reader.GetDecimal(2),
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(3),
                                    Nombre = reader.GetString(4)
                                }
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public static List<DetalleVenta> GetAllDetalleVentas() //para mostrar en la venta todos los detalles
        {
            List<DetalleVenta> listaDetalleVentas = new List<DetalleVenta>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT v.idVenta, dv.idDetalleVenta AS NúmeroDetalle, p.Nombre, dv.cantidad AS Cantidad, dv.subTotal 
                                    FROM DetalleVentas dv INNER JOIN Ventas v on dv.idVenta = v.idVenta INNER JOIN Productos p on dv.idProducto = p.IdProducto";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetalleVenta detalle = new DetalleVenta
                            {
                                Venta = new Venta
                                {
                                    IdVenta = reader.GetInt32(0)
                                },
                                IdDetalleVenta = reader.GetInt32(1),
                                Producto = new Producto
                                {
                                    Nombre = reader.GetString(2),
                                },
                                Cantidad = reader.GetInt32(3),
                                SubTotal = reader.GetDecimal(4)
                            };
                            listaDetalleVentas.Add(detalle);
                        }
                    }
                }
            }
            return listaDetalleVentas;
        }
        public static int CreateDetalleVenta(DetalleVenta detalle) // int para devolver el id venta
        {
            string sqlQuery = @"INSERT INTO DetalleVentas(idVenta, idProducto, cantidad, subTotal) VALUES (@IdVenta, @IdProducto, @Cantidad,@SubTotal);";
            using (SqlConnection connection = Db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Value = detalle.Venta.IdVenta;
                    cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.Producto.IdProducto;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                    cmd.Parameters.AddWithValue("@SubTotal", detalle.SubTotal);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public static DetalleVenta GetById(int id)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT idDetalleVenta, idVenta, idProducto, cantidad, subTotal
                            FROM DetalleVentas WHERE idDetalleVenta = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DetalleVenta
                            {
                                IdDetalleVenta = reader.GetInt32(0),
                                Venta = new Venta
                                {
                                    IdVenta = reader.GetInt32(1)
                                },
                                Producto = new Producto
                                {
                                    IdProducto = reader.GetInt32(2)
                                },
                                Cantidad = reader.GetInt32(3),
                                SubTotal = reader.GetDecimal(4)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public static int UpdateCantidad(int id, int cantidad, decimal nuevoSubTotal, string motivo)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE DetalleVentas 
                            SET cantidad = @cantidad, subTotal = @subTotal, motivoModificacion = @motivo
                            WHERE idDetalleVenta = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@subTotal", nuevoSubTotal);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static decimal GetTotalVentaById(int idVenta)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT SUM(subTotal) FROM DetalleVentas WHERE idVenta = @idVenta";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    connection.Open();
                    object resultado = cmd.ExecuteScalar();
                    return resultado == DBNull.Value || resultado == null ? 0 : Convert.ToDecimal(resultado);
                }
            }
        }
    }
}

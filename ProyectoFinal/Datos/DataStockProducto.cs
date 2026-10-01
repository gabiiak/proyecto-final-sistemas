using System.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Datos
{
    public class DataStockProducto
    {
        public static List<StockProducto> GetAllStock()
        {
            List<StockProducto> listaProductos = new List<StockProducto>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = "Select sp.id, sp.producto_id, p.Nombre, sp.cantidad FROM StockProducto sp INNER JOIN Productos p ON p.IdProducto = sp.producto_id WHERE p.Activo = 1";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StockProducto stock = new StockProducto
                            {
                                Id = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                NombreProducto = reader.GetString(2),
                                CantidadDisponible = (double)reader.GetDecimal(3)
                            };
                            listaProductos.Add(stock);
                        }
                    }
                }
            }
            return listaProductos;
        }
        public static int CrearStock(StockProducto stock)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"INSERT INTO StockProducto (producto_id, cantidad) 
                            VALUES (@productoId, @cantidad);
                            SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@productoId", stock.ProductoId);
                    cmd.Parameters.AddWithValue("@cantidad", stock.CantidadDisponible);
                    connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static int UpdateStock(StockProducto stock)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE StockProducto SET cantidad = @cantidad WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@cantidad", stock.CantidadDisponible);
                    cmd.Parameters.AddWithValue("@id", stock.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static StockProducto GetStockByProductoId(int productoId)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT sp.id, sp.producto_id, p.Nombre, sp.cantidad
                            FROM StockProducto sp
                            INNER JOIN Productos p ON p.IdProducto = sp.producto_id
                            WHERE sp.producto_id = @productoId";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@productoId", productoId);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StockProducto
                            {
                                Id = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                NombreProducto = reader.GetString(2),
                                CantidadDisponible = (double)reader.GetDecimal(3)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public static StockProducto GetStockById(int id)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT sp.id, sp.producto_id, p.Nombre, sp.cantidad FROM StockProducto sp INNER JOIN Productos p ON p.IdProducto = sp.producto_id WHERE sp.id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StockProducto stock = new StockProducto
                            {
                                Id = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                NombreProducto = reader.GetString(2),
                                CantidadDisponible = (double)reader.GetDecimal(3)
                            };
                            return stock;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}

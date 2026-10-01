using System.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    // Requiere la tabla:
    //   CREATE TABLE IF NOT EXISTS Stock (
    //       id INTEGER PRIMARY KEY AUTOINCREMENT,
    //       insumo_id INTEGER NOT NULL,
    //       cantidad REAL NOT NULL DEFAULT 0,
    //       FOREIGN KEY (insumo_id) REFERENCES Insumos(id)
    //   );
    // Agregar esta creación junto al resto del esquema (donde se crea la tabla Insumos).
    public class DataStockInsumo
    {
        public static List<StockInsumo> GetAllStock()
        {
            List<StockInsumo> listaStock = new List<StockInsumo>();
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT s.id, s.insumo_id, i.nombre, s.cantidad, i.unidadMedida
                                    FROM StockInsumo s
                                    INNER JOIN Insumos i ON i.id = s.insumo_id
                                    WHERE i.activo = 1";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StockInsumo stock = new StockInsumo
                            {
                                Id = reader.GetInt32(0),
                                InsumoId = reader.GetInt32(1),
                                NombreInsumo = reader.GetString(2),
                                CantidadDisponible = reader.GetDecimal(3),
                                UnidadMedidaInsumo = reader.GetString(4)
                            };
                            listaStock.Add(stock);
                        }
                    }
                }
            }
            return listaStock;
        }

        public static int createStock(StockInsumo stock)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"INSERT INTO StockInsumo (insumo_id, cantidad) 
                            VALUES (@insumoId, @cantidad);
                            SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@insumoId", stock.InsumoId);
                    cmd.Parameters.AddWithValue("@cantidad", stock.CantidadDisponible);
                    connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()); //para devolver el ID real de la venta
                }
            }
        }

        public static int updateStock(StockInsumo stock)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE StockInsumo 
                                    SET cantidad = @cantidad
                                    WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@cantidad", stock.CantidadDisponible);
                    cmd.Parameters.AddWithValue("@id", stock.Id);
                    connection.Open();
                    return cmd.ExecuteNonQuery(); //execute non query devuelve la cantidad de filas afectadas, por lo que si tira 1 es correcto. si tira 0 es porque no existía
                }
            }
        }

        public static int deleteStock(int id)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"DELETE FROM StockInsumo WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static StockInsumo GetStockById(int id)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT s.id, s.insumo_id, i.nombre, s.cantidad
                                    FROM StockInsumo s
                                    INNER JOIN Insumos i ON i.id = s.insumo_id
                                    WHERE s.id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StockInsumo stock = new StockInsumo
                            {
                                Id = reader.GetInt32(0),
                                InsumoId = reader.GetInt32(1),
                                NombreInsumo = reader.GetString(2),
                                CantidadDisponible = reader.GetDecimal(3)
                            };
                            return stock;
                        }
                        else
                        {
                            return null; // No se encontró el stock con el ID proporcionado
                        }
                    }
                }
            }
        }

        public static StockInsumo GetStockByInsumoId(int insumoId)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT s.id, s.insumo_id, i.nombre, s.cantidad
                            FROM StockInsumo s
                            INNER JOIN Insumos i ON i.id = s.insumo_id
                            WHERE s.insumo_id = @insumoId";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@insumoId", insumoId);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StockInsumo
                            {
                                Id = reader.GetInt32(0),
                                InsumoId = reader.GetInt32(1),
                                NombreInsumo = reader.GetString(2),
                                CantidadDisponible = reader.GetDecimal(3)
                            };
                        }
                        return null;
                    }
                }
            }
        }
    }
}

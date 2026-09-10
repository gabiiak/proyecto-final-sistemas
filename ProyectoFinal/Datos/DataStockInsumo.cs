using Microsoft.Data.Sqlite;
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT s.id, s.insumo_id, i.nombre, s.cantidad
                                    FROM StockInsumo s
                                    INNER JOIN Insumos i ON i.id = s.insumo_id
                                    WHERE i.activo = 1";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StockInsumo stock = new StockInsumo
                            {
                                Id = reader.GetInt32(0),
                                InsumoId = reader.GetInt32(1),
                                NombreInsumo = reader.GetString(2),
                                CantidadDisponible = reader.GetDouble(3)
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"INSERT INTO StockInsumo (insumo_id, cantidad) 
                            VALUES (@insumoId, @cantidad);
                            SELECT last_insert_rowid();";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"UPDATE StockInsumo 
                                    SET cantidad = @cantidad
                                    WHERE id = @id";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
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
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"DELETE FROM StockInsumo WHERE id = @id";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static StockInsumo GetStockById(int id)
        {
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT s.id, s.insumo_id, i.nombre, s.cantidad
                                    FROM StockInsumo s
                                    INNER JOIN Insumos i ON i.id = s.insumo_id
                                    WHERE s.id = @id";
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            StockInsumo stock = new StockInsumo
                            {
                                Id = reader.GetInt32(0),
                                InsumoId = reader.GetInt32(1),
                                NombreInsumo = reader.GetString(2),
                                CantidadDisponible = reader.GetDouble(3)
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
    }
}

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
        public static List<Venta> GetAllVentas()
        {
            List<Venta> listaVentas = new List<Venta>();
            using (SqliteConnection connection = Db.GetConnection())
            {
                string sqlQuery = @"SELECT v.idVenta, v.fecha, v.estadoPedido, v.estadoPago,
                                    c.idCliente, c.nombre,
                                    mp.idMetodoPago, mp.descripcion
                                    FROM Ventas v
                                    INNER JOIN Cliente c ON v.idCliente = c.idCliente
                                    INNER JOIN MetodoPago mp ON v.idMetodoPago = mp.idMetodoPago";
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
                                Fecha = reader.GetString(1),
                                Estado_Pedido = reader.GetInt32(2),
                                Estado_Pago = reader.GetInt32(3),
                                Cliente = new Cliente
                                {
                                    Id = reader.GetInt32(4),
                                    Nombre = reader.GetString(5)
                                },
                                Metodo = new MetodoPago
                                {
                                    IdMetodoPago = reader.GetInt32(6),
                                    Descripcion = reader.GetString(7)
                                }
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
            string sqlQuery = @"INSERT INTO Ventas(idCliente, idMetodoPago, fecha, estadoPedido, estadoPago) 
                                VALUES (@Id, @IdMetodoPago, @Fecha, @EstadoPedido, @EstadoPago);
                                SELECT last_insert_rowid();";

            using (SqliteConnection connection = Db.GetConnection())
            {
                using (SqliteCommand cmd = new SqliteCommand(sqlQuery, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@Id", (SqliteType)System.Data.SqlDbType.Int).Value = venta.Cliente.Id;
                    cmd.Parameters.Add("@IdMetodoPago", (SqliteType)System.Data.SqlDbType.Int).Value = venta.Metodo.IdMetodoPago;
                    cmd.Parameters.Add("@Fecha", (SqliteType)System.Data.SqlDbType.Text).Value = venta.Fecha; // <- cambiar a datetime para SQLServer
                    cmd.Parameters.AddWithValue("@EstadoPedido", venta.Estado_Pedido);
                    cmd.Parameters.AddWithValue("@EstadoPago", venta.Estado_Pago);
                    //cmd.ExecuteNonQuery(); <- esto llama ejecutar 2 veces. mejor usar execute scalar
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
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

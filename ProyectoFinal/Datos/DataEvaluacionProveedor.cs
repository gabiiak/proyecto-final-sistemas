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
    public class DataEvaluacionProveedor
    {
        public static void Guardar(EvaluacionProveedor evaluacion)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sql = @"
                    INSERT INTO EvaluacionProveedor
                    (IdCompra, FechaPrometida, Calidad, Observaciones)
                    VALUES
                    (@IdCompra, @FechaPrometida, @Calidad, @Observaciones)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int)
                        .Value = evaluacion.IdCompra;

                    cmd.Parameters.Add("@FechaPrometida", SqlDbType.Date)
                        .Value = evaluacion.FechaPrometida;

                    cmd.Parameters.Add("@Calidad", SqlDbType.Int)
                        .Value = (object)evaluacion.Calidad ?? DBNull.Value;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 500)
                        .Value = (object)evaluacion.Observaciones ?? DBNull.Value;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Actualizar(EvaluacionProveedor evaluacion)
        {
            using (SqlConnection connection = Db.GetConnection())
            {
                string sql = @"
            UPDATE EvaluacionProveedor
            SET FechaPrometida = @FechaPrometida,
                Calidad = @Calidad,
                Observaciones = @Observaciones
            WHERE IdCompra = @IdCompra";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@IdCompra", SqlDbType.Int)
                        .Value = evaluacion.IdCompra;

                    cmd.Parameters.Add("@FechaPrometida", SqlDbType.Date)
                        .Value = evaluacion.FechaPrometida;

                    cmd.Parameters.Add("@Calidad", SqlDbType.Int)
                        .Value = (object)evaluacion.Calidad ?? DBNull.Value;

                    cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 500)
                        .Value = (object)evaluacion.Observaciones ?? DBNull.Value;

                    connection.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas == 0)
                        throw new InvalidOperationException(
                            "No existe una evaluación para esta compra.");
                }
            }
        }


        public static List<EvaluacionProveedor> ObtenerTodas()
        {
            List<EvaluacionProveedor> lista =
                new List<EvaluacionProveedor>();

            using (SqlConnection connection = Db.GetConnection())
            {
                string sql = @"
                    SELECT IdEvaluacion, IdCompra,
                           FechaPrometida, Calidad, Observaciones
                    FROM EvaluacionProveedor";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EvaluacionProveedor evaluacion =
                                new EvaluacionProveedor
                                {
                                    IdEvaluacion = reader.GetInt32(0),
                                    IdCompra = reader.GetInt32(1),
                                    FechaPrometida = reader.GetDateTime(2),
                                    Calidad = reader.IsDBNull(3)
                                        ? (int?)null : reader.GetInt32(3),
                                    Observaciones = reader.IsDBNull(4)
                                        ? null : reader.GetString(4)
                                };

                            lista.Add(evaluacion);
                        }
                    }
                }
            }

            return lista;
        }
    }
}

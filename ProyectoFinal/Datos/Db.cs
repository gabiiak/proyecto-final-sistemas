using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using SQLitePCL;

namespace Datos
{
    public class Db
    {
        // Nombre de la entrada <connectionStrings> del App.config del proyecto de arranque
        // (en este caso Login\App.config). Ahi esta el servidor, la base y las credenciales.
        private const string ConnectionStringName = "TandGSystem";

        /// <summary>
        /// Conexion a SQL Server. Es la que usa toda la capa de datos.
        /// Nota: el proyecto usa System.Data.SqlClient (nativo de .NET Framework), no Microsoft.Data.SqlClient.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (settings == null)
                throw new ConfigurationErrorsException(
                    "No se encontro la cadena de conexion '" + ConnectionStringName + "' en el App.config.");

            return new SqlConnection(settings.ConnectionString);
        }

        /// <summary>
        /// Conexion a la base SQLite original (mvp.db).
        /// Se conserva unicamente como plan B para volver atras a la version anterior:
        /// ningun archivo de la capa de datos la usa hoy. Si la migracion a SQL Server queda
        /// estable, se puede borrar junto con el paquete Microsoft.Data.Sqlite.
        /// </summary>
        public static SqliteConnection GetSqliteConnection()
        {
            Batteries.Init();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(basePath, "mvp.db");
            string connectionString = $"Data Source= {dbPath}";
            return new SqliteConnection(connectionString);
        }
    }
}
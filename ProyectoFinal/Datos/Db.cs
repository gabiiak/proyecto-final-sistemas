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
        public static SqliteConnection GetConnection()
        {
            Batteries.Init();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(basePath, "mvp.db");
            string connectionString = $"Data Source= {dbPath}";
            return new SqliteConnection(connectionString);
        }
    }
}

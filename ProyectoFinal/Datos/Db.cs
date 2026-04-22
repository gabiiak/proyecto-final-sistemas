using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class Db
    {
        public static SQLiteConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;
            return new SQLiteConnection(connectionString);
        }
    }
}

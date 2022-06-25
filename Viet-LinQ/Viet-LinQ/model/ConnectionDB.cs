
using System.Data.SqlClient;

namespace LinQ_CRUD
{
    public class ConnectionData
    {
        public  SqlConnection GetDatabase()
        {
            string connectionString = "Server =DESKTOP-72U9R1B\\SQLEXPESS;" +
               "Initial Catalog = LinqDB; user=sa;password=sa";
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace c_sharp_exam.connection
{
    public class ConnectDatabase
    {
        public SqlConnection connectDatabaseMSSQL()
        {
            string connectioString = "Server = CARAMEL14\\SQLEXPRESS;" +
                " Initial Catalog =exam2; Integrated Security= SSPI";
            SqlConnection connection = new SqlConnection(connectioString);

            return connection;
        }
    }
}

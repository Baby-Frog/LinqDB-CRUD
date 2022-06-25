using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LinQ_CRUD
{
    public class DeleteEmployeeDao
    {
        public void deleteEmployee(int id)
        {
            ConnectionData connectionData = new ConnectionData();
            SqlConnection connection = connectionData.GetDatabase();
            string query = "DELETE FROM Employee WHERE empID=@empID";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlParameter deleteEmp=new SqlParameter("@empID",id);
            cmd.Parameters.Add(deleteEmp); 
            connection.Open();
            int count = cmd.ExecuteNonQuery();
            Console.WriteLine("Delete {0} success",count);
            connection.Close();
        }
    }
}

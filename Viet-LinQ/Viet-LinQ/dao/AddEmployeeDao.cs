using System;
using System.Collections;
using System.Linq;

using System.Data.SqlClient;
using LinQ_CRUD;
namespace LinQ_CRUD
{
    public class AddEmployeeDao
    {
        public void AddEmployee(string name)
        {
            ConnectionData connection = new ConnectionData();
            SqlConnection sqlConnection = connection.GetDatabase();
            string query = "INSERT INTO Employee VALUES(@empName)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlParameter empName = new SqlParameter("@empName",name);
            cmd.Parameters.Add(empName);
            sqlConnection.Open();
            int data=cmd.ExecuteNonQuery();
            Console.WriteLine("Add {0} Success!!!",data);
            sqlConnection.Close();
        }
    }
}

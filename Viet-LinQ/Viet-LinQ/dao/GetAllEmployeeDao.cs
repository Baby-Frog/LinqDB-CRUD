using System;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;

namespace LinQ_CRUD
{
    public class GetAllEmployeeDao
    {
       public List<Employee> getAll()
        {
            ConnectionData connection=new ConnectionData();
            SqlConnection sqlConnection = connection.GetDatabase();
            string query = "SELECT * FROM Employee";
            SqlCommand cmd =new SqlCommand(query,sqlConnection);
            List<Employee> empList=new List<Employee>();
            sqlConnection.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee emp=new Employee();
                emp.EmpId = Convert.ToInt32(reader[0]);
                emp.EmpName = Convert.ToString(reader[1]);
                empList.Add(emp);
            }
            sqlConnection.Close();
            return empList;
        }
    }
}

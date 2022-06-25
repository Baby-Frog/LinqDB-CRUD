using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace LinQ_CRUD
{
    public class SearchByNameDao
    {
        public List<Employee> searchEmployeeByName(string name)
        {
            ConnectionData connection = new ConnectionData();
            SqlConnection conn = connection.GetDatabase();
            string query = "SELECT * FROM Employee WHERE empName=@empName";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter empName = new SqlParameter("@empName", name);
            cmd.Parameters.Add(empName);
            List<Employee> list = new List<Employee>();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmpId = Convert.ToInt32(reader[0]);
                employee.EmpName = Convert.ToString(reader[1]);
                list.Add(employee);

            }
            return list;
        }
    }
}

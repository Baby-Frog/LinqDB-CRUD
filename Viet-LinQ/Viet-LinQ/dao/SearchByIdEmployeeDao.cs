using System;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;
using LinQ_CRUD;

namespace LinQ_CRUD
{
    public class SearchByIdEmployee
    {
        public List<Employee> searchEmployeeById(int id)
        {
            ConnectionData connection = new ConnectionData();
            SqlConnection conn= connection.GetDatabase();
            string query = "SELECT * FROM Employee WHERE empID=@empID";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter empID = new SqlParameter("@empID", id);
            cmd.Parameters.Add(empID);
            List<Employee> list=new List<Employee>();
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

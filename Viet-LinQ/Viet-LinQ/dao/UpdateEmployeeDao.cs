using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;


namespace LinQ_CRUD
{
    public class UpdateEmployeeDao
    {
        public void UpdateEmployee(Employee employee)
        {
            ConnectionData connectionData = new ConnectionData();
            SqlConnection sqlConnection = connectionData.GetDatabase();
            string query = "UPDATE Employee SET empName=@empName WHERE empID=@empID";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlParameter UpdateEmp = new SqlParameter("@empName", employee.EmpName);
            SqlParameter UpdateEmp1 = new SqlParameter("@empID", employee.EmpId);
            cmd.Parameters.Add(UpdateEmp);
            cmd.Parameters.Add(UpdateEmp1);
            sqlConnection.Open();
            int data=cmd.ExecuteNonQuery();
            Console.WriteLine("Update {0}",data);
            sqlConnection.Close();
        }
    }
}

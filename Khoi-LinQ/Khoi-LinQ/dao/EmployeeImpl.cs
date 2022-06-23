using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Khoi_LinQ.entity;
using Khoi_LinQ.connection;

namespace Khoi_LinQ.dao
{
    internal class EmployeeImpl
    {
        public List<Employee> GetEmployeeData()
        {
            GetConnection connection = new GetConnection();
            SqlConnection conn = connection.GetSqlConnection();
            List<Employee> employees = new List<Employee>();
            string query = "select * from Employee";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader[0]);
                emp.EmployeeName = Convert.ToString(reader[1]);
                employees.Add(emp);
            }
            List<Employee> empProQ1 = employees.Where(emp => emp.EmployeeId.Equals(1)).ToList();
            foreach (Employee employee in empProQ1)
            {
                Console.WriteLine(employee.EmployeeName);
            }
            return empProQ1;
        }

        public void AddEmployeeData()
        {
            GetConnection connection = new GetConnection();
            SqlConnection conn = connection.GetSqlConnection();
            string query = "insert into Employee values (@empName)";
            Console.Write("Enter employee's name: ");
            string nameInput = Console.ReadLine();
            SqlCommand command = new SqlCommand(query, conn);
            SqlParameter EmployeeName = new SqlParameter("@empName", nameInput);
            command.Parameters.Add(EmployeeName);
            conn.Open();
            int DataCount = command.ExecuteNonQuery();
            Console.WriteLine("Insert {0} du lieu thanh cong", DataCount);
            conn.Close();
        }

        public void SearchByName(string name)
        {

        }

        public static void Main(string[] args)
        {
            EmployeeImpl empImpl = new EmployeeImpl();
            empImpl.AddEmployeeData();
        }

    }
}

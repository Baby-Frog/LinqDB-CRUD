using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_CRUD
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public Employee(int empId, string empName)
        {
            EmpId = empId;
            EmpName = empName;
        }

        public Employee()
        {
        }
    }
}

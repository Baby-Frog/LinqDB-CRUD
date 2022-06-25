using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinQ_CRUD
{
    public class Show
    {
        public void menu()
        {
            
            while (true)
            {
                try
                {
                    Console.WriteLine("************Menu**********");
                    Console.WriteLine("1.Add\n2.Update\n3.Delete\n4.ViewAll\n5.Search by Id\n6.Search by name\n7.Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            addEmployee();
                            break;
                        case 2:
                            updateEmployee();
                            break;
                        case 3:
                            deleteEmployee();
                            break;
                        case 4:
                            getAll();
                            break;
                        case 5:
                            searchEmpById();
                            break;
                        case 6:
                            searchEmpByName();
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
        public void searchEmpById()
        {
            Console.WriteLine("Enter id employee:");
            int id=Convert.ToInt32(Console.ReadLine());
            SearchByIdEmployee searchById = new SearchByIdEmployee();
            List<Employee> emplist= searchById.searchEmployeeById(id);
        
            //Cach 1
            var linqSearch=emplist.Select(emp=>emp );
          
            foreach(Employee emp in linqSearch)
            {
                Console.WriteLine("Employee ID:" + emp.EmpId + "\nEmployee Name:" + emp.EmpName);
            }
            //cach 2
            var linqSearch1 = from emp in emplist
                              select emp;
            foreach(Employee emp in linqSearch1)
            {
                Console.WriteLine("Employee ID:" + emp.EmpId + "\nEmployee Name:" + emp.EmpName);
            }
        }
        public void addEmployee()
        {
            Console.WriteLine("Enter name Employee:");
            string name = Console.ReadLine();
            AddEmployeeDao addEmployeeDao=new AddEmployeeDao();
            addEmployeeDao.AddEmployee(name);
        }
        public void updateEmployee()
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter ID employee:");
            emp.EmpId=Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter new name employee:");
            emp.EmpName=Console.ReadLine();
            UpdateEmployeeDao updateEmployeeDao=new UpdateEmployeeDao();
            updateEmployeeDao.UpdateEmployee(emp);
        }
        public void deleteEmployee()
        {
            Console.WriteLine("Enter ID employee:");
            int id = Convert.ToInt32(Console.ReadLine());
            DeleteEmployeeDao deleteEmployee = new DeleteEmployeeDao();
            deleteEmployee.deleteEmployee(id);

        }
        public void getAll()
        {
            GetAllEmployeeDao getAllEmployeeDao=new GetAllEmployeeDao();
            List<Employee> empList= getAllEmployeeDao.getAll();
            //cach 1
            var linQSelect = empList.Select(emp=>emp);
            foreach (Employee emp in linQSelect)
            {
                Console.WriteLine("Employee ID:" + emp.EmpId + "\nEmployee Name:" + emp.EmpName);

            }
            //cach 2
            var linQSelect2 = from emp in empList
                              select emp;
            foreach (Employee emp in linQSelect2)
            {
                Console.WriteLine("Employee ID:" + emp.EmpId + "\nEmployee Name:" + emp.EmpName);

            }
        }
        public void searchEmpByName()
        {
            Console.WriteLine("Enter name employee:");
            string name=Console.ReadLine();
            SearchByNameDao searchByNameDao=new SearchByNameDao();
            List<Employee> emplist =searchByNameDao.searchEmployeeByName(name);

            //Cach 1
            var linqSearch = emplist.Select(emp => emp);

            foreach (Employee emp in linqSearch)
            {
                Console.WriteLine("Employee ID:" + emp.EmpId + "\nEmployee Name:" + emp.EmpName);
            }
            //cach 2
            var linqSearch1 = from emp in emplist
                              select emp;
            foreach (Employee emp in linqSearch1)
            {
                Console.WriteLine("Employee ID:" + emp.EmpId + "\nEmployee Name:" + emp.EmpName);
            }
        }
    }
}

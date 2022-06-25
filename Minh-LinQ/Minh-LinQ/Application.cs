using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_exam.dao;

namespace c_sharp_exam
{
    public class Application
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("---MENU---");
                Console.WriteLine("1. Show");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Exit");

                Console.Write("Choose: ");
                int choose = Convert.ToInt32(Console.ReadLine());

                switch(choose)
                {
                    case 1:
                        Show show = new Show();
                        show.getAllData();
                        break;
                    case 2:
                        Add add = new Add();
                        add.addProduct();
                        break;
                    case 3:
                        DeleteById deleteById = new DeleteById();
                        deleteById.deleteProductById();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

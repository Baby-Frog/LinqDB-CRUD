using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using c_sharp_exam.connection;
using c_sharp_exam.entity;

namespace c_sharp_exam.dao
{
    public class Add
    {
        public void addProduct()
        {
            Product product = new Product();
            ConnectDatabase connectDatabase = new ConnectDatabase();
            SqlConnection connection = connectDatabase.connectDatabaseMSSQL();

            Console.Write("Enter product's name: ");
            product.proName = Console.ReadLine();

            Console.Write("Enter product's price: ");
            product.proPrice = Convert.ToInt32(Console.ReadLine());

            List<Product> products = new List<Product>();

            string query = "insert into product values (@proName, @proPrice)";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlParameter proName = new SqlParameter("@proName", product.proName);
            SqlParameter proPrice = new SqlParameter("@proPrice", product.proPrice);
        
            cmd.Parameters.Add(proName);
            cmd.Parameters.Add(proPrice);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                product.proId = Convert.ToInt32(reader[0]);
                product.proName = Convert.ToString(reader[1]);
                product.proPrice = Convert.ToInt32(reader[2]);

                products.Add(product);
            }

            Console.WriteLine("Add product successfully");
            Console.WriteLine("");

            connection.Close();
        }
    }
}

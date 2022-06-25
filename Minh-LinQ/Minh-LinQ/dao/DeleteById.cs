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
    public class DeleteById
    {
        public void deleteProductById()
        {
            Product product = new Product();
            ConnectDatabase connectDatabase = new ConnectDatabase();
            SqlConnection connection = connectDatabase.connectDatabaseMSSQL();

            Console.Write("Enter product's id: ");
            product.proId = Convert.ToInt32(Console.ReadLine());

            List<Product> products = new List<Product>();

            string query = "delete from product where product.proId = @proId";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlParameter proId = new SqlParameter("@proid", product.proId);

            cmd.Parameters.Add(proId);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                product.proId = Convert.ToInt32(reader[0]);
                product.proName = Convert.ToString(reader[1]);
                product.proPrice = Convert.ToInt32(reader[2]);
            }

            Console.WriteLine("Delete successfully");
            Console.WriteLine("");

            connection.Close();
        }
    }
}

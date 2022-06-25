using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_exam.connection;
using System.Data.SqlClient;
using c_sharp_exam.entity;

namespace c_sharp_exam.dao
{
    public class Show
    {
        public void getAllData()
        {
            ConnectDatabase connectDatabase = new ConnectDatabase();
            SqlConnection connection = connectDatabase.connectDatabaseMSSQL();

            List<Product> productList = new List<Product>();

            string query = "SELECT * FROM product";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.proId = Convert.ToInt32(reader[0]);
                product.proName = Convert.ToString(reader[1]);
                product.proPrice = Convert.ToInt32(reader[2]);

                productList.Add(product);
            }

            var dataList = productList.Select(pro => pro);

            foreach(Product data in dataList)
            {
                Console.WriteLine(data.proId + " " + data.proName + " " + data.proPrice);
            }
            Console.WriteLine("");

            connection.Close();
        }
    }
}

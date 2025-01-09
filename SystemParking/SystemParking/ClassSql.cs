using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SystemParking
{
    class ClassSql
    {
        private string connection;
        public int numberOfAdmin = 0;
        // customer
        public DataTable dt = new DataTable();
        public void GetAllData(string query , string nameTable)
        {
            connection = $@"Data source =HELLO-WORLD\MSSQLSERVER02;Initial Catalog = SystemParking;Integrated Security = true ";
            //string query = $"select *from {table}";
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                ;
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    // table FormAdmin
                    if (nameTable == "FormAdmin")
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //numberOfAdmin = (int)cmd.ExecuteScalar(); // Get count directly
                                numberOfAdmin += 1;
                            }
                        }
                    }
                }
            }
        }
    }
}

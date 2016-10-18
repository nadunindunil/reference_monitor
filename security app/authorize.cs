using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace security_app
{
    class authorize
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\naduni\Documents\rm.mdf;Integrated Security=True;Connect Timeout=30");
        public static string auth(string name,string pass)
        {
            string password = "";
            string acccessLevel = "";
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM [user] where [name]='"+ name+"' ;",connection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["password"].ToString());
                    password = myReader["password"].ToString();
                    acccessLevel = myReader["accessLevel"].ToString();
                }

                connection.Close();

                if (password == pass) return acccessLevel;
                return "false";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "false";
            }
        }

    }
}

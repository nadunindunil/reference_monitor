using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace security_app
{
    class referenceMonitor
    {

        static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\naduni\Documents\rm.mdf;Integrated Security=True;Connect Timeout=30");

        public static Boolean readability(file File, user User)
        {
            
            string secretLvl = "";
            try
            {
                connection.Open();
                
                SqlDataReader myReader2 = null;
                SqlCommand myCommand2 = new SqlCommand("select * from [file] where [path]='" + File.UrlPath+"';",
                                                         connection);
                myReader2 = myCommand2.ExecuteReader();
                while (myReader2.Read())
                {
                    Console.WriteLine(myReader2["secretLevel"].ToString());
                    secretLvl = myReader2["secretLevel"].ToString();
                }

                connection.Close();
                Console.WriteLine(secretLvl);
                Console.WriteLine(User.AccessLevel);
                if (User.AccessLevel <= Int32.Parse(secretLvl)) return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static Boolean writabiliy(file File, user User)
        {
            return !readability(File, User);
        }

    }
}

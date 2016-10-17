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
        
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\NADUN\Documents\rm.mdf;Integrated Security=True;Connect Timeout=30");
        
        public Boolean grantAccess(file File, user User, String action)
        {
            if (File.SecurityLevel == User.AccessLevel) return true;
            return false;
        }

        private Boolean readability(file File,user User) {
            string accessLvl="";
            string secretLvl="";
            try
            {
                connection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from user where name=" + User.Name,
                                                         connection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["accessLevel"].ToString());
                    accessLvl = myReader["accessLevel"].ToString();
                }

                SqlCommand myCommand2 = new SqlCommand("select * from file where name=" + File.Name,
                                                         connection);
                myReader = myCommand2.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["secretLevel"].ToString());
                    secretLvl = myReader["secretLevel"].ToString();
                }

                connection.Close();

                if (Int32.Parse(accessLvl) <= Int32.Parse(secretLvl)) return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        private Boolean writabiliy(file File, user User)
        {
            return true;
        }

    }
}

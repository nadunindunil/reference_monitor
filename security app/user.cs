using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace security_app
{
    class user
    {
        //private static user instance = null;
        private String name;
        //private String pass;
        private String state;
        private int accessLevel;

        public user(string name,int accessLevel)
        {
            this.name = name;
            this.accessLevel = accessLevel;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        

        //public String Pass
        //{
        //    get { return pass; }
        //    set { pass = value; }
        //}
        

        public String State
        {
            get { return state; }
            set { state = value; }
        }
        

        public int AccessLevel
        {
            get { return accessLevel; }
            set { accessLevel = value; }
        }
            
        //public static user getInstance()
        //{
        //    if (instance == null) instance = new user();
        //    return instance;
        //}



    }
}

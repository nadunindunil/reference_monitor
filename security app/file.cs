using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace security_app
{
    class file
    {
        private string securityLevel;
        private string urlPath;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string SecurityLevel
        {
            get { return securityLevel; }
            set { securityLevel = value; }
        }
        

        public string UrlPath
        {
            get { return urlPath; }
            set { urlPath = value; }
        }

        public file(string url) {
            this.urlPath = url;
            //this.securityLevel = SL;
        }

    }
}

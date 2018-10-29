using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sagui.Base.DAL
{
    public class DALBaseHandler: ConfigurationSection
    {
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }
        public string ConnectionStringName
        {
            get
            {
                return (string)base["connectionString"];
            }
        }
        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch (Exception excep)
                {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in web.config. " + excep.Message);
                }
            }
        }
    }
}

using Sagui.Base;
using Sagui.Base.DAL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Base.Factory
{
    public sealed class DbFactory
    {
        public static DALBaseHandler sectionHandler = (DALBaseHandler)ConfigurationManager.GetSection("DALBaseHandler");
        private DbFactory() { }
        public static DALBase CreateDataBase()
        {
            if (sectionHandler?.Name?.Length == 0) throw new Exception("Database name not defined in DbFactoryConfiguration section of config file");
            try
            {
                Type database = Type.GetType(sectionHandler.Name);
                ConstructorInfo constructorInfo = database.GetConstructor(new Type[] { });
                DALBase databaseObj = (DALBase)constructorInfo.Invoke(null);
                databaseObj.connectionString = sectionHandler.ConnectionString;
                return databaseObj;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + sectionHandler.Name + ". " + excep.Message);
            }
        }
    }
}

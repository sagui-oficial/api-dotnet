﻿using Sagui.Base;
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

        //static string HandlerName = "";

        //static string HandlerConnection = default(string);

        //public DbFactory() { }

        //public static DALBase CreateDataBase()
        //{
        //    HandlerName = "Sagui.Base.DAL.DALBaseSQL";
        //    HandlerConnection = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        //    try
        //    {
        //        Type database = Type.GetType(HandlerName);
        //        ConstructorInfo constructorInfo = database.GetConstructor(new Type[] { });
        //        DALBase databaseObj = (DALBase)constructorInfo.Invoke(null);
        //        databaseObj.connectionString = HandlerConnection;
        //        return databaseObj;
        //    }
        //    catch (Exception excep)
        //    {
        //        throw new Exception("Error instantiating database " + HandlerName + ". " + excep.Message);
        //    }
        //}
    }
}

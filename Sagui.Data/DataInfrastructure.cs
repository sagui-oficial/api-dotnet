using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data
{
    public class DataInfrastructure : DataBase, IDisposable
    {
        public static DataInfrastructure dataInfrastructure;
        private static readonly object lockObject = new object();

        public static DataInfrastructure GetInstanceDb(string queryCommand)
        {
            lock (lockObject)
            {
                if (dataInfrastructure == null)
                {
                    dataInfrastructure = new DataInfrastructure(queryCommand);
                }
                else
                {
                    dataInfrastructure = new DataInfrastructure(queryCommand, dataInfrastructure.connection, dataInfrastructure.transaction);
                }
            }

            return dataInfrastructure;
        }


        public static DataInfrastructure GetInstanceDb(string queryCommand, Dictionary<string, object> DbParams)
        {
            lock (lockObject)
            {
                if (dataInfrastructure == null)
                {
                    dataInfrastructure = new DataInfrastructure(queryCommand, DbParams);
                }
                else
                {
                    dataInfrastructure = new DataInfrastructure(queryCommand, DbParams, dataInfrastructure.connection, dataInfrastructure.transaction);
                }
            }
            
            return dataInfrastructure;
        }

        public static void ConnTranControl(bool commit)
        {
            if (commit)
            {
                dataInfrastructure.transaction.Commit();
                
            }
            else
            {
                dataInfrastructure.transaction.Rollback();
            }
        }


        private DataInfrastructure(string queryCommand, IDbConnection dbConnection, IDbTransaction dbTransaction)
            : base(queryCommand, dbConnection, dbTransaction)
        {
        }

        private DataInfrastructure(string queryCommand, Dictionary<string, object> DbParams, IDbConnection dbConnection, IDbTransaction dbTransaction) 
            : base(queryCommand, DbParams, dbConnection, dbTransaction)
        {
        }

        private DataInfrastructure(string queryCommand, Dictionary<string, object> DbParams) : base(queryCommand, DbParams)
        {
            
        }

        private DataInfrastructure(string queryCommand) : base(queryCommand)
        {
        }

        public void Dispose()
        {
            dataInfrastructure = null;
        }
    }

}

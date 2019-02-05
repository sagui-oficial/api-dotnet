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
        public DataInfrastructure(string queryCommand, Dictionary<string, object> DbParams, IDbConnection dbConnection, IDbTransaction dbTransaction) 
            : base(queryCommand, DbParams, dbConnection, dbTransaction)
        {
        }

        public DataInfrastructure(string queryCommand, Dictionary<string, object> DbParams) :base(queryCommand, DbParams)
        {
        }

        public DataInfrastructure(string queryCommand) : base(queryCommand)
        {
        }

        public void Dispose()
        {
            connection.Close();
        }
    }

}

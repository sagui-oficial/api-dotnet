
using Sagui.Base;
using Sagui.Base.DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sagui.Data.Base
{
    public class DataBase : DALWorker
    {
        public SqlCommand command;
        public SqlTransaction transaction;

        public DataBase(string queryCommand, Dictionary<string, object> DbParams)
        {
            using (var conn = dataBase.CreateOpenConnection())
            {
                transaction = (SqlTransaction)conn.BeginTransaction();
                command = (SqlCommand)dataBase.CreateCommand(queryCommand, DbParams, conn, transaction);
            }
        }
    }
}

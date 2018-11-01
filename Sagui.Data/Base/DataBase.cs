
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
        protected IDbConnection connection;

        public DataBase(string queryCommand, Dictionary<string, object> DbParams)
        {
            connection = dataBase.CreateOpenConnection();

            transaction = (SqlTransaction)connection.BeginTransaction();
            command = (SqlCommand)dataBase.CreateCommand(queryCommand, DbParams, connection, transaction);

        }

        public DataBase(string queryCommand)
        {
            connection = dataBase.CreateOpenConnection();

            command = (SqlCommand)dataBase.CreateCommand(queryCommand, connection);

        }
    }
}

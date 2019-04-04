
using Sagui.Base;
using Sagui.Base.DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sagui.Data.Base
{
    public class DataBase : DALWorker
    {
        protected SqlCommand command;
        protected IDbTransaction transaction;
        protected IDbConnection connection;

        public DataBase(string queryCommand, Dictionary<string, object> DbParams, IDbConnection _connection, IDbTransaction _transaction)
        {
            transaction = _transaction;
            connection = _connection;
            command = (SqlCommand)dataBase.CreateCommand(queryCommand, DbParams, _connection, _transaction);
        }

        public DataBase(string queryCommand, Dictionary<string, object> DbParams)
        {
            if(connection == null)
            {
                connection = dataBase.CreateOpenConnection();
            }

            if(transaction == null)
            {
                transaction = (SqlTransaction)connection.BeginTransaction();
            }

            command = (SqlCommand)dataBase.CreateCommand(queryCommand, DbParams, connection, transaction);
        }

        public DataBase(string queryCommand)
        {
            connection = dataBase.CreateOpenConnection();

            command = (SqlCommand)dataBase.CreateCommand(queryCommand, connection);
        }
    }
}

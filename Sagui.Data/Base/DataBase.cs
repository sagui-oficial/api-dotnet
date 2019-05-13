
using Npgsql;
using Sagui.Base.DAL;
using System.Collections.Generic;
using System.Data;

namespace Sagui.Data.Base
{
    public class DataBase : DALWorker
    {
        protected internal NpgsqlCommand command;
        protected internal IDbTransaction transaction;
        protected internal IDbConnection connection;


        public DataBase(string queryCommand, IDbConnection _connection, IDbTransaction _transaction)
        {
            transaction = _transaction;
            connection = _connection;
            command = (NpgsqlCommand)dataBase.CreateCommand(queryCommand, _connection, _transaction);
        }

        public DataBase(string queryCommand, Dictionary<string, object> DbParams, IDbConnection _connection, IDbTransaction _transaction)
        {
            transaction = _transaction;
            connection = _connection;
            command = (NpgsqlCommand)dataBase.CreateCommand(queryCommand, DbParams, _connection, _transaction);
        }

        public DataBase(string queryCommand, Dictionary<string, object> DbParams)
        {
            if(connection == null)
            {
                connection = dataBase.CreateOpenConnection();
            }

            if(transaction == null)
            {
                transaction = (NpgsqlTransaction)connection.BeginTransaction();
            }

            command = (NpgsqlCommand)dataBase.CreateCommand(queryCommand, DbParams, connection, transaction);
        }

        public DataBase(string queryCommand)
        {
            connection = dataBase.CreateOpenConnection();

            command = (NpgsqlCommand)dataBase.CreateCommand(queryCommand, connection);
        }
    }
}

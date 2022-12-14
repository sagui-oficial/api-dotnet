using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Npgsql;


namespace Sagui.Base.DAL
{
    public class DALBaseSQL : DALBase
    {
        public override IDbCommand CreateCommand()
        {
            return new NpgsqlCommand();
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            NpgsqlCommand command = (NpgsqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (NpgsqlConnection)connection;
            command.CommandType = CommandType.Text;
            return command;
        }

        public override IDbCommand CreateCommand(string commandText, IEnumerable<KeyValuePair<string, object>> dbParams, IDbConnection connection)
        {
            NpgsqlCommand command = (NpgsqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (NpgsqlConnection)connection;
            command.CommandType = CommandType.Text;
            IDataParameter[] parameters = this.CreateParameter(dbParams);
            command.Parameters.AddRange(parameters);

            return command;
        }

        public override IDbCommand CreateCommand(string commandText, IEnumerable<KeyValuePair<string, object>> dbParams, IDbConnection connection, IDbTransaction transaction)
        {
            NpgsqlCommand command = (NpgsqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (NpgsqlConnection)connection;
            command.CommandType = CommandType.Text;
            IDataParameter[] parameters = this.CreateParameter(dbParams);
            command.Parameters.AddRange(parameters);
            command.Transaction = (NpgsqlTransaction)transaction;

            return command;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection, IDbTransaction transaction)
        {
            NpgsqlCommand command = (NpgsqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (NpgsqlConnection)connection;
            command.CommandType = CommandType.Text;
            command.Transaction = (NpgsqlTransaction)transaction;

            return command;
        }

        public override IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public override IDbConnection CreateOpenConnection()
        {
            NpgsqlConnection connection = (NpgsqlConnection)CreateConnection();
            connection.Open();
            return connection;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

        public override IDataParameter[] CreateParameter(IEnumerable<KeyValuePair<string, object>> dbParams)
        {
            NpgsqlParameter[] sqlParameters = new NpgsqlParameter[dbParams.Count()];
            for(int i =0; i<dbParams.Count(); i++)
            {
                sqlParameters[i] = new NpgsqlParameter(dbParams.ElementAt(i).Key, dbParams.ElementAt(i).Value);
            }

            return sqlParameters;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            NpgsqlCommand command = (NpgsqlCommand)CreateCommand();
            command.CommandText = procName;
            command.Connection = (NpgsqlConnection)connection;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
    }
}

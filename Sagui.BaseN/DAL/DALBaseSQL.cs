using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Base.DAL
{
    public class DALBaseSQL : DALBase
    {
        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.Text;
            return command;
        }

        public override IDbCommand CreateCommand(string commandText, IEnumerable<KeyValuePair<string, object>> dbParams, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.Text;
            IDataParameter[] parameters = this.CreateParameter(dbParams);
            command.Parameters.AddRange(parameters);

            return command;
        }

        public override IDbCommand CreateCommand(string commandText, IEnumerable<KeyValuePair<string, object>> dbParams, IDbConnection connection, IDbTransaction transaction)
        {
            SqlCommand command = (SqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.Text;
            IDataParameter[] parameters = this.CreateParameter(dbParams);
            command.Parameters.AddRange(parameters);
            command.Transaction = (SqlTransaction)transaction;

            return command;
        }

        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public override IDbConnection CreateOpenConnection()
        {
            SqlConnection connection = (SqlConnection)CreateConnection();
            connection.Open();
            return connection;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

        public override IDataParameter[] CreateParameter(IEnumerable<KeyValuePair<string, object>> dbParams)
        {
            SqlParameter[] sqlParameters = new SqlParameter[dbParams.Count()];
            for(int i =0; i<dbParams.Count(); i++)
            {
                sqlParameters[i] = new SqlParameter(dbParams.ElementAt(i).Key, dbParams.ElementAt(i).Value);
            }

            return sqlParameters;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();
            command.CommandText = procName;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
    }
}

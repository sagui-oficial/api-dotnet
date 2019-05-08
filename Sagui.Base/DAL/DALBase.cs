using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Base.DAL
{
    public abstract class DALBase
    {
        public string connectionString;
        public abstract IDbConnection CreateConnection();
        public abstract IDbCommand CreateCommand();
        public abstract IDbConnection CreateOpenConnection();
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection, IDbTransaction transaction);
        public abstract IDbCommand CreateCommand(string commandText, IEnumerable<KeyValuePair<string, object>> dbParams, IDbConnection connection);
        public abstract IDbCommand CreateCommand(string commandText, IEnumerable<KeyValuePair<string, object>> dbParams, IDbConnection connection, IDbTransaction transaction);
        public abstract IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        public abstract IDataParameter CreateParameter(string parameterName, object parameterValue);
        public abstract IDataParameter[] CreateParameter(IEnumerable<KeyValuePair<string, object>> dbParams);

    }
}

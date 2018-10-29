using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data
{
    public class DataInfrastructure : DataBase
    {
        public DataInfrastructure(string queryCommand, Dictionary<string, object> DbParams) :base(queryCommand, DbParams)
        {
            
        }
    }

}

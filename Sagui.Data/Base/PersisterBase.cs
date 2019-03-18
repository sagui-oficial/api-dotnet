using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Base
{
    public class DBParams
    {
        public Dictionary<string, object> DbParams;
        public DBParams()
        {
            DbParams = new Dictionary<string, object>();
        }
    }
}

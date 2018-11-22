using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Base
{
    public class PersisterBase
    {
        public Dictionary<string, object> DbParams;
        public PersisterBase()
        {
            DbParams = new Dictionary<string, object>();
        }
    }
}

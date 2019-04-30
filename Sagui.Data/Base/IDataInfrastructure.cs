using System;
using System.Collections.Generic;
using System.Text;

namespace Sagui.Data.Base
{
    public interface IDataInfrastructure
    {
        void CommitCommand(bool commit);
    }
}

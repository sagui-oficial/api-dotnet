
using Sagui.Base;
using Sagui.Base.DAL;

namespace Sagui.Data.Base
{
    public class DataBase : DALWorker
    {
        public DataBase()
        {
            dataBase.CreateOpenConnection();
        }
    }
}
